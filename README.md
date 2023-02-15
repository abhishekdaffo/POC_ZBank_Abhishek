Demo Web Application for Customer for banking implemented using Clean Architecture and DDD. 

STEPS TO SETUP Project:<br />

•	Ensure Asp.Net Core Framework 6 runtime is available<br />
•	Then change connetionString in appsettings.json<br /><br />

STEPS TO SETUP DB<br />
•	In Project Infrastructure run following command in Package Manager Console<br />
  	Update-Database<br /><br />
    
FOR LOGIN<br />
•	You can use abhishek1@test.com | test123<br />
OR<br />
•	You can also register as a new user and test for same<br />

SOME Defaults<br />
•	By default we are adding $5000 for demo to every new created user<br />
•	Error page is hidden and Custom Error page is shown. Can be enabled from Program.cs<br />
•	Banking service is major service which our UI is interacting to.<br />
•	MediatR is being used to communicate with our query and command handlers in Banking Service<br />
•	Also in Program.cs for Code related to CORS currently has origin set as https://localhost:7203/ if it different in your system then change accordingly<br />
•	Test Project has test cases of each method of all repositories created<br />
•	Payment and SMS provider are created and method is also called but method is left blank as this is demo project<br />
•	Error logs are getting logged in DB table dbo.Error<br />
