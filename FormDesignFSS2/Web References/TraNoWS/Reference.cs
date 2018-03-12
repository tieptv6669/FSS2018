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
        public int KTThongTinTraNo(string maGN, string soTienTra) {
            object[] results = this.Invoke("KTThongTinTraNo", new object[] {
                        maGN,
                        soTienTra});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void KTThongTinTraNoAsync(string maGN, string soTienTra) {
            this.KTThongTinTraNoAsync(maGN, soTienTra, null);
        }
        
        /// <remarks/>
        public void KTThongTinTraNoAsync(string maGN, string soTienTra, object userState) {
            if ((this.KTThongTinTraNoOperationCompleted == null)) {
                this.KTThongTinTraNoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnKTThongTinTraNoOperationCompleted);
            }
            this.InvokeAsync("KTThongTinTraNo", new object[] {
                        maGN,
                        soTienTra}, this.KTThongTinTraNoOperationCompleted, userState);
        }
        
        private void OnKTThongTinTraNoOperationCompleted(object arg) {
            if ((this.KTThongTinTraNoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.KTThongTinTraNoCompleted(this, new KTThongTinTraNoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
}

#pragma warning restore 1591