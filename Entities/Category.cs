using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectIDS309.Entities
{
    [Table("Category")]
    public class Category
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        //FK
        [ForeignKey("IDCategory")]
        public List<Item> Items { get; set; }
    }
}
