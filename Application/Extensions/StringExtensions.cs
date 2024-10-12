using System.Text.RegularExpressions;

namespace Application.Extensions;

public static class StringExtensions
{
    public static string ToSlug(this string title)
    {
        var lowerCaseTitle = title.ToLower();
        var slug = Regex.Replace(lowerCaseTitle, @"\s+", "-");
        slug = slug.Trim('-');
        return slug;
    }
}