using System.Diagnostics;
using System.Runtime.InteropServices;

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
            CreateProcessListCheckBox();
        }

        private void CreateProcessListCheckBox()
        {
            var processCollection = Process.GetProcesses();
            var cbMemberList = processCollection.ToList().Select(x =>
                new ComboBoxObj(
                    x.Id,
                    $"{x.ProcessName} - {x.Id}"
                ))
                .OrderBy(x => x.Text)
                .ToArray();

            cbProcessNameId.Items.Add(string.Empty);
            cbProcessNameId.SelectedIndex = 0;

            cbProcessNameId.DataSource = cbMemberList;
            cbProcessNameId.DisplayMember = "Text";
            cbProcessNameId.ValueMember = "Id";
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
                if (cbProcessNameId.SelectedItem is ComboBoxObj selectedItem)
                {
                    var actualProcess = GetForegroundWindow();

                    //getting notepad's process | at least one instance of notepad must be running
                    var process = Process.GetProcessById(selectedItem.Id);

                    if (process.MainWindowHandle != IntPtr.Zero)
                    {
                        SetForegroundWindow(process.MainWindowHandle);
                        SendKeys.SendWait("{TAB}");
                        SendKeys.SendWait("{TAB}");
                        SendKeys.SendWait("{ENTER}");
                        SendKeys.SendWait("CHEWBACCA");
                        SendKeys.Flush();
                    }

                    if (actualProcess != IntPtr.Zero)
                        SetForegroundWindow(actualProcess);
                }
            }
        }
    }
}