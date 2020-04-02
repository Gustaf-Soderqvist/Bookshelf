# Bookshelf


A simple libary

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for developments.

### Installing

A step by step series how to get a development env running


Clone or download the project 
```
https://github.com/Gustaf-Soderqvist/Bookshelf.git
```

Run npm install
```
npm install
```

- Create DB -
```

In Visual Studio, you can use the Package Manager Console to apply pending migrations to the database:

Run "Update-Database"
Alternatively, you can apply pending migrations from a command prompt at your project directory:

> dotnet ef database update


* If you have problem with creating the DB. Change cs in appsettings.json to:
connectionString="Server=(localdb)\mssqllocaldb;Database=Hermes;Trusted_Connection=True;" />
```

- Start the application -
```
dotnet run

https://localhost:5001
SwaggerUi
or
http://localhost:1337 - react
```




## Built With

* .NET Core 3.1 https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-1
* Entity Framework Core https://docs.microsoft.com/en-us/ef/core/
* React 16.8.6
* IoC https://autofac.org/
* Mapping https://automapper.org/
* Clean Architecture https://fullstackmark.com/post/18/building-aspnet-core-web-apis-with-clean-architecture?fbclid=IwAR3arYeTPwlwnzhmwgtbcA83XN1YuTCrKN6jqBuBXqIVO3DE255VIMnnJ-4
* React authentication 
https://jasonwatmore.com/post/2018/09/11/react-basic-http-authentication-tutorial-example


## Authors

* **Gustaf Söderqvist** - *Software developer* - https://github.com/Gustaf-Soderqvist

