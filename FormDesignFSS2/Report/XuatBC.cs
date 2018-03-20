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
        /// Báo cáo DS KH
        /// </summary>
        public void BCKH()
        {
            // Lấy danh sách khách hàng
            KhachHangBUS khachHangBUS = new KhachHangBUS();
            string jsonData = khachHangBUS.KhachHangReport();
            List<KhachHangReport> list = JsonConvert.DeserializeObject<List<KhachHangReport>>(jsonData);
            // Chuyển danh sách khách hàng sang data table
            DataTable dataTable = DataTableConvert.ConvertToDataTable(list);
            // Add data table vào dataset
            DataSet dataSet = new DataSet("DSKH");
            dataSet.Tables.Add(dataTable);
            // Parameter
            string name = "Trần Viết Tiệp";
            string name2 = "Trần Viết Nhật";
            // Thiết lập báo cáo
            reportViewerBC.LocalReport.ReportPath = "Report/DanhSachKH.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            ReportParameter[] reportParameter = new ReportParameter[2];
            reportParameter[0] = new ReportParameter("demoParameter", name, true);
            reportParameter[1] = new ReportParameter("demoParameter2", name2, true);
            reportViewerBC.LocalReport.SetParameters(reportParameter);

            reportDataSource.Name = "DSKH";
            reportDataSource.Value = dataSet.Tables[0];
            reportViewerBC.LocalReport.DataSources.Add(reportDataSource);
            // Hiển thị báo cáo
            reportViewerBC.RefreshReport();
        }

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
    }
}
