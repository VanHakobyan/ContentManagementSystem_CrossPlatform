<p align="center"><img src="https://github.com/VanHakobyan/CustomerManagementSystem_CrossPlatform/blob/master/content-manage-system.png?raw=true"></p>

<br>
<h3><p align="center">CMS (Content Management System)</p></h3>


A content management system (CMS) is a software application or set of related programs that are used to create and manage digital content. CMSes are typically used for enterprise content management (ECM) and web content management (WCM). An ECM facilitates collaboration in the workplace by integrating document management, digital asset management and records retention functionalities, and providing end users with role-based access to the organization's digital assets. A WCM facilitates collaborative authoring for websites. ECM software often includes a WCM publishing functionality, but ECM webpages typically remain behind the organization's firewall.

<h3><p align="center">ASP.NET Core Overview</p></h3>

ASP.NET Core is the new web framework from Microsoft. It has been redesigned from the ground up to be fast, flexible, modern, and work across different platforms. Moving forward, ASP.NET Core is the framework that can be used for web development with .NET. If you have any experience with MVC or Web API over the last few years, you will notice some familiar features. At the end this tutorial, you will have everything you need to start using ASP.NET Core and write an application that can create, edit, and view data from a database.


<h3><p align="center">What is ASP.NET Core</p></h3>

ASP.NET Core is an open source and cloud-optimized web framework for developing modern web applications that can be developed and run on Windows, Linux and the Mac. It includes the MVC framework, which now combines the features of MVC and Web API into a single web programming framework.

* ASP.NET Core apps can run on .NET Core or on the full .NET Framework.
* It was architected to provide an optimized development framework for apps that are deployed to the cloud or run on-premises.
* It consists of modular components with minimal overhead, so you retain flexibility while constructing your solutions.
* You can develop and run your ASP.NET Core apps cross-platform on Windows, Mac and Linux.

<h3><po align= "center">ASP.NET Core - Middleware</p></h3>

In this chapter, we will understand how to set up middleware. Middleware in ASP.NET Core controls how our application responds to HTTP requests. It can also control how our application looks when there is an error, and it is a key piece in how we authenticate and authorize a user to perform specific actions.

Middleware are software components that are assembled into an application pipeline to handle requests and responses.

Each component chooses whether to pass the request on to the next component in the pipeline, and can perform certain actions before and after the next component is invoked in the pipeline.

Request delegates are used to build the request pipeline. The request delegates handle each HTTP request.

Each piece of middleware in ASP.NET Core is an object, and each piece has a very specific, focused, and limited role.

Ultimately, we need many pieces of middleware for an application to behave appropriately.

Let us now assume that we want to log information about every request into our application.

In that case, the first piece of middleware that we might install into the application is a logging component.

This logger can see everything about the incoming request, but chances are a logger is simply going to record some information and then pass along this request to the next piece of middleware.

#### Middleware

Middleware is a series of components present in this processing pipeline.

The next piece of middleware that we've installed into the application is an authorizer.

An authorizer might be looking for specific cookie or access tokens in the HTTP headers.

If the authorizer finds a token, it allows the request to proceed. If not, perhaps the authorizer itself will respond to the request with an HTTP error code or redirect code to send the user to a login page.

But, otherwise, the authorizer will pass the request to the next piece of middleware which is a router.

A router looks at the URL and determines your next step of action.

The router looks over the application for something to respond to and if the router doesn't find anything to respond to, the router itself might return a 404 Not Found error.
