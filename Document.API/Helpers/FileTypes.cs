using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LS.Document.API.Helpers
{
    public static class FileTypes
    {
        public static List<string> ValidMimeTypes { get; set; }

        static FileTypes()
        {
            ValidMimeTypes = new List<string>
            {
                "application/msword",
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                "application/pdf",
                "image/jpeg",
                "image/png"

            };
        }
        public static bool IsValidContentType(string sourceFileName)
        {
            var mimeType = MimeMapping.MimeUtility.GetMimeMapping(sourceFileName);
            return ValidMimeTypes.Contains(mimeType);
        }
    }
}
