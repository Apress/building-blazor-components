using System.Text;

namespace InputDigitsComponentLib
{
  public static class StringExtensions
  {
    public static string AtPos(this string s, int pos)
      => (s.Length > pos) ? s[pos].ToString() : string.Empty;

    public static string ReplaceAt(this string s, int pos, string value)
    {
      StringBuilder bob = new StringBuilder(s);
      while (pos >= bob.Length)
      {
        bob.Append(" ");
      }
      bob[pos] = value[0];
      return bob.ToString();
    }
  }
}
