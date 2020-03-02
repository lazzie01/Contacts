# Contacts
This application consists of the API for backend and a Website for the frontend. 

The backend was written using the N-tier design (i.e separating Data Layer, Business Layer & UI/UX Layer).
The Data Layer makes use of Entity Framework Code First approach and its a standalone layer. The Business Layer is made up of the application business rules and is dependents on the Data Layer. 
Finally the UI/UX Layer consists of application view models and it depends on both the Data & Business Layer.

The frontend was written using Angular 9, making use of Angular 9 good programming practices, making it a very cool & maintaiable web app.

The application was developed using the following technologies

database/datastore : SQL Server

backend technology/framework : .Net Framework WebAPI, Entity Framework, .Net Framework, C#

UI technology/framework : Angular 9, Bootstrap 4, Html

To Run the Application

Step 1: Run the backend
1) Open the Backend>System>System.sln using Visual Studio
2) Open the Web.config project in System Project and change the default connection string to point to your server.
3) Run the application
Step 2: Run the frontend
1) Open the Frontend>AngularApp using Visual Studio Code and execute ng serve command
2) The Frontend application will open in the default web browser, please wait for the application to create a database and seed it with inital data.
3) The application will initially list two contact information of Lazarus Munetsi and Jaco Kotze
4) Test the application by performing all the CRUD and search operations 

