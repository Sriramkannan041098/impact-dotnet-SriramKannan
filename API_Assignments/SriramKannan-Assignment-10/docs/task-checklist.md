# Task checklist

- [ ] 10.1 Split into Identity, Academics, Reporting projects with separate databases; confirm each starts independently.
- [ ] 10.2 Implement ADO.NET stored-procedure access, PBKDF2 password hashing, JWT issuance, register/login tests.
- [ ] 10.3 Add Student/Course/Teacher CRUD, seed data, migration, Teacher-only writes, Student read-only policy.
- [ ] 10.4 Create ReportingDb schema in SSMS, scaffold EF DB First entities, add read-only report endpoint.
- [ ] 10.5 Configure YARP routes, JWT validation, role claim handling, and ensure React uses gateway only.
- [ ] 10.6 Add Dockerfiles and Compose health/dependency checks; test full stack.
- [ ] 10.7 Add xUnit tests per service and Selenium E2E tests; enforce >=80% coverage in CI.
- [ ] 10.8 Demo register -> login -> teacher CRUD -> student read-only -> report -> logout.
- [ ] 10.9 Commit architecture decision note.
- [ ] 10.10 Stop Reporting and verify other portal routes remain usable.
