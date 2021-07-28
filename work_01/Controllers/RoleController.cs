using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using work_01.Data;

namespace work_01.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(string userrole)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(userrole))
            {
                if(await _roleManager.RoleExistsAsync(userrole))
                {
                    msg = "Role ["+userrole+"] alredy exist!!";
                }
                else
                {
                    IdentityRole r = new IdentityRole(userrole);
                    await _roleManager.CreateAsync(r);
                    msg= "Role [" + userrole + "] has been create successfully!!";
                }
            }
            else
            {
                msg = "Please enter a valid role name.";
            }
            ViewBag.msg = msg;
            return View("Index");
        }
    }
}