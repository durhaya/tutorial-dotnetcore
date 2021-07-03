Demonstrate Sample APIs in .net 5 (as created in node express sample)
=====================================================================

1. Open VS 2019(recommended) / 2017
2. Create New Project and Search API in project templates
3. Select ASP.Net Core Web API template
4. Select .Net 5 as target framework and authentication type as None.

Study the framework
Chapter2
--------
Startup.cs
    Comment out the default configurations and open as needed while demonstration
    Add the custom endpoints as in node express app, instead controllers route.
    Test the app, Explore the routes on postman, browser...

Chapter3
--------
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