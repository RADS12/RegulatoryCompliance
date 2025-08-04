**Project Overview**
I developed this project using Object-Oriented Programming (OOP), SOLID principles, key design patterns, multithread-safe operations, and a robust caching mechanism.

-------

**Object-Oriented Principles:**
**Inheritance / Polymorphism:** Implemented through base and derived input classes.

**Encapsulation:** Data and logic are contained within dedicated classes.

**Polymorphism:** Each rule encapsulates distinct logic and behavior.

**Abstract:** Simplified complex systems by exposing only essential features and hiding internal implementation details.

**Configuration Management:** Uses POCO classes and dependency injection to load settings from appsettings.json, supporting microservice-ready configurations.

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

**Facade Pattern:** Simplifies execution of various regulatory compliance rules.

**Dependency Injection:** Injects configuration and services, promoting testability and maintainability.

-------

**Additional Features**
**Caching:** Enhances application performance by reducing redundant operations.

**SemaphoreSlim:** Ensures thread-safe operations and manages concurrent access for multithreading.

--------
