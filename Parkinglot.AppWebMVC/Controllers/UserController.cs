using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parkinglot.AppWebMVC.Commands.UserCommands;
using Parkinglot.AppWebMVC.Models;

namespace Parkinglot.AppWebMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public async Task<JsonResult> Configure()
        {
            try
            {
                var createUserCommand = new CreateNewUserCommand()
                { Id = "5ff922479b7b12712737d6af", FullName = "Gilberto Sesteaga Gonzalez", ControlNumber = 1374 };
                await mediator.Send(createUserCommand);
                //new CreateNewUserCommandHander().Handler(Command)
                return Json(new { Ok = true });
            }
            catch (Exception ex)
            {
                return Json(new { Ok = false, Msg = ex.Message });
            }
        }

        [HttpPost()]
        public async Task<JsonResult> CreateUser(CreateNewUserCommand createNewUserCommand)
        {
            try
            {
                // var createUserCommand = new CreateNewUserCommand()
                // { Id = "5ff922479b7b12712737d6af", FullName = "Gilberto Sesteaga Gonzalez", ControlNumber = 1374 };
                await mediator.Send(createNewUserCommand);
                //new CreateNewUserCommandHander().Handler(Command)
                return Json(new { Ok = true });
            }
            catch (Exception ex)
            {
                return Json(new { Ok = false, Msg = ex.Message });
            }
        }

        [HttpPost()]
        public async Task<JsonResult> AddAccessControl(CreateNewUserCommand createNewUserCommand)
        {
            try
            {
                // var createUserCommand = new CreateNewUserCommand()
                // { Id = "5ff922479b7b12712737d6af", FullName = "Gilberto Sesteaga Gonzalez", ControlNumber = 1374 };
                await mediator.Send(createNewUserCommand);
                //new CreateNewUserCommandHander().Handler(Command)
                return Json(new { Ok = true });
            }
            catch (Exception ex)
            {
                return Json(new { Ok = false, Msg = ex.Message });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
