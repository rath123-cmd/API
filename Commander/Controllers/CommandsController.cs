using AutoMapper;
using Commander.Data;
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
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepository commandRepository, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CommandModel>> GetAllAppCommands()
        {
            var result = _commandRepository.GetAllAppCommands();
            if(result != null)
            {
                return Ok(_mapper.Map<IEnumerable<CommandModel>>(result));
            }

            return NotFound();
        }
        
        [HttpGet("{id}")]
        public ActionResult<CommandModel> GetCommandById(int id)
        {
            var result = _commandRepository.GetCommandById(id);
            if (result != null)
            {
                return Ok(_mapper.Map<CommandModel>(result));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandModel> AddCommand(CommandWriteModel cwc)
        {
            var command = _mapper.Map<Command>(cwc);
            _commandRepository.AddCommand(command);
            _commandRepository.SaveChnages();

            return _mapper.Map<CommandModel>(command);
        }
    }
}
