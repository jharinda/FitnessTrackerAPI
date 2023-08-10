using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;
using UserAPI.Models.ViewModels;
using UserAPI.Repository;
using UserAPI.Repository.Interfaces;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public ViewModelUser Get(string email)
        {
            return _userService.Get(email);
        }

        [HttpPost]
        public ViewModelUser Register([FromBody]ViewModelUser user)
        {
            return _userService.Create(user);
        }

        [HttpPut]
        public ViewModelUser Edit([FromBody] ViewModelUser user)
        {
            return _userService.Edit(user);
        }

        [HttpPost("Record")]
        public void AddRecord([FromBody] ViewModelRecord record)
        {
             _userService.AddRecord(record);
        }

        [HttpPut("Record")]
        public void EditRecord([FromBody] ViewModelRecord record)
        {
            _userService.EditRecord(record);
        }

        [HttpDelete("Record/{recordId}")]
        public void DeleteRecord(int recordId)
        {
            _userService.DeleteRecord(recordId);
        }

        [HttpDelete]
        public void Delete([FromBody] ViewModelUser user)
        {
            _userService.Delete(user);
        }

        [HttpPost("validate")]
        public ViewModelUser Validate([FromBody]ViewModelUser tempUser)
        {
            return _userService.AuthorizeUser(tempUser);
        }
    }
}
