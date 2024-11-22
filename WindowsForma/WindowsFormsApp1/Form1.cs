using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        bool farrenheit=false;
        bool celcius=true;
        WindowsFormsApp1.ServiceReference1.ConversionServiceClient service = new ServiceReference1.ConversionServiceClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num;
            if (double.TryParse(label1.Text, out num))
            { 
                if (farrenheit)
                {
                    farrenheit = false;
                    celcius = true;
                    label1.Text = service.FahrenheitToCelsius(double.Parse(label1.Text)).ToString();
                }
            }
            else
                MessageBox.Show("Это не вещественное число и видимо вообще не число");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double num;
            if (double.TryParse(label1.Text, out num))
            {
                if (celcius)
                {
                    celcius = false;
                    farrenheit = true;
                    label1.Text = service.CelsiusToFahrenheit(double.Parse(label1.Text)).ToString();
                }
            }
            else
                MessageBox.Show("Это не вещественное число и видимо вообще не число");
        }
    }
}
