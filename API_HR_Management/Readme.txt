
*************** How To use ******************
 run the app in mode Container DockerFile using  / visual stdio 2022 ( .net 8)  

 if it didnt work : 

 run build manually : 

open folder path where docker-compose files are located and run :

docker compose up --build 


***/in succes 
u should see some fake data : 

{
        "id": {
            "value": "najlae123@gmail.com"
        },
        "firstName": "NajjlaeIdrissi",
        "lastName": "Sis",
        "phoneNumber": {
            "value": "0102030101"
        },
        "callTimeInterval": null,
        "linkedInUrl": "https://www.linkedin.com/in/NajlaeZin",
        "gitHubUrl": "https://github.com/najlae123",
        "comments": "This candidate has excellent communication skills and a strong background in software engineering."
    },
    {
        "id": {
            "value": "jane.doe@example.com"
        },
        "firstName": "Jane",
        "lastName": "Doe",
        "phoneNumber": null,
        "callTimeInterval": null,
        "linkedInUrl": "https://www.linkedin.com/in/janedoe",
        "gitHubUrl": "https://github.com/janedoe",
        "comments": "Another comment"
    },
    {
        "id": {
            "value": "john.doe@example.com"
        },
        "firstName": "John",
        "lastName": "Doe",
        "phoneNumber": null,
        "callTimeInterval": null,
        "linkedInUrl": "https://www.linkedin.com/in/johndoe",
        "gitHubUrl": "https://github.com/johndoe",
        "comments": "Sample comment"
    }



**********************************************

to check if the app is working  ( I prefer postman )

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
