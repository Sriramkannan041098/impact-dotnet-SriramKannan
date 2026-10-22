# Architecture decisions

## Identity — ADO.NET
Identity uses parameterized SQL and stored procedures so the authentication persistence path is explicit and predictable. PBKDF2 stores a salted password hash, never the original password. ADO.NET does not inherently make a service more secure than an ORM; input validation, parameterization, secret handling, and operational controls are what matter.

## Academics — EF Core Code First
The team owns the academic domain and expects it to evolve. Entities and migrations describe schema changes, while relationships and seed data are maintained in code.

## Reporting — EF Core DB First
The reporting database is treated as pre-existing and authoritative. Scaffolded models map that schema; the service should not use migrations to take ownership of a database managed by another team.

## Real-world note
A real product would usually standardize on one persistence approach where it makes sense. Different approaches here are an intentional learning exercise, not a claim that three ORM strategies are inherently better.
