using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactApplication
{
    public partial class PersonEditForm : Form
    {
        public PersonEditForm()
        {
            // Данный конструктор используется для создания новой записи
            InitializeComponent();
            this.personsTableAdapter.Fill(this.notebookDataSet.Persons);
            this.contactTypeTableAdapter.Fill(this.notebookDataSet.ContactType);
            this.contactsTableAdapter.Fill(this.notebookDataSet.Contacts);


            personsBindingSource.AddNew();
        }
        public PersonEditForm(int index)
        {
            //Данный конструктор используется для редактирования существующей записи
            InitializeComponent();
            this.personsTableAdapter.Fill(this.notebookDataSet.Persons);
            this.contactsTableAdapter.Fill(this.notebookDataSet.Contacts);
            this.contactTypeTableAdapter.Fill(this.notebookDataSet.ContactType);
            personsBindingSource.Position = index;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            personsBindingSource.EndEdit();
            personsTableAdapter.Update(notebookDataSet.Persons);
            contactsTableAdapter.Update(notebookDataSet.Contacts);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

