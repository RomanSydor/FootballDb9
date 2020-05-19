using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FootballDb9.Controllers
{
    public class QueryController : Controller
    {
        public static List<List<string>> TableHeader = new List<List<string>>();
        public static List<List<string>> TableBody = new List<List<string>>();
        public static string Query;
        
        // GET: Query
        public ActionResult Index(string query)
        {
            string connectionString = "server=localhost;user=root;database=lab2db;port=3306;password=1313";
            Query += query;
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string sql = query;
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            int fieldCount = reader.FieldCount;
            object[] fields = new object[fieldCount];

            List<string> rowsHeader = new List<string>();
            //tableHeader = new List<List<string>>();

            for (int i = 0; i < fieldCount; i++)
            {
                rowsHeader.Add(reader.GetName(i));
            }
            TableHeader.Add(rowsHeader);

            ViewBag.Header = TableHeader;

            List<string> rowsBody = new List<string>();
            //tableBody = new List<List<string>>();
            while (reader.Read())
            {
                for (int i = 0; i < fieldCount; i++)
                {
                    fields[i] = reader[i];
                    rowsBody.Add(Convert.ToString(fields[i]));
                }
                TableBody.Add(rowsBody);
                rowsBody = new List<string>();
            }

            ViewBag.Body = TableBody;

            reader.Close();
            return View();
        }

        public void CSVSave() 
        {

            var sb = new StringBuilder();
            
            string qry = Query;

            foreach (var item in TableHeader)
            {
                foreach (var i in item)
                {
                    sb.AppendLine(i);
                }
            }
            foreach (var item in TableBody)
            {
                foreach (var i in item)
                {
                    sb.AppendLine(i);
                }
            }

            var response = System.Web.HttpContext.Current.Response;
            response.BufferOutput = true;
            response.Clear();
            response.ClearHeaders();
            response.ContentEncoding = Encoding.Unicode;
            response.AddHeader("content-disposition", "attachment;filename=Query.CSV ");
            response.ContentType = "text/plain";
            response.Write(sb.ToString());
            response.End();
        }
    }
}