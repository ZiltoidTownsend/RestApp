using Microsoft.AspNetCore.SignalR.Client;
using RestApp.Models;
using RestApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.ViewModels
{
    public class KitchenViewModel : BaseInpc
    {
        public ObservableCollection<OrderModel> Orders { get; set; } = new ObservableCollection<OrderModel>();
        private string text;
        public string Text { get => text; set => Set(ref text, value); }
        public SignalRService Service { get; set; }

        public KitchenViewModel(SignalRService service)
        {
            Text = "Kitchen";

            Service = service;
            Service.OrderSended += Service_OrderSended;

            Service.Connect("asd").ContinueWith(task => { });
        }

        private void Service_OrderSended(OrderModel message)
        {
            Orders.Add(message);
        }
    }
}
