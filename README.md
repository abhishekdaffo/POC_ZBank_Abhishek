Demo Web Application for Customer for banking implemented using Clean Architecture and DDD. 

STEPS TO SETUP Project:

•	Ensure Asp.Net Core Framework 6 runtime is available
•	Then change connetionString in appsettings.json

STEPS TO SETUP DB
•	In Project Infrastructure run following command in Package Manager Console
  	Update-Database
    
FOR LOGIN
•	You can use abhishek1@test.com | test123
OR
•	You can also register as a new user and test for same

SOME Defaults
•	By default we are adding $5000 for demo to every new created user
•	Error page is hidden and Custom Error page is shown. Can be enabled from Program.cs
•	Banking service is major service which our UI is interacting to.
•	MediatR is being used to communicate with our query and command handlers in Banking Service
•	Also in Program.cs for Code related to CORS currently has origin set as https://localhost:7203/ if it different in your system then change accordingly
•	Test Project has test cases of each method of all repositories created
•	Payment and SMS provider are created and method is also called but method is left blank as this is demo project
•	Error logs are getting logged in DB table dbo.Error
