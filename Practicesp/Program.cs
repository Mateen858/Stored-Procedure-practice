using System;
using Model;
using Data;
using System.Collections.Generic;

namespace Practicesp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 for new record, 2 for update, 3 for print all records, 4 for Delete, 5 for search");
            int choice = int.Parse(Console.ReadLine());
            while (choice != -1)
            {
                switch (choice)
                {
                    case 1:
                        {
                            Users user = new Users();
                            Console.WriteLine("please enter name");
                            user.Name = Console.ReadLine();
                            Console.WriteLine("please enter age");
                            user.Age = Console.ReadLine();
                            Console.WriteLine("please enter isEmployed");
                            user.IsEmployed = Convert.ToBoolean(Console.ReadLine());
                            Console.WriteLine("please enter Dob");
                            user.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
                            int rowEffected = new UserDac().Save(user);
                            Console.WriteLine(rowEffected + " Rows effected");
                            break;
                        }
                    case 2:
                        {
                            Users user = new Users();
                            Console.WriteLine("please enter Id");
                            user.Id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("please enter name");
                            user.Name = Console.ReadLine();
                            Console.WriteLine("please enter age");
                            user.Age = Console.ReadLine();
                            Console.WriteLine("please enter isEmployed");
                            user.IsEmployed = Convert.ToBoolean(Console.ReadLine());
                            Console.WriteLine("please enter Dob");
                            user.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
                            int rowEffected = new UserDac().Update(user);
                            Console.WriteLine(rowEffected + " Rows effected");
                            break;
                        }

                    case 3:
                        {
                            List<Users> users = new UserDac().GetAll();

                            foreach(var user in users)
                            {
                                Console.WriteLine("Id: \t" + user.Id + "\t Name: \t" + user.Name + "\t Age: \t" + user.Age + "\t IsEmployed \t" + user.IsEmployed + "\t DOB: \t" + user.DateOfBirth + "\n");
                            }

                            break;
                        }

                    case 4:
                        {
                            Console.WriteLine("please enter Id");
                            int id = int.Parse(Console.ReadLine());
                            int rowEffected = new UserDac().Delete(id);
                            Console.WriteLine(rowEffected + " Rows effected");
                            break;
                        }

                    case 5:
                        {
                            Console.WriteLine("please enter Id");
                            string name = Console.ReadLine();
                            List<Users> users =  new UserDac().Search(name);
                            foreach (var user in users)
                            {
                                Console.WriteLine("Id: \t" + user.Id + "\t Name: \t" + user.Name + "\t Age: \t" + user.Age + "\t IsEmployed \t" + user.IsEmployed + "\t DOB: \t" + user.DateOfBirth + "\n");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("wrong choice pls enter again");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        }

                }

                Console.WriteLine("1 for new record, 2 for update, 3 for print all records, 4 for Delete, 5 for search, -1 for exit");
                choice = int.Parse(Console.ReadLine());
            }







        }
    }
}
