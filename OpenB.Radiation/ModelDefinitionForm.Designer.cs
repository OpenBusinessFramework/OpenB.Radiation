namespace OpenB.Radiation
{
    partial class ModelDefinitionForm
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
            this.textKey = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Key";
            // 
            // textKey
            // 
            this.textKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textKey.Location = new System.Drawing.Point(99, 12);
            this.textKey.Name = "textKey";
            this.textKey.Size = new System.Drawing.Size(211, 24);
            this.textKey.TabIndex = 1;
            this.textKey.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textName
            // 
            this.textName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textName.Location = new System.Drawing.Point(99, 38);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(211, 24);
            this.textName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // textDescription
            // 
            this.textDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDescription.Location = new System.Drawing.Point(99, 64);
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(510, 89);
            this.textDescription.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(453, 166);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(534, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ModelDefinitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 201);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.textDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textKey);
            this.Controls.Add(this.label1);
            this.Name = "ModelDefinitionForm";
            this.Text = "Create new Model Definition";
            this.Load += new System.EventHandler(this.ModelDefinitionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textKey;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}