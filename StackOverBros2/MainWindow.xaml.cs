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
using RestSharp;
using StackOverBros2.Challenge_Classes;
using StackOverBros2.Objects;

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
        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }*/

        private void Challenge2()
        {
            string id = "593bc0a2e0dfdc53b239bc2a96ab0fd5";
            ApiClass apiClass = new ApiClass();
            IRestResponse<GetChallenge> response = apiClass.ApiGet(id);
            
            int sum = 0;
            foreach(InputValue i in response.Data.question.inputValues)
            {
                sum += int.Parse(i.data);
                Console.WriteLine(i.data);
            }

            Console.WriteLine(sum);


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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            switch (x)
            {
                case 2:
                    Challenge2();
                    break;
                case 4:
                    Challenge4();
                    break;

            }
        }
    }
}
