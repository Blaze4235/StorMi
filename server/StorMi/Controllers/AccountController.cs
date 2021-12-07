using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoMi.ViewModels;
using StorMi.DalModels;
using StorMi.EF;
using StorMi.DalModels;
using StorMi.Models;
using StorMi.ViewModels;

namespace AuthApp.Controllers
{
    [Route("/api")]
    public class AccountController : Controller
    {
        private readonly StormiContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            StormiContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = context;
        }

        [HttpGet]
        [Route("/users")]
        public async Task<IActionResult> GetAll()
        {
            return Json(await _db.Users.ToListAsync());
        }

        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}

        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.PhoneNumber,
                };


                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var userIdentity = await _userManager.FindByEmailAsync(model.Email);

                    UserProfile userProfile = new UserProfile()
                    {
                        UserId = userIdentity.Id,
                        Name = model.Name
                    };

                    _db.UserProfiles.Add(userProfile);
                    await _db.SaveChangesAsync();

                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return Ok();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }

                    return BadRequest();
                }
            }

            return StatusCode(500);
        }

        [HttpPost]
        [Route("/login")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        var user = await _userManager.FindByEmailAsync(model.Email);
                        user.UserName = (await _db.UserProfiles.FindAsync(user.Id)).Name;
                        return Json(user);
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // POST: /Account/ResetPassword
        [HttpPost]
        [Route("/reset")]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return BadRequest();
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return Ok();
            }

            return StatusCode(500);
        }

        [HttpPost]
        [Route("/logout")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Json("Success");
        }

        [HttpPost]
        [Route("/delete")]
        public async Task<ActionResult> Delete()
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return Json("Success");
                }
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("/edit")]
        public async Task<ActionResult> Edit([FromBody] EditUserModel model)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                user.Email = model.Email;
                user.UserName = model.Name;
                IdentityResult result = await _userManager.UpdateAsync(user);
                await _db.SaveChangesAsync();
                if (result.Succeeded)
                {
                    var userRes = await _userManager.FindByEmailAsync(model.Email);
                    user.UserName = (await _db.UserProfiles.FindAsync(user.Id)).Name;
                    return Json(userRes);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}