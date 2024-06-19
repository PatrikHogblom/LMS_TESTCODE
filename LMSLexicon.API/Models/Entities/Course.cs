using System.Reflection.Metadata;
using System.Reflection;

namespace LMSLexicon.API.Models.Entities
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }

        //foreginkey 

        // Navigation property for modules
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Module> Modules { get; set; } = new List<Module>();
        public ICollection<Document> Documents { get; set; } = new List<Document>();


    }
}
