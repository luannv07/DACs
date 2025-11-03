using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DACs.Utils
{
    public static class StringUtils
    {
        public static string ConvertToUsername(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return string.Empty;

            string[] parts = fullName.Trim().ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return string.Empty;

            string lastName = RemoveDiacritics(parts[parts.Length - 1]);

            StringBuilder initials = new StringBuilder();
            for (int i = 0; i < parts.Length - 1; i++)
            {
                initials.Append(RemoveDiacritics(parts[i])[0]);
            }

            string username = lastName + initials.ToString();

            return username;
        }

        private static string RemoveDiacritics(string text)
        {
            string normalized = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
