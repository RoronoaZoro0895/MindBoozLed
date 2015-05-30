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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PreFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ColorMatching : Page
    {
        const int extremeRight = 1366, center = 544;
        bool first = true;
        int color, word, size;
        string[] ws;
        Color[] cs;
        Random rnd;
        public ColorMatching()
        {
            cs = new Color[] { Colors.Firebrick, Colors.DarkCyan, Colors.SeaGreen, Colors.Gold, Colors.Purple };
            ws = new string[] { "Red", "Blue", "Green", "Yellow", "Purple" };
            rnd = new Random();
            size = cs.Length;
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            backButton.Click += backButton_Click;
            btn.Click += btn2_Click;
            grid.Background = new SolidColorBrush(Colors.SeaGreen);
        }

        void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        void btn2_Click(object sender, RoutedEventArgs e)
        {
            btn.Click -= btn2_Click;
            if (first)
            {
                first = false;
                //Fade out animation
                //Fade out end
                Canvas.SetLeft(grid, extremeRight);
                nextTile();
            }
            else
            {
                int x = Convert.ToInt32(score.Text);
                if (color == word)
                    x++;
                else
                    x--;
                score.Text = Convert.ToString(x);
                btn.Click += btn2_Click;
            }
        }

        async void animateX(UIElement obj, int x, int t, int s, int n)//object,initial point,time difference,size of steps,no. of steps
        {
            for (int i = 0; i < n; i++)
            {
                await Task.Delay(t);
                x += s;
                Canvas.SetLeft(obj, x);
            }
        }
        async void animateY(UIElement obj, int y, int t, int s, int n)//object,initial point,time difference,size of steps,no. of steps
        {
            for (int i = 0; i < n; i++)
            {
                await Task.Delay(t);
                y += s;
                Canvas.SetLeft(obj, y);
            }
        }
        async void nextTile()
        {
            btn.Click -= btn2_Click;
            animateX(grid, extremeRight, 1, -50, 16);
            word = rnd.Next() % size;
            color = rnd.Next() % size;
            btn.Content = ws[word];
            grid.Background = new SolidColorBrush(cs[color]);
            await Task.Delay(800);
            btn.Click += btn2_Click;
            await Task.Delay(300);
            btn.Click -= btn2_Click;
            nextTile();
        }
    }
}
