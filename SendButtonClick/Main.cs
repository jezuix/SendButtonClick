using System.Diagnostics;
using System.Runtime.InteropServices;
using ProcessSendButtonClick.Extension;
using ProcessSendButtonClick.Model;

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

        public Main()
        {
            InitializeComponent();

            CreatButtonListCheckBox();
            CreateProcessListCheckBox();
        }

        private void CreatButtonListCheckBox()
        {
            var buttonList = ButtonCode.ButtonList;

            if (buttonList is not null)
            {
                cbButtonClick.DataSource = buttonList.ToComboBoxDataSource();
                cbButtonClick.DisplayMember = "Text";
                cbButtonClick.ValueMember = "Id";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtButton.BackColor = Color.White;

            if (!string.IsNullOrWhiteSpace(txtButton.Text))
            {

            }
            else
            {
                txtButton.BackColor = Color.Red;
            }
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

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            var (valid, process) = ValidateSelectedProcess();
            if (valid)
                SetForegroundWindow(process.MainWindowHandle);
        }

        internal (bool valid, Process process) ValidateSelectedProcess()
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
    }
}