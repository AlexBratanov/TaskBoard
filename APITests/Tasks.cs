namespace APITests
{
    public class Tasks
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string msg { get; set; }
        public string errMsg { get; set; }
        public Board board { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
    }
}