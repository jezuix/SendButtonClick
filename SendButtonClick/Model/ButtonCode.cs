namespace ProcessSendButtonClick.Model
{
    static public class ButtonCode
    {
        public static IList<ComboBoxObj> ButtonList
        {
            get
            {
                return new List<ComboBoxObj>
                {
                    new ComboBoxObj("{ENTER}", "Enter"),
                    new ComboBoxObj("{TAB}", "Tab")
                };
            }
        }
    }
}
