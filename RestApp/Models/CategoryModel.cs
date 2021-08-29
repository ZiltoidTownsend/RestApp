using LibraryMenu;
using RestApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RestApp.Models
{
    public class CategoryModel : BaseInpc, ICategoryData
    {

        public int Id { get; set; }
        public string Title { get;}
        private Enums.Statuses status;
        public Enums.Statuses Status { get => status; set => Set(ref status, value); }
        public virtual List<DishModel> Dishes { get;} = new List<DishModel>();
        public CategoryModel(int id, string title, List<DishModel> dishes)
        {
            Id = id;
            Title = title;
            Dishes = dishes;
        }

    }
}
