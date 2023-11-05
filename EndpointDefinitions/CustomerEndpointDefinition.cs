using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Repositories;

namespace test.EndpointDefinitions
{
    public static class CustomerEndpointDefinition
    {
        public static void DefineEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/customers", GetAll);
            app.MapGet("/customer/{id}", GetCustomerById);
            app.MapPost("/customers", CreateCustomer);
            app.MapPut("/customer/{id}", UpdateCustomer);
            app.MapDelete("/customer/{id}", DeleteCustomer);
        }

        internal static IResult GetCustomerById([FromServices] ICustomerRepository repo, int id)
        {
            var customer = repo.GetById(id);
            return customer is not null ? Results.Ok(customer) : Results.NotFound();
        }

        internal static List<Customer> GetAll([FromServices] ICustomerRepository repo)
        {
            return repo.GetAll();
        }

        internal static IResult CreateCustomer([FromServices] ICustomerRepository customerRepository, Customer customer)
        {
            customerRepository.Create(customer);
            return Results.Created($"/customer/{customer.Id}", customer);
        }

        internal static IResult UpdateCustomer([FromServices] CustomerRepository repo, int id, Customer updatedCustomer)
        {
            var customer = repo.GetById(id);
            if (customer is null)
            {
                return Results.NotFound();
            }

            repo.Update(updatedCustomer);
            return Results.Ok(updatedCustomer);
        }

        internal static IResult DeleteCustomer([FromServices] CustomerRepository repo, int id)
        {
            repo.Delete(id);
            return Results.Ok();
        }

        public static void DefineServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
        }
    }
}
