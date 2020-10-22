# Changes

## Basic Refactorings
- A new DB folder created
- Handler moved to the DB folder
- All DB transactions will take place in the DB Handler class
- ConnectionString moved into Configurations
- Removed static method that can return instances of the same ConString
- No need for bool isNew
- Some changes of consistency of Models

## Extendibility
- Helper classes inheritence from the main Helper
- Using General formats, implementing something like Entity Framework

## SQL Injection Prevention
- Add with parameter for DB queries

## Future
- Making all calls to be async
- Documentation
- Testing

