# Everflow

Setup:
- There are two "appsettings.json" files in the {Everflow.EventPlanner.UI.ServerSide project, Everflow.EventPlanner.API} projects. Which have a default connection string to local sql server. 
  This must be changed to your local sql server instance and database. Note the database must have been already created in the sql instance even though its empty. 

- In package manager console window. You need to run command "update-database". This will run the migration and attempt to persist the tables and data into your database.
- Select "Everflow.EventPlanner.UI.ServerSide" as your startup project and run the application.

Once the application has loaded. There are two panels on left. 
- Home panel shows all the events that have been created in the system.
- People panel shows all the people that have been registered.
Note: I did not implement any delete functionality due to time constraints.

User Interface:
In my current employment, we use dev express to implement UI components to save us time. For this project, I have decided to use MudBlazor because its free and I have heard positives things in the community about it. If I was given more time, then I would have considered creating my own components. 

Security:
To be honest, I am not an expert in secuirty. This is one aspect of the software development that I would like to learn more about. 
I have implemented a bearer token authentication on the API project. I would expect that a mobile client could call this api to so an individual user can see the events that have been assigned to them. 
Due to time constraints, I couldn't implement;
- Log in functionality into the main app.
- Hashing user passwords in database. 

Api Documentation
I have created two api end points;
- Auth endpoint (POST) - This will take in person email address and password in the body of the call and return a bearer token.
- Event endpoint (GET) - This will take in personId from parameters and return a list of all events that the person is attending

Scalability:
I have implemented the onion architecture with domain driven design. This allows developers to isolate of the application layer and create tests around certain key behaviours. The modurlarity allows for easier scalling as each layer can be scalled independently without effecting the others.

Unit Testing:
I have added two sets of unit tests for validating creating people and creating events. 

