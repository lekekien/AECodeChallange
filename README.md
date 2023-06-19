# Requirements
The goal of this challenge is to build a solution comprised of REST APIs that finds the closest port to a given ship and calculates the estimated arrival time based on velocity and geolocation (longitude and latitude) of given ship

# Technologies
- .NET 6.0
- CQRS Pattern (MediatR package)
- Posgres SQL (Entity Framework package)
- Swagger
- Nunit testing

# Initial
1. Clone project from GitHub
2. Build solution
3. Update Connection String in application.json

```
"ConnectionStrings": {
    "AppConnection": "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=AECodeChallange;Pooling=true;Integrated Security=true;"
  },
```
4. Run migration
    - Open Package Manager Console in VS2022
    - Change Default Project to "AE.Data"
    - run script ```Update-Database```
5. Run project. When swagger UI show up , all api is ready
