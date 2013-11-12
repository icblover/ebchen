using System;
namespace ZCJ.Model
{
	/// <summary>
	/// ArticleDetail:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class ArticleDetail 
	{
		public ArticleDetail()
		{}
		#region Model
		private int _id;
		private int _articleid;
		private string _articleintroduce;
		private string _keyword;
		private string _articlecontent;
		private string _author;
		private string _articlefrom;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ArticleId
		{
			set{ _articleid=value;}
			get{return _articleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ArticleIntroduce
		{
			set{ _articleintroduce=value;}
			get{return _articleintroduce;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Keyword
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ArticleContent
		{
			set{ _articlecontent=value;}
			get{return _articlecontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ArticleFrom
		{
			set{ _articlefrom=value;}
			get{return _articlefrom;}
		}
		#endregion Model

	}
}

