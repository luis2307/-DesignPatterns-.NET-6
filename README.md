# DesignPatterns-.NET-6 - Clean 

Design patterns are a set of reusable solutions to common software development problems. They provide a way to structure code in a way that is easy to understand, maintain, and extend. In this article, we will take a look at some of the most popular design patterns used in .NET 6, specifically Dependency Injection, Repository, Singleton, and Unit of Work patterns.

In this base project you will find the following Design Patterns.

If you like you can contribute :D
 

##Dependency Injection

Dependency injection is a design pattern that allows you to remove the hard-coded dependencies between classes and replace them with a flexible mechanism for supplying those dependencies. This allows for more loosely coupled code and makes it easier to test and maintain.
.NET Core provides a built-in dependency injection container, but you can also use third-party libraries like Autofac, Ninject, and Castle Windsor.

##Repository
The repository pattern is a design pattern that abstracts the data access layer of an application. It provides a way to separate the logic for retrieving and manipulating data from the business logic. This allows you to change the data source (e.g. from a database to a web service) without having to change the business logic.

For example, to implement the repository pattern with Entity Framework, you could create an interface IPetRepository and a concrete class PetRepository that implements the interface. The PetRepository class would use Entity Framework to interact with the database

##Singleton

The singleton pattern is a design pattern that ensures that a class has only one instance throughout the lifetime of an application. This is useful for resources that need to be shared across multiple parts of the application.
A singleton is implemented as a class with a private constructor, a static field to hold its single instance, and a static method that returns the instance.

For example:

```    
  public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();

        // private constructor
        private Singleton() { }

        public static Singleton Instance
        {
            get { return _instance; }
        }
    }
 ```
##Unit of Work
The Unit of Work pattern is a design pattern that groups multiple operations that belong to a single transaction. This allows you to perform several operations as a single unit and either commit or rollback all the changes together.

For example, to implement the Unit of Work pattern with Entity Framework, you could create an interface IUnitOfWork and a concrete class UnitOfWork that implements the interface. The UnitOfWork class would use the DbContext of Entity Framework to start, commit or rollback a transaction.

##Conclusion
Design patterns are an essential part of software development and can help you to write more maintainable and scalable code. Understanding these patterns and how to implement them in .NET 6 can help you to create applications that are easier to understand, test, and maintain.


