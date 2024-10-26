using System;
using System.Data;
using System.Web.UI;

namespace DailyProduction_TesAGIT_SekarPuspita__Soal_1
{
    public partial class PlanProduction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            int totalProduction;
            if (int.TryParse(txtTotalProduction.Value, out totalProduction) && totalProduction >= 0)
            {
                // Hitung produksi harian dengan distribusi sesuai ketentuan
                int[] productionPlan = CalculateProductionPlan(totalProduction);

                // Buat DataTable untuk menampilkan hasil dalam GridView
                DataTable dt = new DataTable();
                dt.Columns.Add("Senin", typeof(int));
                dt.Columns.Add("Selasa", typeof(int));
                dt.Columns.Add("Rabu", typeof(int));
                dt.Columns.Add("Kamis", typeof(int));
                dt.Columns.Add("Jumat", typeof(int));
                dt.Columns.Add("Sabtu", typeof(int));
                dt.Columns.Add("Minggu", typeof(int));

                // Tambah baris untuk distribusi produksi
                DataRow row = dt.NewRow();
                row["Senin"] = productionPlan[0];
                row["Selasa"] = productionPlan[1];
                row["Rabu"] = productionPlan[2];
                row["Kamis"] = productionPlan[3];
                row["Jumat"] = productionPlan[4];
                row["Sabtu"] = productionPlan[5];
                row["Minggu"] = productionPlan[6];
                dt.Rows.Add(row);

                // Bind hasil ke GridView
                gvProductionPlan.DataSource = dt;
                gvProductionPlan.DataBind();

                lblOutput.Text = "Production plan calculated successfully!";
            }
            else
            {
                lblOutput.Text = "Please enter a valid number for total production.";
            }
        }

        private int[] CalculateProductionPlan(int totalProduction)
        {
            // Inisialisasi produksi untuk 7 hari (Senin - Minggu)
            int[] productionPlan = new int[7];
            int dailyProduction = totalProduction / 5; // Distribusi dasar
            int extraProduction = totalProduction % 5; // Sisa yang tidak terbagi rata

            // Set hari kerja reguler (Senin - Jumat)
            for (int i = 0; i < 5; i++)
            {
                productionPlan[i] = dailyProduction;
            }

            // Alokasikan sisa produksi ke hari yang diinginkan (misal Senin dan Kamis)
            productionPlan[0] += extraProduction > 0 ? 1 : 0;
            productionPlan[3] += extraProduction > 1 ? 1 : 0;

            // Pastikan Sabtu dan Minggu tetap 0
            productionPlan[5] = 0; // Sabtu
            productionPlan[6] = 0; // Minggu

            return productionPlan;
        }
    }
}
