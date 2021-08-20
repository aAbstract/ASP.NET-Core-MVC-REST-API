using System.Collections.Generic;
using System.Threading.Tasks;

namespace commander.DataLayer
{
    public interface IDataAccess
    {
        Task<List<Dictionary<string, string>>> GetAllCommands();
        Task<Dictionary<string, string>> GetCommandById(int Id);
        Task<int> CreateCommand(Dictionary<string, string> CommandToAdd);
    }
}