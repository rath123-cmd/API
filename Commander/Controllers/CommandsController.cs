using Commander.Models;
using Commander.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Controllers
{
    [Route("api/command")]
    [ApiController]
    public class CommandsController : Controller
    {
        private readonly ICommandRepository _commandRepository;

        public CommandsController(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CommandModel>> GetAllAppCommands()
        {
            return Ok(_commandRepository.GetAllAppCommands());
        }
        
        [HttpGet("{id}")]
        public ActionResult<CommandModel> GetCommandById(int id)
        {
            return Ok(_commandRepository.GetCommandById(id));
        }
    }
}
