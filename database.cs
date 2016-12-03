using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace app
{
    public class database
    {

        public DataSet dataSet;
        public DataTable Account;
        public DataTable Todo;

        public database()
        {
            loadData();
        }
        public DataSet loadData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            var conn = new SqlConnection(connectionString);
            conn.Open();

            var dataAdapter = new SqlDataAdapter("SELECT * from Account", conn);
            dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Accounts");
            dataAdapter.SelectCommand.CommandText = "select * from Todo";
            dataAdapter.Fill(dataSet, "Todos");

            conn.Close();

            Account = dataSet.Tables["Accounts"];
            Todo = dataSet.Tables["Todos"];

            DataColumn col = new DataColumn("accID", typeof(int));

            col.AllowDBNull = false;
            col.AutoIncrement = true;
            col.AutoIncrementSeed = 1;
            col.Unique = true;


            DataRelation relation = new DataRelation("accID", Account.Columns["ID"], Todo.Columns["accID"]);
            dataSet.Relations.Add(relation);
            return dataSet;
        }
        public string getTodo(DateTime day)
        {
            DataRow[] groupRows = Account.Select("ID='6'");
            DataRow[] memeberTodo = groupRows[0].GetChildRows("accID");
            foreach (var row in memeberTodo)
            {
                if (day == (DateTime)row["Date"])
                {
                    return (string)row["Todo"];
                }
            }
            return null;
        }
        public void setTodo(DateTime day, string text)
        {
            DataRow[] groupRows = Account.Select("ID='6'");
            DataRow[] memeberTodo = groupRows[0].GetChildRows("accID");
            bool i = false;
            foreach (var row in memeberTodo)    
            {
                if (day == (DateTime)row["Date"])
                {
                    row["Todo"] = text;
                    i = true;
                }
            }
            if (i == false)
            {
                DataRow newRow = Todo.NewRow();
                newRow["Todo"] = text;
                newRow["Date"] = day;
                newRow["accID"] = 6;
                Todo.Rows.Add(newRow);
                

            }

            groupRows = Todo.Select("accID='6'");
        }

        public void storeData()
        {
            string connectionString = database.getConnString();
            using (var conn = new SqlConnection(connectionString))
            {
                var dataAdapter = new SqlDataAdapter("SELECT * from Todo", conn);
                var builer = new SqlCommandBuilder(dataAdapter);
                //dataAdapter .UpdateCommand= new SqlCommand("update Todo set ")
                dataAdapter.Update(Todo);
            }
        }
        public static string getConnString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }
}