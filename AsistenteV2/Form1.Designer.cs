namespace AsistenteV2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnUpload = new Button();
            btnChangeImage = new Button();
            btnDelete = new Button();
            btnChangeAplication = new Button();
            btnIncludeApp = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // btnUpload
            // 
            btnUpload.BackColor = Color.Transparent;
            btnUpload.Cursor = Cursors.Hand;
            btnUpload.FlatStyle = FlatStyle.Flat;
            btnUpload.Font = new Font("Cascadia Code", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpload.ForeColor = Color.White;
            btnUpload.Location = new Point(12, 12);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(152, 81);
            btnUpload.TabIndex = 0;
            btnUpload.Text = "Subir";
            btnUpload.UseVisualStyleBackColor = false;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnChangeImage
            // 
            btnChangeImage.BackColor = Color.Transparent;
            btnChangeImage.Cursor = Cursors.Hand;
            btnChangeImage.FlatStyle = FlatStyle.Flat;
            btnChangeImage.Font = new Font("Cascadia Code", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnChangeImage.ForeColor = Color.White;
            btnChangeImage.Location = new Point(191, 12);
            btnChangeImage.Name = "btnChangeImage";
            btnChangeImage.Size = new Size(152, 81);
            btnChangeImage.TabIndex = 2;
            btnChangeImage.Text = "Cambiar Imagen";
            btnChangeImage.UseVisualStyleBackColor = false;
            btnChangeImage.Click += btnChangeImage_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Transparent;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Cascadia Code", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(745, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(152, 81);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Borrar";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnChangeAplication
            // 
            btnChangeAplication.BackColor = Color.Transparent;
            btnChangeAplication.Cursor = Cursors.Hand;
            btnChangeAplication.FlatStyle = FlatStyle.Flat;
            btnChangeAplication.Font = new Font("Cascadia Code", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnChangeAplication.ForeColor = Color.White;
            btnChangeAplication.Location = new Point(376, 12);
            btnChangeAplication.Name = "btnChangeAplication";
            btnChangeAplication.Size = new Size(152, 81);
            btnChangeAplication.TabIndex = 4;
            btnChangeAplication.Text = "Cambiar Aplicacion";
            btnChangeAplication.UseVisualStyleBackColor = false;
            btnChangeAplication.Click += btnChangeAplication_Click;
            // 
            // btnIncludeApp
            // 
            btnIncludeApp.BackColor = Color.Transparent;
            btnIncludeApp.Cursor = Cursors.Hand;
            btnIncludeApp.FlatStyle = FlatStyle.Flat;
            btnIncludeApp.Font = new Font("Cascadia Code", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnIncludeApp.ForeColor = Color.White;
            btnIncludeApp.Location = new Point(565, 12);
            btnIncludeApp.Name = "btnIncludeApp";
            btnIncludeApp.Size = new Size(152, 81);
            btnIncludeApp.TabIndex = 5;
            btnIncludeApp.Text = "Incluir Aplicacion";
            btnIncludeApp.UseVisualStyleBackColor = false;
            btnIncludeApp.Click += btnIncludeApp_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Transparent;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Enabled = false;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Cascadia Code", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(920, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(152, 81);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(255, 128, 128);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1493, 803);
            Controls.Add(btnCancel);
            Controls.Add(btnIncludeApp);
            Controls.Add(btnChangeAplication);
            Controls.Add(btnDelete);
            Controls.Add(btnChangeImage);
            Controls.Add(btnUpload);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "AsistenteV2";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnUpload;
        private Button btnChangeImage;
        private Button btnDelete;
        private Button btnChangeAplication;
        private Button btnIncludeApp;
        private Button btnCancel;
    }
}