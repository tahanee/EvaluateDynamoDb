using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models.SkillSets;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [Route("api/[controller]")]
   [ApiController]
    public class SkillSetController :  ControllerBase
    {
        private readonly TableContext _context;
        public List<SkillSet> flatList = new List<SkillSet>();
        public SkillSetController(TableContext context)
        {
            _context=context;
        }
        // GET api/values
        [HttpGet("{id}", Name = "GetToskills")]
        public ActionResult<SkillSet> GetById(string id)
        {
          var skill = _context.SkillSets.Find(id);
            if (skill == null)
            {
          return NotFound();
         }
             return skill;
        }        

        [HttpPost]
        [Route("add2skills")]
        public IActionResult create (SkillSet skill)
        {            
            Guid obj = Guid.NewGuid();  
            string gid =  obj.ToString();  
            if(skill.Parent == "")      
           {
             skill.Id = gid;  
             skill.Parent = null ;                       
            _context.SkillSets.Add(skill);                
             _context.SaveChanges();  
           }  
            else
            {
             skill.Id = gid;                                  
            _context.SkillSets.Add(skill);                
             _context.SaveChanges();                  
            } 
            
            return CreatedAtRoute("GetToskills",new {id= skill.Id},skill);                  
        }   

        [HttpGet]
        [Route("skills")]
        public ActionResult<List<SkillSet>> GetAllTodoItems()
        {           
          flatList = _context.SkillSets.ToList();          
          var tree = flatList.BuildTree();
          return tree.ToList();
        }

        [HttpPut("{id}")]
        public void Put(string id,SkillSet skill)
        {            
        var val = _context.SkillSets.Find(id);
        val.Node = skill.Node;
       // val.Parent = skill.Parent;         
        _context.SkillSets.Update(val);
        _context.SaveChanges();   
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]        
        public void Delete(string id)
        {
          var todo = _context.SkillSets.Find(id);
         _context.SkillSets.Remove(todo);
         _context.SaveChanges();
        }       
    }
}