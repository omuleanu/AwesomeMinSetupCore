using Microsoft.AspNetCore.Mvc;
using MinSetupCore.Data;
using MinSetupCore.Models;
using MinSetupCore.ViewModels.Input;
using Omu.AwesomeMvc;

namespace MinSetupCore.Controllers
{
    public class DinnersGridCrudController : Controller
    {
        public IActionResult GridGetItems(GridParams g, string search)
        {
            var gmb = new GridModelBuilder<Dinner>(Db.Dinners.AsQueryable(), g)
            {
                KeyProp = o => o.Id, // needed for api select, update, tree, nesting, EF                
            };

            gmb.FilterContainsStr(o => o.Name, search);

            return this.AweJson(gmb.Build());
        }

        public IActionResult Create()
        {
            // make sure to use "return PartialView" for PopupForm/Popup views 
            // this will ignore _viewstart.cshtml so that you don't use the _Layout.cshtml and reload all the scripts
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create(DinnerInput input)
        {
            return Save(input);
        }

        public IActionResult Edit(int id)
        {
            var dinner = Db.Dinners
                .Single(o => o.Id == id);

            var input = new DinnerInput
            {
                Id = dinner.Id,
                Name = dinner.Name,
                ChefId = dinner.Chef.Id,
                Date = dinner.Date,
                MealsIds = dinner.Meals.Select(o => o.Id),
                BonusMealId = dinner.BonusMeal.Id
            };

            return PartialView("Create", input);
        }

        [HttpPost]
        public IActionResult Edit(DinnerInput input)
        {
            return Save(input);
        }

        private IActionResult Save(DinnerInput input)
        {
            if (!ModelState.IsValid) return PartialView("Create", input);

            var isCreate = !input.Id.HasValue;

            var ent = isCreate ? new Dinner() :
                Db.Dinners
                    .First(o => o.Id == input.Id);

            ent.Name = input.Name;
            ent.Date = input.Date.Value;
            ent.Chef = Db.Find<Chef>(input.ChefId);

            // ToList req when using EF
            ent.Meals = Db.Meals
                .Where(o => input.MealsIds.Contains(o.Id)).ToList();

            ent.BonusMeal = Db.Find<Meal>(input.BonusMealId);
            ent.Organic = input.Organic ?? false;

            if (isCreate)
            {
                Db.Add(ent);
            }

            // json obj = success for the popupform, id is used to flash the row
            return this.AweJson(new { Id = ent.Id });
        }

        public IActionResult Delete(int id)
        {
            var dinner = Db.Find<Dinner>(id);

            return PartialView(new DeleteConfirmInput
            {
                Id = id,
                Type = nameof(Dinner).ToLower(),
                Name = dinner.Name
            });
        }

        [HttpPost]
        public IActionResult Delete(DeleteConfirmInput input)
        {
            Db.Delete<Dinner>(input.Id);

            // delete PopupForm's success function will use the Id to animate the row
            return this.AweJson(new { Id = input.Id });
        }
    }
}