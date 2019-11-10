# Phoenix

# Issues with Levitian
1. Lack of documentation (Swagger)
1. Lack of standards around variable capitalization
1. Credentials are in different places for Gets vs Posts

## Employee API
1. Allowed to create multiple employees with the same exact information
1. Role is required on the create employee call but isn't listed in the documentation

## Customer API
1. The Employee Id field is spelled employid instead of employeeid or employeeId
1. The Employee Id field is an int while on employee creation/get id is a guid/string

## Order API
1. Customer Id is a number, but is written as a string
1. Cart Total looks like a number not a decimal
    - are the last two numbers of the cart total the cents?
1. Get Order takes a 'user id' is that the same as a customer id?
1. Create Order passes the cart total as a string???
1. Create Order passes as Cashier Id, but get doesn't return it???
1. Create doesn't have any fields marked as required
1. Create accepts both strings and numbers for 'cartTotal' 
1. Get returns both strings and numbers for 'cartTotal' depending on what was sent in the create


# Things I'd do differently
1. Customer Lookup and passing customer id
    - Obviously there should be a much more robust auth system
    - I just added this quickly to address the issue of creds in different areas (see issues with Levithan)
1. Handling API creds to Leviathan
    - Currently I just hardcoded these, but there would need to be some system to look these up by customer and provider
    - This would also need to be more robust because each provider could authenticate differently
1. Instantiating services
    - Currently using a simple DI
    - Would switch to a Factory pattern to provide the appropriate service based on customer
1. Add swagger documentation
1. On all get methods for all services if the status code is not a successful one should I be returning the objects fro the repo?
1. Add error handling/loggging
1. Addition of Entity Framework, I thought the JSON files was sufficient enough
    - I used Guids for primary keys just for ease of use, but that would change dependent on the backend storage system

# Additional Bonus Notes
To handle the inconsistency of data between Phoenix and Leviathan, and other providerrs, I probably would design this very differently.
1. I think I would introduce an event driven pattern with possibly a circuit breaker pattern around the backend service
    - this should address issues with back end failing... messages would queue until the service is back up
1. An update method for all entities would be required.
    - Either a timed process would be required to pull the backend services to make sure data is in sync
    - This could also be done in a 'Just In Time' approach where the 'get' calls could pull from the backend service and update the repo if needed
        - Drawback to this is that if the backend system is down while the 'get' is called you could have really stale data