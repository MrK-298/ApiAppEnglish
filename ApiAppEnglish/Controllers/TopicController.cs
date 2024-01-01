using ApiAppEnglish.Data.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAppEnglish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly MyDbContext _context;
        public TopicController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetAllTopics")]
        public IActionResult GetAllTopics()
        {
            var topics = _context.topic.ToList();
            if (topics == null)
            {
                return BadRequest("Không có topic nào được tìm thấy");
            }
            return Ok(topics);
        }
        [HttpGet("GetTopicWithId")]
        public IActionResult GetTopic(int id)
        {
            var topic = _context.topic.SingleOrDefault(p=>p.Id==id);
            if (topic == null)
            {
                return BadRequest("Không có topic nào được tìm thấy");
            }
            return Ok(topic);
        }
        [HttpGet("GetHomework")]
        public IActionResult GetHomework(int id)
        {
            var homeworks = _context.homeWorks.Where(h => h.topicId == id).ToList();
            if (homeworks == null)
            {
                return BadRequest("Không có topic nào được tìm thấy");
            }         

            return Ok(homeworks);
        }
    }
}
