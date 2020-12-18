namespace TeslaService.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : BaseController
    {
        public IActionResult Comments()
        {
            return this.View();
        }
    }
}
