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

namespace FormDesignFSS2.XuLyCuoiNgayWS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="XuLyCuoiNgayBUSSoap", Namespace="http://tempuri.org/")]
    public partial class XuLyCuoiNgayBUS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback LayNgayLamViecHienTaiOperationCompleted;
        
        private System.Threading.SendOrPostCallback KTThongTinChayQuaNgayOperationCompleted;
        
        private System.Threading.SendOrPostCallback XuLyCuoiNgayOperationCompleted;
        
        private System.Threading.SendOrPostCallback LaNgayNghiOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetListNgayNghiOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public XuLyCuoiNgayBUS() {
            this.Url = global::FormDesignFSS2.Properties.Settings.Default.FormDesignFSS2_XuLyCuoiNgayWS_XuLyCuoiNgayBUS;
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
        public event LayNgayLamViecHienTaiCompletedEventHandler LayNgayLamViecHienTaiCompleted;
        
        /// <remarks/>
        public event KTThongTinChayQuaNgayCompletedEventHandler KTThongTinChayQuaNgayCompleted;
        
        /// <remarks/>
        public event XuLyCuoiNgayCompletedEventHandler XuLyCuoiNgayCompleted;
        
        /// <remarks/>
        public event LaNgayNghiCompletedEventHandler LaNgayNghiCompleted;
        
        /// <remarks/>
        public event GetListNgayNghiCompletedEventHandler GetListNgayNghiCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/LayNgayLamViecHienTai", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string LayNgayLamViecHienTai() {
            object[] results = this.Invoke("LayNgayLamViecHienTai", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void LayNgayLamViecHienTaiAsync() {
            this.LayNgayLamViecHienTaiAsync(null);
        }
        
        /// <remarks/>
        public void LayNgayLamViecHienTaiAsync(object userState) {
            if ((this.LayNgayLamViecHienTaiOperationCompleted == null)) {
                this.LayNgayLamViecHienTaiOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLayNgayLamViecHienTaiOperationCompleted);
            }
            this.InvokeAsync("LayNgayLamViecHienTai", new object[0], this.LayNgayLamViecHienTaiOperationCompleted, userState);
        }
        
        private void OnLayNgayLamViecHienTaiOperationCompleted(object arg) {
            if ((this.LayNgayLamViecHienTaiCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LayNgayLamViecHienTaiCompleted(this, new LayNgayLamViecHienTaiCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/KTThongTinChayQuaNgay", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int KTThongTinChayQuaNgay(string ngayLVHienTai, string ngayLVTiepTheo) {
            object[] results = this.Invoke("KTThongTinChayQuaNgay", new object[] {
                        ngayLVHienTai,
                        ngayLVTiepTheo});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void KTThongTinChayQuaNgayAsync(string ngayLVHienTai, string ngayLVTiepTheo) {
            this.KTThongTinChayQuaNgayAsync(ngayLVHienTai, ngayLVTiepTheo, null);
        }
        
        /// <remarks/>
        public void KTThongTinChayQuaNgayAsync(string ngayLVHienTai, string ngayLVTiepTheo, object userState) {
            if ((this.KTThongTinChayQuaNgayOperationCompleted == null)) {
                this.KTThongTinChayQuaNgayOperationCompleted = new System.Threading.SendOrPostCallback(this.OnKTThongTinChayQuaNgayOperationCompleted);
            }
            this.InvokeAsync("KTThongTinChayQuaNgay", new object[] {
                        ngayLVHienTai,
                        ngayLVTiepTheo}, this.KTThongTinChayQuaNgayOperationCompleted, userState);
        }
        
        private void OnKTThongTinChayQuaNgayOperationCompleted(object arg) {
            if ((this.KTThongTinChayQuaNgayCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.KTThongTinChayQuaNgayCompleted(this, new KTThongTinChayQuaNgayCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/XuLyCuoiNgay", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool XuLyCuoiNgay(string ngayLVHienTai, string ngayLVTiepTheo) {
            object[] results = this.Invoke("XuLyCuoiNgay", new object[] {
                        ngayLVHienTai,
                        ngayLVTiepTheo});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void XuLyCuoiNgayAsync(string ngayLVHienTai, string ngayLVTiepTheo) {
            this.XuLyCuoiNgayAsync(ngayLVHienTai, ngayLVTiepTheo, null);
        }
        
        /// <remarks/>
        public void XuLyCuoiNgayAsync(string ngayLVHienTai, string ngayLVTiepTheo, object userState) {
            if ((this.XuLyCuoiNgayOperationCompleted == null)) {
                this.XuLyCuoiNgayOperationCompleted = new System.Threading.SendOrPostCallback(this.OnXuLyCuoiNgayOperationCompleted);
            }
            this.InvokeAsync("XuLyCuoiNgay", new object[] {
                        ngayLVHienTai,
                        ngayLVTiepTheo}, this.XuLyCuoiNgayOperationCompleted, userState);
        }
        
        private void OnXuLyCuoiNgayOperationCompleted(object arg) {
            if ((this.XuLyCuoiNgayCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.XuLyCuoiNgayCompleted(this, new XuLyCuoiNgayCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/LaNgayNghi", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool LaNgayNghi(string dateTime) {
            object[] results = this.Invoke("LaNgayNghi", new object[] {
                        dateTime});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void LaNgayNghiAsync(string dateTime) {
            this.LaNgayNghiAsync(dateTime, null);
        }
        
        /// <remarks/>
        public void LaNgayNghiAsync(string dateTime, object userState) {
            if ((this.LaNgayNghiOperationCompleted == null)) {
                this.LaNgayNghiOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLaNgayNghiOperationCompleted);
            }
            this.InvokeAsync("LaNgayNghi", new object[] {
                        dateTime}, this.LaNgayNghiOperationCompleted, userState);
        }
        
        private void OnLaNgayNghiOperationCompleted(object arg) {
            if ((this.LaNgayNghiCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LaNgayNghiCompleted(this, new LaNgayNghiCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetListNgayNghi", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetListNgayNghi() {
            object[] results = this.Invoke("GetListNgayNghi", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetListNgayNghiAsync() {
            this.GetListNgayNghiAsync(null);
        }
        
        /// <remarks/>
        public void GetListNgayNghiAsync(object userState) {
            if ((this.GetListNgayNghiOperationCompleted == null)) {
                this.GetListNgayNghiOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetListNgayNghiOperationCompleted);
            }
            this.InvokeAsync("GetListNgayNghi", new object[0], this.GetListNgayNghiOperationCompleted, userState);
        }
        
        private void OnGetListNgayNghiOperationCompleted(object arg) {
            if ((this.GetListNgayNghiCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetListNgayNghiCompleted(this, new GetListNgayNghiCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void LayNgayLamViecHienTaiCompletedEventHandler(object sender, LayNgayLamViecHienTaiCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LayNgayLamViecHienTaiCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LayNgayLamViecHienTaiCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void KTThongTinChayQuaNgayCompletedEventHandler(object sender, KTThongTinChayQuaNgayCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class KTThongTinChayQuaNgayCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal KTThongTinChayQuaNgayCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void XuLyCuoiNgayCompletedEventHandler(object sender, XuLyCuoiNgayCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class XuLyCuoiNgayCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal XuLyCuoiNgayCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void LaNgayNghiCompletedEventHandler(object sender, LaNgayNghiCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LaNgayNghiCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LaNgayNghiCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetListNgayNghiCompletedEventHandler(object sender, GetListNgayNghiCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetListNgayNghiCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetListNgayNghiCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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