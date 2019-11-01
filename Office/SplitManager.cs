using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using SplitExcel.Tools;

namespace SplitExcel.Office
{
    internal class SplitManager
    {
        internal event RunWorkerCompletedEventHandler SpliterCompleted;
        internal event ProgressChangedEventHandler ProgressChanged;        

        SplitFileParameters Parameters;
        private bool UseMultiThreads = false;
        private int split_ItemsNumber = 0;
        private int split_ItemsSaved = 0;
        private int ThreadsNumber = 0;
        private int ThreadsFinished = 0;
        List<BackgroundWorker> workers;

        string errorMessage = string.Empty;

        private ProgressTicker ticker;

        public bool IsBusy { get; private set; }
        public int ItemsSaved { get { return split_ItemsSaved; } }
        public int ItemsNumber { get { return split_ItemsNumber; } }
        private bool IsCancelled { get; set; }

        public SplitManager(bool useMultiThreads)
        {
            this.UseMultiThreads = useMultiThreads;
        }

        public void StartSplit(SplitFileParameters p)
        {
            this.Parameters = p;
            BackgroundWorker bw_ExcelReader = new BackgroundWorker();
            bw_ExcelReader.DoWork += Bw_ExcelReader_DoWork;
            bw_ExcelReader.RunWorkerCompleted += Bw_ExcelReader_RunWorkerCompleted;
            this.ProgressChanged?.Invoke(null, new ProgressChangedEventArgs(0, "Чтение файла..."));
            bw_ExcelReader.RunWorkerAsync(p);
        }

        private void Bw_ExcelReader_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> list = new List<string>();
            SplitFileParameters p = (SplitFileParameters)e.Argument;         

            using (Office.UsingExcel usXl = new Office.UsingExcel())
            {
                list = usXl.GetSplitValues(p);
            }

            if (list.Count == 0)
                throw new Exception("Пустой диапазон или ошибка чтения критериев");

            e.Result = list;
        }

        private void Bw_ExcelReader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
                this.SpliterCompleted?.Invoke(null, new RunWorkerCompletedEventArgs(null, e.Error, false));
            else
            {
                List<string> list = (List<string>)e.Result;

                this.split_ItemsNumber = list.Count;
                this.ProgressChanged?.Invoke(null, new ProgressChangedEventArgs(0, $"Обработано 0 из {list.Count}"));

                int transactions = (Parameters.RowEnd - Parameters.RowBegin + 1) * this.split_ItemsNumber;
                this.ticker = new ProgressTicker(transactions, 1);
                this.ticker.ProgressChanged += Ticker_ProgressChanged;
                

                List<List<string>> splittedList = Extentions.SplitList(list, this.UseMultiThreads);
                this.ThreadsNumber = splittedList.Count;
                this.IsBusy = true;
                workers = new List<BackgroundWorker>();
                foreach (List<string> l in splittedList)
                {
                    SplitThread thread = new Office.SplitThread(this.Parameters);
                    BackgroundWorker bw_SplitThread = new BackgroundWorker();
                    bw_SplitThread.WorkerReportsProgress = true;
                    bw_SplitThread.WorkerSupportsCancellation = true;
                    bw_SplitThread.DoWork += thread.SplitExcelFile; 
                    bw_SplitThread.ProgressChanged += Bw_SplitThread_ProgressChanged;
                    bw_SplitThread.RunWorkerCompleted += Bw_SplitThread_RunWorkerCompleted;

                    workers.Add(bw_SplitThread);
                    bw_SplitThread.RunWorkerAsync(l);                                        
                }
            }
        }
        public void CancelAsync()
        {
            if (this.IsCancelled)
                return;

            if (this.IsBusy)
            {
                this.ProgressChanged?.Invoke(null, new ProgressChangedEventArgs(-1, "Ожидание завершения потоков..."));

                foreach (var worker in this.workers)
                {
                    if (worker.IsBusy)
                        worker.CancelAsync();
                }
                this.IsCancelled = true;
            }
        }

        private void Ticker_ProgressChanged(ProgressData data)
        {
            this.ProgressChanged?.Invoke(null, new ProgressChangedEventArgs(data.Progress, null));
        }

        private void Bw_SplitThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                split_ItemsSaved++;
                if (!this.IsCancelled)
                {
                    this.ProgressChanged?.Invoke(null, new ProgressChangedEventArgs(-1, $"Обработано {split_ItemsSaved} из {split_ItemsNumber}"));
                }
                
            }
            else
                this.ticker.Tick();
        }

        private void Bw_SplitThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.errorMessage += e.Error.Message;
            }
            else if(!this.IsCancelled)
            {
                (e.Result as SplitThread).Dispose();
            }
            this.ThreadsFinished++;
            if (ThreadsFinished == ThreadsNumber)
            {
                Exception err = string.IsNullOrEmpty(this.errorMessage) ? null : new Exception(this.errorMessage);
                this.SpliterCompleted(null, new RunWorkerCompletedEventArgs(this.Parameters, err, this.IsCancelled));                
            }                
        }

        
    }
}
