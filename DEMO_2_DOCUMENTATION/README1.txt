README1

	RateMyPlace requires a web server to run. This can be in the form of a managed web server containing the files or a local web server created specifically for the system. As of writing this documentation, our system has been solely ran from local web servers. The easiest of these to set up would be the IIS Web Server that is created and used by Visual Studio. The steps to set this up are as follows. Assuming the user has installed Visual Studio and downloaded the code.
      
      
1. At any point during this procedure, Visual Studio may prompt you to install the packages required to run an IIS Server or .Net applications, install all of those as prompted.
2. Open the RateMyPlace.sln file using Visual Studio.
3. In the Solution Explorer on the right hand side of the screen, right click on the HomePage.aspx file and select Set As Start Page.
	a. You may have to open the pages folder to see this file.
4. In the top middle of the screen, click on the green play button that will say something along the lines of Start or IIS Server.
5. The application should now be starting in the browser indicated by the start button.
	a. This may take several minutes as the required files are built.

These steps have not changed in any form since Demo 1.
