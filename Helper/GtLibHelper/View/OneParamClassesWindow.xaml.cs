﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GtLibHelper.View
{
    /// <summary>
    /// Interaction logic for OneParamClassesWindow.xaml
    /// </summary>
    public partial class OneParamClassesWindow : Window
    {
        public OneParamClassesWindow()
        {
            InitializeComponent();
        }

        public void setMainTextBox(String text) 
        {
            mainText.Text = text;
        }
    }
}