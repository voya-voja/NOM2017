using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Odbc;

namespace NOMServiceApp.Persistence
{
    public abstract class Persister
    {
        // MS Access connection string
        //private static string gmConnectionString = @"Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\Users\Public\Documents\My Deliveries\Clients\Scotiabank\NOM\Model\NOM 06.09.16 Final\ScotiaData.mdb";
        private static string gmConnectionString = @"DRIVER={SQL Server};SERVER=CA2155632W0\VNVSQLSERVER;Trusted_connection=yes;DATABASE=ScotiaNOMdb;";
        private static string gmTableNamePrefix = " [dbo].[";

        private OdbcConnection mConnection;

        protected Persister()
        {
            mConnection = new OdbcConnection(gmConnectionString);
        }

        protected OdbcConnection connection { get { return (mConnection); } }      
        
        protected OdbcCommand createCommand( string cmdStr, string tableName)
        {
            return (new OdbcCommand(cmdStr + gmTableNamePrefix+ tableName + "];", connection));
        }
    }
}