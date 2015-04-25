using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AspxOn.Search.FenLei
{
    public class SVMModle
    {
        /// <summary>
        /// 降维词表
        /// </summary>
        private List<string> reducingKeys = new List<string>();
        /// <summary>
        /// 构造函数：使用降维表
        /// </summary>
        /// <param name="reducingKeys">降维词表</param>
        public SVMModle(List<string> reducingKeys)
        {
            this.reducingKeys = reducingKeys;
        }
        /// <summary>
        /// 构造函数：不使用降维表
        /// </summary>
        public SVMModle()
        {
        }
        /// <summary>
        /// 相似度计算
        /// </summary>
        /// <param name="text1">文档１（分好词的，分词符为非汉字字符）</param>
        /// <param name="text2">文档２（分好词的，分词符为非汉字字符）</param>
        /// <returns>两篇文章的相似度</returns>
        public double Similarity(string text1, string text2)
        {
            double similarity = 0.0, numerator = 0.0, denominator1 = 0.0, denominator2 = 0.0;
            int temp1, temp2;
            Dictionary<string, int> dictionary1 = GetDictionary(text1);
            Dictionary<string, int> dictionary2 = GetDictionary(text2);
            if ((dictionary1.Count < 1) || (dictionary2.Count < 1))//如果任一篇文章中不含有汉字
            {
                return 0.0;
            }
            Dictionary<string, int>.KeyCollection keys1 = dictionary1.Keys;
            foreach (string key in keys1)
            {
                dictionary1.TryGetValue(key, out temp1);
                if (!dictionary2.TryGetValue(key, out temp2))
                {
                    temp2 = 0;
                }
                dictionary2.Remove(key);
                numerator += temp1 * temp2;
                denominator1 += temp1 * temp1;
                denominator2 += temp2 * temp2;
            }
            Dictionary<string, int>.KeyCollection keys2 = dictionary2.Keys;
            foreach (string key in keys2)
            {
                dictionary2.TryGetValue(key, out temp2);
                denominator2 += temp2 * temp2;
            }
            similarity = numerator / (Math.Sqrt(denominator1 * denominator2));
            return similarity;
        }
        /// <summary>
        /// 相似度计算
        /// </summary>
        /// <param name="text1">第一篇文档的词频词典</param>
        /// <param name="text2">第二篇文档的词频词典</param>
        /// <returns>两篇文档的相似度</returns>
        public double Similarity(Dictionary<string, int> text1, Dictionary<string, int> text2)
        {
            double similarity = 0.0, numerator = 0.0, denominator1 = 0.0, denominator2 = 0.0;
            int temp1, temp2;
            Dictionary<string, int> dictionary1 = new Dictionary<string, int>(text1);
            Dictionary<string, int> dictionary2 = new Dictionary<string, int>(text2);
            if ((dictionary1.Count < 1) || (dictionary2.Count < 1))//如果任一篇文章中不含有汉字
            {
                return 0.0;
            }
            Dictionary<string, int>.KeyCollection keys1 = dictionary1.Keys;
            foreach (string key in keys1)
            {
                dictionary1.TryGetValue(key, out temp1);
                if (!dictionary2.TryGetValue(key, out temp2))
                {
                    temp2 = 0;
                }
                dictionary2.Remove(key);
                numerator += temp1 * temp2;
                denominator1 += temp1 * temp1;
                denominator2 += temp2 * temp2;
            }
            Dictionary<string, int>.KeyCollection keys2 = dictionary2.Keys;
            foreach (string key in keys2)
            {
                dictionary2.TryGetValue(key, out temp2);
                denominator2 += temp2 * temp2;
            }
            similarity = numerator / (Math.Sqrt(denominator1 * denominator2));
            return similarity;
        }
        /// <summary>
        /// 统计文档词频词典
        /// </summary>
        /// <param name="text">已分词文档，分隔符为非汉语字符</param>
        /// <returns>该文档词频词典</returns>
        public Dictionary<string, int> GetDictionary(string text)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            Regex regex = new Regex(@"[\u4e00-\u9fa5]");
            MatchCollection results = regex.Matches(text);
            int temp;
            foreach (Match word in results)
            {
                if (dictionary.TryGetValue(word.Value, out temp))
                {
                    temp++;
                    dictionary.Remove(word.Value);
                    dictionary.Add(word.Value, temp);
                }
                else
                {
                    dictionary.Add(word.Value, 1);
                }
            }
            return dictionary;
        }
    }
}