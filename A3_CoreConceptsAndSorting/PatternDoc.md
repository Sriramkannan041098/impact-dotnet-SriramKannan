# Design Patterns Reference
This document maps the design patterns learned in Phase 3
to where they will be used in future application development.

---

## 1. Singleton

### Where it appears
Task 3.4 - Thread-Safe Logger

### Future usage
Can be used for application-wide services that require
a single shared instance.

### Example
Logger, configuration manager, or shared application service.

---

## 2. Factory

### Where it appears
Task 3.5 - Vehicle Factory

### Future usage
Used in service/object creation when the exact implementation
needs to be selected based on runtime information.

### Example
Creating different payment, notification, or service implementations.

---

## 3. Observer

### Where it appears
Task 3.6 - StockTicker

### Future usage
Used when multiple components need to react to an event
or state change.

### Example
C# events, notification systems, UI updates, and messaging.

---

## 4. Strategy

### Where it appears
Task 3.7 - Payment Strategy

### Future usage
Used when an application has multiple interchangeable
algorithms or behaviours.

### Example
Payment methods, discount calculations, or authentication strategies.

---

## 5. Repository

### Where it appears
Task 3.8 - StudentRepository / CourseRepository

### Future usage
Used in the data access layer to separate database operations
from business logic.

### Example
EF Core repositories for Student, Course, Employee, and Order.

---

## 6. Unit of Work

### Where it appears
Task 3.8 - UnitOfWork

### Future usage
Used to coordinate changes across multiple repositories
and commit them as a unit.

### Example
Saving Student and Course changes together in a database transaction.

---

## 7. Adapter

### Where it appears
Task 3.9 - XmlReportAdapter

### Future usage
Used when integrating an existing third-party component
whose interface does not match the application's interface.

### Example
Converting JSON data into XML for a legacy reporting system.

---

## 8. Facade

### Where it appears
Task 3.9 - OrderFacade

### Future usage
Used in service/application layers to provide a simple entry
point over multiple complex subsystems.

### Example
PlaceOrder() coordinating inventory, payment, and shipping.

---

## 9. Builder

### Where it appears
Task 3.9 - Pattern Notes

### Future usage
Useful for creating complex objects with many optional properties.

### Example
Building complex request objects or configuration objects.

---

## 10. Prototype

### Where it appears
Task 3.9 - Pattern Notes

### Future usage
Useful when objects need to be copied from an existing template.

### Example
Cloning document or report templates.

---

## 11. Decorator

### Where it appears
Task 3.9 - Pattern Notes

### Future usage
Used to add behaviour to existing services without modifying
their original implementation.

### Example
Adding logging, caching, or authorization to a service.

---

## 12. Command

### Where it appears
Task 3.9 - Pattern Notes

### Future usage
Used to represent actions as objects that can be queued,
stored, logged, or undone.

### Example
Background jobs, undo/redo, and command processing.

---

## 13. Template Method

### Where it appears
Task 3.9 - Pattern Notes

### Future usage
Used when multiple implementations follow the same overall
algorithm but customize individual steps.

### Example
Common file-processing or report-generation workflows.

---

## 14. Mediator

### Where it appears
Task 3.9 - Pattern Notes

### Future usage
Used to reduce direct communication between multiple components.

### Example
Application mediator or chat communication system.

---

## 15. Chain of Responsibility

### Where it appears
Task 3.9 - Pattern Notes

### Future usage
Used when a request needs to pass through multiple processing steps.

### Example
ASP.NET Core middleware pipeline.

---

## 16. State

### Where it appears
Task 3.9 - Pattern Notes

### Future usage
Used when an object's behaviour changes based on its current state.

### Example
Order states: Pending → Paid → Shipped → Delivered.

---

# Pattern → Future Application Mapping

| Pattern | Future Layer / Usage |
|---|---|
| Singleton | Shared application services |
| Factory | Service/Object creation |
| Observer | Events and notifications |
| Strategy | Runtime behaviour choices |
| Repository | Data access layer |
| Unit of Work | Database transaction coordination |
| Adapter | Third-party/legacy integration |
| Facade | Application/service layer |
| Builder | Complex object creation |
| Prototype | Object cloning/templates |
| Decorator | Dynamic service behaviour |
| Command | Commands/background operations |
| Template Method | Common processing workflows |
| Mediator | Component communication |
| Chain of Responsibility | Request/middleware pipeline |
| State | State-dependent business behaviour |