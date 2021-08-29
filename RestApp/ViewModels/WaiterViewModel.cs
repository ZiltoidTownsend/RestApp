using RestApp.Commands;
using RestApp.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;
using RestApp.Other;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using LibraryMenu;
using RestApp.Services;

namespace RestApp.ViewModels
{
    public class WaiterViewModel : BaseInpc
    {
        private string text;
        public string Text { get => text; set => Set(ref text, value); }

        public SignalRService Service { get; set; }

        public MenuModel Menu { get;}

        public ObservableCollection<OrderModel> Orders { get; set; } = new ObservableCollection<OrderModel>();

        private OrderModel selectedOrder;

        public OrderModel SelectedOrder { get => selectedOrder; set => Set(ref selectedOrder, value); }


        private RelayCommand addOrderCommand;
        public RelayCommand AddOrderCommand
        {
            get
            {
                return addOrderCommand ??
                  (addOrderCommand = new RelayCommand(obj =>
                  {
                      OrderModel newOrder = ConnectingToApi.GetIdOrder().GetAwaiter().GetResult();
                      Orders.Add(newOrder);
                  }));
            }
        }


        private RelayCommand addDishesCommand;
        public RelayCommand AddDishesCommand => addDishesCommand
    ?? (addDishesCommand = new RelayCommand<OrderModel>(AddDishExecute));

        private void AddDishExecute(OrderModel order)
        {

            List<DishModel> or = new List<DishModel>(from cats in Menu.AllMenu
                                                     from dishes in cats.Dishes
                                                     where dishes.IsSelected == true
                                                     select dishes);
            foreach (var item in or)
            {
                if (order.Dishes.Any(d => d.Id == item.Id))
                {
                    DishModel dish = order.Dishes.SingleOrDefault(d => d.Id == item.Id);
                    dish.Count += item.Count;
                    order.Price += dish.Price * item.Count;
                }
                else
                    order.Dishes.Add(new DishModel(item.Id, item.Title, item.Price, item.Gram, item.Desc, item.CategoryId, item.Count));
            }

        }

        private RelayCommand sendOrderCommand;
        public RelayCommand SendOrderCommand
        {
            get
            {
                return sendOrderCommand ??
                  (sendOrderCommand = new RelayCommand(async obj =>
                  {

                      await Service.SendOrder(Orders[0]);

                  }));
            }
        }


        private RelayCommand deleteOrderCommand;
        public RelayCommand DeleteOrderCommand => deleteOrderCommand
    ?? (deleteOrderCommand = new RelayCommand<OrderModel>(DeleteOrderExecute));

        private void DeleteOrderExecute(OrderModel order)
        {
            Orders.Remove(order);
        }

        public WaiterViewModel(SignalRService service, UserModel user)
        {
            Text = "asd";
            SelectedOrder = new OrderModel();
            Menu = new MenuModel(user);
            Service = service;
            Service.OrderSended += Service_OrderSended;

            Service.Connect("asd").ContinueWith(task => { });
            //Menu = new ObservableCollection<CategoryModel> { new CategoryModel { Id = 0, Title = "Супы", Dishes = new ObservableCollection<DishModel> { new DishModel { Id = 0, Title = "Луковый суп", Price = 115 } } } };
            //Orders = new ObservableCollection<OrderModel>();
            //Orders.Add(new OrderModel { Id = 1, Price = 0, Dishes = new List<DishModel> { new DishModel { Id=1, Title="Луковый суп", Price = 15} } });
        }

        private void Service_OrderSended(OrderModel message)
        {
            Orders.Add(message);
        }
    }
}
