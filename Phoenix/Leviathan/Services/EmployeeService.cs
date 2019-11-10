using System.Collections.Generic;
using System;
using Phoenix.Models;
using Phoenix.Services;
using Phoenix.Repositories.Interfaces;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Options;
using AutoMapper;
using Phoenix.Leviathan.Models;
using System.Text;
using System.Net;
using Phoenix.Exceptions;

namespace Phoenix.Leviathan.Services
{
    public class EmployeeService : EmployeeBaseService
    {
        private const string _employeePath = "employee";
        private IHttpClientFactory _clientFactory;
        private AppSettings _appSettings;
        private string _employeeUrl;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepo employeeRepo, IHttpClientFactory clientFactory, IOptions<AppSettings> appSettings, IMapper mapper) : base(employeeRepo)
        {
            _clientFactory = clientFactory;
            _appSettings = appSettings.Value;
            _employeeUrl = _appSettings.LeviathanUrl + _employeePath;
            _mapper = mapper;
        }

        public async override Task Create(Employee employee)
        {
            var createEmp = _mapper.Map<LeviathanEmployeeModel>(employee);
            var createEmpJson = JsonSerializer.Serialize(createEmp);

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, _employeeUrl);

                var client = _clientFactory.CreateClient();
                var response = await client.PostAsync(_employeeUrl, new StringContent(createEmpJson, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    employee.IsSynced = true;
                    await base.Create(employee);
                }        
                // There are probably other StatusCodes to watch for where we would want to save locally
                else if(response.StatusCode == HttpStatusCode.GatewayTimeout)
                {
                    await base.Create(employee);
                }
                else
                {
                    // TODO: Error handling
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    throw new ApiException(errorMessage, (int)response.StatusCode);
                }
            }
            catch(Exception)
            {
                // TOOD: Error Handling
                await base.Create(employee);
            }
        }

        public async override Task<IEnumerable<Employee>> GetAllByCompanyId(Guid companyId)
        {
            var repoEmployees = await base.GetAllByCompanyId(companyId);

            // TODO: handle url and api creds better
            try
            {
                var url = string.Format("{0}?ApiUser={1}&ApiKey={2}", _employeeUrl, _appSettings.LeviathanApiUser, _appSettings.LeviathanApiKey);
                var request = new HttpRequestMessage(HttpMethod.Get, url);

                var client = _clientFactory.CreateClient();
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var employeeJson = await response.Content.ReadAsStringAsync();
                    
                    // TODO: Determine which employee collection to return
                    // TODO: Need to update local repo from remote source
                    var employees = JsonSerializer.Deserialize<IEnumerable<LeviathanEmployeeModel>>(employeeJson);
                    return _mapper.Map<IEnumerable<Employee>>(employees);
                }
                else
                {
                    // TODO: Error handling
                    return repoEmployees;
                }        
            }
            catch(Exception)
            {
                // TODO: Error Handling
                return repoEmployees;
            }
        }
    }
}