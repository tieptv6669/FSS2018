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

namespace FormDesignFSS2.LichSuWS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="LichSuBUSSoap", Namespace="http://tempuri.org/")]
    public partial class LichSuBUS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback TimKiemLichSuOperationCompleted;
        
        private System.Threading.SendOrPostCallback ThemLichSuOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public LichSuBUS() {
            this.Url = global::FormDesignFSS2.Properties.Settings.Default.FormDesignFSS2_LichSuWS_LichSuBUS;
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
        public event TimKiemLichSuCompletedEventHandler TimKiemLichSuCompleted;
        
        /// <remarks/>
        public event ThemLichSuCompletedEventHandler ThemLichSuCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TimKiemLichSu", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string TimKiemLichSu(string tenDangNhap, string soTKLK, string maDT, string startDate, string finishDate) {
            object[] results = this.Invoke("TimKiemLichSu", new object[] {
                        tenDangNhap,
                        soTKLK,
                        maDT,
                        startDate,
                        finishDate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void TimKiemLichSuAsync(string tenDangNhap, string soTKLK, string maDT, string startDate, string finishDate) {
            this.TimKiemLichSuAsync(tenDangNhap, soTKLK, maDT, startDate, finishDate, null);
        }
        
        /// <remarks/>
        public void TimKiemLichSuAsync(string tenDangNhap, string soTKLK, string maDT, string startDate, string finishDate, object userState) {
            if ((this.TimKiemLichSuOperationCompleted == null)) {
                this.TimKiemLichSuOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTimKiemLichSuOperationCompleted);
            }
            this.InvokeAsync("TimKiemLichSu", new object[] {
                        tenDangNhap,
                        soTKLK,
                        maDT,
                        startDate,
                        finishDate}, this.TimKiemLichSuOperationCompleted, userState);
        }
        
        private void OnTimKiemLichSuOperationCompleted(object arg) {
            if ((this.TimKiemLichSuCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TimKiemLichSuCompleted(this, new TimKiemLichSuCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ThemLichSu", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ThemLichSu(string jsonData) {
            object[] results = this.Invoke("ThemLichSu", new object[] {
                        jsonData});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ThemLichSuAsync(string jsonData) {
            this.ThemLichSuAsync(jsonData, null);
        }
        
        /// <remarks/>
        public void ThemLichSuAsync(string jsonData, object userState) {
            if ((this.ThemLichSuOperationCompleted == null)) {
                this.ThemLichSuOperationCompleted = new System.Threading.SendOrPostCallback(this.OnThemLichSuOperationCompleted);
            }
            this.InvokeAsync("ThemLichSu", new object[] {
                        jsonData}, this.ThemLichSuOperationCompleted, userState);
        }
        
        private void OnThemLichSuOperationCompleted(object arg) {
            if ((this.ThemLichSuCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ThemLichSuCompleted(this, new ThemLichSuCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void TimKiemLichSuCompletedEventHandler(object sender, TimKiemLichSuCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TimKiemLichSuCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TimKiemLichSuCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void ThemLichSuCompletedEventHandler(object sender, ThemLichSuCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ThemLichSuCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ThemLichSuCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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