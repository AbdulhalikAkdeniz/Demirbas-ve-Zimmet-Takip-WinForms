using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace veriokumaexcel
{
    public class main
    {
        public static HashSet<string> unvanlarStrList = new HashSet<string>();
        public static HashSet<string> birimlerStrList = new HashSet<string>();
        public static HashSet<string> turlerStrList = new HashSet<string>();
        public static List<string> adsoyadStrList = new List<string>();
        public static HashSet<string> sicillerStrList = new HashSet<string>();
        public static HashSet<string> sadecemarkaStrList = new HashSet<string>();
        public static HashSet<string> markamodelStrList = new HashSet<string>();
        public static HashSet<string> serinoStrList = new HashSet<string>();
        public static string CSVUrunlerFileName = "vt/demirbaslar.csv";
        public static string CSVPersonellerFileName = "vt/personeller.csv";
        public static string CSVZimmetlerFileName = "vt/zimmetler.csv";

        public static void anlikFiltre(string searchText, DataTable beforeFilterTable,System.Windows.Forms.DataGridView visualGridTable)
        {
            try
            {
                DataTable filteredTable = beforeFilterTable.Clone();
                foreach (DataRow row in beforeFilterTable.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        if (item.ToString().IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            filteredTable.ImportRow(row);
                            break;
                        }
                    }
                }

                visualGridTable.DataSource = filteredTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }
    
}
