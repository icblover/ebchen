using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZCJ.Utility
{
    /// <summary>
    /// 水印的类型
    /// </summary>
    public enum WaterMarkType
    {
        /// <summary>
        /// 文字水印
        /// </summary>
        TextMark,
        /// <summary>
        /// 图片水印
        /// </summary>
        //ImageMark // 暂时只能添加文字水印
    };
    /// <summary>
    /// 水印的位置
    /// </summary>
    public enum WaterMarkPosition
    {
        /// <summary>
        /// 左上角
        /// </summary>
        WMP_Left_Top,
        /// <summary>
        /// 左下角
        /// </summary>
        WMP_Left_Bottom,
        /// <summary>
        /// 右上角
        /// </summary>
        WMP_Right_Top,
        /// <summary>
        /// 右下角
        /// </summary>
        WMP_Right_Bottom
    };
    public class ImageHelper
    {
        public ImageHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary> 匹配第一张图片代码 </summary>
        /// <param name="text">匹配文本</param>
        /// <returns></returns>
        public static string GetImgUrl(string text)
        {
            StringBuilder str = new StringBuilder();
            string pat = @"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\""*\S+\""*)'?[^>]*>";
            Regex r = new Regex(pat, RegexOptions.Compiled);
            Match m = r.Match(text.ToLower());

            Group g = m.Groups["url"];
            str.Append(g).Append("|");//g就是图片的完整url

            string strs = str.ToString().Replace("\"", "").TrimEnd('|');
            return strs;
        }
        /// <summary> 返回一个匹配结果组 </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static MatchCollection GetImgUrlGroup(string text)
        {
            string pat = @"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\""*\S+\""*)'?[^>]*>";
            Regex r = new Regex(pat, RegexOptions.Compiled);
            MatchCollection collection = r.Matches(text.ToLower());
            return collection;
        }
        /// <summary>
        /// 上传文件，文件名要求唯一，上传成功显示文件名，如123.jpg,否则返回 false;
        /// </summary>
        /// <param name="fload">上传组件</param>
        /// <param name="path">指定的路径 ，总是以“/”结尾</param>
        /// <param name="FileName">指定文件名</param>
        /// <returns>string</returns>
        public static string FileUpLoad(System.Web.UI.WebControls.FileUpload fload, string path, string FileName)
        {
            //判断指定路径是否存在此目录，如果没有则创建
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            int count = 0;
            string NewFileName = FileName;
            //上传文件之前判断指定路径是否已经存在此文件，如果存在，则删除
            if (System.IO.File.Exists(path + NewFileName))
            {
                System.IO.File.Delete(path + NewFileName);
            }
            try
            {
                fload.SaveAs(path + NewFileName);
            }
            catch (Exception ex)
            {
                count++;
            }
            if (count > 0)
            {
                return "false";
            }
            else
            {
                return NewFileName;
            }
        }

        #region 给图片加水印
        /// <summary>
        /// 添加水印(分图片水印与文字水印两种)
        /// </summary>
        /// <param name="oldpath">原图片绝对地址</param>
        /// <param name="newpath">新图片放置的绝对地址</param>
        /// <param name="wmtType">要添加的水印的类型</param>
        /// <param name="sWaterMarkContent">水印内容，若添加文字水印，此即为要添加的文字；
        /// 若要添加图片水印，此为图片的路径</param>
        public void addWaterMark(string oldpath, string newpath, WaterMarkType wmtType, string sWaterMarkContent)
        {
            try
            {
                Image image = Image.FromFile(oldpath);
                Bitmap b = new Bitmap(image.Width, image.Height,
                    PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(b);
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.High;
                g.DrawImage(image, 0, 0, image.Width, image.Height);
                switch (wmtType)
                {
                    /*case WaterMarkType.ImageMark:
                        //图片水印
                        this.addWatermarkImage(g, 
                            Page.Server.MapPath(Watermarkimgpath), 
                            WatermarkPosition,image.Width,image.Height);
                        break;*/
                    case WaterMarkType.TextMark:
                        //文字水印
                        this.addWatermarkText(g, sWaterMarkContent, "WM_BOTTOM_RIGHT",
                            image.Width, image.Height);
                        break;
                }
                b.Save(newpath);
                b.Dispose();
                image.Dispose();
            }
            catch
            {
                if (File.Exists(oldpath))
                {
                    File.Delete(oldpath);
                }
            }
            finally
            {
                if (File.Exists(oldpath))
                {
                    File.Delete(oldpath);
                }
            }
        }
        /// <summary>
        ///  加水印文字
        /// </summary>
        /// <param name="picture">imge 对象</param>
        /// <param name="_watermarkText">水印文字内容</param>
        /// <param name="_watermarkPosition">水印位置</param>
        /// <param name="_width">被加水印图片的宽</param>
        /// <param name="_height">被加水印图片的高</param>
        private void addWatermarkText(Graphics picture, string _watermarkText, string _watermarkPosition, int _width, int _height)
        {
            // 确定水印文字的字体大小
            int[] sizes = new int[] { 32, 30, 28, 26, 24, 22, 20, 18, 16, 14, 12, 10, 8, 6, 4 };
            Font crFont = null;
            SizeF crSize = new SizeF();
            for (int i = 0; i < sizes.Length; i++)
            {
                crFont = new Font("Arial Black", sizes[i], FontStyle.Bold);
                crSize = picture.MeasureString(_watermarkText, crFont);
                if ((ushort)crSize.Width < (ushort)_width)
                {
                    break;
                }
            }
            // 生成水印图片（将文字写到图片中）
            Bitmap floatBmp = new Bitmap((int)crSize.Width + 3,
                           (int)crSize.Height + 3, PixelFormat.Format32bppArgb);
            Graphics fg = Graphics.FromImage(floatBmp);
            PointF pt = new PointF(0, 0);
            // 画阴影文字
            Brush TransparentBrush0 = new SolidBrush(Color.FromArgb(255, Color.Black));
            Brush TransparentBrush1 = new SolidBrush(Color.FromArgb(255, Color.Black));
            fg.DrawString(_watermarkText, crFont, TransparentBrush0, pt.X, pt.Y + 1);
            fg.DrawString(_watermarkText, crFont, TransparentBrush0, pt.X + 1, pt.Y);
            fg.DrawString(_watermarkText, crFont, TransparentBrush1, pt.X + 1, pt.Y + 1);
            fg.DrawString(_watermarkText, crFont, TransparentBrush1, pt.X, pt.Y + 2);
            fg.DrawString(_watermarkText, crFont, TransparentBrush1, pt.X + 2, pt.Y);
            TransparentBrush0.Dispose();
            TransparentBrush1.Dispose();
            // 画文字
            fg.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            fg.DrawString(_watermarkText,
                crFont, new SolidBrush(Color.White),
                pt.X, pt.Y, StringFormat.GenericDefault);
            // 保存刚才的操作
            fg.Save();
            fg.Dispose();
            // floatBmp.Save("d:\\WebSite\\DIGITALKM\\ttt.jpg");
            // 将水印图片加到原图中
            this.addWatermarkImage(
                picture,
                new Bitmap(floatBmp),
                "WM_BOTTOM_RIGHT",
                _width,
                _height);
        }
        /// <summary>
        ///  加水印图片
        /// </summary>
        /// <param name="picture">imge 对象</param>
        /// <param name="iTheImage">Image对象（以此图片为水印）</param>
        /// <param name="_watermarkPosition">水印位置</param>
        /// <param name="_width">被加水印图片的宽</param>
        /// <param name="_height">被加水印图片的高</param>
        private void addWatermarkImage(Graphics picture, Image iTheImage, string _watermarkPosition, int _width, int _height)
        {
            Image watermark = new Bitmap(iTheImage);
            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();
            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };
            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);
            float[][] colorMatrixElements = {
                                                new float[] {1.0f, 0.0f, 0.0f, 0.0f, 0.0f},
                                                new float[] {0.0f, 1.0f, 0.0f, 0.0f, 0.0f},
                                                new float[] {0.0f, 0.0f, 1.0f, 0.0f, 0.0f},
                                                new float[] {0.0f, 0.0f, 0.0f, 0.3f, 0.0f},
                                                new float[] {0.0f, 0.0f, 0.0f, 0.0f, 1.0f}
                                            };
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            int xpos = 0;
            int ypos = 0;
            int WatermarkWidth = 0;
            int WatermarkHeight = 0;
            double bl = 1d;
            //计算水印图片的比率
            //取背景的1/4宽度来比较
            if ((_width > watermark.Width * 4) && (_height > watermark.Height * 4))
            {
                bl = 1;
            }
            else if ((_width > watermark.Width * 4) && (_height < watermark.Height * 4))
            {
                bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);
            }
            else if ((_width < watermark.Width * 4) && (_height > watermark.Height * 4))
            {
                bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);
            }
            else
            {
                if ((_width * watermark.Height) > (_height * watermark.Width))
                {
                    bl = Convert.ToDouble(_height / 4) / Convert.ToDouble(watermark.Height);
                }
                else
                {
                    bl = Convert.ToDouble(_width / 4) / Convert.ToDouble(watermark.Width);
                }
            }
            WatermarkWidth = Convert.ToInt32(watermark.Width * bl);
            WatermarkHeight = Convert.ToInt32(watermark.Height * bl);
            switch (_watermarkPosition)
            {
                case "WM_TOP_LEFT":
                    xpos = 10;
                    ypos = 10;
                    break;
                case "WM_TOP_RIGHT":
                    xpos = _width - WatermarkWidth - 10;
                    ypos = 10;
                    break;
                case "WM_BOTTOM_RIGHT":
                    xpos = _width - WatermarkWidth - 10;
                    ypos = _height - WatermarkHeight - 10;
                    break;
                case "WM_BOTTOM_LEFT":
                    xpos = 10;
                    ypos = _height - WatermarkHeight - 10;
                    break;
            }
            picture.DrawImage(
                watermark,
                new Rectangle(xpos, ypos, WatermarkWidth, WatermarkHeight),
                0,
                0,
                watermark.Width,
                watermark.Height,
                GraphicsUnit.Pixel,
                imageAttributes);
            watermark.Dispose();
            imageAttributes.Dispose();
        }
        /// <summary>
        ///  加水印图片
        /// </summary>
        /// <param name="picture">imge 对象</param>
        /// <param name="WaterMarkPicPath">水印图片的地址</param>
        /// <param name="_watermarkPosition">水印位置</param>
        /// <param name="_width">被加水印图片的宽</param>
        /// <param name="_height">被加水印图片的高</param>
        private void addWatermarkImage(Graphics picture, string WaterMarkPicPath, string _watermarkPosition, int _width, int _height)
        {
            Image watermark = new Bitmap(WaterMarkPicPath);
            this.addWatermarkImage(picture, watermark, _watermarkPosition, _width,
                _height);
        }
        /// <summary>
        /// 在图片上增加文字水印
        /// </summary>
        /// <param name="Path">原服务器图片路径</param>
        /// <param name="Path_sy">生成的带文字水印的图片路径</param>
        public static void AddWater(string WaterText, string Path)
        {
            string addText = WaterText;
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            System.Drawing.Font f = new System.Drawing.Font("Verdana", 12, FontStyle.Bold);
            System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.White);

            g.DrawString(addText, f, b, image.Width - 170, image.Height - 40);
            g.Dispose();
            string oldPath = System.IO.Path.GetDirectoryName(Path);
            string fileExtension = System.IO.Path.GetExtension(Path);
            string fileName = System.IO.Path.GetFileNameWithoutExtension(Path);
            string newFile = oldPath + fileName + "_1" + fileExtension;
            image.Save(newFile);
            image.Dispose();
            //删除源文件
            File.Delete(Path);
            //复制新文件
            File.Copy(newFile, Path);
            //删除新文件
            File.Delete(newFile);
        }
        /// <summary>
        /// 在图片上增加文字水印
        /// </summary>
        /// <param name="Path">原服务器图片路径</param>
        /// <param name="Path_sy">生成的带文字水印的图片路径</param>
        public static void AddWater(string WaterText, string Path, string Path_sy)
        {
            string addText = WaterText;
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(image, 0, 0, image.Width, image.Height);
            System.Drawing.Font f = new System.Drawing.Font("Verdana", 12);
            System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
            g.DrawString(addText, f, b, 10, 10);
            g.Dispose();
            image.Save(Path_sy);
            image.Dispose();
        }
        /// <summary>
        /// 在图片上生成图片水印
        /// </summary>
        /// <param name="Path">原服务器图片路径</param>
        /// <param name="Path_syp">生成的带图片水印的图片路径</param>
        /// <param name="Path_sypf">水印图片路径</param>
        public static void AddWaterPic(string Path, string Path_syp, string Path_sypf)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
            System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sypf);
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
            g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
            g.Dispose();
            image.Save(Path_syp);
            image.Dispose();
        }
        #endregion

        #region 生成缩略图
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="image">Image 对象</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="ici">指定格式的编解码参数</param>
        private void SaveImage(Image image, string savePath, ImageCodecInfo ici)
        {
            //设置 原图片 对象的 EncoderParameters 对象
            EncoderParameters parameters = new EncoderParameters(1);
            parameters.Param[0] = new EncoderParameter(
                System.Drawing.Imaging.Encoder.Quality, ((long)90));
            image.Save(savePath, ici, parameters);
            parameters.Dispose();
        }
        /// <summary>
        /// 获取图像编码解码器的所有相关信息
        /// </summary>
        /// <param name="mimeType">包含编码解码器的多用途网际邮件扩充协议 (MIME) 类型的字符串</param>
        /// <returns>返回图像编码解码器的所有相关信息</returns>
        private ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType)
                    return ici;
            }
            return null;
        }
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="sourceImagePath">原图片路径(相对路径)</param>
        /// <param name="thumbnailImagePath">生成的缩略图路径,如果为空则保存为原图片路径(相对路径)</param>
        /// <param name="thumbnailImageWidth">缩略图的宽度（高度与按源图片比例自动生成）</param>
        public void ToThumbnailImages(string SourceImagePath, string ThumbnailImagePath, int ThumbnailImageWidth)
        {
            Hashtable htmimes = new Hashtable();
            htmimes[".jpeg"] = "image/jpeg";
            htmimes[".jpg"] = "image/jpeg";
            htmimes[".png"] = "image/png";
            htmimes[".tif"] = "image/tiff";
            htmimes[".tiff"] = "image/tiff";
            htmimes[".bmp"] = "image/bmp";
            htmimes[".gif"] = "image/gif";
            // 取得原图片的后缀
            string sExt = SourceImagePath.Substring(SourceImagePath.LastIndexOf(".")).ToLower();
            //从 原图片 创建 Image 对象
            Image image = Image.FromFile(SourceImagePath);
            int num = ((ThumbnailImageWidth / 4) * 3);
            int width = image.Width;
            int height = image.Height;
            //计算图片的比例
            if ((((double)width) / ((double)height)) >= 1.3333333333333333f)
            {
                num = ((height * ThumbnailImageWidth) / width);
            }
            else
            {
                ThumbnailImageWidth = ((width * num) / height);
            }
            if ((ThumbnailImageWidth < 1) || (num < 1))
            {
                return;
            }
            //用指定的大小和格式初始化 Bitmap 类的新实例
            Bitmap bitmap = new Bitmap(ThumbnailImageWidth, num, PixelFormat.Format32bppArgb);
            //从指定的 Image 对象创建新 Graphics 对象
            Graphics graphics = Graphics.FromImage(bitmap);
            //清除整个绘图面并以透明背景色填充
            graphics.Clear(Color.Transparent);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.High;
            //在指定位置并且按指定大小绘制 原图片 对象
            graphics.DrawImage(image, new Rectangle(0, 0, ThumbnailImageWidth, num));
            image.Dispose();
            try
            {
                //将此 原图片 以指定格式并用指定的编解码参数保存到指定文件 
                SaveImage(bitmap, ThumbnailImagePath, GetCodecInfo((string)htmimes[sExt]));
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式,"Hw":指定高宽缩放（可能变形） ,"W"://指定宽，高按比例; "H"://指定高，宽按比例;"Cut"://指定高宽裁减（不变形）</param> 
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);
            int towidth = width;
            int toheight = height;
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形） 
                    break;
                case "W"://指定宽，高按比例 
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形） 
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }
            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);
            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);
            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        #endregion
    }

}
