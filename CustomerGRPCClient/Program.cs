// See https://aka.ms/new-console-template for more information
using CustomerGRPCService;
using Grpc.Core;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("https://localhost:7213");
var custClient = new Customer.CustomerClient(channel);
var request = new CustRequestByAuth { Username = "Lalith", Password = "Lalith" };
var response = await custClient.GetSpecificCustomerAsync(request);
Console.WriteLine($"Welcome {response.Firstname} {response.Lastname} to {response.Company}.");
Console.WriteLine($"We strongly believe, your {response.Experience} years of experience in {response.Technology} technology will help the company achieve new milestones.");
Console.WriteLine($"All the very best to you in your {response.Role} role.");
Console.WriteLine();

var request1 = new CustRequestByAuth { Username = "Edwin", Password = "Edwin" };
var response1 = await custClient.GetSpecificCustomerAsync(request1);
Console.WriteLine($"Welcome {response1.Firstname} {response1.Lastname} to {response1.Company}.");
Console.WriteLine($"We strongly believe, your {response1.Experience} years of experience in {response1.Technology} technology will help the company achieve new milestones.");
Console.WriteLine($"All the very best to you in your {response1.Role} role.");

using (var call = custClient.GetAllCustomers(new AllCustRequest()))
{
    await Task.Delay(2000);
    Console.WriteLine();
    Console.WriteLine("fetching customer list......");
    Console.WriteLine();

    while (await call.ResponseStream.MoveNext())
    {
        var currentCustomer = call.ResponseStream.Current;
        Console.WriteLine($"FirstName:{currentCustomer.Firstname}");
        Console.WriteLine($"LastName:{currentCustomer.Lastname}");
        Console.WriteLine($"Company:{currentCustomer.Company}");
        Console.WriteLine($"Role:{currentCustomer.Role}");
        Console.WriteLine($"Technology:{currentCustomer.Technology}");
        Console.WriteLine($"Experience:{currentCustomer.Experience}");
        Console.WriteLine();
    }
    Console.ReadLine();
}
