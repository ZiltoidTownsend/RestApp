using LibraryMenu;
using RestApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RestApp.Models
{
    public class DishModel : BaseInpc, IDishData
    {
        public int Id { get; set; }
        public string Title { get;}
        public int Price { get;}
        public string Gram { get;}
        public string Desc { get;}
        public int CategoryId { get;}

        private int count;
        [JsonIgnore]
        public virtual CategoryModel Category { get;}
        public DishModel(int id, string title, int price, string gram, string desc, int categoryId, int count)
        {
            Id = id;
            Title = title;
            Price = price;
            Gram = gram;
            Desc = desc;
            CategoryId = categoryId;
            IsSelected = false;
            Count = count;
        }


        private bool isSelected;

        public bool IsSelected { get => isSelected; set => Set(ref isSelected, value); }
        [JsonIgnore]
        public int Count { get => count; set => Set(ref count, value); }
    }
}
