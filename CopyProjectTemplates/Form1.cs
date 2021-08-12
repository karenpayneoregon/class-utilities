#nullable enable
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CopyProjectTemplates.Classes;

namespace CopyProjectTemplates
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            FileHelpers.CopyFileHandler += OnCopyFileHandler;
            Shown += OnShown;
        }

        private void OnCopyFileHandler(string filename)
        {
            CopiedFilesListBox.Items.Add(filename);
            CopiedFilesListBox.SelectedIndex = CopiedFilesListBox.Items.Count - 1;
        }


        private void OnShown(object? sender, EventArgs e)
        {
            if (FileHelpers.TemplateFolderExists)
            {
                VisualStudioTemplateFolderTextBox.Text = FileHelpers.TemplateFolder;
            }
            else
            {
                CopyFilesButton.Enabled = false;
                MessageBox.Show($"{FileHelpers.TemplateFolder} does not exists");
            }
        }

        private void CopyFilesButton_Click(object sender, EventArgs e)
        {
            CopiedFilesListBox.Items.Clear();

            var (success, exception) = FileHelpers.CopyLocalFilesToProjectTemplateFolder();
            MessageBox.Show(success == false ? exception.Message : "Copy files completed");
        }
    }
}
