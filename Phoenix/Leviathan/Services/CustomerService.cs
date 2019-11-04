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
        private const string _customerGetPath = "get-all";
        private IHttpClientFactory _clientFactory;
        private AppSettings _appSettings;
        private string _customerUrl;
        private string _customerGetUrl;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepo customerRepo, IHttpClientFactory clientFactory, IOptions<AppSettings> appSettings, IMapper mapper) : base(customerRepo)
        {
            _clientFactory = clientFactory;
            _appSettings = appSettings.Value;
            _customerUrl = _appSettings.LeviathanUrl + _customerPath;
            _customerGetUrl = string.Format("{0}/{1}", _customerUrl, _customerGetPath);
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

        public async override Task<IEnumerable<Customer>> GetAll(Guid companyId)
        {
            var repoCustomers = await base.GetAll(companyId);

            try
            {
                var url = string.Format("{0}?ApiUser={1}&ApiKey={2}", _customerGetUrl, _appSettings.LeviathanApiUser, _appSettings.LeviathanApiKey);
                var request = new HttpRequestMessage(HttpMethod.Get, url);

                var client = _clientFactory.CreateClient();
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var customerJson = await response.Content.ReadAsStringAsync();
                    
                    var customers = JsonSerializer.Deserialize<IEnumerable<LeviathanEmployeeModel>>(customerJson);
                    return _mapper.Map<IEnumerable<Customer>>(customers);
                }
                else
                {
                    // TODO: Error handling
                    return repoCustomers;
                }        
            }
            catch(Exception)
            {
                // TODO: Error Handling
                return repoCustomers;
            }
        }
    }
}