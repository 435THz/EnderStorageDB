using EnderStorageDB.Structures;
using System;
using System.IO;
using System.Windows.Forms;

namespace EnderStorageDB
{
    public partial class OpenFileUI : Form
    {
        public OpenFileUI()
        {
            InitializeComponent();
            DB.CheckSaveFolder();
            FileSelectBox.Items.Clear();

            foreach (string file in Directory.EnumerateFiles(DB.FOLDER))
            {
                if(Path.GetExtension(file) == DB.EXTENSION)
                {
                    FileSelectBox.Items.Add(Path.GetFileNameWithoutExtension(file));
                }
            }
            TextChange("");
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            if(DB.LoadFile(FileSelectBox.Text))
                this.Close();
            else
            {
                string message = $"Could not read \"{FileSelectBox.Text}{DB.EXTENSION}\".\nPlease choose a different file.";
                string caption = "Error Reading File";
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                MessageBox.Show(message, caption, buttons);
            }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            DB.MakeNewFile(FileSelectBox.Text);
            this.Close();
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string message = $"Delete \"{FileSelectBox.Text}{DB.EXTENSION}\"?\nThis action cannot be undone.";
            string caption = "Delete File";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, caption, buttons);

            if (result.Equals(DialogResult.Yes))
            {
                DB.DeleteFile(FileSelectBox.Text);
                FileSelectBox.Items.Remove(FileSelectBox.Text);
                TextChange(FileSelectBox.Text);

                message = $"\"{FileSelectBox.Text}{DB.EXTENSION}\" has been deleted.";
                caption = "Delete File";
                buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
        }

        private void FileSelectBox_SelectionChangeCommitted(object sender, EventArgs e) =>
            TextChange((string)FileSelectBox.Items[FileSelectBox.SelectedIndex]);

        private void FileSelectBox_TextUpdate(object sender, EventArgs e) =>
            TextChange(FileSelectBox.Text);

        private void TextChange(string text)
        {
            if (FileSelectBox.Items.Contains(text))
            {
                DeleteButton.Enabled = true;
                OpenButton.Enabled = true;
                AddButton.Enabled = false;
            }
            else
            {
                DeleteButton.Enabled = false;
                OpenButton.Enabled = false;
                AddButton.Enabled = !string.IsNullOrEmpty(text);
            }
        }
    }
}
