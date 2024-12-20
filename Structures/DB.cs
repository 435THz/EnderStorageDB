using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnderStorageDB.Structures
{
    public class DB
    {
        internal static readonly string FOLDER = "userdata";
        internal static readonly string EXTENSION = ".esdb";

        public static DB Instance;
        [JsonIgnore]
        public string filename = "";
        [JsonIgnore]
        public bool file_exists = false;
        [JsonIgnore]
        public string Filepath => $"{FOLDER}\\{filename}{EXTENSION}";

        [JsonIgnore]
        public bool Changes { get; internal set; } = false;

        public static string FilepathOf(string filename) => $"{FOLDER}\\{filename}{EXTENSION}";
        [JsonInclude]
        public Dictionary<ColorCode, string> Chests = new Dictionary<ColorCode, string>();
        [JsonInclude]
        public Dictionary<ColorCode, string> Tanks = new Dictionary<ColorCode, string>();

        public DB() { }

        public static bool LoadFile(string filename)
        {
            try
            {
                var byteEncoded = File.ReadAllBytes(FilepathOf(filename));
                var encoded = Encoding.UTF8.GetString(byteEncoded);
                var byteStr = Convert.FromBase64String(encoded);
                var str = Encoding.UTF8.GetString(byteStr);

                var db = JsonSerializer.Deserialize<DB>(str);
                if (db is null)
                {
                    return false;
                }
                else
                {
                    Instance = db;
                    Instance.filename = filename;
                    Instance.file_exists = true;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void MakeNewFile(string filename)
        {
            Instance = new DB();
            Instance.filename = filename;
        }

        public static bool SaveFile()
        {

            if (Instance == null || string.IsNullOrEmpty(Instance.filename)) return false;

            string str = JsonSerializer.Serialize(Instance);
            var byteStr = Encoding.UTF8.GetBytes(str);
            var encoded = Convert.ToBase64String(byteStr);
            var byteEncoded = Encoding.UTF8.GetBytes(encoded);

            try
            {
                using (FileStream file = File.OpenWrite(Instance.Filepath))
                {
                    Instance.file_exists = true;
                    lock (file)
                    {
                        file.SetLength(0);
                        file.Write(byteEncoded, 0, byteEncoded.Length);
                    }
                }
            }
            catch (Exception) {
                return false;
            }
            Instance.Changes = false;
            return true;
        }

        public static bool CheckSaveFolder()
        {
            if (Directory.Exists(FOLDER)) return true;
            Directory.CreateDirectory("userdata");
            return false;
        }

        public static void DeleteFile(string filename)
        {
            File.Delete(FilepathOf(filename));
        }

        internal static List<ColorID> CheckFreeColors(int slot, ColorCode selected, Dictionary<ColorCode, string> ActiveDB)
        {
            List<ColorID> colors = new List<ColorID>();
            foreach (ColorID id in Enum.GetValues(typeof(ColorID))) {
                if (id == ColorID.None) continue;

                ColorCode codeChecked;
                switch(slot)
                {
                    case 0: codeChecked = new ColorCode(id, selected.Color2, selected.Color3); break;
                    case 1: codeChecked = new ColorCode(selected.Color1, id, selected.Color3); break;
                    case 2: codeChecked = new ColorCode(selected.Color1, selected.Color2, id); break;
                    default: throw new IndexOutOfRangeException($"Value {slot} out of range [0, 2]");
                }
                if(!ActiveDB.ContainsKey(codeChecked))
                colors.Add(id);
            }
            return colors;
        }
    }
}
