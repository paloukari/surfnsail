using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace surfnsail.Models
{
    public class SettingItem
    {
        public SettingItem()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public int SportID { get; set; }
    }
}
