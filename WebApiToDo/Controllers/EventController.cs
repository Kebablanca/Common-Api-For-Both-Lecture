using LMSData.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly LMSDBContext _context;

        public EventController(LMSDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] Event newEvent)
        {
            try
            {
                if (newEvent == null || string.IsNullOrWhiteSpace(newEvent.Title) )
                {
                    return BadRequest("Invalid input");
                }
                if (newEvent.Date == null)
                {
                    return BadRequest("Date cannot be null");
                }


                newEvent.Id = 0; // Buraya uygun bir kullanıcı ID'si ekleme
                _context.Events.Add(newEvent);
                try
                {
                    await _context.SaveChangesAsync();
                    return Ok(newEvent);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex); // Hata detaylarını yazdır
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserEvents(int userId)
        {
            try
            {
                var userEvents = await _context.Events
                    .Where(e => e.UserId == userId)
                    .ToListAsync();

                return Ok(userEvents);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var evnt = _context.Events.Find(id);
            _context.Events.Remove(evnt);
            _context.SaveChanges();
        }
    }
    }
