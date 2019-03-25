using Xunit;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using CandidateModel.Models;
using System;
using QandAApi.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace IntegrationTests
{
    public class CandidateTests: TestBase
    {

               [Fact]
        public async System.Threading.Tasks.Task ListCandidates()
        {            
            var response = await Client.GetAsync("/api/Candidate/CandidateData");                
            response.EnsureSuccessStatusCode();                
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);                    
        }

        [Fact]
          public async System.Threading.Tasks.Task AddCandidate()
        {
         var candidateContent=new MyCandidates();
        candidateContent.Id= "f13c1a0a-1f70-4fc0-8aa8-6a4986640280";
        candidateContent.ResourceRequisition= "Manager";
        candidateContent.CandidateEmail= "test@example.com";
        candidateContent.Stages= 2;
        candidateContent.ResumeText="CAsca";
        candidateContent.ResumeUpload="";
        candidateContent.PanelDeadline=new DateTime(); 
        var payload =  new StringContent(JsonConvert.SerializeObject(candidateContent),
        Encoding.UTF8, "application/json");
         var response = await Client.PostAsync("/api/Candidate/addCandidates",payload);

        response.EnsureSuccessStatusCode();                
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);                
        }
        
         [Fact]
          public async System.Threading.Tasks.Task UpdateCandidate()
        { 
            // Arrange
            var candidateContent=new MyCandidates();
            candidateContent.ResourceRequisition= "edited Manager";
            candidateContent.CandidateEmail= "test@example.com";
            candidateContent.Stages= 3;
            candidateContent.ResumeText="edited resume";
            candidateContent.ResumeUpload="";
            candidateContent.PanelDeadline=new DateTime(); 
            var payload =  new StringContent(JsonConvert.SerializeObject(candidateContent),
            Encoding.UTF8, "application/json");

            // Act
            var response = await Client.PutAsync("/api/Candidate/9999",payload);
            response.EnsureSuccessStatusCode();                

            // Asserts
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

           var o = JsonConvert.DeserializeObject<MyCandidates>(response.Content.ReadAsStringAsync().Result);
           Assert.Equal("edited Manager", actual: o.ResourceRequisition);

         }
        
        [Fact]
          public async System.Threading.Tasks.Task DeleteCandidate()
        {       
         var response = await Client.DeleteAsync("/api/Candidate/9999");
        response.EnsureSuccessStatusCode();                
        Assert.Equal(HttpStatusCode.OK, response.StatusCode); }
    }
}
