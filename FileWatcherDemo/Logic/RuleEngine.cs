using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.IO;

namespace FileWatcherDemo
{
    public class RuleEngine : IRuleEngine
    {
        ILogger objLogger = LoggerService.CreateLogger();     
        public static Dictionary<string, System.Windows.Forms.Timer> objTimerRule2 = new Dictionary<string, System.Windows.Forms.Timer>();
        public static Dictionary<string, System.Windows.Forms.Timer> objTimerRule3 = new Dictionary<string, System.Windows.Forms.Timer>();
        public FileInfo LastcreatedFile = null;
        private Object thisLock = new Object();
        public RuleEngine()
        {

        }


        /// <summary>
        /// update the dictionary value of folder and file information
        /// </summary>
        /// <param name="NewFile"></param>
        /// <param name="folderName"></param>
        /// <param name="eventName"></param>
        public void UpdateDictionary(string NewFile, string folderName, string eventName, string folderPath, int interval)
        {
            lock (thisLock)
            {
                if (eventName == "Created")
                {
                    if (Program.FileCreationList.Count != 0)
                    {
                        var lastFileName = Program.FileCreationList.Values.Where(t => t.Foldername == folderName).FirstOrDefault();
                        if (lastFileName != null)
                        {
                            CheckFileRemain(lastFileName, DateTime.Now);
                        }

                    }
                    if (Program.FileCreationList.ContainsKey(folderPath) == false)
                    {
                        FileDetails objFileDetails = new FileDetails();
                        objFileDetails.Filename = NewFile;
                        objFileDetails.Foldername = folderName;
                        objFileDetails.Fullfilepath = folderPath;
                        objFileDetails.Interval = interval;
                        objFileDetails.FolderLastWriteTime = DateTime.Now;
                        objFileDetails.FileCreationTime = DateTime.Now;
                        Program.FileCreationList.Add(folderPath, objFileDetails);

                        objLogger.WritelogInfo("New File: " + NewFile + " Created in folder " + folderPath);
                    }

                    if (Program.FolderLastAccessTimeList.ContainsKey(folderName) == false)
                    {
                        Program.FolderLastAccessTimeList.Add(folderName, Directory.GetLastWriteTime(folderName));
                    }
                    else
                    {
                        Program.FolderLastAccessTimeList[folderName] = DateTime.Now;
                    }
                }
                else if (eventName == "Changed")
                {
                    if (Program.FileCreationList.Count != 0)
                    {
                        var lastFileName = Program.FileCreationList.Values.Where(t => t.Foldername == folderName).FirstOrDefault();
                        if (lastFileName != null)
                        {
                            CheckFileRemain(lastFileName, DateTime.Now);
                        }
                    }
                    if (Program.FolderLastAccessTimeList.ContainsKey(folderName) == false)
                    {
                        Program.FolderLastAccessTimeList.Add(folderName, Directory.GetLastWriteTime(folderName));
                    }
                    else
                    {
                        Program.FolderLastAccessTimeList[folderName] = DateTime.Now;
                    }
                }
            }
        }


        /// <summary>
        /// chek file how long remains in folder
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="LastFileAccessTime"></param>
        public void CheckFileRemain(FileDetails objFile, DateTime LastFileAccessTime)
        {
            lock (thisLock)
            {

                if (Program.FolderLastAccessTimeList.Count > 0)
                {
                    var last = Program.FolderLastAccessTimeList.Where(t => t.Key == objFile.Foldername).FirstOrDefault().Value;
                    if (last != null)
                    {
                        if (RuleFileRemain.chekFileRemains(null, last, LastFileAccessTime, objFile.Interval) == true)
                        {
                            if (Program.FileRemainingList.ContainsKey(objFile.Fullfilepath) == false)
                            {

                                Program.FileRemainingList.Add(objFile.Fullfilepath, objFile);
                                //  Program.FileRemainingList.Add(fileName, DateTime.Now);                            
                                objLogger.WritelogWaning("File:" + objFile.Filename + " remained in folder " + objFile.Foldername + " for long time");
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Raise alert for file when threshold time for file ends for rule2
        /// </summary>
        /// <param name="folderName"></param>
        public void RaiseAlert_Rule2(string folderName, int thresholdInterval)
        {
            lock (thisLock)
            {

                DateTime currentTime = DateTime.Now;
                if (Program.FolderLastAccessTimeList.Count > 0)
                {
                    foreach (var file in Program.FileCreationList)
                    {
                        if (file.Value.Foldername == folderName)
                        {
                            var folderLastAccessTime = Program.FolderLastAccessTimeList.Where(t => t.Key == folderName).FirstOrDefault().Value;
                            if (folderLastAccessTime != null)
                            {
                                if (RuleFileNotReceived.chekFileNotReceived(null, DateTime.Now, folderLastAccessTime, thresholdInterval) == true)
                                {
                                    objLogger.WritelogWaning("No new file received from " + folderLastAccessTime + " to " + DateTime.Now + " in folder " + file.Key);
                                }
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Raise alert for file when threshold time for file ends for rule3
        /// </summary>
        /// <param name="folderName"></param>
        public void RaiseAlert_Rule3(string folderName, int thresholdInterval)
        {
            lock (thisLock)
            {
                DateTime currentTime = DateTime.Now;

                if (Program.FileCreationList.Count > 0)
                {
                    if (Program.FolderLastAccessTimeList.Count > 0)
                    {
                        foreach (var file in Program.FileCreationList)
                        {
                            if (file.Value.Foldername == folderName)
                            {
                                if (RuleFileRemain.chekFileRemains(null, currentTime, file.Value.FileCreationTime, thresholdInterval) == true)
                                {
                                    if (Program.FileRemainingList.ContainsKey(file.Key) == false)
                                    {
                                        Program.FileRemainingList.Add(file.Key, file.Value);
                                    }
                                    objLogger.WritelogWaning("File:" + file.Key + " remained in folder" + folderName + " for long time");
                                }
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        /// function start timer using windows forms  timer
        /// </summary>
        public void FileTimer(DateTime startTime, string folderName, int thresholdInterval)
        {
            lock (thisLock)
            {
                if (!objTimerRule2.ContainsKey(folderName))
                {
                    objTimerRule2.Add(folderName, new System.Windows.Forms.Timer());
                }
                if (!objTimerRule3.ContainsKey(folderName))
                {
                    objTimerRule3.Add(folderName, new System.Windows.Forms.Timer());
                }
                foreach(var timer in objTimerRule2)
                {
                    timer.Value.Interval = thresholdInterval;
                    timer.Value.Tick += (sender, e) => OnTimerEvent_Rule2(sender, e, folderName, thresholdInterval);
                    timer.Value.Start();
                }
                foreach (var timer1 in objTimerRule3)
                {
                    timer1.Value.Interval = thresholdInterval;
                    timer1.Value.Tick += (sender, e) => OnTimerEvent_Rule3(sender, e, folderName, thresholdInterval);
                    timer1.Value.Start();
                }                    
            }

       }

        /// <summary>
        /// funtion used to stop file timer.
        /// </summary>
        public void StopFileTimer()
        {
            lock (thisLock)
            {                  
                if (objTimerRule2.Count>0)
                {
                    foreach (var timer in objTimerRule2)
                    {
                        timer.Value.Stop();                      
                    }
                }
                if (objTimerRule3.Count > 0)
                {
                    foreach (var timer in objTimerRule3)
                    {
                        timer.Value.Stop();
                    }
                }
                objTimerRule2.Clear();
                objTimerRule3.Clear();
            }
        }

        private void OnTimerEvent_Rule2(object source, EventArgs e, string folderPath, int thresholdInterval)
        {
            lock (thisLock)
            {
                RaiseAlert_Rule2(folderPath, thresholdInterval);
            }

        }


        private void OnTimerEvent_Rule3(object source, EventArgs e, string folderPath, int thresholdInterval)
        {
            lock (thisLock)
            {
                RaiseAlert_Rule3(folderPath, thresholdInterval);
            }

        }

    }

}

