using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Aplication.DTOs.User;
using Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gerenciador_de_arquivos.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _iuserService;

        public UserController(IUserService iuserService)
        {
            _iuserService = iuserService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserPostDTO userPostDTO)
        {
            var CreateUser = await _iuserService.CreateAsync(userPostDTO);
            return Ok("deu bom aqui");
        }
    }
}