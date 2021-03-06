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

namespace FormDesignFSS2.TraNoWS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="TraNoBUSSoap", Namespace="http://tempuri.org/")]
    public partial class TraNoBUS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetListGNOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetListGNWithIdKHOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetGNOperationCompleted;
        
        private System.Threading.SendOrPostCallback KTThongTinTraNoOperationCompleted;
        
        private System.Threading.SendOrPostCallback TaoMaTraNoOperationCompleted;
        
        private System.Threading.SendOrPostCallback ThemTNOperationCompleted;
        
        private System.Threading.SendOrPostCallback CapNhatDuNoOperationCompleted;
        
        private System.Threading.SendOrPostCallback CapNhatNguonOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetIDGNOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetListTNOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public TraNoBUS() {
            this.Url = global::FormDesignFSS2.Properties.Settings.Default.FormDesignFSS2_TraNoWS_TraNoBUS;
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
        public event GetListGNCompletedEventHandler GetListGNCompleted;
        
        /// <remarks/>
        public event GetListGNWithIdKHCompletedEventHandler GetListGNWithIdKHCompleted;
        
        /// <remarks/>
        public event GetGNCompletedEventHandler GetGNCompleted;
        
        /// <remarks/>
        public event KTThongTinTraNoCompletedEventHandler KTThongTinTraNoCompleted;
        
        /// <remarks/>
        public event TaoMaTraNoCompletedEventHandler TaoMaTraNoCompleted;
        
        /// <remarks/>
        public event ThemTNCompletedEventHandler ThemTNCompleted;
        
        /// <remarks/>
        public event CapNhatDuNoCompletedEventHandler CapNhatDuNoCompleted;
        
        /// <remarks/>
        public event CapNhatNguonCompletedEventHandler CapNhatNguonCompleted;
        
        /// <remarks/>
        public event GetIDGNCompletedEventHandler GetIDGNCompleted;
        
        /// <remarks/>
        public event GetListTNCompletedEventHandler GetListTNCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetListGN", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetListGN() {
            object[] results = this.Invoke("GetListGN", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetListGNAsync() {
            this.GetListGNAsync(null);
        }
        
        /// <remarks/>
        public void GetListGNAsync(object userState) {
            if ((this.GetListGNOperationCompleted == null)) {
                this.GetListGNOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetListGNOperationCompleted);
            }
            this.InvokeAsync("GetListGN", new object[0], this.GetListGNOperationCompleted, userState);
        }
        
        private void OnGetListGNOperationCompleted(object arg) {
            if ((this.GetListGNCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetListGNCompleted(this, new GetListGNCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetListGNWithIdKH", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetListGNWithIdKH(int idKH) {
            object[] results = this.Invoke("GetListGNWithIdKH", new object[] {
                        idKH});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetListGNWithIdKHAsync(int idKH) {
            this.GetListGNWithIdKHAsync(idKH, null);
        }
        
        /// <remarks/>
        public void GetListGNWithIdKHAsync(int idKH, object userState) {
            if ((this.GetListGNWithIdKHOperationCompleted == null)) {
                this.GetListGNWithIdKHOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetListGNWithIdKHOperationCompleted);
            }
            this.InvokeAsync("GetListGNWithIdKH", new object[] {
                        idKH}, this.GetListGNWithIdKHOperationCompleted, userState);
        }
        
        private void OnGetListGNWithIdKHOperationCompleted(object arg) {
            if ((this.GetListGNWithIdKHCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetListGNWithIdKHCompleted(this, new GetListGNWithIdKHCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetGN", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetGN(string maGN) {
            object[] results = this.Invoke("GetGN", new object[] {
                        maGN});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetGNAsync(string maGN) {
            this.GetGNAsync(maGN, null);
        }
        
        /// <remarks/>
        public void GetGNAsync(string maGN, object userState) {
            if ((this.GetGNOperationCompleted == null)) {
                this.GetGNOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetGNOperationCompleted);
            }
            this.InvokeAsync("GetGN", new object[] {
                        maGN}, this.GetGNOperationCompleted, userState);
        }
        
        private void OnGetGNOperationCompleted(object arg) {
            if ((this.GetGNCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetGNCompleted(this, new GetGNCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/KTThongTinTraNo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int KTThongTinTraNo(string maGN, string soTienTra, string duNoGoc, string duNoLaiTrongHan, string duNoLaiQuaHan) {
            object[] results = this.Invoke("KTThongTinTraNo", new object[] {
                        maGN,
                        soTienTra,
                        duNoGoc,
                        duNoLaiTrongHan,
                        duNoLaiQuaHan});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void KTThongTinTraNoAsync(string maGN, string soTienTra, string duNoGoc, string duNoLaiTrongHan, string duNoLaiQuaHan) {
            this.KTThongTinTraNoAsync(maGN, soTienTra, duNoGoc, duNoLaiTrongHan, duNoLaiQuaHan, null);
        }
        
        /// <remarks/>
        public void KTThongTinTraNoAsync(string maGN, string soTienTra, string duNoGoc, string duNoLaiTrongHan, string duNoLaiQuaHan, object userState) {
            if ((this.KTThongTinTraNoOperationCompleted == null)) {
                this.KTThongTinTraNoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnKTThongTinTraNoOperationCompleted);
            }
            this.InvokeAsync("KTThongTinTraNo", new object[] {
                        maGN,
                        soTienTra,
                        duNoGoc,
                        duNoLaiTrongHan,
                        duNoLaiQuaHan}, this.KTThongTinTraNoOperationCompleted, userState);
        }
        
        private void OnKTThongTinTraNoOperationCompleted(object arg) {
            if ((this.KTThongTinTraNoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.KTThongTinTraNoCompleted(this, new KTThongTinTraNoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TaoMaTraNo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string TaoMaTraNo(string maGN) {
            object[] results = this.Invoke("TaoMaTraNo", new object[] {
                        maGN});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void TaoMaTraNoAsync(string maGN) {
            this.TaoMaTraNoAsync(maGN, null);
        }
        
        /// <remarks/>
        public void TaoMaTraNoAsync(string maGN, object userState) {
            if ((this.TaoMaTraNoOperationCompleted == null)) {
                this.TaoMaTraNoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTaoMaTraNoOperationCompleted);
            }
            this.InvokeAsync("TaoMaTraNo", new object[] {
                        maGN}, this.TaoMaTraNoOperationCompleted, userState);
        }
        
        private void OnTaoMaTraNoOperationCompleted(object arg) {
            if ((this.TaoMaTraNoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TaoMaTraNoCompleted(this, new TaoMaTraNoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ThemTN", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ThemTN(string jsonData) {
            object[] results = this.Invoke("ThemTN", new object[] {
                        jsonData});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ThemTNAsync(string jsonData) {
            this.ThemTNAsync(jsonData, null);
        }
        
        /// <remarks/>
        public void ThemTNAsync(string jsonData, object userState) {
            if ((this.ThemTNOperationCompleted == null)) {
                this.ThemTNOperationCompleted = new System.Threading.SendOrPostCallback(this.OnThemTNOperationCompleted);
            }
            this.InvokeAsync("ThemTN", new object[] {
                        jsonData}, this.ThemTNOperationCompleted, userState);
        }
        
        private void OnThemTNOperationCompleted(object arg) {
            if ((this.ThemTNCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ThemTNCompleted(this, new ThemTNCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CapNhatDuNo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool CapNhatDuNo(string maGN, long duNoGoc, long duNoLaiTrongHan, long duNoLaiQuaHan) {
            object[] results = this.Invoke("CapNhatDuNo", new object[] {
                        maGN,
                        duNoGoc,
                        duNoLaiTrongHan,
                        duNoLaiQuaHan});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void CapNhatDuNoAsync(string maGN, long duNoGoc, long duNoLaiTrongHan, long duNoLaiQuaHan) {
            this.CapNhatDuNoAsync(maGN, duNoGoc, duNoLaiTrongHan, duNoLaiQuaHan, null);
        }
        
        /// <remarks/>
        public void CapNhatDuNoAsync(string maGN, long duNoGoc, long duNoLaiTrongHan, long duNoLaiQuaHan, object userState) {
            if ((this.CapNhatDuNoOperationCompleted == null)) {
                this.CapNhatDuNoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCapNhatDuNoOperationCompleted);
            }
            this.InvokeAsync("CapNhatDuNo", new object[] {
                        maGN,
                        duNoGoc,
                        duNoLaiTrongHan,
                        duNoLaiQuaHan}, this.CapNhatDuNoOperationCompleted, userState);
        }
        
        private void OnCapNhatDuNoOperationCompleted(object arg) {
            if ((this.CapNhatDuNoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CapNhatDuNoCompleted(this, new CapNhatDuNoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CapNhatNguon", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool CapNhatNguon(int idNg, long tienDaChoVay, long tienCoTheChoVay) {
            object[] results = this.Invoke("CapNhatNguon", new object[] {
                        idNg,
                        tienDaChoVay,
                        tienCoTheChoVay});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void CapNhatNguonAsync(int idNg, long tienDaChoVay, long tienCoTheChoVay) {
            this.CapNhatNguonAsync(idNg, tienDaChoVay, tienCoTheChoVay, null);
        }
        
        /// <remarks/>
        public void CapNhatNguonAsync(int idNg, long tienDaChoVay, long tienCoTheChoVay, object userState) {
            if ((this.CapNhatNguonOperationCompleted == null)) {
                this.CapNhatNguonOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCapNhatNguonOperationCompleted);
            }
            this.InvokeAsync("CapNhatNguon", new object[] {
                        idNg,
                        tienDaChoVay,
                        tienCoTheChoVay}, this.CapNhatNguonOperationCompleted, userState);
        }
        
        private void OnCapNhatNguonOperationCompleted(object arg) {
            if ((this.CapNhatNguonCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CapNhatNguonCompleted(this, new CapNhatNguonCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetIDGN", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int GetIDGN(string maGN) {
            object[] results = this.Invoke("GetIDGN", new object[] {
                        maGN});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void GetIDGNAsync(string maGN) {
            this.GetIDGNAsync(maGN, null);
        }
        
        /// <remarks/>
        public void GetIDGNAsync(string maGN, object userState) {
            if ((this.GetIDGNOperationCompleted == null)) {
                this.GetIDGNOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetIDGNOperationCompleted);
            }
            this.InvokeAsync("GetIDGN", new object[] {
                        maGN}, this.GetIDGNOperationCompleted, userState);
        }
        
        private void OnGetIDGNOperationCompleted(object arg) {
            if ((this.GetIDGNCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetIDGNCompleted(this, new GetIDGNCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetListTN", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetListTN(int idGN) {
            object[] results = this.Invoke("GetListTN", new object[] {
                        idGN});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetListTNAsync(int idGN) {
            this.GetListTNAsync(idGN, null);
        }
        
        /// <remarks/>
        public void GetListTNAsync(int idGN, object userState) {
            if ((this.GetListTNOperationCompleted == null)) {
                this.GetListTNOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetListTNOperationCompleted);
            }
            this.InvokeAsync("GetListTN", new object[] {
                        idGN}, this.GetListTNOperationCompleted, userState);
        }
        
        private void OnGetListTNOperationCompleted(object arg) {
            if ((this.GetListTNCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetListTNCompleted(this, new GetListTNCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void GetListGNCompletedEventHandler(object sender, GetListGNCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetListGNCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetListGNCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetListGNWithIdKHCompletedEventHandler(object sender, GetListGNWithIdKHCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetListGNWithIdKHCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetListGNWithIdKHCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetGNCompletedEventHandler(object sender, GetGNCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetGNCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetGNCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void KTThongTinTraNoCompletedEventHandler(object sender, KTThongTinTraNoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class KTThongTinTraNoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal KTThongTinTraNoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void TaoMaTraNoCompletedEventHandler(object sender, TaoMaTraNoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TaoMaTraNoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TaoMaTraNoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void ThemTNCompletedEventHandler(object sender, ThemTNCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ThemTNCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ThemTNCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void CapNhatDuNoCompletedEventHandler(object sender, CapNhatDuNoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CapNhatDuNoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CapNhatDuNoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void CapNhatNguonCompletedEventHandler(object sender, CapNhatNguonCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CapNhatNguonCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CapNhatNguonCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    public delegate void GetIDGNCompletedEventHandler(object sender, GetIDGNCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetIDGNCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetIDGNCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetListTNCompletedEventHandler(object sender, GetListTNCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetListTNCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetListTNCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
}

#pragma warning restore 1591