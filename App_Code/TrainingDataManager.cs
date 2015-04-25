using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Text.RegularExpressions;

namespace AspxOn.Search.FenLei
{

    /// <summary>
    /// 训练管理器
    /// </summary>
    public class TrainingDataManager
    {
        private string[] trainingFileClassicfications; //训练预料分类数组
        private DirectoryInfo trainingTextDir; //训练预料存放目录
        private string defaultDir = "./Data/Sample";
        //private string defaultDir = @"J:\SogouC.reduced.20061127\SogouC.reduced\Reduced";

        public TrainingDataManager()
        {
            if (!Directory.Exists(defaultDir))
            {
                throw new Exception("当前语料目录不存在!");
            }
            trainingTextDir = new DirectoryInfo(defaultDir);

            trainingFileClassicfications = Directory.GetDirectories(defaultDir, "*", SearchOption.TopDirectoryOnly);

            for (int i = 0; i < trainingFileClassicfications.Length; i++)
            {
                trainingFileClassicfications[i] = (Regex.Split(trainingFileClassicfications[i], "\\\\"))[(Regex.Split(trainingFileClassicfications[i], "\\\\")).Length - 1];
                //Console.WriteLine(trainingFileClassicfications[i]);
            }
        }

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <returns></returns>
        public string[] GetTrainingClassifications()
        {
            return trainingFileClassicfications;
        }

        /// <summary>
        /// 获取指定分类下的文件路径
        /// </summary>
        /// <param name="classification"></param>
        /// <returns></returns>
        public string[] GetFilesPath(string classification)
        {
            string[] ret = Directory.GetFiles(defaultDir + "\\" + classification);

            return ret;
        }

        /// <summary>
        /// 获取指定位置的文件内容
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public string GetFileText(string filepath)
        {
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] bt = new byte[fs.Length];
            fs.Read(bt, 0, bt.Length);
            fs.Close();
            string s = Encoding.Default.GetString(bt);
            return s;
        }

        /// <summary>
        /// 获取训练文本集中的文本数目
        /// </summary>
        /// <returns></returns>
        public int GetTrainFileCount()
        {
            int ret = 0;
            for (int i = 0; i < trainingFileClassicfications.Length; i++)
            {
                ret += GetTrainFileCountOfCertainClassification(trainingFileClassicfications[i]);
            }
            return ret;
        }

        /// <summary>
        /// 获取指定分类下的文本数目
        /// </summary>
        /// <param name="classification"></param>
        /// <returns></returns>
        public int GetTrainFileCountOfCertainClassification(string classification)
        {
            int ret = 0;

            ret = Directory.GetFiles(defaultDir + "\\" + classification).Length;

            return ret;
        }

        /// <summary>
        /// 获取指定分类包含关键字或关键词的样本数目
        /// </summary>
        /// <param name="classification">指定分类</param>
        /// <param name="key">关键词或关键字</param>
        /// <returns>样本数目</returns>
        public int GetCountContainKeyOfClassification(string classification, string key)
        {
            int ret = 0;
            string[] filepaths = GetFilesPath(classification);
            try
            {

                for (int i = 0; i < filepaths.Length; i++)
                {
                    string text = GetFileText(filepaths[i]);
                    if (text.Contains(key))
                    {
                        ret++;
                    }
                }
            }
            catch
            {
                throw new Exception("error!");
            }
            return ret;
        }
        public  string[] getText(string classification)
        {
            string[] filepaths = GetFilesPath(classification);
            string[] text = new string[filepaths.Length];
            for (int i = 0; i < filepaths.Length; i++)
            {
                 text[i] = GetFileText(filepaths[i]);
               
            }
            return text;
        }
    }
}
