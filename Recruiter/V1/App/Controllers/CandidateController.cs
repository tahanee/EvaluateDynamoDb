using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.SkillSets;
using QandAApi.Models;
using Microsoft.AspNetCore.Cors;
using CandidateModel.Models;

namespace guid_reactapp.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class CandidateController : ControllerBase
{
private readonly TableContext _context;
//private IHostingEnvironment _hostingEnvironment;
public CandidateController(TableContext context)
{
_context=context;
//_hostingEnvironment = environment;
}
[HttpGet]
[Route("CandidateData")]
public ActionResult<List<MyCandidate>> GetAllTodoItems()
{
return _context.MyCandidates.ToList();
}
[HttpGet("{id}", Name = "GetCandidateDetails")] 
public ActionResult<MyCandidate> GetById(string id)
{
var candidate = _context.MyCandidates.Find(id);
if (candidate == null)
{
return NotFound();
}
return candidate;
}
[HttpPost]
[Route("addCandidates")]
public IActionResult Create(MyCandidate candidates)
{
    if(candidates.Id == null)
        {
            Guid obj = Guid.NewGuid();
            string gid = obj.ToString();
            candidates.Id = gid; 
        }
    _context.MyCandidates.Add(candidates);
    _context.SaveChanges(); 
    var data = _context.MyCandidates.Find(candidates.Id); 
    return CreatedAtRoute("GetCandidateDetails", new { id = candidates.Id }, candidates);
}
[HttpPut("{id}")]
public IActionResult Put(string id,MyCandidate candidates)
{
    var data = _context.MyCandidates.Find(id); 
    data.ResourceRequisition = candidates.ResourceRequisition;
    data.CandidateEmail = candidates.CandidateEmail;
    data.Stages = candidates.Stages;
    data.ResumeText = candidates.ResumeText;
    data.ResumeUpload = candidates.ResumeUpload;
    data.Stages = candidates.Stages;
    data.PanelDeadline = candidates.PanelDeadline; 
    _context.MyCandidates.Update(data);
    _context.SaveChanges(); 
    data = _context.MyCandidates.Find(id); 
    return CreatedAtRoute("GetCandidateDetails", new { id = id }, candidates);
}
// DELETE api/values/5
[HttpDelete("{id}")] 
public void Delete(string id)
    {
    var data = _context.MyCandidates.Find(id);
    if(data != null)
    {
        _context.MyCandidates.Remove(data);
        _context.SaveChanges();
    }
    }
}
}