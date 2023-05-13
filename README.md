# EasyBlog

EasyBlog is an ASP.NET Core 6 MVC project developed using n-tier architecture. It utilizes various technologies and frameworks such as Entity Framework, AutoMapper, Fluent Validation, and Identity to provide a robust and scalable solution. The project uses MSSQL as its database engine and incorporates features like email verification and password renewal.

## Features

- N-tier architecture for better separation of concerns and modularity.
- ASP.NET Core 6 MVC framework for building scalable and maintainable web applications.
- Entity Framework for object-relational mapping and database access.
- AutoMapper for mapping between different object types.
- Fluent Validation for robust input validation and error handling.
- Identity for user management and authentication.
- Email verification token system for ensuring secure user registration.
- Password renewal functionality for enhanced security.

## Prerequisites

Before running the project, ensure you have the following prerequisites installed:

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MSSQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Getting Started

1. Clone the repository:

   ```shell
   git clone https://github.com/your-username/your-project.git
2. Change to the project directory: 
   cd your-project
3. Update the connection string in the appsettings.json file with your MSSQL database details.
4. Run database migrations:
  dotnet ef database update
5. Start the application:
6. Open your browser and navigate to http://localhost:5000 to access the application.

