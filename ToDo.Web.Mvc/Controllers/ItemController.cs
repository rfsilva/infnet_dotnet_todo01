using Microsoft.AspNetCore.Mvc;
using ToDo.Domain.Entities;
using ToDo.Domain.Interface;
using ToDo.Web.Mvc.Models;

namespace ToDo.Web.Mvc.Controllers
{
    public class ItemController : Controller
    {
        protected IItemRepository repository;

        public ItemController(IItemRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var items = await repository.GetAllAsync();

            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Description")] CreateItemModel createItemModel)
        {
            if (ModelState.IsValid)
            {
                var item = new Item(createItemModel.Description);
                await repository.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }

            return View(createItemModel);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Edit([FromRoute] Guid Id)
        {
            Item item = await repository.getAsync(Id);
            UpdateItemModel model = new UpdateItemModel();
            model.Id = Id;
            model.Description = item.Description;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update([Bind("Id","Description")] UpdateItemModel updateItemModel)
        {
            if (ModelState.IsValid)
            {
                var item = new Item(updateItemModel.Id, updateItemModel.Description);
                await repository.EditAsync(item);
                return RedirectToAction(nameof(Index));
            }

            return View(updateItemModel);
        }


        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {

            await repository.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));
            
        }
    }
}
