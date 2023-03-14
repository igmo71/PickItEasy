﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Persistence.Models;

namespace PickItEasy.Web.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<ApplicationUser> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll() => Ok(_roleManager.Roles.ToList());

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateRole(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest();

            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
            if (!result.Succeeded)
                return Problem();

            return Ok(name);
        }

        [HttpPost("[action]/{roleId}")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return BadRequest();

            IdentityResult result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
                return Problem();

            return Ok();
        }

        [HttpGet("[action]")]
        public IActionResult UserList() => Ok(_userManager.Users.ToList());

        [HttpGet("[action]")]
        public async Task<IActionResult> UserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);
            return Ok(userRoles);
        }

        [HttpPost("[action]/{userId}")]
        public async Task<IActionResult> AddRoles(string userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
                return NotFound(userId);

            // получем список ролей пользователя
            var userRoles = await _userManager.GetRolesAsync(user);
            // получаем все роли
            var allRoles = _roleManager.Roles.ToList();
            // получаем список ролей, которые были добавлены
            var addedRoles = roles.Except(userRoles);
            // получаем роли, которые были удалены
            var removedRoles = userRoles.Except(roles);

            await _userManager.AddToRolesAsync(user, addedRoles);

            await _userManager.RemoveFromRolesAsync(user, removedRoles);

            return Ok();
        }
    }
}
