# StudentDB CRUD Console App with PostgreSQL and Npgsql

This is a simple C# console application that performs basic **CRUD** operations on a PostgreSQL database using the **Npgsql** library.

## Features

- ✅ Create table if it doesn't exist
- 📝 Insert new student records
- 🔄 Update existing student records
- ❌ Delete student records by age or ID
- 📄 Retrieve and display student data

## Technologies Used

- C# (.NET Console Application)
- PostgreSQL
- Npgsql (ADO.NET data provider for PostgreSQL)
- appsettings.json for configuration

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Npgsql NuGet package](https://www.nuget.org/packages/Npgsql)

## Table Structure

The application interacts with a table named `StudentDB` with the following columns:

| Column Name    | Data Type   | Description               |
|----------------|-------------|---------------------------|
| id             | SERIAL      | Primary Key               |
| fullname       | VARCHAR     | Student's full name       |
| email          | VARCHAR     | Student's email           |
| age            | INTEGER     | Age of the student        |
| gender         | VARCHAR     | Gender                    |
| date_of_birth  | DATE        | Date of birth             |
| phone          | VARCHAR     | Contact phone number      |
| address        | VARCHAR     | Home address              |
| department     | VARCHAR     | Academic department       |
| level          | INTEGER     | Academic level (e.g., 100)|
| matric_no      | VARCHAR     | Matriculation number      |
| gpa            | DECIMAL     | GPA score                 |
| is_active      | BOOLEAN     | Status (active/inactive)  |

## Setup Instructions

1. **Clone the project** or create a new C# console app.
2. **Install Npgsql** via NuGet:
   ```bash
   dotnet add package Npgsql
   - Add below packages using Npsql
        Microsoft.Extensions.Configuration
        Microsoft.Extensions.Configuration.json
        Npgsql.EntityFrameworkCore.PostgreSQL
        Npgsql.EntityFrameworkCore.PostgreSQL.design
3. **Create appsettings.json in the root of your project:**
{
  "ConnectionStrings": {
    "defaultConnection": "Host=localhost;Port=5432;Username=postgres;Password=yourpassword;Database=yourdbname"
  }
}
4. **Include the blow in the csproj file**
   <ItemGroup>
    <None Update="appsettings.json">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
  </ItemGroup>

