
using System.Collections.Generic;
using System.Threading.Tasks;

namespace commander.DataLayer
{
    public class TestDataAccess : IDataAccess
    {
        public Task<int> CreateCommand(Dictionary<string, string> CommandToAdd)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Dictionary<string, string>>> GetAllCommands()
        {
            return Task.Run(() =>
            {
                return new List<Dictionary<string, string>>
                {
                    new Dictionary<string, string> { {"Id", "1"}, {"HowTo", "cd"}, {"Line", "cd"}, {"Platform", "Linux"} },
                    new Dictionary<string, string> { {"Id", "2"}, {"HowTo", "ifconfig"}, {"Line", "ifconfig"}, {"Platform", "Linux"} },
                    new Dictionary<string, string> { {"Id", "3"}, {"HowTo", "systemctl status ssh"}, {"Line", "ifconfig"}, {"Platform", "Linux"} },
                    new Dictionary<string, string> { {"Id", "4"}, {"HowTo", "systemctl enable ssh"}, {"Line", "systemctl enable ssh"}, {"Platform", "Linux"} }
                };
            });
        }

        public Task<Dictionary<string, string>> GetCommandById(int id)
        {
            return Task.Run(() =>
            {
                return new Dictionary<string, string> { { "Id", "1" }, { "HowTo", "cd" }, { "Line", "cd" }, { "Platform", "Linux" } };
            });
        }
    }
}