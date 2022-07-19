using ProcessSendButtonClick.Model;

namespace ProcessSendButtonClick.Extension
{
    public static class ComboBoxObjExtension
    {
        public static IList<ComboBoxObj> ToComboBoxDataSource(this IEnumerable<ComboBoxObj> listComboBoxObj)
        {
            var retorno = listComboBoxObj.ToList();
            retorno.Insert(0, new ComboBoxObj(string.Empty, "Select item"));

            return retorno;
        }
    }
}
