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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.thicknessBar = new System.Windows.Forms.TrackBar();
            this.changeColor = new System.Windows.Forms.Button();
            this.markPoly = new System.Windows.Forms.RadioButton();
            this.deleteButton = new System.Windows.Forms.Button();
            this.movePolygon = new System.Windows.Forms.RadioButton();
            this.deletePolygon = new System.Windows.Forms.RadioButton();
            this.movePoint = new System.Windows.Forms.RadioButton();
            this.newPoint = new System.Windows.Forms.RadioButton();
            this.deletePoint = new System.Windows.Forms.RadioButton();
            this.newPolygon = new System.Windows.Forms.RadioButton();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape5 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessBar)).BeginInit();
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
            this.pictureBox.Size = new System.Drawing.Size(1320, 616);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.PictureBoxClick);
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxPaint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseUp);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(7, 45);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(92, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Dodaj wielokąt";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.thicknessBar);
            this.groupBox.Controls.Add(this.changeColor);
            this.groupBox.Controls.Add(this.markPoly);
            this.groupBox.Controls.Add(this.deleteButton);
            this.groupBox.Controls.Add(this.movePolygon);
            this.groupBox.Controls.Add(this.deletePolygon);
            this.groupBox.Controls.Add(this.movePoint);
            this.groupBox.Controls.Add(this.newPoint);
            this.groupBox.Controls.Add(this.deletePoint);
            this.groupBox.Controls.Add(this.newPolygon);
            this.groupBox.Controls.Add(this.addButton);
            this.groupBox.Controls.Add(this.shapeContainer1);
            this.groupBox.Location = new System.Drawing.Point(93, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(1121, 87);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Menu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(951, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Grubość linii";
            // 
            // thicknessBar
            // 
            this.thicknessBar.Location = new System.Drawing.Point(945, 45);
            this.thicknessBar.Maximum = 3;
            this.thicknessBar.Minimum = 1;
            this.thicknessBar.Name = "thicknessBar";
            this.thicknessBar.Size = new System.Drawing.Size(154, 45);
            this.thicknessBar.TabIndex = 7;
            this.thicknessBar.Value = 1;
            this.thicknessBar.Scroll += new System.EventHandler(this.ThicknessBarScroll);
            // 
            // changeColor
            // 
            this.changeColor.Location = new System.Drawing.Point(835, 19);
            this.changeColor.Name = "changeColor";
            this.changeColor.Size = new System.Drawing.Size(75, 23);
            this.changeColor.TabIndex = 5;
            this.changeColor.Text = "Zmień kolor";
            this.changeColor.UseVisualStyleBackColor = true;
            this.changeColor.Click += new System.EventHandler(this.ChangeColorClick);
            // 
            // markPoly
            // 
            this.markPoly.AutoSize = true;
            this.markPoly.Location = new System.Drawing.Point(690, 20);
            this.markPoly.Name = "markPoly";
            this.markPoly.Size = new System.Drawing.Size(108, 17);
            this.markPoly.TabIndex = 4;
            this.markPoly.TabStop = true;
            this.markPoly.Text = "Zaznacz wielokąt";
            this.markPoly.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(233, 41);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(84, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Usuń wielokąt";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButtonClick);
            // 
            // movePolygon
            // 
            this.movePolygon.AutoSize = true;
            this.movePolygon.Location = new System.Drawing.Point(557, 20);
            this.movePolygon.Name = "movePolygon";
            this.movePolygon.Size = new System.Drawing.Size(105, 17);
            this.movePolygon.TabIndex = 3;
            this.movePolygon.TabStop = true;
            this.movePolygon.Text = "Przesuń wielokąt";
            this.movePolygon.UseVisualStyleBackColor = true;
            // 
            // deletePolygon
            // 
            this.deletePolygon.AutoSize = true;
            this.deletePolygon.Location = new System.Drawing.Point(233, 18);
            this.deletePolygon.Name = "deletePolygon";
            this.deletePolygon.Size = new System.Drawing.Size(92, 17);
            this.deletePolygon.TabIndex = 3;
            this.deletePolygon.TabStop = true;
            this.deletePolygon.Text = "Usuń wielokąt";
            this.deletePolygon.UseVisualStyleBackColor = true;
            // 
            // movePoint
            // 
            this.movePoint.AutoSize = true;
            this.movePoint.Location = new System.Drawing.Point(458, 19);
            this.movePoint.Name = "movePoint";
            this.movePoint.Size = new System.Drawing.Size(93, 17);
            this.movePoint.TabIndex = 2;
            this.movePoint.TabStop = true;
            this.movePoint.Text = "Przesuń punkt";
            this.movePoint.UseVisualStyleBackColor = true;
            // 
            // newPoint
            // 
            this.newPoint.AutoSize = true;
            this.newPoint.Location = new System.Drawing.Point(107, 23);
            this.newPoint.Name = "newPoint";
            this.newPoint.Size = new System.Drawing.Size(82, 17);
            this.newPoint.TabIndex = 3;
            this.newPoint.TabStop = true;
            this.newPoint.Text = "Nowy punkt";
            this.newPoint.UseVisualStyleBackColor = true;
            // 
            // deletePoint
            // 
            this.deletePoint.AutoSize = true;
            this.deletePoint.Location = new System.Drawing.Point(331, 20);
            this.deletePoint.Name = "deletePoint";
            this.deletePoint.Size = new System.Drawing.Size(80, 17);
            this.deletePoint.TabIndex = 2;
            this.deletePoint.TabStop = true;
            this.deletePoint.Text = "Usuń punkt";
            this.deletePoint.UseVisualStyleBackColor = true;
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
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 16);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape5,
            this.lineShape4,
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1115, 68);
            this.shapeContainer1.TabIndex = 6;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape5
            // 
            this.lineShape5.Name = "lineShape5";
            this.lineShape5.X1 = 927;
            this.lineShape5.X2 = 927;
            this.lineShape5.Y1 = -8;
            this.lineShape5.Y2 = 75;
            // 
            // lineShape4
            // 
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 818;
            this.lineShape4.X2 = 818;
            this.lineShape4.Y1 = -13;
            this.lineShape4.Y2 = 70;
            // 
            // lineShape3
            // 
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 679;
            this.lineShape3.X2 = 679;
            this.lineShape3.Y1 = -5;
            this.lineShape3.Y2 = 78;
            // 
            // lineShape2
            // 
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 206;
            this.lineShape2.X2 = 206;
            this.lineShape2.Y1 = -9;
            this.lineShape2.Y2 = 74;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 441;
            this.lineShape1.X2 = 441;
            this.lineShape1.Y1 = -11;
            this.lineShape1.Y2 = 72;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.pictureBox);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Rysowanie wielokątów";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton newPoint;
        private System.Windows.Forms.RadioButton newPolygon;
        private System.Windows.Forms.RadioButton deletePolygon;
        private System.Windows.Forms.RadioButton deletePoint;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.RadioButton movePolygon;
        private System.Windows.Forms.RadioButton movePoint;
        private System.Windows.Forms.RadioButton markPoly;
        private System.Windows.Forms.Button changeColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar thicknessBar;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape5;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
    }
}

