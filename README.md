# AspireDay Web Application

The AspireDay Web Application is a Blazor Server application designed to demonstrate a simple e-commerce platform with functionalities such as a counter, error handling, and a store feature with real-time updates using SignalR.

## Features

- **Counter**: A simple page that increments a counter each time a button is clicked.
- **Error Handling**: A dedicated error page that displays error details and suggests switching to the development environment for more detailed error information.
- **Store**: A store page that allows users to view, add, edit, and delete buy orders. It integrates with a backend API to manage orders and uses SignalR for real-time updates.

## Technologies

- **.NET 6**: The application is built using .NET 6, leveraging the Blazor Server framework for building interactive web UIs with C#.
- **SignalR**: Used for enabling real-time web functionality, allowing the server to send asynchronous notifications to client-side web applications.
- **Mapster**: Utilized for object-to-object mapping in .NET, simplifying the transformation of data models.
- **Syncfusion Blazor Components**: Provides rich UI components for Blazor applications, used in this project for displaying and managing the orders in the store.

## Setup and Installation

1. **Prerequisites**:
   - Ensure you have [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed on your machine.
   - An IDE such as [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [JetBrains Rider](https://www.jetbrains.com/rider/) for development.
