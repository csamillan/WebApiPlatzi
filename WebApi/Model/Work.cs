using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatziEntityFramework.Model
{
    public class Work
    {
        //[Key]
        public Guid WorkId { get; set; }

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        //[Required]
        //[MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public DateTime DateCreate { get; set; }

        public virtual Category Category { get; set; }

       // [NotMapped]
        public string Summary { get; set; }

        public string comentary { get; set; }
    }
}

public enum Priority
{
    Low,

    Medium, 
    
    High
}
