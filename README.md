# GrpahQL with ASP.NET-6 and EntityFrameworkCore-6

### A simple project to make API request to an ASP.NET app using GraphQL query syntax allowing the users to query only the data they need instead of the whole payload like in conventional REST API's.

### To get started, 
- Clone this repo, then setup the database using `dotnet ef` tool and database provider of your choice (make sure to use the correct `ConnectionString`).
- This project uses a docker container instance of PostgreSQL and you will find `docker-compose.yml` inside the database folder.
- Then build and run the application, and make a `POST` request to enpoint `https://localhost:7016/graphql` with following json payload: -
```
{
  "query": " {
    movies {
      id name
    }
  }",
  "variables": null
}
```
and hopefully everything should work ☺️.

### See these screenshots for reference: -

#### - Simple `GET` request
<div>
  <img src="https://github.com/prateek332/GrpahQL.ASP.NET.EntityFrameworkCore/blob/main/graphql-GET-Request.jpg" width=100% height=70% />
</div>

#### - Simple `POST` request
<div>
  <img src="https://github.com/prateek332/GrpahQL.ASP.NET.EntityFrameworkCore/blob/main/graphql-POST-Request.jpg" width=100% height=70% />
</div>
