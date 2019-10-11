using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPage : ContentPage
    {
        string url = "https://s15.onlinevideoconverter.com/download?file=g6a0j9g6e4f5e4";

        public VideoPage()
        {
            InitializeComponent();
        }

    }
}