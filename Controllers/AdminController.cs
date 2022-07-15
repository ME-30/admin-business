using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> userManager;

        public AdminController(RoleManager<IdentityRole> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRole model)
        {
            if(ModelState.IsValid)
            {
                var role = new IdentityRole()
                {
                    Name = model.RoleName
                };
                var Result = await userManager.CreateAsync(role);

                if (Result.Succeeded)
                {
                    return RedirectToAction("CreateRole");
                }
                else
                {
                    foreach (var error in Result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

            }


            return View(model);
        }
    }
}
