using AutoMapper;
using Commander.Data;
using Commander.Models;
using Commander.Repository;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdaterModel cum)
        {
            var toBeUpdated = _commandRepository.GetCommandById(id);

            if(toBeUpdated == null)
            {
                return NotFound();
            }

            _mapper.Map(cum, toBeUpdated);

            _commandRepository.SaveChnages();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateCommand(int id, JsonPatchDocument<CommandUpdaterModel> cum)
        {
            var toBeUpdated = _commandRepository.GetCommandById(id);

            if (toBeUpdated == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdaterModel>(toBeUpdated);
            cum.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, toBeUpdated);

            _commandRepository.SaveChnages();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var toBeUpdated = _commandRepository.GetCommandById(id);

            if (toBeUpdated == null)
            {
                return NotFound();
            }

            _commandRepository.DeleteCommand(toBeUpdated);

            _commandRepository.SaveChnages();

            return NoContent();
        }
    }
}
