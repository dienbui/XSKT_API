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

namespace XSKTDB
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="XSKT")]
	public partial class XSKTDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertLocationPrize(LocationPrize instance);
    partial void UpdateLocationPrize(LocationPrize instance);
    partial void DeleteLocationPrize(LocationPrize instance);
    partial void InsertPrize(Prize instance);
    partial void UpdatePrize(Prize instance);
    partial void DeletePrize(Prize instance);
    partial void InsertPrizeDetail(PrizeDetail instance);
    partial void UpdatePrizeDetail(PrizeDetail instance);
    partial void DeletePrizeDetail(PrizeDetail instance);
    #endregion
		
		public XSKTDBDataContext() : 
				base(global::XSKTDB.Properties.Settings.Default.XSKTConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public XSKTDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public XSKTDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public XSKTDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public XSKTDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<LocationPrize> LocationPrizes
		{
			get
			{
				return this.GetTable<LocationPrize>();
			}
		}
		
		public System.Data.Linq.Table<Prize> Prizes
		{
			get
			{
				return this.GetTable<Prize>();
			}
		}
		
		public System.Data.Linq.Table<PrizeDetail> PrizeDetails
		{
			get
			{
				return this.GetTable<PrizeDetail>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LocationPrizes")]
	public partial class LocationPrize : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Name;
		
		private EntitySet<PrizeDetail> _PrizeDetails;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public LocationPrize()
		{
			this._PrizeDetails = new EntitySet<PrizeDetail>(new Action<PrizeDetail>(this.attach_PrizeDetails), new Action<PrizeDetail>(this.detach_PrizeDetails));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(MAX)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LocationPrize_PrizeDetail", Storage="_PrizeDetails", ThisKey="ID", OtherKey="LoctionPrizeId")]
		public EntitySet<PrizeDetail> PrizeDetails
		{
			get
			{
				return this._PrizeDetails;
			}
			set
			{
				this._PrizeDetails.Assign(value);
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
		
		private void attach_PrizeDetails(PrizeDetail entity)
		{
			this.SendPropertyChanging();
			entity.LocationPrize = this;
		}
		
		private void detach_PrizeDetails(PrizeDetail entity)
		{
			this.SendPropertyChanging();
			entity.LocationPrize = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Prizes")]
	public partial class Prize : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _FirstPrize;
		
		private string _SecondPrize;
		
		private string _ThirdPrize;
		
		private string _FourthPrize;
		
		private string _FifthPrize;
		
		private string _SixthPrize;
		
		private string _SeventhPrize;
		
		private string _SpecialPrize;
		
		private EntitySet<PrizeDetail> _PrizeDetails;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnFirstPrizeChanging(string value);
    partial void OnFirstPrizeChanged();
    partial void OnSecondPrizeChanging(string value);
    partial void OnSecondPrizeChanged();
    partial void OnThirdPrizeChanging(string value);
    partial void OnThirdPrizeChanged();
    partial void OnFourthPrizeChanging(string value);
    partial void OnFourthPrizeChanged();
    partial void OnFifthPrizeChanging(string value);
    partial void OnFifthPrizeChanged();
    partial void OnSixthPrizeChanging(string value);
    partial void OnSixthPrizeChanged();
    partial void OnSeventhPrizeChanging(string value);
    partial void OnSeventhPrizeChanged();
    partial void OnSpecialPrizeChanging(string value);
    partial void OnSpecialPrizeChanged();
    #endregion
		
		public Prize()
		{
			this._PrizeDetails = new EntitySet<PrizeDetail>(new Action<PrizeDetail>(this.attach_PrizeDetails), new Action<PrizeDetail>(this.detach_PrizeDetails));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstPrize", DbType="NVarChar(MAX)")]
		public string FirstPrize
		{
			get
			{
				return this._FirstPrize;
			}
			set
			{
				if ((this._FirstPrize != value))
				{
					this.OnFirstPrizeChanging(value);
					this.SendPropertyChanging();
					this._FirstPrize = value;
					this.SendPropertyChanged("FirstPrize");
					this.OnFirstPrizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SecondPrize", DbType="NVarChar(MAX)")]
		public string SecondPrize
		{
			get
			{
				return this._SecondPrize;
			}
			set
			{
				if ((this._SecondPrize != value))
				{
					this.OnSecondPrizeChanging(value);
					this.SendPropertyChanging();
					this._SecondPrize = value;
					this.SendPropertyChanged("SecondPrize");
					this.OnSecondPrizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThirdPrize", DbType="NVarChar(MAX)")]
		public string ThirdPrize
		{
			get
			{
				return this._ThirdPrize;
			}
			set
			{
				if ((this._ThirdPrize != value))
				{
					this.OnThirdPrizeChanging(value);
					this.SendPropertyChanging();
					this._ThirdPrize = value;
					this.SendPropertyChanged("ThirdPrize");
					this.OnThirdPrizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FourthPrize", DbType="NVarChar(MAX)")]
		public string FourthPrize
		{
			get
			{
				return this._FourthPrize;
			}
			set
			{
				if ((this._FourthPrize != value))
				{
					this.OnFourthPrizeChanging(value);
					this.SendPropertyChanging();
					this._FourthPrize = value;
					this.SendPropertyChanged("FourthPrize");
					this.OnFourthPrizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FifthPrize", DbType="NVarChar(MAX)")]
		public string FifthPrize
		{
			get
			{
				return this._FifthPrize;
			}
			set
			{
				if ((this._FifthPrize != value))
				{
					this.OnFifthPrizeChanging(value);
					this.SendPropertyChanging();
					this._FifthPrize = value;
					this.SendPropertyChanged("FifthPrize");
					this.OnFifthPrizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SixthPrize", DbType="NVarChar(MAX)")]
		public string SixthPrize
		{
			get
			{
				return this._SixthPrize;
			}
			set
			{
				if ((this._SixthPrize != value))
				{
					this.OnSixthPrizeChanging(value);
					this.SendPropertyChanging();
					this._SixthPrize = value;
					this.SendPropertyChanged("SixthPrize");
					this.OnSixthPrizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SeventhPrize", DbType="NVarChar(MAX)")]
		public string SeventhPrize
		{
			get
			{
				return this._SeventhPrize;
			}
			set
			{
				if ((this._SeventhPrize != value))
				{
					this.OnSeventhPrizeChanging(value);
					this.SendPropertyChanging();
					this._SeventhPrize = value;
					this.SendPropertyChanged("SeventhPrize");
					this.OnSeventhPrizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SpecialPrize", DbType="NVarChar(MAX)")]
		public string SpecialPrize
		{
			get
			{
				return this._SpecialPrize;
			}
			set
			{
				if ((this._SpecialPrize != value))
				{
					this.OnSpecialPrizeChanging(value);
					this.SendPropertyChanging();
					this._SpecialPrize = value;
					this.SendPropertyChanged("SpecialPrize");
					this.OnSpecialPrizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Prize_PrizeDetail", Storage="_PrizeDetails", ThisKey="ID", OtherKey="PrizeId")]
		public EntitySet<PrizeDetail> PrizeDetails
		{
			get
			{
				return this._PrizeDetails;
			}
			set
			{
				this._PrizeDetails.Assign(value);
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
		
		private void attach_PrizeDetails(PrizeDetail entity)
		{
			this.SendPropertyChanging();
			entity.Prize = this;
		}
		
		private void detach_PrizeDetails(PrizeDetail entity)
		{
			this.SendPropertyChanging();
			entity.Prize = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PrizeDetails")]
	public partial class PrizeDetail : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private int _PrizeId;
		
		private int _LoctionPrizeId;
		
		private System.Nullable<System.DateTime> _DatePrize;
		
		private EntityRef<LocationPrize> _LocationPrize;
		
		private EntityRef<Prize> _Prize;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnPrizeIdChanging(int value);
    partial void OnPrizeIdChanged();
    partial void OnLoctionPrizeIdChanging(int value);
    partial void OnLoctionPrizeIdChanged();
    partial void OnDatePrizeChanging(System.Nullable<System.DateTime> value);
    partial void OnDatePrizeChanged();
    #endregion
		
		public PrizeDetail()
		{
			this._LocationPrize = default(EntityRef<LocationPrize>);
			this._Prize = default(EntityRef<Prize>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrizeId", DbType="Int NOT NULL")]
		public int PrizeId
		{
			get
			{
				return this._PrizeId;
			}
			set
			{
				if ((this._PrizeId != value))
				{
					if (this._Prize.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPrizeIdChanging(value);
					this.SendPropertyChanging();
					this._PrizeId = value;
					this.SendPropertyChanged("PrizeId");
					this.OnPrizeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LoctionPrizeId", DbType="Int NOT NULL")]
		public int LoctionPrizeId
		{
			get
			{
				return this._LoctionPrizeId;
			}
			set
			{
				if ((this._LoctionPrizeId != value))
				{
					if (this._LocationPrize.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnLoctionPrizeIdChanging(value);
					this.SendPropertyChanging();
					this._LoctionPrizeId = value;
					this.SendPropertyChanged("LoctionPrizeId");
					this.OnLoctionPrizeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DatePrize", DbType="DateTime")]
		public System.Nullable<System.DateTime> DatePrize
		{
			get
			{
				return this._DatePrize;
			}
			set
			{
				if ((this._DatePrize != value))
				{
					this.OnDatePrizeChanging(value);
					this.SendPropertyChanging();
					this._DatePrize = value;
					this.SendPropertyChanged("DatePrize");
					this.OnDatePrizeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LocationPrize_PrizeDetail", Storage="_LocationPrize", ThisKey="LoctionPrizeId", OtherKey="ID", IsForeignKey=true)]
		public LocationPrize LocationPrize
		{
			get
			{
				return this._LocationPrize.Entity;
			}
			set
			{
				LocationPrize previousValue = this._LocationPrize.Entity;
				if (((previousValue != value) 
							|| (this._LocationPrize.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._LocationPrize.Entity = null;
						previousValue.PrizeDetails.Remove(this);
					}
					this._LocationPrize.Entity = value;
					if ((value != null))
					{
						value.PrizeDetails.Add(this);
						this._LoctionPrizeId = value.ID;
					}
					else
					{
						this._LoctionPrizeId = default(int);
					}
					this.SendPropertyChanged("LocationPrize");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Prize_PrizeDetail", Storage="_Prize", ThisKey="PrizeId", OtherKey="ID", IsForeignKey=true)]
		public Prize Prize
		{
			get
			{
				return this._Prize.Entity;
			}
			set
			{
				Prize previousValue = this._Prize.Entity;
				if (((previousValue != value) 
							|| (this._Prize.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Prize.Entity = null;
						previousValue.PrizeDetails.Remove(this);
					}
					this._Prize.Entity = value;
					if ((value != null))
					{
						value.PrizeDetails.Add(this);
						this._PrizeId = value.ID;
					}
					else
					{
						this._PrizeId = default(int);
					}
					this.SendPropertyChanged("Prize");
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
