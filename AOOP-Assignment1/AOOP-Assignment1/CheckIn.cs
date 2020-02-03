using System;
using System.Collections.Generic;
using System.Text;

namespace AOOP_Assignment1
{
    class CheckIn
    {
        //sends info to savetocsv and checks in or out the member
        public void checkInOrOut(Member member, string inOrOut)
        {
            string checkInTime = DateTime.Now.ToString("h:mm:ss tt");
            var save = new SaveToCSV();
            save.checkInOrOut(member.FirstName, member.LastName, member.Birthday, checkInTime, inOrOut);
        }
    }
}
