// Seth Urbach - NinjaServ
// Created 08/28/2017
// Running Demo code for Multithreading in Windows Forms
// Examples come from http://csharp-video-tutorials.blogspot.com
// and MSDN 
// Started Project as a console application and then converted it to Windows Application using Windows Forms Controls 
// in the Project Properties->Application->Output Type


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

//using System.Windows.Forms;


namespace MultiThreadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}


