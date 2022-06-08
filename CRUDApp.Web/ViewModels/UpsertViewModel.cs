using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BDRD.DemoCICD.CRUDAPP.Web.ViewModels;

#nullable disable
public class UpsertViewModel
{
    public int Id { get; set; }
    [Required]
    [MaxLength(200)]
    [MinLength(3)]
    [Display(Name = "Todo item name", Prompt = "Enter todo item name...")]
    public string Name { get; set; }
    [DisplayName("Status")]
    public int Status { get; set; }
    [Required]
    [DisplayName("Start date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    [Required]
    [DisplayName("Due date")]
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; }
    [Display(Name = "Note", Prompt = "Enter todo item note...")]
    public string Note { get; set; }
}