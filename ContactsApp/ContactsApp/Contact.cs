﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// A class containing all information about the contact.
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Contact's surname.
        /// </summary>
        private string _surname;
        /// <summary>
        /// Contact's surname.
        /// </summary>
        private string _name;
        /// <summary>
        /// Contact's birthday.
        /// </summary>
        private DateTime _dateBirth;
        /// <summary>
        /// Contact's email.
        /// </summary>
        private string _email;
        /// <summary>
        /// Contact's ID Vkontakte.
        /// </summary>
        private string _vkID;
        /// <summary>
        /// Returns and sets the contact's surname.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                Validator.AssertEmptyString(value);
                Validator.AssertStringInRange(value, 0, 50);
                _surname = Validator.MakeUpperCase(value);
            }
        }
        /// <summary>
        /// Returns and sets the contact's name.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Validator.AssertEmptyString(value);
                Validator.AssertStringInRange(value, 0, 50);
                _name = Validator.MakeUpperCase(value);
            }
        }
        /// <summary>
        /// Contact's number.
        /// </summary>
        public PhoneNumber Number { get; set; }
        /// <summary>
        /// Returns and sets the contact's birthday.
        /// </summary>
        /// 
        public DateTime DateBirth
        {
            get
            {
                return _dateBirth;
            }
            set
            {
                if ((value.Year < 1900) || (value > DateTime.Now))
                {
                    throw new ArgumentException(value.Year + " "
                        + "must be in the range from" + 1900 + "to" + DateTime.Now);
                }
                _dateBirth = value;
            }
        }
        /// <summary>
        /// Returns and sets the contact's email.
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                Validator.AssertEmptyString(value);
                Validator.AssertStringInRange(value, 0, 50);
                _email = value;
            }
        }
        /// <summary>
        /// Returns and sets the contact's ID Vkontakte.
        /// </summary>
        public string VKID
        {
            get
            {
                return _vkID;
            }
            set
            {
                Validator.AssertEmptyString(value);
                Validator.AssertStringInRange(value, 0, 15);
                _vkID = value;
            }
        }
        /// <summary>
        /// Creates a contact.
        /// </summary>
        /// <param name="surname">Contact's surname.</param>
        /// <param name="name">Contact's name..</param>
        /// <param name="number">Contact's number.</param>
        /// <param name="dateBirth">Contact's birthday.</param>
        /// <param name="email">Contact's email.</param>
        /// <param name="vkID">A double precision number.</param>

        public Contact(string surname, string name, PhoneNumber number,
                       DateTime dateBirth, string email, string vkID)
        {
            this.Name = name;
            this.Surname = surname;
            this.Number = number;
            this.DateBirth = dateBirth;
            this.Email = email;
            this.VKID = vkID;
        }
        /// <summary>
        /// Makes a copy of the object <see cref="Contact"/>
        /// </summary>
        public object Clone()
        {
            return new Contact(Surname = this.Surname, Name = this.Name,
                Number = this.Number, DateBirth = this.DateBirth,
                Email = this.Email, VKID = this.VKID);
        }
    }
}
