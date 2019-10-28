using System.Collections.Generic;
using System;
using Phoenix.Models;
using Phoenix.Services;
using Phoenix.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace Phoenix.Leviathan.Services
{
    public class EmployeeService : EmployeeBaseService
    {
        private const string _employeePath = "employee";
        private IHttpClientFactory _clientFactory;
        private AppSettings _appSettings;
        private string _employeeUrl;

        public EmployeeService(IEmployeeRepo employeeRepo, IHttpClientFactory clientFactory, IOptions<AppSettings> appSettings) : base(employeeRepo)
        {
            _clientFactory = clientFactory;
            _appSettings = appSettings.Value;
            _employeeUrl = _appSettings.LeviathanUrl + _employeePath;
        }

        public async override Task Create(Employee employee)
        {
            base.Create(employee);

            // var request = new HttpRequestMessage(HttpMethod.Post, _employeeUrl);
            // request.

            // var client = _clientFactory.CreateClient();
            // var response = await client.PostAsync(_employeeUrl, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

            // if (response.IsSuccessStatusCode)
            // {
            //     var emplyeeJson = await response.Content.ReadAsStringAsync();
                
            //     // TODO: Determine which employee collection to return
            //     return JsonSerializer.Deserialize<IEnumerable<Employee>>(emplyeeJson);
            // }
            // else
            // {
            //     // TODO: Error handling
            //     throw new Exception();
            // }        

        }

        public async override Task<IEnumerable<Employee>> GetAllByCompanyId(Guid companyId)
        {
            var repoEmployees = await base.GetAllByCompanyId(companyId);

            // TODO: handle url and api creds better
            var url = string.Format("{0}?ApiUser={1}&ApiKey={2}", _employeeUrl, _appSettings.LeviathanApiUser, _appSettings.LeviathanApiKey);
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var emplyeeJson = await response.Content.ReadAsStringAsync();
                
                // TODO: Determine which employee collection to return
                return JsonSerializer.Deserialize<IEnumerable<Employee>>(emplyeeJson);
            }
            else
            {
                // TODO: Error handling
                throw new Exception();
            }        
        }
    }
}