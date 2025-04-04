📚 Teacher Management API
A RESTful API built using ASP.NET Core and MS SQL Server to perform full CRUD operations for managing Teachers and their associated Classes. Developed in Visual Studio 2022.

🚀 Features
✅ Create, Read, Update, Delete Teachers

✅ Manage Classes (Add / Update / Delete)

✅ Relational Mapping: Each Teacher belongs to a Class

✅ Clean Architecture with Entity Framework Core

✅ SQL Server Integration

✅ Swagger UI for API Testing

🛠 Tech Stack
Backend Framework: ASP.NET Core Web API (.NET 6/.NET 7)

Database: Microsoft SQL Server

ORM: Entity Framework Core

IDE: Visual Studio 2022

Documentation: Swagger / Swashbuckle

🧱 Database Structure
🧑‍🏫 Teacher Table
Field	Type	Description
Id	GUID	Primary Key
Name	string	Teacher's full name
Subject	string	Subject taught
Age	int	Age of the teacher
Gender	string	Gender
Address	string	Residential address
ClassId	int	Foreign Key to Class
🏫 Class Table
Field	Type	Description
ClassId	int	Primary Key
ClassName	string	Name of the class
📂 Project Structure
pgsql
Copy
Edit
TeacherManagementAPI/
│
├── Controllers/
│   ├── TeacherController.cs
│   └── ClassController.cs
│
├── Models/
│   ├── Teacher.cs
│   └── Class.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Migrations/
│   └── [EF Core migrations]
│
├── Program.cs
└── appsettings.json
⚙️ How to Run
Clone the Repository

bash
Copy
Edit
git clone https://github.com/yourusername/TeacherManagementAPI.git
Open in Visual Studio 2022

Configure Connection String

Update appsettings.json with your SQL Server connection string:

json
Copy
Edit
"ConnectionStrings": {
  "Dbcs": "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;"
}
Apply Migrations

bash
Copy
Edit
Add-Migration InitialCreate
Update-Database
Run the Project

Press F5 or click Start in Visual Studio.

Test with Swagger

Navigate to https://localhost:{port}/swagger to access Swagger UI.

📬 API Endpoints
Teachers
Method	Endpoint	Description
GET	/api/teacher	Get all teachers
GET	/api/teacher/{id}	Get teacher by ID
POST	/api/teacher	Add new teacher
PUT	/api/teacher/{id}	Update teacher
DELETE	/api/teacher/{id}	Delete teacher
Classes
Method	Endpoint	Description
GET	/api/class	Get all classes
GET	/api/class/{id}	Get class by ID
POST	/api/class	Add new class
PUT	/api/class/{id}	Update class
DELETE	/api/class/{id}	Delete class
📄 License
This project is licensed under the Apache 2.0 License.

🙌 Acknowledgements
Microsoft Docs

Entity Framework Core Documentation

Swagger for API testing

