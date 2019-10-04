using Newtonsoft.Json;
using Prism.Ioc;
using Project.Models;
using Project.Services;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Project.ViewModels
{
    public class SearchPageViewModel : BaseViewModel
    {
        public Comment Resultados { get; set; } = new Comment();

      public ICommand GetCommentsCommand { get; set; }

      public ObservableCollection<Snippet> Snippets { get; set; } = new ObservableCollection<Snippet>();

      public SearchPageViewModel()
      {
         PageName = "Search Page";
        // GetCommentsCommand = new Command(async () => await RunSafe(GetData()));
            
      }

      async Task GetData()
        {
            var commentsResponse = await ApiManager.GetComments("");

            if (commentsResponse.IsSuccessStatusCode)
            {
                var response = await commentsResponse.Content.ReadAsStringAsync();
                var json = await Task.Run(() => JsonConvert.DeserializeObject<Comment>(response));
                Resultados = json;
            }
            else
            {
                await PageDialog.AlertAsync("Unable to get data", "Error", "Ok");
            }
            System.Diagnostics.Debug.WriteLine("Probando");
        }
        
    }
}
