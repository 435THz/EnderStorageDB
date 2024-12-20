using EnderStorageDB.Structures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EnderStorageDB
{
    public partial class DatabaseUI : Form
    {
        private static ToolStripItem none;
        private bool Changes {
            get => DB.Instance.Changes;
            set => DB.Instance.Changes = value;
        }
        internal Dictionary<ColorCode, string> ActiveDB
        {
            get
            {
                if (TabControl.SelectedIndex == 0)
                    return DB.Instance.Chests;
                else
                    return DB.Instance.Tanks;
            }
        }
        private readonly List<ColorCode> ActiveDBMapping = new List<ColorCode>();

        public DatabaseUI()
        {
            InitializeComponent();
            ColorBox1.Items.Clear();
            ColorBox2.Items.Clear();
            ColorBox3.Items.Clear();
            foreach (ColorID id in Enum.GetValues(typeof(ColorID)))
            {
                ColorBox1.Items.Add(ColorIDMapper.Stringify(id));
                ColorBox2.Items.Add(ColorIDMapper.Stringify(id));
                ColorBox3.Items.Add(ColorIDMapper.Stringify(id));
            }
            ColorBox1.SelectedIndex = 0;
            ColorBox2.SelectedIndex = 0;
            ColorBox3.SelectedIndex = 0;
            none = ColorListMenuItem.DropDownItems[0];
        }

        private void SetName(string filename)
        {
            Text = $"Ender Storage DB - {filename}{DB.EXTENSION}";
        }

        private void DatabaseUI_Shown(object sender, EventArgs e)
        {
            ShowOpenFileUI();
        }

        private void ColorComboName_TextChanged(object sender, EventArgs e)
        {
            string text = ColorComboName.Text;
            ColorCode code = GetSelectedCode();
            if (code.IsValid())
            {
                if (!string.IsNullOrEmpty(text))
                {
                    ActiveDB[code] = text;
                    Changes = true;
                }
                else
                {
                    ActiveDB.Remove(code);
                }
            }
        }

        private void ColorComboName_DropDown(object sender, EventArgs e)
        {
            ColorComboName.Items.Clear();
            ActiveDBMapping.Clear();
            foreach (KeyValuePair<ColorCode, string> pair in ActiveDB)
            {
                ColorComboName.Items.Add(pair.Value);
                ActiveDBMapping.Add(pair.Key);
            }
        }

        private void ColorComboName_SelectionChanged(object sender, EventArgs e)
        {
            if (ColorComboName.SelectedIndex >= 0)
            {
                ColorCode newCode = ActiveDBMapping[ColorComboName.SelectedIndex];
                ColorBox1.SelectedIndex = (int)newCode.Color1;
                ColorBox2.SelectedIndex = (int)newCode.Color2;
                ColorBox3.SelectedIndex = (int)newCode.Color3;
            }
        }

        private ColorCode GetSelectedCode() =>
            new ColorCode(ColorBox1.SelectedIndex, ColorBox2.SelectedIndex, ColorBox3.SelectedIndex);

        private void ColorComboChanged(object sender, EventArgs e) => ColorComboChanged();
        private void ColorComboChanged()
        {
            ColorCode code = GetSelectedCode();
            string value = "";
            if (code.IsValid())
            {
                ActiveDB.TryGetValue(code, out value);
            }
            ColorComboName.Text = value;
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("Do you want to save your changes before leaving?", "", MessageBoxButtons.YesNoCancel);
            if (res != DialogResult.Cancel)
            {
                string prev_file = DB.Instance.filename;
                if (res == DialogResult.Yes)
                    DB.SaveFile();
                DB.Instance = null;
                ShowOpenFileUI(prev_file);
            }
        }

        private void ShowOpenFileUI(string prev_file = "")
        {
            OpenFileUI form = new OpenFileUI();
            form.ShowDialog();
            if (DB.Instance == null && !DB.LoadFile(prev_file))
            {
                string firstLine = DB.Instance is null || !DB.Instance.file_exists ? "No file selected" : $"\"{prev_file}{DB.EXTENSION}\" cannot be found.";
                string message = $"{firstLine}\nThe program will now close.";
                string caption = "Missing File";
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                MessageBox.Show(message, caption, buttons);
                this.Close();
            }
            else
            {
                SetName(DB.Instance.filename);
                ColorBox1.SelectedIndex = 0;
                ColorBox2.SelectedIndex = 0;
                ColorBox3.SelectedIndex = 0;
                ColorComboChanged();
            }
        }

        private void DatabaseUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DB.Instance != null && !string.IsNullOrEmpty(DB.Instance.filename) && Changes)
            {
                DialogResult res = MessageBox.Show("Do you want to save your changes before leaving?", "", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Yes)
                {
                    DB.SaveFile();
                }
                else if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DB.SaveFile();
            MessageBox.Show("Save Completed", "", MessageBoxButtons.OK);
        }

        private void ColorBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ColorBox_RightClick((ComboBox)sender, 1, e);
        }
        private void ColorBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ColorBox_RightClick((ComboBox)sender, 2, e);
        }
        private void ColorBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                ColorBox_RightClick((ComboBox)sender, 3, e);
        }

        private void ColorBox_RightClick(ComboBox sender, int box, MouseEventArgs e)
        {
            if (GetSelectedCode().IsValid(box - 1))
            {
                ColorListMenuItem.DropDownItems.Clear();
                ColorListMenuItem.Enabled = true;
                List<ColorID> colors = DB.CheckFreeColors(box - 1, GetSelectedCode(), ActiveDB);
                if (colors.Count == 0)
                {
                    ColorListMenuItem.DropDownItems.Add(none);
                }
                else
                {
                    PopulateColorListMenuItem(sender, colors);
                }
            }
            else
            {
                ColorListMenuItem.Enabled = false;
            }

            ContextMenuColors.Show(new Point(Left + sender.Left + e.X + 20, Top + sender.Top + e.Y + 50));
        }

        private void PopulateColorListMenuItem(ComboBox sender, List<ColorID> colors)
        {
            foreach (ColorID color in colors)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(ColorIDMapper.Stringify(color));
                item.Click += delegate
                {
                    sender.SelectedIndex = (int)color;
                    ColorComboChanged();
                };
                ColorListMenuItem.DropDownItems.Add(item);
            }
        }
    }
}
