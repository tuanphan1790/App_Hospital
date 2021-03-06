﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BVPS.DB.DBContext
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="htss")]
	public partial class LogHisSystemDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertdtb_log(dtb_log instance);
    partial void Updatedtb_log(dtb_log instance);
    partial void Deletedtb_log(dtb_log instance);
    #endregion
		
		public LogHisSystemDataContext() : 
				base(global::BVPS.DB.Properties.Settings.Default.htssConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LogHisSystemDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LogHisSystemDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LogHisSystemDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LogHisSystemDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<dtb_log> dtb_logs
		{
			get
			{
				return this.GetTable<dtb_log>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.dtb_log")]
	public partial class dtb_log : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _username;
		
		private string _action;
		
		private System.Nullable<System.DateTime> _create_date;
		
		private string _controller;
		
		private string _note;
		
		private string _type;
		
		private string _ip_address;
		
		private string _desktop_name;
		
		private int _user_id;
		
		private int _created_at;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnusernameChanging(string value);
    partial void OnusernameChanged();
    partial void OnactionChanging(string value);
    partial void OnactionChanged();
    partial void Oncreate_dateChanging(System.Nullable<System.DateTime> value);
    partial void Oncreate_dateChanged();
    partial void OncontrollerChanging(string value);
    partial void OncontrollerChanged();
    partial void OnnoteChanging(string value);
    partial void OnnoteChanged();
    partial void OntypeChanging(string value);
    partial void OntypeChanged();
    partial void Onip_addressChanging(string value);
    partial void Onip_addressChanged();
    partial void Ondesktop_nameChanging(string value);
    partial void Ondesktop_nameChanged();
    partial void Onuser_idChanging(int value);
    partial void Onuser_idChanged();
    partial void Oncreated_atChanging(int value);
    partial void Oncreated_atChanged();
    #endregion
		
		public dtb_log()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_username", DbType="NVarChar(100)")]
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				if ((this._username != value))
				{
					this.OnusernameChanging(value);
					this.SendPropertyChanging();
					this._username = value;
					this.SendPropertyChanged("username");
					this.OnusernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_action", DbType="NVarChar(100)")]
		public string action
		{
			get
			{
				return this._action;
			}
			set
			{
				if ((this._action != value))
				{
					this.OnactionChanging(value);
					this.SendPropertyChanging();
					this._action = value;
					this.SendPropertyChanged("action");
					this.OnactionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_create_date", DbType="Date")]
		public System.Nullable<System.DateTime> create_date
		{
			get
			{
				return this._create_date;
			}
			set
			{
				if ((this._create_date != value))
				{
					this.Oncreate_dateChanging(value);
					this.SendPropertyChanging();
					this._create_date = value;
					this.SendPropertyChanged("create_date");
					this.Oncreate_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_controller", DbType="VarChar(50)")]
		public string controller
		{
			get
			{
				return this._controller;
			}
			set
			{
				if ((this._controller != value))
				{
					this.OncontrollerChanging(value);
					this.SendPropertyChanging();
					this._controller = value;
					this.SendPropertyChanged("controller");
					this.OncontrollerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_note", DbType="VarChar(300)")]
		public string note
		{
			get
			{
				return this._note;
			}
			set
			{
				if ((this._note != value))
				{
					this.OnnoteChanging(value);
					this.SendPropertyChanging();
					this._note = value;
					this.SendPropertyChanged("note");
					this.OnnoteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_type", DbType="VarChar(50)")]
		public string type
		{
			get
			{
				return this._type;
			}
			set
			{
				if ((this._type != value))
				{
					this.OntypeChanging(value);
					this.SendPropertyChanging();
					this._type = value;
					this.SendPropertyChanged("type");
					this.OntypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ip_address", DbType="VarChar(20)")]
		public string ip_address
		{
			get
			{
				return this._ip_address;
			}
			set
			{
				if ((this._ip_address != value))
				{
					this.Onip_addressChanging(value);
					this.SendPropertyChanging();
					this._ip_address = value;
					this.SendPropertyChanged("ip_address");
					this.Onip_addressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desktop_name", DbType="VarChar(50)")]
		public string desktop_name
		{
			get
			{
				return this._desktop_name;
			}
			set
			{
				if ((this._desktop_name != value))
				{
					this.Ondesktop_nameChanging(value);
					this.SendPropertyChanging();
					this._desktop_name = value;
					this.SendPropertyChanged("desktop_name");
					this.Ondesktop_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_user_id", DbType="Int NOT NULL")]
		public int user_id
		{
			get
			{
				return this._user_id;
			}
			set
			{
				if ((this._user_id != value))
				{
					this.Onuser_idChanging(value);
					this.SendPropertyChanging();
					this._user_id = value;
					this.SendPropertyChanged("user_id");
					this.Onuser_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_created_at", DbType="Int NOT NULL")]
		public int created_at
		{
			get
			{
				return this._created_at;
			}
			set
			{
				if ((this._created_at != value))
				{
					this.Oncreated_atChanging(value);
					this.SendPropertyChanging();
					this._created_at = value;
					this.SendPropertyChanged("created_at");
					this.Oncreated_atChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
