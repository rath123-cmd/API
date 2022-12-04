using Commander.Data;
using Commander.Models;
using System.Collections.Generic;

namespace Commander.Repository
{
    public interface ICommandRepository
    {
        bool SaveChnages();

        IEnumerable<Command> GetAllAppCommands();
        Command GetCommandById(int id);
        void AddCommand(Command command);
    }
}