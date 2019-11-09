# Phoenix

role is required on the create employee call
    email is available, but optional

Questions
    What is a 'Traceability Api'?
        Are there different Apis for different functions?
        Are there different Apis that offer the same functionality and each consumer can select the provider they wish to use?
        Could a 'consumer' of Phoenix register with multiple Apis for the same functionality?
    
# Issues with Levitian
Lack of documentation (Swagger)
Lack of standards around variable capitalization
Creds are in different places for Gets v Posts

# Employee API
On Customer Employee Id is an int while on employee creation/get id is a guid/string
Allowed to create multiple employees with the same exact information
On the Employee Get All call why is the order of the employee xml in a different order for each employee

# Order API
Customer Id is a number, but is written as a string
Cart Total is listed looks like a number not a decimal
    - are the last two numbers of the cart total the cents?
Get Order takes a 'user id' is that the same as a customer id?
Create Order passes the cart total as a string???
Create Order passes as Cashier Id, but get doesn't return it???
Create doesn't have any fields marked as required
Create accepts both strings and numbers for 'cartTotal' 
Get returns both strings and numbers for 'cartTotal' depending on what was sent in the create


"e6833b1d-b50d-43fc-8ad9-12ad72b9d95b"
"a140a6dd-5b1e-425e-bc98-f6f19858e75e"

# Things I don't like
1. Customer Lookup and passing customer id
2. Handling API creds to Leviathan
3. I think a factory pattern would probably be more fitting for the service layers
    the directions were a bit vague on this, but my guess is that each customer could be registered with one, possibly multiple
    providers. A service factory would allow me to select the correct service provide based on the user of the API

# TODOS
1. Clean up async warnings
2. Add error handling
3. Create customer call to Leviathan is failing with 'invalid employeeid' (postman)