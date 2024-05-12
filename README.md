
# Academic Grievance Handling System

## Overview
The Academic Grievance Handling System is a web-based application designed to streamline the process of reporting and managing academic complaints by faculty members. Built with .NET C# Web Forms, this application provides a robust interface for users to interact with administrative data efficiently and securely.

## Features
- **Complaint Reporting**: Allows academic faculty to report grievances directly through the interface.
- **Data Management**: Users can manage detailed administrative data concerning courses, departments, staff, and students.
- **Grievance Tracking**: Track the status of each complaint, from filing to resolution.
- **User Authentication**: Secure login system for staff and students to access their respective modules.

## Technologies Used
- **Frontend**: HTML, CSS, JavaScript
- **Backend**: .NET C# Web Forms
- **Database**: SQL Server for robust data management and querying.
- **Architecture**: Structured with a 3-tier architecture, separating the presentation, business logic, and data access layers.

## Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites
- Microsoft SQL Server
- .NET Framework
- IIS Express (For running the project locally)

### Installing
1. Clone the repository to your local machine:
    ```bash
    git clone https://github.com/yourusername/academic-grievance-handling-system.git
    ```
2. Open the solution file in Visual Studio.
3. Restore the necessary packages and rebuild the solution.
4. Set up the database using the SQL script provided in the `DatabaseScript.sql` file.
5. Update the database connection string in `Web.config` according to your SQL Server instance.
6. Run the project using IIS Express in Visual Studio.

## Usage
Log in as an admin to manage the system or as a staff/student to file and track grievances.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Screenshots
![Dashboard](/Screenshots/Dashboard.png "Dashboard View")
!["Grievance Details"](/Screenshots/GrievanceDetails.png "Grievance Details View")
![Grievance List](/Screenshots/GrievanceList.png "Grievance List View")
![Login](/Screenshots/Login.png "Login View")
![New Grievance](/Screenshots/NewGrievance.png "New Grievance View")
![Staff Dashboard](/Screenshots/StaffDashboard.png "Staff Dashboard View")
![Staff](/Screenshots/Staff.png "Staff List View")
![Student](/Screenshots/Student.png "Student Add View")
![User Grievance Details](/Screenshots/UserGrievanceDetails.png "User Grievance Details View")
![User Grievance List](/Screenshots/UserGrievanceList.png "User Grievance List View")


