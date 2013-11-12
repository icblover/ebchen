using System;
using System.Reflection;
using System.Configuration;
using ZCJ.IDAL;

namespace ZCJ.DALFactory
{
    /// <summary>
    /// Abstract Factory pattern to create the DAL。
    /// 如果在这里创建对象报错，请检查web.config里是否修改了<add key="DAL" value="Maticsoft.SQLServerDAL" />。
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DAL"];
        public DataAccess()
        { }

        #region CreateObject

        //不使用缓存
        private static object CreateObjectNoCache(string AssemblyPath, string classNamespace)
        {
            try
            {
                object objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);
                return objType;
            }
            catch//(System.Exception ex)
            {
                //string str=ex.Message;// 记录错误日志
                return null;
            }

        }
        //使用缓存
        private static object CreateObject(string AssemblyPath, string classNamespace)
        {
            //object objType = DataCache.GetCache(classNamespace);
            //if (objType == null)
            //{
            //    try
            //    {
            //        objType = Assembly.Load(AssemblyPath).CreateInstance(classNamespace);					
            //        DataCache.SetCache(classNamespace, objType);// 写入缓存
            //    }
            //    catch//(System.Exception ex)
            //    {
            //        //string str=ex.Message;// 记录错误日志
            //    }
            //}
            //return objType;
            return null;
        }
        #endregion

        #region 泛型生成
        ///// <summary>
        ///// 创建数据层接口。
        ///// </summary>
        //public static t Create(string ClassName)
        //{

        //    string ClassNamespace = AssemblyPath +"."+ ClassName;
        //    object objType = CreateObject(AssemblyPath, ClassNamespace);
        //    return (t)objType;
        //}
        #endregion

        #region CreateSysManage
        //public static ZCJ.IDAL.ISysManage CreateSysManage()
        //{
        //    //方式1			
        //    //return (ZCJ.IDAL.ISysManage)Assembly.Load(AssemblyPath).CreateInstance(AssemblyPath+".SysManage");

        //    //方式2 			
        //    string classNamespace = AssemblyPath+".SysManage";	
        //    object objType=CreateObject(AssemblyPath,classNamespace);
        //    return (ZCJ.IDAL.ISysManage)objType;		
        //}
        #endregion


        /// <summary>
        /// 创建ArticleDAL数据层接口。
        /// </summary>
        public static ZCJ.IDAL.IArticleDAL CreateArticleDAL()
        {

            string ClassNamespace = AssemblyPath + ".ArticleDAL";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (ZCJ.IDAL.IArticleDAL)objType;
        }


        /// <summary>
        /// 创建ArticleClassDAL数据层接口。
        /// </summary>
        public static ZCJ.IDAL.IArticleClassDAL CreateArticleClassDAL()
        {
            string ClassNamespace = AssemblyPath + ".ArticleClassDAL";
            object objType = CreateObjectNoCache(AssemblyPath, ClassNamespace);
            return (ZCJ.IDAL.IArticleClassDAL)objType;
        }


        /// <summary>
        /// 创建ArticleDetailDAL数据层接口。
        /// </summary>
        public static ZCJ.IDAL.IArticleDetailDAL CreateArticleDetailDAL()
        {
            string ClassNamespace = AssemblyPath + ".ArticleDetailDAL";
            object objType = CreateObjectNoCache(AssemblyPath, ClassNamespace);
            return (ZCJ.IDAL.IArticleDetailDAL)objType;
        }


        /// <summary>
        /// 创建BannersDAL数据层接口。
        /// </summary>
        public static ZCJ.IDAL.IBannersDAL CreateBannersDAL()
        {

            string ClassNamespace = AssemblyPath + ".BannersDAL";
            object objType = CreateObjectNoCache(AssemblyPath, ClassNamespace);
            return (ZCJ.IDAL.IBannersDAL)objType;
        }


        /// <summary>
        /// 创建FriendLinkDAL数据层接口。
        /// </summary>
        public static ZCJ.IDAL.IFriendLinkDAL CreateFriendLinkDAL()
        {

            string ClassNamespace = AssemblyPath + ".FriendLinkDAL";
            object objType = CreateObjectNoCache(AssemblyPath, ClassNamespace);
            return (ZCJ.IDAL.IFriendLinkDAL)objType;
        }


        /// <summary>
        /// 创建ManagerAuthorityDAL数据层接口。
        /// </summary>
        public static ZCJ.IDAL.IManagerAuthorityDAL CreateManagerAuthorityDAL()
        {

            string ClassNamespace = AssemblyPath + ".ManagerAuthorityDAL";
            object objType = CreateObjectNoCache(AssemblyPath, ClassNamespace);
            return (ZCJ.IDAL.IManagerAuthorityDAL)objType;
        }


        /// <summary>
        /// 创建ManagerRoleDAL数据层接口。
        /// </summary>
        public static ZCJ.IDAL.IManagerRoleDAL CreateManagerRoleDAL()
        {

            string ClassNamespace = AssemblyPath + ".ManagerRoleDAL";
            object objType = CreateObjectNoCache(AssemblyPath, ClassNamespace);
            return (ZCJ.IDAL.IManagerRoleDAL)objType;
        }


        /// <summary>
        /// 创建SiteBaseInfoDAL数据层接口。
        /// </summary>
        public static ZCJ.IDAL.ISiteBaseInfoDAL CreateSiteBaseInfoDAL()
        {

            string ClassNamespace = AssemblyPath + ".SiteBaseInfoDAL";
            object objType = CreateObjectNoCache(AssemblyPath, ClassNamespace);
            return (ZCJ.IDAL.ISiteBaseInfoDAL)objType;
        }


        /// <summary>
        /// 创建SiteManagerDAL数据层接口。
        /// </summary>
        public static ZCJ.IDAL.ISiteManagerDAL CreateSiteManagerDAL()
        {

            string ClassNamespace = AssemblyPath + ".SiteManagerDAL";
            object objType = CreateObjectNoCache(AssemblyPath, ClassNamespace);
            return (ZCJ.IDAL.ISiteManagerDAL)objType;
        }


        /// <summary>
        /// 创建SiteModuleDAL数据层接口。
        /// </summary>
        public static ZCJ.IDAL.ISiteModuleDAL CreateSiteModuleDAL()
        {
            string ClassNamespace = AssemblyPath + ".SiteModuleDAL";
            object objType = CreateObjectNoCache(AssemblyPath, ClassNamespace);
            return (ZCJ.IDAL.ISiteModuleDAL)objType;
        }


        /// <summary> 网站导航栏目 </summary>
        /// <returns></returns>
        public static ZCJ.IDAL.IColumnNavigationDAL CreateNavigationDAL()
        {
            string classNameSpace = AssemblyPath + ".ColumnNavigationDAL";
            return (ZCJ.IDAL.IColumnNavigationDAL) Assembly.Load(AssemblyPath).CreateInstance(classNameSpace, true);
        }

        /// <summary> 协会信息 </summary>
        /// <returns></returns>
        public static ZCJ.IDAL.IAssociationDAL CreateAssociationDAL()
        {
            string classNameSpace = AssemblyPath + ".AssociationDAL";
            return (ZCJ.IDAL.IAssociationDAL) Assembly.Load(AssemblyPath).CreateInstance(classNameSpace);
        }

        /// <summary> 网站参数 </summary>
        /// <returns></returns>
        public static ZCJ.IDAL.ISiteParameterDAL CreateSiteParameterDAL()
        {
            string classNameSpace = AssemblyPath + ".SiteParameterDAL";
            return (ZCJ.IDAL.ISiteParameterDAL) Assembly.Load(AssemblyPath).CreateInstance(classNameSpace);
        }
        /// <summary> 文章信息 </summary>
        /// <returns></returns>
        public static ZCJ.IDAL.IArticleInfoDAL CreateArticleInfoDAL()
        {
            string classNameSpace = AssemblyPath + ".ArticleInfoDAL";
            return (ZCJ.IDAL.IArticleInfoDAL) Assembly.Load(AssemblyPath).CreateInstance(classNameSpace);
        }

        /// <summary> 视频分类 </summary>
        public static ZCJ.IDAL.IVideoClassDAL CreateVideoClassDAL()
        {
            string ClassNamespace = AssemblyPath + ".VideoClassDAL";
            object objType = CreateObjectNoCache(AssemblyPath, ClassNamespace);
            return (ZCJ.IDAL.IVideoClassDAL)objType;
        }

        /// <summary> 创建VideoDAL视频接口 </summary>
        /// <returns></returns>
        public static ZCJ.IDAL.IVideoDAL CreateVideoDAL()
        {
            string classNameSpace = AssemblyPath + ".VideoDAL";
            return Assembly.Load(AssemblyPath).CreateInstance(classNameSpace) as IVideoDAL;
        }

        /// <summary> 评论 </summary>
        /// <returns></returns>
        public static ZCJ.IDAL.IArticleCommentDAL CreateArticleCommentDAL()
        {
            string classNameSpace = AssemblyPath + ".ArticleCommentDAL";
            return (ZCJ.IDAL.IArticleCommentDAL) Assembly.Load(AssemblyPath).CreateInstance(classNameSpace);
        }

    }
}