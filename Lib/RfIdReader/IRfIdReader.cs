﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet_Library.RfIdReader
{
    public interface IRfIdReader
    {
        event EventHandler<RfidEventArgs> RfidEvent;
    }
}
