using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace IntelliTect.Analyzer
{
#pragma warning disable CA1055 // Uri return values should not be strings

    public static class DiagnosticUrlBuilder
    {
        private const string BaseUrl = "https://github.com/IntelliTect/CodingGuidelines";

        /// <summary>
        /// Get the full diagnostic help url
        /// </summary>
        /// <param name="title">intl analyzer title</param>
        /// <param name="diagnosticId">The intl error code</param>
        /// <returns>Full url linking to wiki </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetUrl(string title, string diagnosticId)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new System.ArgumentException("title cannot be empty", nameof(title));
            if (string.IsNullOrWhiteSpace(diagnosticId))
                throw new System.ArgumentException("diagnostic ID cannot be empty", nameof(diagnosticId));

            Regex hyphenateRegex = new Regex(@"\s");
            string hyphenatedTitle = hyphenateRegex.Replace(title, "-");

            return BaseUrl + $"#{diagnosticId.ToLower()}" + $"---{hyphenatedTitle.ToLower()}";
        }
    }

#pragma warning restore CA1055 // Uri return values should not be strings
}
