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
                
                int[] productionPlan = CalculateProductionPlan(totalProduction);

              
                DataTable dt = new DataTable();
                dt.Columns.Add("Senin", typeof(int));
                dt.Columns.Add("Selasa", typeof(int));
                dt.Columns.Add("Rabu", typeof(int));
                dt.Columns.Add("Kamis", typeof(int));
                dt.Columns.Add("Jumat", typeof(int));

               
                DataRow row = dt.NewRow();
                row["Senin"] = productionPlan[0];
                row["Selasa"] = productionPlan[1];
                row["Rabu"] = productionPlan[2];
                row["Kamis"] = productionPlan[3];
                row["Jumat"] = productionPlan[4];
                dt.Rows.Add(row);

              
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
            
            int[] productionPlan = new int[7];
            int dailyProduction = totalProduction / 5;
            int extraProduction = totalProduction % 5; 

           
            for (int i = 0; i < 5; i++)
            {
                productionPlan[i] = dailyProduction;
            }

           
            productionPlan[0] += extraProduction > 0 ? 1 : 0;
            productionPlan[3] += extraProduction > 1 ? 1 : 0;

            return productionPlan;
        }
    }
}
