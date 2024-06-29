using System;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITestService" in both code and config file together.
    [ServiceContract]

    public interface ITestService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
           ResponseFormat = WebMessageFormat.Json,
           RequestFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped, // has to be Wrapped for POST method
           UriTemplate = "DoWork/")]
        List<TestClass> DoWork(TestRequest request);

        [OperationContract]
        [WebInvoke(Method = "GET",
           // ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "Ping/")]
        string Ping();
    }
}
