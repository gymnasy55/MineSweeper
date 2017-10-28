namespace MineSweeper
{
    partial class CustomForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLenght = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMines = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the number of cells in the length";
            // 
            // txtLenght
            // 
            this.txtLenght.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLenght.Location = new System.Drawing.Point(17, 41);
            this.txtLenght.Name = "txtLenght";
            this.txtLenght.Size = new System.Drawing.Size(384, 32);
            this.txtLenght.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(395, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter the number of cells in the height";
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.Location = new System.Drawing.Point(17, 103);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(384, 32);
            this.txtHeight.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(67, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Enter the number of mines";
            // 
            // txtMines
            // 
            this.txtMines.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMines.Location = new System.Drawing.Point(17, 165);
            this.txtMines.Name = "txtMines";
            this.txtMines.Size = new System.Drawing.Size(384, 32);
            this.txtMines.TabIndex = 5;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStart.Location = new System.Drawing.Point(17, 203);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(384, 70);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "OK";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // CustomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 303);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtMines);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLenght);
            this.Controls.Add(this.label1);
            this.Name = "CustomForm";
            this.Text = "MineSweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLenght;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMines;
        private System.Windows.Forms.Button btnStart;
    }
}