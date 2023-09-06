using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PlatziEntityFramework.Model
{
    public class Category
    {
        //[Key]
        public Guid CategoryID { get; set; }

        //[Required]
        //[MaxLength(150)]
        public string Name { get; set; }    

        public string Description { get; set; }

        public int Weigth { get; set; }

        [JsonIgnore]
        public virtual ICollection<Work> Works { get; set; }

    }
}
