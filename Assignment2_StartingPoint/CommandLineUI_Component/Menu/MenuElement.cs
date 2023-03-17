namespace CommandLineUI.Menu
{
    public abstract class MenuElement
    {
        public int Id { get; }
        public string Text { get; set; }

        protected MenuElement(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public abstract void Print(string indent);
    }
}
