using demow02.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace demow02
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Beer b = new Beer("jupiler", "AB inbev", 5.2, "blond");
            Debug.WriteLine(b);

        }
    }
}
