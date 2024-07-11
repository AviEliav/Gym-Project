using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Project
{
    internal class Client : Person
    {


        private double _height;

        public double Height
        {
            get { return _height; }

            set
            {
                _height = (value);
            }
        }



        private double _weight;

        public double Weight
        {
            get { return _weight; }

            set
            {
                _weight = (value);
            }
        }



        private double _bmi;

        public double BMI
        {
            get { return BmiCalaulation(); }

            set
            {

            }
        }


        public double BmiCalaulation()
        {
            double bmiHeight = Height;
            return Math.Round(Weight / Math.Pow(bmiHeight , 2),2);
        }


        public override string ToString()
        {
            return $"ID: {Id} \nFirst name: {FirstName} \nLast name: {LastName} \nGender: {Gender} \nDate of birth: {DOB} \nAddress: {Address} \nPhone number: {PhoneNumber} \nEmail: {Email} \nHeight: {Height} \nWeight: {Weight} \nBMI: {BMI} \nIs active: {IsActive}\n\n";   
        }






    }
}
