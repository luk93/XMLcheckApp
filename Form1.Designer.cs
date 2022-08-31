
namespace XMLcheckApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxXmlPath = new System.Windows.Forms.TextBox();
            this.buttonCheckXml = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonGetDynText = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripSL = new System.Windows.Forms.ToolStripStatusLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonGetDataCSExcel = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(454, 12);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select XML Path";
            // 
            // textBoxXmlPath
            // 
            this.textBoxXmlPath.Location = new System.Drawing.Point(99, 14);
            this.textBoxXmlPath.Name = "textBoxXmlPath";
            this.textBoxXmlPath.Size = new System.Drawing.Size(349, 20);
            this.textBoxXmlPath.TabIndex = 2;
            // 
            // buttonCheckXml
            // 
            this.buttonCheckXml.Location = new System.Drawing.Point(174, 40);
            this.buttonCheckXml.Name = "buttonCheckXml";
            this.buttonCheckXml.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckXml.TabIndex = 3;
            this.buttonCheckXml.Text = "Operation 1";
            this.buttonCheckXml.UseVisualStyleBackColor = true;
            this.buttonCheckXml.Click += new System.EventHandler(this.buttonCheckXml_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Check Devices in CS XML";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Get Dynamic Textes (with @)";
            // 
            // buttonGetDynText
            // 
            this.buttonGetDynText.Location = new System.Drawing.Point(174, 66);
            this.buttonGetDynText.Name = "buttonGetDynText";
            this.buttonGetDynText.Size = new System.Drawing.Size(75, 23);
            this.buttonGetDynText.TabIndex = 5;
            this.buttonGetDynText.Text = "Operation 2";
            this.buttonGetDynText.UseVisualStyleBackColor = true;
            this.buttonGetDynText.Click += new System.EventHandler(this.buttonGetDynText_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSL});
            this.statusStrip1.Location = new System.Drawing.Point(0, 120);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(547, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripSL
            // 
            this.toolStripSL.Name = "toolStripSL";
            this.toolStripSL.Size = new System.Drawing.Size(89, 17);
            this.toolStripSL.Text = "toolStripStatusLabel1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Get Data From CS excel file";
            // 
            // buttonGetDataCSExcel
            // 
            this.buttonGetDataCSExcel.Location = new System.Drawing.Point(454, 40);
            this.buttonGetDataCSExcel.Name = "buttonGetDataCSExcel";
            this.buttonGetDataCSExcel.Size = new System.Drawing.Size(75, 23);
            this.buttonGetDataCSExcel.TabIndex = 8;
            this.buttonGetDataCSExcel.Text = "Operation";
            this.buttonGetDataCSExcel.UseVisualStyleBackColor = true;
            this.buttonGetDataCSExcel.Click += new System.EventHandler(this.buttonGetDataCSExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 142);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonGetDataCSExcel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonGetDynText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCheckXml);
            this.Controls.Add(this.textBoxXmlPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "XML Check App by PLRADLIG";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxXmlPath;
        private System.Windows.Forms.Button buttonCheckXml;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonGetDynText;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonGetDataCSExcel;
    }
}

