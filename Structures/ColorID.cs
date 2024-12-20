using System.Text;
using System.Text.RegularExpressions;

namespace EnderStorageDB.Structures
{
    public enum ColorID
    {
        None,
        Black,
        Blue,
        Brown,
        Cyan,
        Gray,
        Green,
        LightBlue,
        LightGray,
        Lime,
        Magenta,
        Orange,
        Pink,
        Purple,
        Red,
        White,
        Yellow
    }

    internal static class ColorIDMapper
    {
        public static string Stringify(ColorID color)
        {
            if (color == ColorID.None)
                return "???";
            string str = color.ToString();
            str = Regex.Replace(str, @"[A-Z].*(?:[A-Z].*)+", ApplyMatch);
            return str;
        }

        private static string ApplyMatch(Match match)
        {
            StringBuilder output = new StringBuilder();
            bool first = true;
            foreach (char letter in match.Value)
            {
                if (char.IsUpper(letter))
                {
                    if (first)
                        first = false;
                    else
                        output.Append(' ');
                }
                output.Append(letter);
            }
            return output.ToString();
        }
    }
}
