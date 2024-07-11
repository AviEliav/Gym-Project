using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Project
{
    internal class Coach : Person
    {

		private string _profession;

		public string Profession
		{
			get { return _profession; }
			
			set 
			{
				_profession = v.ValidProfession(value);
			}
		}



        private string _bankName;

        public string BankName
        {
            get { return _bankName; }

            set
            {
                _bankName = v.ValidBankName(value);
            }
        }



        private string _bankBranch;

        public string BankBranch
        {
            get { return _bankBranch; }

            set
            {
                _bankBranch = v.ValidBankBranch(value);
            }
        }



        private string _accountNumber;

        public string AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                _accountNumber = v.ValidAccountNumber(value);
            }
        }

        public override string ToString()
        {
            return $"ID: {Id} \nFirst name: {FirstName} \nLast name: {LastName} \nGender: {Gender} \nDate of birth: {DOB} \nAddress: {Address} \nPhone number: {PhoneNumber}  \nEmail: {Email} \nBank name: {BankName} \nBanke Branch: {BankBranch} \nAccount number: {AccountNumber} \nProfession: {Profession}  \nIs active: {IsActive}\n\n";
        }

    }
}
