using mshtml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewsBlog
{
    class MainWindowViewModel : ObservableObject
    {
        //public static WPFWebBrowser webBrowser;

        private ObservableCollection<CollectionItem> news = new ObservableCollection<CollectionItem>();
        public ObservableCollection<CollectionItem> NewsList
        {
            get => news;
            set => Set(ref news, value);
        }

        private string input = "Type header here";
        public string InputHeader
        {
            get => input;
            set => Set(ref input, value);
        }

        //private ToDo selected;
        //public ToDo Selected
        //{
        //    get => selected;
        //    set => Set(ref selected, value);
        //}

        public MainWindowViewModel()
        {
            NewsList.Add(new CollectionItem { PostHeader = "Test", PostDate = DateTime.Now });
            
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get => addCommand ?? (addCommand = new RelayCommand(
                param =>
                {
                    AddEditWindow AddWin = new AddEditWindow();
                    AddWin.Title = "Add new post";
                    AddWin.DataContext = this;
                    
                    AddWin.ShowDialog();

                }
                //param =>
                //{
                //    Regex regex = new Regex("^[a-z, ]*$");
                //    return regex.IsMatch(Input) && !String.IsNullOrWhiteSpace(Input);
                //}
                //param => !String.IsNullOrWhiteSpace(Input)
            ));
        }


        private RelayCommand delCommand;
        public RelayCommand DeleteCommand
        {
            get => delCommand ?? (delCommand = new RelayCommand(
                param =>
                {
                    //var todo = param as ToDo;
                    //todo.Done = !todo.Done;
                }
            ));
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get => editCommand ?? (editCommand = new RelayCommand(
                param =>
                {
                   // WebUtility
                    //var todo = param as ToDo;
                    //todo.Done = !todo.Done;
                }
            ));
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get => saveCommand ?? (saveCommand = new RelayCommand(
                param =>
                {
                    dynamic doc = Gui.webBrowser.doc;
                    var htmlText = doc.documentElement.InnerHtml;
                    NewsList.Add(new CollectionItem { PostHeader = InputHeader, PostDate = DateTime.Now, HTMLtext = htmlText});
                    InputHeader = "Type header here";
                    
                    //var todo = param as ToDo;
                    //todo.Done = !todo.Done;
                }
            ));
        }

        private RelayCommand boldCommand;
        public RelayCommand BoldCommand
        {
            get => boldCommand ?? (boldCommand = new RelayCommand(
                param =>
                {
                    Format.bold();
                    //var todo = param as ToDo;
                    //todo.Done = !todo.Done;
                }
            ));
        }
    }
}
