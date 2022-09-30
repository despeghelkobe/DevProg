using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace demow02.Models
{
    public class Beer
    {
        private string _brewery;
        private string _name;
        private string _fullName;

        public Guid BeerId { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (value != null)
                    _name = value;
                else
                    _name = "unknown";
            }
        }

        public string Brewery
        { 
            get => _brewery;
            set
            {
                if (_brewery != null)
                    _brewery = value;
                else
                    _brewery = "unknown";
            }
        }

        public double Alcohol { get; set; }

        public string Color { get; set; }

        public string FullName
        {
            get => $"{Name} ({Brewery})";
        }


        //ctors

        public Beer(string name, string brewery, double alcohol, string color)
        {
            BeerId = Guid.NewGuid();
            Name = name;
            Brewery = brewery;
            Alcohol = alcohol;
            Color = color;
        }

        public override string ToString()
        {
            return $"Name: {FullName}, Alcohol percentage: {Alcohol}%, Color: {Color}";
        }
    }
}
