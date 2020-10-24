# Changes

## Basic Refactorings
- ConnectionString moved into Configurations
- Removed static method that can return instances of the same ConString
- No need for bool isNew
- Some changes of consistency of Models

## Extendibility with ORM
- Using Entity Framework

## SQL Injection Prevention
- Add with parameter for DB queries with has been covered with EF, removed dangerous ADO.Net lines

## Future
- Further extendibility consideration especially for Transactions
- Documentation
- Testing

