using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestApp.Styles
{
    /// <summary>
    /// Логика взаимодействия для TextBoxWithHint.xaml
    /// </summary>
    public partial class TextBoxWithHint : UserControl
    {
        public TextBoxWithHint()
        {
            InitializeComponent();
        }

        public string HintText 
        {
            get { return (string)GetValue(HintTextProperty); }
            set
            {
                SetValue(HintTextProperty, value);
            }
        }
        public string Text 
        {
            get { return (string)GetValue(TextProperty); }
            set
            {
                SetValue(TextProperty, value);
            }
        }
        public static readonly DependencyProperty TextProperty =
           DependencyProperty.Register("Text", typeof(string), typeof(TextBoxWithHint), new PropertyMetadata(null));

        public static readonly DependencyProperty HintTextProperty =
           DependencyProperty.Register("HintText", typeof(string), typeof(TextBoxWithHint), new PropertyMetadata(null));

    }
}
