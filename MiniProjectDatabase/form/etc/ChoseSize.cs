using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;
using MiniProjectDatabase.asset.database;
using MiniProjectDatabase.asset.lib;
namespace MiniProjectDatabase.form.etc
{
    public partial class ChoseSize : Form
    {
        string menu_id;
        string size_id;
        string getsize;
        double getprice;
        database db = new database();
        public string GetSizeID
        {
            get { return size_id; }
            set { size_id = value; }
        }
        public string GetSize
        {
            get { return getsize; }
            set { getsize = value; }
        }
        public double GetPrice
        {
            get { return getprice; }
            set { getprice = value; }
        }
        public ChoseSize(string menu_id)
        {
            InitializeComponent();
            this.menu_id = menu_id;
        }
        
        private void GenerateControl()
        {
            flowLayoutPanel1.Controls.Clear();
            db.openconnect();
            string sql = $"SELECT envy_size.sizename,envy_size.size_id from envy_menu_size inner join envy_size on envy_menu_size.size_id = envy_size.size_id Where menu_id = '{menu_id}'";

            OracleCommand orcl = new OracleCommand(sql,db.OracleConnect);
            OracleDataReader reader = orcl.ExecuteReader();
            MenuList[] allrecord;
            List<MenuList> mList = new List<MenuList>();
            while (reader.Read())
            {

                mList.Add(new MenuList { MSize = reader.GetString(0),SizeID = reader.GetString(1)});
                
            }
             allrecord = mList.ToArray();
            ChoseSizeControl[] list = new ChoseSizeControl[allrecord.Length];

            string[] sizeid = new string[allrecord.Length];
            string[] sizename = new string[allrecord.Length];
            
            int x = 0;
            foreach (MenuList s in allrecord)
            {
                sizename[x] = s.MSize;
                sizeid[x] = s.SizeID;
                x++;
            }

            for (int i = 0; i < list.Length; i++)
            {
                list[i] = new ChoseSizeControl();
                list[i].Sizes = sizename[i];
                list[i].SizeIDs = sizeid[i];
                flowLayoutPanel1.Controls.Add(list[i]);

                list[i].Click += new System.EventHandler(this.UserControl_Click);
            }

        }

        void UserControl_Click(object sender, EventArgs e)
        {
            ChoseSizeControl obj = (ChoseSizeControl)sender;
            GetSize = obj.Sizes;
            GetSizeID = obj.SizeIDs;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ChoseSize_Load(object sender, EventArgs e)
        {
            GenerateControl();
        }
    }


}
