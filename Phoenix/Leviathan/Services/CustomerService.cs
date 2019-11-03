using System.Collections.Generic;
using System;
using Phoenix.Models;
using Phoenix.Repositories.Interfaces;
using Phoenix.Services.Interfaces;
using System.Threading.Tasks;
using Phoenix.Services;
using AutoMapper;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;
using Phoenix.Leviathan.Models;
using System.Text;

namespace Phoenix.Leviathan.Services
{
    public class CustomerService : CustomerBaseService
    {
        private const string _customerPath = "customer";
        private IHttpClientFactory _clientFactory;
        private AppSettings _appSettings;
        private string _customerUrl;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepo customerRepo, IHttpClientFactory clientFactory, IOptions<AppSettings> appSettings, IMapper mapper) : base(customerRepo)
        {
            _clientFactory = clientFactory;
            _appSettings = appSettings.Value;
            _customerUrl = _appSettings.LeviathanUrl + _customerPath;
            _mapper = mapper;
        }

        public async override Task Create(Customer customer)
        {
            await base.Create(customer);

            var createCustomer = _mapper.Map<LeviathanCustomerModel>(customer);
            var createCustomerJson = JsonSerializer.Serialize(createCustomer);

            var request = new HttpRequestMessage(HttpMethod.Post, _customerUrl);

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync(_customerUrl, new StringContent(createCustomerJson, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                // TODO: Update local version to represent that it's beens synced and get the ID from the response
            }        
            else
            {
                // TODO: Error handling
            }
        }

        public override IEnumerable<Customer> GetAll(Guid companyId)
        {
            throw new System.NotImplementedException();
        }
    }
}