﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq; //Deze namespace is heel belangerijk

namespace _1._2_telefoonboek.uitwerking
{
    public class TelephoneBook : ITelephoneBook
    {
        public IList<IPerson> People { get; set; }

        /// <summary>
        /// Lege constructor
        /// </summary>
        public TelephoneBook()
        {
            People = new List<IPerson>();
        }

        /// <summary>
        /// Constructor op basis van lijst
        /// </summary>
        public TelephoneBook(List<IPerson> people)
        {
            this.People = people;
        }

        public int Count
        {
            get { return this.People.Count; }
        }

        public List<IPerson> SortByLastName()
        {
            return People.OrderBy(m => m.LastName).ToList();
        }

        public List<IPerson> FirstNameStartWith(char firstChar)
        {
            return People
                .Where(p => p.FirstName[0] == firstChar)
                .OrderBy(m => m.LastName).ToList();
        }

        public List<IPerson> LastNameLongerThen(int length)
        {
            return People
                 .Where(p => p.LastName.Length > length)
                 .OrderBy(m => m.LastName).ToList();
        }

        public List<IPerson> SortByLastNameLength()
        {
            return People.OrderBy(p => p.LastName.Length).ToList();
        }
    }
}
