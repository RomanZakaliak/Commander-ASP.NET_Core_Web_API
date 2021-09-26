using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        private IEnumerable<Command> commands = new List<Command>
        {
            new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle and pan"},
            new Command{Id=1, HowTo="Cut bread", Line="Get a knife", Platform="Knife and chopping board"},
            new Command{Id=2, HowTo="Make cup of tea", Line="Place teabag in cup", Platform="Kettle and cup"}
        };

        public void CreateCommand(Command cmd)
        {
            this.commands.Append(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
          this.commands = this.commands.Where(c => c.Id != cmd.Id);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return commands;
        }

        public Command GetCommandById(int Id)
        {
            var command = commands.Where( c => c.Id == Id).FirstOrDefault();
            return command;
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}