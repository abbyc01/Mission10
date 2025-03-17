using FullStackFun.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackFun.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlerController : ControllerBase
    {
        private readonly BowlingDbContext _bowlingContext;

        public BowlerController(BowlingDbContext temp)
        {
            _bowlingContext = temp;
        }
        
        [HttpGet(Name = "GetBowler")]
        public async Task<ActionResult<IEnumerable<Bowler>>> Get()
        {
            var bowlers = await _bowlingContext.Bowlers
                .Include(b => b.Team) // Ensure Team is included
                .Where(b => b.TeamID ==1 || b.TeamID == 2)
                .Select(b => new Bowler
                {
                    BowlerID = b.BowlerID,
                    BowlerLastName = b.BowlerLastName,
                    BowlerFirstName = b.BowlerFirstName,
                    BowlerMiddleInit = b.BowlerMiddleInit,
                    BowlerAddress = b.BowlerAddress,
                    BowlerCity = b.BowlerCity,
                    BowlerState = b.BowlerState,
                    BowlerZip = b.BowlerZip,
                    BowlerPhoneNumber = b.BowlerPhoneNumber,
                    TeamName = b.Team.TeamName // Replace TeamID with TeamName
                })
                .ToListAsync();

            return Ok(bowlers);
        }
    }
}