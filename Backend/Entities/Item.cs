using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectIDS309.Backend.Entities
{
    [Table("Item")]
    public class Item
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        //FK       
        public Guid IDCategory { get; set; }
        public Category Category { get; set; }
    }
}
