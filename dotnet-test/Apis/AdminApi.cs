using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using dotnet_test.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extension.Configuration;
using System.Data.SqlConnection;

namespace dotnet_test.Apis{  


    [ApiController]
    [Route("admin")]
    public class AdminApi : ControllerBase
    {
       
        private ILogger _logger;
        private IConfiguration _config;
        public AdminApi( ILogger<AdminApi> logger, IConfiguration configuration){
            _logger = logger;
            _config = configuration;
            _logger.LogInformation("Logger was created");
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        public  ActionResult<List<Users>> UsersList(){
                _logger.LogInformation("Called admin api user list");
            
            using(var conn = new SqlConnection(_config.GetConnectionString("FZeroDB"))){
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select  from dbo.Users', conn);
                SqlReader sql = cmd.ExecuteQuery();


            }

        } 

    }
}