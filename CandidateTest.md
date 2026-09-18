# Candidate Test

This solution contains three projects:

- Cmf.CandidateTest.Api: This is the main API project that contains the controllers, and other necessary components for the API.
- Cmf.CandidateTest.Data: This project contains the data access layer, including the DbContext and entity configurations.
- Cmf.CandidateTest.Tests: This project contains the unit tests for the API and data projects.

On starting the Api project, it will automatically create a SQLite database file named `CandidateTest.db` in the root directory of the project. The database will be created based on the entity configurations defined in the `Cmf.CandidateTest.Data` project.
The database will be seeded with some initial data for testing purposes.

You can ignore the code in the `Cmf.CandidateTest.Tests.Seeding` namespace.

Although this is normally considered bad practice, you will be hard coding any sql queries in files in the Cmf.CandidateTest.Data.Queries namespace. An example has been included to get you started with the first user story. 

By default, the API will run on `https://localhost:7159` and `http://localhost:5555`. You can use tools like Postman or curl to test the API endpoints.

## User Stories

Routing has not been defined in the user stories, so you are free to define the routing as you see fit. 
You can use the provided entity relationship diagram (EntityRelationships.md) as a reference for querying the database schema.

### Part 1 - API endpoints

Given that I am an API user
When I GET an order by its Id
And the order exists
Then I should receive the order details including the Order Id, Order Date, User Id,

Given that I am an API user
When I POST a valid order
Then the order should be created in the database.
And I should receive a response indicating that the order was created successfully, along with the new Order Id.

Given that I am an API user
When I request a list of users with no orders
Then I should receive a list of users with their Id, Name, and Email
And the list should only include users who have not placed any orders.

## Part 2 - Authentication

Given that I am an API user
When I attempt to access the API without a valid API key
Then I should receive an unauthorized response.

Given that I am an API user
When I attempt to access the API with a valid API key in the X-API-KEY header
Then I should be able to access the API endpoints.

Notes: 
    - Most of the code for this is included in the Cmf.CandidateTest.Api project, in the Authentication folder. 
    - You will need to implement the API key validation logic in the ApiKeyAuthenticationHandler class. 
    - Don't worry about encrypting or hashing the key, as this is not required for this test. The API key is already hardcoded in ApiKeyAuthenticationHandler class.
    - Add the Authorize attribute to the controllers that you want to protect with API key authentication.
    - You will also need to register the authentication handler in the Program.cs file.

## Part 3 - Unit Testing

In the Cmf.CandidateTest.Tests project, you will find a test class named `OrderControllerTests`. This class contains unit tests for the OrderController. You are required to implement the unit tests for the following scenarios:

1. Retrieving an order by its Id when the order exists.
2. Retrieving an order by its Id when the order does not exist.


## General Instructions

Use Dapper as an ORM. An example has been included in the Cmf.CandidateTest.Data.Repository namespace to get you started with the first user story.
You may also find this link useful: https://www.learndapper.com/saving-data/insert

Do:
- use dependency injection to register any services which you might need in the controllers;
- use ANSI SQL for database operations. SQLite does not support all non-ANSI SQL features.
- use the provided entity relationship diagram (EntityRelationshops.md) as a reference for querying the database schema.

Don't:
- worry if you can't complete every task in the allotted time! We are more concerned with your approach and understanding of the concepts.
- be afraid to ask questions if you are unsure about any requirements or constraints. Although we are not able to provide answers to technical questions, we will do our best to clarify any ambiguities in the requirements.
- use copilot or any other AI code generation tools to generate code for this test. The purpose of this test is to evaluate your coding skills, so please write the code yourself.
