using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;

using Lucene.Net.Analysis.Cn;
using Lucene.Net.Analysis.KTDictSeg;

using SharpICTCLAS;
using System.IO;
namespace AspxOn.Search.FenLei
{
    /// <summary>
    /// 中文分词器
    /// </summary>
    public class ChineseSpliter
    {
        public static string Split(string text, string splitToken, ICTCLASAnalyzer an, WordSegment wordSegment)
        {
            StringBuilder sb = new StringBuilder();

           // Analyzer an = new ICTCLASAnalyzer();

            //TokenStream ts = an.ReusableTokenStream("", new StringReader(text));

            TokenStream ts = an.TS("", new StringReader(text),wordSegment);

            Lucene.Net.Analysis.Token token;
            while ((token = ts.Next()) != null)
            {
                sb.Append(splitToken + token.TermText());
            }
            try
            {
                return sb.ToString().Substring(1);
            }
            catch (System.Exception ex)
            {
                return "";
            }
            
        }
    }
}