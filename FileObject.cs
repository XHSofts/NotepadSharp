using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadSharp
{
    class FileObject
    {
        public string fileName;
        public string filePath;
        public string fileExt;
        public long   fileSize;

        public FileObject(string fileName, string filePath, string fileExt)
        {
            this.fileName = fileName;
            this.filePath = filePath;
            this.fileExt  = fileExt;
        }
    }
}