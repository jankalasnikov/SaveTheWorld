﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SaveWorldWebsite.ProductServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProductB", Namespace="http://schemas.datacontract.org/2004/07/SaveWorldModel")]
    [System.SerializableAttribute()]
    public partial class ProductB : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductDescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProductIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SizeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StockField;
        
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
        public decimal Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductDescription {
            get {
                return this.ProductDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductDescriptionField, value) != true)) {
                    this.ProductDescriptionField = value;
                    this.RaisePropertyChanged("ProductDescription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductId {
            get {
                return this.ProductIdField;
            }
            set {
                if ((this.ProductIdField.Equals(value) != true)) {
                    this.ProductIdField = value;
                    this.RaisePropertyChanged("ProductId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductName {
            get {
                return this.ProductNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductNameField, value) != true)) {
                    this.ProductNameField = value;
                    this.RaisePropertyChanged("ProductName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Size {
            get {
                return this.SizeField;
            }
            set {
                if ((object.ReferenceEquals(this.SizeField, value) != true)) {
                    this.SizeField = value;
                    this.RaisePropertyChanged("Size");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Stock {
            get {
                return this.StockField;
            }
            set {
                if ((this.StockField.Equals(value) != true)) {
                    this.StockField = value;
                    this.RaisePropertyChanged("Stock");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductServiceReference.IProductService")]
    public interface IProductService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProduct", ReplyAction="http://tempuri.org/IProductService/GetProductResponse")]
        SaveWorldWebsite.ProductServiceReference.ProductB GetProduct(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProduct", ReplyAction="http://tempuri.org/IProductService/GetProductResponse")]
        System.Threading.Tasks.Task<SaveWorldWebsite.ProductServiceReference.ProductB> GetProductAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProductByName", ReplyAction="http://tempuri.org/IProductService/GetProductByNameResponse")]
        SaveWorldWebsite.ProductServiceReference.ProductB GetProductByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProductByName", ReplyAction="http://tempuri.org/IProductService/GetProductByNameResponse")]
        System.Threading.Tasks.Task<SaveWorldWebsite.ProductServiceReference.ProductB> GetProductByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAllProduct", ReplyAction="http://tempuri.org/IProductService/GetAllProductResponse")]
        SaveWorldWebsite.ProductServiceReference.ProductB[] GetAllProduct();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetAllProduct", ReplyAction="http://tempuri.org/IProductService/GetAllProductResponse")]
        System.Threading.Tasks.Task<SaveWorldWebsite.ProductServiceReference.ProductB[]> GetAllProductAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/RemoveStockFromProduct", ReplyAction="http://tempuri.org/IProductService/RemoveStockFromProductResponse")]
        void RemoveStockFromProduct(int id, int removeQuantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/RemoveStockFromProduct", ReplyAction="http://tempuri.org/IProductService/RemoveStockFromProductResponse")]
        System.Threading.Tasks.Task RemoveStockFromProductAsync(int id, int removeQuantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/ReturnStock", ReplyAction="http://tempuri.org/IProductService/ReturnStockResponse")]
        void ReturnStock(int idOfProduct, int returnQuantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/ReturnStock", ReplyAction="http://tempuri.org/IProductService/ReturnStockResponse")]
        System.Threading.Tasks.Task ReturnStockAsync(int idOfProduct, int returnQuantity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductServiceChannel : SaveWorldWebsite.ProductServiceReference.IProductService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductServiceClient : System.ServiceModel.ClientBase<SaveWorldWebsite.ProductServiceReference.IProductService>, SaveWorldWebsite.ProductServiceReference.IProductService {
        
        public ProductServiceClient() {
        }
        
        public ProductServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SaveWorldWebsite.ProductServiceReference.ProductB GetProduct(int id) {
            return base.Channel.GetProduct(id);
        }
        
        public System.Threading.Tasks.Task<SaveWorldWebsite.ProductServiceReference.ProductB> GetProductAsync(int id) {
            return base.Channel.GetProductAsync(id);
        }
        
        public SaveWorldWebsite.ProductServiceReference.ProductB GetProductByName(string name) {
            return base.Channel.GetProductByName(name);
        }
        
        public System.Threading.Tasks.Task<SaveWorldWebsite.ProductServiceReference.ProductB> GetProductByNameAsync(string name) {
            return base.Channel.GetProductByNameAsync(name);
        }
        
        public SaveWorldWebsite.ProductServiceReference.ProductB[] GetAllProduct() {
            return base.Channel.GetAllProduct();
        }
        
        public System.Threading.Tasks.Task<SaveWorldWebsite.ProductServiceReference.ProductB[]> GetAllProductAsync() {
            return base.Channel.GetAllProductAsync();
        }
        
        public void RemoveStockFromProduct(int id, int removeQuantity) {
            base.Channel.RemoveStockFromProduct(id, removeQuantity);
        }
        
        public System.Threading.Tasks.Task RemoveStockFromProductAsync(int id, int removeQuantity) {
            return base.Channel.RemoveStockFromProductAsync(id, removeQuantity);
        }
        
        public void ReturnStock(int idOfProduct, int returnQuantity) {
            base.Channel.ReturnStock(idOfProduct, returnQuantity);
        }
        
        public System.Threading.Tasks.Task ReturnStockAsync(int idOfProduct, int returnQuantity) {
            return base.Channel.ReturnStockAsync(idOfProduct, returnQuantity);
        }
    }
}
