﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SaveWorldWPFClient.UserService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserB", Namespace="http://schemas.datacontract.org/2004/07/SaveWorldModel")]
    [System.SerializableAttribute()]
    public partial class UserB : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BankAccountIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TypeOfUserField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
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
        public string Address {
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
        public int BankAccountId {
            get {
                return this.BankAccountIdField;
            }
            set {
                if ((this.BankAccountIdField.Equals(value) != true)) {
                    this.BankAccountIdField = value;
                    this.RaisePropertyChanged("BankAccountId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone {
            get {
                return this.PhoneField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneField, value) != true)) {
                    this.PhoneField = value;
                    this.RaisePropertyChanged("Phone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int TypeOfUser {
            get {
                return this.TypeOfUserField;
            }
            set {
                if ((this.TypeOfUserField.Equals(value) != true)) {
                    this.TypeOfUserField = value;
                    this.RaisePropertyChanged("TypeOfUser");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserService.IUser")]
    public interface IUser {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/GetUser", ReplyAction="http://tempuri.org/IUser/GetUserResponse")]
        SaveWorldWPFClient.UserService.UserB GetUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/GetUser", ReplyAction="http://tempuri.org/IUser/GetUserResponse")]
        System.Threading.Tasks.Task<SaveWorldWPFClient.UserService.UserB> GetUserAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/CheckEmailIfExists", ReplyAction="http://tempuri.org/IUser/CheckEmailIfExistsResponse")]
        bool CheckEmailIfExists(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/CheckEmailIfExists", ReplyAction="http://tempuri.org/IUser/CheckEmailIfExistsResponse")]
        System.Threading.Tasks.Task<bool> CheckEmailIfExistsAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/GetUserByName", ReplyAction="http://tempuri.org/IUser/GetUserByNameResponse")]
        SaveWorldWPFClient.UserService.UserB GetUserByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/GetUserByName", ReplyAction="http://tempuri.org/IUser/GetUserByNameResponse")]
        System.Threading.Tasks.Task<SaveWorldWPFClient.UserService.UserB> GetUserByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/GetAllUsers", ReplyAction="http://tempuri.org/IUser/GetAllUsersResponse")]
        SaveWorldWPFClient.UserService.UserB[] GetAllUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/GetAllUsers", ReplyAction="http://tempuri.org/IUser/GetAllUsersResponse")]
        System.Threading.Tasks.Task<SaveWorldWPFClient.UserService.UserB[]> GetAllUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/CheckLogin", ReplyAction="http://tempuri.org/IUser/CheckLoginResponse")]
        SaveWorldWPFClient.UserService.UserB CheckLogin(string email, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/CheckLogin", ReplyAction="http://tempuri.org/IUser/CheckLoginResponse")]
        System.Threading.Tasks.Task<SaveWorldWPFClient.UserService.UserB> CheckLoginAsync(string email, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/CreateUser", ReplyAction="http://tempuri.org/IUser/CreateUserResponse")]
        void CreateUser(SaveWorldWPFClient.UserService.UserB newUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/CreateUser", ReplyAction="http://tempuri.org/IUser/CreateUserResponse")]
        System.Threading.Tasks.Task CreateUserAsync(SaveWorldWPFClient.UserService.UserB newUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/DeleteUser", ReplyAction="http://tempuri.org/IUser/DeleteUserResponse")]
        int DeleteUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/DeleteUser", ReplyAction="http://tempuri.org/IUser/DeleteUserResponse")]
        System.Threading.Tasks.Task<int> DeleteUserAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/GetUserIDByName", ReplyAction="http://tempuri.org/IUser/GetUserIDByNameResponse")]
        int GetUserIDByName(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/GetUserIDByName", ReplyAction="http://tempuri.org/IUser/GetUserIDByNameResponse")]
        System.Threading.Tasks.Task<int> GetUserIDByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/UpdateUser", ReplyAction="http://tempuri.org/IUser/UpdateUserResponse")]
        bool UpdateUser(SaveWorldWPFClient.UserService.UserB user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUser/UpdateUser", ReplyAction="http://tempuri.org/IUser/UpdateUserResponse")]
        System.Threading.Tasks.Task<bool> UpdateUserAsync(SaveWorldWPFClient.UserService.UserB user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserChannel : SaveWorldWPFClient.UserService.IUser, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserClient : System.ServiceModel.ClientBase<SaveWorldWPFClient.UserService.IUser>, SaveWorldWPFClient.UserService.IUser {
        
        public UserClient() {
        }
        
        public UserClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SaveWorldWPFClient.UserService.UserB GetUser(int id) {
            return base.Channel.GetUser(id);
        }
        
        public System.Threading.Tasks.Task<SaveWorldWPFClient.UserService.UserB> GetUserAsync(int id) {
            return base.Channel.GetUserAsync(id);
        }
        
        public bool CheckEmailIfExists(string email) {
            return base.Channel.CheckEmailIfExists(email);
        }
        
        public System.Threading.Tasks.Task<bool> CheckEmailIfExistsAsync(string email) {
            return base.Channel.CheckEmailIfExistsAsync(email);
        }
        
        public SaveWorldWPFClient.UserService.UserB GetUserByName(string name) {
            return base.Channel.GetUserByName(name);
        }
        
        public System.Threading.Tasks.Task<SaveWorldWPFClient.UserService.UserB> GetUserByNameAsync(string name) {
            return base.Channel.GetUserByNameAsync(name);
        }
        
        public SaveWorldWPFClient.UserService.UserB[] GetAllUsers() {
            return base.Channel.GetAllUsers();
        }
        
        public System.Threading.Tasks.Task<SaveWorldWPFClient.UserService.UserB[]> GetAllUsersAsync() {
            return base.Channel.GetAllUsersAsync();
        }
        
        public SaveWorldWPFClient.UserService.UserB CheckLogin(string email, string pass) {
            return base.Channel.CheckLogin(email, pass);
        }
        
        public System.Threading.Tasks.Task<SaveWorldWPFClient.UserService.UserB> CheckLoginAsync(string email, string pass) {
            return base.Channel.CheckLoginAsync(email, pass);
        }
        
        public void CreateUser(SaveWorldWPFClient.UserService.UserB newUser) {
            base.Channel.CreateUser(newUser);
        }
        
        public System.Threading.Tasks.Task CreateUserAsync(SaveWorldWPFClient.UserService.UserB newUser) {
            return base.Channel.CreateUserAsync(newUser);
        }
        
        public int DeleteUser(int id) {
            return base.Channel.DeleteUser(id);
        }
        
        public System.Threading.Tasks.Task<int> DeleteUserAsync(int id) {
            return base.Channel.DeleteUserAsync(id);
        }
        
        public int GetUserIDByName(string name) {
            return base.Channel.GetUserIDByName(name);
        }
        
        public System.Threading.Tasks.Task<int> GetUserIDByNameAsync(string name) {
            return base.Channel.GetUserIDByNameAsync(name);
        }
        
        public bool UpdateUser(SaveWorldWPFClient.UserService.UserB user) {
            return base.Channel.UpdateUser(user);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateUserAsync(SaveWorldWPFClient.UserService.UserB user) {
            return base.Channel.UpdateUserAsync(user);
        }
    }
}
