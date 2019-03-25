debugger;
    const loadtest = require('loadtest');
    var options = {
        url: 'http://127.0.0.1:5001/Api/ResourceRequisition/addResourceRequisition',
        maxRequests: 1,
        concurrency: 5,
        requestsPerSecond: 1,
        method: 'POST',
        contentType: 'application/json',        
        body : 
        {                                
            "title": "Data Analyst 2 ",
            "description": "fkdjkdjg kefleflkfgkdg krfrfrefre ",
            "hiringManagerEmail": "xyzabc@gmail.com",
            "notes": "bchdbjfjghjkhfg jkfkdjkjk",
            "skills": "Python",
            "stages": 3,
            "plannedDeadline": "12/08/2018"
        }       
    };
    
    loadtest.loadTest(options, function(error, result){
        console.log(result);
        if(result.totalErrors>0)
        {
          console.log('\n' +'\n'+".............Test Failed ! ...................."); 
          console.log("Error : ")
          console.log(result.errorCodes);            
        }
        else
        {        
        console.log('\n'+" .............Test Successfull ! ....................");
        }
    });
                 