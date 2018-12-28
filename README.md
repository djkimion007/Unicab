# Unicab
UNICAB SERVICE - a project to develop an app ecosystem for student cab drivers in Universiti Sains Malaysia!

## Preamble

This project consists of three components:

1. API server (Unicab.Api)
2. Admin (Web) interface (Unicab.Admin)
3. Cross-platform mobile application (Unicab.App)

The project makes use of ASP.NET Core Razor Pages and MVC, as well as Xamarin.Forms cross-platform
mobile development via Visual Studio 2017 - adequate knowledge of these technologies are expected.

## Minimum Prerequisites:

1. MS Visual Studio 2017 Community Edition - latest version with at least Mobile Development with
Xamarin and ASP.NET Web Development workloads installed.
2. A decent computer with a decent specification - minimum 8GB RAM and about 1GB disk space.
3. (Android) An Android smartphone with at least 1GB RAM and version 5.0 (Lollipop) and above.

## Getting Started:

1. Open Visual Studio.
2. Load the solution file from the desired solution (API or Web or App)
3. Explore, test and fix the codes!

### Starting the API data server

1. Load Unicab.Api solution (Unicab.Api.sln) and do a Rebuild Solution
2. Go to **Debug -> Unicab.Api Properties...**
3. Under **Debug** sub-menu and **Profile: Unicab.Api**, at Web Server Settings, set the App URL
to your computer's network IP address (you can get it from the Task Manager)
4. Save and press F5 (Start Debugging) to start the server under debugging mode in Visual Studio.
(you can also do a Ctrl-F5 (Start Without Debugging) if you wish to)

### Starting the Admin (Web) server

1. Load Unicab.Web solution (Unicab.Web.sln)
2. Go to **Debug -> Unicab.Api Properties...**
3. Under **Debug** sub-menu and **Profile: Unicab.Web**, at Web Server Settings, set the App URL
to your computer's network IP address (you can get it from the Task Manager)
4. At Solution Explorer, under Unicab.Web, head to Services folder and open AppServerConstants.cs.
5. Change the AppServerUrl value to your computer's IP address as well.
6. Save and do a Rebuild Solution, then press F5 (Start Debugging) or Ctrl-F5 (Start Without Debugging)
to fire up the Web server. The site can then be accessed from the URL link incl. the port number
(http://10.207.142.52:26830 for example.)

### Loading and running the application (Android)

> **IMPORTANT PREREQUISITE - Before running the app, make sure that the API data server is __up and running__,
otherwise the app will crash.**

1. Load Unicab.App solution (Unicab.App.sln)
2. At Solution Explorer, under Unicab.App.SM folder, open AppServerConstants.cs.
3. Change the AppServerUrl value to your computer's IP address as well.
4. Save and do a Rebuild Solution.
5. Connect your Android device, ensure that it is on Debugging Mode and that Visual Studio identifies
your device correctly (you can refer to the label next to the startup button (the green Play button) to see
if your device identity is correct or otherwise.)
6. Hit F5 (Start Debugging) to deploy the app and start up in debug mode.

> Once everything is verified to be running up and well (that is, the API server, admin site and mobile app),
well, **congratulations!** Have fun exploring and improving on the code and features!

## Additional notes

1. List of abbreviations used in Unicab.App:

CM - common module
DM - driver module
LM - landing module (when user starts the app, or exits driver or passenger module)
PM - passenger module
SM - services module

## Contact

I am contactable via e-mail at `lesterngkimho (at) gmail (dot) com` at anytime in case any (minor) assistance
is needed. Otherwise, Mr. Google and Mrs. StackOverflow are willing to assist as well!