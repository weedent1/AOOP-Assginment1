using System;
using System.Collections.Generic;
using System.Text;

namespace AOOP_Assignment1
{
    class Member
    {
        private string firstName, lastName, birthday, lastInTime, lastOutTime, lastDate, numberOfCheckInTimes;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Birthday
        {
            get { return birthday; }
        }

        public string LastInTime
        {
            get { return lastInTime; }
            set { lastInTime = value; }
        }

        public string LastOutTime
        {
            get { return lastOutTime; }
            set { lastOutTime = value; }
        }

        public string LastDate
        {
            get { return lastDate; }
            set { lastDate = value; }
        }

        public string NumberOfCheckInTimes
        {
            get { return numberOfCheckInTimes; }
        }


        // Member constuctor initializes member
        public Member(string fName, string lName, string bDay, string iTime, string oTime, string lDate)
        {
            firstName = fName;
            lastName = lName;
            birthday = bDay;
            lastInTime = iTime;
            lastOutTime = oTime;
            lastDate = lDate;
            numberOfCheckInTimes = "0";
        }

        // Prints member info to console
        public void printInfo()
        {
            Console.WriteLine("Member Information: ");
            Console.WriteLine("First Name: " + firstName);
            Console.WriteLine("Last Name: " + lastName);
            Console.WriteLine("Birthday: " + birthday);
            Console.WriteLine("Last Time In: " + lastInTime);
            Console.WriteLine("Last Time Out: " + lastOutTime);
            Console.WriteLine("Last Date At Facility: " + lastDate);
        }
    }
}
