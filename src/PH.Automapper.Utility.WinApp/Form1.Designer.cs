
namespace PH.Automapper.Utility.WinApp
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAssembly = new System.Windows.Forms.TextBox();
            this.btnSelectAssembly = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Assembly File (.dll)";
            // 
            // txtAssembly
            // 
            this.txtAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssembly.Location = new System.Drawing.Point(158, 12);
            this.txtAssembly.Name = "txtAssembly";
            this.txtAssembly.Size = new System.Drawing.Size(549, 23);
            this.txtAssembly.TabIndex = 1;
            // 
            // btnSelectAssembly
            // 
            this.btnSelectAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAssembly.Location = new System.Drawing.Point(713, 11);
            this.btnSelectAssembly.Name = "btnSelectAssembly";
            this.btnSelectAssembly.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAssembly.TabIndex = 2;
            this.btnSelectAssembly.Text = "Select Assembly";
            this.btnSelectAssembly.UseVisualStyleBackColor = true;
            this.btnSelectAssembly.Click += new System.EventHandler(this.btnSelectAssembly_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.CheckBoxes = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(158, 41);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(549, 297);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sources";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnSelectAssembly);
            this.Controls.Add(this.txtAssembly);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAssembly;
        private System.Windows.Forms.Button btnSelectAssembly;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
    }
}

