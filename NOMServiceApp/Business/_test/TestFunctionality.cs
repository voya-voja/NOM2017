using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

using NOMServiceApp.Common._test;
using NOMServiceApp.Persistence._test;

namespace NOMServiceApp.Business._test
{
    [DataContract]
    public class TestRequest
    {
        [DataMember]
        public string arg1 { get; set; }

        [DataMember]
        public string arg2 { get; set; }
    }

    public class TestFunctionality
    {
        TestRequest mRequest;

        public static TestFunctionality Instance(TestRequest request)
        {
            if(("test".Equals(request.arg1) && "Data".Equals(request.arg2)))
            {
                return (new TestFunctionality(request));
            }
            else
            {
                throw new Exception("Incorect Test request arguments. Pleas conntact NOM admin.");
            }
        }
        protected TestFunctionality(TestRequest request)
        {
            mRequest = request;
        }

        private TestFunctionality() { }

        public List<TestClass> Execute()
        {
            TestClassPersister persister = TestClassPersister.Instance();
            return (persister.execute());
        }
    }
}