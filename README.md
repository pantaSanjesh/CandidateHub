  # Overview

This is a Candidate Management API project.

We have created 2 Projects:
CandidateHubAPI

- Contains the main application logic and API endpoints.

- There is 1 Controller with the following APIs:

CandidateController

a. Create or Update Candidate - This endpoint allows creating a new candidate profile or updating an existing one using the email as the unique identifier.

- Contains the models, interfaces, DbContext, and repositories for database interaction.

- We use MS SQL Server as the database for data persistence.

-Implements the repository pattern for abstraction between the database and controller.

2. CandidateManagementAPI.Tests

- An Xunit test project with Moq added for mocking data statically for testing.

- The following test cases are included:

1.AddOrUpdateCandidate_ShouldReturnOk_WhenCandidateIsAddedOrUpdated

2.AddOrUpdateCandidate_ShouldReturnBadRequest_WhenModelStateIsInvalid




## Getting Started
Run the project in Visual Studio. Swagger is enabled for testing API endpoints.

### Prerequisites
Packages required with project details:

1.CandidateHubtAPI

- Swashbuckle.AspNetCore

- Microsoft.EntityFrameworkCore

- Microsoft.EntityFrameworkCore.Tools

- Microsoft.EntityFrameworkCore.SqlServer

2. CandidateManagementAPI.Tests

- coverlet.collector

- Microsoft.Net.Test.Sdk

- Moq

- xunit

- xunit.runner.visualstudio

### Database Configuration

   - We use MS SQL Server for data storage.

   - To set up the database, follow these steps:
     
   - Update the appsettings.json file with your connection string:
		{
		  "ConnectionStrings": {
			"DefaultConnection": "Server=YOUR_SERVER_NAME;Database=CandidateDb;Trusted_Connection=True;"
		  }
		}
   - Run migrations to set up the database:
   
     a.dotnet ef migrations add InitialCreate
     b.dotnet ef database update
	 
   - To view the data, connect to the SQL Server database using a management tool (e.g., SQL Server Management Studio) and query the Candidates table.
   
### More Features

- Use AppDbContext to manage interactions with the database.
- The repository pattern is implemented to separate business logic from data access logic.
- Swagger documentation is enabled for easier testing and exploration of the API.
- Validation is implemented using Data Annotations for input data consistency.



#### File and Folders

- AppDbContext: The DbContext class to configure database tables and relationships.
- Repositories: Interfaces and their implementations to access data from the database
- Interfaces: Define the contract for business logic and data access methods.
- Models: Represent domain entities, such as Candidate.
- DTOs: Data transfer objects for API request and response handling.

##### Bonus Features

- Swagger UI is enabled, making it easy to test API endpoints.
- The application is designed with future extensibility in mind, allowing for easy migration to other storage solutions.
- Validation is handled using DTOs, ensuring clean separation of concerns between API and domain logic. 
- Database connection strings and other configurations can be updated in appsettings.json for different environments.

### Contributions

Contributions are welcome! Fork the repository and submit a pull request for any improvements.
