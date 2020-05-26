using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class FileDataProvider : IDataProvider
    {
        public int GetData()
        {
            var content = File.ReadAllText("File.txt");
            var lines = content.Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            return Convert.ToInt32(lines[0]);

        }
    }
}
