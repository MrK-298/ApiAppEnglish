using ApiAppEnglish.Data.EF;
using ApiAppEnglish.Data.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ApiAppEnglish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerWordController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ManagerWordController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetAllWords")]
        public IActionResult GetAllWords()
        {
            var words = _context.listWords.ToList();
            if (words == null)
            {
                return BadRequest("Không có từ nào được tìm thấy");
            }
            return Ok(words);
        }
        [HttpPost("SaveWord")]
        public IActionResult SaveWord(SaveWordViewModel model)
        {
            if(model !=null)
            {
                var word = new ListWord
                {
                    word = model.word,
                    definition = model.definition,
                    UserId = model.userId,
                    phonetic = model.phonetic,
                };
                _context.listWords.Add(word);
                _context.SaveChanges();
                return Ok(word);
            }
            return BadRequest("Save failed");
        }
        [HttpDelete("UnSaveWord")]
        public IActionResult UnSaveWord(int id)
        {
            if(id!=0)
            {
                var word = _context.listWords.SingleOrDefault(p=>p.Id==id);
                _context.listWords.Remove(word);
                _context.SaveChanges();
                return Ok("Unsave successful");           
            }
            return BadRequest("Unsave failed");
        }
    }
}
