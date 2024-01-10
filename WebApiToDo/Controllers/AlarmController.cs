using LMSData.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class AlarmController : ControllerBase
{
    private static List<Alarms> _alarms = new List<Alarms>(); // Örnek olarak liste kullanıldı. Gerçek uygulamada veritabanı kullanmalısınız.

    [HttpGet("user/{userId}")]
    public ActionResult<IEnumerable<Alarms>> GetAlarms(int userId)
    {
        var userAlarms = _alarms.Where(a => a.UserId == userId).ToList();
        return userAlarms;
    }

    [HttpGet("{id}")]
    public ActionResult<Alarms> GetAlarm(int id)
    {
        var alarm = _alarms.FirstOrDefault(a => a.Id == id);
        if (alarm == null)
        {
            return NotFound();
        }

        return alarm;
    }

    [HttpPost]
    public ActionResult<Alarms> CreateAlarm(Alarms alarm)
    {
        alarm.Id = _alarms.Count + 1; // Örnek olarak ID'yi basitçe artırabilirsiniz.
        _alarms.Add(alarm);

        return CreatedAtAction(nameof(GetAlarm), new { id = alarm.Id }, alarm);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAlarm(int id, Alarms updatedAlarm)
    {
        var existingAlarm = _alarms.FirstOrDefault(a => a.Id == id);

        if (existingAlarm == null)
        {
            return NotFound();
        }

        existingAlarm.AlarmTime = updatedAlarm.AlarmTime;
        existingAlarm.Day = updatedAlarm.Day;
        existingAlarm.IsSet = updatedAlarm.IsSet;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAlarm(int id)
    {
        var alarm = _alarms.FirstOrDefault(a => a.Id == id);
        if (alarm == null)
        {
            return NotFound();
        }

        _alarms.Remove(alarm);

        return NoContent();
    }
}
 