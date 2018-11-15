# ParkShark_Team_Shark
[![Build Status](https://dev.azure.com/ParkShark/Shark2/_apis/build/status/malfaitbart.ParkShark_Team_Shark)](https://dev.azure.com/ParkShark/Shark2/_build/latest?definitionId=1)

# ParkShark

![ParkShark logo](parkshark.png)

ParkShark is a totally legit pay-to-use parking lot company.
Their goal is to take over the (underground) world of parking lots. They first tried to accomplish this by using violence.
However, they figured a mobile app that automates their processes might also get the job done.
As a bonus, that solution will involve less killing. This mobile-app will be used by both ParkShark customers 
and ParkShark administrators.

The front-end of ParkShark will be created by a freelancer who they'll never pay (that's what the *free* in freelancer stands for after all).

The front-end (mobile app) of ParkShark will communicate with the back-end of ParkShark using an HTTP(S) implementation of REST 
using JSON as its message format. This back-end will contain the entire domain and all the business logic.
It's your job to implement this back-end.

## Technical requirements for .NET

- Create a new GitHub repository (one per team)
- Use REST (with JSON as the message / body format)
- Use ASP.NET Core WebApi
- Use Entity Framework Core
- Use Azure DevOps Build pipeline for continuous integration
    - We'll help you with this
- Perform logging (use logging provided by .NET Core) 
    - Certainly log all interactions with the application that can be defined as "errors" - E.g.: unauthorized access, illegal arguments, exceptions in general,...
    - Also log all database queries done via EF Core
- Use Swagger to provide a readable document of your WebApi
- Use MS Sql Server for a database
- Don't bother writing EF Core migrations, you can compose you database schema migrations in T-SQL
    - Do make sure to include your T-SQL changes in a Scripts folder in the GitHub Repo, so that we can inspect the migrations done to the DB
- Setup a transaction per HTTP call (we can help you with this)
- You don't have to bother about securing your endpoints (unless told otherwise): in other words, you can neglect the fact that certain endpoints
should only be usable by - for example - an administrator.

## Timing

We've created two categories of stories: Must-Have's and Nice-To-Have's. 
Focus on the Must-Have's, when they're fully implemented you can go to the Nice-To-Have's.
    
## Functional Stories

The functional requirements are written down as stories.

- The functional analyst will be available to answer all your questions (he'll speak for the customer ParkShark)
- The functional analyst made some design decisions, if you want to challenge those, you always can. Come prepared though. :grin:

### Story DI1: Create a Division
**As an Administrator I want to create a division.**
> ParkShark became the company it is by doing takeovers of competing companies. 
These companies were never fully merged with ParkShark, they became divisions.
- A division has a name, an original name (the original name of the bought company) and a director
- Prioritization: Must-Have

### Story DI2: Get all Divisions
**As an Administrator I want to get an overview of all divisions.**
- Prioritization: Must-Have

### Story DI3: Get a Division
**As an Administrator I want to get a single, specified, division.**
- Prioritization: Nice-To-Have

### Story DI4: Create a Subdivision
**As an Administrator I want to create a division that is a subdivision of an already existing division**
> Sometimes, a company that was bought by ParkShark, bought some companies itself. We want to be able to express that in our application by creating subdivisions.
- A subdivision is the same as a division, it simply has another division that functions as its parent.
- Prioritization: Must-Have
    
### Story PL1: Create a Parking lot
**As an Administrator I want to create a parking lot.**
- A parking lot has a name, a division, a building type, a capacity, a contact person and an address
- A parking lot also has a price per hour for car allocation (parking your car)
- The contact person has a name, a mobile phone number, a telephone number, an e-mail and an address
    - As a means of contact: 
        - A contact person should always have a (valid) e-mail address.
        - A contact person should always have a mobile phone number or a telephone number. Both are allowed, but at least one is always required!
- The address consists of a street name, street number and a postal code
    - A postal code consist of an actual postal code and a label (e.g. *3000, Leuven*)
- A building type is currently limited to either *underground* or *above ground*. However, there can be more in the future.
- Prioritization: Must-Have

### Story PL2: Get all Parking lots
**As an Administrator I want to get an overview of all parking lots.**
- Prioritization: Must-Have

### Story PL3: Get a Parking lot
**As an Administrator I want to get a single, specified, parking lot.**
- Prioritization: Nice-To-Have

### Story ME1: Register as a Member
**As a Person I want to register myself as a Member so that I can park my car in a parking lot of ParkShark.**
> In order to use the ParkShark parking lots, a person needs to become a member first.
- A member has personal information (name, address, contact information,...), a license plate (license plate number and issuing country) and a registration date.
- Prioritization: Must-Have

### Story ME2: get all Members
**As an Administrator I want to get an overview of all Members**
- Prioritization: Must-Have

### Story ME3: get a Member
**As an Administrator I want to get a single, identified, Member**
- Prioritization: Nice-To-Have

### Story ML1: Select a Membership level
**As a Member I want to select a Membership level.**
> By selecting a certain membership level, a member will gain certain advantages.
- In total, there are 3 membership levels: **bronze**, **silver** and **gold**.
- All membership levels come with a same set of options, however, their values differ:
    - Bronze
        - Monthly cost: €0
        - Parking spot allocation reduction: 0%
        - Maximum allowed allocation-time of parking spot: 4 hours
    - Silver
        - Monthly cost: €10
        - Parking spot allocation price-per-hour reduction: 20%
        - Maximum allowed allocation-time of parking spot: 6 hours
    - Gold
        - Monthly cost: €40
        - Parking spot allocation price-per-hour reduction: 30%
        - Maximum allowed allocation-time of parking spot: 24 hours 
- Extend the Member registration so that upon registering a member we can choose to provide a membership level. However,
it should still be possible to not provide one. In that case, we'll automatically set the membership level to **bronze.**
- It might be possible extra options or entire membership levels are introduced in the future. Those changes don't have to happen dynamically. 
It's okay if they only take affect after a new deploy to production.
- Prioritization: Must-Have

### Story PSA1: Start Allocating a Parking spot
**As a Member I want to start allocating a Parking spot so that I can enter the parking lot and park my car.**
> Parking spot allocation is the term they use at ParkShark to indicate that a 
member is in front of a parking lot which he want to enter so he can park his car. The member can use the mobile app to indicate
he wants to enter the parking lot. This is what ParkShark calls "starting Parking spot allocation".
- To start allocating a Parking spot, the following info is required:
    - The member (id)
    - The license place number (of the actual car being parked)
    - The parking lot (id)
- Starting parking allocation only succeeds if the following requirements are met:
    - The member is recognized by the system
    - The provided license plate number is the same as the member's license plate number
    - The parking lot is recognized by the system
    - The parking lot still has available capacity (it's not full)
- An Allocation id should be generated and returned (to the member)
    - It should not be a guessable, numerical id (e.g. 1,2,3)
    - It should be unique
- An Allocation should have a start time (when did the member start allocation?)
- Prioritization: Must-Have

### Story PSA2: Stop Allocating a Parking spot
**As a Member I want to stop allocating a Parking spot so that I can leave the parking lot**
> When a member wants to leave a parking lot (and thus has just left his parking spot) he has to use the mobile app to
indicate this. ParkShark calls this "stopping Parking spot allocation".
- To stop allocating a Parking spot, the following info is required:
    - The Allocation id
    - The Member (id)
- An allocation can only be stopped, if it's active.
- An allocation can only be stopped, if the provided member (id) is the owner of the allocation.
- When an allocation is stopped, a stop time should be added to the allocation.
    - Allocations that have a stop time can be seen as passive allocations. Allocations without a stop time can be seen
    as active allocations. Do make this explicit! We'll refer to it as the Allocation status. 
- Prioritization: Must-Have
    
### Story PSA3: get all Allocations
**As an Administrator I want to get an overview of all Allocations**
- By default all allocations are returned, ordered on start time ascending
- The following filters should be available:
    - limit the returned number of allocations to the provided amount
    - filter between all allocations, all active allocations and all passive allocations
    - ordering can be set to descending (or ascending)
- Prioritization: Must-Have

### Story PSA4: get all Allocations for a Member
**As an Administrator I want to get an overview of all Allocations for a given Member**
- The following filter should be available:
    - filter between all allocations, all active allocations and all passive allocations
- Prioritization: Nice-To-Have

### Story PSA5: get all Allocations for a Parking lot
**As an Administrator I want to get an overview of all Allocations for a given Parking lot**
- The following filter should be available:
    - filter between all allocations, all active allocations and all passive allocations
- Prioritization: Nice-To-Have

### Story PSA6: get all Allocations (Duration)
**As an Administrator I want to get an overview of all Allocations, showing the duration of each allocation**
- Builds on Story **PSA3**
- Each allocation returned (when getting all Allocations) should also include the duration in `hh:mm:ss` of the allocation (`duration = start time - stop time`)
    - If the stop time is not yet filled in, we use the current time
- Prioritization: Nice-To-Have

### Story INV1: get monthly Invoice 
**As a Member I want to get my monthly Invoice so that I can pay it.** (otherwise ParkShark will come and break my legs :scream: )
> When a member requests his monthly invoice, an invoice will be generated on the fly and returned to the member. All allocations 
with status passive should be collected and used (you don't have to check the current month, since we'll generate an invoice every month). 
- To get the latest invoice, the following info is required:
    - The member (id)
- Each Allocation with status **passive** needs to be transformed to an Invoice Item
    - Each of those Allocations will then get status **invoiced**
- An Invoice Item has
    - A (reference to an) Allocation
    - A calculated price
        - The price is calculated as follows:
            - `Total number of whole hours parked (rounded up) * cost per hour (defined in parking lot)`
                - E.g. Parked for 2h:20m will be charged as 3h.
                - If any reduction applies (based on Membership level), make sure to apply it!
            - If the total number of whole hours parked (rounded up) exceeds the Maximum allowed allocation-time of parking spot 
            (based on Membership level), a fine of €2.5 per hour is added to the price.
- An Invoice has
    - A unique reference number
    - A creation date
    - An expiration date
    - A collection of Invoice items (or should an Invoice Item contain a reference to Invoice?)
    - A status (Open or Closed)
        - If Closed, it should have a "date of payment"
- The returned invoice should also contain the total price to pay. This total price consists of:
    - The sum of the price of each Invoice Item (+ fine)
    - The membership monthly cost
- Prioritization: Nice-To-Have

### Story INV2: get all Invoices
**As an Administrator I want to get an overview of all Invoices.**
- Prioritization: Nice-To-Have

### Story INV3: Mark an Invoice as Closed
**As an Administrator I want to mark an Invoice as closed**
- To mark an invoice as closed, the following info is required:
    - The invoice unique reference
- The Invoice's status should be set to closed.
- Prioritization: Nice-To-Have
