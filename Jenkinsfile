pipeline {
         agent any
         stages {
		stage('Shutdown App at start') {
			steps{
				sh "sudo su"
				sh "fuser -k 5001/tcp || echo 'Port not in use'"
				}					
			}
		 stage('Build') {
			steps{
			        dir ('Recruiter/V2/App/API'){
				sh "sudo su"
				sh "dotnet build"}
			      }			 
			   }
		 stage('Execute Unit + Integration Tests') {
			steps{
			        dir ('Recruiter/V2/App/APITests/IntegrationTests'){
				sh "sudo su"
				sh "dotnet test"}
			      }			 
			   }
                 stage('Build Deployment Package') {
			steps{
			        dir ('Recruiter/V2/App/API'){
				sh "sudo su"
				sh "dotnet publish"}
			      }			 
			   }
		stage('Setup DB') {
				steps{
				dir ('Recruiter/V2/App/API'){
				sh "mkdir bin/Debug/netcoreapp2.1/DB"
				sh "cp ../DB/Recruiter.db bin/Debug/netcoreapp2.1/DB"}
			      }
				 }
		stage('Launch App') {
				steps{
				dir ('Recruiter/V2/App/API/bin/Debug/netcoreapp2.1/publish'){
				sh "sudo su"
				sh "BUILD_ID=dontKillMe nohup dotnet API.dll &"				
						}
			      }	
				 }
		 stage('Execute API Smoke Tests') {
			steps{
			        dir ('Recruiter/V2/App/APITests/testSuite'){
				sh "sudo su"
				sh "newman run NewCandidateCRUD.json"}
			      }			 
			   }
                 
		}
		post { 
        		always { 
            			cleanWs()
        			}
    		     }
	}

