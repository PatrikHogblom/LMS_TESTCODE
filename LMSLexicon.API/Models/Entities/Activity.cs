namespace LMSLexicon.API.Models.Entities
{
    public class Activity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ActivityType Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        //foreginkey
        public int ModuleID { get; set; }

        //navigation
        public Module Module { get; set; }
        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }

    public enum ActivityType
    {
        Lecture,
        Assignment,
        Quiz,
        Discussion
    }
}
