
*************** How To use ******************

open folder path where docker-compose files exists and run :

docker compose up --build 

then run the app using visual stdio 2022 ( .net 8)

**********************************************

to check if the app is working 

test with postman this endpoint to get some fake Data that i insert with hasData of ef :
Get : api/candiate

Post : update or create 

Post : api/candiate/upsrt 

*************************************************


This project focuses on managing candidates for Human Resources
(HR) using Domain-Driven Design (DDD), Command Query Responsibility
Segregation (CQRS), and Clean Architecture principles
(Domain -> Application -> Infrastructure-> API presentation ). 
I emphasize best practices to ensure a robust and maintainable system.

Key Features:
CQRS Implementation: Utilizing MediatR for handling commands and queries, 
FluentValidation for validating data,
and Mapster for object mapping, 
I separate read and write operations to enhance performance and scalability.

Entity Framework Core: Employing a Code-First approach, i leverage Entity Framework Core for database management,
including automatic migrations and entity configurations following DDD principles.

Database and Containerization: For simplicity, SQLite is used as the database solution, 
allowing for easy setup and testing. 

Technologies and Practices:
MediatR: Facilitates decoupled communication between various parts of the application.
FluentValidation: Ensures data integrity by validating commands and queries before processing.
Mapster: Provides efficient and easy-to-maintain object-to-object mapping.
Entity Framework Core: Manages database interactions through a Code-First approach and supports migrations.
SQLite: A lightweight database solution for simplicity in development and testing.
Containerization: Docker Ensures the application can be easily deployed 
and run in various environments without configuration issues.
