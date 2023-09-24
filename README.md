# doctorly
# Event Management API

This is a .NET 5 Web API project for managing events and attendees. The API allows you to perform CRUD operations on events and attendees.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [Visual Studio](https://visualstudio.microsoft.com/), [Visual Studio Code](https://code.visualstudio.com/), or your preferred code editor.

## Clone the Repository

To get started with the project, follow these steps to clone the repository:

git clone https://github.com/phadimanelerefolo/doctorly.git

Running the API Locally
To run the API locally on your development machine, follow these steps:

Open the project in your preferred code editor (e.g., Visual Studio, Visual Studio Code).

Set up your database connection:

Open the appsettings.json file and configure your database connection string under "ConnectionStrings".
json

"ConnectionStrings": {
    "DefaultConnection": "your-connection-string-here"
}

Navigate to Technical.Data and add your connection string inside your db context
Also Navigate to your test project, inside your config file add your connection string
Open a terminal within your code editor or use a command-line terminal.

Navigate to the project's root directory.

Run the following command to apply database migrations and create the database:


dotnet ef database update

Start the API by running the following command:


dotnet run
The API should start locally and be accessible at https://localhost:5001 (HTTPS) or http://localhost:5000 (HTTP).

API Documentation
The API is documented using Swagger. To access the API documentation:

Start the API as explained above.

Open a web browser and navigate to:

Swagger UI: https://localhost:5001/swagger (HTTPS)
Swagger JSON: https://localhost:5001/swagger/v1/swagger.json (HTTPS)
Replace localhost and port number if you configured a different URL.

API Endpoints
The API provides the following endpoints:

GET /api/events: Retrieve a list of all events.
GET /api/events/{id}: Retrieve an event by ID.
POST /api/events: Create a new event.
PUT /api/events/{id}: Update an existing event.
DELETE /api/events/{id}: Delete an event by ID.