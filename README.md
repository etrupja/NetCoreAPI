**REST API using ASP.NET Core, Entity Framework Core and Code First Pattern**##


### Technologies used:
•	ASP.NET Core
•	Entity Framework Core
•	Entity Framework Migrations – Code First
•	Repository pattern

### **1.	Installing .NET Core**
To install .NET Core please follow the steps on the official web site https://www.microsoft.com/net/core#windowsvs2015

### **2.	Opening project**
a.	Open the solution in VS 2015 
b.	Open Package Manager Console on the project by going to: Tools > Nuget Package Manager > Package Manager Console
c.	On the start up class modify the database connection string (connection) to reflect your database environment
d.	Run the following commands (they will create the database schema on your database environment):
i.	Dotnet ef migrations add “initial”
ii.	Dotnet ef database update

### **3.	Build and Run**
You could test the API using POSTMAN which can be downloaded from here: https://www.getpostman.com/



