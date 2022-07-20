namespace ProcessSendButtonClick.Model
{
    public class ComboBoxObj
    {
        public object Id { get; set; }
        public string Text { get; set; }

        public ComboBoxObj(object id, string text)
        {
            Id = id;
            Text = text;
        }
    }
}
