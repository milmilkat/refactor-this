# Changes

## for Separation of Concern
- A new DB folder created
- Handler moved to the DB folder
- All DB transactions will take place in the DB Handler class
- ConnectionString changed to readonly rather than const
- Removed static method that can return instances of the same ConString
- No need for bool isNew

## Design Pattern
- Helper classes inheritence from the main Helper
- The main helper do not need to be used, it is abstract
- Main helper having the protected Con to be used by the inherited classes

## SQL Injection Prevention
- Add with parameter for DB queries

## Future
- Making all DB calls to be async

