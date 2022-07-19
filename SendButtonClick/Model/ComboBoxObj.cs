namespace ProcessSendButtonClick.Model
{
    public class ComboBoxObj
    {
        public ComboBoxObj(object id, string text)
        {
            Id = id;
            Text = text;
        }

        public object Id { get; set; }
        public string Text { get; set; }
    }
}
