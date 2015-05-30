using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PreFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WindowsLogo : Page
    {
        SolidColorBrush[] randArray1, clor =
        { new SolidColorBrush(Colors.Red), new SolidColorBrush(Colors.Green), 
            new SolidColorBrush(Colors.Yellow), new SolidColorBrush(Colors.Blue) };
        int cur;
        public WindowsLogo()
        {
            this.InitializeComponent();
            Random rnd = new Random();
            randArray1 = clor.OrderBy(x => rnd.Next()).ToArray();
            r1.Fill = randArray1[0];
            r2.Fill = randArray1[1];
            r3.Fill = randArray1[2];
            r4.Fill = randArray1[3];
            change();
            backButton.Click += backButton_Click;
        }

        void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        async void change()
        {
            while (true)
            {
                cur = 0;
                await Task.Delay(800);
                Random rnd = new Random();
                if (rnd.Next() % 3 == 1)
                    randArray1 = clor.OrderBy(x => rnd.Next()).ToArray();
                else
                    randArray1 = clor;
                int temp;
                temp = (Convert.ToInt32(score.Text) + cur);
                score.Text = Convert.ToString(temp);
                r1.Fill = (randArray1[0]);
                r2.Fill = (randArray1[1]);
                r3.Fill = (randArray1[2]);
                r4.Fill = (randArray1[3]);
            }
        }
        bool check()
        {
            return (r1.Fill == clor[0] && r2.Fill == clor[1] && r3.Fill == clor[2] && r4.Fill == clor[3]);
        }
        private void botton_Click(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                cur = 1;
            }
            else
            {
                cur = -1;
            }
        }
    }
}
