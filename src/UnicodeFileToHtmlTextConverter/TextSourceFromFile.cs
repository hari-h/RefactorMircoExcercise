using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class TextSourceFromFile : ITextSource
    {
        private readonly string _fullFilenameWithPath;
        public TextSourceFromFile(string fullFilenameWithPath)
        {
            _fullFilenameWithPath = fullFilenameWithPath;
        }
        public TextReader GetTextReader()
        {
            return File.OpenText(_fullFilenameWithPath);
        }
    }
}
