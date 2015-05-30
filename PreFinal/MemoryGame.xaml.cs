using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PreFinal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MemoryGame : Page
    {
        static int intscore=0;
        Random rnd;
        Button[] btns;
        string[] ws;
        Color[] cs;
        int[] b, c;
        int choice; Button bchoice;
        public MemoryGame()
        {
            this.InitializeComponent();
            cs = new Color[] { Colors.Firebrick, Colors.DarkCyan, Colors.SeaGreen, Colors.Gold, Colors.Purple };
            ws = new string[] { "Red", "Blue", "Green", "Yellow", "Purple" };
            rnd = new Random();
            btns = new Button[] { b1, b2, b3, b4, b5 };
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            backButton.Click += backButton_Click;
            score.Text = Convert.ToString(intscore);
            int[] a = new int[cs.Length];
            for (int i = 0; i < cs.Length; i++)
                a[i] = i;
            b = a.OrderBy(x => rnd.Next()).ToArray();
            c = a.OrderBy(x => rnd.Next()).ToArray();
            g1.Background = new SolidColorBrush(cs[b[0]]);
            g2.Background = new SolidColorBrush(cs[b[1]]);
            g3.Background = new SolidColorBrush(cs[b[2]]);
            g4.Background = new SolidColorBrush(cs[b[3]]);
            g5.Background = new SolidColorBrush(cs[b[4]]);
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].Content = ws[c[i]];
            }
            progress();
            Change();
        }

        void backButton_Click(object sender, RoutedEventArgs e)
        {
            intscore = 0;
            this.Frame.Navigate(typeof(MainPage));
        }
        public async void Change()
        {
            await Task.Delay(3000);
            for (int i = 0; i < btns.Length; i++)
                btns[i].Content = "";
            question.Visibility = Visibility.Visible;
            choice=rnd.Next()%5;
            question.Text = "On which tile was " + ws[c[choice]] + " written?";
            for(int i=0;i<5;i++)
                btns[i].Click += MemoryGame_Click;
            bchoice = btns[choice];
        }

        void MemoryGame_Click(object sender, RoutedEventArgs e)
        {
            if (sender == bchoice)
            {
                int s = Convert.ToInt32(score.Text);
                intscore=++s;
                score.Text = Convert.ToString(s);
            }
            else
            {
                int s = Convert.ToInt32(score.Text);
                intscore = --s;
                score.Text = Convert.ToString(s);
            }
            this.Frame.Navigate(typeof(MemoryGame));
        }
        public async void progress()
        {
            int i;
            for (i = 100; i > 0; i--)
            {
                await Task.Delay(20);
                progressBar.Value--;
            }
            progressBar.Visibility = Visibility.Collapsed;
        }
    }

}
