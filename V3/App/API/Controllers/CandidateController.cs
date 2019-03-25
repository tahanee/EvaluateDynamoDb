using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CandidateModel.Models;
using Amazon;
using Amazon.Runtime;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace API.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class CandidateController : ControllerBase
{
private readonly TableContext _context;
 private readonly IAmazonDynamoDB _dynamoClient;

public CandidateController(TableContext context, IAmazonDynamoDB dynamoClient)
{
_context=context;
_dynamoClient = dynamoClient;


}
[HttpGet]
[Route("CandidateData")]

public async Task<ActionResult<List<MyCandidates>>> GetAllCandidatesAsync()
{  
     var response = await GetItems();

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

        #region dynamoDb
        public async Task<TableItems> GetItems()
        {
            var queryRequest = RequestBuilder();

            var result = await ScanAsync(queryRequest);

            return new TableItems
            {
                Items = result.Items.Select(Map).ToList()
            };
        }

        private Item Map(Dictionary<string, AttributeValue> result)
        {
            return new Item
            {
                Id = result["Id"].S,
                Title = result["Title"].S
            };
        }

        public class TableItems
        {
            public IEnumerable<Item> Items { get; set; }
        }

        public class Item
        {
            public string Id { get; set; }
            public string Title { get; set; }
        }

        private ScanRequest RequestBuilder()
        {
            return new ScanRequest
                {
                    TableName = "RequestRequisition",
                };

        }

        private async Task<ScanResponse> ScanAsync(ScanRequest request)
        {
            var response = await _dynamoClient.ScanAsync(request);

            return response;
        }
        
        #endregion
}


}