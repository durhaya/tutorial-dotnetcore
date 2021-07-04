Demonstrate Sample APIs in .net 5 (as created in node express sample)
=====================================================================

1. Open VS 2019(recommended) / 2017
2. Create New Project and Search API in project templates
3. Select ASP.Net Core Web API template
4. Select .Net 5 as target framework and authentication type as None.

Study the framework
Chapter 2
---------
Startup.cs
    Comment out the default configurations and open as needed while demonstration
    Add the custom endpoints as in node express app, instead controllers route.
    Test the app, Explore the routes on postman, browser...

Chapter 3
---------
Startup.cs
    Lets try out now the controller way.. Framework way..
    Remove/Comment out the custom endpoints
    Uncomment the section to use the controllers
    Uncomment the swagger section, so that we can see our APIs into swagger
    Demonstrate the middle ware configuration (swagger, endpoints)
        
Controllers
    Questions:
        What is MVC, What is controller?
            MVC is a application framework.. web api is based on MVC
            Controller is basically a class which groups together the endpoints
        IActionResult - Is a generic return type
    Create tickets controller
        Attribute Routing..
        Controller level Routing.. 
            Known as conventional base routing
            This also a type of Attribute Routing.. Controller level attribute routing
        Default Model Validation
    Create projects controller with Route on controller

    Model Binding Type
    https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/parameter-binding-in-aspnet-web-api

Chapter 4
---------
Renaming of the project.. 
    ProjectAPIDemo to ProjectAPI
Model Binding
    Create a folder named Models
        Create a class named Ticket.cs
            Demonstrate complex object model binding
            Model Binding Types - From Body, From Query.. etc..
            	Note: not a good practice to mix binding types
Model Validation
	Validation is not the purpose of end point
	Model validation with data annotations
			Required Attribute, min, max etc
		Its independant from the MVC
		You have to call this validation
		https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.rangeattribute?view=net-5.0
		
	in real world you have to validate model class object as whole with custom validation logic
		Conditional When there is an owner then only Due Date cannot be null.
		For this we have to do custom validation
        
    Extend Validation Attribute for custom validation
        Create a folder ModelValidation
        Create a class - Ticket_EnsureDueDateForTicketOwner
            Inherit from ValidationAttribute and override IsValid
        Assignment:
	        When you have owner then due date must have and it must be in the future
		        The trick here is this validation is valid only for the create.. update may have the past date.

Filter pipeline
	//Authentication
	//Generic Validation
	//Retrieve the input data
	//data validation
	//application logic / manipulating the data
	//format the output data
	//Exception handling

	How filter works
		https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-5.0
		
	Why you need filter pipeline when middle ware is there..
		middleware is global.. you cannot apply middleware on a particular action method
		middleware cannot access the MVC data constructs

Action Filters
    ActionFilterAttribute for Model Validation:
        Question: Difference between ActionFilterAttribute and ValidationAttribute
        Use cases: 
            When you have multiple version of action method and having same model.

        Problem statement: Add ticket enter date while creating the ticket.
        Create a folder named Filters
            Add a class named Ticket_EnsureEnteredDateActionFilter.cs
            Inherit from ActionFilterAttribute and override OnActionExecuting

(Versioning)
Resource Filters
	Perfect place to do some generic validations
		Expired versioning issue
		Demonstrate to add this filter attribute on controller level
		Demonstrate to add this filter attribute globally in startup.cs
		
Assignment:
	Entered Date should be earlier than the due date.


Chapter 5
---------
Few design problems till now...
	1. Models with in the API project..
		Model represents the data/message and web api is the channel to broadcast
		Message residing into the channel is a tight couple.. can only use one channel..
		It should be decouple from the web api to get used from multiple channels
			Web API
			Web Socket
			Any other channels
			Direct to the actor.
	2. Model Validations => using MVC namespace
	3. Filters => using MVC namespace
		Demonstrate move validations into Core model class..

Lets Resolve the Problems:
Handle problem 1:
Create a class Library Project named Core for Models
    Add Folder Models
        Create ticket model or Copy ticket model, resolved errors by deleting the attributes

    Delete Models folder from Project API.
    Correct the references in Project API.

Handle Problem 2 and 3:
    Add methods in Ticket Model class for validations as per business Logic
    Add folder named ValidationAttributes in Core Project.
        Add classes there as per business logic and inherit them from the ValidationAttribute as like we did earlier.
    Delete ModelValidation Folder from ProjectAPI

    Do the same for validations we have in filters