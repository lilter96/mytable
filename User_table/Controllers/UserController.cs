using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User_table.Models;
using User_table.ViewModels;

namespace User_table.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        private bool CheckCurrentUserAuth(string Id)
        {
            ClaimsPrincipal user = this.User;
            var currentId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Id == currentId;
        }

        public IActionResult Index() => View(_userManager.Users.ToList());

        [HttpPost]
        public async Task<IActionResult> Block(List<string> AreChecked,IFormCollection form)
        {
            var value = form.Keys.Contains("block") ? true : false;
            foreach (var userName in AreChecked)
            {
                var currentUser = await _userManager.FindByNameAsync(userName);
                if (form.Keys.Contains("delete"))
                {
                    await _userManager.DeleteAsync(currentUser);
                }
                else
                {
                    currentUser.IsBlocked = form.Keys.Contains("block") ? true : false;
                    await _userManager.UpdateAsync(currentUser);
                }

                if (CheckCurrentUserAuth(currentUser.Id) && !form.Keys.Contains("unblock"))
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index");
        }

    }
}
