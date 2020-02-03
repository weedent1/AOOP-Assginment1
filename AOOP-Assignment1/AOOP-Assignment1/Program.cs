using System;

namespace AOOP_Assignment1
{
    class Program
    {

        static private TrialMember inputMember()
        {
            Console.WriteLine("Please enter: member first name in lowercase");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter: member last name in lowercase");
            string lastName = Console.ReadLine();
            Console.WriteLine("Please enter: member birthdate ex: 01/01/1999");
            string birthDate = Console.ReadLine();
            Console.WriteLine("If trial member enter trial end date ex: 01/01/1999 if not trial member hit enter");
            string trialDate = Console.ReadLine();
            var member = new TrialMember(firstName, lastName, birthDate, "", "", "", trialDate);
            return member;
        }

        static private bool WouldYouLikeToContinue()
        {
            Console.WriteLine("Would you like to continue? Enter yes or no.");
            string resp = Console.ReadLine();
            if (resp == "no")
            {
                return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("--- Member Access Application ---");

            var SaveToCSV = new SaveToCSV();

            bool hasMembers = SaveToCSV.hasMembers();

            while (!hasMembers)
            {
                Console.WriteLine("No members found in file please create new member to get started.");
                Console.WriteLine("Creating new member:");
                var inMember = inputMember();
                SaveToCSV.writeMemberToCSV(inMember);
                hasMembers = true;
            }

            bool contin = true;

            while (contin)
            {

                Console.WriteLine("Enter: C for check in, O for checkout, or A to access members");

                string line = Console.ReadLine();

                if (line == "C")
                {
                    Console.WriteLine("Please enter: member first name in lowercase");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Please enter: member last name in lowercase");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Please enter: member birthdate ex: 01/01/1999");
                    string birthDate = Console.ReadLine();

                    var checkIn = new CheckIn();
                    var checkMember = SaveToCSV.getMember(firstName, lastName, birthDate);

                    checkIn.checkInOrOut(checkMember, "in");

                    contin = WouldYouLikeToContinue();
                }

                if (line == "O")
                {
                    Console.WriteLine("Please enter: member first name in lowercase");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Please enter: member last name in lowercase");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Please enter: member birthdate ex: 01/01/1999");
                    string birthDate = Console.ReadLine();

                    var checkIn = new CheckIn();
                    var checkMember = SaveToCSV.getMember(firstName, lastName, birthDate);

                    checkIn.checkInOrOut(checkMember, "out");

                    contin = WouldYouLikeToContinue();

                }

                if (line == "A")
                {
                    Console.WriteLine("Type add to add a new member, type delete to delete a member, type print to print a members information");
                    string resp = Console.ReadLine();
                    if(resp == "add")
                    {
                        var inMember = inputMember();
                        SaveToCSV.writeMemberToCSV(inMember);
                        Console.WriteLine("New member added.");
                    }
                    if (resp == "delete")
                    {
                        Console.WriteLine("WARNING WILL DELETE ALL RECORDS OF INPUT MEMBER");
                        Console.WriteLine("Please enter: member first name in lowercase");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Please enter: member last name in lowercase");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Please enter: member birthdate ex: 01/01/1999");
                        string birthDate = Console.ReadLine();
                        Console.WriteLine("Do you wish to delete " + firstName + " " + lastName + "'s account? enter yes or no");
                        string delete = Console.ReadLine();
                        if(delete == "yes")
                        {
                            SaveToCSV.removeMember(firstName, lastName, birthDate);
                        }
                        contin = WouldYouLikeToContinue();
                    }
                    if (resp == "print")
                    {
                        Console.WriteLine("Please enter: member first name in lowercase");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Please enter: member last name in lowercase");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Please enter: member birthdate ex: 01/01/1999");
                        string birthDate = Console.ReadLine();
                        //need to fix so checkmember can be trialMember object and can use trialMembers
                        //printInfo() method, because right now getMember() always returns Member object
                        var checkMember = SaveToCSV.getMember(firstName, lastName, birthDate);
                        checkMember.printInfo();
                    }

                }


            }

        }

    }
}
