﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgapysBoxCore.Entity
{
    [Serializable]
    public class UserData
    {
        public UserData()
        {

        }
        public string UserName { get; set; }
        public DateTime Date { get; set; }

    }
}
