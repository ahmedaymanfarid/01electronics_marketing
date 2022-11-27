using _01electronics_library;
using System;
using System.ComponentModel;
using _01electronics_windows_library;
using System.IO;
using System.Windows;
using System.Timers;
using System.Threading;
using _01electronics_marketing;

namespace _01electronics_marketing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Navigation.NavigationWindow
    {

        bool canceled = false;
        int progress = 0;
        bool closedWindow = false;
        private BackgroundWorker backgroundWorker = new BackgroundWorker();


        //Timer timer=new Timer(60000);

        FTPServer ftpServer = new FTPServer();
        bool fileFound = true;
        public MainWindow(ref Employee mLoggedInUser)
        {

            this.Closing += NavigationWindow_Closing;

            backgroundWorker.WorkerReportsProgress = true;


            InitializeComponent();

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\01 Electronics"))
            {
                fileFound = false;
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\01 Electronics\\erp_system\\products_photos");
                //ftpServer.GetModificationTime();

            }


            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\01 Electronics\\Upload"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\01 Electronics\\Upload");
                //ftpServer.GetModificationTime();

            }

            if (!File.Exists(Directory.GetCurrentDirectory() + "\\LastInstruction.txt"))
            {

                File.Create(Directory.GetCurrentDirectory() + "\\LastInstruction.txt").Close();
            }


            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Server"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Server");
            }

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Client.txt"))
            {

                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Client.txt").Close();

            }


            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Server.txt"))
            {

                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Server.txt").Close();

            }

            SystemWatcher watcher = new SystemWatcher(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\01 Electronics", BASIC_MACROS.CLIENT_ID, backgroundWorker);


            String[] instructions = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\LastInstruction.txt");
            File.Delete(Directory.GetCurrentDirectory() + "\\ServerDownload.txt");
            File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Server.txt", Directory.GetCurrentDirectory() + "\\ServerDownload.txt");

            string[] serverInstructions = File.ReadAllLines(Directory.GetCurrentDirectory() + "\\ServerDownload.txt");





            if (fileFound == false)
            {
                backgroundWorker.DoWork += BackgroundStart;
                backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
                backgroundWorker.RunWorkerAsync();
            }



            else if (serverInstructions.Length != 0)
            {

                DateTime dateTime = Convert.ToDateTime(serverInstructions[serverInstructions.Length - 1].Split(',')[0]);

                if (instructions.Length != 0)
                {




                    if (Convert.ToDateTime(instructions[0]) != dateTime)
                    {

                        ftpServer.UploadForSynchronization();
                    }

                }

            }







            //timer.Elapsed += (o, s) => Task.Factory.StartNew(() => OnTimerElapsed(o, s));
            //timer.Start();

            CategoriesPage statisticsPage = new CategoriesPage(ref mLoggedInUser);
            this.NavigationService.Navigate(statisticsPage);

        }


        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress = e.ProgressPercentage;
        }


        //private void OnTimerElapsed(object o, ElapsedEventArgs s)
        //{
        //    if (ftpServer.CheckDateChanged() == false)
        //        MessageBox.Show("Nothing Changed");
        //    else {
        //        ftpServer.GetFileParsing();     
        //    }
        //}

        public MainWindow()
        {
        }

        private void BackgroundStart(object sender, DoWorkEventArgs e)
        {
            backgroundWorker.WorkerReportsProgress = true;

            String errorMessage = String.Empty;
            if (!ftpServer.DownloadFolder(BASIC_MACROS.MODELS_PHOTOS_PATH, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\01 Electronics\\erp_system\\products_photos\\", ref errorMessage))
            {
                return;
            }


            backgroundWorker.ReportProgress(100);

            if (closedWindow == true)
            {
                CancelEventArgs cancelEventArgs = new CancelEventArgs();
                NavigationWindow_Closing(null, cancelEventArgs);
            }


        }

        //private void BackgroundExecuteRest(object sender,RunWorkerCompletedEventArgs e)
        //{
        //    String errorMessage = String.Empty;
        //    if (!ftpServer.DownloadFolder(BASIC_MACROS.MODELS_PHOTOS_PATH, Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\01 Electronics\\products_photos\\", ref errorMessage))
        //    {
        //        return;
        //    }

        //    backgroundWorker.ReportProgress(100);
        //    if (closedWindow == true) {
        //        CancelEventArgs cancelEventArgs = new CancelEventArgs();
        //        cancelEventArgs.Cancel = false;
        //        NavigationWindow_Closing(null, cancelEventArgs);
        //    }

        //    Thread.CurrentThread.Suspend();
        //}

        private void NavigationWindow_Closing(object sender, CancelEventArgs e)
        {
            if (canceled == true)
                return;
            closedWindow = true;

            this.Dispatcher.Invoke(() =>
            {

                if (backgroundWorker.IsBusy == true)
                {

                    if (progress == 100)
                    {
                        canceled = true;
                        this.Close();

                    }
                    else
                    {
                        e.Cancel = true;
                        this.Hide();
                    }

                }
                else
                {
                    e.Cancel = false;
                }

            });

        }

        private void NavigationWindow_Closed(object sender, EventArgs e)
        {

        }
    }
}
