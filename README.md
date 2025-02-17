# Developer Evaluation Project

This complete system uses the CQRS architecture and is based on **DDD (Domain-Driven Design)**.
This includes sales, users, customers, branches, and product functionalities.
The application was developed in **.NET 8**. Uses AutoMapper, Mediator, and FluentValidation technologies. For testing, XUnit was used. The databases running on **Docker**.

## **Summary**

- [Main Resources](#main-resources)
- [Stacks](#stacks)
- [Run tests](#run-tests)


---

## **Main Resources**

- **Sales:** Allows management of sales and its items.
- **Users:** Management users of the system.

---

## **Stacks**

- **.NET 8**
- **FluentValidation** (Validações)
- **AutoMapper** (Mapeamento de Objetos)
- **MediatR** (Mediator)
- **XUnit e NSubstitute** (Testes unitários e mocks)
- **PostgreSQL** (Banco de dados relacional)
- **MongoDB** (Banco de dados NoSQL)
- **Redis** (Banco de dados Cache)
- **Docker** (Containerização)
---

## **Run Tests**

### Unit Tests

   ```
   dotnet test Ambev.DeveloperEvaluation.Unit
   ```

### Integration Tests

   ```
   dotnet test Ambev.DeveloperEvaluation.Integration
   ```

### Functional tests

   ```
   dotnet test Ambev.DeveloperEvaluation.Functional
   ```
