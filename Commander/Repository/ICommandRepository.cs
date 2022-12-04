using Commander.Models;
using System.Collections.Generic;

namespace Commander.Repository
{
    public interface ICommandRepository
    {
        IEnumerable<CommandModel> GetAllAppCommands();
        CommandModel GetCommandById(int id);
    }
}