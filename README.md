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
    - run script ```Update-Database``` for migrate to database and import the sample data
5. Run project. When swagger UI show up , all api is ready

# Introduction
Main project have 5 sub-project inside
- AE.Api : handle all request from outside by router mapping and send request parameters to exactly handler defined
- AE.Application : process all bussiness of this project . Have many handler for handle request from API layer. Get data from Data layer and work arround on it
- AE.Data : Contain All enitity mapping with table in database.
- AE Common : Contain some funtion can re-use many time when develope
- AE.UnitTesting : Use Mock data to test funtion in project . Use NUnit to implement

#Demo
- Swagger
![image](https://github.com/lekekien/AECodeChallange/assets/40720438/7f01435c-2e9a-47fa-a85e-39fe99989e7a)
-Response from API

![image](https://github.com/lekekien/AECodeChallange/assets/40720438/b1f8775f-945a-4f7c-af90-4d45ca1a7208)


![image](https://github.com/lekekien/AECodeChallange/assets/40720438/50f94119-91b5-40e6-a650-f38136530970)


![image](https://github.com/lekekien/AECodeChallange/assets/40720438/3087db64-ba95-417f-a2c9-11800d66362b)
