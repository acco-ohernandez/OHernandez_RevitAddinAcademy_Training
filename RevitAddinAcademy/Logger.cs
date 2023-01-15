using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RevitAddinAcademy
{
    internal class Logger
    {
        public string Filepath { get; set; }
        public string Username { get; set; }
        public string Logpath { get; set; }

        public Logger(string filepath, string username) 
        {
            Filepath= filepath;
            Username= username;

            Logpath = @"C:\temp\RAA log.csv";
        }

        public void method1()
        {
            string message = Filepath + "," + Username + "," + DateTime.Now.ToString();
            WriteToLog(message);
        }

        public void method2()
        {

        }

        public void method3(string assembly, string method, string error)
        {
            string message = "ERROR, " + assembly + ":" + method + "," + error;
            WriteToLog(message);
        }

        private void WriteToLog(string message)
        {
            if (File.Exists(Logpath) == false)
            {
                string header = "item1,item2,item3";
                File.WriteAllText(Logpath, header + Environment.NewLine);
            }

            File.AppendAllText(Logpath, message + Environment.NewLine);
        }
    }
}
