# Full-Stack To-Do List Application

This is a complete full-stack web application built from scratch, demonstrating a backend REST API and a frontend client application working together.

---

## Features
* **Full CRUD Functionality:** Create, Read, Update, and Delete to-do items.
* **Persistent Data:** All data is stored in a SQL Server database using Entity Framework Core.
* **Responsive Frontend:** The user interface is built with Blazor WebAssembly and works on any screen size.
* **Clean Architecture:** The solution is structured with separate projects for the backend API and the frontend client, promoting separation of concerns.

---

## Technologies Used
* **Backend:** C#, ASP.NET Core Web API
* **Frontend:** Blazor WebAssembly
* **Database:** Entity Framework Core, SQL Server LocalDB
* **Tools:** Visual Studio 2022, Git

---

## How to Run
1.  Clone the repository.
2.  Open the `TodoApi.sln` file in Visual Studio.
3.  Ensure the database connection string in `TodoApi/appsettings.json` is configured for your environment.
4.  Set the Solution to launch multiple startup projects (`TodoApi` and `TodoApp.Client`).
5.  Press **F5** to run the application. The API will launch in a console window and the Blazor app will open in your browser.


---

## What's next
1. Validation: Add checks to prevent users from creating empty to-do items.

2. Authentication & Authorization: This is the most significant next step. Add user accounts so that different people can have their own private to-do lists.

3. Better UI/UX: Improve the user experience with loading indicators, error messages, and confirmation dialogs (e.g., "Are you sure you want to delete?").

4. Deployment: Learn how to deploy both the API and the Blazor app to a cloud service like Microsoft Azure, making it live on the internet.
