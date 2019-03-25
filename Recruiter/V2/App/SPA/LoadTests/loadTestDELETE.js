
    const loadtest = require('loadtest');
    var options = {
        url: 'http://127.0.0.1:5001/api/ResourceRequisition/666666',
        maxRequests: 1,
        concurrency: 5,
        requestsPerSecond: 10,
        method: 'DELETE'       
    };
    error = {
       
    }
    
    loadtest.loadTest(options, function(error, result){
        console.log(result);             
        if(result.totalErrors>0)
        {
          console.log('\n' +".............Test Failed !...................."); 
          console.log("Error : ")
          console.log(result.errorCodes);           
        }
        else
        {        
        console.log('\n'+" .............Test Successfull ! ....................");
        }
    });
                 