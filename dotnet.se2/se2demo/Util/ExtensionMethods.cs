using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace se2demo.Util
{
    public static class ExtensionMethods
    {
        public static String SafeFileName(this String fileName)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(c, '-');
            }
            return fileName;
        }

        public static String SafePathName(this String filePath)
        {
            foreach (var c in Path.GetInvalidPathChars())
            {
                filePath = filePath.Replace(c, '-');
            }
            return filePath;
        }
    }
}
