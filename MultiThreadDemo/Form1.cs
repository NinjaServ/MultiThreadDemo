using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;

using System.Windows.Forms;
//System.Windows.Threading

using System.IO;
using System.Resources;
using System.Reflection;

using System.Diagnostics;


//Example Code from tutorials at http://csharp-video-tutorials.blogspot.com
// http://csharp-video-tutorials.blogspot.com/2014/03/part-93-protecting-shared-resources_16.html
//Venkat @ www.Pragimtech.com

namespace MultiThreadDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void btnTimeConsumingWork_Click(object sender, EventArgs e)
        //{
        //    btnTimeConsumingWork.Enabled = false;
        //    btnPrintNumbers.Enabled = false;

        //    DoTimeConsumingWork();

        //    btnTimeConsumingWork.Enabled = true;
        //    btnPrintNumbers.Enabled = true;
        //}

        private void btnTimeConsumingWork_Click(object sender, EventArgs e)
        {
            btnTimeConsumingWork.Enabled = false;
            btnPrintNumbers.Enabled = false;

            // Create another THREAD to offload the work of
            // executing the time consuming method to it.
            // As a result the UI thread, is free to execute the
            // rest of the code and our application is more responsive.
            Thread backGroundThread = new Thread(DoTimeConsumingWork);
            backGroundThread.Start();
            //DoTimeConsumingWork();

            //listBoxNumbers.Items.Clear();
            listBoxNumbers.Items.Add("**TimeConsumingWork Thread!");

            btnTimeConsumingWork.Enabled = true;
            btnPrintNumbers.Enabled = true;
        }


        private void DoTimeConsumingWork()
        {
            // Make the thread sleep, to introduce artifical latency
            Thread.Sleep(5000);
        }

        private void btnPrintNumbers_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                listBoxNumbers.Items.Add(i);
            }
        }

        private void listBoxNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private int CountCharacters()
        {
            int count = 0;

            //Add a Resource File to your project (Right Click Project->Properties->Resources). 
            // Where it says "strings", you can switch to be "files". Choose "Add Resource" and select your file.
            // reference your file through the Properties.Resources collection.
            // Resource.text;
            string resource = Properties.Resources.data;
            int cnt = resource.Length;
            int lcnt = 0;
            var lines = resource.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            List<string> words = resource.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var line in lines)
            {
                string txt = line;
                lcnt += txt.Length;
            }

            //From Solution Explorer, right click on myfile.txt and choose "Properties"
            // From there, set the Build Action to content and Copy to Output Directory to either Copy always or Copy if newer
            // have to use absolute path in this case. But set the CopyToOutputDirectory = CopyAlways,
            string filePath = System.IO.Path.GetFullPath("data.txt");
            string txtPath = Path.Combine(Environment.CurrentDirectory, "testfile.txt");
            string baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _filePath = Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName;
            _filePath += @"\Resources\Data.txt";


            string dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\Resources\data.txt";
            var filename = "data.txt";
            var reflectStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("MultiThreadDemo." + filename);
            //Assembly resourceAssembly = Assembly.LoadFrom(resource);
            //string[] manifests = resourceAssembly.GetManifestResourceNames();

            // Create a StreamReader and point it to the file to read
            using (StreamReader reader = new StreamReader(file)) // reflectStream //file //_filePath    //".\\Resources\\data.txt"
            //using (ResourceReader reader = new ResourceReader(resource))
            {
                string content = reader.ReadToEnd();
                count = content.Length;
                // Make the program look busy for 5 seconds
                Thread.Sleep(5000);
            }

            return count;
        }

        //private void btnProcessFile_Click(object sender, EventArgs e)
        //{
        //    lblCount.Text = "Processing file. Please wait...";
        //    int count = CountCharacters();
        //    lblCount.Text = count.ToString() + " characters in file";
        //}

        // Make the method async by using the async keyword
        //private async void btnProcessFile_Click(object sender, EventArgs e)
        //{
        //    // Create a task to execute CountCharacters() function
        //    // CountCharacters() function returns int, so we created Task<int>
        //    Task<int> task = new Task<int>(CountCharacters);
        //    task.Start();

        //    lblCount.Text = "Processing file. Please wait...";
        //    // Wait until the long running task completes
        //    int count = await task;
        //    lblCount.Text = count.ToString() + " characters in file";
        //}

        private void btnProcessFile_Click(object sender, EventArgs e)
        {
            Console.WriteLine(@"Button Clicked");
            lblCount.Text = "Process File Button Click";
            listBoxNumbers.Items.Clear();
            listBoxNumbers.Items.Add("Process File Button Click");

            //ProcessFile_Async();
            //ProcessFile_Thread_Fast();
            //ProcessFile_Thread_Blocking();
            //ProcessFile_Thread_Cross();
            //ProcessFile_Thread_ActionDel();
            ProcessFile_Thread();

        }

        private async void ProcessFile_Async()
        {
            // Create a task to execute CountCharacters() function
            // CountCharacters() function returns int, so we created Task<int>
            Task<int> task = new Task<int>(CountCharacters);
            task.Start();

            lblCount.Text = "Processing file. Please wait...";
            // Wait until the long running task completes
            int count = await task;
            lblCount.Text = count.ToString() + " characters in file";
        }



        private void ProcessFile_Thread_Fast()
        {
            int count = 0;
            //Lambda Function
            Thread thread = new Thread(() => { count = CountCharacters(); });
            thread.Start();

            lblCount.Text = "Processing file. Please wait...";
            lblCount.Text = count.ToString() + " characters in file";

            //lblCount.Text = "Processing file. Please wait...";
            //lblCount.Text = count.ToString() + " characters in file";
        }

        private void ProcessFile_Thread_Blocking()
        {
            int count = 0;
            Thread thread = new Thread(() => { count = CountCharacters(); });
            thread.Start();

            lblCount.Text = "Processing file. Please wait...";
            // Join() blocks the Main thread (UI Thread)
            thread.Join();
            lblCount.Text = count.ToString() + " characters in file";
        }

        private void ProcessFile_Thread_Cross()
        {
            int count = 0;
            Thread thread = new Thread(() =>
            {
                count = CountCharacters();
                // This is dangerous
                lblCount.Text = count.ToString() + " characters in file";
            });
            thread.Start();

            lblCount.Text = "Processing file. Please wait...";
        }


        //Action delegate points to a piece of code. The Action delegate is then passed to the BeginInvoke() method 
        // which asks the UI thread to execute that piece of code asynchronously in a type safe manner. 
        private void ProcessFile_Thread_ActionDel()
        {
            int count = 0;
            Thread thread = new Thread(() =>
            {
                count = CountCharacters();
                Action action = () => lblCount.Text = count.ToString() + " characters in file";
                this.BeginInvoke(action);
            });
            thread.Start();

            lblCount.Text = "Processing file. Please wait...";
        }


        int characterCount = 0;

        private void ProcessFile_Thread()
        {
            Thread thread = new Thread(() =>
            {
                characterCount = CountCharacters();
                // Action delegate points to SetLabelTextProperty method
                // Signature of SetLabelTextProperty() method should match
                // with the signature of Action delegate
                Action action = new Action(SetLabelTextProperty);
                this.BeginInvoke(action);
            });
            thread.Start();

            lblCount.Text = "Processing file. Please wait...";
        }

        private void SetLabelTextProperty()
        {
            lblCount.Text = characterCount.ToString() + " characters in file";
        }


        //-------------------
        // This BackgroundWorker is used to demonstrate the 
        // preferred way of performing asynchronous operations.
        private BackgroundWorker backgroundWorker1;

        // This event handler starts the form's 
        // BackgroundWorker by calling RunWorkerAsync.
        //
        // The Text property of the TextBox control is set
        // when the BackgroundWorker raises the RunWorkerCompleted
        // event.
        private void TextBackgroundWorkerBtn_Click(object sender, EventArgs e)
        {
            // backgroundWorker1
            // 
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);

            this.backgroundWorker1.RunWorkerAsync();

        }

        // This event handler sets the Text property of the TextBox
        // control. It is called on the thread that created the 
        // TextBox control, so the call is thread-safe.
        //
        // BackgroundWorker is the preferred way to perform asynchronous
        // operations.

        private void backgroundWorker1_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            this.textBox1.Text =
                "This text was set safely by BackgroundWorker.";
        }








        #region ThreadDemos

        //----------------
        /// <summary>
        /// Demos for Thread Operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void threadDemoButton_Click(object sender, EventArgs e)
        {
            //Thread_Join_IsAlive();
            Thread_Locks();

            this.textBox1.Text = "Run Performance Test - In Console";
            Thread_Performance_Test();

            this.textBox1.Text = "Employee Lambda Test - In Console";
            Employee_Select(); 
        }

        private void Thread_Join_IsAlive()
        {
            listBoxNumbers.Items.Clear();
            listBoxNumbers.Items.Add("ThreadDemo Button Click");


            listBoxNumbers.Items.Add("Main Started");
            Thread T1 = new Thread(Thread1Function);
            T1.Start();

            Thread T2 = new Thread(Thread2Function);
            T2.Start();

            if (T1.Join(1000))
            {
                listBoxNumbers.Items.Add("Thread1Function completed");
            }
            else
            {
                listBoxNumbers.Items.Add("Thread1Function has not completed in 1 second");
            }

            T2.Join();
            listBoxNumbers.Items.Add("Thread2Function completed");

            for (int i = 1; i <= 10; i++)
            {
                if (T1.IsAlive)
                {
                    listBoxNumbers.Items.Add("Thread1Function is still doing it's work");
                    Thread.Sleep(500);
                }
                else
                {
                    listBoxNumbers.Items.Add("Thread1Function Completed");
                    break;
                }
            }

            listBoxNumbers.Items.Add("Main Completed");
        }

        public static void Thread1Function()
        {
            Console.WriteLine("Thread1Function started");
            Thread.Sleep(5000);
            Console.WriteLine("Thread1Function is about to return");
        }

        public static void Thread2Function()
        {
            Console.WriteLine("Thread2Function started");
        }


        /// <summary>
        /// Thread Locks example
        /// </summary>
        static int Total = 0;

        private void Thread_Locks()
        {
            lblCount.Text = "Check Console";

            Stopwatch stopwatch = Stopwatch.StartNew();
            Thread thread1 = new Thread(AddOneMillion);
            Thread thread2 = new Thread(AddOneMillion_func);
            Thread thread3 = new Thread(AddOneMillion_Monitor);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();

            Console.WriteLine("Total = " + Total);

            stopwatch.Stop();
            Console.WriteLine("Time Taken in Ticks = " + stopwatch.ElapsedTicks);
        }

        /// <summary>
        /// Lock object for thread safe operations
        /// </summary>
        static object _lock = new object();

        public static void AddOneMillion()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                lock (_lock)
                {
                    Total++;
                }
            }
        }

        public static void AddOneMillion_func()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                Interlocked.Increment(ref Total);
            }
        }

        public static void AddOneMillion_Monitor()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                bool lockTaken = false;
                // Acquires the exclusive lock
                Monitor.Enter(_lock, ref lockTaken);
                try
                {
                    Total++;
                }
                finally
                {
                    // Releases the exclusive lock
                    if (lockTaken)
                        Monitor.Exit(_lock);
                }
            }
        }



        /// <summary>
        /// Thread Performance testing
        /// </summary>
        public static void Thread_Performance_Test()
        {

            Console.WriteLine("Current Processor Count on this system = "
                + Environment.ProcessorCount);

            Stopwatch stopwatch = Stopwatch.StartNew();
            Thread T1 = new Thread(EvenNumbersSum);
            Thread T2 = new Thread(OddNumbersSum);

            T1.Start();
            T2.Start();

            T1.Join();
            T2.Join();

            stopwatch.Stop();
            Console.WriteLine("Total milliseconds with multiple threads = "
                + stopwatch.ElapsedMilliseconds);
            Console.WriteLine();

            stopwatch = Stopwatch.StartNew();
            EvenNumbersSum();
            OddNumbersSum();
            stopwatch.Stop();
            Console.WriteLine("Total milliseconds without multiple threads  = "
                + stopwatch.ElapsedMilliseconds);
        }

        public static void EvenNumbersSum()
        {
            double sum = 0;
            for (int i = 0; i <= 50000000; i++)
            {
                if (i % 2 == 0)
                {
                    sum = sum + i;
                }
            }
            Console.WriteLine("Sum of even numbers = {0}", sum);
        }

        public static void OddNumbersSum()
        {
            double sum = 0;
            for (int i = 0; i <= 50000000; i++)
            {
                if (i % 2 == 1)
                {
                    sum = sum + i;
                }
            }
            Console.WriteLine("Sum of odd numbers = {0}", sum);
        }

        #endregion

        //Lambda expressions are particularly helpful for writing LINQ query expressions.
        //=> is called lambda operator and read as GOES TO.
        //In most of the cases Lambda expressions supersedes anonymous methods.

        //public static void Odd()
        //{
        //    Button1.Click += delegate
        //    {
        //        MessageBox.Show("Button Clicked");
        //    };
        //    Button1.Click += (eventSender, eventAgrs) =>
        //    {
        //        MessageBox.Show("Button Clicked");
        //    };
        //}



        public static void func_delegate()
        {
            Func<int, int, string> funcDelegate = (firstNumber, secondNumber) =>
                "Sum = " + (firstNumber + secondNumber).ToString();

            string result = funcDelegate(10, 20);
            Console.WriteLine(result);
        }


        public static void Employee_Select()
        {
            List<Employee> listEmployees = new List<Employee>() {
            new Employee{ ID = 101, Name = "Mark"},
            new Employee{ ID = 102, Name = "John"},
            new Employee{ ID = 103, Name = "Mary"},
        };

            // Create a Func delegate
            Func<Employee, string> selector = employee => "Name = " + employee.Name;
            // Pass the delegate to the Select() LINQ function
            IEnumerable<string> names = listEmployees.Select(selector);

            // The above output can be achieved using
            // lambda expression as shown below
            // IEnumerable<string> names =
            // listEmployees.Select(employee => "Name = " + employee.Name);

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Dictionary<int, string> aDict = new Dictionary<int, string> { { 101, "Marky" }, { 102, "Johnny" }, { 103, "Mary" }, { 104, "Lucy" } };
            names = aDict.Select(element => "Name = " + element.Value);
            //listEmployees.Select(selector);
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
}

public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
}

    }
}

