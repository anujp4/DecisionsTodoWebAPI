# DecisionsTodoWebAPI

This is a .NET Web API for a To-Do application that supports basic task management features such as creating, updating, retrieving, and deleting tasks. It is intended to be used alongside a front-end client, such as a React or Blazor application.

## Features

- RESTful API endpoints for managing tasks
- Entity Framework Core with Code First Migrations
- SQL Server as the database provider
- CORS enabled for front-end communication

## Getting Started

### Prerequisites

- [.NET 7.0 SDK or later](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) (with ASP.NET and web development workload)
- SQL Server (LocalDB or full instance)

### Setup Instructions

user has change the connection string to point to the database

### API Endpoints
Here are some common endpoints:
| Method | Endpoint        | Description         |
| ------ | --------------- | ------------------- |
| GET    | /api/todos      | Get all to-do items |
| GET    | /api/todos/{id} | Get a specific item |
| POST   | /api/todos      | Create a new item   |
| PUT    | /api/todos/{id} | Update an item      |
| DELETE | /api/todos/{id} | Delete an item      |
