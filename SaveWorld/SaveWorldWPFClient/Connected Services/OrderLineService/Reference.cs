﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SaveWorldWPFClient.OrderLineService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderLine", Namespace="http://schemas.datacontract.org/2004/07/SaveWorldModel")]
    [System.SerializableAttribute()]
    public partial class OrderLine : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrderIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrderLineIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProductIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QuantityField;
        
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
        public int OrderID {
            get {
                return this.OrderIDField;
            }
            set {
                if ((this.OrderIDField.Equals(value) != true)) {
                    this.OrderIDField = value;
                    this.RaisePropertyChanged("OrderID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OrderLineId {
            get {
                return this.OrderLineIdField;
            }
            set {
                if ((this.OrderLineIdField.Equals(value) != true)) {
                    this.OrderLineIdField = value;
                    this.RaisePropertyChanged("OrderLineId");
                }
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
        public int ProductID {
            get {
                return this.ProductIDField;
            }
            set {
                if ((this.ProductIDField.Equals(value) != true)) {
                    this.ProductIDField = value;
                    this.RaisePropertyChanged("ProductID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Quantity {
            get {
                return this.QuantityField;
            }
            set {
                if ((this.QuantityField.Equals(value) != true)) {
                    this.QuantityField = value;
                    this.RaisePropertyChanged("Quantity");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OrderLineService.IOrderLineService")]
    public interface IOrderLineService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderLineService/CreateOrderLine", ReplyAction="http://tempuri.org/IOrderLineService/CreateOrderLineResponse")]
        SaveWorldWPFClient.OrderLineService.OrderLine CreateOrderLine(SaveWorldWPFClient.OrderLineService.OrderLine newOrderLine);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderLineService/CreateOrderLine", ReplyAction="http://tempuri.org/IOrderLineService/CreateOrderLineResponse")]
        System.Threading.Tasks.Task<SaveWorldWPFClient.OrderLineService.OrderLine> CreateOrderLineAsync(SaveWorldWPFClient.OrderLineService.OrderLine newOrderLine);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderLineService/RemoveOrderLineAndReturnStock", ReplyAction="http://tempuri.org/IOrderLineService/RemoveOrderLineAndReturnStockResponse")]
        int RemoveOrderLineAndReturnStock(int idToRemoveOrderLine);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderLineService/RemoveOrderLineAndReturnStock", ReplyAction="http://tempuri.org/IOrderLineService/RemoveOrderLineAndReturnStockResponse")]
        System.Threading.Tasks.Task<int> RemoveOrderLineAndReturnStockAsync(int idToRemoveOrderLine);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderLineService/UpdateOrderLine", ReplyAction="http://tempuri.org/IOrderLineService/UpdateOrderLineResponse")]
        void UpdateOrderLine(SaveWorldWPFClient.OrderLineService.OrderLine orderLine);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderLineService/UpdateOrderLine", ReplyAction="http://tempuri.org/IOrderLineService/UpdateOrderLineResponse")]
        System.Threading.Tasks.Task UpdateOrderLineAsync(SaveWorldWPFClient.OrderLineService.OrderLine orderLine);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOrderLineServiceChannel : SaveWorldWPFClient.OrderLineService.IOrderLineService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OrderLineServiceClient : System.ServiceModel.ClientBase<SaveWorldWPFClient.OrderLineService.IOrderLineService>, SaveWorldWPFClient.OrderLineService.IOrderLineService {
        
        public OrderLineServiceClient() {
        }
        
        public OrderLineServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OrderLineServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderLineServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderLineServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SaveWorldWPFClient.OrderLineService.OrderLine CreateOrderLine(SaveWorldWPFClient.OrderLineService.OrderLine newOrderLine) {
            return base.Channel.CreateOrderLine(newOrderLine);
        }
        
        public System.Threading.Tasks.Task<SaveWorldWPFClient.OrderLineService.OrderLine> CreateOrderLineAsync(SaveWorldWPFClient.OrderLineService.OrderLine newOrderLine) {
            return base.Channel.CreateOrderLineAsync(newOrderLine);
        }
        
        public int RemoveOrderLineAndReturnStock(int idToRemoveOrderLine) {
            return base.Channel.RemoveOrderLineAndReturnStock(idToRemoveOrderLine);
        }
        
        public System.Threading.Tasks.Task<int> RemoveOrderLineAndReturnStockAsync(int idToRemoveOrderLine) {
            return base.Channel.RemoveOrderLineAndReturnStockAsync(idToRemoveOrderLine);
        }
        
        public void UpdateOrderLine(SaveWorldWPFClient.OrderLineService.OrderLine orderLine) {
            base.Channel.UpdateOrderLine(orderLine);
        }
        
        public System.Threading.Tasks.Task UpdateOrderLineAsync(SaveWorldWPFClient.OrderLineService.OrderLine orderLine) {
            return base.Channel.UpdateOrderLineAsync(orderLine);
        }
    }
}
