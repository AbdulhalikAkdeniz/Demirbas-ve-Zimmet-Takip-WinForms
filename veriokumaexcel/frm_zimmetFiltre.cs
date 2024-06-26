using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veriokumaexcel
{
    public partial class frm_zimmetFiltre : Form
    {
        public frm_zimmetler fz;
        public frm_zimmetFiltre(frm_zimmetler fz)
        {
            InitializeComponent();
            this.fz = fz;

        }

        private void frm_zimmetFiltre_Load(object sender, EventArgs e)
        {
            try
            {
                txtBirim.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtBirim.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtBirim.AutoCompleteCustomSource.AddRange(main.birimlerStrList.ToArray());
                //
                txtUnvan.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtUnvan.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtUnvan.AutoCompleteCustomSource.AddRange(main.unvanlarStrList.ToArray());
                //
                txtAdsoyad.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtAdsoyad.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtAdsoyad.AutoCompleteCustomSource.AddRange(main.adsoyadStrList.ToArray());
                //
                txtMM.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtMM.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtMM.AutoCompleteCustomSource.AddRange(main.markamodelStrList.ToArray());
                //
                txtSerino.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtSerino.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtSerino.AutoCompleteCustomSource.AddRange(main.serinoStrList.ToArray());
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }

        public void chkChanges()
        {
            try {BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = zimmetler.dtZimmetler;

            string filterExpression = ""; // Filtre ifadesi

            if (chkBirim.Checked)
            {
                if (!string.IsNullOrEmpty(filterExpression))
                {
                    filterExpression += " AND ";
                }
                filterExpression += string.Format("birim LIKE '%{0}%'",txtBirim.Text);
            }
            if (chkAdsoyad.Checked)
            {
                if (!string.IsNullOrEmpty(filterExpression))
                {
                    filterExpression += " AND ";
                }
                filterExpression += string.Format("teslimalanadsoyad LIKE '%{0}%'", txtAdsoyad.Text);
            }
            if (chkUnvan.Checked)
            {
                if (!string.IsNullOrEmpty(filterExpression))
                {
                    filterExpression += " AND ";
                }
                filterExpression += string.Format("teslimalanunvan LIKE '%{0}%'", txtUnvan.Text);
            }
            if (chkSicil.Checked)
            {
                if (!string.IsNullOrEmpty(filterExpression))
                {
                    filterExpression += " AND ";
                }
                filterExpression += string.Format("teslimalansicil LIKE '%{0}%'", txtSicil.Text);
            }
            if (chkMM.Checked)
            {
                if (!string.IsNullOrEmpty(filterExpression))
                {
                    filterExpression += " AND ";
                }
                filterExpression += string.Format("dbmarkamodel LIKE '%{0}%'", txtMM.Text);
            }
            if (chkSerino.Checked)
            {
                if (!string.IsNullOrEmpty(filterExpression))
                {
                    filterExpression += " AND ";
                }
                filterExpression += string.Format("dbserino LIKE '%{0}%'", txtSerino.Text);
            }
            if (chk_demno.Checked)
            {
                 if (!string.IsNullOrEmpty(filterExpression))
                 {
                    filterExpression += " AND ";
                 }
                 filterExpression += string.Format("dem_no LIKE '%{0}%'", txtDemNo.Text);
            }
                // Filtreleme işlemini gerçekleştir
                bindingSource.Filter = filterExpression;

            // DataGridView'i yeniden bağla
            fz.dgZimmetler.DataSource = bindingSource; }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //chkChanges();
            if(chkBirim.Checked){
                txtBirim.Visible = true;
            }
            else{
                txtBirim.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chkChanges();
        }

        private void chkAd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdsoyad.Checked)
            {
                txtAdsoyad.Visible = true;
            }
            else
            {
                txtAdsoyad.Visible = false;
            }
        }


        private void chkUnvan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnvan.Checked)
            {
                txtUnvan.Visible = true;
            }
            else
            {
                txtUnvan.Visible = false;
            }
        }

        private void chkSicil_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSicil.Checked)
            {
                txtSicil.Visible = true;
            }
            else
            {
                txtSicil.Visible = false;
            }
        }

        private void chkMM_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMM.Checked)
            {
                txtMM.Visible = true;
            }
            else
            {
                txtMM.Visible = false;
            }
        }

        private void chkSerino_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSerino.Checked)
            {
                txtSerino.Visible = true;
            }
            else
            {
                txtSerino.Visible = false;
            }
        }

        private void txtMM_TextChanged(object sender, EventArgs e)
        {

        }

        private void chk_demno_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_demno.Checked)
            {
                txtDemNo.Visible = true;
            }
            else
            {
                txtDemNo.Visible = false;
            }
        }
    }
}
