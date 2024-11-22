using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace QueryValuta
{
    public partial class ProxyParam : Form
    {
        public QW_ConfData mw_edt;
        public ProxyParam()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                mw_edt.AuthType = this.Edt_AuthType.Text;
                mw_edt.Domain = this.Edt_Domain.Text;
                mw_edt.PWD = this.Edt_Password.Text;
                mw_edt.UserName = this.Edt_UserName.Text;

                if (mw_edt.UserName == "") return;
               // s_Config sc = new s_Config();
                //sc.SaveData(mw);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                string err_msg = "Ошибка: " + ex.Message;
                MessageBox.Show(err_msg, "Ошибка");
                

            }

        }

        private void ProxyParam_Load(object sender, EventArgs e)
        {
            
            Edt_AuthType.Items.Add("Basic");
            Edt_AuthType.Items.Add("Kerberos");
            Edt_AuthType.Items.Add("NTLM");
            Edt_AuthType.Items.Add("Negotiate");
            Edt_AuthType.SelectedIndex = 0;
            

        }

        private void ProxyParam_Shown(object sender, EventArgs e)
        {
            this.Edt_Domain.Text = mw_edt.Domain;
            this.Edt_Password.Text = mw_edt.PWD;
            this.Edt_UserName.Text = mw_edt.UserName;
            this.Edt_AuthType.Text = mw_edt.AuthType;
        }
    }



    // данные для авторизации на прокси-сервере
    [Serializable()]	
    public struct QW_ConfData 
    {
        public string UserName;
        public string PWD;
        public string Domain;
        public string AuthType;
 
        

    }
    //**************************************************************
    // Это класс сохранения - загрузки параметров из файла
    // если необходимо можно использовать любые другие методы сохранения данных
    //***************************************************
    public class s_Config 
    {
        public bool SaveData(QW_ConfData qw_s)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream("QWconf.dat", FileMode.Create);
            formatter.Serialize(fs, qw_s);
            fs.Close();
            return true;

        }
        public QW_ConfData LoadData()
        {
            QW_ConfData o_w=new QW_ConfData();
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fs = new FileStream("QWconf.dat", FileMode.Open);
                o_w = (QW_ConfData)formatter.Deserialize(fs);
                fs.Close();
                return o_w;
            }
            catch
            {
                o_w.UserName = "Test";
                o_w.AuthType = "Basic";
                return o_w;
            }
        }
    }

}
