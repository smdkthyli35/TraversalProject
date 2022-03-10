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

        public static class About
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir hakkında bilgisi bulunamadı.";
                return "Böyle bir hakkında bilgisi bulunamadı.";
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

        public static class Contact
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir iletişim bilgisi bulunamadı.";
                return "Böyle bir iletişim bilgisi bulunamadı.";
            }

            public static string Add = "İletişim bilgisi başarıyla eklendi.";
            public static string Delete = "İletişim bilgisi başarıyla silindi.";
            public static string HardDelete = "İletişim bilgisi başarıyla veritabanından silindi.";
            public static string Update = "İletişim bilgisi başarıyla güncellendi.";
        }

        public static class Destination
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir iletişim bilgisi bulunamadı.";
                return "Böyle bir iletişim bilgisi bulunamadı.";
            }

            public static string Add = "Hedef bilgisi başarıyla eklendi.";
            public static string Delete = "Hedef bilgisi başarıyla silindi.";
            public static string HardDelete = "Hedef bilgisi başarıyla veritabanından silindi.";
            public static string Update = "Hedef bilgisi başarıyla güncellendi.";
        }

        public static class Feature
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir özellik bilgisi bulunamadı.";
                return "Böyle bir özellik bilgisi bulunamadı.";
            }

            public static string Add(string title)
            {
                return $"{title} başlıklı özellik başarıyla eklendi.";
            }

            public static string Delete(string title)
            {
                return $"{title} başlıklı özellik başarıyla silindi.";
            }

            public static string Update(string title)
            {
                return $"{title} başlıklı özellik başarıyla güncellendi.";
            }

            public static string HardDelete(string title)
            {
                return $"{title} başlıklı özellik başarıyla veritabanından silindi.";
            }
        }

        public static class Guide
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir rehber bilgisi bulunamadı.";
                return "Böyle bir rehber bilgisi bulunamadı.";
            }

            public static string Add(string name)
            {
                return $"{name} adlı rehber başarıyla eklendi.";
            }

            public static string Delete(string name)
            {
                return $"{name} adlı rehber başarıyla silindi.";
            }

            public static string Update(string name)
            {
                return $"{name} adlı rehber başarıyla güncellendi.";
            }

            public static string HardDelete(string name)
            {
                return $"{name} adlı rehber başarıyla veritabanından silindi.";
            }
        }

        public static class Newsletter
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir haber bülteni bilgisi bulunamadı.";
                return "Böyle bir haber bülteni bilgisi bulunamadı.";
            }

            public static string Add(string name)
            {
                return $"{name} adlı mail haber bültenine başarıyla eklendi.";
            }

            public static string Delete(string name)
            {
                return $"{name} adlı mail haber bülteninden başarıyla silindi.";
            }

            public static string Update(string name)
            {
                return $"{name} adlı mail haber bülteninde başarıyla güncellendi.";
            }

            public static string HardDelete(string name)
            {
                return $"{name} adlı mail haber bülteninden başarıyla veritabanından silindi.";
            }
        }

        public static class OtherFeature
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir diğer özellik bilgisi bulunamadı.";
                return "Böyle bir diğer özellik bilgisi bulunamadı.";
            }

            public static string Add(string title)
            {
                return $"{title} başlıklı diğer özellik başarıyla eklendi.";
            }

            public static string Delete(string title)
            {
                return $"{title} başlıklı diğer özellik başarıyla silindi.";
            }

            public static string Update(string title)
            {
                return $"{title} başlıklı diğer özellik başarıyla güncellendi.";
            }

            public static string HardDelete(string title)
            {
                return $"{title} başlıklı diğer özellik başarıyla veritabanından silindi.";
            }
        }

        public static class SubAbout
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir alt hakkında bilgisi bulunamadı.";
                return "Böyle bir alt hakkında  bilgisi bulunamadı.";
            }

            public static string Add(string title)
            {
                return $"{title} başlıklı alt hakkında bilgisi başarıyla eklendi.";
            }

            public static string Delete(string title)
            {
                return $"{title} başlıklı alt hakkında bilgisi başarıyla silindi.";
            }

            public static string Update(string title)
            {
                return $"{title} başlıklı alt hakkında bilgisi başarıyla güncellendi.";
            }

            public static string HardDelete(string title)
            {
                return $"{title} başlıklı alt hakkında bilgisi veritabanından silindi.";
            }
        }

        public static class Testimonial
        {
            public static string NotFound(bool isPlural)
            {
                if (isPlural) return "Hiçbir referans bilgisi bulunamadı.";
                return "Böyle bir referans bilgisi bulunamadı.";
            }

            public static string Add = "Referans bilgisi başarıyla eklendi.";
            public static string Delete = "Referans bilgisi başarıyla silindi.";
            public static string HardDelete = "Referans bilgisi başarıyla veritabanından silindi.";
            public static string Update = "Referans bilgisi başarıyla güncellendi.";
        }
    }
}
