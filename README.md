# Internship assignment

The task is to to create a class that can be represented as any type of vessel. To achieve this you need to create a base class that represents a *vessel*. The vessel class should be made so that we can use it to define different types of vessels in our fleet.

This assignment should be done on the .NET platform, preferably in C# and .NET Core.

## Precode

Our fleet will consist of these types of vessels:

```Typescript
class Ferry : Vessel { .. }
class Tugboat : Vessel { .. }
class Submarine : Vessel { .. }
```

To get you started you can use this base class as an insipration:

```Typescript
class Vessel {
    private string name;
    private string yearBuilt;

    public Vessel(string Name, string Year);

    public string GetName();
    public string GetYearBuilt();

    public override string ToString() {
        return $"Vessel: {name}";
    }
}
```

## Task 1 - Questions

__Q1:__ What is the purpose of the private fields `name` and `yearBuilt` having methods for getting their values?

__Q2:__ What is the concept behind overriding the `ToString()` method called?

## Task 2 - Programming

The `Vessel` class _constructor_ should be responsible for setting the ships name and year built. Since our fleet manager does not like old vessels, so you will have to throw a `OldShipException` exception when somone creates a vessel with the age over 20 years (tip: she does not like the name NULL either).

The vessels should have these characteristics to them:

* The `Ferry` class should have an additional public property: passengers.
* The `Tugboat` class should have an additional private field: max force.
* The `Submarine` class should also have an additional private field: max depth.

The `GetVesselInfo()` method should print the type of vessel and its name, year built and its additional field/property. This will be what our fleet manager looks at when scrolling through all vessels in the fleet.

## Task 3 - Programming

Our fleet manager wanted to know what is the max speed of the various vessels too (we don't really know why..), so we need to create a new class for representing the speed of each vessel.

Create a class called `Speed` class implementing the `IFormattable` interface. Since our fleet manager doesn't like the nautical representation "knots" the class should support the format specifiers: "MS" and "KN" which will convert the speed to either knots or m/s (the default should be knots to not confuse mariners). 

Also remember to add this to the `Vessel` class.

## Verifying your solution

You should demonstrate that the classes work as intended in a program thas has a collection of vessels (remember to create various types of vessels within the collection) by iterating over the collection and calling each objects `ToString()` method.

You should also add relevant unit tests to the project, by for example using [xUnit](https://xunit.github.io/docs/getting-started-dotnet-core).
# internship_dualog
