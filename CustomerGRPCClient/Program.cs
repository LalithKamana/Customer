// See https://aka.ms/new-console-template for more information
using CustomerGRPCService;
using Grpc.Core;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("https://localhost:7213");
var custClient = new Customer.CustomerClient(channel);

using (var call = custClient.GetAllCustomers(new AllCustRequest()))
{
    Console.WriteLine("fetching customer list......");
    Console.WriteLine();
    int counter = 0;
    while (await call.ResponseStream.MoveNext())
    {
        var currentCustomer = call.ResponseStream.Current;
        counter++;
        Console.WriteLine($"#### {counter} ####");
        Console.WriteLine($"FirstName:{currentCustomer.Firstname}");
        Console.WriteLine($"LastName:{currentCustomer.Lastname}");
        Console.WriteLine($"Company:{currentCustomer.Company}");
        Console.WriteLine($"Role:{currentCustomer.Role}");
        Console.WriteLine($"Technology:{currentCustomer.Technology}");
        Console.WriteLine($"Experience:{currentCustomer.Experience}");
        Console.WriteLine();
    }
}
await Task.Delay(2000);
var request = new CustRequestByAuth { Username = "Lalith", Password = "Lalith" };
var response = await custClient.GetSpecificCustomerAsync(request);
Console.WriteLine($"$Welcome {response.Firstname} {response.Lastname} to {response.Company}.");
Console.WriteLine($"We strongly believe, your {response.Experience} years of experience in {response.Technology} technology will help the company achieve new milestones.");
Console.WriteLine($"All the very best to you in your {response.Role} role.");
Console.WriteLine();
await Task.Delay(2000);
var request1 = new CustRequestByAuth { Username = "Edwin", Password = "Edwin" };
var response1 = await custClient.GetSpecificCustomerAsync(request1);
Console.WriteLine($"$Welcome {response1.Firstname} {response1.Lastname} to {response1.Company}.");
Console.WriteLine($"We strongly believe, your {response1.Experience} years of experience in {response1.Technology} technology will help the company achieve new milestones.");
Console.WriteLine($"All the very best to you in your {response1.Role} role.");
Console.WriteLine();
await Task.Delay(2000);
var request2 = new CustRequestByAuth { Username = "Razz", Password = "Razz" };
var response2 = await custClient.GetSpecificCustomerAsync(request2);
Console.WriteLine($"$Welcome {response2.Firstname} {response2.Lastname} to {response2.Company}.");
Console.WriteLine($"We strongly believe, your {response2.Experience} years of experience in {response2.Technology} technology will help the company achieve new milestones.");
Console.WriteLine($"All the very best to you in your {response2.Role} role.");
Console.WriteLine();
await Task.Delay(2000);
var request3 = new CustRequestByAuth { Username = "Anirban", Password = "Anirban" };
var response3 = await custClient.GetSpecificCustomerAsync(request3);
Console.WriteLine($"$Welcome {response3.Firstname} {response3.Lastname} to {response3.Company}.");
Console.WriteLine($"We strongly believe, your {response3.Experience} years of experience in {response3.Technology} technology will help the company achieve new milestones.");
Console.WriteLine($"All the very best to you in your {response3.Role} role.");

Console.ReadLine();