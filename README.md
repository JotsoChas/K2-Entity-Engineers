<h1 align="center">
  <b>K2 Entity Engineers – Course Administration System</b>
</h1>

<p align="center">
  School administration console app built in <b>C# / .NET 8</b> using <b>Entity Framework Core + SQL Server</b>.
</p>

<p align="center">
 <img src="https://img.shields.io/badge/.NET-8.0-blueviolet?style=for-the-badge&logo=dotnet" />
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" />
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" />
</p>

---

## 📌 Project Overview

Course administration console system

K2 Entity Engineers is a SQL Server + Database-First console application for managing students, teachers, courses, classrooms, schedules and grades.
The system is built with C# (.NET 8), EF Core (Database-First), LINQ and a menu-based UI, including reusable input validation and feedback through ConsoleHelper.

The purpose is to simulate a real administration workflow similar to course/education platforms, including registration flows and reporting views.

---

## ⚙️ Technologies

| Component | Technology   |
|-----------|--------------|
| Language  |  C# (.NET 8) |
| ORM	    |  EF Core     |
| Database  |  SQL Server  |
| UI | Console application |
| Version Control | GitHub |

---

## Installation

### Follow these steps to download and run the project locally:

### 1. Choose a Folder
Pick or create a folder where you want to store the project files.


### 2. Open Command Prompt in That Folder
- Click the **address bar** in your File Explorer.
- Type `cmd` and press **Enter**.  
  This opens Command Prompt in the same directory.

### 3. Clone the Repository
Run the following command:

Clone repo:
git clone https://github.com/JotsoChas/K2-Entity-Engineers.git

---

## 🚀 How to Run the Project

Open Visual Studio

Open solution file .sln

Make sure SQL Server is connected (localDB, localhost or your instance)

Run the project with Ctrl + F5 or Start Without Debugging

Console menu will launch, navigate using number keys

---

## Features

### Student Management
- Add student
- Edit student
- Delete student
- List all students
- Student overview report (Joined with courses, grades & teachers)

### Course Management
- Add course
- List all courses
- Show active courses including enrolled students

### Teacher Management
- Add teacher
- Edit teacher
- Delete teacher
- List teachers

### Classroom Management
- Add classroom,
- List classrooms

### Schedule
- Create schedule entry for courses,
- Connect schedule to teacher & classroom

### Grades
- Register grade for student per course,
- Show grade overview,
- Year Report,
- Half-year Report,
- Quarter Report

### Student-Course Enrollment
- Register student to course
- Prevent duplicate course enrollment

---

## Database Model & Design
- The project uses a relational database design tailored for school administration. Below is an overview of the schema:

### Table			Description
- Student			- Stores basic student information (Name, ID).
- Teacher			- Registry of teachers responsible for courses.
- Course			- Represents a subject/course, linked to a specific Teacher and Classroom.
- Classroom	    	- Locations where classes are held.
- Schedule	    	- Time slots connecting a Course to a Classroom and Teacher.
- StudentCourses	- Junction table handling the Many-to-Many relationship between Students and Courses.
- Grades        	- Stores the final grade and date for a specific Student on a specific Course.

---

## 👥 Contributors
<table>
<tr>

<td align="center" width="150">
  <a href="https://github.com/bjorn1911" style="color:black; text-decoration:none;">
    <img src="https://github.com/bjorn1911.png" width="90" style="border-radius:50%;"/><br/>
    <span style="font-size:16px; font-weight:bold; color:black;">Björn</span>
  </a>
</td>

<td align="center" width="150">
  <a href="https://github.com/JotsoChas" style="color:black; text-decoration:none;">
    <img src="https://github.com/JotsoChas.png" width="90" style="border-radius:50%;"/><br/>
    <span style="font-size:16px; font-weight:bold; color:black;">Joco</span>
  </a>
</td>

<td align="center" width="150">
  <a href="https://github.com/RoffeRuff42" style="color:black; text-decoration:none;">
    <img src="https://github.com/RoffeRuff42.png" width="90" style="border-radius:50%;"/><br/>
    <span style="font-size:16px; font-weight:bold; color:black;">Rolf</span>
  </a>
</td>

</tr>
</table>

---
