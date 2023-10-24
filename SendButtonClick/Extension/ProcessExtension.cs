using System.Diagnostics;
using ProcessSendButtonClick.Model;

namespace ProcessSendButtonClick.Extension
{
    public static class ProcessExtension
    {
        public static IList<ComboBoxObj> ToComboBoxObjList(this Process[] processCollection)
        {
            return processCollection
                .Where(x => x.MainWindowHandle != IntPtr.Zero)
                .Select(x => new ComboBoxObj(x.Id, $"{x.ProcessName} - {x.Id}"))
                .OrderBy(x => x.Text)
                .ToList();
        }
    }
}
