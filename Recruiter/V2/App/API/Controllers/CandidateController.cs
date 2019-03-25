using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CandidateModel.Models;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using Amazon.Runtime;

namespace API.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class CandidateController : ControllerBase
{
private readonly TableContext _context;

public CandidateController(TableContext context)
{
_context=context;

}
[HttpGet]
[Route("CandidateData")]

public async Task<ActionResult<List<MyCandidates>>> GetAllCandidatesAsync()
{  
    try{
        ReceiveMessageRequest request;
        var credentials = new EnvironmentVariablesAWSCredentials();
        var client = new AmazonSQSClient(credentials, RegionEndpoint.APSouth1);    
        request = new  ReceiveMessageRequest
            {
                AttributeNames = new List<string>() { "All" },
                MaxNumberOfMessages = 5,
                QueueUrl = "https://sqs.ap-south-1.amazonaws.com/722160623806/candidateQueue",
                VisibilityTimeout = (int)TimeSpan.FromMinutes(10).TotalSeconds,
                WaitTimeSeconds = (int)TimeSpan.FromSeconds(5).TotalSeconds
            };
            
            ReceiveMessageResponse response = await client.ReceiveMessageAsync(request);
            if
            (response!= null)
            {
                foreach (var message in response.Messages)
                {
                Console.WriteLine("For message ID '" + message.MessageId + "':");
                    Console.WriteLine("  Response: " + message.Body);
                    Console.WriteLine("  MD5Signature: " + message.MD5OfBody);            
                    foreach (var attr in message.Attributes)
                        {
                        Console.WriteLine("    " + attr.Key + ": " + attr.Value);
                        } 
                }
            }
            else
            {
                Console.WriteLine("No messages received.");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("AWS ERROR : " + ex.Message);
        }
    return _context.MyCandidates.ToList();
} 

[HttpGet("{id}", Name = "GetCandidateDetails")] 
public ActionResult<MyCandidates> GetById(string id)
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
    public IActionResult Create(MyCandidates candidates)
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
    public IActionResult Put(string id,MyCandidates candidates)
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