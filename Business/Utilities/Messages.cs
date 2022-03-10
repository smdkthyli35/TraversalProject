using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
    public static class Messages
    {
        public static class AboutPost
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir hakkında içeriği bulunamadı.";
                return "Böyle bir hakkında içeriği bulunamadı.";
            }

            public static string Add = "Eklendi";
            public static string Delete = "Eklendi";
            public static string Update = "Eklendi";
        }
    }
}
