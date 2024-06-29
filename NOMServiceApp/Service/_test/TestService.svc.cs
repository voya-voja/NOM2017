﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

using NOMServiceApp.Common._test;
using NOMServiceApp.Business._test;

namespace NOMServiceApp.Service._test
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TestService.svc or TestService.svc.cs at the Solution Explorer and start debugging.
    public class TestService : ITestService
    {
        public List<TestClass> DoWork(TestRequest request)
        {
            try
            {
                TestFunctionality test = TestFunctionality.Instance(request);
                return (test.Execute());
            }
            catch(Exception e)
            {
                throw new WebFaultException(System.Net.HttpStatusCode.Forbidden);
            }
        }

        public string Ping()
        {
            string response = "PING response: Test was sucessful.";
            return (response);
        }
    }
}
