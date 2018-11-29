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
            string id = "593bc0a2e0dfdc53b239bc2a96ab0fd5";
            
            IRestResponse<GetChallenge> response = apiClass.ApiGet(id);
            
            int sum = 0;
            foreach(InputValue i in response.Data.question.inputValues)
            {
                sum += int.Parse(i.data);
            }

            answer.name = "sum";
            answer.data = sum.ToString();
            values.Add(answer);
            Thread.Sleep(10000);
            IRestResponse<PostChallenge> postResponse = apiClass.ApiPost(response.Data.id, id, values);

            
            challenges.Add(new Challenge { Name = postResponse.Data.identifier, Completion = postResponse.Data.status });
            list_challenges.ItemsSource = challenges;

        }

        private void Challenge4()
        {

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
                else if(i.name == "end")
                {
                    stop = int.Parse(i.data);
                }
            }
            for (int num = start; num < stop; num++)
            {
                if(IsPrime(num))
                {
                    answer.name = "prime";
                    answer.data = num.ToString();
                    values.Add(answer);
                }
                    
            }
            
            
            Console.WriteLine(response.Data.id);
            Thread.Sleep(10000);
            IRestResponse<PostChallenge> postResponse = apiClass.ApiPost(response.Data.id, id, values);



            challenges.Add(new Challenge { Name = postResponse.Data.identifier, Completion = postResponse.Data.status });
            list_challenges.ItemsSource = challenges;
        }

        public static bool IsPrime(int candidate)
        {
                // Test whether the parameter is a prime number.
                if ((candidate & 1) == 0)
                {
                    if (candidate == 2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                // Note:
                // ... This version was changed to test the square.
                // ... Original version tested against the square root.
                // ... Also we exclude 1 at the end.
                for (int i = 3; (i * i) <= candidate; i += 2)
                {
                    if ((candidate % i) == 0)
                    {
                        return false;
                    }
                }
                return candidate != 1;
            
        }

        private void Challenge5()
        {
            btn_complete.IsEnabled = false;
            string id = "d230ea19237b0b1ba70e5464f00c4717";

            IRestResponse<GetChallenge> response = apiClass.ApiGet(id);

            //TODO: Code for the Challenge
            double sec = 0;
            string planet = "";

            foreach (InputValue i in response.Data.question.inputValues)
            {
                switch (i.name)
                {
                    case "ageInUniversalSeconds":
                        sec = double.Parse(i.data);
                        break;
                    case "destinationPlanet":
                        planet = i.data;
                        break;
                    default:
                        if (i.name.ToUpper().Contains(planet.ToUpper()))
                        {
                            sec = sec / double.Parse(i.data);
                        }
                        break;
                }
            }
            answer.name = "ageInYears";
            answer.data = Math.Round(sec, 2).ToString();

            values.Add(answer);
            Console.WriteLine(response.Data.id);
            Thread.Sleep(10000);
            IRestResponse<PostChallenge> postResponse = apiClass.ApiPost(response.Data.id, id, values);


            challenges.Add(new Challenge { Name = postResponse.Data.identifier, Completion = postResponse.Data.status });
            list_challenges.ItemsSource = challenges;

            Thread.Sleep(10000);
            btn_complete.IsEnabled = true;
        }

        public void Challenge8()
        {
            string id = "6451359698245e2b02bdf79d5f99fe5b";

            IRestResponse<GetChallenge> response = apiClass.ApiGet(id);

            foreach (InputValue i in response.Data.question.inputValues)
            {
                answer.name = "decoded";
                answer.data = BinaryToString(i.data);
            }
            values.Add(answer);
            Console.WriteLine(response.Data.id);
            Thread.Sleep(10000);
            IRestResponse<PostChallenge> postResponse = apiClass.ApiPost(response.Data.id, id, values);


            challenges.Add(new Challenge { Name = postResponse.Data.identifier, Completion = postResponse.Data.status });
            list_challenges.ItemsSource = challenges;
        }

        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }


        public void Challenge16()
        {
            string id = "30668de5857704bdf1e620cfb99fef51";
            IRestResponse<GetChallenge> response = apiClass.ApiGet(id);
            string roman = "";
            InputValue i = response.Data.question.inputValues[0];
            
            Console.WriteLine(i.data);
            int x = int.Parse(i.data);
            roman = ToRoman(x);
            
            answer.name = "number";
            answer.data = roman;
            values.Add(answer);
            Thread.Sleep(10000);
            IRestResponse<PostChallenge> postResponse = apiClass.ApiPost(response.Data.id, id, values);

            challenges.Add(new Challenge { Name = postResponse.Data.identifier, Completion = postResponse.Data.status });
            list_challenges.ItemsSource = challenges;

        }

        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CompleteChallenges();
        }

        private void CompleteChallenges()
        {
            Challenge2();
            Thread.Sleep(10000);
            Challenge4();
            Thread.Sleep(10000);
            //Challenge5();
            Challenge8();
            Thread.Sleep(10000);
            Challenge16();
        }

        public class Challenge
        {
            public string Name { get; set; }

            public string Completion { get; set; }
        }
    }
}
