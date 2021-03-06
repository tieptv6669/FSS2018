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

namespace FormDesignFSS2.NguonWS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="NguonBUSSoap", Namespace="http://tempuri.org/")]
    public partial class NguonBUS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback LayDSNguonOperationCompleted;
        
        private System.Threading.SendOrPostCallback TimKiemNguonOperationCompleted;
        
        private System.Threading.SendOrPostCallback TaoMaNguonOperationCompleted;
        
        private System.Threading.SendOrPostCallback KTThongTinThemNguonOperationCompleted;
        
        private System.Threading.SendOrPostCallback ThemNguonMoiOperationCompleted;
        
        private System.Threading.SendOrPostCallback KTThongTinSuaNguonOperationCompleted;
        
        private System.Threading.SendOrPostCallback SuaNguonOperationCompleted;
        
        private System.Threading.SendOrPostCallback XoaNguonOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetNguonOperationCompleted;
        
        private System.Threading.SendOrPostCallback updateSoTienOperationCompleted;
        
        private System.Threading.SendOrPostCallback updateSoTienSuaOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetNguonWithIDOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public NguonBUS() {
            this.Url = global::FormDesignFSS2.Properties.Settings.Default.FormDesignFSS2_NguonWS_NguonBUS;
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
        public event LayDSNguonCompletedEventHandler LayDSNguonCompleted;
        
        /// <remarks/>
        public event TimKiemNguonCompletedEventHandler TimKiemNguonCompleted;
        
        /// <remarks/>
        public event TaoMaNguonCompletedEventHandler TaoMaNguonCompleted;
        
        /// <remarks/>
        public event KTThongTinThemNguonCompletedEventHandler KTThongTinThemNguonCompleted;
        
        /// <remarks/>
        public event ThemNguonMoiCompletedEventHandler ThemNguonMoiCompleted;
        
        /// <remarks/>
        public event KTThongTinSuaNguonCompletedEventHandler KTThongTinSuaNguonCompleted;
        
        /// <remarks/>
        public event SuaNguonCompletedEventHandler SuaNguonCompleted;
        
        /// <remarks/>
        public event XoaNguonCompletedEventHandler XoaNguonCompleted;
        
        /// <remarks/>
        public event GetNguonCompletedEventHandler GetNguonCompleted;
        
        /// <remarks/>
        public event updateSoTienCompletedEventHandler updateSoTienCompleted;
        
        /// <remarks/>
        public event updateSoTienSuaCompletedEventHandler updateSoTienSuaCompleted;
        
        /// <remarks/>
        public event GetNguonWithIDCompletedEventHandler GetNguonWithIDCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/LayDSNguon", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string LayDSNguon() {
            object[] results = this.Invoke("LayDSNguon", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void LayDSNguonAsync() {
            this.LayDSNguonAsync(null);
        }
        
        /// <remarks/>
        public void LayDSNguonAsync(object userState) {
            if ((this.LayDSNguonOperationCompleted == null)) {
                this.LayDSNguonOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLayDSNguonOperationCompleted);
            }
            this.InvokeAsync("LayDSNguon", new object[0], this.LayDSNguonOperationCompleted, userState);
        }
        
        private void OnLayDSNguonOperationCompleted(object arg) {
            if ((this.LayDSNguonCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LayDSNguonCompleted(this, new LayDSNguonCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TimKiemNguon", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string TimKiemNguon(string tenNguon, string maNguon) {
            object[] results = this.Invoke("TimKiemNguon", new object[] {
                        tenNguon,
                        maNguon});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void TimKiemNguonAsync(string tenNguon, string maNguon) {
            this.TimKiemNguonAsync(tenNguon, maNguon, null);
        }
        
        /// <remarks/>
        public void TimKiemNguonAsync(string tenNguon, string maNguon, object userState) {
            if ((this.TimKiemNguonOperationCompleted == null)) {
                this.TimKiemNguonOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTimKiemNguonOperationCompleted);
            }
            this.InvokeAsync("TimKiemNguon", new object[] {
                        tenNguon,
                        maNguon}, this.TimKiemNguonOperationCompleted, userState);
        }
        
        private void OnTimKiemNguonOperationCompleted(object arg) {
            if ((this.TimKiemNguonCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TimKiemNguonCompleted(this, new TimKiemNguonCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TaoMaNguon", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string TaoMaNguon() {
            object[] results = this.Invoke("TaoMaNguon", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void TaoMaNguonAsync() {
            this.TaoMaNguonAsync(null);
        }
        
        /// <remarks/>
        public void TaoMaNguonAsync(object userState) {
            if ((this.TaoMaNguonOperationCompleted == null)) {
                this.TaoMaNguonOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTaoMaNguonOperationCompleted);
            }
            this.InvokeAsync("TaoMaNguon", new object[0], this.TaoMaNguonOperationCompleted, userState);
        }
        
        private void OnTaoMaNguonOperationCompleted(object arg) {
            if ((this.TaoMaNguonCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TaoMaNguonCompleted(this, new TaoMaNguonCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/KTThongTinThemNguon", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int KTThongTinThemNguon(string tenNguon, string hanMuc) {
            object[] results = this.Invoke("KTThongTinThemNguon", new object[] {
                        tenNguon,
                        hanMuc});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void KTThongTinThemNguonAsync(string tenNguon, string hanMuc) {
            this.KTThongTinThemNguonAsync(tenNguon, hanMuc, null);
        }
        
        /// <remarks/>
        public void KTThongTinThemNguonAsync(string tenNguon, string hanMuc, object userState) {
            if ((this.KTThongTinThemNguonOperationCompleted == null)) {
                this.KTThongTinThemNguonOperationCompleted = new System.Threading.SendOrPostCallback(this.OnKTThongTinThemNguonOperationCompleted);
            }
            this.InvokeAsync("KTThongTinThemNguon", new object[] {
                        tenNguon,
                        hanMuc}, this.KTThongTinThemNguonOperationCompleted, userState);
        }
        
        private void OnKTThongTinThemNguonOperationCompleted(object arg) {
            if ((this.KTThongTinThemNguonCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.KTThongTinThemNguonCompleted(this, new KTThongTinThemNguonCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ThemNguonMoi", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ThemNguonMoi(string jsonData) {
            object[] results = this.Invoke("ThemNguonMoi", new object[] {
                        jsonData});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ThemNguonMoiAsync(string jsonData) {
            this.ThemNguonMoiAsync(jsonData, null);
        }
        
        /// <remarks/>
        public void ThemNguonMoiAsync(string jsonData, object userState) {
            if ((this.ThemNguonMoiOperationCompleted == null)) {
                this.ThemNguonMoiOperationCompleted = new System.Threading.SendOrPostCallback(this.OnThemNguonMoiOperationCompleted);
            }
            this.InvokeAsync("ThemNguonMoi", new object[] {
                        jsonData}, this.ThemNguonMoiOperationCompleted, userState);
        }
        
        private void OnThemNguonMoiOperationCompleted(object arg) {
            if ((this.ThemNguonMoiCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ThemNguonMoiCompleted(this, new ThemNguonMoiCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/KTThongTinSuaNguon", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int KTThongTinSuaNguon(string hanMuc, string soTienDaChoVay) {
            object[] results = this.Invoke("KTThongTinSuaNguon", new object[] {
                        hanMuc,
                        soTienDaChoVay});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void KTThongTinSuaNguonAsync(string hanMuc, string soTienDaChoVay) {
            this.KTThongTinSuaNguonAsync(hanMuc, soTienDaChoVay, null);
        }
        
        /// <remarks/>
        public void KTThongTinSuaNguonAsync(string hanMuc, string soTienDaChoVay, object userState) {
            if ((this.KTThongTinSuaNguonOperationCompleted == null)) {
                this.KTThongTinSuaNguonOperationCompleted = new System.Threading.SendOrPostCallback(this.OnKTThongTinSuaNguonOperationCompleted);
            }
            this.InvokeAsync("KTThongTinSuaNguon", new object[] {
                        hanMuc,
                        soTienDaChoVay}, this.KTThongTinSuaNguonOperationCompleted, userState);
        }
        
        private void OnKTThongTinSuaNguonOperationCompleted(object arg) {
            if ((this.KTThongTinSuaNguonCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.KTThongTinSuaNguonCompleted(this, new KTThongTinSuaNguonCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SuaNguon", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SuaNguon(string maNguon, string hanMuc, string soTienCoTheChoVay) {
            object[] results = this.Invoke("SuaNguon", new object[] {
                        maNguon,
                        hanMuc,
                        soTienCoTheChoVay});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SuaNguonAsync(string maNguon, string hanMuc, string soTienCoTheChoVay) {
            this.SuaNguonAsync(maNguon, hanMuc, soTienCoTheChoVay, null);
        }
        
        /// <remarks/>
        public void SuaNguonAsync(string maNguon, string hanMuc, string soTienCoTheChoVay, object userState) {
            if ((this.SuaNguonOperationCompleted == null)) {
                this.SuaNguonOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSuaNguonOperationCompleted);
            }
            this.InvokeAsync("SuaNguon", new object[] {
                        maNguon,
                        hanMuc,
                        soTienCoTheChoVay}, this.SuaNguonOperationCompleted, userState);
        }
        
        private void OnSuaNguonOperationCompleted(object arg) {
            if ((this.SuaNguonCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SuaNguonCompleted(this, new SuaNguonCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/XoaNguon", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool XoaNguon(string maNguon) {
            object[] results = this.Invoke("XoaNguon", new object[] {
                        maNguon});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void XoaNguonAsync(string maNguon) {
            this.XoaNguonAsync(maNguon, null);
        }
        
        /// <remarks/>
        public void XoaNguonAsync(string maNguon, object userState) {
            if ((this.XoaNguonOperationCompleted == null)) {
                this.XoaNguonOperationCompleted = new System.Threading.SendOrPostCallback(this.OnXoaNguonOperationCompleted);
            }
            this.InvokeAsync("XoaNguon", new object[] {
                        maNguon}, this.XoaNguonOperationCompleted, userState);
        }
        
        private void OnXoaNguonOperationCompleted(object arg) {
            if ((this.XoaNguonCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.XoaNguonCompleted(this, new XoaNguonCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetNguon", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetNguon(string tenNguon) {
            object[] results = this.Invoke("GetNguon", new object[] {
                        tenNguon});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetNguonAsync(string tenNguon) {
            this.GetNguonAsync(tenNguon, null);
        }
        
        /// <remarks/>
        public void GetNguonAsync(string tenNguon, object userState) {
            if ((this.GetNguonOperationCompleted == null)) {
                this.GetNguonOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetNguonOperationCompleted);
            }
            this.InvokeAsync("GetNguon", new object[] {
                        tenNguon}, this.GetNguonOperationCompleted, userState);
        }
        
        private void OnGetNguonOperationCompleted(object arg) {
            if ((this.GetNguonCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetNguonCompleted(this, new GetNguonCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/updateSoTien", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool updateSoTien(long choVay, int idNguon, long coTheVay, long daChoVay) {
            object[] results = this.Invoke("updateSoTien", new object[] {
                        choVay,
                        idNguon,
                        coTheVay,
                        daChoVay});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void updateSoTienAsync(long choVay, int idNguon, long coTheVay, long daChoVay) {
            this.updateSoTienAsync(choVay, idNguon, coTheVay, daChoVay, null);
        }
        
        /// <remarks/>
        public void updateSoTienAsync(long choVay, int idNguon, long coTheVay, long daChoVay, object userState) {
            if ((this.updateSoTienOperationCompleted == null)) {
                this.updateSoTienOperationCompleted = new System.Threading.SendOrPostCallback(this.OnupdateSoTienOperationCompleted);
            }
            this.InvokeAsync("updateSoTien", new object[] {
                        choVay,
                        idNguon,
                        coTheVay,
                        daChoVay}, this.updateSoTienOperationCompleted, userState);
        }
        
        private void OnupdateSoTienOperationCompleted(object arg) {
            if ((this.updateSoTienCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.updateSoTienCompleted(this, new updateSoTienCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/updateSoTienSua", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool updateSoTienSua(long choVay, int idNguon, long coTheVay, long daChoVay) {
            object[] results = this.Invoke("updateSoTienSua", new object[] {
                        choVay,
                        idNguon,
                        coTheVay,
                        daChoVay});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void updateSoTienSuaAsync(long choVay, int idNguon, long coTheVay, long daChoVay) {
            this.updateSoTienSuaAsync(choVay, idNguon, coTheVay, daChoVay, null);
        }
        
        /// <remarks/>
        public void updateSoTienSuaAsync(long choVay, int idNguon, long coTheVay, long daChoVay, object userState) {
            if ((this.updateSoTienSuaOperationCompleted == null)) {
                this.updateSoTienSuaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnupdateSoTienSuaOperationCompleted);
            }
            this.InvokeAsync("updateSoTienSua", new object[] {
                        choVay,
                        idNguon,
                        coTheVay,
                        daChoVay}, this.updateSoTienSuaOperationCompleted, userState);
        }
        
        private void OnupdateSoTienSuaOperationCompleted(object arg) {
            if ((this.updateSoTienSuaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.updateSoTienSuaCompleted(this, new updateSoTienSuaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetNguonWithID", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetNguonWithID(int idNg) {
            object[] results = this.Invoke("GetNguonWithID", new object[] {
                        idNg});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetNguonWithIDAsync(int idNg) {
            this.GetNguonWithIDAsync(idNg, null);
        }
        
        /// <remarks/>
        public void GetNguonWithIDAsync(int idNg, object userState) {
            if ((this.GetNguonWithIDOperationCompleted == null)) {
                this.GetNguonWithIDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetNguonWithIDOperationCompleted);
            }
            this.InvokeAsync("GetNguonWithID", new object[] {
                        idNg}, this.GetNguonWithIDOperationCompleted, userState);
        }
        
        private void OnGetNguonWithIDOperationCompleted(object arg) {
            if ((this.GetNguonWithIDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetNguonWithIDCompleted(this, new GetNguonWithIDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void LayDSNguonCompletedEventHandler(object sender, LayDSNguonCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LayDSNguonCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LayDSNguonCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void TimKiemNguonCompletedEventHandler(object sender, TimKiemNguonCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TimKiemNguonCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TimKiemNguonCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void TaoMaNguonCompletedEventHandler(object sender, TaoMaNguonCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TaoMaNguonCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TaoMaNguonCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void KTThongTinThemNguonCompletedEventHandler(object sender, KTThongTinThemNguonCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class KTThongTinThemNguonCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal KTThongTinThemNguonCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void ThemNguonMoiCompletedEventHandler(object sender, ThemNguonMoiCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ThemNguonMoiCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ThemNguonMoiCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void KTThongTinSuaNguonCompletedEventHandler(object sender, KTThongTinSuaNguonCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class KTThongTinSuaNguonCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal KTThongTinSuaNguonCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void SuaNguonCompletedEventHandler(object sender, SuaNguonCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SuaNguonCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SuaNguonCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void XoaNguonCompletedEventHandler(object sender, XoaNguonCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class XoaNguonCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal XoaNguonCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetNguonCompletedEventHandler(object sender, GetNguonCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetNguonCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetNguonCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void updateSoTienCompletedEventHandler(object sender, updateSoTienCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class updateSoTienCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal updateSoTienCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void updateSoTienSuaCompletedEventHandler(object sender, updateSoTienSuaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class updateSoTienSuaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal updateSoTienSuaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetNguonWithIDCompletedEventHandler(object sender, GetNguonWithIDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetNguonWithIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetNguonWithIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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