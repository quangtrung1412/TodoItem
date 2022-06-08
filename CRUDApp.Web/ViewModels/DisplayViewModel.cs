using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BDRD.DemoCICD.CRUDAPP.Web.ViewModels;
#nullable disable
public class DisplayViewModel
{
    public int Id { get; set; }
    [Display(Name = "Todo item name", Prompt = "Enter todo item name...")]
    public string Name { get; set; }
    [DisplayName("Status")]
    public ItemStatusViewModel Status { get; set; }
    public string StartDate { get; set; }
    public string DueDate { get; set; }
    public string Note { get; set; }
}