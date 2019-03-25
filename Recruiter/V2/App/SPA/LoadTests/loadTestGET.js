
    const loadtest = require('loadtest');
    var options = {
        url: 'http://127.0.0.1:5001/api/ResourceRequisition/ResourceRequisitionData',
        maxRequests: 2 ,
        concurrency: 5,
        requestsPerSecond: 10,
        method: 'GET'       
    };
    
    loadtest.loadTest(options, function(error, result){
        console.log(result);
        if(result.totalErrors>0)
        {
          console.log('\n' +'\n'+".............Test Failed ! ....................");    
          console.log("Error : ")
          console.log(result.errorCodes);         
        }
        else if(result.totalErrors==0)
        {        
        return console.log('\n'+" .............Test Successfull ! ....................");
        }
    });

                 