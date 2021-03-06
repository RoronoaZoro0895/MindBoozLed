﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PreFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();      
        }

        private void onClick(object sender, RoutedEventArgs e)
        {
            if (sender == btn1)
                this.Frame.Navigate(typeof(ColorMatching));
            else if(sender == btn2)
                this.Frame.Navigate(typeof(MemoryGame));
            else if(sender == btn3)
                this.Frame.Navigate(typeof(ColorTiles));
            else if(sender == btn4)
                this.Frame.Navigate(typeof(WindowsLogo));
        }

    }
}
