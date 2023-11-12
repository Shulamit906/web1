using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static int id = 1;
        private static List<Event> events = new List<Event> { new Event { Id = id++, Title = "birthdate" ,Start= new DateTime(2023,9,9), End = new DateTime(2023, 9, 9) },
            new Event { Id = id++, Title = "newborn", Start = new DateTime(2023, 8, 8), End = new DateTime(2023, 8, 8) },
            new Event { Id = id++, Title = "wedding", Start = new DateTime(2023, 10,10), End = new DateTime(2023, 10,10) }};
       
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
;
        }
        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Event newEvent)
        {
            events.Add(new Event { Id = id++, Title = newEvent.Title, Start = newEvent.Start });
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event newEvent)
        {
            Event ev=events.Find(item=>item.Id == id);
            events.Remove(ev);
            ev.Title = newEvent.Title;
            ev.Start = newEvent.Start;
            events.Add(ev);

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Event ev = events.Find(item => item.Id == id);
            events.Remove(ev);
        }
    }
}
