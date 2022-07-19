using System.Diagnostics;
using ProcessSendButtonClick.Model;

namespace ProcessSendButtonClick.Extension
{
    public static class ProcessExtension
    {
        public static List<ComboBoxObj> ToComboBoxObjList(this Process[] processCollection)
        {
            return processCollection.ToList().Select(x =>
                new ComboBoxObj(
                    x.Id,
                    $"{x.ProcessName} - {x.Id}"
                ))
                .OrderBy(x => x.Text)
                .ToList();
        }
    }
}
