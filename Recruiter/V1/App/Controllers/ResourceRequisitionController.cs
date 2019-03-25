using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models.Recruiter;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Cors;

namespace guid_reactapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceRequisitionController :  ControllerBase
    {
        private readonly TableContext _context;
         private IHostingEnvironment _hostingEnvironment;
        public ResourceRequisitionController(TableContext context, IHostingEnvironment environment)
        {
            _context=context;
            _hostingEnvironment = environment;
        }
         [HttpGet]
         [Route("ResourceRequisitionData")]
        public ActionResult<List<ResourceRequisition>> GetAllTodoItems()
        {
            return _context.ResourceRequisitions.ToList();
        }
       
        [HttpGet("{id}", Name = "GetToJobs")]        
        public ActionResult<ResourceRequisition> GetById(string id)
        {
          var skill = _context.ResourceRequisitions.Find(id);
            if (skill == null)
            {
          return NotFound();
         }
             return skill;
        }

        [HttpPost]
        [Route("addResourceRequisition")]
        public IActionResult Create(ResourceRequisition resourceRequisition)
        {
            Guid obj = Guid.NewGuid();
            string gid = obj.ToString();           
            resourceRequisition.Id = gid;
            _context.ResourceRequisitions.Add(resourceRequisition);
            _context.SaveChanges();          
            return CreatedAtRoute("GetToJobs", new { id = resourceRequisition.Id }, resourceRequisition);
        }
         [HttpPut("{id}")]
        public void Put(string id,ResourceRequisition resourceRequisition)
        {
        var todo = _context.ResourceRequisitions.Find(id);          
        todo.Title = resourceRequisition.Title;
        todo.Description = resourceRequisition.Description;
        todo.HiringManagerEmail = resourceRequisition.HiringManagerEmail;
        todo.Skills = resourceRequisition.Skills;
        todo.Notes = resourceRequisition.Notes;
        todo.Stages = resourceRequisition.Stages;
        todo.PlannedDeadline = resourceRequisition.PlannedDeadline;       
        _context.ResourceRequisitions.Update(todo);
        _context.SaveChanges();   
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        var todo = _context.ResourceRequisitions.Find(id);
        _context.ResourceRequisitions.Remove(todo);
        _context.SaveChanges();
        }
      
    }
}