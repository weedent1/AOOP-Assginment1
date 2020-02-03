using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AOOP_Assignment1
{
    class SaveToCSV
    {
        private List<Member> members = new List<Member>();
        private List<TrialMember> trialMembers = new List<TrialMember>();

        private String csvFile;

        // Constructor for SaveToCSV creates the csv file if not already in place
        public SaveToCSV()
        {
            string path = @"C:\Users\Tristan\Desktop\MATC\S2\Advanced Object Oriented Programing\Assignments\AOOP-Assginment1\AOOP-Assignment1\AOOP-Assignment1\members.csv";

            if (!File.Exists(path))
            {
                try
                {
                    using (FileStream fs = File.Create(path))
                    {

                    }

                 }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

        }

        // returns true if any members are already stored
        public bool hasMembers()
        {
            ReadCSV();
            if(members.Count < 1 && trialMembers.Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //gets Member object of desired member held in the csv
        public Member getMember(string firstName, string lastName, string birthDate)
        {
            ReadCSV();
            foreach ( Member member in members)
            {
                if(member.FirstName == firstName)
                {
                    if (member.LastName == lastName)
                    {
                        if (member.Birthday == birthDate)
                        {
                            return member;
                        }
                    }
                }
            }
            foreach (TrialMember member in trialMembers)
            {
                if (member.FirstName == firstName)
                {
                    if (member.LastName == lastName)
                    {
                        if (member.Birthday == birthDate)
                        {
                            return member;
                        }
                    }
                }
            }

                return null;
        }

        //reads the csv and adds the members and trial members to their respective lists
        private void ReadCSV()
        {
            string path = @"C:\Users\Tristan\Desktop\MATC\S2\Advanced Object Oriented Programing\Assignments\AOOP-Assginment1\AOOP-Assignment1\AOOP-Assignment1\members.csv";
            var lines = File.ReadLines(path);
            members = new List<Member>();
            trialMembers = new List<TrialMember>();
            foreach (string line in lines)
            {
                string[] input = line.Split(',');
                if(input.Length > 7)
                {
                    var trialMember = new TrialMember(input[0], input[1], input[2], input[3], input[4], input[5], input[6]);
                    trialMembers.Add(trialMember);
                } 
                else if(input.Length == 7)
                {
                    var member = new Member(input[0], input[1], input[2], input[3], input[4], input[5]);
                    members.Add(member);
                }
            }
        }

        //removes desired member from the csv
        public void removeMember(string firstName, string lastName, string birthDate)
        {
            ReadCSV();
            List<Member> mems = new List<Member>();
            List<TrialMember> tMems = new List<TrialMember>();

            foreach (Member member in members)
            {
                if (member.FirstName == firstName && member.LastName == lastName && member.Birthday == birthDate)
                {
                    Console.WriteLine("deleteguyy");
                }
                else
                {
                    mems.Add(member);
                }
            }
            foreach (TrialMember member in trialMembers)
            {
                if (member.FirstName == firstName && member.LastName == lastName && member.Birthday == birthDate)
                {
                    Console.WriteLine("deleteguyy");
                }
                else
                {
                    tMems.Add(member);
                }
            }

            members = mems;
            trialMembers = tMems;

            string path = @"C:\Users\Tristan\Desktop\MATC\S2\Advanced Object Oriented Programing\Assignments\AOOP-Assginment1\AOOP-Assignment1\AOOP-Assignment1\members.csv";

            var csv = new StringBuilder();
            csv.Append("");
            File.WriteAllText(path, csv.ToString());

            foreach (Member member in members)
            {
                writeMemberToCSV(member);
            }

            foreach (TrialMember member in trialMembers)
            {
                writeMemberToCSV(member);
            }

        }

        //writes Member to csv
        public void writeMemberToCSV(Member member)
        {

            var csv = new StringBuilder();


            var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6}", member.FirstName, member.LastName, member.Birthday, member.LastInTime, member.LastOutTime, member.LastDate, member.NumberOfCheckInTimes);
            csv.AppendLine(newLine);

            string path = @"C:\Users\Tristan\Desktop\MATC\S2\Advanced Object Oriented Programing\Assignments\AOOP-Assginment1\AOOP-Assignment1\AOOP-Assignment1\members.csv";

            File.AppendAllText(path, csv.ToString());
        }

        //writes TrialMember to csv
        public void writeMemberToCSV(TrialMember member)
        {

            var csv = new StringBuilder();

            var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", member.FirstName, member.LastName, member.Birthday, member.LastInTime, member.LastOutTime, member.LastDate, member.NumberOfCheckInTimes, member.TrialEndDate);
            csv.AppendLine(newLine);

            string path = @"C:\Users\Tristan\Desktop\MATC\S2\Advanced Object Oriented Programing\Assignments\AOOP-Assginment1\AOOP-Assignment1\AOOP-Assignment1\members.csv";

            File.AppendAllText(path, csv.ToString());
        }

        //checks a memeber in or out and updates csv with check in or check out information
        public void checkInOrOut(string first, string last, string bday, string time, string checkInOrOut)
        {
            ReadCSV();
            var csv = new StringBuilder();

            foreach (Member member in members)
            {
                if (member.FirstName == first && member.LastName == last && member.Birthday == bday)
                {
                    if (checkInOrOut == "in") {
                        member.LastInTime = time;
                        member.LastDate = DateTime.Now.ToString("M/d/yyyy");
                    }
                    if (checkInOrOut == "out")
                    {
                        member.LastOutTime = time;
                        member.LastDate = DateTime.Now.ToString("M/d/yyyy");
                    }
                }
                var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6}", member.FirstName, member.LastName, member.Birthday, member.LastInTime, member.LastOutTime, member.LastDate, member.NumberOfCheckInTimes);
                csv.AppendLine(newLine);
            }

            foreach (TrialMember member in trialMembers)
            {
                if (member.FirstName == first && member.LastName == last && member.Birthday == bday)
                {
                    if (checkInOrOut == "in")
                    {
                        member.LastInTime = time;
                        member.LastDate = DateTime.Now.ToString("M/d/yyyy");
                    }
                    if (checkInOrOut == "out")
                    {
                        member.LastOutTime = time;
                        member.LastDate = DateTime.Now.ToString("M/d/yyyy");
                    }
                }
                var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", member.FirstName, member.LastName, member.Birthday, member.LastInTime, member.LastOutTime, member.LastDate, member.NumberOfCheckInTimes, member.TrialEndDate);
                csv.AppendLine(newLine);
            }

            string path = @"C:\Users\Tristan\Desktop\MATC\S2\Advanced Object Oriented Programing\Assignments\AOOP-Assginment1\AOOP-Assignment1\AOOP-Assignment1\members.csv";

            File.WriteAllText(path, csv.ToString());
        }
    }
}
