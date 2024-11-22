using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace QueryValuta
{
	/// <summary>
	/// Summary description for DailyForm.
	/// </summary>
	public class DailyForm : System.Windows.Forms.Form
	{
		public bool is_seld;
		public System.Data.DataSet DailyDs;
		public 	System.DateTime selected_date;
		public DailyInfoServ.DailyInfo mdi;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DailyForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(16, 32);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.Size = new System.Drawing.Size(440, 296);
            this.dataGrid1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save to XML file";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "Curses.xml";
            this.saveFileDialog1.Filter = "XML files |*.xml";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(137, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "xsd Схема";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DailyForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(472, 334);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGrid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DailyForm";
            this.Text = "DailyForm";
            this.Load += new System.EventHandler(this.DailyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void DailyForm_Load(object sender, System.EventArgs e)
		{
			
						
			//Получение курса валют на дату
			if (is_seld==false)		DailyDs=mdi.GetCursOnDate(selected_date); // для ежедневных
			else 	DailyDs=mdi.GetSeldCursOnDate(selected_date); // для ежемесячных
			System.Data.DataSet ds=DailyDs.Copy();

			ds.Tables[0].Columns[0].ColumnName="Название валюты";
			ds.Tables[0].Columns[1].ColumnName="Номинал";
			ds.Tables[0].Columns[2].ColumnName="Курс";
			ds.Tables[0].Columns[3].ColumnName="Числ.код";
			ds.Tables[0].Columns[4].ColumnName="Стр.код";
			dataGrid1.SetDataBinding(ds,"ValuteCursOnDate");
			
	
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
		System.Windows.Forms.DialogResult res=saveFileDialog1.ShowDialog(this);
			if (res==System.Windows.Forms.DialogResult.OK)
			{
	
				DailyDs.WriteXml(saveFileDialog1.FileName);
                
			}
		}

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DailyDs.GetXmlSchema());
           
        }
	}
}
