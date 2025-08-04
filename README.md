**Project Overview:**

I developed this project using 
- Object-Oriented Programming (OOP)
- SOLID principles
- Key design patterns
- Multithread-safe operations
- Robust caching mechanism

-------

**Object-Oriented Principles:**

**Inheritance / Polymorphism:** Implemented through base and derived input classes.

**Encapsulation:** Data and logic are contained within dedicated classes.

**Polymorphism:** Each rule encapsulates distinct logic and behavior.

**Abstraction:** Simplified complex systems by exposing only essential features and hiding internal implementation details.

-------

**SOLID Principles:**

**Single Responsibility:** Each class serves a single purpose (e.g., test input, configuration, test logic). Each rule is self-contained.

**Open/Closed:** New regulatory tests and rules can be added without modifying existing code, enhancing extensibility.

**Liskov Substitution:** Derived test input classes are substitutable for their base types.

**Interface Segregation:** Separate interfaces are used for configuration and composite tests, reducing unnecessary dependencies.

**Dependency Inversion:** High-level modules depend on abstractions, not concretions. The engine and services rely on interfaces.

-----------

**Design Patterns:**

**Strategy Pattern:** Regulatory rules are implemented as strategies, selected dynamically at runtime.

**Repository Pattern:** Abstracts database operations, improving data access flexibility.

**Composite Pattern:** State regulatory Rule can contain several sub-tests

**Facade Pattern:** Simplifies execution of various regulatory compliance rules.

**Dependency Injection:** Injects configuration and services, promoting testability and maintainability.

**Future Additions:** Factory Pattern, Chain of Responsibility Pattern, Observer Pattern, Adapter Pattern, etc.

-------

**Additional Features**

**Configuration Management:** Uses POCO classes and dependency injection to load settings from appsettings.json, supporting microservice-ready configurations.

**Caching:** Enhances application performance by reducing redundant operations.

**SemaphoreSlim:** Ensures thread-safe operations and manages concurrent access for multithreading.

**Dapper:** Automatically map query results to objects, reducing boilerplate code, improving productivity, and offering significantly faster data access compared to manual ADO.NET operations.

--------
