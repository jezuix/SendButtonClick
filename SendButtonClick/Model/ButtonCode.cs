namespace ProcessSendButtonClick.Model
{
    static public class ButtonCode
    {
        public static List<ComboBoxObj> ButtonList
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
