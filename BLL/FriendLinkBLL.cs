using System;
using System.Data;
using System.Collections.Generic;
using System.Web.Mvc;
using ZCJ.Model;
using ZCJ.DALFactory;
using ZCJ.IDAL;
using System.Web;
namespace ZCJ.BLL
{
	/// <summary>
	/// FriendLinkBLL
	/// </summary>
	public partial class FriendLinkBLL
	{
		private static readonly IFriendLinkDAL dal=DataAccess.CreateFriendLinkDAL();
		public FriendLinkBLL()
		{}
		#region  BasicMethod

		/// <summary> 增加一条数据 </summary>
		public static int  Add(ZCJ.Model.FriendLink model)
		{
		    if (model.LinkLogo!="")
		    {
		        model.HasLogo = 1;
		    }
			return dal.Add(model);
		}

		/// <summary> 更新一条数据 </summary>
		public static bool Update(ZCJ.Model.FriendLink model)
		{
			return dal.Update(model);
		}

		/// <summary> 删除一条数据 </summary>
		public static bool Delete(int id)
		{

		    return dal.Delete(Utility.Utils.SafeInt32(id));
		}
		/// <summary> 删除一条数据 </summary>
		public static bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary> 得到一个对象实体 </summary>
		public static ZCJ.Model.FriendLink GetModel(int id)
		{
			
			return dal.GetModel(Utility.Utils.SafeInt32(id));
		}


		/// <summary> 获得数据列表 </summary>
        public static List<FriendLink> GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary> 获得前几行数据 </summary>
        public static List<FriendLink> GetList(int Top, string strWhere, string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		

		/// <summary> 获得数据列表 </summary>
        public static List<FriendLink> GetAllList()
		{
			return GetList("");
		}
        
		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary> 获得友情链接类型 </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetFriendLinkTypeList()
        {
            return Utility.Utils.DataReaderToSelect(dal.GetFriendLinkTypeList(), "id", "ParameterName");
        }

        /// <summary> 保存上传图片 </summary>
        /// <returns></returns>
        public static string UploadImg(HttpPostedFileBase upImage)
        {
            return Utility.Utils.UpLoadImage(upImage, "~/UploadFiles/FriendLinks/");
        }
		#endregion  ExtensionMethod
	}
}

