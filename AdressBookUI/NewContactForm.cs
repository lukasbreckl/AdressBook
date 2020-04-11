using ABLibrary;
using ABLibrary.DataAccess;
using ABLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdressBookUI
{
    public partial class NewContactForm : Form
    {
        public NewContactForm()
        {
            InitializeComponent();
        }

        private void createNewContactButton_Click(object sender, EventArgs e)
        {
            ContactModel NewContact = new ContactModel(firstNameTextBox.Text, lastNameTextBox.Text, phoneNumberTextBox.Text);
            GlobalConfig.Connection.CreateContact(NewContact);

                firstNameTextBox.Text = "";
                lastNameTextBox.Text = "";
                phoneNumberTextBox.Text = "";
            MessageBox.Show("Contact successfully added.");
            
        }
    }
}
