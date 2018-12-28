# Unicab
**UNICAB SERVICE** - a project to develop an app ecosystem for student cab drivers in Universiti Sains Malaysia!

* If you are reading this README from the project CD, you can also access this README online at the project's
GitHub link: https://github.com/djkimion007/Unicab

* If you intend to take up and make improvements on this project, I highly recommend that you fork this project
(it's MIT-licensed anyway).

## Preamble

This project consists of three components:

1. API server (**__Unicab.Api__**)
2. Admin (Web) interface (**__Unicab.Admin__**)
3. Cross-platform mobile application (**__Unicab.App__**)

The project makes use of **ASP.NET Core Razor Pages / MVC and Entity Framework Core**, as well as **Xamarin.Forms cross-platform
mobile development** via **Visual Studio 2017** - adequate knowledge of these technologies are expected.

## Minimum Prerequisites:

1. **MS Visual Studio 2017 Community Edition** - latest version with at least Mobile Development with
Xamarin and ASP.NET Web Development workloads installed.
2. A decent computer with a decent specification - minimum **8GB RAM** and about 1GB disk space.
3. (Android) An Android smartphone with at least 1GB RAM and version 5.0 (Lollipop) and above.

## Getting Started

1. Open Visual Studio.
2. Load the solution file from the desired solution (API or Web or App)
3. Explore, test and fix the codes!

### a. Starting the API data server

1. Load **Unicab.Api** solution (Unicab.Api.sln)
2. **You will first need to set up MS SQL Server LocalDB for the data server to function. If this step is done once, then you
don't need to repeat this step again later on, unless you changed the data models in __Unicab.Api.Models__**
   1. Go to **View -> Other Windows -> Package Manager Console**
   2. Once the PMC is ready, enter `Add-Migration InitialSetup` (InitialSetup is arbitrary, you can name it whatever)
   3. Then, enter `Update-Database`
   4. Once everything is done without errors, proceed to the next steps.
3. Go to **Debug -> Unicab.Api Properties...**
4. Under **Debug** sub-menu and **Profile: Unicab.Api**, at Web Server Settings, set the **App URL**
to your computer's network IP address (you can get it from the Task Manager)
5. Save and press **F5 (Start Debugging)** to start the server under debugging mode in Visual Studio.
(you can also do a **Ctrl-F5 (Start Without Debugging)** if you wish to)

### b. Starting the Admin (Web) server

1. Load **Unicab.Web** solution (Unicab.Web.sln)
2. Go to **Debug -> Unicab.Api Properties...**
3. Under **Debug** sub-menu and **Profile: Unicab.Web**, at Web Server Settings, set the **App URL**
to your computer's network IP address (you can get it from the Task Manager)
4. At Solution Explorer, under **Unicab.Web**, head to **Services** folder and open **AppServerConstants.cs**.
5. Change the **AppServerUrl** value to your computer's IP address as well.
6. Save and do a **Rebuild Solution**, then press **F5 (Start Debugging) or Ctrl-F5 (Start Without Debugging)**
to fire up the Web server. The site can then be accessed from the URL link incl. the port number
(http://10.207.142.52:26830 for example.)

### c. Loading and running the application (Android)

**IMPORTANT PREREQUISITE - Before running the app, make sure that the API data server is __up and running__,
otherwise the app will crash.**

1. Load **Unicab.App** solution (Unicab.App.sln)
2. At Solution Explorer, under **Unicab.App.SM** folder, open **AppServerConstants.cs**.
3. Change the **AppServerUrl** value to your computer's IP address as well.
4. Save and do a **Rebuild Solution**.
5. Connect your Android device, ensure that it is on **Debugging Mode** and that Visual Studio **identifies
your device correctly** (you can refer to the label next to the startup button (the green Play button) to see
if your device identity is correct or otherwise.)
6. Hit **F5 (Start Debugging)** to deploy the app and start up in debug mode.

> Once everything is verified to be running up and well (that is, the API server, admin site and mobile app),
well, **congratulations!** Have fun exploring and improving on the code and features!

## Additional notes

List of abbreviations used in **Unicab.App**:

* CM - common module
* DM - driver module
* LM - landing module (when user starts the app, or exits driver or passenger module)
* PM - passenger module
* SM - services module

Many features are either working well, or somewhat working, or not working at all - that's something to put in
mind if you are trying this out for the very first time.

If ever you encounter issues along the way,  Mr. Google and Mrs. StackOverflow are ready to get you back up and going!

## Contact

I am contactable via e-mail at `lesterngkimho (at) gmail (dot) com` at anytime.