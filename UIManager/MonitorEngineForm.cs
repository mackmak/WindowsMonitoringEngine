using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BL;

namespace UIManager
{
    public partial class MonitorEngineForm : Form
    {
        public MonitorEngineForm()
        {
            InitializeComponent();
        }

        private void MonitorEngineForm_Load(object sender, EventArgs e)
        {
            dataGridViewPerformance.DataSource = PerformanceAccess.GetAll();
            //dataGridViewPerformance.DataBind();


            SetChart(chart1);
            SetChart(chart2);

            SetUpDataGridView();
        }

        private void SetChart(Chart chart)
        {

            chart.Series[0].XValueType = ChartValueType.DateTime;
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy" +
                System.Environment.NewLine + "hh:mm:ss";
            chart.DataSource = PerformanceAccess.GetAll();
        }

        private void SetUpDataGridView()
        {
            //hiding ID column
            dataGridViewPerformance.Columns[0].Visible = false;

            dataGridViewPerformance.Columns[1].Width = 50;
            dataGridViewPerformance.Columns[2].Width = 50;
            dataGridViewPerformance.Columns[3].Width = 110;

            dataGridViewPerformance.Columns[1].HeaderText = "CPU";
            dataGridViewPerformance.Columns[2].HeaderText = "Mem";
            dataGridViewPerformance.Columns[3].HeaderText = "Date";

        }



    }
}
