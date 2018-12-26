﻿//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------
using System;
using System.Linq;

using LinqToDB;
using LinqToDB.Mapping;

namespace DataModel
{
	/// <summary>
	/// Database       : SmartTestSql
	/// Data Source    : 47.98.242.55
	/// Server Version : 5.6.39-log
	/// </summary>
	public partial class SmartTSqlDB : LinqToDB.Data.DataConnection
	{
		public ITable<TAccount>            TAccounts            { get { return this.GetTable<TAccount>(); } }
		public ITable<TConfig>             TConfigs             { get { return this.GetTable<TConfig>(); } }
		public ITable<TFuncconfig>         TFuncconfigs         { get { return this.GetTable<TFuncconfig>(); } }
		public ITable<TGroupconfig>        TGroupconfigs        { get { return this.GetTable<TGroupconfig>(); } }
		public ITable<TProfilerightconfig> TProfilerightconfigs { get { return this.GetTable<TProfilerightconfig>(); } }
		public ITable<TSign>               TSigns               { get { return this.GetTable<TSign>(); } }
		public ITable<TZjstastic>          TZjstastics          { get { return this.GetTable<TZjstastic>(); } }

		public SmartTSqlDB()
		{
			InitDataContext();
		}

		public SmartTSqlDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
		}

		partial void InitDataContext();
	}

	[Table("T_Account")]
	public partial class TAccount
	{
		[PrimaryKey, Identity   ] public uint   Id        { get; set; } // int(10) unsigned
		[Column,     NotNull    ] public string PID       { get; set; } // varchar(50)
		[Column,        Nullable] public string WxOpenId  { get; set; } // varchar(255)
		[Column,        Nullable] public string WxUnionId { get; set; } // varchar(255)
	}

	[Table("T_Config")]
	public partial class TConfig
	{
		[PrimaryKey, Identity] public uint   Id    { get; set; } // int(11) unsigned
		[Column,     Nullable] public string Name  { get; set; } // varchar(255)
		[Column,     Nullable] public string Value { get; set; } // varchar(255)
	}

	[Table("T_FuncConfig")]
	public partial class TFuncconfig
	{
		[PrimaryKey, Identity] public uint   Id       { get; set; } // int(10) unsigned
		[Column,     NotNull ] public int    ParentId { get; set; } // int(10)
		[Column,     NotNull ] public string FuncName { get; set; } // varchar(255)
		[Column,     NotNull ] public bool   IsOpen   { get; set; } // tinyint(1)
	}

	[Table("T_GroupConfig")]
	public partial class TGroupconfig
	{
		[PrimaryKey, Identity] public uint Id { get; set; } // int(10) unsigned
	}

	[Table("T_ProfileRightConfig")]
	public partial class TProfilerightconfig
	{
		[PrimaryKey, Identity] public uint   Id     { get; set; } // int(10) unsigned
		[Column,     Nullable] public string Gid    { get; set; } // varchar(255)
		[Column,     Nullable] public string Pid    { get; set; } // varchar(255)
		[Column,     Nullable] public int?   FuncId { get; set; } // int(11)
		[Column,     Nullable] public ulong? IsOpen { get; set; } // bit(1)
	}

	[Table("T_Sign")]
	public partial class TSign
	{
		[PrimaryKey, Identity] public uint     Id       { get; set; } // int(10) unsigned
		[Column,     NotNull ] public string   Pid      { get; set; } // varchar(255)
		[Column,     NotNull ] public string   Gid      { get; set; } // varchar(255)
		[Column,     NotNull ] public DateTime LastSign { get; set; } // datetime
		[Column,     NotNull ] public string   SignGid  { get; set; } // varchar(255)
	}

	[Table("T_ZjStastic")]
	public partial class TZjstastic
	{
		[PrimaryKey, Identity] public uint      Id      { get; set; } // int(10) unsigned
		[Column,     Nullable] public string    Gid     { get; set; } // varchar(255)
		[Column,     Nullable] public string    Pid     { get; set; } // varchar(255)
		[Column,     Nullable] public int?      Score   { get; set; } // int(11)
		[Column,     Nullable] public int?      Rank    { get; set; } // int(11)
		[Column,     Nullable] public DateTime? KPITime { get; set; } // date
	}

	public static partial class TableExtensions
	{
		public static TAccount Find(this ITable<TAccount> table, uint Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static TConfig Find(this ITable<TConfig> table, uint Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static TFuncconfig Find(this ITable<TFuncconfig> table, uint Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static TGroupconfig Find(this ITable<TGroupconfig> table, uint Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static TProfilerightconfig Find(this ITable<TProfilerightconfig> table, uint Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static TSign Find(this ITable<TSign> table, uint Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}

		public static TZjstastic Find(this ITable<TZjstastic> table, uint Id)
		{
			return table.FirstOrDefault(t =>
				t.Id == Id);
		}
	}
}