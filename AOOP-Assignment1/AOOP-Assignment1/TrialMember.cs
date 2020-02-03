using System;
using System.Collections.Generic;
using System.Text;

namespace AOOP_Assignment1
{
    class TrialMember : Member
    {
        private string trialEndDate;

        public string TrialEndDate
        {
            get { return trialEndDate; }
        } 

        // Trial member constructor calls base constructor then sets trialEnd date
        public TrialMember(string fName, string lName, string bDay, string iTime, string oTime, string lDate, string tEndDate) : base(fName, lName, bDay, iTime, oTime, lDate)
        {
            trialEndDate = tEndDate;
        }

        // Prints member info calling bases method first then adds the trial end date
        public void printInfo()
        {
            base.printInfo();
            Console.WriteLine("TrialEndDate: " + trialEndDate);
        }
    }
}
