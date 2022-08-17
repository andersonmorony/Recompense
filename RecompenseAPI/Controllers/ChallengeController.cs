using Microsoft.AspNetCore.Mvc;
using RecompenseAPI.Data.IRepository;
using RecompenseAPI.Models;

namespace RecompenseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallengeRepositoty _challengeRepository;

        public ChallengeController(IChallengeRepositoty challengeRepository)
        {
            _challengeRepository = challengeRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var challenge = _challengeRepository.GetAll();
                return Ok(challenge);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var challenge = _challengeRepository.GetById(id);
                if (challenge == null)
                {
                    return NotFound();
                }
                return Ok(challenge);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(CreateChallenge challenge)
        {
            try
            {
                var result = _challengeRepository.Add(challenge);
                return Ok(challenge);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
