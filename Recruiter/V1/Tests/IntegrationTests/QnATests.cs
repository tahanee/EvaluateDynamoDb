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
    public class QnATests : TestBase
    {
         //private readonly List<MyCandidate> list;
        string gid;
           private void SetUp()
             {
                 Guid obj = Guid.NewGuid();  
                gid =  obj.ToString();   
            }

      
    [Fact]
          public async System.Threading.Tasks.Task ListQnA()
        {            
            var response = await Client.GetAsync("/api/Values/TableData");                
            response.EnsureSuccessStatusCode();                
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);                    
        }

         [Fact]
          public async System.Threading.Tasks.Task AddQandA()
        {                        
                var  QnAItem = new Item();
                QnAItem.Id= "68764923bnmbnmn";
                QnAItem.Ques = "IntegrationTestQuestion";
                QnAItem.Ans = "IntegrationTestAnswer";
                var payload =  new StringContent(JsonConvert.SerializeObject(QnAItem),
                Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("/api/Values/Item",payload);

            response.EnsureSuccessStatusCode();                
           
            Assert.Equal(HttpStatusCode.Created, response.StatusCode); 
                   
        }
 
         
    }
    
}
