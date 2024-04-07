# Service Oriented Architecture

The program is developed in C#, utilizing the .NET Core Web API template. The solution is structured into four distinct projects:

- **SOA**: Acts as the startup project. It includes the `Program.cs` file, which is the entry point of the project, along with all controllers and mapping profiles.
- **SOA.Common**: Contains all shared code used across other projects.
- **SOA.Services**: Houses all the service logic.
- **SOA.Data**: Comprises all database entities, migrations, and repositories.

To improve usability, Swagger has been integrated, providing a convenient interface to visualize and test the project's endpoints. The database is powered by MariaDB version 10.6 and is deployed using Docker, facilitating an efficient setup.
