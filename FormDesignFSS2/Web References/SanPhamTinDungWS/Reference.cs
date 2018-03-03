﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace FormDesignFSS2.SanPhamTinDungWS {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SanPhamTinDungBUSSoap", Namespace="http://tempuri.org/")]
    public partial class SanPhamTinDungBUS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback KTThongTinThemMoiSPTDOperationCompleted;
        
        private System.Threading.SendOrPostCallback LayDanhSachSPTDOperationCompleted;
        
        private System.Threading.SendOrPostCallback TimKiemSPTDOperationCompleted;
        
        private System.Threading.SendOrPostCallback TaoMaSPTDOperationCompleted;
        
        private System.Threading.SendOrPostCallback ThemMoiSPTDOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SanPhamTinDungBUS() {
            this.Url = global::FormDesignFSS2.Properties.Settings.Default.FormDesignFSS2_SanPhamTinDungWS_SanPhamTinDungBUS;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event KTThongTinThemMoiSPTDCompletedEventHandler KTThongTinThemMoiSPTDCompleted;
        
        /// <remarks/>
        public event LayDanhSachSPTDCompletedEventHandler LayDanhSachSPTDCompleted;
        
        /// <remarks/>
        public event TimKiemSPTDCompletedEventHandler TimKiemSPTDCompleted;
        
        /// <remarks/>
        public event TaoMaSPTDCompletedEventHandler TaoMaSPTDCompleted;
        
        /// <remarks/>
        public event ThemMoiSPTDCompletedEventHandler ThemMoiSPTDCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/KTThongTinThemMoiSPTD", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int KTThongTinThemMoiSPTD(string tenSPTD, string thoiHanVay, string laiSuat, string laiSuatQuaHan) {
            object[] results = this.Invoke("KTThongTinThemMoiSPTD", new object[] {
                        tenSPTD,
                        thoiHanVay,
                        laiSuat,
                        laiSuatQuaHan});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void KTThongTinThemMoiSPTDAsync(string tenSPTD, string thoiHanVay, string laiSuat, string laiSuatQuaHan) {
            this.KTThongTinThemMoiSPTDAsync(tenSPTD, thoiHanVay, laiSuat, laiSuatQuaHan, null);
        }
        
        /// <remarks/>
        public void KTThongTinThemMoiSPTDAsync(string tenSPTD, string thoiHanVay, string laiSuat, string laiSuatQuaHan, object userState) {
            if ((this.KTThongTinThemMoiSPTDOperationCompleted == null)) {
                this.KTThongTinThemMoiSPTDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnKTThongTinThemMoiSPTDOperationCompleted);
            }
            this.InvokeAsync("KTThongTinThemMoiSPTD", new object[] {
                        tenSPTD,
                        thoiHanVay,
                        laiSuat,
                        laiSuatQuaHan}, this.KTThongTinThemMoiSPTDOperationCompleted, userState);
        }
        
        private void OnKTThongTinThemMoiSPTDOperationCompleted(object arg) {
            if ((this.KTThongTinThemMoiSPTDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.KTThongTinThemMoiSPTDCompleted(this, new KTThongTinThemMoiSPTDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/LayDanhSachSPTD", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string LayDanhSachSPTD() {
            object[] results = this.Invoke("LayDanhSachSPTD", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void LayDanhSachSPTDAsync() {
            this.LayDanhSachSPTDAsync(null);
        }
        
        /// <remarks/>
        public void LayDanhSachSPTDAsync(object userState) {
            if ((this.LayDanhSachSPTDOperationCompleted == null)) {
                this.LayDanhSachSPTDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLayDanhSachSPTDOperationCompleted);
            }
            this.InvokeAsync("LayDanhSachSPTD", new object[0], this.LayDanhSachSPTDOperationCompleted, userState);
        }
        
        private void OnLayDanhSachSPTDOperationCompleted(object arg) {
            if ((this.LayDanhSachSPTDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LayDanhSachSPTDCompleted(this, new LayDanhSachSPTDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TimKiemSPTD", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string TimKiemSPTD(string tenSPTD, string maSPTD, string tenNguon) {
            object[] results = this.Invoke("TimKiemSPTD", new object[] {
                        tenSPTD,
                        maSPTD,
                        tenNguon});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void TimKiemSPTDAsync(string tenSPTD, string maSPTD, string tenNguon) {
            this.TimKiemSPTDAsync(tenSPTD, maSPTD, tenNguon, null);
        }
        
        /// <remarks/>
        public void TimKiemSPTDAsync(string tenSPTD, string maSPTD, string tenNguon, object userState) {
            if ((this.TimKiemSPTDOperationCompleted == null)) {
                this.TimKiemSPTDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTimKiemSPTDOperationCompleted);
            }
            this.InvokeAsync("TimKiemSPTD", new object[] {
                        tenSPTD,
                        maSPTD,
                        tenNguon}, this.TimKiemSPTDOperationCompleted, userState);
        }
        
        private void OnTimKiemSPTDOperationCompleted(object arg) {
            if ((this.TimKiemSPTDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TimKiemSPTDCompleted(this, new TimKiemSPTDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TaoMaSPTD", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string TaoMaSPTD(string prefixMaSPTD) {
            object[] results = this.Invoke("TaoMaSPTD", new object[] {
                        prefixMaSPTD});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void TaoMaSPTDAsync(string prefixMaSPTD) {
            this.TaoMaSPTDAsync(prefixMaSPTD, null);
        }
        
        /// <remarks/>
        public void TaoMaSPTDAsync(string prefixMaSPTD, object userState) {
            if ((this.TaoMaSPTDOperationCompleted == null)) {
                this.TaoMaSPTDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTaoMaSPTDOperationCompleted);
            }
            this.InvokeAsync("TaoMaSPTD", new object[] {
                        prefixMaSPTD}, this.TaoMaSPTDOperationCompleted, userState);
        }
        
        private void OnTaoMaSPTDOperationCompleted(object arg) {
            if ((this.TaoMaSPTDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TaoMaSPTDCompleted(this, new TaoMaSPTDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ThemMoiSPTD", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ThemMoiSPTD(string jsonData) {
            object[] results = this.Invoke("ThemMoiSPTD", new object[] {
                        jsonData});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ThemMoiSPTDAsync(string jsonData) {
            this.ThemMoiSPTDAsync(jsonData, null);
        }
        
        /// <remarks/>
        public void ThemMoiSPTDAsync(string jsonData, object userState) {
            if ((this.ThemMoiSPTDOperationCompleted == null)) {
                this.ThemMoiSPTDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnThemMoiSPTDOperationCompleted);
            }
            this.InvokeAsync("ThemMoiSPTD", new object[] {
                        jsonData}, this.ThemMoiSPTDOperationCompleted, userState);
        }
        
        private void OnThemMoiSPTDOperationCompleted(object arg) {
            if ((this.ThemMoiSPTDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ThemMoiSPTDCompleted(this, new ThemMoiSPTDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void KTThongTinThemMoiSPTDCompletedEventHandler(object sender, KTThongTinThemMoiSPTDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class KTThongTinThemMoiSPTDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal KTThongTinThemMoiSPTDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void LayDanhSachSPTDCompletedEventHandler(object sender, LayDanhSachSPTDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LayDanhSachSPTDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LayDanhSachSPTDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void TimKiemSPTDCompletedEventHandler(object sender, TimKiemSPTDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TimKiemSPTDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TimKiemSPTDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void TaoMaSPTDCompletedEventHandler(object sender, TaoMaSPTDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TaoMaSPTDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TaoMaSPTDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void ThemMoiSPTDCompletedEventHandler(object sender, ThemMoiSPTDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ThemMoiSPTDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ThemMoiSPTDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591