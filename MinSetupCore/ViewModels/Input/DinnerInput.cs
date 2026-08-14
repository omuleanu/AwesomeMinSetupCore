using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Omu.AwesomeMvc;

namespace MinSetupCore.ViewModels.Input
{
    public class DinnerInput
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Length must be between 3 and 50")]        
        public string Name { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [UIHint("MultiLookup")]
        [Required]        
        [DisplayName("Meals")]
        [MultiLookup(Controller = "MealsMultiLookup")]
        public IEnumerable<int> MealsIds { get; set; }

        [UIHint("Lookup")]
        [Required]
        [DisplayName("Chef")]
        [Lookup(Controller = "ChefLookup")]
        public int? ChefId { get; set; }

        [Required]
        [UIHint("DropdownList")]
        [AweUrl(Action = "GetAllMeals", Controller = "Data")]
        [DisplayName("Bonus meal")]
        public int? BonusMealId { get; set; }

        public bool? Organic { get; set; }
    }
}