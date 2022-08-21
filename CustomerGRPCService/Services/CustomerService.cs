using Grpc.Core;
using System.Collections.Generic;

namespace CustomerGRPCService.Services
{
    public class CustomerService : Customer.CustomerBase
    {
        public ILogger<CustomerService> _logger;
        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
        }
        public override Task<CustInfoResponse> GetSpecificCustomer(CustRequestByAuth request, ServerCallContext context)
        {
            CustInfoResponse response = new CustInfoResponse();
            if (request.Username == "Lalith" && request.Password == "Lalith")
            {
                response.Firstname = "Lalith";
                response.Lastname = "Kamana";
                response.Company = "NexTurn";
                response.Role = "DotNet Architect";
                response.Technology = "DotNet";
                response.Experience = 13;
            }
            else if (request.Username == "Edwin" && request.Password == "Edwin")
            {
                response.Firstname = "Edwin";
                response.Lastname = "Singh";
                response.Company = "NexTurn";
                response.Role = "Cloud Architect";
                response.Technology = "DotNet";
                response.Experience = 15;
            }
            else if (request.Username == "Razz" && request.Password == "Razz")
            {
                response.Firstname = "Razz";
                response.Lastname = "Verma";
                response.Company = "NexTurn";
                response.Role = "UI Architect";
                response.Technology = "DotNet";
                response.Experience = 6;
            }
            else if (request.Username == "Anirban" && request.Password == "Anirban")
            {
                response.Firstname = "Anirban";
                response.Lastname = "C";
                response.Company = "NexTurn";
                response.Role = "Microservices Architect";
                response.Technology = "DotNet";
                response.Experience = 14;
            }
            else
            {

            }
            return Task.FromResult(response);
        }

        public override async Task GetAllCustomers(AllCustRequest request, IServerStreamWriter<CustInfoResponse> responseStream, ServerCallContext context)
        {
            List<CustInfoResponse> allCust = new List<CustInfoResponse>
            {
                new CustInfoResponse
                {
                    Firstname = "Lalith",
                    Lastname = "Kamana",
                    Company = "NexTurn",
                    Role = "DotNet Architect",
                    Technology = "DotNet",
                    Experience = 13
                },
                new CustInfoResponse
                {
                    Firstname = "Edwin",
                    Lastname = "Singh",
                    Company = "NexTurn",
                    Role = "Cloud Architect",
                    Technology = "DotNet",
                    Experience = 15
                },
                new CustInfoResponse
                {
                    Firstname = "Razz",
                    Lastname = "Verma",
                    Company = "NexTurn",
                    Role = "UI Architect",
                    Technology = "DotNet",
                    Experience = 6
                },
                new CustInfoResponse
                {
                    Firstname = "Anirban",
                    Lastname = "C",
                    Company = "NexTurn",
                    Role = "Microservices Architect",
                    Technology = "DotNet",
                    Experience = 14
                }

            };
            foreach (var cust in allCust)
            {
                await Task.Delay(2000);
                await responseStream.WriteAsync(cust);
            }
        }

    }
}
