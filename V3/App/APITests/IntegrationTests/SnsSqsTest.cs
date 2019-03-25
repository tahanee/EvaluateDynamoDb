using Xunit;
using System.Net;
using System;
using Amazon.SimpleNotificationService;
using Amazon;
using Amazon.SimpleNotificationService.Model;
using Amazon.SQS.Model;
using Amazon.Runtime;
using Amazon.SQS;
using System.Collections.Generic;

namespace IntegrationTests
{
    public class SnsSqsTest : TestBase
    {
      
    [Fact(Skip="enable environment variables for AWS first")]
          public async System.Threading.Tasks.Task SnsTest()
        {   
            
            var credentials = new EnvironmentVariablesAWSCredentials();
            var client = new AmazonSimpleNotificationServiceClient(credentials, RegionEndpoint.APSouth1);
            //SendMessage(client).Wait(); 
            
            var request = new PublishRequest
            {
                TopicArn = "arn:aws:sns:ap-south-1:722160623806:Request-Requisition",
                Message = "New Request Requisition Added by tahanee"            
            };           

            var response=await client.PublishAsync(request);                             
            Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);                    
        }

         [Fact(Skip="enable environment variables for AWS first")]
          public async System.Threading.Tasks.Task SqsTest()
        {                        
              var credentials = new EnvironmentVariablesAWSCredentials();

              var client = new AmazonSQSClient(credentials, RegionEndpoint.APSouth1);
              ReceiveMessageRequest request;
              request = new  ReceiveMessageRequest
     {
        AttributeNames = new List<string>() { "All" },
        MaxNumberOfMessages = 5,
        QueueUrl="https://sqs.ap-south-1.amazonaws.com/722160623806/candidateQueue",
        VisibilityTimeout = (int)TimeSpan.FromMinutes(10).TotalSeconds,
        WaitTimeSeconds = (int)TimeSpan.FromSeconds(5).TotalSeconds
    };
 
    ReceiveMessageResponse response = await client.ReceiveMessageAsync(request);
           
            Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);                   
            
        }    
}    
}
