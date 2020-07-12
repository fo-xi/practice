﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsApp;

namespace ContactsAppUserInterface
{ //TODO: зачем увеличен размер шрифта у лейблов на форме? (+)
    //TODO: проверь и исправь резиновость формы (+)
    public partial class ContactForm : Form
    { //TODO: xml (+) //TODO: одна пустая строка между членами класса (+)
        /// <summary>
        /// Sets and returns contact information.
        /// </summary>
        public Contact Contact { set; get; }

        public ContactForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                var phoneNumber = new PhoneNumber(PhoneTextBox.Text);
                Contact = new Contact(SurnameTextBox.Text,
                            NameTextBox.Text, phoneNumber,
                            BirthdayDateTimePicker.Value, EmailTextBox.Text,
                            VkIDTextBox.Text);
                this.Close();
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        } //TODO: грамошибка в названии метода (+)

        private void DisplayInformation(object sender, EventArgs e)
        {
            if (Contact != null)
            {
                SurnameTextBox.Text = Contact.Surname;
                NameTextBox.Text = Contact.Name;
                BirthdayDateTimePicker.Value = Contact.DateBirth;
                PhoneTextBox.Text = Contact.Number.Number;
                EmailTextBox.Text = Contact.Email;
                VkIDTextBox.Text = Contact.VKID;
            }
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validator.AssertStringLength(SurnameTextBox.Text, 0, 50);
                SurnameTextBox.BackColor = Color.White;
            }            catch            {
                SurnameTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validator.AssertStringLength(NameTextBox.Text, 0, 50);
                NameTextBox.BackColor = Color.White;
            }            catch            {
                NameTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validator.AssertStringLength(EmailTextBox.Text, 0, 50);
                EmailTextBox.BackColor = Color.White;
            }            catch            {
                EmailTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validator.AssertPhoneNumber(PhoneTextBox.Text);
                Validator.AssertStringLength(PhoneTextBox.Text, 0, 11);
                PhoneTextBox.BackColor = Color.White;
            }
            catch
            {
                if (PhoneTextBox.Text.Length == 0)
                {
                    PhoneTextBox.BackColor = Color.White;
                }
                PhoneTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void VkIDTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validator.AssertStringLength(VkIDTextBox.Text, 0, 15);
                VkIDTextBox.BackColor = Color.White;
            }            catch            {
                VkIDTextBox.BackColor = Color.LightSalmon;
            }
        }
    }
}
