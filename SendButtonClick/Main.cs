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

        public Main()
        {
            InitializeComponent();

            CreatButtonListCheckBox();
            CreateProcessListCheckBox();
            CreateDataGridView();
        }

        #region Events

        private void btnAddButton_Click(object sender, EventArgs e)
        {
            txtButton.BackColor = Color.White;
            if (!string.IsNullOrWhiteSpace(txtButton.Text))
            {
                if (EditedIndex < 0)
                    AddButtonEvent();
                else
                    EditButtonEvent();

                ClearAll();
            }
            else
                txtButton.BackColor = Color.Red;
        }

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

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (cbProcessNameId.SelectedIndex == 1)
            {
                MessageBox.Show("Select a process to send a button click", "Missing configuration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                var (valid, process) = ValidateSelectedProcess();
                if (valid)
                {
                    var actualProcess = GetForegroundWindow();
                    SetForegroundWindow(process.MainWindowHandle);
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{TAB}");
                    SendKeys.SendWait("{ENTER}");
                    SendKeys.SendWait("CHEWBACCA");
                    SendKeys.Flush();

                    if (actualProcess != IntPtr.Zero)
                        SetForegroundWindow(actualProcess);
                }
            }
        }

        private void btnMaximizeProcess_Click(object sender, EventArgs e)
        {
            var (valid, process) = ValidateSelectedProcess();
            if (valid)
                SetForegroundWindow(process.MainWindowHandle);
        }

        private void txtPause_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !ValidateKeyPressIsValidNumber(e);
        }

        private void txtUniversalPause_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !ValidateKeyPressIsValidNumber(e);
        }

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

        #region Methods

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

        private void CreateProcessListCheckBox()
        {
            var processList = Process.GetProcesses()?.ToComboBoxObjList();

            if (processList is not null)
            {
                cbProcessNameId.DataSource = processList.ToComboBoxDataSource();
                cbProcessNameId.DisplayMember = "Text";
                cbProcessNameId.ValueMember = "Id";
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
            //UseCheckBoxForNullableBool(dgvButtonSequence);
            dgvButtonSequence.Update();
        }

        private (bool valid, Process process) ValidateSelectedProcess()
        {
            var returnValue = false;
            var process = new Process();

            if (cbProcessNameId.SelectedItem is ComboBoxObj selectedItem && !string.IsNullOrWhiteSpace(selectedItem.Id.ToString()))
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
            var dialogResult = MessageBox.Show("Desire delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            txtPause.Text = "1000";
        }

        private void ClearAll()
        {
            ChangeAllEnabled(true);
            ChangeAllButtonAddEditName();
            ClearAllItens();

            EditedIndex = -1;
        }

        private bool ValidateKeyPressIsValidNumber(KeyPressEventArgs e)
        {
            return char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar);
        }

        #endregion
    }
}