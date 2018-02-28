using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HISSMS
{
    class ClassPrint
    {
        public static string nameReport(string name)
        {
            string ext = Path.GetExtension(name);
            string name_file = name.Replace(ext,"");
            return name_file + "_excel" + ext;
        }
    }
}
