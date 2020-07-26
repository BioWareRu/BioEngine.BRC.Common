using System.Collections.Generic;
using System.Threading.Tasks;
using BioEngine.BRC.Common.Entities;
using BioEngine.BRC.Common.Repository;
using BioEngine.BRC.Common.Web;
using Microsoft.AspNetCore.Mvc;

namespace BioEngine.BRC.Site.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly MenuRepository _menuRepository;

        public MenuViewComponent(MenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menu = await _menuRepository.GetSiteMenuAsync(HttpContext.Features.Get<CurrentSiteFeature>().Site);

            return View(menu);
        }
    }

    public struct MenuLevel
    {
        public int Level;
        public List<MenuItem> Items;
    }
}
