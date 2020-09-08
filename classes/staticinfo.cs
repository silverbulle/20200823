using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.MobileControls;

namespace doc_reviewer_1._2
{
    public static class staticinfo
    {
        //public static string Submittype { get; set; }  //上传送审稿类型
        //public static string Filingunit { get; set; }  //备案单位
        //public static string Department { get; set; }  //签发部门科室
        //public static string Signer { get; set; }    //签发人
        //public static string Remark { get; set; }   //备注
        //public static string Appendtype { get; set; }  //上传附件
        //public static string Lacktype { get; set; }  //缺少文件
        //public static string DataTimeget { get; set; }  //送达时间
        //public static string Mainfilepath { get; set; } //记录主文件路径
        //以上均为审核提交页面参数
        public static string adressip = "http://39.105.91.30:6667";  //主机IP地址

        public static int Idremark { get; set; }  //文件标签索引
        public static string Nameremark { get; set; }  //文件标签名称
        //
        public static string page { get; set; }  //连接服务端get方法所需
        public static string pagesize { get; set; }  //连接服务端get方法所需
        public static string word { get; set; }  //连接服务端get方法所需

        public static JArray Listinfo { get; set; }  //解析的json信息

        public static int Recordcount { get; set; }  //字典中记录的总行数

        public static List<string> rc = new List<string>(); //返回的主体结果
        //public static List<string> Returncontent { get; set; }
        public static int Returnindex { get; set; } //审核详情获取点击的行索引

        public static List<string> MainName = new List<string>(); //返回的主文件名称
        public static List<string> Subunit = new List<string>(); //返回的送审单位
        public static List<string> Subtime = new List<string>(); //返回的送审时间
        public static List<string> Signer = new List<string>(); //返回的主文件名称
        public static List<string> Department = new List<string>(); //返回的签发人科室
        public static List<string> Remark = new List<string>(); //返回的备注
        public static List<string> Appendpk = new List<string>(); //返回的yi已有的附件id
        public static List<string> Lackappend = new List<string>(); //返回的缺少附件类型
        public static List<int> Numlackappend = new List<int>(); //单个文件缺少的附件类型个数
        public static List<List<string>> Lackappendname = new List<List<string>>() { };

        public static List<string> Append = new List<string>(); //返回的已有的附件名称
        public static List<int> Numappend = new List<int>(); //返回单个文件的已有附件
        //public  static int Numlackappend { get; set; }  //单个文件缺少的附件类型个数
    }
}
