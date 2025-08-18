🚚 eShift Household Goods Transport System

A desktop-based transport management system built with C# WinForms and SQL Server, following a layered architecture.
The system helps manage customers, employees, transport units (lorries, containers), job assignments, loads, reporting, and payments efficiently.

✨ Features

User Authentication & Roles

Separate logins for Admins, Employees, and Customers.

Role-based dashboards for secure access.

Customer Management

Registration, updating, and deleting customer details.

Viewing history of jobs and payments.

Job & Load Management

Create and update transport jobs.

Assign loads to transport units (lorries/containers).

Track job status (Pending, In Progress, Completed, Cancelled).

Transport Unit Management

Manage lorries, drivers, assistants, and containers.

Assign units dynamically to loads.

Email Notifications

Customers receive job confirmation and status updates via SMTP/MailKit.

Reports & Analytics

Generate PDF/Excel reports (Customers, Employees, Payments, Lorry Utilization).

Export and print with iTextSharp and ClosedXML.

Error Handling & Logging

Try–catch exception handling with user-friendly messages.

Logging of system errors for debugging.

🛠️ Software Requirements
Category	Requirement
OS	Windows 10 / 11
Framework	.NET Framework 4.7.2 or later
IDE	Visual Studio 2019+
Database	SQL Server 2016+
Libraries	iTextSharp, ClosedXML, MailKit, System.Data.SqlClient
🗄️ Database Setup

Install SQL Server and SQL Server Management Studio (SSMS).

Create a database named:

CREATE DATABASE eShiftDB;


Run the provided SQL scripts (/Database/eShiftDB.sql) to create tables:

Customers

Employees

Jobs

JobItems

Loads

Lorries

Containers

Payments

Update the connection string in App.config:

<connectionStrings>
    <add name="eShiftDB"
         connectionString="Data Source=YOUR_SERVER;Initial Catalog=eShiftDB;Integrated Security=True;" 
         providerName="System.Data.SqlClient" />
</connectionStrings>

🚀 Installation & Running

Clone this repository:

git clone https://github.com/your-username/eShift_Householdgoods_Transport_System.git


Open the project in Visual Studio.

Restore dependencies and build the solution.

Run the project (F5) – the Login Form will appear.

🔮 Future Improvements

Role-Based Access Control (RBAC) with advanced permissions.

Real-time notifications using SignalR.

Web and Mobile versions with ASP.NET Core MVC / Blazor / MAUI.

Advanced charts and dashboards using LiveCharts.

Audit Logging for all operations.

Cloud deployment on Azure/AWS.

Integrated Payment Gateway (Stripe/PayPal) for online transactions.

👨‍💻 Author

Developed by Chathu Liyanage