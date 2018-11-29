﻿using mshtml;
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
    /// Interaction logic for ImageWin.xaml
    /// </summary>
    public partial class ImageWin : Window, IDisposable
    {
        public HTMLDocument doc;

        public ImageWin(HTMLDocument Doc)
        {
            InitializeComponent();
            doc = Doc;
        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            description.Focus();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            if (doc != null)
            {
                dynamic r = doc.selection.createRange();
                r.pasteHTML(string.Format(@"<img alt=""{1}"" src=""{0}"">", link.Text, description.Text));
                Hide();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\";
                openFileDialog.Filter = "jpg files (*.jpg)|*.jpg|All files (*.png.*)|*.png|All files (*.gif)|*.gif|All files (*.*)|*.*";
                openFileDialog.RestoreDirectory = true;

                System.Windows.Forms.DialogResult result = openFileDialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    link.Text = openFileDialog.FileName;
                }
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Dispose();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
