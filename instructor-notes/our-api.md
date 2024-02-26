# Issue Tracker API

The Company is "Hypertheory, Inc"

Supported list of software.

For that supported list of software, *employees* can issue a support request.

These support requests will be routed to the appropriate desktop support person for follow-up. (More on that in Microservices class, but we'll touch on it)

What they need:

- They need the ID of the employee making the request
- They need the software the issue is with, along with the version (the desktop support people maintain this list in their API.)
- They need a brief description of the issue (Maximum 1024 characters)
- When the issue was filed (Date and Time)



## Three Vectors of API Design

- The Resource
    - "An important thingy we want to expose to our users"
- The Method
    - GET - I would like the current representation of this resource.
    - POST - 
    - PUT
    - DELETE
    - HEAD
    - others that you should be suspect of using.
- The Representation

```http
POST /issues
Content-Type: application/json
Authorization: "something here that identified the user"

{

    "description": "Done broke",
    "software": "Excel",
    "softwareversion": "95",
   
}
```


```http
200 Ok
Content-Type: application/json

{
    "id": "839839839guid",
    "description": "Done Broke",
    "software": "Excel",
    "status": "Pending"
}

```