# Sulmar.AspNetCore.Routing.RouteConstraints
Route constraints for validation of Polish NIP, PESEL, REGON for .NET 5

## Get Started
RouteConstraints can be installed using the Nuget package manager or the dotnet CLI.

~~~ 
Install-Package Sulmar.AspNetCore.Routing.RouteConstraints
~~~

~~~ 
dotnet add package Sulmar.AspNetCore.Routing.RouteConstraints
~~~

## Usage

### Register

- PESEL
~~~ csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddPeselConstraint();    
}
~~~

- REGON
~~~ csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddRegonConstraint();    
}
~~~

- NIP

~~~ csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddNipConstraint();    
}
~~~

- or all together 
~~~ csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddPolishConstraints();    
}
~~~

### Add Route Constraint

- PESEL
~~~ csharp
// GET api/customers/{number}
[HttpGet("{number:pesel}")]
public ActionResult<Customer> GetByPesel(string number)
{
    var customer = customerService.GetByPesel(number);

    if (customer == null)
        return NotFound();

    return Ok(customer);
}
~~~

- REGON
~~~ csharp
// GET api/customers/{number}
[HttpGet("{number:regon}")]
public ActionResult<Customer> GetByRegon(string number)
{
    var customer = customerService.GetByRegon(number);

    if (customer == null)
        return NotFound();

    return Ok(customer);
}
~~~

- NIP
~~~ csharp
// GET api/customers/{number}
[HttpGet("{number:nip}")]
public ActionResult<Customer> GetByNip(string number)
{
    var customer = customerService.GetByNip(number);

    if (customer == null)
        return NotFound();

    return Ok(customer);
}
~~~


