using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ProcessSendButtonClick.Extension;
using ProcessSendButtonClick.Model;
using static ProcessSendButtonClick.Enum.EventTypeEnum;

namespace ProcessSendButtonClick
{
    public partial class Main : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        private IList<DataGridViewObj> ListButtonSequence { get; set; } = new List<DataGridViewObj>();
        private int EditedIndex { get; set; } = -1;

        private CancellationTokenSource cts;
        private bool startedLoop = false;

        private const string pauseDefault = "1000";
        private int pauseIntDefault = int.Parse(pauseDefault);
        private const string actionLoopDefault = "10";
        private const string universalPauseDefault = "50";
        private int universalPauseIntDefault = int.Parse(universalPauseDefault);

        public Main()
        {
            InitializeComponent();

            CreateProcessListCheckBox();
            CreatButtonListCheckBox();
            CreateDataGridView();

            ClearAll();
        }

        #region Events

        #region Process Name

        private void ddlProcessNameId_Click(object sender, EventArgs e)
        {
            CreateProcessListCheckBox();
        }

        private void btnMaximizeProcess_Click(object sender, EventArgs e)
        {
            var (valid, process) = ValidateSelectedProcess();
            if (valid)
                SetForegroundWindow(process.MainWindowHandle);
            else
                SetErrorAlert(ddlProcessNameId);
        }

        #endregion

        #region Button Click

        private void btnAddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtButton.Text))
            {
                if (EditedIndex < 0)
                    AddButtonEvent();
                else
                    EditButtonEvent();

                ClearAll();
            }
        }

        #endregion

        #region Pre setted Button Click

        private void btnAddPreSetButton_Click(object sender, EventArgs e)
        {
            cbPreSetButtonClick.BackColor = Color.White;
            if (cbPreSetButtonClick.SelectedIndex > 0)
            {
                if (EditedIndex < 0)
                    AddPreSetButtonEvent();
                else
                    EditPreSetButtonEvent();

                ClearAll();
            }
            else
                cbPreSetButtonClick.BackColor = Color.Red;
        }

        #endregion

        #region Pause

        private void txtPause_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !ValidateKeyPressIsValidNumber(e);
        }

        private void btnAddPause_Click(object sender, EventArgs e)
        {
            txtPause.BackColor = Color.White;
            if (!string.IsNullOrWhiteSpace(txtPause.Text))
            {
                if (EditedIndex < 0)
                    AddPauseEvent();
                else
                    EditPauseEvent();

                ClearAll();
            }
            else
                txtPause.BackColor = Color.Red;
        }

        #endregion

        #region Action Loop

        private void txtLoop_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !ValidateKeyPressIsValidNumber(e);
        }

        private void btnAddLoop_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Universal Pause (Pause inner events)

        private void txtUniversalPause_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !ValidateKeyPressIsValidNumber(e);
        }

        private void txtUniversalPause_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(txtUniversalPause.Text, out var universalPause))
                universalPause = 0;

            if (universalPause < 50)
                txtUniversalPause.Text = universalPauseDefault;
        }

        #endregion

        #region DataGrid

        private void dgvButtonSequence_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                ChangeAllEnabled(false);
                ChangeAllButtonAddEditName();
                ClearAllItens();

                EditedIndex = e.RowIndex;
                var buttonSequenceEditaded = ListButtonSequence.ElementAt(EditedIndex);
                switch (buttonSequenceEditaded.EventType)
                {
                    case EventType.ButtonClick:
                        EditButtonClick();
                        break;
                    case EventType.PreSetButtonClick:
                        EditPreSetButtonClick();
                        break;
                    case EventType.Pause:
                        EditPauseClick(buttonSequenceEditaded.Value.ToString());
                        break;
                    default:
                        break;
                }
            }
            else if (e.ColumnIndex == 7)
            {
                DeleteButtonClick(e.RowIndex);
            }
        }

        #endregion

        #region Start/Stop Button

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (ddlProcessNameId.SelectedIndex == 1)
            {
                MessageBox.Show("Select a process to send a button click", "Missing configuration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (startedLoop)
                {
                    cts.Cancel();
                    btnStartStop.Text = "Start";
                    startedLoop = false;
                }
                else
                {
                    var (valid, process) = ValidateSelectedProcess();
                    if (valid)
                    {
                        cts = new CancellationTokenSource();
                        Task.Run(async () => await ExecuteButtonSequence(process, cts.Token));

                        btnStartStop.Text = "Stop";
                        startedLoop = true;
                    }
                }

                ChangeAllEnabled(!startedLoop);
                ddlProcessNameId.Enabled = !startedLoop;
            }
        }

        #endregion

        #endregion

        #region Geral Methods

        private void CreateProcessListCheckBox()
        {
            var processList = Process.GetProcesses()?.ToComboBoxObjList();

            if (processList is not null)
            {
                ddlProcessNameId.DataSource = processList.ToComboBoxDataSource();
                ddlProcessNameId.DisplayMember = "Text";
                ddlProcessNameId.ValueMember = "Id";
            }
        }

        private void CreatButtonListCheckBox()
        {
            var buttonList = ButtonCode.ButtonList;

            if (buttonList is not null)
            {
                cbPreSetButtonClick.DataSource = buttonList.ToComboBoxDataSource();
                cbPreSetButtonClick.DisplayMember = "Text";
                cbPreSetButtonClick.ValueMember = "Id";
            }
        }

        private void CreateDataGridView()
        {
            dgvButtonSequence.RowHeadersVisible = false;
            dgvButtonSequence.AutoGenerateColumns = false;
            dgvButtonSequence.DataSource = new BindingList<DataGridViewObj>(ListButtonSequence);

            //Text 
            dgvButtonSequence.Columns.Add(new DataGridViewColumn()
            {
                HeaderText = "Text",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "Text",
                CellTemplate = new DataGridViewTextBoxCell()
            });

            //Control
            dgvButtonSequence.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                HeaderText = "Control",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                DataPropertyName = "Control",
                ValueType = typeof(bool?),
                ThreeState = true
            });

            ////Shift 
            dgvButtonSequence.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                HeaderText = "Shift",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                DataPropertyName = "Shift",
                ValueType = typeof(bool?),
                ThreeState = true
            });

            ////Alt
            dgvButtonSequence.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                HeaderText = "Alt",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                DataPropertyName = "Alt",
                ValueType = typeof(bool?),
                ThreeState = true
            });

            ////Value
            dgvButtonSequence.Columns.Add(new DataGridViewColumn()
            {
                HeaderText = "Value",
                Visible = false,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                DataPropertyName = "Value",
                CellTemplate = new DataGridViewTextBoxCell()
            });

            ////EventType
            dgvButtonSequence.Columns.Add(new DataGridViewColumn()
            {
                HeaderText = "EventType",
                Visible = false,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = "EventType",
                CellTemplate = new DataGridViewTextBoxCell()
            });

            //Edit
            dgvButtonSequence.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = string.Empty,
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            });

            //Delete
            dgvButtonSequence.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = string.Empty,
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            });

            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            dgvButtonSequence.DataSource = new BindingList<DataGridViewObj>(ListButtonSequence);
            dgvButtonSequence.Update();
        }

        #endregion

        #region Validation Methods

        private (bool valid, Process process) ValidateSelectedProcess()
        {
            var returnValue = false;
            var process = new Process();

            if (ddlProcessNameId.SelectedItem is ComboBoxObj selectedItem && !string.IsNullOrWhiteSpace(selectedItem.Id.ToString()))
                if (int.TryParse(selectedItem.Id.ToString(), out var id))
                {
                    process = Process.GetProcessById(id);
                    if (process is not null)
                        returnValue = process.MainWindowHandle != IntPtr.Zero;
                    else
                        process = new Process();
                }

            return (returnValue, process);
        }

        private bool ValidateKeyPressIsValidNumber(KeyPressEventArgs e)
        {
            return char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar);
        }

        #endregion

        private void EditButtonClick()
        {
            var buttonSequenceEditaded = ListButtonSequence.ElementAt(EditedIndex);
            var enabled = true;

            txtButton.Enabled = enabled;
            chkCtrl.Enabled = enabled;
            chkShift.Enabled = enabled;
            chkAlt.Enabled = enabled;
            btnAddButton.Enabled = enabled;

            btnAddButton.Text = "Edit";

            txtButton.Text = buttonSequenceEditaded.Text;
            chkCtrl.Checked = buttonSequenceEditaded.Control ?? false;
            chkShift.Checked = buttonSequenceEditaded.Shift ?? false;
            chkAlt.Checked = buttonSequenceEditaded.Alt ?? false;
        }

        private void EditPreSetButtonClick()
        {
            var buttonSequenceEditaded = ListButtonSequence.ElementAt(EditedIndex);
            var enabled = true;

            cbPreSetButtonClick.Enabled = enabled;
            btnAddPreSetButton.Enabled = enabled;

            btnAddPreSetButton.Text = "Edit";

            cbPreSetButtonClick.SelectedValue = buttonSequenceEditaded.Value;
        }

        private void EditPauseClick(string pauseTime)
        {
            var enabled = true;

            txtPause.Enabled = enabled;
            btnAddPause.Enabled = enabled;

            btnAddPause.Text = "Edit";

            txtPause.Text = pauseTime;
        }

        private void DeleteButtonClick(int rowIndex)
        {
            var dialogResult = MessageBox.Show("Are you sure you want to delete this row?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                ListButtonSequence.RemoveAt(rowIndex);

            UpdateDataGridView();
        }

        private void AddButtonEvent()
        {
            var value = chkShift.Checked ?
                txtButton.Text.ToUpper() :
                txtButton.Text.ToLower();

            var listButtonSequence = ListButtonSequence;
            listButtonSequence.Add(new DataGridViewObj(txtButton.Text, chkCtrl.Checked, chkShift.Checked, chkAlt.Checked, value, EventType.ButtonClick));
            ListButtonSequence = listButtonSequence;

            UpdateDataGridView();
        }

        private void AddPreSetButtonEvent()
        {
            var value = cbPreSetButtonClick.SelectedValue?.ToString() ?? string.Empty;

            var listButtonSequence = ListButtonSequence;
            listButtonSequence.Add(new DataGridViewObj(cbPreSetButtonClick.Text, null, null, null, value, EventType.PreSetButtonClick));
            ListButtonSequence = listButtonSequence;

            UpdateDataGridView();
        }

        private void AddPauseEvent()
        {
            var listButtonSequence = ListButtonSequence;
            listButtonSequence.Add(new DataGridViewObj($"Pause-{txtPause.Text} milliseconds", null, null, null, txtPause.Text, EventType.Pause));
            ListButtonSequence = listButtonSequence;

            UpdateDataGridView();
        }

        private void EditButtonEvent()
        {
            var value = chkShift.Checked ?
                txtButton.Text.ToUpper() :
                txtButton.Text.ToLower();


            var listButtonSequence = ListButtonSequence;
            listButtonSequence[EditedIndex] = new DataGridViewObj(txtButton.Text, chkCtrl.Checked, chkShift.Checked, chkAlt.Checked, value, EventType.ButtonClick);
            ListButtonSequence = listButtonSequence;

            UpdateDataGridView();
        }

        private void EditPreSetButtonEvent()
        {
            var value = cbPreSetButtonClick.SelectedValue?.ToString() ?? string.Empty;

            var listButtonSequence = ListButtonSequence;
            listButtonSequence[EditedIndex] = new DataGridViewObj(cbPreSetButtonClick.Text, null, null, null, value, EventType.PreSetButtonClick);
            ListButtonSequence = listButtonSequence;

            UpdateDataGridView();
        }

        private void EditPauseEvent()
        {
            var listButtonSequence = ListButtonSequence;
            listButtonSequence[EditedIndex] = new DataGridViewObj(txtPause.Text, null, null, null, txtPause.Text, EventType.Pause);
            ListButtonSequence = listButtonSequence;

            UpdateDataGridView();
        }

        private void ChangeAllEnabled(bool enabled)
        {
            txtButton.Enabled = enabled;
            chkCtrl.Enabled = enabled;
            chkShift.Enabled = enabled;
            chkAlt.Enabled = enabled;
            btnAddButton.Enabled = enabled;
            cbPreSetButtonClick.Enabled = enabled;
            btnAddPreSetButton.Enabled = enabled;
            txtPause.Enabled = enabled;
            btnAddPause.Enabled = enabled;
            txtLoop.Enabled = enabled;
            btnAddLoop.Enabled = enabled;
        }

        private void ChangeAllButtonAddEditName()
        {
            var btnAddButtonText = "Add";

            btnAddButton.Text = btnAddButtonText;
            btnAddPreSetButton.Text = btnAddButtonText;
            btnAddPause.Text = btnAddButtonText;
        }

        private void ClearAllItens()
        {
            txtButton.Text = string.Empty;
            chkCtrl.Checked = false;
            chkShift.Checked = false;
            chkAlt.Checked = false;
            cbPreSetButtonClick.SelectedIndex = 0;

            txtPause.Text = pauseDefault;
            txtLoop.Text = actionLoopDefault;
            txtUniversalPause.Text = universalPauseDefault;
        }

        private void ClearErrorAlert()
        {
            Controls.Cast<Control>().ToList().ForEach(c => c.BackColor = Color.White);
        }

        private void SetErrorAlert(Control control, Color? color = null)
        {
            control.BackColor = color ?? Color.Red;
        }

        private void ClearAll()
        {
            ChangeAllEnabled(true);
            ChangeAllButtonAddEditName();
            ClearAllItens();
            ClearErrorAlert();

            EditedIndex = -1;
        }

        private async Task ExecuteButtonSequence(Process process, CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                for (int i = 0; i < ListButtonSequence.Count; i++)
                {
                    var item = ListButtonSequence[i];
                    var loopControl = new Dictionary<string, int>();

                    var actualProcess = GetForegroundWindow();
                    Console.WriteLine(actualProcess);

                    switch (item.EventType)
                    {
                        case EventType.ButtonClick:
                        case EventType.PreSetButtonClick:
                            string keypess = string.Empty;

                            if (item.Shift.HasValue && item.Shift.Value)
                                keypess += "+";
                            if (item.Control.HasValue && item.Control.Value)
                                keypess += "^";
                            if (item.Alt.HasValue && item.Alt.Value)
                                keypess += "%";

                            keypess += item.Value;

                            SetForegroundWindow(process.MainWindowHandle);
                            SendKeys.SendWait($"{keypess}");
                            SendKeys.Flush();

                            if (actualProcess != IntPtr.Zero && actualProcess != process.MainWindowHandle)
                                SetForegroundWindow(actualProcess);
                            break;
                        case EventType.Pause:
                            if (int.TryParse(item.Value, out var pauseTime))
                                Thread.Sleep(pauseTime);
                            break;
                        case EventType.LoopIni:
                            break;
                        case EventType.LoopEnd:
                            break;
                        default:
                            break;
                    }

                    var _ = int.TryParse(txtUniversalPause.Text, out int universalPause);

                    Thread.Sleep(universalPause < universalPauseIntDefault ? universalPauseIntDefault : universalPause);
                }

                if (ListButtonSequence.Where(x => x.EventType == EventType.Pause).Sum(x => int.Parse(x.Value)) < pauseIntDefault)
                    Thread.Sleep(pauseIntDefault);
            }

        }
    }
}