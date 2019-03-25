
    const loadtest = require('loadtest');
    var options = {
        url: 'http://127.0.0.1:5000/api/ResourceRequisition/ResourceRequisitionData',
        maxRequests: 2 ,
        concurrency: 5,
       requestsPerSecond: 10,
        method: 'GET'
       
    };
    
    loadtest.loadTest(options, function(error, result){
        console.log(result);
        if(error)
        {
           return console.error("Error in Fetch Method");            
        }
        else
        console.log("Test Successfull !")
    });
                 