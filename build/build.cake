#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#addin nuget:?package=Cake.FileHelpers&version=3.3.0
#tool "nuget:?package=GitVersion.CommandLine&version=5.3.7"
#tool "nuget:?package=JetBrains.dotCover.CommandLineTools&version=2020.1.4"
#tool "nuget:?package=ReportUnit"
#tool "docfx.console"
#addin nuget:?package=Cake.Docfx&version=0.13.1
#addin nuget:?package=Cake.Xamarin&version=3.1.0
#addin nuget:?package=Cake.WebDeploy&version=0.3.4
#addin "nuget:?package=Syncfusion.Build.CakePlugin"
#addin "nuget:?package=Syncfusion.UnitTest.CakePlugin"
#addin "nuget:?package=Syncfusion.APIReference.CakePlugin"

using System.IO;
using System.Collections.Generic;

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Build");
var apiServerIP=Argument<string>("apiServerIP","");
var apiServerPort=Argument<string>("apiServerPort","");
var apiSiteName=Argument<string>("apiSiteName","");
var apiServerUserName=Argument<string>("apiServerUserName","");
var apiServerPassword=Argument<string>("apiServerPassword","");
var SourceBranch=Argument<string>("SourceBranch","");
var XAMLAWSAccessID=Argument<string>("XAMLAWSAccessID","");
var XAMLAWSAccessKey=Argument<string>("XAMLAWSAccessKey","");
var currentDirectory = MakeAbsolute(Directory("../"));
var hasNUnitTestCases  = false;

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Build").Does(() =>
{
   Syncfusion.Build.CakePlugin.BuildAlias.CompileProjects(Context);
   
   // Copies the cireports to repository location to avoid file not found error.
   EnsureDirectoryExists("../cireports");
   Context.CopyDirectory("../cireports", "../../cireports");

})
.OnError(exception =>
{
    // Copies the cireports to repository location to avoid file not found error.
    EnsureDirectoryExists("../cireports");
    Context.CopyDirectory("../cireports", "../../cireports");
	FileWriteText("../cakelog.txt", "Error on Executing Build:" + exception.ToString());
	throw new Exception("Cake process Failed on Build Task");
});

Task("APIReference")
.Does(() =>
{
   if(IsRunningOnWindows())
   {
		Syncfusion.APIReference.CakePlugin.ApiReferenceAlias.Generate(Context);
   }
})
.OnError(exception =>
{
	FileWriteText("../cakelog.txt", "Error on Executing APIReference task:" + exception.ToString());
	throw new Exception("Cake process Failed on APIReference Task");
});

Task("CodeViolation").Does(() =>
{
	if(IsRunningOnWindows())
	{
		//Syncfusion.Build.CakePlugin.BuildAlias.GetStyleCopReports(Context);
		//Syncfusion.Build.CakePlugin.BuildAlias.GetFxCopReports(Context);
	}
})
.OnError(exception =>
{
	FileWriteText("../cakelog.txt", "Error on Executing CodeViolation task:" + exception.ToString());
	throw new Exception("Cake process Failed on CodeViolation Task");
});

//////////////////////////////////////////////////////////////////////
// Test
//////////////////////////////////////////////////////////////////////

Task("Test").Does(() =>
{
	if(IsRunningOnWindows() && hasNUnitTestCases)
	{
	    Syncfusion.Build.CakePlugin.BuildAlias.Test(Context);
		DotCover();
	}
	
})
.OnError(exception =>
{
	FileWriteText("../cakelog.txt", "Error on Test task:" + exception.ToString());
	throw new Exception("Cake process Failed on Test Task");
});


//Apply the DotCover tool to test suite
void DotCover()    
{
    var currentDirectoryInfo=new DirectoryInfo(currentDirectory.FullPath);
	var sourcedirectories = currentDirectoryInfo.GetDirectories("WinForms",SearchOption.AllDirectories);
	var codecoverageFolder = Argument("codecoverageFolder", currentDirectory.FullPath + "/cireports/codecoverage");
	var nunitFolder = Argument("nunitFolder", currentDirectory.FullPath + "/cireports/nunit");
    foreach(var sourcedir in sourcedirectories)
    {
    var winformsDirectories = sourcedir.GetDirectories("Test",SearchOption.AllDirectories);
	foreach(var testSuitDirectory in winformsDirectories)
    {		
	var testDirectories = sourcedir.GetDirectories("bin",SearchOption.AllDirectories);
	foreach(var testProjectDirectory in testDirectories)
	{
		var files = testProjectDirectory.GetFiles("*.Test.dll",SearchOption.AllDirectories);
		
		//Apply the test suite dll to nunit with dotCover tool and its generate a output of coverage as dcvr format.
		foreach(var file in files)
		{		
			int index = file.Name.IndexOf(file.Extension);
			var fileName = file.Name.Substring(0, index);
		try
		{
			 DotCoverCover(tool => {
			 	tool.NUnit3(file.FullName,new NUnit3Settings {
			 		NoResults = false,
			 		Results = new[] { new NUnit3Result { FileName = nunitFolder+"/" +fileName+".TestResult.xml" } }
			 		});},
			 		new FilePath(codecoverageFolder+"/" +fileName+".UnitTestCover.dcvr"),
			 		new DotCoverCoverSettings()
			 		.WithScope(file.FullName)
			 		.WithFilter("-:*Test"));
}
catch
{
}					
		}
		}
		}
		}
		var coveragePercent = "";
            var dcvrFiles = currentDirectoryInfo.GetFiles("*.UnitTestCover.dcvr", SearchOption.AllDirectories);
            var filesCollection = new FilePathCollection(new PathComparer(true));
            foreach (var filePath in dcvrFiles)
            {
                filesCollection.Add(new FilePath(filePath.FullName));
            }
           
           DotCoverMerge(filesCollection, new FilePath(codecoverageFolder + "/UnitTestCover.dcvr"));

           DotCoverReport(codecoverageFolder + "/UnitTestCover.dcvr", codecoverageFolder + "/UnitTestCover.html", new DotCoverReportSettings
            {
                ReportType = DotCoverReportType.HTML
            });

            DotCoverReport(codecoverageFolder + "/UnitTestCover.dcvr", codecoverageFolder + "/UnitTestCover.xml", new DotCoverReportSettings { ReportType = DotCoverReportType.XML });

            //Get the coverage percentage from generated report
            var percentage = (from elements in System.Xml.Linq.XDocument.Load(codecoverageFolder + "/UnitTestCover.xml").Descendants("Root")
                              select (string)elements.Attribute("CoveragePercent")).FirstOrDefault();
            coveragePercent += ":" + percentage + " ";

            var testFiles = currentDirectoryInfo.GetFiles("*.TestResult.xml", SearchOption.AllDirectories);
            foreach (var file in testFiles)
            {
                ReportUnit(file.FullName);
            }

            foreach (var filePath in dcvrFiles)
            {
                DeleteFile(filePath.FullName);
            }

            //Store a coverage percentage as text file.
            FileStream fs1 = new FileStream("../cireports/codecoverage/UnitTestCover.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(fs1);
            writer.Write(coveragePercent);
            writer.Close();
            //Display the coverage percentage
            Information("CoveragePercent : " + coveragePercent);
}

//////////////////////////////////////////////////////////////////////
// Publish
//////////////////////////////////////////////////////////////////////

Task("publish")
.Does(() =>
{
	if(IsRunningOnWindows())
	{
		//Resolved appcenter publish issues in winui sb, so commented the below changes and stopped the app publishing in AWS.
		var information = "SourceBranch:" + SourceBranch + ",\nXAMLAWSAccessID:" + XAMLAWSAccessID  + ",\nXAMLAWSAccessKey:"+ XAMLAWSAccessKey;
		StreamWriter infoFile = new StreamWriter(currentDirectory+"/cireports/information.txt");
		infoFile.WriteLine(information);
		infoFile.Close();
		//Syncfusion.Build.CakePlugin.BuildAlias.AppxPackagePublishInAWS(Context);
		Syncfusion.Build.CakePlugin.BuildAlias.AppCenterPublish(Context);
	}
})
.OnError(exception =>
{
	FileWriteText("../cakelog.txt", "Error on publish task:" + exception.ToString());
	throw new Exception("Cake process Failed on publish Task");
});
	
RunTarget(target);