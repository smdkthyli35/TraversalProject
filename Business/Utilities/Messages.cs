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

            public static string Add(string firstTitle, string secondTitle)
            {
                return $"{firstTitle} ve {secondTitle} başlıklı yazı başarıyla eklendi.";
            }

            public static string Delete(string firstTitle, string secondTitle)
            {
                return $"{firstTitle} ve {secondTitle} başlıklı yazı başarıyla silindi.";
            }

            public static string Update(string firstTitle, string secondTitle)
            {
                return $"{firstTitle} ve {secondTitle} başlıklı yazı başarıyla güncellendi.";
            }

            public static string HardDelete(string firstTitle, string secondTitle)
            {
                return $"{firstTitle} ve {secondTitle} başlıklı yazı başarıyla veritabanından silindi.";
            }
        }
    }
}
