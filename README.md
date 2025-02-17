# Developer Evaluation Project

This complete system uses the CQRS architecture and is based on **DDD (Domain-Driven Design)**.
This includes sales, users, customers, branches, and product functionalities.
The application was developed in **.NET 8**. Uses AutoMapper, Mediator, Entity Framework, and FluentValidation technologies. 
For testing, XUnit was used. The databases are running on **Docker**.

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
- **Entity Framework (ORM)**
- **PostgreSQL** (Banco de dados relacional)
- **MongoDB** (Banco de dados NoSQL)
- **Redis** (Banco de dados Cache)
- **Docker** (Containerização)
- **XUnit e NSubstitute** (Testes unitários e mocks)

---

## **Entity Framework Settings**

### Remove previous migrations

   ```
   dotnet ef migrations remove --project "src/Ambev.DeveloperEvaluation.ORM/" --startup-project "src/Ambev.DeveloperEvaluation.WebApi/" --context DefaultContext
   ```

### Add new migrations

   ```
   dotnet ef migrations add NewTablesConfiguration --project "src/Ambev.DeveloperEvaluation.ORM/" --startup-project "src/Ambev.DeveloperEvaluation.WebApi/" --context DefaultContext
   ```

### Update changes in the database

   ```
   dotnet ef database update --project "src/Ambev.DeveloperEvaluation.ORM/" --startup-project "src/Ambev.DeveloperEvaluation.WebApi/" --context DefaultContext
   ```

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
