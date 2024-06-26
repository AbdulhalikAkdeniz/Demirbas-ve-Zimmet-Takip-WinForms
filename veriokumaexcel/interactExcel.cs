using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Data;
using DataTable = System.Data.DataTable;

namespace veriokumaexcel
{
    public static class interactExcel
    {
        public static void ConvertDataTableToExcelAndShow(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                Console.WriteLine("DataTable is null or empty.");
                return;
            }

            Application excelApp = null;
            Workbook workbook = null;
            Worksheet worksheet = null;

            try
            {
                // Excel uygulaması oluştur
                excelApp = new Application();
                workbook = excelApp.Workbooks.Add();
                worksheet = (Worksheet)workbook.ActiveSheet;

                // DataTable verilerini Excel hücrelerine yerleştir
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 1, j + 1].Value = dataTable.Rows[i][j].ToString();
                    }
                }

                // Sütunları otomatik genişliğe ayarla
                worksheet.Columns.AutoFit();

                // Excel uygulamasını göster (Visible = true)
                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Kaynakları serbest bırak
                ReleaseObject(worksheet);
                ReleaseObject(workbook);
                ReleaseObject(excelApp);
            }
        }
        public static void ConvertCsvToExcelAndShow(string csvFilePath)
        {
            if (!File.Exists(csvFilePath))
            {
                Console.WriteLine("CSV file not found.");
                return;
            }

            Application excelApp = null;
            Workbook workbook = null;
            Worksheet worksheet = null;

            try
            {
                // CSV dosyasını Excel içine aktar
                excelApp = new Application();
                workbook = excelApp.Workbooks.Add();
                worksheet = (Worksheet)workbook.ActiveSheet;
                
                string[] lines = File.ReadAllLines(csvFilePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(';'); // Doğru parçalama karakterini kullan

                    for (int j = 0; j < values.Length; j++)
                    {
                        // UTF-8 formatında karakterleri doğru şekilde aktarmak için Text Encoding'i ayarla
                        worksheet.Cells[i + 1, j + 1].Value = values[j];
                    }
                }

                // Sütunları otomatik genişliğe ayarla
                worksheet.Columns.AutoFit();

                // Excel uygulamasını göster (Visible = true)

                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Kaynakları serbest bırak
                ReleaseObject(worksheet);
                ReleaseObject(workbook);
                ReleaseObject(excelApp);
            }
        }

        private static void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("An error occurred while releasing the object: " + ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

        public static void writeExcelFromDGView(System.Windows.Forms.DataGridView dgv,string filename,string sayfaismi)
        {
            string excelFilePath = Path.Combine(Environment.CurrentDirectory, "excel/"+filename);
            string sheetName = sayfaismi;//"BİLGİSAYAR";

            if (!File.Exists(excelFilePath))
            {
                return; // Metodun geri kalanını işlemeye devam etmeden dön
            }
            // Excel uygulamasını başlat
            Application excelApp = new Application();
            excelApp.Visible = true;

            // Excel dosyasını aç
            Workbook workbook = excelApp.Workbooks.Open(excelFilePath);
            Worksheet worksheet = workbook.Sheets[sheetName];

            // İlgili sütunları al ve Excel'e yaz
            int rowCount = dgv.Rows.Count;
            int columnCount = dgv.Columns.Count;

            for (int i = 0; i < rowCount; i++)
            {
                    try
                    {
                        string columnName = dgv.Columns[0].HeaderText;
                        object cellValueObj = dgv.Rows[i].Cells[0].Value;
                    if (cellValueObj != null)
                    {
                        string cellValue = cellValueObj.ToString();
                        worksheet.Cells[i + 2, 0 + 1].Value = (i+1).ToString();
                    }
                    
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
            }
            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    string columnName = dgv.Columns[1].HeaderText;
                    object cellValueObj= dgv.Rows[i].Cells[1].Value;
                    if (cellValueObj != null)
                    {
                        string cellValue = cellValueObj.ToString();
                        worksheet.Cells[i + 2, 1 + 1].Value = cellValue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    string columnName = dgv.Columns[2].HeaderText;
                    Object ObjcellValue = dgv.Rows[i].Cells[2].Value;
                    if (ObjcellValue != null)
                    {
                        string cellValue = ObjcellValue.ToString();
                        worksheet.Cells[i + 2, 2 + 1].Value = cellValue;
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    string columnName = dgv.Columns[3].HeaderText;
                    Object ObjCellValue = dgv.Rows[i].Cells[3].Value;
                    if (ObjCellValue!=null)
                    {
                        string cellValue = ObjCellValue.ToString();
                        worksheet.Cells[i + 2, 3 + 1].Value = cellValue;
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    string columnName = dgv.Columns[4].HeaderText;
                    Object ObjCellValue = dgv.Rows[i].Cells[4].Value;
                    if (ObjCellValue!=null)
                    {
                        string cellValue = ObjCellValue.ToString();
                        worksheet.Cells[i + 2, 4 + 1].Value = cellValue;
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    string columnName = dgv.Columns[6].HeaderText;
                    Object ObjCellValue = dgv.Rows[i].Cells[6].Value;
                    if (ObjCellValue!=null)
                    {
                        string cellValue = ObjCellValue.ToString();
                        worksheet.Cells[i + 2, 5 + 1].Value = cellValue;
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    string columnName = dgv.Columns[7].HeaderText;
                    Object objCellValue = dgv.Rows[i].Cells[7].Value;
                    if (objCellValue!=null)
                    {
                        string cellValue = objCellValue.ToString();
                        worksheet.Cells[i + 2, 6 + 1].Value = cellValue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            for (int i = 0; i < rowCount; i++)
            {
                try
                {
                    string columnName = dgv.Columns[11].HeaderText;
                    Object objCellValue = dgv.Rows[i].Cells[11].Value;
                    if (objCellValue != null)
                    {
                        string cellValue = objCellValue.ToString();
                        worksheet.Cells[i + 2, 8 + 1].Value = cellValue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Excel uygulamasını kapat
            /*workbook.Close(true);
            excelApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            worksheet = null;
            workbook = null;
            excelApp = null;

            GC.Collect();*/
        }
    }
}
