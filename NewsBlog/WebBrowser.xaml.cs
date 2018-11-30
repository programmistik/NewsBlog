using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Web;

namespace NewsBlog
{
    /// <summary>
    /// Interaction logic for WebBrowser.xaml
    /// </summary>
    public partial class WPFWebBrowser : UserControl
    {
        public HTMLDocument doc;
        public WebBrowser webBrowser;

        public WPFWebBrowser()
        {
            InitializeComponent();
        }

        public void newWb(string url)
        {
            if (webBrowser != null)
            {
                webBrowser.LoadCompleted -= completed;
                webBrowser.Dispose();
                gridwebBrowser.Children.Remove(webBrowser);
            }

            if (doc != null)
            {
                doc.clear();
            }

            webBrowser = new WebBrowser();
            webBrowser.LoadCompleted += completed;
            gridwebBrowser.Children.Add(webBrowser);

            Script.HideScriptErrors(webBrowser, true);

            if (url == "")
            {
                webBrowser.NavigateToString(Properties.Resources.New);
                doc = webBrowser.Document as HTMLDocument;
                doc.designMode = "On";
                Format.doc = doc;
                return;
            }
            else
            {
                

                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    webBrowser.Navigate(url);
                }
                else
                {
                    webBrowser.NavigateToString(url);
                    doc = webBrowser.Document as HTMLDocument;
                    doc.designMode = "On";
                    Format.doc = doc;
                    return;
                }
            }


            doc = webBrowser.Document as HTMLDocument;
            Format.doc = doc;
        }

        private void completed(object sender, NavigationEventArgs e)
        {
            doc = webBrowser.Document as HTMLDocument;
            doc.designMode = "On";
        }
    }
}
