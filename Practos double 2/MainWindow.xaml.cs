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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practos_double_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[] buttons;
        Button[] EBut;
        bool player = true;
        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[9] { _1, _2, _3, _4, _5, _6, _7, _8, _9 };
            EBut  = buttons.Where(item => item.IsEnabled == true).ToArray();
        }


        private void _1_Click(object sender, RoutedEventArgs e)
        {   
            (sender as Button).Content = player ? "X" : "O";
            (sender as Button).IsEnabled = false;
            Proverka();
            Robot();
            
        }

        void Robot()
        {
            Random rnd = new Random();
            EBut = buttons.Where(item => item.IsEnabled == true).ToArray();
            if (EBut.Length == 0) return;
            int num_but = rnd.Next(0, EBut.Length);
            EBut[num_but].IsEnabled = false;
            EBut[num_but].Content = player ? "O" : "X";
            Proverka();
        }

        void Proverka()
        {
            if (_1.Content == _2.Content && _2.Content == _3.Content && _1.Content != "")
            {
                Status.Content = "Победил " + _1.Content;
                Block();
            }
            else if (_4.Content == _5.Content && _5.Content == _6.Content && _4.Content != "")
            {
                Status.Content = "Победил " + _4.Content;
                Block();
            }
            else if (_7.Content == _8.Content && _8.Content == _9.Content && _7.Content != "")
            {
                Status.Content = "Победил " + _7.Content;
                Block();
            }
            else if (_1.Content == _4.Content && _4.Content == _7.Content && _1.Content != "")
            {
                Status.Content = "Победил " + _1.Content;
                Block();
            }
            else if (_2.Content == _5.Content && _5.Content == _8.Content && _2.Content != "")
            {
                Status.Content = "Победил " + _2.Content;
                Block();
            }
            else if (_3.Content == _6.Content && _6.Content == _9.Content && _3.Content != "")
            {
                Status.Content = "Победил " + _3.Content;
                Block();
            }
            else if (_1.Content == _5.Content && _5.Content == _9.Content && _1.Content != "")
            {
                Status.Content = "Победил " + _1.Content;
                Block();
            }
            else if (_3.Content == _5.Content && _5.Content == _7.Content && _3.Content != "")
            {
                Status.Content = "Победил " + _3.Content;
                Block();
            }
            else if (buttons.Where(item => item.IsEnabled == true).ToArray().Length == 0)
            {
                Status.Content = "Ничья";
                Block();
            } 
        }

        void Restart()
        {
            Status.Content = "";
            foreach (Button button in buttons)
            {
                button.IsEnabled = true;
                button.Content = "";
            }
            if (!player)
            {
                Robot();
            }
        }

        void Block()
        {
            player = !player; //просто в исходной программе блокировка была нужна только после выйгрыша, а там тима меняется)
            foreach (Button button in buttons)
            {
                button.IsEnabled = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            player = !player;
            Restart();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Restart();
        }
    }
}
