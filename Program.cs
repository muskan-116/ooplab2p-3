using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3
{
    class Program
    {
        class entery
        {
            public string names;
            public string passwords;
        }
        static void Main(string[] args)
        {
            string path = "G:\\ooplab2\\project3\\project3\\data.txt";
            entery[] load = new entery[10];
            int option;
            int count = 0;
            count = readData(load, path);
            do
            {
                
                Console.Clear();
                option = menu();
                Console.Clear();
               
                if (option == 1)
                {

                    load[count] = total();
                    count++;
                    signUP(path, load, count);
                    
                }
                else if (option == 2)
                {
                    string names, passwords;
                    Console.WriteLine("enter user name :");
                    names = Console.ReadLine();
                    Console.WriteLine("enter password :");
                    passwords = Console.ReadLine();
                    signIN(names, passwords, load, count);

                }
            }
            while (option < 3);
            
                Console.ReadKey();
            

        }
           
    
        static int  menu()
        {
            Console.Clear();
            int choice;
            Console.WriteLine("1.press 1 for sign UP");
            Console.WriteLine("2.press 2 for sign IN");
            Console.WriteLine("3.Enter option:");
            choice = int.Parse(Console.ReadLine());
            return choice;

        }
        static string getParse(string record,int field)
        {
            int count = 1;
            string item = "";
            for(int x=0;x<record.Length;x++)
            {
                if(record[x]==',')
                {
                    count++;
                }
                else if(count==field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static int readData(entery[] load,string path)
        {
            int x = 0;

            if (File.Exists(path))
            {

                StreamReader file = new StreamReader(path);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    entery output = new entery();
                    output.names = getParse(line, 1);
                    output.passwords = getParse(line, 2);
                 
                    load[x++] = output;
                    if (x > 10)
                    {
                        break;
                    }

                }
                file.Close();
            }
            else
            {
                Console.WriteLine("no exits");
            }
            return x;
            
        }
        static void  signUP(string path, entery[] load, int count)
        {
            StreamWriter file = new StreamWriter(path, true);
            for(int i =0; i<count;i++)
            {
                file.WriteLine(load[i].names + "," + load[i].passwords);
                
            }
            file.Flush();
            file.Close();



        }
        static void signIN (string names,string passwords,entery[] load, int count)
        {
            bool flag = false;
            for (int x = 0; x < count; x++)
            {
                if (names == load[x].names && passwords == load[x].passwords)
                {
                    Console.WriteLine("valid user");
                    Console.WriteLine("press any key to continue");
                    Console.ReadKey();
                    flag = true;
                }
            }
                 if(flag == false)
                {
                    Console.WriteLine("invalid user");
                Console.WriteLine("press any key to continue");
                Console.ReadKey();


            }
            
            Console.ReadKey();
        }
        static entery total()
        {
            entery s1 = new entery();
            Console.WriteLine("enter name :");
            s1.names = Console.ReadLine();
            Console.WriteLine("enter password :");
            s1.passwords = Console.ReadLine();
            return s1;


        }

    }
}
