using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace code.Utilities
{
    public class File
    {
        public static string ReadFile(string FilePath)
        {
            return System.IO.File.ReadAllText(FilePath);
        }

        public static void WriteFile(string FilePath,string Content)
        {
            System.IO.File.WriteAllText(FilePath, Content);
        }
    }
}