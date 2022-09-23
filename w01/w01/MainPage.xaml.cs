using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace w01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ex01();
            ex02();
            ex03();
            ex04();

        }

        private void ex04()
        {
            var scores = new Dictionary<string, int> { { "Jan", 3 }, { "Paul", 2 }, { "Jef", 5 }, { "Bram", 0 }, { "Pieter", 4 }, { "Koen", 0 } };
            Debug.WriteLine("Evalution per student:");
            foreach (var student in scores)
                showEvaluation(student);
        }

        private void ex03()
        {
            var dict_purchases = new Dictionary<String, List<int>>();
            dict_purchases.Add("jan", new List<int>() { 100, 50, 20 });
            dict_purchases.Add("piet", new List<int>() { 10, 70, 20, 4, 58, 542 });
            dict_purchases.Add("karel", new List<int>() { 9 });
            dict_purchases.Add("sandra", new List<int>() { 45, 45, 10 });
            int limitValue = 200;
            var customerList = determine_expensive_carts(dict_purchases, limitValue);
            Debug.WriteLine($"The value of the shopping cart of the following people was higher than {limitValue}€:");
            foreach (var customer in customerList)
                Debug.WriteLine($"\t- {customer}");
        }

        private void ex02()
        {
            var classroom = new Dictionary<string, int> { { "KWE.P.0.002", 200 }, { "KWE.P.1.103", 20 }, { "KWE.A.1.103", 60 }, { "KWE.A.1.104", 30 }, { "KWE.A.1.302", 64 }, { "KWE.A.1.301", 64 } };
            int groupSize = 20;
            var roomList = determine_corona_rooms(classroom, groupSize);
            Debug.WriteLine($"Suitable rooms for a group of {groupSize} students are:");
            foreach (var room in roomList)
                Debug.Write($"\t- {room}");
        }

        private void ex01()
        {
            var list_favorite_colors_children = new List<string>() { "green", "yellow", "pink", "blue", "red", "green", "pink", "yellow", "yellow", "black", "pink", "brown" };
            var colorsDict = count_colors(list_favorite_colors_children);
            Debug.WriteLine("Counting children's favorite colors:");
            foreach (var color in colorsDict)
                Debug.WriteLine($"\t- the color {color.Key} occurs {color.Value} times.");

            var colorList = give_favorite_chosen_colors(colorsDict);
            Debug.WriteLine("The colors with the most votes are:");
            foreach (var color in colorList)
                Debug.WriteLine($"\t- {color}");
        }

        private void showEvaluation(KeyValuePair<string, int> student)
        {
            string beoordeling;
            switch (student.Value)
            {
                case 0:
                    beoordeling = "Fail";
                    break;
                case 1:
                    beoordeling = "Fail";
                    break;
                case 2:
                    beoordeling = "Weak";
                    break;
                case 3:
                    beoordeling = "Average";
                    break;
                case 4:
                    beoordeling = "Average";
                    break;
                case 5:
                    beoordeling = "good";
                    break;
                default:
                    beoordeling = "Invalid  score";
                    break;
            }
            Debug.WriteLine($"\t-{student.Key} => {beoordeling}");
        }

        private List<string> determine_expensive_carts(Dictionary<string, List<int>> purchases, int limit)
        {
            var customers = new List<string>();

            foreach (var customer in purchases)
                if (customer.Value.Sum() >= limit)
                    customers.Add(customer.Key);
            return customers;
        }

        public List<string> determine_corona_rooms(Dictionary<string, int> rooms, int size)
        {
            var coronaproof = new List<string>();
            foreach (var room in rooms)
                if (room.Value / 2 >= size)
                    coronaproof.Add(room.Key);
            coronaproof.Sort();
            return coronaproof;
        }

        public List<string> give_favorite_chosen_colors(Dictionary<string, int> dict)
        {
            var colorList = new List<string>();
            var maxValue = dict.OrderByDescending(x => x.Value).FirstOrDefault().Value;
            foreach (var color in dict)
                if (color.Value == maxValue)
                    colorList.Add(color.Key);
            return colorList;
        }

        public Dictionary<string, int> count_colors(List<string> favo_colors)
        {
            var colors = new Dictionary<string, int>();

            foreach (var color in favo_colors)
            {
                if (colors.ContainsKey(color))
                    colors[color]++;
                else
                    colors.Add(color, 1);
            }
            return colors;
        }
    }
}
