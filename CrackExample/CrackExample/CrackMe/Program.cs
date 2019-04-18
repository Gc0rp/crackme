using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackMe
{
    class Program
    {

        public static string RunFileToCrack(string username, string password)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "CrackMe_File.exe",
                    Arguments = username + " " + password,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                return line;
            }
            return "File did not respond";
            
        }


        static void breakPassword(List<string> email) {
            string i = "0";
            string output = "";

            foreach(string currentEmail in email) {
                i = "0";
                Console.WriteLine("Currently searching: " + currentEmail);
                if (RunFileToCrack(currentEmail, i) == "User not found.") {


                    Console.WriteLine(currentEmail + " User not Found");


                } else {
                    while (int.Parse(i) <= 999)
                    {
                        output = RunFileToCrack(currentEmail, i);

                        i = (int.Parse(i) + 1).ToString();

                        if (output.ToLower() != "incorrect password")
                        {
                            Console.WriteLine(currentEmail + " " + output + " " + i);
                            break;
                        }

                    }

                }

            }

        }


        static void Main(string[] args)
        {




            List<string> email = new List<string>();
            email.Add("ihencke0@about.me");
            email.Add("kbrimblecombe1@deviantart.com");
            email.Add("apurslow2@dyndns.org");
            email.Add("hmacsharry3@answers.com");
            email.Add("hdomleog@taobao.com");
            email.Add("rperl5@youku.com");
            email.Add("svany6@apple.com");
            email.Add("bhewlings7@tiny.cc");
            email.Add("wgounet8@ox.ac.uk");
            email.Add("gwebley4@rediff.com");
            email.Add("wcruxtona@apple.com");
            email.Add("vburkittb@webeden.co.uk");
            email.Add("iandrejsc@wordpress.com");
            email.Add("ecockshutd@oakley.com");
            email.Add("jpoinsette@macromedia.com");
            email.Add("ghurlestonf@nydailynews.com");
            email.Add("jreyner9@wiley.com");
            email.Add("kcasserlyh@jugem.jp");
            email.Add("awhickmani@networksolutions.com");

            breakPassword(email);


            Console.ReadKey(true);
        }
    }
}
