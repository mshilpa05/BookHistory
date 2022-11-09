# BookHistory

Book history is a solution you can use to manage book entity.

When you run the solution, you can see the swagger page. You can do CURD operations on Book entity. The updates you do this entity is audited using the change tracker. You can view audit logs which are:
* paginated
* filtered w.r.t publish date
* ordered w.r.t date of the record in ascending
* count of actions on each book entity (grouping)

## Technologies used

* ASP.NET Core Web api
* Entity Framework Core 
* SQLLite

### Patterns used
* Repository pattern
* Unit of work pattern

