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

namespace WebApiDemo
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
    using Newtonsoft.Json;

    [global::System.Data.Linq.Mapping.DatabaseAttribute(Name="videoclubevc")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCategoria(Categoria instance);
    partial void UpdateCategoria(Categoria instance);
    partial void DeleteCategoria(Categoria instance);
    partial void InsertFilme(Filme instance);
    partial void UpdateFilme(Filme instance);
    partial void DeleteFilme(Filme instance);
    #endregion
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Categoria> Categorias
		{
			get
			{
				return this.GetTable<Categoria>();
			}
		}
		
		public System.Data.Linq.Table<Filme> Filmes
		{
			get
			{
				return this.GetTable<Filme>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Categorias")]
	public partial class Categoria : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _Sigla;
		
		private string _Categoria1;
		
		private EntitySet<Filme> _Filmes;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnSiglaChanging(string value);
    partial void OnSiglaChanged();
    partial void OnCategoria1Changing(string value);
    partial void OnCategoria1Changed();
    #endregion
		
		public Categoria()
		{
			this._Filmes = new EntitySet<Filme>(new Action<Filme>(this.attach_Filmes), new Action<Filme>(this.detach_Filmes));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sigla", DbType="VarChar(5) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string Sigla
		{
			get
			{
				return this._Sigla;
			}
			set
			{
				if ((this._Sigla != value))
				{
					this.OnSiglaChanging(value);
					this.SendPropertyChanging();
					this._Sigla = value;
					this.SendPropertyChanged("Sigla");
					this.OnSiglaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Categoria", Storage="_Categoria1", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
        
        public string Categoria1
		{
			get
			{
				return this._Categoria1;
			}
			set
			{
				if ((this._Categoria1 != value))
				{
					this.OnCategoria1Changing(value);
					this.SendPropertyChanging();
					this._Categoria1 = value;
					this.SendPropertyChanged("Categoria1");
					this.OnCategoria1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Categoria_Filme", Storage="_Filmes", ThisKey="Sigla", OtherKey="Categoria")]
		[JsonIgnore]
		public EntitySet<Filme> Filmes
		{
			get
			{
				return this._Filmes;
			}
			set
			{
				this._Filmes.Assign(value);
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
		
		private void attach_Filmes(Filme entity)
		{
			this.SendPropertyChanging();
			entity.Categoria1 = this;
		}
		
		private void detach_Filmes(Filme entity)
		{
			this.SendPropertyChanging();
			entity.Categoria1 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Filmes")]
	public partial class Filme : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Titulo;
		
		private string _Categoria;
		
		private EntityRef<Categoria> _Categoria1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnTituloChanging(string value);
    partial void OnTituloChanged();
    partial void OnCategoriaChanging(string value);
    partial void OnCategoriaChanged();
    #endregion
		
		public Filme()
		{
			this._Categoria1 = default(EntityRef<Categoria>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Titulo", DbType="VarChar(250)")]
		public string Titulo
		{
			get
			{
				return this._Titulo;
			}
			set
			{
				if ((this._Titulo != value))
				{
					this.OnTituloChanging(value);
					this.SendPropertyChanging();
					this._Titulo = value;
					this.SendPropertyChanged("Titulo");
					this.OnTituloChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Categoria", DbType="VarChar(5)")]
		public string Categoria
		{
			get
			{
				return this._Categoria;
			}
			set
			{
				if ((this._Categoria != value))
				{
					if (this._Categoria1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCategoriaChanging(value);
					this.SendPropertyChanging();
					this._Categoria = value;
					this.SendPropertyChanged("Categoria");
					this.OnCategoriaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Categoria_Filme", Storage="_Categoria1", ThisKey="Categoria", OtherKey="Sigla", IsForeignKey=true)]

        [JsonIgnore]
        public Categoria Categoria1
		{
			get
			{
				return this._Categoria1.Entity;
			}
			set
			{
				Categoria previousValue = this._Categoria1.Entity;
				if (((previousValue != value) 
							|| (this._Categoria1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Categoria1.Entity = null;
						previousValue.Filmes.Remove(this);
					}
					this._Categoria1.Entity = value;
					if ((value != null))
					{
						value.Filmes.Add(this);
						this._Categoria = value.Sigla;
					}
					else
					{
						this._Categoria = default(string);
					}
					this.SendPropertyChanged("Categoria1");
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
