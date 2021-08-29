using LibraryMenu;
using Microsoft.AspNetCore.SignalR.Client;
using RestApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.Services
{
    public class SignalRService
    {
        private readonly HubConnection _connection;
        public event Action<OrderModel> OrderSended;

        public SignalRService(HubConnection connection)
        {
            _connection = connection;

            _connection.On<OrderModel>("SendOrderTo", message => OrderSended?.Invoke(message));

        }

        public async Task Connect(string loginId)
        {
            
            await _connection.StartAsync().ContinueWith(async x => await _connection.InvokeAsync("RegistrationUser", loginId));
            
        }

        public async Task SendOrder(OrderModel message)
        {
            await _connection.SendAsync("SendOrder", message);
        }
    }
}
