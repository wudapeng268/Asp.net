using System;
using System.Collections.Generic;
using System.Text;

namespace AspxOn.Search.FenLei
{
    /// <summary>
    /// 保存分类结果
    /// </summary>
    public class ClassifyResult
    {

        public double probability; //分类概率
        public string keytext;  //分类

        public string keyanswerid;
        public string id;
        public int rownu;//
        public ClassifyResult()
        {
            probability = 0;
            keytext = string.Empty;
        }
    }
}