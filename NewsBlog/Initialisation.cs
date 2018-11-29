﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace NewsBlog
{
    public static class Initialisation
    {
        public static AddEditWindow webeditor;

        public static void RibbonComboboxFontsInitialisation()
        {
            webeditor.RibbonComboboxFonts.ItemsSource = Fonts.SystemFontFamilies;
            webeditor.RibbonComboboxFonts.Text = "Times New Roman";
        }

        public static void RibbonComboboxFormatInitionalisation()
        {
            webeditor.RibbonComboboxFormat.ItemsSource = Gui.RibbonComboboxFormatInitionalisation();
            webeditor.RibbonComboboxFormat.SelectedIndex = 0;
        }

        public static void RibbonComboboxFontSizeInitialisation()
        {
            webeditor.RibbonComboboxFontHeight.ItemsSource = Gui.RibbonComboboxFontSizeInitialisation();
            webeditor.RibbonComboboxFontHeight.Text = "3";
        }
    }
}
