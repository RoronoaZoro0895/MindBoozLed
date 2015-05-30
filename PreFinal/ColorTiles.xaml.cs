using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using System.Threading.Tasks;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PreFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ColorTiles : Page
    {
        SolidColorBrush[] randArray1 = { new SolidColorBrush(Colors.Red), new SolidColorBrush(Colors.Green), 
            new SolidColorBrush(Colors.Yellow), new SolidColorBrush(Colors.Blue) };
        string[] str = { "Red", "Green", "Yellow", "Blue" };
        int cur;
        int[][] g = new int[4][];
        int[][] h = new int[4][];

        Random rnd = new Random();
        void initial()
        {


            int[] rndindexer = new int[4], indexer = { 0, 1, 2, 3 };
            int p, q, i;
            rnd.Next();
            rndindexer = indexer.OrderBy(x => rnd.Next()).ToArray();
            q = rnd.Next() % 2;

            p = rnd.Next() % 4;
            btn1.Background = randArray1[rndindexer[0]]; g[0][0] = rndindexer[0];
            btn2.Background = randArray1[rndindexer[1]]; g[0][1] = rndindexer[1];
            btn3.Background = randArray1[rndindexer[2]]; g[0][2] = rndindexer[2];
            btn4.Background = randArray1[rndindexer[3]]; g[0][3] = rndindexer[3];
            i = rndindexer[p];
            switch (p)
            {
                case 0:
                    btn1.Content = str[i]; h[0][0] = rndindexer[0];
                    if (q == 1)
                    {
                        btn2.Content = str[rndindexer[2]]; h[0][1] = rndindexer[2];
                        btn3.Content = str[rndindexer[3]]; h[0][2] = rndindexer[3];
                        btn4.Content = str[rndindexer[1]]; h[0][3] = rndindexer[1];
                    }
                    else
                    {
                        btn2.Content = str[rndindexer[3]]; h[0][1] = rndindexer[3];
                        btn3.Content = str[rndindexer[1]]; h[0][2] = rndindexer[1];
                        btn4.Content = str[rndindexer[2]]; h[0][3] = rndindexer[2];
                    }
                    break;
                case 1:
                    btn2.Content = str[i]; h[0][1] = rndindexer[1];
                    if (q == 1)
                    {
                        btn1.Content = str[rndindexer[3]]; h[0][0] = rndindexer[3];
                        btn3.Content = str[rndindexer[0]]; h[0][2] = rndindexer[0];
                        btn4.Content = str[rndindexer[2]]; h[0][3] = rndindexer[2];
                    }
                    else
                    {
                        btn1.Content = str[rndindexer[2]]; h[0][0] = rndindexer[2];
                        btn3.Content = str[rndindexer[3]]; h[0][2] = rndindexer[3];
                        btn4.Content = str[rndindexer[0]]; h[0][3] = rndindexer[0];
                    }
                    break;
                case 2:
                    btn3.Content = str[i]; h[0][2] = rndindexer[2];
                    if (q == 1)
                    {
                        btn1.Content = str[rndindexer[1]]; h[0][0] = rndindexer[1];
                        btn2.Content = str[rndindexer[3]]; h[0][1] = rndindexer[3];
                        btn4.Content = str[rndindexer[0]]; h[0][3] = rndindexer[0];
                    }
                    else
                    {
                        btn1.Content = str[rndindexer[3]]; h[0][0] = rndindexer[3];
                        btn2.Content = str[rndindexer[0]]; h[0][1] = rndindexer[0];
                        btn4.Content = str[rndindexer[1]]; h[0][3] = rndindexer[1];
                    }
                    break;
                case 3:
                    btn4.Content = str[i]; h[0][3] = rndindexer[3];
                    if (q == 1)
                    {
                        btn1.Content = str[rndindexer[1]]; h[0][0] = rndindexer[1];
                        btn2.Content = str[rndindexer[2]]; h[0][1] = rndindexer[2];
                        btn3.Content = str[rndindexer[0]]; h[0][2] = rndindexer[0];
                    }
                    else
                    {
                        btn1.Content = str[rndindexer[2]]; h[0][0] = rndindexer[2];
                        btn2.Content = str[rndindexer[0]]; h[0][1] = rndindexer[0];
                        btn3.Content = str[rndindexer[1]]; h[0][2] = rndindexer[1];
                    }
                    break;
            }
        }
        void shiftdown()
        {
            btn13.Content = btn9.Content; h[3][0] = h[2][0];
            btn14.Content = btn10.Content; h[3][1] = h[2][1];
            btn15.Content = btn11.Content; h[3][2] = h[2][2];
            btn16.Content = btn12.Content; h[3][3] = h[2][3];
            btn13.Background = btn9.Background; g[3][0] = g[2][0];
            btn14.Background = btn10.Background; g[3][1] = g[2][1];
            btn15.Background = btn11.Background; g[3][2] = g[2][2];
            btn16.Background = btn12.Background; g[3][3] = g[2][3];

            btn9.Background = btn5.Background; h[2][0] = h[1][0]; g[2][0] = g[1][0];
            btn10.Background = btn6.Background; h[2][1] = h[1][1]; g[2][1] = g[1][1];
            btn11.Background = btn7.Background; h[2][2] = h[1][2]; g[2][2] = g[1][2];
            btn12.Background = btn8.Background; h[2][3] = h[1][3]; g[2][3] = g[1][3];
            btn9.Content = btn5.Content;
            btn10.Content = btn6.Content;
            btn11.Content = btn7.Content;
            btn12.Content = btn8.Content;

            btn5.Content = btn1.Content; h[1][0] = h[0][0]; g[1][0] = g[0][0];
            btn6.Content = btn2.Content; h[1][1] = h[0][1]; g[1][1] = g[0][1];
            btn7.Content = btn3.Content; h[1][2] = h[0][2]; g[1][2] = g[0][2];
            btn8.Content = btn4.Content; h[1][3] = h[0][3]; g[1][3] = g[0][3];
            btn5.Background = btn1.Background;
            btn6.Background = btn2.Background;
            btn7.Background = btn3.Background;
            btn8.Background = btn4.Background;
        }

        public ColorTiles()
        {
            this.InitializeComponent();
            backButton.Click += backButton_Click;
            for (int j = 0; j < 4; j++)
            {
                g[j] = new int[4];
                h[j] = new int[4];
                for (int k = 0; k < 4; k++)
                    g[j][k] = h[j][k] = -1;
            }
            initial();
            for (int i = 0; i < 6; i++)
            {

                shiftdown();
                initial();
            }

        }

        void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btn13_Click(object sender, RoutedEventArgs e)
        {
            if (g[3][0] == h[3][0])
            {
                int temp;
                temp = (Convert.ToInt32(score.Text) + 1);
                score.Text = Convert.ToString(temp);
            }
            else
            {
                int temp;
                temp = (Convert.ToInt32(score.Text) - 1);
                score.Text = Convert.ToString(temp);
            }
            shiftdown();
            initial();
        }
        private void btn14_Click(object sender, RoutedEventArgs e)
        {
            if (g[3][1] == h[3][1])
            {

                int temp;
                temp = (Convert.ToInt32(score.Text) + 1);
                score.Text = Convert.ToString(temp);
            }
            else
            {
                int temp;
                temp = (Convert.ToInt32(score.Text) - 1);
                score.Text = Convert.ToString(temp);
            }
            shiftdown();
            initial();
        }
        private void btn15_Click(object sender, RoutedEventArgs e)
        {
            if (g[3][2] == h[3][2])
            {
                int temp;
                temp = (Convert.ToInt32(score.Text) + 1);
                score.Text = Convert.ToString(temp);
            }
            else
            {
                int temp;
                temp = (Convert.ToInt32(score.Text) - 1);
                score.Text = Convert.ToString(temp);
            }
            shiftdown();
            initial();
        }
        private void btn16_Click(object sender, RoutedEventArgs e)
        {
            if (g[3][3] == h[3][3])
            {
                int temp;
                temp = (Convert.ToInt32(score.Text) + 1);
                score.Text = Convert.ToString(temp);
            }
            else
            {
                int temp;
                temp = (Convert.ToInt32(score.Text) - 1);
                score.Text = Convert.ToString(temp);
            }
            shiftdown();
            initial();
        }
    }
}
