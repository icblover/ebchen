using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ZCJ.Model;
using ZCJ.IDAL;
using ZCJ.DALFactory;
using Webdiyer.WebControls.Mvc;
using ZCJ.Utility;
namespace ZCJ.BLL
{
    public class ArticleInfoBLL
    {
        private static readonly IArticleInfoDAL dal = DataAccess.CreateArticleInfoDAL();

        /// <summary> 新增文章 </summary>
        /// <param name="model"></param>
        /// <param name="shuiyin"></param>
        /// <returns></returns>
        public static int Create(ArticleInfo model, bool shuiyin)
        {
            if (model.HasImage)
            {
                model.SmallImgPath = ImageHelper.GetImgUrl(model.ArticleContent);
            }

            if (shuiyin && !string.IsNullOrEmpty(model.SmallImgPath))
            {
                AddWaterMark(model.ArticleContent);
            }

            return dal.Create(model);
        }

        public static int Update(ArticleInfo model, bool shuiyin)
        {
            if (model.HasImage)
            {
                model.SmallImgPath = ImageHelper.GetImgUrl(model.ArticleContent);
            }

            if (shuiyin && !string.IsNullOrEmpty(model.SmallImgPath))
            {
                AddWaterMark(model.ArticleContent);
            }
            return dal.Update(model);
        }

        public static bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public static ArticleInfo ToTotalModel(ArticleIntro intro, ArticleDetail detail)
        {
            return new ArticleInfo
                {
                    ArticleClassName = intro.ArticleClassName,
                    ArticleContent = detail.ArticleContent,
                    ArticleFrom = detail.ArticleFrom,
                    ArticleId = intro.id,
                    ArticleIntroduce = detail.ArticleIntroduce,

                    AttributionArea = intro.AttributionArea,
                    Author = detail.Author,
                    ClassId = intro.ClassId,
                    ClickInt = intro.ClickInt,
                    CreateDate = intro.CreateDate,

                    FirstAudit = intro.FirstAudit,
                    FirstAuditDate = intro.FirstAuditDate,
                    FirstAuditReason = intro.FirstAuditReason,
                    HasImage = intro.HasImage,
                    HotFlag = intro.HotFlag,

                    id = intro.id,
                    Keyword = detail.Keyword,
                    SecondAuditReason = intro.SecondAuditReason,
                    SecondAudit = intro.SecondAudit,
                    SecondAuditDate = intro.SecondAuditDate,

                    SmallImgPath = intro.SmallImgPath,
                    Title = intro.Title
                };
        }

        public static ArticleInfo GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public static List<ArticleInfo> GetList(string where)
        {
            return dal.GetList(where).ToPagedList(1, 20);
        }

        /// <summary> 打水印，匹配新闻内容图片，打水印后删除原图    </summary>
        /// <param name="Content">新闻内容</param>
        /// <returns></returns>
        public static void AddWaterMark(string Content)
        {
            string waterText = "WWW.ZJZCJ.COM";
            MatchCollection collection = ImageHelper.GetImgUrlGroup(Content);

            if (collection.Count > 0)
            {
                for (int i = 0; i < collection.Count; i++)
                {
                    string imageUrl = collection[i].Groups["url"].Value.Replace("\"", "");
                    ImageHelper.AddWater(waterText, AppDomain.CurrentDomain.BaseDirectory + imageUrl);

                }
            }
        }

        /// <summary> Index Action </summary>
        /// <returns></returns>
        public static PagedList<ArticleInfo> Index(int pageIndex)
        {
            return dal.GetList("").ToPagedList(pageIndex, 20);
        }
        public static PagedList<ArticleInfo> Index(int pageIndex, string classId, string keyword)
        {
            StringBuilder str = new StringBuilder();
            if (classId != "0")
            {
                str.Append(" AND ClassId=");
                str.Append(Utils.SafeSQL(classId));
            }
            if (keyword.Trim().Length > 0)
            {
                str.Append("AND Title LIKE '%");
                str.Append(keyword.Trim());
                str.Append("%'");
            }
            return dal.GetList(str.ToString()).ToPagedList(pageIndex, 20);
        }

        /// <summary> 二审权限判断 </summary>
        /// <param name="powerList"></param>
        /// <param name="articleState"></param>
        /// <returns></returns>
        public static bool HasSecondTrial(string powerList, string articleState)
        {
            if (powerList.Contains("17") && articleState.Contains("一"))
            {
                return true;
            }
            return false;
        }

        /// <summary> 二审权限判断 </summary>
        /// <param name="powerList"></param>
        /// <param name="articleState"></param>
        /// <returns></returns>
        public static bool SecondEndTrial(string powerList, string articleState)
        {
            if (powerList.Contains("17") && articleState.Contains("二"))
            {
                return true;
            }
            return false;
        }

        /// <summary> 三审权限判断 </summary>
        /// <param name="powerlist"></param>
        /// <param name="articlestate"></param>
        /// <returns></returns>
        public static bool HasThirdTrail(string powerlist, string articlestate)
        {
            if (powerlist.Contains("18") && (articlestate.Contains("一") || articlestate.Contains("二")))
            {
                return true;
            }
            return false;
        }

        /// <summary> 三审结束判断 </summary>
        /// <param name="powerlist"></param>
        /// <param name="articlestate"></param>
        /// <returns></returns>
        public static bool ThirdEndAudit(string powerlist, string articlestate)
        {
            if (powerlist.Contains("18") && articlestate.Contains("三"))
            {
                return true;
            }
            return false;
        }

        /// <summary> 一审权限判断 </summary>
        /// <param name="powerlist"></param>
        /// <returns></returns>
        public static bool AuthorAudit(string powerlist)
        {
            if (!powerlist.Contains("18") && !powerlist.Contains("17"))
            {
                return true;
            }
            return false;
        }

        /// <summary> 二审处理逻辑,数据库中FirstAudit字段就代表二审 </summary>
        /// <param name="model"></param>
        /// <param name="shuiyin"></param>
        /// <returns>修改FirstAudit字段值</returns>
        public static bool SecondAudit(ArticleInfo model, bool shuiyin,string firstAudit, string firstAuditReason)
        {
            if (Update(model, shuiyin)>0)
            {
                return dal.SecondAudit(model.id, firstAudit, firstAuditReason);
            }
            return false;
        }

        public static bool ThirdAudit(ArticleInfo model, bool shuiyin, string secondAudit, string secondAuditReason)
        {
            if (Update(model,shuiyin)>0)
            {
                return dal.ThirdAudit(model.id, secondAudit, secondAuditReason);
            }
            return false;
        }
    }


}
