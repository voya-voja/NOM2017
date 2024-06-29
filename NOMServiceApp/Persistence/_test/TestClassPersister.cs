using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using System.Data;

using NOMServiceApp.Common._test;

namespace NOMServiceApp.Persistence._test
{
    public class TestClassPersister : Persister
    {
        public static TestClassPersister Instance()
        {
            return (new TestClassPersister());
        }

        protected TestClassPersister() { }

        public List<TestClass> execute()
        {
            List<TestClass> testObjects = new List<TestClass>();
            using (connection)
            {
                connection.Open();
                OdbcCommand command = createCommand("select * from ", "UserTable");

                // Execute the DataReader and access the data.
                OdbcDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TestClass item = new TestClass();
                    item.member1 = (string)reader["USER_ID"];
                    item.member2 = (string)reader["USER_NAME"];
                    testObjects.Add(item);
                }
                reader.Close();
                connection.Close();
            }
            return (testObjects);
        }
    }
}