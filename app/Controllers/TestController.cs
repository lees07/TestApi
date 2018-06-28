using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        private readonly TestContext _context;

        public TestController(TestContext context) 
        {
            _context = context;

            if (_context.TestItems.Count() == 0)
            {
                _context.TestItems.Add(new TestItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<TestItem>> GetAll()
        {
            return _context.TestItems.ToList();
        }

        [HttpGet("{id}", Name = "GetTest")]
        public ActionResult<TestItem> GetById(long id)
        {
            var item = _context.TestItems.Find(id);
            if (item == null) 
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(TestItem item)
        {
            _context.TestItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTest", new { id = item.Id }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(long id, TestItem item)
        {
            var todo = _context.TestItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TestItems.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.TestItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TestItems.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }

    }
}