using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Windows.Forms;
namespace MiniProjectDatabase.asset.database
{
    class database
    {
        OracleConnection ORCL;
        // private string ip = "192.168.142.128";
        //private string ip = "192.168.27.128";
        private string ip = "192.168.93.129";
        private string id = "ora1";
        private string password = "ora1";

        public OracleConnection OracleConnect
        {
            get { return ORCL; }
            set { ORCL = value; }
        }
        public database()
        {
            ORCL = new OracleConnection($"Data Source={ip}/orcl;User ID={id};Password={password};Unicode=True");
        }
        public void openconnect()
        {
            try
            {
                if (OracleConnect.State == System.Data.ConnectionState.Closed)
                {
                    ORCL.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            
        }
        public void closeconnect()
        {
            ORCL.Close();
        }
        public bool CheckState()
        {
            if(OracleConnect.State == System.Data.ConnectionState.Closed)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
