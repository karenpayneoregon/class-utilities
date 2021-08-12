
namespace CopyProjectTemplates
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VisualStudioTemplateFolderTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CopiedFilesListBox = new System.Windows.Forms.ListBox();
            this.CopyFilesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VisualStudioTemplateFolderTextBox
            // 
            this.VisualStudioTemplateFolderTextBox.Location = new System.Drawing.Point(12, 64);
            this.VisualStudioTemplateFolderTextBox.Name = "VisualStudioTemplateFolderTextBox";
            this.VisualStudioTemplateFolderTextBox.Size = new System.Drawing.Size(606, 23);
            this.VisualStudioTemplateFolderTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Visual Studio\'s project template folder";
            // 
            // CopiedFilesListBox
            // 
            this.CopiedFilesListBox.FormattingEnabled = true;
            this.CopiedFilesListBox.ItemHeight = 15;
            this.CopiedFilesListBox.Location = new System.Drawing.Point(12, 103);
            this.CopiedFilesListBox.Name = "CopiedFilesListBox";
            this.CopiedFilesListBox.Size = new System.Drawing.Size(606, 244);
            this.CopiedFilesListBox.TabIndex = 2;
            // 
            // CopyFilesButton
            // 
            this.CopyFilesButton.Location = new System.Drawing.Point(12, 358);
            this.CopyFilesButton.Name = "CopyFilesButton";
            this.CopyFilesButton.Size = new System.Drawing.Size(129, 23);
            this.CopyFilesButton.TabIndex = 3;
            this.CopyFilesButton.Text = "Copy";
            this.CopyFilesButton.UseVisualStyleBackColor = true;
            this.CopyFilesButton.Click += new System.EventHandler(this.CopyFilesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 393);
            this.Controls.Add(this.CopyFilesButton);
            this.Controls.Add(this.CopiedFilesListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VisualStudioTemplateFolderTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copy Visual Studio Template files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox VisualStudioTemplateFolderTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox CopiedFilesListBox;
        private System.Windows.Forms.Button CopyFilesButton;
    }
}

