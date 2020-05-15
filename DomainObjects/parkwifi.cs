using System;
using System.Collections.Generic;
using System.Text;

namespace parkWiFis.DomainObjects
{
    public class parkWiFi : DomainObject
    {
        public string parkname { get; set; }
        public string wifiname { get; set; }
        public string status { get; set; }

        public string Name { get; set; }

    }
}
