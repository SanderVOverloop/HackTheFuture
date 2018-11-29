using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        private int x = 2;
        private List<Challenge> challenges = new List<Challenge>();
        private ApiClass apiClass = new ApiClass();
        private InputValue answer = new InputValue();
        private List<InputValue> values = new List<InputValue>();

        private void Challenge2()
        {
            btn_complete.IsEnabled = false;
            string id = "593bc0a2e0dfdc53b239bc2a96ab0fd5";
            
            IRestResponse<GetChallenge> response = apiClass.ApiGet(id);
            
            int sum = 0;
            foreach(InputValue i in response.Data.question.inputValues)
            {
                sum += int.Parse(i.data);
            }

            answer.name = "sum";
            answer.data = sum.ToString();
            List<InputValue> values = new List<InputValue>();
            values.Add(answer);
            Console.WriteLine(response.Data.id);
            Thread.Sleep(10000);
            IRestResponse<PostChallenge> postResponse = apiClass.ApiPost(response.Data.id, id, values);

            
            challenges.Add(new Challenge { Name = postResponse.Data.identifier, Completion = postResponse.Data.status });
            list_challenges.ItemsSource = challenges;
            
            Thread.Sleep(10000);
            btn_complete.IsEnabled = true;

        }

        private void Challenge4()
        {
            btn_complete.IsEnabled = false;

            string id = "7a34919d6dd4c2d9c3f05c6957946b82";
            IRestResponse<GetChallenge> response = apiClass.ApiGet(id);

            int start = 0;
            int stop = 1;
            foreach (InputValue i in response.Data.question.inputValues)
            {
                if(i.name == "start")
                {
                    start = int.Parse(i.data);
                }
                else if(i.name == "stop")
                {
                    stop = int.Parse(i.data);
                }
            }
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
                    answer.name = "prime";
                    answer.data = num.ToString();
                    values.Add(answer);
            }

            
            
            
            Console.WriteLine(response.Data.id);
            Thread.Sleep(10000);
            IRestResponse<PostChallenge> postResponse = apiClass.ApiPost(response.Data.id, id, values);



            challenges.Add(new Challenge { Name = postResponse.Data.identifier, Completion = postResponse.Data.status });
            list_challenges.ItemsSource = challenges;
            Thread.Sleep(10000);
            btn_complete.IsEnabled = true;
        }

        private void Challenge5()
        {
            btn_complete.IsEnabled = false;
            string id = "d230ea19237b0b1ba70e5464f00c4717";

            IRestResponse<GetChallenge> response = apiClass.ApiGet(id);

            //TODO: Code for the Challenge
            int sum = 0;
            foreach (InputValue i in response.Data.question.inputValues)
            {
                sum += int.Parse(i.data);
            }

            InputValue answer = new InputValue();
            answer.name = "sum";
            answer.data = sum.ToString();
            List<InputValue> values = new List<InputValue>();
            values.Add(answer);
            Console.WriteLine(response.Data.id);
            Thread.Sleep(10000);
            IRestResponse<PostChallenge> postResponse = apiClass.ApiPost(response.Data.id, id, values);


            challenges.Add(new Challenge { Name = postResponse.Data.identifier, Completion = postResponse.Data.status });
            list_challenges.ItemsSource = challenges;

            Thread.Sleep(10000);
            btn_complete.IsEnabled = true;
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

        public class Challenge
        {
            public string Name { get; set; }

            public string Completion { get; set; }
        }
    }
}
