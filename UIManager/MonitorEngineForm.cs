using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BL;
using Common;

namespace UIManager
{
    public partial class MonitorEngineForm : Form
    {
        private ServiceController _serviceController { get; set; }
        public MonitorEngineForm()
        {
            InitializeComponent();

            var serviceName = ConfigurationManager.AppSettings["serviceName"];
            _serviceController = new ServiceController(serviceName, Environment.MachineName);
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

        private void BtnServiceSwitch_Click(object sender, EventArgs e)
        {

            try
            {

                if (lblServiceStatus.Text.ToLower() != "stopped")
                {
                    _serviceController.Stop();
                    _serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                    btnServiceSwitch.Text = "Start";
                    //lblServiceStatus.Text = "Stopped";
                }
                else
                {
                    _serviceController.Start();
                    _serviceController.WaitForStatus(ServiceControllerStatus.Running);
                    btnServiceSwitch.Text = "Stop";
                    //lblServiceStatus.Text = "Running";
                }

                lblServiceStatus.Text = _serviceController.Status.ToString();
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message, ex.InnerException.Message);
                _serviceController.Dispose();
            }


        }

        private static ServiceController CreateService()
        {

            var serviceName = ConfigurationManager.AppSettings["serviceName"];
            var serviceController = new ServiceController(serviceName);

            return serviceController;
        }
    }
}
