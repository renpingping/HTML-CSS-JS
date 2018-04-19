using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Configuration;
using System.Text;
using System.Drawing;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Mvc;


/// <summary>
/// CommonClass 的摘要说明
/// </summary>
public class CommonClass
{
    public CommonClass()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public string MessageBox(string TxtMessage, string Url)
    {
        string str;
        str = "<script langage=javascript>alert('" + TxtMessage + "');location='" + Url + "';</script>";
        return str;
    }
    public string MessageBoxPage(string TxtMessage)
    {
        string str;
        str = "<script langage=javascript>alert('" + TxtMessage + "');</script>";
        return str;
    }
   public string RandomNum(int n)
    {
        string strchar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
        string[] VcArray = strchar.Split(',');
        string VNum = "";
        int temp = -1;
        Random rand = new Random();
        for (int i = 1; i < n + 1; i++)
        {
            if (temp != -1)
            {
                rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
            }
            int t = rand.Next(61);
            if (temp != -1 && temp == t)
            {
                return RandomNum(n);
            }
            temp = t;
            VNum += VcArray[t];
        }
        return VNum;
    }
   public string VarStr(string sString, int nleng)//用来截取小数点后nleng位
   {
       int index = sString.IndexOf(".");
       if (index == -1 || index + nleng >= sString.Length)
           return sString;
       else
           return sString.Substring(0, (index + nleng + 1));
   }
    /// <summary>
    /// 生成图片验证码
    /// </summary>
    /// <param name="checkCode"></param>
   public void CreateCheckCodeImage(string[] checkCode)
   {
       if (checkCode == null || checkCode.Length <= 0)
           return;

       System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 32.5)), 30);
       System.Drawing.Graphics g = Graphics.FromImage(image);

       try
       {
           Random random = new Random();
           //清空图片背景色 
           g.Clear(Color.White);

           //画图片的背景噪音线 
           for (int i = 0; i < 20; i++)
           {
               int x1 = random.Next(image.Width);
               int x2 = random.Next(image.Width);
               int y1 = random.Next(image.Height);
               int y2 = random.Next(image.Height);

               g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
           }

           //定义颜色
           Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
           //定义字体
           string[] f = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };

           for (int k = 0; k <= checkCode.Length - 1; k++)
           {
               int cindex = random.Next(7);
               int findex = random.Next(5);

               Font drawFont = new Font(f[findex], 16, (System.Drawing.FontStyle.Bold));
               SolidBrush drawBrush = new SolidBrush(c[cindex]);

               float x = 5.0F;
               float y = 0.0F;
               float width = 20.0F;
               float height = 25.0F;
               int sjx = random.Next(10);
               int sjy = random.Next(image.Height - (int)height);

               RectangleF drawRect = new RectangleF(x + sjx + (k * 25), y + sjy, width, height);

               StringFormat drawFormat = new StringFormat();
               drawFormat.Alignment = StringAlignment.Center;

               g.DrawString(checkCode[k], drawFont, drawBrush, drawRect, drawFormat);
           }

           //画图片的前景噪音点 
           for (int i = 0; i < 100; i++)
           {
               int x = random.Next(image.Width);
               int y = random.Next(image.Height);

               image.SetPixel(x, y, Color.FromArgb(random.Next()));
           }

           //画图片的边框线 
           g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

           System.IO.MemoryStream ms = new System.IO.MemoryStream();
           image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
           //System.Web.HttpContext.Current.Response.ClearContent();
           System.Web.HttpContext.Current.Response.ContentType = "image/Gif";
           System.Web.HttpContext.Current.Response.BinaryWrite(ms.ToArray());
       }
       finally
       {
           g.Dispose();
           image.Dispose();
       }
   }
   /*public ActionResult SecurityCode(){
       string oldcode = TempData["SecurityCode"] as string;
              string code = CreateRandomCode(4); //验证码的字符为4个
              TempData["SecurityCode"] = code; //验证码存放在TempData中
              return File(CreateValidateGraphic(code), "image/Jpeg");
   }
     
          /// <summary>
         /// 生成随机的字符串
         /// </summary>
         /// <param name="codeCount"></param>
/// <returns></returns>
         public string CreateRandomCode(int codeCount)
         {
             string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,a,b,c,d,e,f,g,h,i,g,k,l,m,n,o,p,q,r,F,G,H,I,G,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,s,t,u,v,w,x,y,z";
             string[] allCharArray = allChar.Split(',');
             string randomCode = "";
             int temp = -1;
             Random rand = new Random();
             for (int i = 0; i < codeCount; i++)
             {
                 if (temp != -1)
                 {
                     rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                 }
                 int t = rand.Next(35);
                 if (temp == t)
                 {
                     return CreateRandomCode(codeCount);
                 }
                 temp = t;
                 randomCode += allCharArray[t];
             }
             return randomCode;
         }
 
         /// <summary>
         /// 创建验证码图片
         /// </summary>
         /// <param name="validateCode"></param>
         /// <returns></returns>
         public byte[] CreateValidateGraphic(string validateCode)
         {
             Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 16.0), 27);
             Graphics g = Graphics.FromImage(image);
             try
             {
                 //生成随机生成器
                 Random random = new Random();
                 //清空图片背景色
                 g.Clear(Color.White);
                 //画图片的干扰线
                 for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                     int x2 = random.Next(image.Width);
                     int y1 = random.Next(image.Height);
                     int y2 = random.Next(image.Height);
                     g.DrawLine(new Pen(Color.Silver), x1, x2, y1, y2);
                 }
                 Font font = new Font("Arial", 13, (FontStyle.Bold | FontStyle.Italic));
                 LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                 g.DrawString(validateCode, font, brush, 3, 2);
 
                 //画图片的前景干扰线
                 for (int i = 0; i < 100; i++)
                 {
                     int x = random.Next(image.Width);
                     int y = random.Next(image.Height);
                     image.SetPixel(x, y, Color.FromArgb(random.Next()));
                 }
                 //画图片的边框线
                 g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
 
                 //保存图片数据
                 MemoryStream stream = new MemoryStream();
                 image.Save(stream, ImageFormat.Jpeg);
 
                 //输出图片流
                 return stream.ToArray();
             }
            finally
            {
                 g.Dispose();
                 image.Dispose();
             }
         }*/
}
