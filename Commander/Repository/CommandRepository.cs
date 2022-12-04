using Commander.Data;
using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Repository
{
    public class CommandRepository : ICommandRepository
    {
        private readonly CommanderContext _commanderContext;

        public CommandRepository(CommanderContext commanderContext)
        {
            _commanderContext = commanderContext;
        }

        public void AddCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            _commanderContext.Add(command);
        }

        public IEnumerable<Command> GetAllAppCommands()
        {
            return _commanderContext.Commands;
        }

        public Command GetCommandById(int id)
        {
            return _commanderContext.Commands.Where(comm => comm.Id == id).FirstOrDefault();
        }

        public bool SaveChnages()
        {
            return (_commanderContext.SaveChanges() >= 0);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            _commanderContext.Remove(command);
        }
    }
}
