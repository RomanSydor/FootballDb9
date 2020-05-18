using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FootballDb9.Controllers
{
    public class QueryController : Controller
    {
        // GET: Query
        public ActionResult Index(string query)
        {
            string connectionString = "server=localhost;user=root;database=lab2db;port=3306;password=1313";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string sql = query;
            MySqlCommand command = new MySqlCommand(sql, connection);
            MySqlDataReader reader = command.ExecuteReader();

            int fieldCount = reader.FieldCount;
            object[] fields = new object[fieldCount];

            List<string> rowsHeader = new List<string>();
            List<List<string>> tableHeader = new List<List<string>>();

            for (int i = 0; i < fieldCount; i++)
            {
                rowsHeader.Add(reader.GetName(i));
            }
            tableHeader.Add(rowsHeader);
            ViewBag.Header = tableHeader;

            List<string> rowsBody = new List<string>();
            List<List<string>> tableBody = new List<List<string>>();
            while (reader.Read())
            {
                for (int i = 0; i < fieldCount; i++)
                {
                    fields[i] = reader[i];
                    rowsBody.Add(Convert.ToString(fields[i]));
                }
                tableBody.Add(rowsBody);
                rowsBody = new List<string>();
            }
            ViewBag.Body = tableBody;
            reader.Close();
            return View();
        }
    }
}