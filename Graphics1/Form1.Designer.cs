namespace Graphics1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.addButton = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.addGroupBox = new System.Windows.Forms.GroupBox();
            this.newPoint = new System.Windows.Forms.RadioButton();
            this.newPolygon = new System.Windows.Forms.RadioButton();
            this.deleteGroupBox = new System.Windows.Forms.GroupBox();
            this.deletePolygon = new System.Windows.Forms.RadioButton();
            this.deletePoint = new System.Windows.Forms.RadioButton();
            this.deleteButton = new System.Windows.Forms.Button();
            this.moveGroupBox = new System.Windows.Forms.GroupBox();
            this.movePolygon = new System.Windows.Forms.RadioButton();
            this.movePoint = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.addGroupBox.SuspendLayout();
            this.deleteGroupBox.SuspendLayout();
            this.moveGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 105);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1328, 624);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(118, 58);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // listView
            // 
            this.listView.Location = new System.Drawing.Point(30, 2);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(242, 97);
            this.listView.TabIndex = 3;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // addGroupBox
            // 
            this.addGroupBox.Controls.Add(this.newPoint);
            this.addGroupBox.Controls.Add(this.newPolygon);
            this.addGroupBox.Controls.Add(this.addButton);
            this.addGroupBox.Location = new System.Drawing.Point(296, 12);
            this.addGroupBox.Name = "addGroupBox";
            this.addGroupBox.Size = new System.Drawing.Size(210, 87);
            this.addGroupBox.TabIndex = 4;
            this.addGroupBox.TabStop = false;
            this.addGroupBox.Text = "Dodawanie";
            // 
            // newPoint
            // 
            this.newPoint.AutoSize = true;
            this.newPoint.Location = new System.Drawing.Point(98, 19);
            this.newPoint.Name = "newPoint";
            this.newPoint.Size = new System.Drawing.Size(82, 17);
            this.newPoint.TabIndex = 3;
            this.newPoint.TabStop = true;
            this.newPoint.Text = "Nowy punkt";
            this.newPoint.UseVisualStyleBackColor = true;
            // 
            // newPolygon
            // 
            this.newPolygon.AutoSize = true;
            this.newPolygon.Checked = true;
            this.newPolygon.Location = new System.Drawing.Point(7, 20);
            this.newPolygon.Name = "newPolygon";
            this.newPolygon.Size = new System.Drawing.Size(94, 17);
            this.newPolygon.TabIndex = 2;
            this.newPolygon.TabStop = true;
            this.newPolygon.Text = "Nowy wielokąt";
            this.newPolygon.UseVisualStyleBackColor = true;
            // 
            // deleteGroupBox
            // 
            this.deleteGroupBox.Controls.Add(this.deletePolygon);
            this.deleteGroupBox.Controls.Add(this.deletePoint);
            this.deleteGroupBox.Controls.Add(this.deleteButton);
            this.deleteGroupBox.Location = new System.Drawing.Point(531, 12);
            this.deleteGroupBox.Name = "deleteGroupBox";
            this.deleteGroupBox.Size = new System.Drawing.Size(210, 87);
            this.deleteGroupBox.TabIndex = 5;
            this.deleteGroupBox.TabStop = false;
            this.deleteGroupBox.Text = "Usuwanie";
            // 
            // deletePolygon
            // 
            this.deletePolygon.AutoSize = true;
            this.deletePolygon.Location = new System.Drawing.Point(98, 19);
            this.deletePolygon.Name = "deletePolygon";
            this.deletePolygon.Size = new System.Drawing.Size(92, 17);
            this.deletePolygon.TabIndex = 3;
            this.deletePolygon.TabStop = true;
            this.deletePolygon.Text = "Usuń wielokąt";
            this.deletePolygon.UseVisualStyleBackColor = true;
            // 
            // deletePoint
            // 
            this.deletePoint.AutoSize = true;
            this.deletePoint.Location = new System.Drawing.Point(7, 20);
            this.deletePoint.Name = "deletePoint";
            this.deletePoint.Size = new System.Drawing.Size(80, 17);
            this.deletePoint.TabIndex = 2;
            this.deletePoint.TabStop = true;
            this.deletePoint.Text = "Usuń punkt";
            this.deletePoint.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(118, 58);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Usuń";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // moveGroupBox
            // 
            this.moveGroupBox.Controls.Add(this.movePolygon);
            this.moveGroupBox.Controls.Add(this.movePoint);
            this.moveGroupBox.Location = new System.Drawing.Point(783, 12);
            this.moveGroupBox.Name = "moveGroupBox";
            this.moveGroupBox.Size = new System.Drawing.Size(210, 87);
            this.moveGroupBox.TabIndex = 6;
            this.moveGroupBox.TabStop = false;
            this.moveGroupBox.Text = "Przesuwanie";
            // 
            // movePolygon
            // 
            this.movePolygon.AutoSize = true;
            this.movePolygon.Location = new System.Drawing.Point(98, 19);
            this.movePolygon.Name = "movePolygon";
            this.movePolygon.Size = new System.Drawing.Size(105, 17);
            this.movePolygon.TabIndex = 3;
            this.movePolygon.TabStop = true;
            this.movePolygon.Text = "Przesuń wielokąt";
            this.movePolygon.UseVisualStyleBackColor = true;
            // 
            // movePoint
            // 
            this.movePoint.AutoSize = true;
            this.movePoint.Location = new System.Drawing.Point(7, 20);
            this.movePoint.Name = "movePoint";
            this.movePoint.Size = new System.Drawing.Size(93, 17);
            this.movePoint.TabIndex = 2;
            this.movePoint.TabStop = true;
            this.movePoint.Text = "Przesuń punkt";
            this.movePoint.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.moveGroupBox);
            this.Controls.Add(this.deleteGroupBox);
            this.Controls.Add(this.addGroupBox);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.pictureBox);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.addGroupBox.ResumeLayout(false);
            this.addGroupBox.PerformLayout();
            this.deleteGroupBox.ResumeLayout(false);
            this.deleteGroupBox.PerformLayout();
            this.moveGroupBox.ResumeLayout(false);
            this.moveGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.GroupBox addGroupBox;
        private System.Windows.Forms.RadioButton newPoint;
        private System.Windows.Forms.RadioButton newPolygon;
        private System.Windows.Forms.GroupBox deleteGroupBox;
        private System.Windows.Forms.RadioButton deletePolygon;
        private System.Windows.Forms.RadioButton deletePoint;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.GroupBox moveGroupBox;
        private System.Windows.Forms.RadioButton movePolygon;
        private System.Windows.Forms.RadioButton movePoint;
    }
}

