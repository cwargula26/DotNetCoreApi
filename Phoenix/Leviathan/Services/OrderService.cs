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
using System.Net;
using Phoenix.Exceptions;

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
            var orderCreate = _mapper.Map<LeviathanOrderCreateModel>(order);
            var createOrderJson = JsonSerializer.Serialize(orderCreate);

            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, _orderUrl);

                var client = _clientFactory.CreateClient();
                var response = await client.PostAsync(_orderUrl, new StringContent(createOrderJson, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    // TODO: Update local version to represent that it's beens synced
                    order.IsSynced = true;
                    await base.Create(order);
                }        
                // There are probably other StatusCodes to watch for where we would want to save locally
                else if(response.StatusCode == HttpStatusCode.GatewayTimeout)
                {
                    await base.Create(order);
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
                // TODO: Error handling
                await base.Create(order);
            }
        }

        public async override Task<IEnumerable<Order>> GetByCustomer(System.Guid customerId)
        {
            var repoOrders = await base.GetByCustomer(customerId);

            try
            {
                var url = string.Format("{0}/{1}?ApiUser={2}&ApiKey={3}", _orderUrl, customerId, _appSettings.LeviathanApiUser, _appSettings.LeviathanApiKey);
                var request = new HttpRequestMessage(HttpMethod.Get, url);

                var client = _clientFactory.CreateClient();
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var orderJson = await response.Content.ReadAsStringAsync();
                    
                    // TODO: Determine which order collection to return
                    // TODO: Need to update local repo from remote source
                    var orders = JsonSerializer.Deserialize<IEnumerable<LeviathanOrderGetModel>>(orderJson);
                    return _mapper.Map<IEnumerable<Order>>(orders);
                }
                else
                {
                    // TODO: Error handling
                    return repoOrders;
                }        
            }
            catch(Exception)
            {
                // TODO: Error Handling
                return repoOrders;
            }
        }
    }
}

