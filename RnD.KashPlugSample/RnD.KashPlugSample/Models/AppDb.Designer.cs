﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace RnD.KashPlugSample.Models
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class AppDbEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new AppDbEntities object using the connection string found in the 'AppDbEntities' section of the application configuration file.
        /// </summary>
        public AppDbEntities() : base("name=AppDbEntities", "AppDbEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new AppDbEntities object.
        /// </summary>
        public AppDbEntities(string connectionString) : base(connectionString, "AppDbEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new AppDbEntities object.
        /// </summary>
        public AppDbEntities(EntityConnection connection) : base(connection, "AppDbEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<TblApplication> TblApplications
        {
            get
            {
                if ((_TblApplications == null))
                {
                    _TblApplications = base.CreateObjectSet<TblApplication>("TblApplications");
                }
                return _TblApplications;
            }
        }
        private ObjectSet<TblApplication> _TblApplications;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<TblModule> TblModules
        {
            get
            {
                if ((_TblModules == null))
                {
                    _TblModules = base.CreateObjectSet<TblModule>("TblModules");
                }
                return _TblModules;
            }
        }
        private ObjectSet<TblModule> _TblModules;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<TblMenu> TblMenus
        {
            get
            {
                if ((_TblMenus == null))
                {
                    _TblMenus = base.CreateObjectSet<TblMenu>("TblMenus");
                }
                return _TblMenus;
            }
        }
        private ObjectSet<TblMenu> _TblMenus;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the TblApplications EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTblApplications(TblApplication tblApplication)
        {
            base.AddObject("TblApplications", tblApplication);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the TblModules EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTblModules(TblModule tblModule)
        {
            base.AddObject("TblModules", tblModule);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the TblMenus EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTblMenus(TblMenu tblMenu)
        {
            base.AddObject("TblMenus", tblMenu);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AppDbContext", Name="TblApplication")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class TblApplication : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new TblApplication object.
        /// </summary>
        /// <param name="applicationId">Initial value of the ApplicationId property.</param>
        /// <param name="applicationName">Initial value of the ApplicationName property.</param>
        public static TblApplication CreateTblApplication(global::System.Int32 applicationId, global::System.String applicationName)
        {
            TblApplication tblApplication = new TblApplication();
            tblApplication.ApplicationId = applicationId;
            tblApplication.ApplicationName = applicationName;
            return tblApplication;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ApplicationId
        {
            get
            {
                return _ApplicationId;
            }
            set
            {
                OnApplicationIdChanging(value);
                ReportPropertyChanging("ApplicationId");
                _ApplicationId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ApplicationId");
                OnApplicationIdChanged();
            }
        }
        private global::System.Int32 _ApplicationId;
        partial void OnApplicationIdChanging(global::System.Int32 value);
        partial void OnApplicationIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ApplicationName
        {
            get
            {
                return _ApplicationName;
            }
            set
            {
                if (_ApplicationName != value)
                {
                    OnApplicationNameChanging(value);
                    ReportPropertyChanging("ApplicationName");
                    _ApplicationName = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("ApplicationName");
                    OnApplicationNameChanged();
                }
            }
        }
        private global::System.String _ApplicationName;
        partial void OnApplicationNameChanging(global::System.String value);
        partial void OnApplicationNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ApplicationTitle
        {
            get
            {
                return _ApplicationTitle;
            }
            set
            {
                OnApplicationTitleChanging(value);
                ReportPropertyChanging("ApplicationTitle");
                _ApplicationTitle = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ApplicationTitle");
                OnApplicationTitleChanged();
            }
        }
        private global::System.String _ApplicationTitle;
        partial void OnApplicationTitleChanging(global::System.String value);
        partial void OnApplicationTitleChanged();

        #endregion

    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AppDbContext", Name="TblMenu")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class TblMenu : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new TblMenu object.
        /// </summary>
        /// <param name="menuId">Initial value of the MenuId property.</param>
        /// <param name="applicationId">Initial value of the ApplicationId property.</param>
        /// <param name="menuName">Initial value of the MenuName property.</param>
        /// <param name="menuCaption">Initial value of the MenuCaption property.</param>
        /// <param name="moduleId">Initial value of the ModuleId property.</param>
        public static TblMenu CreateTblMenu(global::System.Int32 menuId, global::System.Int32 applicationId, global::System.String menuName, global::System.String menuCaption, global::System.Int32 moduleId)
        {
            TblMenu tblMenu = new TblMenu();
            tblMenu.MenuId = menuId;
            tblMenu.ApplicationId = applicationId;
            tblMenu.MenuName = menuName;
            tblMenu.MenuCaption = menuCaption;
            tblMenu.ModuleId = moduleId;
            return tblMenu;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 MenuId
        {
            get
            {
                return _MenuId;
            }
            set
            {
                OnMenuIdChanging(value);
                ReportPropertyChanging("MenuId");
                _MenuId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("MenuId");
                OnMenuIdChanged();
            }
        }
        private global::System.Int32 _MenuId;
        partial void OnMenuIdChanging(global::System.Int32 value);
        partial void OnMenuIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ApplicationId
        {
            get
            {
                return _ApplicationId;
            }
            set
            {
                if (_ApplicationId != value)
                {
                    OnApplicationIdChanging(value);
                    ReportPropertyChanging("ApplicationId");
                    _ApplicationId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ApplicationId");
                    OnApplicationIdChanged();
                }
            }
        }
        private global::System.Int32 _ApplicationId;
        partial void OnApplicationIdChanging(global::System.Int32 value);
        partial void OnApplicationIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String MenuName
        {
            get
            {
                return _MenuName;
            }
            set
            {
                if (_MenuName != value)
                {
                    OnMenuNameChanging(value);
                    ReportPropertyChanging("MenuName");
                    _MenuName = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("MenuName");
                    OnMenuNameChanged();
                }
            }
        }
        private global::System.String _MenuName;
        partial void OnMenuNameChanging(global::System.String value);
        partial void OnMenuNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String MenuCaption
        {
            get
            {
                return _MenuCaption;
            }
            set
            {
                OnMenuCaptionChanging(value);
                ReportPropertyChanging("MenuCaption");
                _MenuCaption = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("MenuCaption");
                OnMenuCaptionChanged();
            }
        }
        private global::System.String _MenuCaption;
        partial void OnMenuCaptionChanging(global::System.String value);
        partial void OnMenuCaptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String MenuCaptionBng
        {
            get
            {
                return _MenuCaptionBng;
            }
            set
            {
                OnMenuCaptionBngChanging(value);
                ReportPropertyChanging("MenuCaptionBng");
                _MenuCaptionBng = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("MenuCaptionBng");
                OnMenuCaptionBngChanged();
            }
        }
        private global::System.String _MenuCaptionBng;
        partial void OnMenuCaptionBngChanging(global::System.String value);
        partial void OnMenuCaptionBngChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> ParentMenuId
        {
            get
            {
                return _ParentMenuId;
            }
            set
            {
                OnParentMenuIdChanging(value);
                ReportPropertyChanging("ParentMenuId");
                _ParentMenuId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ParentMenuId");
                OnParentMenuIdChanged();
            }
        }
        private Nullable<global::System.Int32> _ParentMenuId;
        partial void OnParentMenuIdChanging(Nullable<global::System.Int32> value);
        partial void OnParentMenuIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> SerialNo
        {
            get
            {
                return _SerialNo;
            }
            set
            {
                OnSerialNoChanging(value);
                ReportPropertyChanging("SerialNo");
                _SerialNo = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("SerialNo");
                OnSerialNoChanged();
            }
        }
        private Nullable<global::System.Int32> _SerialNo;
        partial void OnSerialNoChanging(Nullable<global::System.Int32> value);
        partial void OnSerialNoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.Byte[] MenuIcon
        {
            get
            {
                return StructuralObject.GetValidValue(_MenuIcon);
            }
            set
            {
                OnMenuIconChanging(value);
                ReportPropertyChanging("MenuIcon");
                _MenuIcon = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("MenuIcon");
                OnMenuIconChanged();
            }
        }
        private global::System.Byte[] _MenuIcon;
        partial void OnMenuIconChanging(global::System.Byte[] value);
        partial void OnMenuIconChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PageUrl
        {
            get
            {
                return _PageUrl;
            }
            set
            {
                OnPageUrlChanging(value);
                ReportPropertyChanging("PageUrl");
                _PageUrl = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PageUrl");
                OnPageUrlChanged();
            }
        }
        private global::System.String _PageUrl;
        partial void OnPageUrlChanging(global::System.String value);
        partial void OnPageUrlChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ModuleId
        {
            get
            {
                return _ModuleId;
            }
            set
            {
                if (_ModuleId != value)
                {
                    OnModuleIdChanging(value);
                    ReportPropertyChanging("ModuleId");
                    _ModuleId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ModuleId");
                    OnModuleIdChanged();
                }
            }
        }
        private global::System.Int32 _ModuleId;
        partial void OnModuleIdChanging(global::System.Int32 value);
        partial void OnModuleIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> OrderNo
        {
            get
            {
                return _OrderNo;
            }
            set
            {
                OnOrderNoChanging(value);
                ReportPropertyChanging("OrderNo");
                _OrderNo = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("OrderNo");
                OnOrderNoChanged();
            }
        }
        private Nullable<global::System.Int32> _OrderNo;
        partial void OnOrderNoChanging(Nullable<global::System.Int32> value);
        partial void OnOrderNoChanged();

        #endregion

    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AppDbContext", Name="TblModule")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class TblModule : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new TblModule object.
        /// </summary>
        /// <param name="moduleId">Initial value of the ModuleId property.</param>
        /// <param name="applicationId">Initial value of the ApplicationId property.</param>
        /// <param name="moduleName">Initial value of the ModuleName property.</param>
        public static TblModule CreateTblModule(global::System.Int32 moduleId, global::System.Int32 applicationId, global::System.String moduleName)
        {
            TblModule tblModule = new TblModule();
            tblModule.ModuleId = moduleId;
            tblModule.ApplicationId = applicationId;
            tblModule.ModuleName = moduleName;
            return tblModule;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ModuleId
        {
            get
            {
                return _ModuleId;
            }
            set
            {
                OnModuleIdChanging(value);
                ReportPropertyChanging("ModuleId");
                _ModuleId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ModuleId");
                OnModuleIdChanged();
            }
        }
        private global::System.Int32 _ModuleId;
        partial void OnModuleIdChanging(global::System.Int32 value);
        partial void OnModuleIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String ModuleTitle
        {
            get
            {
                return _ModuleTitle;
            }
            set
            {
                OnModuleTitleChanging(value);
                ReportPropertyChanging("ModuleTitle");
                _ModuleTitle = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("ModuleTitle");
                OnModuleTitleChanged();
            }
        }
        private global::System.String _ModuleTitle;
        partial void OnModuleTitleChanging(global::System.String value);
        partial void OnModuleTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ApplicationId
        {
            get
            {
                return _ApplicationId;
            }
            set
            {
                if (_ApplicationId != value)
                {
                    OnApplicationIdChanging(value);
                    ReportPropertyChanging("ApplicationId");
                    _ApplicationId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ApplicationId");
                    OnApplicationIdChanged();
                }
            }
        }
        private global::System.Int32 _ApplicationId;
        partial void OnApplicationIdChanging(global::System.Int32 value);
        partial void OnApplicationIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ModuleName
        {
            get
            {
                return _ModuleName;
            }
            set
            {
                if (_ModuleName != value)
                {
                    OnModuleNameChanging(value);
                    ReportPropertyChanging("ModuleName");
                    _ModuleName = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("ModuleName");
                    OnModuleNameChanged();
                }
            }
        }
        private global::System.String _ModuleName;
        partial void OnModuleNameChanging(global::System.String value);
        partial void OnModuleNameChanged();

        #endregion

    
    }

    #endregion

    
}