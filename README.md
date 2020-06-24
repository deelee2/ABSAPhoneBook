# ABSAPhoneBook
PhoneBook Application Assessment

Setup guide:

The project consists of both a Frontend and Backend application.

The API files can be found in the API folder found in this directory.
The Frontend files can be found in the Frontend folder also found in this directory.

In order for the API to start up, you are required to have Mongo installed on your machine. 
The API expects a server to be running at mongodb://localhost:27017".

You can find install instructions here: https://docs.mongodb.com/manual/installation/

Currently I am adding a manual phone book entry to the database on start up. 
Every time you restart the service, a new phone book will be added. This is just so data will be visible on start up. 


API:

Please note, I made use of Visual Studio for Mac which is still relatively new. 

Prerequisites:

Visual Studio for Mac:

    1 .NET Core SDK 3.0 or later
    
    2 Visual Studio for Mac version 7.7 or later


Visual Studio:

    1 .NET Core SDK 3.0 or later
    
    2 Visual Studio 2019 with the ASP.NET 
    
    3 MongoDB

Open PhoneBookApi.sln in the API folder and run the service. 


Frontend Vue application:

In a terminal, cd to the root directory and run the below commands: (these instructions can be found in the ReadMe within the application)

cd Phone-Book/


# install dependencies
npm install

# serve with hot reload at localhost:8080
npm run dev

# build for production with minification
npm run build


The Server should auto load a phone book entry on startup. You can select a phone book entry in the drop down found at the top right of the page 'Select Phone Book'. 
Once you have selected a phone book to view, you will see the entries within. No data is display on startup of the page. 


Things that I would improved on if the time was available:

Frontend improvements:

* Alphabetical order of phone book

* Better visual styling in general

* Adding a new phone book from the UI

* Regex expression to manage input validation

* Pagination of phone book entries 

* Unit testing/Integration testing

* Logging/Metrics

* Service error code management to improve user experience and debugging (catch errors from the server).
Currently I'm not catching any errors from the server and I feel bad about this :(


Backend improvements:

* Unit Testing (Making use of interfaces and DI)

* Better error handling. Ideally I would have custom error handling classes to manage specific error types. 
Error messages could then be more detailed, enabling the client to manage it more efficiently their side.

* Mongo initialisation could be improved. 
It could be moved out to another class only responsible for database setup. (Satisfy SOLID principles)

* Prevent duplicate entries from being added

* General input validation from the client. 
Although I have input validation on the client side, we still need to check if we have valid entries for both name and number on the server.

* Use of generics and possibly look at async calls to the database. 
Async calls would not really provide any value in this case as there would not be any visual improvement to the application. 
We still need the data either way

* If we needed Auth: OAuth2 would be the way to go. 

* Cors management is not ideal

* Better route naming 

* Logging and Metrics (Using something like splunk potentially)

