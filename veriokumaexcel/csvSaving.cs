using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veriokumaexcel
{
    public static class csvSaving
    {
        public static void saveCSV_personeller()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(main.CSVPersonellerFileName))
                {
                    // Sütun başlıklarını yazdır
                    for (int i = 0; i < personeller.dtPersoneller.Columns.Count; i++)
                    {
                        writer.Write(personeller.dtPersoneller.Columns[i].ColumnName);
                        if (i < personeller.dtPersoneller.Columns.Count - 1)
                        {
                            writer.Write(";");
                        }
                    }
                    writer.WriteLine();

                    // Verileri yazdır
                    foreach (DataRow row in personeller.dtPersoneller.Rows)
                    {
                        for (int i = 0; i < personeller.dtPersoneller.Columns.Count; i++)
                        {
                            writer.Write(row[i]);
                            if (i < personeller.dtPersoneller.Columns.Count - 1)
                            {
                                writer.Write(";");
                            }
                        }
                        writer.WriteLine();
                    }
                }

                System.Windows.Forms.MessageBox.Show("Veriler '" + main.CSVPersonellerFileName + "' dosyasına kaydedildi.");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Hata", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        public static void saveCSV_urunler()
        {
            //
            try
            {
                using (StreamWriter writer = new StreamWriter(main.CSVUrunlerFileName))
                {
                    // Sütun başlıklarını yazdır
                    for (int i = 0; i < demirbaslar.dtUrunler.Columns.Count; i++)
                    {
                        writer.Write(demirbaslar.dtUrunler.Columns[i].ColumnName);
                        if (i < demirbaslar.dtUrunler.Columns.Count - 1)
                        {
                            writer.Write(";");
                        }
                    }
                    writer.WriteLine();

                    // Verileri yazdır
                    foreach (DataRow row in demirbaslar.dtUrunler.Rows)
                    {
                        for (int i = 0; i < demirbaslar.dtUrunler.Columns.Count; i++)
                        {
                            writer.Write(row[i]);
                            if (i < demirbaslar.dtUrunler.Columns.Count - 1)
                            {
                                writer.Write(";");
                            }
                        }
                        writer.WriteLine();
                    }
                }

                System.Windows.Forms.MessageBox.Show("Veriler '" + main.CSVUrunlerFileName + "' dosyasına kaydedildi.");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Hata", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public static void saveCSV_zimmetler()
        {
            //
            try
            {
                using (StreamWriter writer = new StreamWriter(main.CSVZimmetlerFileName))
                {
                    // Sütun başlıklarını yazdır
                    for (int i = 0; i < zimmetler.dtZimmetler.Columns.Count; i++)
                    {
                        writer.Write(zimmetler.dtZimmetler.Columns[i].ColumnName);
                        if (i < zimmetler.dtZimmetler.Columns.Count - 1)
                        {
                            writer.Write(";");
                        }
                    }
                    writer.WriteLine();

                    // Verileri yazdır
                    foreach (DataRow row in zimmetler.dtZimmetler.Rows)
                    {
                        for (int i = 0; i < zimmetler.dtZimmetler.Columns.Count; i++)
                        {
                            writer.Write(row[i]);
                            if (i < zimmetler.dtZimmetler.Columns.Count - 1)
                            {
                                writer.Write(";");
                            }
                        }
                        writer.WriteLine();
                    }
                }

                System.Windows.Forms.MessageBox.Show("Veriler '"+ main.CSVZimmetlerFileName + "' dosyasına kaydedildi.");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Hata", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        public static void saveTxt(HashSet<String> list,string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (string item in list)
                    {
                        writer.WriteLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Hata", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

        }
    }
}
