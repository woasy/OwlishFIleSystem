using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OwlishFileSystem
{
    public class OwlishProgress
    {
        public OwlishProgress(string message, string file, long max, long current)
        {
            this.ProcessingMessage = message;
            this.ProcessingFile = file;
            this.AddedMaxProgress = max;
            this.ImprovedProgress = current;
        }
        public string ProcessingMessage { get; private set; }
        public string ProcessingFile { get; private set; }
        public long AddedMaxProgress { get; private set; }
        public long ImprovedProgress { get; private set; }
    }
}
