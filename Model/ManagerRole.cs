using System;
using System.ComponentModel.DataAnnotations;
namespace ZCJ.Model
{
    /// <summary>
    /// ManagerRole:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ManagerRole 
    {
        public ManagerRole()
        { }
        #region Model
        private int _id;
        private string _name;

        private DateTime? _createdate = DateTime.Now;
        
        [Display(Name = "编号")]
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        [Required(ErrorMessage = "*必填")]
        [Display(Name = "角色名称")]
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        
        [Display(Name = "权限列表")]
        public string OperateList
        {
            get; set;
        }

        [Display(Name = "创建时间")]
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion Model
    }
}

