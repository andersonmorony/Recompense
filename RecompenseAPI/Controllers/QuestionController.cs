using Microsoft.AspNetCore.Mvc;
using RecompenseAPI.Data.IRepository;
using RecompenseAPI.Models;

namespace RecompenseAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IChallengeRepositoty _challengeRepository;

        public QuestionController(IQuestionRepository questionRepository, IChallengeRepositoty challengeRepositoty)
        {
            _questionRepository = questionRepository;
            _challengeRepository = challengeRepositoty;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _questionRepository.GetAll();
                return Ok(result);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _questionRepository.GetById(id);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(CreateQuestion question)
        {
            try
            {
                var challenge = _challengeRepository.GetById(question.ChallengeId);
                if (challenge == null) return NotFound("Challenge not found");

                var result = _questionRepository.Add(question);

                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
