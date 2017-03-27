# watson-visual-recognition-netcore #
Watson Visual Recognition SDK &amp; Tool for .NET Core

[Live Demo](http://watson-visual-recognition-tool.mybluemix.net/)

This project consists of an abstraction SDK from Watson's Visual Recognition api's for .NetCore and web project utility for the management and classification of images.

## SDK

The SDK was developed using .NetCore, and is intended to facilitate the use of the Visual Recognition API for .NET developers, allowing the the use of face detection, image classification and managing custom classifiers in a fast and easy way

## Utility

The utility was developed above the SDK mentioned above, and using ASP.NET and AngularJS to create a simple and friendly interface.

With this utility, it is intended that anyone, regardless of machine learning or programming knowledge, can use the benefits of visual recognition.

Examples:

* A dealership can use the utility to search for the car model with just one photo.

* A clothing store can take the photo of a dress and find similar products.

* A biologist can identify specimens of animals with just the photo of it.

* Hospitals can diagnose imaging tests by comparing them to other tests.

All of this without writing any line code or having a T.I. team to implement the solution. Only using the [Live Demo](http://watson-visual-recognition-tool.mybluemix.net/)



## Docs:


* For the Watson Visual Recognition API

  For instructions on using the Watson Visual Recognition API, visit the following documentation:
  http://www.ibm.com/watson/developercloud/doc/visual-recognition

* For the project instructions

  For instructions on how to use the tool and the SDK: 
  
  https://github.com/psbds/watson-visual-recognition-netcore/wiki

### Running the tool

### System Requirements

* Library's: 
  * .NETCore Version 1.0.0-preview2-003121

* IDE's (Optional): 
  * Visual Studio 2015
  * Visual Studio Code

* OS (any of the following): 
  * Windows 7 (or higher), 
  * OSX
  * Linux (RHEL, Ubuntu, Debian, Fedora, CentOS, openSUS)

* Browsers (any of the following): 
  * Chrome
  * FireFox
  * Opera
  * Edge
  * Internet Explorer 10 (or higher)
 
 
### Project Run

1. Install .NET Core version 1.0.0-preview2-003121

  * [x64](https://go.microsoft.com/fwlink/?LinkID=809122)
  
  * [x86](https://go.microsoft.com/fwlink/?LinkID=809123)
  
2. Install [npm](https://www.npmjs.com/)

3. Install [bower](https://bower.io/)
  
        1. Open the npm command line
  
        2. Run the command `bower install -g`


4. Run the Project

    1. For Linux and Mac Users
    
        1. Go to the solution folder and open the npm command line
    
        2. Run the command `npm install`
  
        3. Run the command `bower install`
  
        4. Open the terminal and run:

         `dotnet restore`

         `dotnet run -p src / Watson.VisualRecognition.Tool `
    
    2. For Windows Users with Visual Studio

        1. Open the solution in Visual Studio and wait for the restoration of nuget, npm and bower packages
   
        2. Hit F5 to build and Run
    
    3. For Windows Users without Visual Studio

        1. Go to the solution folder and open the npm command line
    
        2. Run the command `npm install`
  
        3. Run the command `bower install`
    
        4. Navigate to the solution folder, open the command window and run:
   
        `dotnet restore`

        `dotnet run -p src / Watson.VisualRecognition.Tool `
      
### Next Steps

The next steps for this project are:

1. Publish the SDK as nuget package

2. Improve documentation

3. Implement Visual Recognition Collections (currently on BETA)



#### Questions, suggestions and pull requests are always welcome, feel free to do it :)
