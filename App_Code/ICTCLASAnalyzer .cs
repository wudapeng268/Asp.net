using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;

using SharpICTCLAS;
using System.IO;
using System.Web;

namespace AspxOn.Search.FenLei
{

    /// <summary>
    /// ICTCLAS分词组件for Lucene.net接口
    /// </summary>
    public class ICTCLASAnalyzer : Analyzer
    {
        //定义要过滤的词
        public  readonly System.String[] CHINESE_ENGLISH_STOP_WORDS = new string[583];
        public string NoisePath = HttpContext.Current.Request.PhysicalApplicationPath + "\\data\\stopwords572.txt";

        public ICTCLASAnalyzer()
        {
            StreamReader reader = new StreamReader(NoisePath, System.Text.Encoding.Default);
            string noise = reader.ReadLine();
            int i = 0;

            while (!string.IsNullOrEmpty(noise))
            {
                CHINESE_ENGLISH_STOP_WORDS[i] = noise;
                noise = reader.ReadLine();
                i++;
            }

        }

        /**/
        /// Constructs a {@link StandardTokenizer} filtered by a {@link
        /// StandardFilter}, a {@link LowerCaseFilter} and a {@link StopFilter}. 
        /// 
        public override TokenStream TokenStream(System.String fieldName, System.IO.TextReader reader)
        {
            TokenStream result = new ICTCLASTokenizer(reader, null);
            result = new StandardFilter(result);
            result = new LowerCaseFilter(result);
            result = new StopFilter(result, CHINESE_ENGLISH_STOP_WORDS);
            return result;
          
        }

        public TokenStream TS(System.String fieldName,System.IO.TextReader reader,WordSegment wordSegment)
        {
            TokenStream result = new ICTCLASTokenizer(reader, wordSegment);
            result = new StandardFilter(result);
            result = new LowerCaseFilter(result);
            result = new StopFilter(result, CHINESE_ENGLISH_STOP_WORDS);
            return result;
        }


    }
}