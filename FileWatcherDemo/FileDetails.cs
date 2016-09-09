using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherDemo
{
   public class FileDetails
    {

       public string Filename { get; set; }
       public string Fullfilepath { get; set; }
       public string Foldername { get; set; }
       public int Interval { get; set; }
       public DateTime FolderLastWriteTime { get; set; }
       public DateTime FileCreationTime { get; set; }

    }
}
