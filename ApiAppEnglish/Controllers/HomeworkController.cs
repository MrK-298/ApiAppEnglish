using ApiAppEnglish.Data.EF;
using ApiAppEnglish.Data.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAppEnglish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly MyDbContext _context;
        public HomeworkController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetUserHomeworks")]
        public IActionResult GetUserHomeworks(int userId)
        {
            var userHomeworks = _context.detailHomeworks
                .Include(dh => dh.homework)
                .Where(dh => dh.userId == userId && dh.isDone)
                .Select(dh => new
                {
                    id = dh.homework.Id,
                    title = dh.homework.title,
                    score = dh.score,
                    isDone = dh.isDone
                })
                .ToList();

            if (userHomeworks == null || userHomeworks.Count == 0)
            {
                return BadRequest("Không có bài tập nào được tìm thấy cho người dùng này.");
            }

            return Ok(userHomeworks);
        }
        [HttpPost("DoHomework")]
        public IActionResult DoHomework(DoHomeworkViewModel model)
        {
            if (model != null)
            {
                var existingHomework = _context.detailHomeworks
                    .FirstOrDefault(dh => dh.homeworkId == model.homeworkId && dh.userId == model.userId);

                if (existingHomework != null)
                {
                    existingHomework.score = model.score;
                    _context.detailHomeworks.Update(existingHomework);
                    _context.SaveChanges();

                    return Ok(existingHomework);
                }
                else
                {
                    // Nếu chưa có bản ghi, tạo mới
                    var homework = new DetailHomework
                    {
                        homeworkId = model.homeworkId,
                        score = model.score,
                        userId = model.userId,
                        isDone = true,
                    };

                    _context.detailHomeworks.Add(homework);
                    _context.SaveChanges();

                    return Ok(homework);
                }
            }
            return BadRequest("Save failed");
        }
    }
}
