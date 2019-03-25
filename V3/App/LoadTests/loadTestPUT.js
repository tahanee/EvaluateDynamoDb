debugger;
    const loadtest = require('loadtest');
    var options = {
        url: 'http://127.0.0.1:5001/Api/ResourceRequisition/3911383a-9e51-414b-a547-783456fce187',
        maxRequests: 5,
        concurrency: 5,
        requestsPerSecond: 10,
        method: 'PUT',
        contentType: 'application/json',        
        body : 
        {                                
            "title": "Data Analyst 2 Edited ",
            "description": "fkdjkdjg kefleflkfgkdg krfrfrefre edited",
            "hiringManagerEmail": "xyzabc@gmail.com edited",
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
          console.log('\n' +'\n'+".............Test Failed ! ...................."+ color + red);   
          console.log("Error : ")
          console.log(result.errorCodes);          
        }
        else
        {        
        console.log('\n'+" .............Test Successfull ! ....................");
        }
    });
                 