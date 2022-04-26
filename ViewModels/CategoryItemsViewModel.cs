using FinalProjectIDS309.Models;

namespace FinalProjectIDS309.ViewModels
{
  public class CategoryItemsViewModel
  {
    public Guid? categoryId { get; set; }
    public string CategoryName { get; set; }
    public List<ItemModel> Items { get; set; }

  }

}