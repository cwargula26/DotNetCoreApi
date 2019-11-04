using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Phoenix.Models;
using Phoenix.Services;
using Phoenix.Repositories.Interfaces;
using System.Net.Http;
using Microsoft.Extensions.Options;
using AutoMapper;
using Phoenix.Leviathan.Models;
using System.Text.Json;
using System.Text;

namespace Phoenix.Leviathan.Services
{
    public class OrderService : OrderBaseService
    {
        private const string _orderPath = "orders";
        private string _orderUrl;
        private IHttpClientFactory _clientFactory;
        private AppSettings _appSettings;
        private IMapper _mapper;

        public OrderService(IOrderRepo _repo, IHttpClientFactory clientFactory, IOptions<AppSettings> appSettings, IMapper mapper) : base(_repo)
        {
            _clientFactory = clientFactory;
            _appSettings = appSettings.Value;
            _mapper = mapper;
            _orderUrl = _appSettings.LeviathanUrl + _orderPath;
        }

        public async override Task Create(Order order)
        {
            await base.Create(order);

            var orderCreate = _mapper.Map<LeviathanOrderCreateModel>(order);
            var createOrderJson = JsonSerializer.Serialize(orderCreate);
            var request = new HttpRequestMessage(HttpMethod.Post, _orderUrl);

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync(_orderUrl, new StringContent(createOrderJson, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                // TODO: Update local version to represent that it's beens synced
            }        
            else
            {
                // TODO: Error handling
            }
        }

        public async Task<IEnumerable<Order>> GetByCustomer(string customerId)
        {
            throw new NotImplementedException();
        }
    }
}

