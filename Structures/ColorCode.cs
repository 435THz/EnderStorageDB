using System;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace EnderStorageDB.Structures
{
    [JsonConverter(typeof(ColorCodeConverter))]
    public readonly struct ColorCode : IComparable<ColorCode>, IEquatable<ColorCode>
    {
        public readonly ColorID Color1;
        public readonly ColorID Color2;
        public readonly ColorID Color3;
        [JsonConstructor]
        internal ColorCode(ColorID color1, ColorID color2, ColorID color3)
        {
            Color1 = color1;
            Color2 = color2;
            Color3 = color3;
        }
        internal ColorCode(int color1, int color2, int color3)
        {
            Color1 = (ColorID)color1;
            Color2 = (ColorID)color2;
            Color3 = (ColorID)color3;
        }

        public bool IsValid()
        {
            return Color1 != ColorID.None &&
                Color2 != ColorID.None &&
                Color3 != ColorID.None;
        }
        public bool IsValid(int ignore_slot)
        {
            switch (ignore_slot)
            {
                case 0: return new ColorCode(ColorID.White, Color2, Color3).IsValid();
                case 1: return new ColorCode(Color1, ColorID.White, Color3).IsValid();
                case 2: return new ColorCode(Color1, Color2, ColorID.White).IsValid();
                default: throw new IndexOutOfRangeException($"Value {ignore_slot} out of range [0, 2]");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            return this.Equals((ColorCode)obj);
        }

        public bool Equals(ColorCode other)
        {
            return Color1.Equals(other.Color1) &&
                Color2.Equals(other.Color2) &&
                Color3.Equals(other.Color3);
        }

        public override int GetHashCode()
        {
            int prime = 92821;
            int hash = prime + Color1.GetHashCode();
            hash = hash * prime + Color2.GetHashCode();
            hash = hash * prime + Color3.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return $"[{ColorIDMapper.Stringify(Color1)}, {ColorIDMapper.Stringify(Color2)}, {ColorIDMapper.Stringify(Color3)}]";
        }

        private int ToInt()
        {
            int col = (int)Color1 * (17 ^ 2) + (int)Color2 ^ 17 + (int)Color3;
            if (Color1 == ColorID.None || Color2 == ColorID.None || Color3 == ColorID.None)
                col -= 17 ^ 3;
            return col;
        }

        public int CompareTo(ColorCode other) => this.ToInt() - other.ToInt();

        internal static string Serialize(ColorCode obj)
        {
            return $"{(int)obj.Color1}, {(int)obj.Color2}, {(int)obj.Color3}";
        }
        internal static ColorCode Deserialize(string str)
        {
            Match match = Regex.Match(str, @"(\d+), *(\d+), *(\d+)");
            ColorID c1 = (ColorID)int.Parse(match.Groups[1].Value);
            ColorID c2 = (ColorID)int.Parse(match.Groups[2].Value);
            ColorID c3 = (ColorID)int.Parse(match.Groups[3].Value);
            return new ColorCode(c1, c2, c3);
        }
    }
}
