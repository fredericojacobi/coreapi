using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Newtonsoft.Json;

namespace FirstApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReminderController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Reminder
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var reminders = new ReminderRepository(_context).Get();
                return Content(JsonConvert.SerializeObject(reminders.Select(reminder => new ReminderDTO
                {
                    Id = reminder.Id,
                    Title = reminder.Title,
                    Description = reminder.Description,
                    isComplete = reminder.isComplete
                }).ToList()));
            }
            catch (DbException e)
            {
                return Problem(e.Message, e.InnerException?.Source, 500, e.Source);
            }
        }

        // GET: api/Reminder/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                var reminder = new ReminderRepository(_context).Get(id);
                if (reminder == null)
                    return NotFound();
                return Content(JsonConvert.SerializeObject(new ReminderDTO
                {
                    Id = reminder.Id,
                    Title = reminder.Title,
                    Description = reminder.Description,
                    isComplete = reminder.isComplete
                }));
            }
            catch (DbException e)
            {
                return Problem(e.Message, e.InnerException?.Source, 500, e.Source);
            }
        }

        // PUT: api/Reminder/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ReminderDTO>> Put(long id, ReminderDTO reminder)
        {
            if (id != reminder.Id)
                return BadRequest();
            try
            {
                var repositoryResult = new ReminderRepository(_context).InsertOrUpdate(new Reminder
                {
                    Id = reminder.Id,
                    Title = reminder.Title,
                    Description = reminder.Description,
                    isComplete = reminder.isComplete
                });
                return Content(JsonConvert.SerializeObject(repositoryResult));
            }
            catch (DbException e)
            {
                if (!ReminderExists(id))
                    return NotFound();
                return Problem(e.Message, e.InnerException?.Source, 500, e.Source);
            }
        }

        // POST: api/Reminder
        [HttpPost]
        public async Task<ActionResult<dynamic>> Post(ReminderDTO reminder)
        {
            try
            {
                var repositoryResult = new ReminderRepository(_context).InsertOrUpdate(new Reminder
                {
                    Title = reminder.Title,
                    Description = reminder.Description,
                    isComplete = reminder.isComplete
                });
                return CreatedAtAction(nameof(Get), new { id = reminder.Id }, repositoryResult);
            }
            catch (DbException e)
            {
                return Problem(e.Message, e.InnerException?.Source, 500, e.Source);
            }
        }

        // DELETE: api/Reminder/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] long id)
        {
            try
            {
                var reminder = new ReminderRepository(_context).Delete(id);
                if (!reminder)
                    return NotFound();
                return NoContent();
            }
            catch (DbException e)
            {
                return Problem(e.Message, e.InnerException?.Source, 500, e.Source);
            }
        }

        private bool ReminderExists(long id)
        {
            return _context.Reminders.Any(e => e.Id == id);
        }
    }
}