using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace doc_reviewer_1._2.model.mothed
{
    class DeleteFile
    {
        public static void delet(string aimPath, string Directory)
        {
            try
            {
                //检查目标目录是否以目录分割字符结束如果不是则添加之
                //if (aimPath[aimPath.Length - 1] !=
                //    Path.DirectorySeparatorChar)
                //    aimPath += Path.DirectorySeparatorChar;
                //得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                //如果你指向Delete目标文件下面的文件而不包含目录请使用下面的方法
                //string[]fileList=  Directory.GetFiles(aimPath);
                // string[] fileList = System.Environment.GetFileSystemEntries(aimPath);
                //遍历所有的文件和目录 
                /*foreach (string file in fileList)
                {
                    //先当作目录处理如果存在这个
                    //目录就递归Delete该目录下面的文件 
                    if (Directory.Exists(file))
                    {
                        DeleteDir(aimPath + Path.GetFileName(file));
                    }
                    //否则直接Delete文件 
                    else
                    {
                        File.Delete(aimPath + Path.GetFileName(file));
                    }
                }*/
                //删除文件夹 
                if (System.IO.Directory.Exists(Directory))
                    System.IO.Directory.Delete(Directory, true);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                //MessageBox.Show(e.ToString());
            }
}
    }
}
