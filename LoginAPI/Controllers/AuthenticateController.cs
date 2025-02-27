﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Controllers
{

    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly LoginDetailsContext _context;
        public AuthenticateController(LoginDetailsContext context)
        {
            _context = context;
        }

        [Route("Authenticate")]
        [HttpGet]

        public async Task<ActionResult<LoginDetails>> GetUser(string Username, string Password)
         {
             //var User = await _context.LoginDetails.FindAsync(Username, Password);

             var User = await _context.LoginDetails.Where(x => x.Username == Username && x.Password == Password).ToListAsync();

             if (User == null)
             {
                 return NotFound();
             }

             return User;
         }
 /* 
  public LoginDetails FindMyUser(string Username)
  {
      LoginDetails usr = (LoginDetails)_context.LoginDetails.Where(m => m.Username == Username);// hämta från db




      return usr;
  }
        */
    }
}
