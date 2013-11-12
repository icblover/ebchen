using System;
using System.ComponentModel.DataAnnotations;
namespace ZCJ.Model
{
    /// <summary>
    /// SiteManager:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SiteManager
    {
        public SiteManager()
        { }
        #region Model
        private int _id;
        private string _username;
        private string _password;
        private string _role;
        private bool _is_deleted = false;
        private DateTime? _createdate;

        [Display(Name = "编号")]
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "用户名")]
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "密码")]
        public string PassWord
        {
            set { _password = value; }
            get { return _password; }
        }

        [Compare("PassWord")]
        [Display(Name = "确认密码")]
        public string RePassWord { get; set; }

        [Required(ErrorMessage = "*必选")]
        [Display(Name = "角色")]
        public string Role
        {
            set { _role = value; }
            get { return _role; }
        }

        [Display(Name = "昵称")]
        public string NickName { get; set; }

        /// <summary>
        /// 是否删除, 0:正常,1:删除，默认值为0
        /// </summary>
        [Display(Name = "启用")]
        public bool Is_Deleted
        {
            set { _is_deleted = value; }
            get { return _is_deleted; }
        }

        [Display(Name = "添加时间")]
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }


        #endregion Model

    }
}

