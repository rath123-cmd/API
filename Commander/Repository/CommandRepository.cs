using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Repository
{
    public class CommandRepository : ICommandRepository
    {
        public IEnumerable<CommandModel> GetAllAppCommands()
        {
            return GetCommands();
        }

        public CommandModel GetCommandById(int id)
        {
            return GetCommands().Where(comm => comm.Id == id).FirstOrDefault();
        }




        public List<CommandModel> GetCommands()
        {
            return new List<CommandModel>()
            {
                new CommandModel(){ Id = 1, HowTo = "Cut a tree.", CommandLine = "cutTree", Platform = "Earth"},
                new CommandModel(){ Id = 2, HowTo = "Cut a paper.", CommandLine = "cutPaper", Platform = "Book"},
                new CommandModel(){ Id = 3, HowTo = "Plant a tree.", CommandLine = "plantTree", Platform = "Earth"},
                new CommandModel(){ Id = 4, HowTo = "Cut a Patato.", CommandLine = "cutPotato", Platform = "Kitchen"},
                new CommandModel(){ Id = 5, HowTo = "Cook a curry.", CommandLine = "cookCurry", Platform = "Kitchen"},
                new CommandModel(){ Id = 6, HowTo = "Built a house.", CommandLine = "builtHouse", Platform = "Earth"},
                new CommandModel(){ Id = 7, HowTo = "Do your homework.", CommandLine = "doHW", Platform = "Study"},
                new CommandModel(){ Id = 8, HowTo = "Drink some water.", CommandLine = "drinkWater", Platform = "Life"},
                new CommandModel(){ Id = 9, HowTo = "Eat some food.", CommandLine = "eatFood", Platform = "Life"}
            };
        }
    }
}
