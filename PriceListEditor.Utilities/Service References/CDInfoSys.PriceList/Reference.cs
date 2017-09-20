﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PriceListEditor.Utilities.CDInfoSys.PriceList {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseHeader", Namespace="http://schemas.datacontract.org/2004/07/PriceListWcfService.DataContracts")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PriceListEditor.Utilities.CDInfoSys.PriceList.UpdateSuppliersResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PriceListEditor.Utilities.CDInfoSys.PriceList.GetSuppliersResponse))]
    public partial class ResponseHeader : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PriceListEditor.Utilities.CDInfoSys.PriceList.ResponseErrorCode ErrorCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorDescriptionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PriceListEditor.Utilities.CDInfoSys.PriceList.ResponseErrorCode ErrorCode {
            get {
                return this.ErrorCodeField;
            }
            set {
                if ((this.ErrorCodeField.Equals(value) != true)) {
                    this.ErrorCodeField = value;
                    this.RaisePropertyChanged("ErrorCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorDescription {
            get {
                return this.ErrorDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorDescriptionField, value) != true)) {
                    this.ErrorDescriptionField = value;
                    this.RaisePropertyChanged("ErrorDescription");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UpdateSuppliersResponse", Namespace="http://schemas.datacontract.org/2004/07/PriceListWcfService.DataContracts")]
    [System.SerializableAttribute()]
    public partial class UpdateSuppliersResponse : PriceListEditor.Utilities.CDInfoSys.PriceList.ResponseHeader {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetSuppliersResponse", Namespace="http://schemas.datacontract.org/2004/07/PriceListWcfService.DataContracts")]
    [System.SerializableAttribute()]
    public partial class GetSuppliersResponse : PriceListEditor.Utilities.CDInfoSys.PriceList.ResponseHeader {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PriceListEditor.Utilities.CDInfoSys.PriceList.SupplierDTO[] SuppliersField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PriceListEditor.Utilities.CDInfoSys.PriceList.SupplierDTO[] Suppliers {
            get {
                return this.SuppliersField;
            }
            set {
                if ((object.ReferenceEquals(this.SuppliersField, value) != true)) {
                    this.SuppliersField = value;
                    this.RaisePropertyChanged("Suppliers");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseErrorCode", Namespace="http://schemas.datacontract.org/2004/07/PriceListWcfService.DataContracts")]
    public enum ResponseErrorCode : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NoError = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ExceptionCaught = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SupplierDTO", Namespace="http://schemas.datacontract.org/2004/07/PriceListWcfService.DataContracts.Supplie" +
        "r")]
    [System.SerializableAttribute()]
    public partial class SupplierDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescrField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SupplierIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid UniqueIdentifierField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descr {
            get {
                return this.DescrField;
            }
            set {
                if ((object.ReferenceEquals(this.DescrField, value) != true)) {
                    this.DescrField = value;
                    this.RaisePropertyChanged("Descr");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SupplierID {
            get {
                return this.SupplierIDField;
            }
            set {
                if ((this.SupplierIDField.Equals(value) != true)) {
                    this.SupplierIDField = value;
                    this.RaisePropertyChanged("SupplierID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid UniqueIdentifier {
            get {
                return this.UniqueIdentifierField;
            }
            set {
                if ((this.UniqueIdentifierField.Equals(value) != true)) {
                    this.UniqueIdentifierField = value;
                    this.RaisePropertyChanged("UniqueIdentifier");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UpdateSuppliersRequest", Namespace="http://schemas.datacontract.org/2004/07/PriceListWcfService.DataContracts")]
    [System.SerializableAttribute()]
    public partial class UpdateSuppliersRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PriceListEditor.Utilities.CDInfoSys.PriceList.SupplierDTO[] SupplierRecordsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PriceListEditor.Utilities.CDInfoSys.PriceList.SupplierDTO[] SupplierRecords {
            get {
                return this.SupplierRecordsField;
            }
            set {
                if ((object.ReferenceEquals(this.SupplierRecordsField, value) != true)) {
                    this.SupplierRecordsField = value;
                    this.RaisePropertyChanged("SupplierRecords");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CDInfoSys.PriceList.IPriceListService")]
    public interface IPriceListService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPriceListService/GetSuppliers", ReplyAction="http://tempuri.org/IPriceListService/GetSuppliersResponse")]
        PriceListEditor.Utilities.CDInfoSys.PriceList.GetSuppliersResponse GetSuppliers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPriceListService/GetSuppliers", ReplyAction="http://tempuri.org/IPriceListService/GetSuppliersResponse")]
        System.Threading.Tasks.Task<PriceListEditor.Utilities.CDInfoSys.PriceList.GetSuppliersResponse> GetSuppliersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPriceListService/UpdateSuppliers", ReplyAction="http://tempuri.org/IPriceListService/UpdateSuppliersResponse")]
        PriceListEditor.Utilities.CDInfoSys.PriceList.UpdateSuppliersResponse UpdateSuppliers(System.DateTime clientUtcTime, PriceListEditor.Utilities.CDInfoSys.PriceList.UpdateSuppliersRequest supplierDataIn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPriceListService/UpdateSuppliers", ReplyAction="http://tempuri.org/IPriceListService/UpdateSuppliersResponse")]
        System.Threading.Tasks.Task<PriceListEditor.Utilities.CDInfoSys.PriceList.UpdateSuppliersResponse> UpdateSuppliersAsync(System.DateTime clientUtcTime, PriceListEditor.Utilities.CDInfoSys.PriceList.UpdateSuppliersRequest supplierDataIn);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPriceListServiceChannel : PriceListEditor.Utilities.CDInfoSys.PriceList.IPriceListService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PriceListServiceClient : System.ServiceModel.ClientBase<PriceListEditor.Utilities.CDInfoSys.PriceList.IPriceListService>, PriceListEditor.Utilities.CDInfoSys.PriceList.IPriceListService {
        
        public PriceListServiceClient() {
        }
        
        public PriceListServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PriceListServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PriceListServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PriceListServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PriceListEditor.Utilities.CDInfoSys.PriceList.GetSuppliersResponse GetSuppliers() {
            return base.Channel.GetSuppliers();
        }
        
        public System.Threading.Tasks.Task<PriceListEditor.Utilities.CDInfoSys.PriceList.GetSuppliersResponse> GetSuppliersAsync() {
            return base.Channel.GetSuppliersAsync();
        }
        
        public PriceListEditor.Utilities.CDInfoSys.PriceList.UpdateSuppliersResponse UpdateSuppliers(System.DateTime clientUtcTime, PriceListEditor.Utilities.CDInfoSys.PriceList.UpdateSuppliersRequest supplierDataIn) {
            return base.Channel.UpdateSuppliers(clientUtcTime, supplierDataIn);
        }
        
        public System.Threading.Tasks.Task<PriceListEditor.Utilities.CDInfoSys.PriceList.UpdateSuppliersResponse> UpdateSuppliersAsync(System.DateTime clientUtcTime, PriceListEditor.Utilities.CDInfoSys.PriceList.UpdateSuppliersRequest supplierDataIn) {
            return base.Channel.UpdateSuppliersAsync(clientUtcTime, supplierDataIn);
        }
    }
}