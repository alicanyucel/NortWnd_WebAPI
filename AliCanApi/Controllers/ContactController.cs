using AliCanApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliCanApi.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        [HttpGet("")]
        
        public List<ContactModel> Get()
        {
            return new List<ContactModel>
            {
                new ContactModel{Id=1,FirstName="alican",LastName="yucel" }
             };
        }
    }
}
