# DevBlog

DevBlog is an ASP.NET Core 6 MVC project developed using n-tier architecture. It utilizes various technologies and frameworks such as Entity Framework, AutoMapper, Fluent Validation, Regex and Identity to provide a robust and scalable solution. The project uses MSSQL as its database engine and incorporates features like email verification and password renewal. Additionally, users can add and renew profile photos, share blogs, and write comments.


## Features

- N-tier architecture for better separation of concerns and modularity.
- **ASP.NET Core** 6 MVC framework for building scalable and maintainable web applications.
- **Entity Framework** for object-relational mapping and database access.
- **AutoMapper** for mapping between different object types.
- **Fluent Validation** for robust input validation and error handling.
- **Identity** for user management and authentication.
- Email verification token system for ensuring secure user registration.
- Password renewal functionality for enhanced security.
- Profile photo management for users.
- Blog sharing functionality for users.
- Commenting system for blogs.
- **Regex**: Regular expressions (Regex) are utilized for pattern matching and validation, enabling powerful text processing and data manipulation.


## Prerequisites

Before running the project, ensure you have the following prerequisites installed:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MSSQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Getting Started

1. Clone the repository:

   ```shell
   git clone https://github.com/AliIbrahimov/finalproject.github.io
2. Change to the project directory: 
	```shell
   cd your-project
3. Update the connection string in the appsettings.json file with your MSSQL database details.
4. Run database migrations:
 	```shell
 	dotnet ef database update
5. Start the application:
	```shell
	dotnet run
7. Open your browser and navigate to http://localhost:5000 to access the application.

## Acknowledgments

- [ASP.NET Core](https://dotnet.microsoft.com/aspnet)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://docs.fluentvalidation.net/en/latest/)
- [Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-7.0&tabs=visual-studio)
- [MSSQL Server](https://learn.microsoft.com/en-us/sql/?view=sql-server-ver16)

