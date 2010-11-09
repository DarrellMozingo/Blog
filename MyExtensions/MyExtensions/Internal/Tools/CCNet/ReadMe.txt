1. Install the Windows SDK for Server 2003/2008 and .NET Framework first (Google & download it).
2. Install the version of Subversion in this directory.

3. Move only the following files to their specified destinations, given that:

	%CCInstall% = CruiseControl.NET installation directory (typically C:\Program Files\CruiseControl.NET)

	* Under %CCInstall%\server
		- ccnet.config

	* Under %CCInstall%\webdashboard
		- dashboard.config
		- Fixture.png
		- Populator.png
		- Test.png
		
	* Under %CCInstall%\webdashboard\xsl
		- MBUnitDetails.xsl
		- NCoverExplorer.xsl
		- NCoverExplorerSummary.xsl

4. Create the directory
		C:\Program Files\MSBuild\Microsoft\VisualStudio\v9.0\WebApplications
   Place Microsoft.WebApplication.targets in that folder