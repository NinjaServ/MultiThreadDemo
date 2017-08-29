// Seth Urbach - NinjaServ
// Created 08/28/2017
// Running Demo code for Multithreading in Windows Forms
// Examples come from http://csharp-video-tutorials.blogspot.com
// and MSDN     https://msdn.microsoft.com/en-us/library/ms171728(v=vs.100).aspx?appId=Dev14IDEF1&l=EN-US&k=k(EHInvalidOperation.WinForms.IllegalCrossThreadCall)%3bk(TargetFrameworkMoniker-.NETFramework,Version%3dv4.5.2)%3bk(DevLang-csharp)&rd=true&cs-save-lang=1&cs-lang=csharp#code-snippet-2
//      https://msdn.microsoft.com/en-us/library/hh199416(v=vs.110).aspx
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


