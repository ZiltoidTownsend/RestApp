using LibraryMenu;
using RestApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace RestApp.Models
{
    public class OrderModel : BaseInpc, IOrderData
    {
        public int Id { get; set; }
        private decimal price;
        [Column(TypeName = "varchar(20)")]
        public Enums.Statuses Status { get; set; }

        public ObservableCollection<DishModel> Dishes { get; } = new ObservableCollection<DishModel>();
        private bool isSelected;

        public OrderModel()
        {
            Dishes.CollectionChanged += Dishes_Add_Remove;
        }
        public bool IsSelected { get => isSelected; set => Set(ref isSelected, value); }
        public decimal Price { get => price; set => Set(ref price, value); }


        private void Dishes_Add_Remove(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    foreach (DishModel a in e.NewItems)                     
                        Price += Convert.ToDecimal(a.Count) * a.Price;
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    foreach (DishModel a in e.NewItems)
                        Price -= Convert.ToDecimal(a.Count) * a.Price;
                    break;
                case NotifyCollectionChangedAction.Reset:
                    Price += Dishes[e.NewStartingIndex].Price * Dishes[e.NewStartingIndex].Count;
                    break;
            }

        }
    }
}
