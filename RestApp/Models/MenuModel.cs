using RestApp.Other;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RestApp.Models
{
    public class MenuModel
    {
        public ObservableCollection<CategoryModel> AllMenu { get;}

        public MenuModel(UserModel user)
        {
            AllMenu = new ObservableCollection<CategoryModel>();
            List<CategoryModel> Categories = ConnectingToApi.GetMenu(user.Cookies).GetAwaiter().GetResult();
            foreach (var cat in Categories)
            {
                AllMenu.Add(new CategoryModel(cat.Id, cat.Title, cat.Dishes));
                foreach (DishModel dish in cat.Dishes)
                    dish.Count = 1;
                 
            }

        }
    }
}
