﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class ConnectionClass
    {
        public DSAEntities Entity { get; set; }

        public ConnectionClass()
        {
            Entity = new DSAEntities();
        }
    }
}
