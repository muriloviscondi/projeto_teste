using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace Project.Domain.Extensions
{
    public static class Extension
    {
        public static DateTime ToBrasilia(this DateTime data)
        {
            //DateTime timeUtc = DateTime.UtcNow;
            //TimeZoneInfo kstZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"); 
            //DateTime dateTimeBrasilia = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, kstZone);
            //return dateTimeBrasilia;
            DateTime timeUtc = DateTime.UtcNow;
            bool isWindows = System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            TimeZoneInfo kstZone;
            if (isWindows)
            {
                kstZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            }
            else
            {
                kstZone = TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo");
            }

            DateTime dateTimeBrasilia = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, kstZone);
            return dateTimeBrasilia;
        }

        public static string RemoveAccents(this string text)
        {
            if (string.IsNullOrEmpty(text)) return "";

            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
    }
}
