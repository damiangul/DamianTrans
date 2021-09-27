using DamianTrans.Models;
using DamianTrans.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accoundService;

        public AccountController(IAccountService accountService)
        {
            _accoundService = accountService;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View(new LoginClientWorkerDto());
        }

        [HttpPost("login")]
        public IActionResult LoginClient(LoginClientWorkerDto dto)
        {
            _accoundService.loginUser(dto);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost("logout")]
        public IActionResult LogoutClient()
        {
            _accoundService.logoutClient();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View(new RegisterClientDto());
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromForm] RegisterClientDto dto)
        {
            _accoundService.addUser(dto);
            return RedirectToAction("Index", "Home");
        }
    }
}
