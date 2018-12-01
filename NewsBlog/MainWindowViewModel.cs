using mshtml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NewsBlog
{
    class MainWindowViewModel : ObservableObject
    {

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

        NewsBlogContext Entities = new NewsBlogContext();
        public MainWindowViewModel()
        {
           // NewsList.Add(new CollectionItem { PostHeader = "Test", PostDate = DateTime.Now });
            Entities.MyCollection.Load();
            NewsList = Entities.MyCollection.Local;
        }

        private void SaveToDB()
        {
            try
            {
                Entities.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    AddWin.CollItem = new CollectionItem { PostHeader = "Type header here", PostDate = DateTime.Now, HTMLtext = Properties.Resources.New };
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
                    var itm = param as CollectionItem;
                    NewsList.Remove(itm);
                    SaveToDB();
                }
            ));
        }

        private RelayCommand editCommand;
        public RelayCommand EditCommand
        {
            get => editCommand ?? (editCommand = new RelayCommand(
                param =>
                {
                    var itm = param as CollectionItem;
                    AddEditWindow AddWin = new AddEditWindow();
                    AddWin.Title = "Add new post";
                    AddWin.DataContext = this;
                    AddWin.CollItem = itm;
                    AddWin.ShowDialog();
                    
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
                    
                    var win = param as AddEditWindow;
                    var be = win.tbPostHeader.GetBindingExpression(TextBox.TextProperty);
                    be.UpdateSource();
                    win.CollItem.HTMLtext = htmlText;
                    bool exsist = NewsList.Where(itm => itm == win.CollItem).Any();
                    if(!exsist)
                     NewsList.Add(win.CollItem);

                    win.Close();
                    InputHeader = "Type header here";
                    SaveToDB();
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
                }
            ));
        }

        private RelayCommand italicCommand;
        public RelayCommand ItalicCommand
        {
            get => italicCommand ?? (italicCommand = new RelayCommand(
                param =>
                {
                    Format.Italic();
                }
            ));
        }
        //
        private RelayCommand underLineCommand;
        public RelayCommand UnderLineCommand
        {
            get => underLineCommand ?? (underLineCommand = new RelayCommand(
                param =>
                {
                    Format.Underline();
                }
            ));
        }
        private RelayCommand fontColorCommand;
        public RelayCommand FontColorCommand
        {
            get => fontColorCommand ?? (fontColorCommand = new RelayCommand(
                param =>
                {
                    Gui.SettingsFontColor();
                }
            ));
        }
        private RelayCommand addImageCommand;
        public RelayCommand AddImageCommand
        {
            get => addImageCommand ?? (addImageCommand = new RelayCommand(
                param =>
                {
                    Gui.SettingsAddImage();
                }
            ));
        }
        private RelayCommand leftAlignCommand;
        public RelayCommand LeftAlignCommand
        {
            get => leftAlignCommand ?? (leftAlignCommand = new RelayCommand(
                param =>
                {
                    Format.JustifyLeft();
                }
            ));
        }
        private RelayCommand center2Command;
        public RelayCommand Center2Command
        {
            get => center2Command ?? (center2Command = new RelayCommand(
                param =>
                {
                    Format.JustifyCenter();
                }
            ));
        }
        private RelayCommand rightAlignCommand;
        public RelayCommand RightAlignCommand
        {
            get => rightAlignCommand ?? (rightAlignCommand = new RelayCommand(
                param =>
                {
                    Format.JustifyRight();
                }
            ));
        }
        private RelayCommand centerCommand;
        public RelayCommand CenterCommand
        {
            get => centerCommand ?? (centerCommand = new RelayCommand(
                param =>
                {
                    Format.JustifyFull();
                }
            ));
        }
        private RelayCommand bulletsCommand;
        public RelayCommand BulletsCommand
        {
            get => bulletsCommand ?? (bulletsCommand = new RelayCommand(
                param =>
                {
                    Format.InsertUnorderedList();
                }
            ));
        }
        private RelayCommand outIdentCommand;
        public RelayCommand OutIdentCommand
        {
            get => outIdentCommand ?? (outIdentCommand = new RelayCommand(
                param =>
                {
                    Format.Outdent();
                }
            ));
        }
        private RelayCommand identCommand;
        public RelayCommand IdentCommand
        {
            get => identCommand ?? (identCommand = new RelayCommand(
                param =>
                {
                    Format.Indent();
                }
            ));
        }
        private RelayCommand editWeb1Command;
        public RelayCommand EditWeb1Command
        {
            get => editWeb1Command ?? (editWeb1Command = new RelayCommand(
                param =>
                {
                    Gui.EditWeb();
                }
            ));
        }
        private RelayCommand viewHTMLCommand;
        public RelayCommand ViewHTMLCommand
        {
            get => viewHTMLCommand ?? (viewHTMLCommand = new RelayCommand(
                param =>
                {
                    Gui.ViewHTML();
                }
            ));
        }
        private RelayCommand numberedCommand;
        public RelayCommand NumberedCommand
        {
            get => numberedCommand ?? (numberedCommand = new RelayCommand(
                param =>
                {
                    Format.InsertOrderedList();
                }
            ));
        }

        private RelayCommand addLinkCommand;
        public RelayCommand AddLinkCommand
        {
            get => addLinkCommand ?? (addLinkCommand = new RelayCommand(
                param =>
                {
                    Gui.SettingsAddLink();
                }
            ));
        }

        private RelayCommand showCommand;
        public RelayCommand ShowCommand
        {
            get => showCommand ?? (showCommand = new RelayCommand(
                param =>
                {
                    var itm = param as CollectionItem;

                    var ShowWin = new ShowWindow();
                    ShowWin.CollecItem = itm;
                    ShowWin.DataContext = this;
                    ShowWin.Title = itm.PostHeader;
                    ShowWin.ShowDialog();
                }
            ));
        }
    }
}
