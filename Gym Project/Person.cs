using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Project
{
    abstract class Person
    {
       
      protected Validation v = new Validation();


        private string _id;

        public string Id
        {
            get { return _id; }

            set
            {
                _id = v.ValidId(value);
            }

        }
        
       

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            
            set 
            { 
              _firstName = v.ValidFirstName(value);
            }
        }



        private string _lastName;

        public string LastName
        {
            get { return _lastName;}

            set 
            {
              _lastName = v.ValidLastName(value);
            }
        }


        private char _gender;

        public char Gender
        {
            get { return _gender;}
           
            set 
            {
              _gender = v.ValidGender(value);
            }
        }



        private string _dob;

        public  string DOB
        {
            get { return _dob;}
           
            set 
            {
              _dob = v.ValidDOB(value);
            }
        }



        private string _address;

        public string Address
        {
            get { return _address;}
            
            set
            {
               _address = v.ValidAddress(value);
            }
        }



        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber;}

            set
            {
               _phoneNumber = v.ValidPhoneNumber(value);
            }
        }


        
        private string _email;

        public  string Email
        {
            get { return _email; }
           
            set
            { 
               _email = v.ValidEmail (value); 
            }
        }


      
        
        private bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }
            
            set 
            {
                _isActive = value;
            }
        }





    }
}
