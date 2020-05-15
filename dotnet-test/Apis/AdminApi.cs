using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using dotnet_test.Models;
using Microsoft.Extensions.Logging;

namespace dotnet_test.Apis{  


    [ApiController]
    [Route("admin")]
    public class AdminApi : ControllerBase
    {
        private fzeroContext ctx ;
        private ILogger _logger;
        public AdminApi(fzeroContext fzCxt , ILogger<AdminApi> logger){
            ctx = fzCxt;
            _logger = logger;
            _logger.LogInformation("Logger was created");
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public  ActionResult<List<Users>> UsersList(){
                _logger.LogInformation("Called admin api user list");
                return  ctx.Users.ToList();
            

        }

    }
}