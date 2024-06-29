using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace NOMServiceApp.Common._test
{
    [DataContract]
    public class TestClass
    {
        [DataMember]
        public string member1 { get; set; }

        [DataMember]
        public string member2 { get; set; }
    }
}