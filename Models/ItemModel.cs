using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectIDS309.Models
{
    [Table("Item")]
    public class ItemModel
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        //FK       
        public Guid IDCategory { get; set; }
        public CategoryModel Category { get; set; }
    }
}
