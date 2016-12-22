using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace surfnsail.Models
{
    public class SportItem
    {
        public SportItem()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public string PictureName { get; set; }

    }
}
