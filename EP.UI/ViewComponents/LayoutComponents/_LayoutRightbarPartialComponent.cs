using Microsoft.AspNetCore.Mvc;

namespace EP.UI.ViewComponents.LayoutComponents
{
    public class _LayoutRightbarPartialComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
