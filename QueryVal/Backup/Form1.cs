//************************************************************
// Piter Gavrinev 2008 piter@mail.cbr.ru
// Простой пример использования веб-сервиса для получения курсов валют
// с сервера Центрального Банка РФ 
// http://www.cbr.ru/DailyInfoWebServ/DailyInfo.asmx
//************************************************************

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using System.Net;
using System.Configuration;

using System.Net.Security;
using System.Security.Cryptography.X509Certificates; //for ssl use



namespace QueryValuta
{

	



	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private string Val_code;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Label label4;
		public DailyInfoServ.DailyInfo di;
        private Button button3;
        private CredentialCache myCache;
		public Form1()
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
				if (components != null) 
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(24, 48);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(472, 69);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "ConnectToServer";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(56, 128);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(296, 128);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "С";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(264, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "По";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(16, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 32);
            this.button2.TabIndex = 9;
            this.button2.Text = "Получить курс";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(24, 232);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.Size = new System.Drawing.Size(488, 128);
            this.dataGrid1.TabIndex = 10;
            this.dataGrid1.DoubleClick += new System.EventHandler(this.dataGrid1_DoubleClick);
            this.dataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid1_Navigate);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(488, 16);
            this.label3.TabIndex = 11;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(264, 193);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(240, 16);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Валюты, устанавливаемые ежемесячно";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 365);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(520, 32);
            this.statusBar1.TabIndex = 13;
            this.statusBar1.Text = "statusBar1";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(264, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Список валют";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(115, 187);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 15;
            this.button3.Text = "Как xml";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(520, 397);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Пример использования веб-сервиса V 0.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}


        public static bool TrustAllCertificateCallback(object sender,
        X509Certificate cert, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        } 

		private void button1_Click(object sender, System.EventArgs e)
		{
            try
            {
                int i;
                System.Data.DataSet my_dataset;
                System.Data.DataRow row;

                string v_name, v_id;
                IWebProxy I_DefWP=null;
                if (di == null)
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback (TrustAllCertificateCallback);

                    I_DefWP = WebRequest.DefaultWebProxy; // если используется web-прокси по умолчанию
                    
                    
                    if ((I_DefWP != null) && (I_DefWP.Credentials==null))
                    {
                        
                        Uri uriDest = I_DefWP.GetProxy(new Uri(QueryValuta.Properties.Settings.Default.QueryValuta_DailyInfoServ_DailyInfo));
                        
                        s_Config sc = new s_Config();
                        QW_ConfData mw = sc.LoadData(); // получаем данные из файла конфигурации если они есть
                        DialogResult res;
                        ProxyParam pp;
                        pp = new ProxyParam();
                        pp.mw_edt = mw;
                        if (mw.PWD == null)
                        {
                        
                             res = pp.ShowDialog();
                        }
                        else
                        {
                            res = DialogResult.OK;
                        }
                        if (res == DialogResult.OK)
                        {
                            mw = pp.mw_edt;
                            sc.SaveData(mw); // сохраняем данные в файле


                            if ((mw.AuthType.ToLower() == "basic"))
                            {
                                // для Basic
                                I_DefWP.Credentials = new System.Net.NetworkCredential(mw.UserName, mw.PWD);
                            }
                            else
                            {
                                // для остальных типов
                                NetworkCredential myCred = new NetworkCredential(mw.UserName, mw.PWD, mw.Domain);
                                myCache = new CredentialCache();
                                myCache.Add(uriDest, mw.AuthType, myCred);
                                I_DefWP.Credentials = myCache;
                            }



                            statusBar1.Text = "try connect via proxy (auth mode)... " + uriDest.AbsoluteUri;
                        }
                        else
                        {
                            statusBar1.Text = "try connect via proxy (not auth mode)... " + uriDest.AbsoluteUri;
                        }
                    }
                    else
                    {
                        statusBar1.Text = "try connect ...";
                    }
                    di = new DailyInfoServ.DailyInfo();
                   
                    if (I_DefWP != null)
                    {
                        di.AllowAutoRedirect = true;
                        di.PreAuthenticate = true;
                        di.Proxy = I_DefWP;
                    }
                           

                }

                
                // Получаем список валют в DataSet
                my_dataset = (System.Data.DataSet)di.EnumValutes(checkBox1.Checked); //Получаем список валют
                statusBar1.Text = "получаем последнюю дату зарегистр. курсов";


                System.Data.DataTable tbl = my_dataset.Tables["EnumValutes"];
                listBox1.BeginUpdate();
                ArrayList ValutesNames = new ArrayList();
                // заполняем список(listBox1) валютами полученными с сервера
                for (i = 0; i < tbl.Rows.Count; i++)
                {
                    row = tbl.Rows[i];
                    v_id = (string)row.ItemArray.GetValue(0);
                    v_id = v_id.Trim();
                    v_name = (string)row.ItemArray.GetValue(1);
                    v_name = v_name.Trim();
                    ValutesNames.Add(new Valute(v_name, v_id));
                }


                listBox1.DataSource = ValutesNames;
                listBox1.DisplayMember = "ValuteName";
                listBox1.ValueMember = "ValuteCode";
                listBox1.EndUpdate();


                System.DateTime dtm;
                if (!checkBox1.Checked)
                {
                    dtm = di.GetLatestDateTime();
                    listBox1.SelectedValue = "R01235"; // устанавливаем валюту Доллар США как валюту по умолчанию
                }
                else
                {
                    dtm = di.GetLatestDateTimeSeld();
                }
                dateTimePicker2.MaxDate = dtm;
                dateTimePicker2.Value = dtm;
                button2.Enabled = true;
                button3.Enabled = true;
                statusBar1.Text = "все данные получены, теперь нажмите 'Получить курс'.";
            }
            catch (Exception ex)
            {
                string err_msg = "Ошибка: " + ex.Message;
                MessageBox.Show(err_msg, "Ошибка");
                statusBar1.Text = err_msg;

            }
		}

		private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (listBox1.SelectedIndex != -1){

				Val_code=listBox1.SelectedValue.ToString();
				label3.Text=listBox1.SelectedItem.ToString();

				}
		}

	

		private void button2_Click(object sender, System.EventArgs e)
		{
			
			System.Data.DataSet val_ds;
			System.DateTime  DateFrom,DateTo;
			DateFrom=dateTimePicker1.Value;
			DateTo=dateTimePicker2.Value;
			if (Val_code!="")
			{
			//Вызываем GetCursDynamic для получения таблицы с курсами заданной валюты
			statusBar1.Text="пробуем получить курс.";
			val_ds=(System.Data.DataSet)di.GetCursDynamic(DateFrom,DateTo,Val_code);
			statusBar1.Text="курс валюты получен, кликнете два раза по левой колонке для получения списка валют на дату";
			val_ds.Tables[0].Columns[0].ColumnName="Дата";
			val_ds.Tables[0].Columns[1].ColumnName="Вн.код валюты";
			val_ds.Tables[0].Columns[2].ColumnName="Номинал";
			val_ds.Tables[0].Columns[3].ColumnName="Курс";
				
			dataGrid1.SetDataBinding(val_ds,"ValuteCursDynamic");
				dataGrid1.Enabled=true;
		
			
			}
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (di!=null)
			{
			button1.PerformClick();
			dataGrid1.Enabled=false;
			}
		}

		

		

		private void dataGrid1_DoubleClick(object sender, System.EventArgs e)
		{
			System.Data.DataSet ds_grid;
			System.Data.DataRow row;
			int row_index;
			row_index=dataGrid1.CurrentRowIndex;
			if (row_index>-1)
			{
				ds_grid=(System.Data.DataSet)dataGrid1.DataSource;
				DailyForm df=new DailyForm();
				df.mdi=di;
				df.is_seld=checkBox1.Checked;
				row=ds_grid.Tables[0].Rows[row_index];
				
				df.selected_date=(System.DateTime)row[0];
				df.Text="Курсы валют на "+((System.DateTime)row[0]).ToString("dd.MM.yyyy",DateTimeFormatInfo.InvariantInfo);
				df.ShowDialog(this);
				df.Dispose();
			}

		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			statusBar1.Text="Нажмите ConnectToServer для соединения с веб-сервисом";
		}

        private void dataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // получаем данные о динамике курса в виде простого XML
			System.DateTime  DateFrom,DateTo;
			DateFrom=dateTimePicker1.Value;
			DateTo=dateTimePicker2.Value;
            if (Val_code != "")
            {
               System.Xml.XmlNode ret_xml = di.GetCursDynamicXML(DateFrom,DateTo,Val_code);
               MessageBox.Show(ret_xml.InnerXml, "Simple XML (GetCursDynamicXML)");
               
            }
        }

	
		}

    public class Valute
    {
        private string str_ValuteCode;
        private string str_ValuteName;

        public Valute(string ValuteNameStr, string ValuteCodeStr)
        {

            this.str_ValuteCode = ValuteCodeStr;
            this.str_ValuteName = ValuteNameStr;
        }

        public string ValuteCode
        {
            get
            {
                return str_ValuteCode;
            }
        }

        public string ValuteName
        {

            get
            {
                return str_ValuteName;
            }
        }

        public override string ToString()
        {
            return this.str_ValuteName + " - " + this.str_ValuteCode;
        }

        

       
    }

      

    }
