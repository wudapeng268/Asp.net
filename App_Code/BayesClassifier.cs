using System;
using System.Collections.Generic;
using System.Text;
using Lucene.Net.Analysis;


using SharpICTCLAS;
using System.IO;
namespace AspxOn.Search.FenLei
{
    /// <summary>
    /// 朴素贝叶斯分类器
    /// </summary>
    public class BayesClassifier
    {

        private TrainingDataManager tdm; //训练集合管理器
        //private string trainingDataPath; //训练集合路径
        private SVMModle svm;
      //  private static float zoomFactor = 10.0F;
        ICTCLASAnalyzer a = new ICTCLASAnalyzer();
        /// <summary>
        /// 默认构造器，初始化训练集合
        /// </summary>
        public BayesClassifier()
        {
            tdm = new TrainingDataManager();
            svm = new SVMModle();
        }

        /// <summary>
        /// 计算给定的文本属性向量X在给定的分类Cj中的类条件概率
        /// </summary>
        /// <param name="X">文本属性向量X</param>
        /// <param name="Cj">给定的分类</param>
        /// <returns>分类条件概率连乘值</returns>
        protected float CaluProd(string[] X, string Cj)
        {
            float ret = 1.0F;

          
               // float f=ClassConditionalProbability.CaculatePxc(Xi, Cj)* zoomFactor;//因为数值过小，因此将连乘值放大10倍(通过乘以zoomFactor)

            //Console.WriteLine(ret);
            ret *= PriorProbability.CaculatePc(Cj); //再乘以先验概率
            return ret;
        }

        /// <summary>
        /// 对指定文本进行分类
        /// </summary>
        /// <param name="text">指定文本</param>
        /// <returns>分类结果</returns>
        public List<ClassifyResult> Classify(string text)
        {
            string DictPath = Path.Combine(Environment.CurrentDirectory, "Data") + Path.DirectorySeparatorChar;
           // Console.WriteLine("正在初始化字典库，请稍候");
            WordSegment wordSegment = new WordSegment();
            wordSegment.InitWordSegment(DictPath);
            
            string terms = ChineseSpliter.Split(text, "|",a,wordSegment); //中文分词处理（分词结果可能包含停用词）
           // string[] classes = tdm.GetTrainingClassifications();  //分类列表数组
           
            List<ClassifyResult> crs = new List<ClassifyResult>(); //分类结果

        //   String selectall = "select * from TAnswer where id >= 0";
        //DataSet allds = sql.sqlsearch(selectall);
        //int len = allds.Tables["t"].Rows.Count;
        //ClassifyResult[] cr = new ClassifyResult[len];

        //for (int i = 0; i < len; i++)
        //{
        //    cr[i].id = allds.Tables["t"].Rows[i]["id"].ToString();
        //    cr[i].keyanswerid = allds.Tables["t"].Rows[i]["keyanswerid"].ToString();
        //    cr[i].keytext = allds.Tables["t"].Rows[i]["keytext"].ToString();
        //    cr[i].rownu = i;
        //}

          
        //       // string[] text2 = tdm.getText(Ci);
        //        for(int j=0;j<text2.Length;j++)
        //        {
                    
        //            probility += svm.Similarity(terms, text2[j]);
        //        }
        //        ClassifyResult cr = new ClassifyResult();
        //        cr.classification = Ci;
        //        cr.probability = probility;
        //        crs.Add(cr);
            
            return crs;
        }

        public string GetMaxNum(List<ClassifyResult> crs)
        {
            double ret = 0;
            string classification = string.Empty;
            ret = crs[0].probability;
            for (int i = 0; i < crs.Count; i++)
            {
                if (crs[i].probability > ret)
                {
                    ret = crs[i].probability;
                   // classification = crs[i].classification;
                }
            }
            return classification;
        }

        
    }
}