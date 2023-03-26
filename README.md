# LibraryAPI

ASP.NET Core WebAPI with Clean Arcitecture, JWT Auth, CQRS.
This project includes CRUD operations with books.
## Features
- Create book
- Update book
- Delete book
- Get by Id or ISBN
Operations Create, Update, Delete require authentication. You can registrate a new User and then login to application, or you can sign in by default credentials: 

email: test@test.com
password: Qwerty1234!
## Installation

1. Clone the repository
2. Provide your own connection to database in appsettings.json
3. In Package Manager Console choose Infrastructe project and write:
```sh
add-migration InitialMigration
update-database
```
