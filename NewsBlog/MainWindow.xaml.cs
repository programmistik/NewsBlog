using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewsBlog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public static readonly DependencyProperty CollectionProperty = DependencyProperty.Register
        //    (
        //    "Collection",
        //    typeof(ICollection<CollectionItem>),
        //    typeof(MainWindow),
        //    new PropertyMetadata(new ObservableCollection<CollectionItem>())
        //    );

        //public ICollection<CollectionItem> Collection
        //{
        //    get { return (ICollection<CollectionItem>)GetValue(CollectionProperty); }
        //    set { SetValue(CollectionProperty, value); }
        //}

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();

            //Collection = new ObservableCollection<CollectionItem>();
            //lbNewsList.ItemsSource = Collection;
        }
    }
}
