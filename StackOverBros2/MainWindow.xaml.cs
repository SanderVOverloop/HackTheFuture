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

namespace StackOverBros2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int x = 2;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch(x)
            {
                case 2:
                    Challenge2();
                    break;
                case 4:
                    Challenge4();
                    break;

            }
        }

        private void Challenge2()
        {
            string id = "593bc0a2e0dfdc53b239bc2a96ab0fd5";

            int sum = 0;
            foreach(int i in inputValues.data)
            {
                sum += i;   
            }


        }

        private void Challenge4()
        {
            string id = "7a34919d6dd4c2d9c3f05c6957946b82";

            int start = 0;
            int stop = 1;
            for (int num = start; num <= stop; num++)
            {
                int control = 0;

                for (int i = 2; i <= num / 2; i++)
                {
                    if (num % i == 0)
                    {
                        control++;
                        break;
                    }
                }

                if (control == 0 && num != 1)
                    Console.Write("{0} ", num);
            }
        }
    }
}
