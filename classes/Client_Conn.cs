using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Web;


namespace doc_reviewer_1._2
{
    class Client_Conn
    {

        public static string Client_Login(string username, string password)
        {

            WebClient w = new WebClient();

            System.Collections.Specialized.NameValueCollection VarPost = new System.Collections.Specialized.NameValueCollection();

            VarPost.Add("username", username);
            VarPost.Add("password", password);

            Console.Write(VarPost);

            byte[] DeletInfo = w.UploadValues("http://39.105.91.30:6667/law/userAuth/userLogin", "POST", VarPost);

            string responseText = System.Text.Encoding.UTF8.GetString(DeletInfo);

            return responseText;
        }

        /// <summary>
        /// 附件类型查询
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="str3"></param>
        /// <returns></returns>
        public static string Client_type_Select(string str1, string str2, string str3)
        {
            WebClient wc = new WebClient();
            string strURL = string.Format(staticinfo.adressip + "/law/appendixtype/select?page={0}&pageSize={1}&word={2}", str1, str2, str3);
            System.Net.HttpWebRequest request;
            // 创建一个HTTP请求  
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            //request.Method="get";  
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string responseText = myreader.ReadToEnd();

            return responseText;
        }
        /// <summary>
        /// 附件类型添加
        /// </summary>
        /// <param name="str1"></param>
        /// <returns></returns>
        public static string Client_type_add(string str1)
        {
            WebClient w = new WebClient();

            System.Collections.Specialized.NameValueCollection VarPost = new System.Collections.Specialized.NameValueCollection();

            VarPost.Add("name", str1);

            Console.Write(VarPost);

            byte[] DeletInfo = w.UploadValues(staticinfo.adressip + "/law/appendixtype/add", "POST", VarPost);

            string responseText = System.Text.Encoding.UTF8.GetString(DeletInfo);

            return responseText;
        }

        /// <summary>
        /// 附件类型更新
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static string Client_type_update(string str1, string str2)
        {
            WebClient w = new WebClient();

            System.Collections.Specialized.NameValueCollection VarPost = new System.Collections.Specialized.NameValueCollection();

            VarPost.Add("id", str1);

            VarPost.Add("name", str2);

            Console.Write(VarPost);

            byte[] byRemoteInfo = w.UploadValues(staticinfo.adressip + "/law/appendixtype/update", "POST", VarPost);

            string sRemoteInfo = System.Text.Encoding.UTF8.GetString(byRemoteInfo);

            return sRemoteInfo;

        }
        /// <summary>
        /// 附件类型删除
        /// </summary>
        /// <param name="str1"></param>
        /// <returns></returns>
        public static string Client_type_delet(string str1)
        {

            WebClient w = new WebClient();

            System.Collections.Specialized.NameValueCollection VarPost = new System.Collections.Specialized.NameValueCollection();

            VarPost.Add("id", str1);


            byte[] DeletInfo = w.UploadValues(staticinfo.adressip + "/law/appendixtype/delete", "POST", VarPost);

            string responseText = System.Text.Encoding.UTF8.GetString(DeletInfo);

            return responseText;
        }
        /// <summary>
        /// 敏感词查询
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="str3"></param>
        /// <returns></returns>
        public static string Client_sensitive_Select(string str1, string str2, string str3)
        {
            WebClient wc = new WebClient();
            string strURL = string.Format(staticinfo.adressip + "/law/sensitivewords/select?page={0}&pageSize={1}&word={2}", str1, str2, str3);
            System.Net.HttpWebRequest request;
            // 创建一个HTTP请求  
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            //request.Method="get";  
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string responseText = myreader.ReadToEnd();

            return responseText;
        }
        /// <summary>
        /// 敏感词添加
        /// </summary>
        /// <param name="str1"></param>
        /// <returns></returns>
        public static string Client_sensitive_add(string str1)
        {
            WebClient w = new WebClient();

            System.Collections.Specialized.NameValueCollection VarPost = new System.Collections.Specialized.NameValueCollection();

            VarPost.Add("name", str1);

            Console.Write(VarPost);

            byte[] DeletInfo = w.UploadValues(staticinfo.adressip + "/law/sensitivewords/add", "POST", VarPost);

            string responseText = System.Text.Encoding.UTF8.GetString(DeletInfo);

            return responseText; ;
        }

        /// <summary>
        /// 敏感词更新
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static string Client_sensitive_update(string str1, string str2)
        {
            WebClient w = new WebClient();

            System.Collections.Specialized.NameValueCollection VarPost = new System.Collections.Specialized.NameValueCollection();

            VarPost.Add("id", str1);
            VarPost.Add("name", str2);

            Console.Write(VarPost);

            byte[] DeletInfo = w.UploadValues(staticinfo.adressip + "/law/sensitivewords/update", "POST", VarPost);

            string responseText = System.Text.Encoding.UTF8.GetString(DeletInfo);

            return responseText;
        }
        /// <summary>
        /// 敏感词删除
        /// </summary>
        /// <param name="str1"></param>
        /// <returns></returns>
        public static string Client_sensitive_delet(string str1)
        {

            WebClient w = new WebClient();

            System.Collections.Specialized.NameValueCollection VarPost = new System.Collections.Specialized.NameValueCollection();

            VarPost.Add("id", str1);

            Console.Write(VarPost);

            byte[] DeletInfo = w.UploadValues(staticinfo.adressip + "/law/sensitivewords/delete", "POST", VarPost);

            string responseText = System.Text.Encoding.UTF8.GetString(DeletInfo);

            return responseText;
        }
        /// <summary>
        /// 查询审核文件
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="word"></param>
        /// <param name="type"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string Client_file_select(string page, string pageSize, string word, string type, string state)
        {
            WebClient wc = new WebClient();
            string strURL = string.Format(staticinfo.adressip + "/law/file/select?page={0}&pageSize={1}&word={2}&type={3}&state={4}", page, pageSize, word, type, state);
            System.Net.HttpWebRequest request;
            // 创建一个HTTP请求  
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            //request.Method="get";  
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string responseText = myreader.ReadToEnd();

            return responseText;
        }
        /// <summary>
        /// 删除审核文件
        /// </summary>
        /// <param name="str1"></param>
        /// <returns></returns>
        public static string Client_file_delet(string str1)
        {

            WebClient w = new WebClient();

            System.Collections.Specialized.NameValueCollection VarPost = new System.Collections.Specialized.NameValueCollection();

            VarPost.Add("id", str1);


            byte[] DeletInfo = w.UploadValues(staticinfo.adressip + "/law/file/delete", "POST", VarPost);

            string responseText = System.Text.Encoding.UTF8.GetString(DeletInfo);

            return responseText;
        }

        public static void Client_file_Download(string fileName)
        {
            WebClient w = new WebClient();
            w.DownloadFile(staticinfo.adressip + "/law/appendix/download", fileName);

        }

        //public static string Client_review_upload(string url, Dictionary<string, string> dic, string imgfile, string Key)
        //{
        //    string str = "";

        //    try
        //    {
        //        HttpClient client = new HttpClient();
        //        var postContent = new MultipartFormDataContent();


        //        string boundary = string.Format("--{0}", DateTime.Now.Ticks.ToString("x"));
        //        postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");
        //        //postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");

        //        string image_file_Type = Key;
        //        postContent.Add(new ByteArrayContent(File.ReadAllBytes(imgfile)), image_file_Type, imgfile);
        //        foreach (var key in dic.Keys)
        //        {
        //            postContent.Add(new StringContent(dic[key].ToString()), key);
        //        }
        //        HttpResponseMessage response = client.PostAsync(url, postContent).Result;
        //        HttpResponseMessage response_1 = client.GetAsync(url).Result;
        //        str = response.Content.ReadAsStringAsync().Result;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("PostJsonData:" + ex.ToString());
        //    }
        //    return str;
        //}


        /// <summary>
        /// 文件审核提交
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <param name="imgfile"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string Client_file_upload(string url, Dictionary<string, string> dic, string imgfile, string Key)
        {
            string str = "";

            try
            {
                HttpClient client = new HttpClient();
                var postContent = new MultipartFormDataContent();


                string boundary = string.Format("--{0}", DateTime.Now.Ticks.ToString("x"));
                postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");
                //postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");

                string image_file_Type = Key;
                postContent.Add(new ByteArrayContent(File.ReadAllBytes(imgfile)), image_file_Type, imgfile);
                foreach (var key in dic.Keys)
                {
                    postContent.Add(new StringContent(dic[key].ToString()), key);
                }
                HttpResponseMessage response = client.PostAsync(url, postContent).Result;
                HttpResponseMessage response_1 = client.GetAsync(url).Result;
                str = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception ex)
            {
                MessageBox.Show("PostJsonData:" + ex.ToString());
            }
            return str;

        }
        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="id"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool Client_file_download(string id, string path, string fileName)
        {
            try
            {
                //string fileName = Path.GetFileName(url);
                string filePath = path;
                //+ "\\" + fileName;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                WebClient wc = new WebClient();
                string strURL = string.Format(staticinfo.adressip + "/law/file/downloadReviewWord?id={0}", id);
                System.Net.HttpWebRequest request;
                request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
                
                System.Net.HttpWebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
               // string header_contentDisposition = wc.ResponseHeaders["content-disposition"];
                System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                Stream responsestream = response.GetResponseStream();

                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader readStream = new StreamReader(responsestream, encode);


                byte[] srcBuf = new Byte[1024];


                int iTotalSize = 0;
                int size = responsestream.Read(srcBuf, 0, (int)srcBuf.Length);
                while (size > 0)
                {
                    iTotalSize += size;
                    fs.Write(srcBuf, 0, size);
                    size = responsestream.Read(srcBuf, 0, (int)srcBuf.Length);
                }
                fs.Close();
                responsestream.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

        }

        public static bool Client_appendixfile_download(string id, string path, string fileName)
        {
            try
            {
                //string fileName = Path.GetFileName(url);
                string filePath = path;
                //+ "\\" + fileName;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                WebClient wc = new WebClient();
                string strURL = string.Format(staticinfo.adressip + "/law/appendix/download?id={0}", id);
                
                System.Net.HttpWebRequest request;
                request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
                System.Net.HttpWebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
                System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                Stream responsestream = response.GetResponseStream();
                //string header_contentDisposition = wc.ResponseHeaders["content-disposition"];
                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader readStream = new StreamReader(responsestream, encode);

                byte[] srcBuf = new Byte[1024];

                int iTotalSize = 0;
                int size = responsestream.Read(srcBuf, 0, (int)srcBuf.Length);
                while (size > 0)
                {
                    iTotalSize += size;
                    fs.Write(srcBuf, 0, size);
                    size = responsestream.Read(srcBuf, 0, (int)srcBuf.Length);
                }
                fs.Close();
                responsestream.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }

        }

        /// <summary>
        /// 提交json数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <param name="imgfile"></param>
        /// <returns></returns>
        public static string PostJsonData(string url, Dictionary<string, string> dic, string imgfile)
        {
            string str = "";
            try
            {
                HttpClient client = new HttpClient();
                var postContent = new MultipartFormDataContent();


                string boundary = string.Format("--{0}", DateTime.Now.Ticks.ToString("x"));
                postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");
                //postContent.Headers.Add("ContentType", $"multipart/form-data, boundary={boundary}");

                string image_file_Type = "file";
                postContent.Add(new ByteArrayContent(File.ReadAllBytes(imgfile)), image_file_Type, imgfile);

                foreach (var key in dic.Keys)
                {
                    postContent.Add(new StringContent(dic[key].ToString()), key);
                }
                HttpResponseMessage response = client.PostAsync(url, postContent).Result;
                str = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception ex)
            {
                MessageBox.Show("PostJsonData:" + ex.ToString());
            }
            return str;

        }
        /// <summary>
        /// 根据附件id查询附件名称
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="str3"></param>
        /// <returns></returns>
        public static string Client_Nameappend_Select(string str1, string str2, string str3)
        {
            WebClient wc = new WebClient();
            string strURL = string.Format(staticinfo.adressip + "/law/appendixtype/selectById?page={0}&pageSize={1}&id={2}", str1, str2, str3);
            System.Net.HttpWebRequest request;
            // 创建一个HTTP请求  
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            //request.Method="get";  
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string responseText = myreader.ReadToEnd();

            return responseText;
        }
        /// <summary>
        /// 文件标签删除
        /// </summary>
        /// <param name="str1"></param>
        /// <returns></returns>
        public static string Client_fileremark_delet(string str1)
        {

            WebClient w = new WebClient();

            System.Collections.Specialized.NameValueCollection VarPost = new System.Collections.Specialized.NameValueCollection();

            VarPost.Add("id", str1);


            byte[] DeletInfo = w.UploadValues(staticinfo.adressip + "/law/appendixtype/delete", "POST", VarPost);

            string responseText = System.Text.Encoding.UTF8.GetString(DeletInfo);

            return responseText;
        }
        /// <summary>
        /// 敏感词删除
        /// </summary>
        /// <param name="str1"></param>
        /// <returns></returns>
        public static string Client_sen_delet(string str1)
        {

            WebClient w = new WebClient();

            System.Collections.Specialized.NameValueCollection VarPost = new System.Collections.Specialized.NameValueCollection();

            VarPost.Add("id", str1);


            byte[] DeletInfo = w.UploadValues(staticinfo.adressip + "/law/sen/delete", "POST", VarPost);

            string responseText = System.Text.Encoding.UTF8.GetString(DeletInfo);

            return responseText;
        }

        public static string Client_change_state(string id, string state)
        {
            WebClient w = new WebClient();

            System.Collections.Specialized.NameValueCollection VarPost = new System.Collections.Specialized.NameValueCollection();

            VarPost.Add("id", id);
            VarPost.Add("state", state);


            byte[] DeletInfo = w.UploadValues(staticinfo.adressip + "/law/file/updateState", "POST", VarPost);

            string responseText = System.Text.Encoding.UTF8.GetString(DeletInfo);

            return responseText;
        }

        public static bool Client_download_reviewWord(string id,string path,string filename)
        {
            try
            {
                //string fileName = Path.GetFileName(url);
                string filePath = path;
                //+ "\\" + fileName;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                WebClient wc = new WebClient();
                string strURL = string.Format(staticinfo.adressip + "/law/file/downloadSampleReviewWord?id={0}", id);
                
                System.Net.HttpWebRequest request;
                request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
                System.Net.HttpWebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
                System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                Stream responsestream = response.GetResponseStream();
                //string header_contentDisposition = wc.ResponseHeaders["Content-Disposition"];
                Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
                StreamReader readStream = new StreamReader(responsestream, encode);

                byte[] srcBuf = new Byte[1024];

                int iTotalSize = 0;
                int size = responsestream.Read(srcBuf, 0, (int)srcBuf.Length);
                while (size > 0)
                {
                    iTotalSize += size;
                    fs.Write(srcBuf, 0, size);
                    size = responsestream.Read(srcBuf, 0, (int)srcBuf.Length);
                }
                fs.Close();
                responsestream.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
