# Release Notes

- Major issues encountered during development that have been fixed:
	- Integration of database with the two applications
	- Modular functionality of in-game assignments

### Version 1.0

#### Included Functionality

- Firebase and REST API backend to handle database requests to populate the game
- Users can create a team of adventurers and embark on quests
- Account creation and login with user data stored in Firebase DB in accordance to FERPA Laws
- Users can submit assignments, view assignments, and view progress
- Users can view the entire course syllabus
- Users can redeem in-game rewards for items and quests

#### Outstanding Bugs

- No outstanding bugs

# Install Guide / Requirements

- Users only need to download the .exe file for the program, which is bundled with a data file that contains the assets needed for the game to run.
- Developers must download the Unity Editor and open the project file provided. No external libraries are needed, but it is possible that future versions of Unity might require re-import of assets, which Unity handles on its own. The current build is located in the “build” file in the project.

## Deployment Guide - Desktop Application (MAC/ WINDOWS)

The desktop application uses the C++ and Visual Basic framework that can be downloaded [here](https://www.microsoft.com/en-us/download/details.aspx?id=9639). The application also uses the Unity Engine, and requires the Unity Editor. The project can be opened on any platform that the Unity Engine supports. All scripts are found in the “Scripts” folder within the project. The project can be opened merely by selecting the project folder in the Unity Editor. Unity uses its own UI editor, and typically uses Visual Studio for script editing, though the default IDE can be changed. All UI elements must be edited using the Unity Editor. Furthur documentation on using the Unity Editor can be found [here](https://docs.unity3d.com/Manual/index.html).


## Deployment Guide - Teacher Portal (MAC/WINDOWS)

The teacher portal is a Java application which can be deployed to any machine which has Java v7+. The application includes all necessary libraries as add-on bundles, so no other actions are necessary. The teacher portal is made using Java and all relevant files containing the source code can be found in the on github. The portal can be launched by clicking on the .jar file provided. If a developer is taking over this application, they can make changes by editing the .java files in the directory. It is recommended that an IDE such as IntelliJ is used to simplify the front end development and also help debugging if needed.

## Deployment Guide - Backend

A Google account was created and privately shared to be accessed by the client only. She has requested that the private and public keys she uses to access the database are not to be publicly displayed on Github for other developers at this time. (However, include in-depth discussion of how a developer taking over this application would be able to access and use backend functionality?)
