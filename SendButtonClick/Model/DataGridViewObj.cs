using static ProcessSendButtonClick.Enum.EventTypeEnum;

namespace ProcessSendButtonClick.Model
{
    public class DataGridViewObj
    {
        public string Text { get; set; }
        public bool? Control { get; set; }
        public bool? Shift { get; set; }
        public bool? Alt { get; set; }
        public string Value { get; set; }
        public EventType EventType { get; set; }
        public bool Editable { get; set; }

        public DataGridViewObj(string text, bool? control, bool? shift, bool? alt, string value, EventType eventType, bool editable = true)
        {
            Text = text;
            Control = control;
            Shift = shift;
            Alt = alt;
            Value = value;
            EventType = eventType;
            Editable = editable;
        }
    }
}
