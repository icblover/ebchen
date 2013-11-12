using System;
namespace ZCJ.Model
{
	/// <summary>
	/// ManagerAuthority:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class ManagerAuthority 
	{
		public ManagerAuthority()
		{}
		#region Model
		private int _id;
		private int _managerid;
		private int _managerroleid;
		private string _remark;
		private DateTime? _createdate;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 管理员id
		/// </summary>
		public int ManagerId
		{
			set{ _managerid=value;}
			get{return _managerid;}
		}
		/// <summary>
		/// 角色id
		/// </summary>
		public int ManagerRoleId
		{
			set{ _managerroleid=value;}
			get{return _managerroleid;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		#endregion Model

	}
}

