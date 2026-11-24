# 📄 CSV Checker

CSV Checker is a web application designed to validate CSV files before a transfer to a business application.

## 🖥️ Tech Stack

**Frontend:**
- **HTML** — Defines the structure and content of the web interface.
- **CSS** — Handles the visual presentation and layout.
- **JavaScript (via Bootstrap 5+)** — Provides client-side interactivity.

**Backend:**
- **VB.NET** — Implements the application logic, CSV processing, and business rule validation.
- **ASP.NET** — Provides the web application environment and handles communication between the interface and backend.

**Database:**
- **PostgreSQL** - Manage and store data

**DevOps:**
- **Windows PowerShell** — Commandline tool
- **Windows 11** — Operating system environment.
- **Git** — Version control.
- **GitHub** — Source code hosting and project management.

## 📊 Data

The app uses table of data `analysis_history` with the following informations :

| Attribute | Conceptual Type | Description |
|---|---|---|
| id | UUID | Unique identifier |
| file_name | String | Name of the analyzed file |
| date | DateTime | Date and time of the analysis |
| status | Enum | COMPLIANT / NON_COMPLIANT |
| detail | Text | Explanatory message or error encountered |

You can consult this script at: [Database/schema.sql](./Database/schema.sql "Link to SQL file")

## 📋 Prerequisites

- PostgreSQL must be installed: https://www.postgresql.org/docs/

## ⚙️ Setup

1. Open a terminal and create the database `csvchecker` with PostgreSQL
2. Create the table using the schema above
3. Add a `.env` file at the root of the project containing database connection informations

```bash
# .env

PGUSERNAME=[YOUR_PGUSERNAME]
PGPASSWORD=[YOUR_PGPASSWORD]
```

4. Run the application using your dev environment and you have access to the main part on https://localhost:44377/

## ▶️ Usage

Verify the docs part when the application is started.

## 🔑 License

<div align="center">Copyright &copy; 2026 | Loïck CHERIMONT | All Rights Reserved.</div>
