using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using FormDesignFSS2.KhachHangWS;
using Newtonsoft.Json;
using FormDesignFSS2.ReportWS;
using DTO;
using System.Data;

namespace FormDesignFSS2.Report
{
    /// <summary>
    /// Viết Tiệp
    /// 18/3/2018
    /// </summary>
    public class XuatBC
    {
        public ReportViewer reportViewerBC;
        public string gioHT;

        /// <summary>
        /// Báo cáo danh sách dư nợ 01
        /// </summary>
        public void BCDuNoA()
        {
            // Lấy DS bản ghi
            ReportBUS reportBUS = new ReportBUS();
            List<DSDuNoA> list = JsonConvert.DeserializeObject<List<DSDuNoA>>(reportBUS.GetListDSDuNoA(gioHT));
            // Chuyển dữ liệu sang DataTable
            DataTable dataTable = DataTableConvert.ConvertToDataTable(list);
            // Add datatable vào dataset
            DataSet dataSet = new DataSet("DuNoA");
            dataSet.Tables.Add(dataTable);

            string slBG = list.Count.ToString();
            reportViewerBC.LocalReport.ReportPath = "Report/DanhSachDuNo01.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            ReportParameter[] reportParameter = new ReportParameter[2];
            reportParameter[0] = new ReportParameter("SLBanGhi", slBG, true);
            reportParameter[1] = new ReportParameter("GioHT", gioHT, true);

            reportViewerBC.LocalReport.SetParameters(reportParameter);

            reportDataSource.Name = "DuNoA";
            reportDataSource.Value = dataSet.Tables[0];
            reportViewerBC.LocalReport.DataSources.Add(reportDataSource);
            // Hiển thị báo cáo
            reportViewerBC.RefreshReport();
        }

        /// <summary>
        /// Báo cáo danh sách dư nợ 02
        /// </summary>
        public void BCDuNoB()
        {
            // Lấy DS bản ghi
            ReportBUS reportBUS = new ReportBUS();
            List<DSDuNoB> list = JsonConvert.DeserializeObject<List<DSDuNoB>>(reportBUS.GetListDSDuNoB());
            // Chuyển dữ liệu sang DataTable
            DataTable dataTable = DataTableConvert.ConvertToDataTable(list);
            // Add datatable vào dataset
            DataSet dataSet = new DataSet("DuNoB");
            dataSet.Tables.Add(dataTable);

            string slBG = list.Count.ToString();
            reportViewerBC.LocalReport.ReportPath = "Report/DanhSachDuNo02.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            ReportParameter[] reportParameter = new ReportParameter[2];
            reportParameter[0] = new ReportParameter("SLBanGhi", slBG, true);
            reportParameter[1] = new ReportParameter("GioHT", gioHT, true);

            reportViewerBC.LocalReport.SetParameters(reportParameter);

            reportDataSource.Name = "DuNoB";
            reportDataSource.Value = dataSet.Tables[0];
            reportViewerBC.LocalReport.DataSources.Add(reportDataSource);
            // Hiển thị báo cáo
            reportViewerBC.RefreshReport();
        }

        /// <summary>
        /// Báo cáo danh sách dư nợ 03
        /// </summary>
        public void BCDuNoC()
        {
            // Lấy DS bản ghi
            ReportBUS reportBUS = new ReportBUS();
            List<DSDuNoC> list = JsonConvert.DeserializeObject<List<DSDuNoC>>(reportBUS.GetListDSDuNoC(gioHT));
            // Chuyển dữ liệu sang DataTable
            DataTable dataTable = DataTableConvert.ConvertToDataTable(list);
            // Add datatable vào dataset
            DataSet dataSet = new DataSet("DuNoC");
            dataSet.Tables.Add(dataTable);

            string slBG = list.Count.ToString();
            reportViewerBC.LocalReport.ReportPath = "Report/DanhSachDuNo03.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            ReportParameter[] reportParameter = new ReportParameter[2];
            reportParameter[0] = new ReportParameter("SLBanGhi", slBG, true);
            reportParameter[1] = new ReportParameter("GioHT", gioHT, true);

            reportViewerBC.LocalReport.SetParameters(reportParameter);

            reportDataSource.Name = "DuNoC";
            reportDataSource.Value = dataSet.Tables[0];
            reportViewerBC.LocalReport.DataSources.Add(reportDataSource);
            // Hiển thị báo cáo
            reportViewerBC.RefreshReport();
        }

        /// <summary>
        /// Báo cáo danh sách dư nợ 04
        /// </summary>
        public void BCDuNoD()
        {
            // Lấy DS bản ghi
            ReportBUS reportBUS = new ReportBUS();
            List<DSDuNoD> list = JsonConvert.DeserializeObject<List<DSDuNoD>>(reportBUS.GetListDSKHHetNo());
            // Chuyển dữ liệu sang DataTable
            DataTable dataTable = DataTableConvert.ConvertToDataTable(list);
            // Add datatable vào dataset
            DataSet dataSet = new DataSet("DuNoD");
            dataSet.Tables.Add(dataTable);

            string slBG = list.Count.ToString();
            reportViewerBC.LocalReport.ReportPath = "Report/DanhSachDuNo04.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            ReportParameter[] reportParameter = new ReportParameter[2];
            reportParameter[0] = new ReportParameter("SLBanGhi", slBG, true);
            reportParameter[1] = new ReportParameter("GioHT", gioHT, true);

            reportViewerBC.LocalReport.SetParameters(reportParameter);

            reportDataSource.Name = "DuNoD";
            reportDataSource.Value = dataSet.Tables[0];
            reportViewerBC.LocalReport.DataSources.Add(reportDataSource);
            // Hiển thị báo cáo
            reportViewerBC.RefreshReport();
        }

        /// <summary>
        /// Báo cáo DS dư nợ 05
        /// </summary>
        public void BCDuNoE()
        {
            // Lấy DS bản ghi
            ReportBUS reportBUS = new ReportBUS();
            List<DSDuNoE> list = JsonConvert.DeserializeObject<List<DSDuNoE>>(reportBUS.GetListDSDuNoE());
            // Chuyển dữ liệu sang DataTable
            DataTable dataTable = DataTableConvert.ConvertToDataTable(list);
            // Add datatable vào dataset
            DataSet dataSet = new DataSet("DuNoE");
            dataSet.Tables.Add(dataTable);

            string slBG = list.Count.ToString();
            reportViewerBC.LocalReport.ReportPath = "Report/DanhSachDuNo05.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            ReportParameter[] reportParameter = new ReportParameter[2];
            reportParameter[0] = new ReportParameter("SLBanGhi", slBG, true);
            reportParameter[1] = new ReportParameter("GioHT", gioHT, true);

            reportViewerBC.LocalReport.SetParameters(reportParameter);

            reportDataSource.Name = "DuNoE";
            reportDataSource.Value = dataSet.Tables[0];
            reportViewerBC.LocalReport.DataSources.Add(reportDataSource);
            // Hiển thị báo cáo
            reportViewerBC.RefreshReport();

        }
    }
}
