using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using commander.DataLayer;

namespace commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IDataAccess _DataAccess;

        public CommandsController(IDataAccess DataAccess)
        {
            this._DataAccess = DataAccess;
        }

        // route: /api/commands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dictionary<string, string>>>> GetAllCommands()
        {
            return Ok(await this._DataAccess.GetAllCommands());
        }

        // route: /api/commands/{command_id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Dictionary<string, string>>> GetCommandsById(int id)
        {
            return Ok(await this._DataAccess.GetCommandById(id));
        }

        // route: /api/commands
        [HttpPost]
        public async Task<ActionResult<string>> CreateCommand(Dictionary<string, string> ObjToAdd)
        {
            int CmdId = await this._DataAccess.CreateCommand(ObjToAdd);
            if (CmdId != -1)
                return Ok($"/api/commands/{CmdId}");
            return BadRequest($"Error Creating Resource Command: {CmdId}");
        }
    }
}