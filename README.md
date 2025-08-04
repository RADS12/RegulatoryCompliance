I created  this project to show my understanding about OOPs, Solid, Design pattern etc.
--

**SOLID Principal:**
- S (Single Responsibility): Each class has one responsibility (test input, config, test logic, etc.)
- O (Open/Closed): New regulatory tests can be added without modifying existing code.
- L (Liskov): Derived test input classes can be used wherever the base is expected.
- I (Interface Segregation): Separate interfaces for configuration and composite tests.
- D (Dependency Inversion): Services depend on abstractions, not concretions.

**Object Orineted Principles:**
- Inheritance/Polymorphism: Used for base/derived input classes.
- Encapsulation: Data and logic are kept within classes.
- Polymorphism: Each rule can have different logic.

**Design Pattern:**
- Strategy Pattern: The rules act as strategies, selected at runtime.
- Facade: To run different regulatory complaince rules
- Dependcy Injection: Read appsettings configuaration.

**Other Benefits:**
- Configuration from appsettings.json: Via POCO and DI, enabling microservice-friendly config.
