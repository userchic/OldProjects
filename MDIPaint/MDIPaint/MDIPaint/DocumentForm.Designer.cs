
namespace MDIPaint
{
    partial class DocumentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Dec_of_Scale = new System.Windows.Forms.ToolStripButton();
            this.ScaleCoefTB = new System.Windows.Forms.ToolStripLabel();
            this.IncOfScale = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Dec_of_Scale,
            this.ScaleCoefTB,
            this.IncOfScale});
            this.toolStrip1.Location = new System.Drawing.Point(0, 136);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(284, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Dec_of_Scale
            // 
            this.Dec_of_Scale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Dec_of_Scale.Image = ((System.Drawing.Image)(resources.GetObject("Dec_of_Scale.Image")));
            this.Dec_of_Scale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Dec_of_Scale.Name = "Dec_of_Scale";
            this.Dec_of_Scale.Size = new System.Drawing.Size(23, 22);
            this.Dec_of_Scale.Text = "toolStripButton1";
            this.Dec_of_Scale.Click += new System.EventHandler(this.Dec_of_Scale_Click);
            // 
            // ScaleCoefTB
            // 
            this.ScaleCoefTB.Name = "ScaleCoefTB";
            this.ScaleCoefTB.Size = new System.Drawing.Size(35, 22);
            this.ScaleCoefTB.Text = "100%";
            // 
            // IncOfScale
            // 
            this.IncOfScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.IncOfScale.Image = ((System.Drawing.Image)(resources.GetObject("IncOfScale.Image")));
            this.IncOfScale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.IncOfScale.Name = "IncOfScale";
            this.IncOfScale.Size = new System.Drawing.Size(23, 22);
            this.IncOfScale.Text = "toolStripButton2";
            this.IncOfScale.Click += new System.EventHandler(this.IncOfScale_Click);
            // 
            // DocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "DocumentForm";
            this.Text = "DocumentForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DocumentForm_FormClosed);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DocumentForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DocumentForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DocumentForm_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Dec_of_Scale;
        private System.Windows.Forms.ToolStripLabel ScaleCoefTB;
        private System.Windows.Forms.ToolStripButton IncOfScale;
    }
}