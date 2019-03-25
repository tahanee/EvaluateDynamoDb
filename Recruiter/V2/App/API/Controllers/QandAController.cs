using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using QandAApi.Models;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
         private readonly TableContext _context;
        public ValuesController(TableContext context)
        {
            _context=context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet]
         [Route("TableData")]
        public ActionResult<List<Item>> GetAllTodoItems()
        {
            return _context.Items.ToList();       }

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("TableDataId")]
        public ActionResult<string> Get(string id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<Item> GetById(string id)
        {
          var item = _context.Items.Find(id);
            if (item == null)
            {
          return NotFound();
         }
             return item;
        }
        [HttpPost]
        [Route("Item")]
        public IActionResult Create(Item item, string id)
        {
            Guid obj = Guid.NewGuid();  
            string gid =  obj.ToString();   
            item.Id = gid; 
            _context.Items.Add(item);
            _context.SaveChanges();
            return CreatedAtRoute("GetTodo",new {id= item.Id},item);           
          
        }      

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(string id,Item item)
        {
        var todo = _context.Items.Find(id);          
        todo.Ques = item.Ques;
        todo.Ans = item.Ans;
        _context.Items.Update(todo);
        _context.SaveChanges();   
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]        
        public void Delete(string id)
        {
        var todo = _context.Items.Find(id);
        _context.Items.Remove(todo);
        _context.SaveChanges();
        }
    }
}
