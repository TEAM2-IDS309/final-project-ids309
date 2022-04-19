using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectIDS309.Models
{
    [Table("Category")]
    public class CategoryModel
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }

        //FK
        [ForeignKey("IDCategory")]
        public List<ItemModel> Items { get; set; }
    }
}
