using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Webdiyer.WebControls.Mvc;
using ZCJ.Model;
using ZCJ.IDAL;
using ZCJ.DALFactory;
using ZCJ.Utility;

namespace ZCJ.BLL
{
    public class VideoBLL
    {

        private static IVideoDAL dal = DataAccess.CreateVideoDAL();

        public static int Create(Video model)
        {
            model.VideoImage = VideoConvert.CatchImg(ConfigurationManager.AppSettings["VideoPath"] + model.VideoPath);
            model.VideoPath = ConfigurationManager.AppSettings["VideoPath"] + model.VideoPath;
            if (model.VideoImage.Length > 0)
            {
                return dal.Add(model);
            }
            return 0;
        }

        public static int Update(Video model)
        {
            if (string.IsNullOrEmpty(model.VideoImage))
            {
                model.VideoImage = VideoConvert.CatchImg(ConfigurationManager.AppSettings["VideoPath"] + model.VideoPath);
            }
            model.VideoPath = ConfigurationManager.AppSettings["VideoPath"] + model.VideoPath;
            return dal.Update(model);
        }

        public static bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public static Video GetModel(int id)
        {
            return dal.GetModel(id);
        }

        public static PagedList<Video> GetList(string where, int pageIndex)
        {
            return dal.GetList(where).ToPagedList(pageIndex, 20);
        }

        public static PagedList<Video> IndexNoQuery(int pageIndex)
        {
            return GetList("", pageIndex);
        }

        public static bool UploadVideo()
        {
            return true;
        }

        /// <summary> 检测文件是否存在 </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool ExistFile(string path)
        {
            string videoPath = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["VideoPath"]);
            if (Directory.Exists(videoPath))
            {
                if (File.Exists(videoPath + path))
                {
                    return true;
                }
                return false;
            }
            else
            {
                Directory.CreateDirectory(videoPath);
            }
            return false;
        }

        /// <summary> 二审权限判断 </summary>
        /// <param name="powerList"></param>
        /// <param name="articleState"></param>
        /// <returns></returns>
        public static bool HasSecondTrial(string powerList, string articleState)
        {
            if (powerList.Contains("46") && articleState.Contains("一"))
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
            if (powerList.Contains("46") && articleState.Contains("二"))
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
            if (powerlist.Contains("47") && (articlestate.Contains("一") || articlestate.Contains("二")))
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
            if (powerlist.Contains("47") && articlestate.Contains("三"))
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
            if (!powerlist.Contains("47") && !powerlist.Contains("46"))
            {
                return true;
            }
            return false;
        }

        public static bool SecondAudit(Video model, string firstAudit, string firstAuditReason)
        {
            if (Update(model) > 0)
            {
                return dal.SecondAudit(model.id, firstAudit, firstAuditReason);
            }
            return false;
        }

        public static bool ThirdAudit(Video model, string secondAudit, string secondAuditReason)
        {
            if (Update(model) > 0)
            {
                return dal.ThirdAudit(model.id, secondAudit, secondAuditReason);
            }
            return false;
        }
    }
}
