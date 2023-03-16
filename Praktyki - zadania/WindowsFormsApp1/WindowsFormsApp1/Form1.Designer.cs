namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxFile = new System.Windows.Forms.RichTextBox();
            this.openFileDialogPlik = new System.Windows.Forms.OpenFileDialog();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.saveFileDialogWord = new System.Windows.Forms.SaveFileDialog();
            this.ButtonOpenManyFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxFile
            // 
            this.richTextBoxFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxFile.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxFile.Name = "richTextBoxFile";
            this.richTextBoxFile.Size = new System.Drawing.Size(824, 384);
            this.richTextBoxFile.TabIndex = 4;
            this.richTextBoxFile.Text = "";
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Location = new System.Drawing.Point(12, 402);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpen.TabIndex = 1;
            this.ButtonOpen.Text = "Otwórz";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(93, 402);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 2;
            this.ButtonSave.Text = "Zapisz";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonClose
            // 
            this.ButtonClose.Location = new System.Drawing.Point(174, 402);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(75, 23);
            this.ButtonClose.TabIndex = 3;
            this.ButtonClose.Text = "Zamknij";
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // saveFileDialogWord
            // 
            this.saveFileDialogWord.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialogWord_FileOk);
            // 
            // ButtonOpenManyFiles
            // 
            this.ButtonOpenManyFiles.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ButtonOpenManyFiles.Location = new System.Drawing.Point(12, 431);
            this.ButtonOpenManyFiles.Name = "ButtonOpenManyFiles";
            this.ButtonOpenManyFiles.Size = new System.Drawing.Size(237, 23);
            this.ButtonOpenManyFiles.TabIndex = 0;
            this.ButtonOpenManyFiles.Text = "Otwórz kilka plików";
            this.ButtonOpenManyFiles.UseVisualStyleBackColor = false;
            this.ButtonOpenManyFiles.Click += new System.EventHandler(this.ButtonOpenManyFiles_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(848, 466);
            this.Controls.Add(this.ButtonOpenManyFiles);
            this.Controls.Add(this.ButtonClose);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonOpen);
            this.Controls.Add(this.richTextBoxFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxFile;
        private System.Windows.Forms.OpenFileDialog openFileDialogPlik;
        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonClose;
        private System.Windows.Forms.SaveFileDialog saveFileDialogWord;
        private System.Windows.Forms.Button ButtonOpenManyFiles;
    }
}

