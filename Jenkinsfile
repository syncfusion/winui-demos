node ('Maui') 
{ 
timestamps
{
 timeout(time: 7200000, unit: 'MILLISECONDS') 
 {
    stage 'Checkout' 
    try
    {	
	  checkout([$class: 'GitSCM', branches: [[name: '*/$githubSourceBranch']], doGenerateSubmoduleConfigurations: false, extensions: [[$class: 'RelativeTargetDirectory', relativeTargetDir: 'SB-winui']], submoduleCfg: [], userRemoteConfigs: [[credentialsId: env.githubCredentialId, url: 'https://github.com/essential-studio/samplebrowser-winui.git']]])
	  
	  checkout([$class: 'GitSCM', branches: [[name: 'development']], doGenerateSubmoduleConfigurations: false, extensions: [[$class: 'RelativeTargetDirectory', relativeTargetDir: 'xaml-cake-plugin']], submoduleCfg: [], userRemoteConfigs: [[credentialsId: env.githubCredentialId, url: 'https://github.com/essential-studio/xaml-cake-plugin.git']]])
    }
    catch(Exception e)
    {
        echo "Exception in checkout stage \r\n"+e
        currentBuild.result = 'FAILURE'
    }
if(currentBuild.result != 'FAILURE')
{		   
	stage('Install Software') {
		try
		{
		    nodejs(nodeJSInstallationName: 'nodejs-16.17.1') {
			    bat 'npm config ls'
			}

			env.PATH = "C:\\tools\\jenkins.plugins.nodejs.tools.NodeJSInstallation\\nodejs-16.17.1;${env.PATH}"
			bat 'npm -v'
			bat 'npm install --location=global appcenter-cli'
			
			bat 'powershell.exe -ExecutionPolicy ByPass -File SB-winui/Install.ps1'
			echo "Software installation completed"
		}
		 catch(Exception e)
		 {
		    echo "Exception in software installation stage \r\n"+e
			currentBuild.result = 'FAILURE'
		 }
	}
}	
if(currentBuild.result != 'FAILURE')
{ 
	stage 'Build Source'
	try
	{		
	    gitlabCommitStatus("Build")
		{
			bat 'powershell.exe -ExecutionPolicy ByPass -File SB-winui/build/build.ps1 -Script '+env.WORKSPACE+"/SB-winui/build/build.cake -Target build -OutputPath Assemblies -StudioVersion  "+env.studio_version+' -nugetserverurl '+env.nugetserverurls
	 	}
                 def files = findFiles(glob: '**/cireports/errorlogs/*.txt')

                 if(files.size() > 0)
                 {
                    currentBuild.result = 'FAILURE'
                 }
    }
	catch(Exception e) 
    {
        echo "Exception in build source stage \r\n"+e
		currentBuild.result = 'FAILURE'
    }
}

if(currentBuild.result != 'FAILURE')
{ 
	 stage 'Test'
	 try
	 {     
		gitlabCommitStatus("Test")	 
        { 
			bat 'powershell.exe -ExecutionPolicy ByPass -File SB-winui/build/build.ps1 -Script '+env.WORKSPACE+"/SB-winui/build/build.cake -Target test -nugetserverurl "+env.nugetserverurls
        }  
	 }	  
     catch(Exception e) 
    {	 
		currentBuild.result = 'FAILURE'
    }
}


if(currentBuild.result != 'FAILURE')
{
	stage 'Code violation'
try
{
	    gitlabCommitStatus("Code violation")
	    {
				 bat 'powershell.exe -ExecutionPolicy ByPass -File SB-winui/build/build.ps1 -Script '+env.WORKSPACE+"/SB-winui/build/build.cake -Target codeviolation"  
	    }
}
	catch(Exception e) 
	{
	    echo "Exception in code violation stage \r\n"+e
		currentBuild.result = 'FAILURE'
	}
}  

if(currentBuild.result != 'FAILURE' && env.publishBranch.contains(githubSourceBranch))
{
	stage 'Publish'
	try
	{
	  //method to get release notes content
	   env.PATH = "C:\\Program Files\\Git\\mingw64\\bin;${env.PATH}"  
       def branchCommit = '"'+'https://api.github.com/repos/essential-studio/SB-winui/pulls/'+env.pullRequestId+'/commits'
	   String branchCommitDetails = bat returnStdout: true, script: 'curl -H "Accept: application/vnd.github.v3+json" -u SyncfusionBuild:' +env.GithubBuildAutomation_PrivateToken+" "+branchCommit
	   def splitCommitDetails=branchCommitDetails.split('\n')
	   def splitMessageDetails = splitCommitDetails[2].split('"message":')
	   def releaseNotesContent=""; 
		for(int k=1; k<splitMessageDetails.size();k++)
		{
			def commitDetails = splitMessageDetails[k].split('"author_email":')
			for(int j=1; j<commitDetails.size(); j++)
			{			
				 releaseNotesContent+=commitDetails[0].replace(',"author_name":',' - ').replace('\\n','').replace('",','"')+"\r\n";
			}
		}
		if (releaseNotesContent) 
		{  
		   writeFile file: env.WORKSPACE+"/cireports/releasenotes/releasenotes.txt", text: releaseNotesContent
		}
		else  
		{
		   writeFile file: env.WORKSPACE+"/cireports/releasenotes/releasenotes.txt", text: "No commit details found for this job."
		}

	  gitlabCommitStatus("Publish")
	    {
	        bat 'powershell.exe -ExecutionPolicy ByPass -File SB-winui/build/build.ps1 -Script '+env.WORKSPACE+"/SB-winui/build/build.cake -Target publish -apiServerPort 8193 -apiSiteName samplebrowser-winui -StudioVersion  "+env.studio_version+' -revisionNumber '+env.revisionNumber+' -nugetapikey '+env.nugetapikey+' -SourceBranch '+githubSourceBranch+' -XAMLAWSAccessID '+env.XAMLAWSAccessID+' -XAMLAWSAccessKey '+env.XAMLAWSAccessKey+' -apiServerIP '+env.apiServerIP+' -apiServerUserName '+env.apiServerUserName+' -apiServerPassword '+env.apiServerPassword+' -nugetserverurl '+env.nugetserverurls
	    }
	}
	catch(Exception e) 
	{
	    echo "Exception in publish stage \r\n"+e
		currentBuild.result = 'FAILURE'
	}
}
	stage 'Delete Workspace'
	
	// Archiving artifacts when the folder was not empty
	
    def files = findFiles(glob: '**/cireports/**/*.*')      
    
    if(files.size() > 0) 		
    { 		
        archiveArtifacts artifacts: 'cireports/', excludes: null 		
    }
	
	   step([$class: 'WsCleanup']) 
	   }
}
}
