using System;
using System.Collections.Generic;
using System.Text;

using Lucene.Net.Analysis;
using SharpICTCLAS;
using System.IO;

namespace AspxOn.Search.FenLei
{
    public class ICTCLASTokenizer : Tokenizer
    {
        int nKind = 1;
        List<WordResult[]> result;
        int startIndex = 0;
        int endIndex = 0;
        int i = 1;
        /**/
        /// 
        /// 待分词的句子
        /// 
        private string sentence;
        /**/
        /// Constructs a tokenizer for this Reader. 
        public ICTCLASTokenizer(System.IO.TextReader reader, WordSegment wordSegment)
        {

        //    this.input = reader;
            sentence = reader.ReadToEnd();
            sentence = sentence.Replace("\r\n", "");
            sentence = sentence.Replace("&nbsp", "");
            result = wordSegment.Segment(sentence, nKind);
        }
     

        /**/
        /// 进行切词，返回数据流中下一个token或者数据流为空时返回null
        /// 
        public override Token Next()
        {
            Token token = null;
            while (i < result[0].Length - 1)
            {
                string word = result[0][i].sWord;
                endIndex = startIndex + word.Length - 1;
                token = new Token(word, startIndex, endIndex);
                startIndex = endIndex + 1;

                i++;
                return token;

            }
            return null;
        }

    }
}