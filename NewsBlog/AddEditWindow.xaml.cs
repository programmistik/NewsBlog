using mshtml;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace NewsBlog
{
    /// <summary>
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        public static readonly DependencyProperty CollectionItemProperty = DependencyProperty.Register
            ("CollItem",
            typeof(CollectionItem),
            typeof(AddEditWindow),
            new PropertyMetadata(new CollectionItem())
            );

        public CollectionItem CollItem
        {
            get { return (CollectionItem)GetValue(CollectionItemProperty); }
            set { SetValue(CollectionItemProperty, value); }
        }

        public AddEditWindow()
        {
            InitializeComponent();
        }

        private void RibbonButtonNew_Click(object sender, RoutedEventArgs e)
        {
            Gui.newdocument();
        }

        private void RibbonButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            Gui.newdocumentFile();
        }

        private void RibbonButtonOpenweb_Click(object sender, RoutedEventArgs e)
        {
            webBrowserEditor.newWb(@"http://www.github.com/programmistik/");
        }

        private void RibbonButtonSave_Click(object sender, RoutedEventArgs e)
        {
            Gui.RibbonButtonSave();
        }

        private void RibbonComboboxFonts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Gui.RibbonComboboxFonts(RibbonComboboxFonts);
        }

        private void RibbonComboboxFontHeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Gui.RibbonComboboxFontHeight(RibbonComboboxFontHeight);
        }

        private void RibbonComboboxFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Gui.RibbonComboboxFormat(RibbonComboboxFormat);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            Gui.webBrowser = webBrowserEditor;
            
            Gui.htmlEditor = HtmlEditor1;
            Initialisation.webeditor = this;
            Gui.newdocument();
            Gui.webBrowser.newWb(CollItem.HTMLtext);
           

            Initialisation.RibbonComboboxFontsInitialisation();
            Initialisation.RibbonComboboxFontSizeInitialisation();
            Initialisation.RibbonComboboxFormatInitionalisation();

        }
    }
}
