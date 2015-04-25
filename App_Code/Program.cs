using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspxOn.Search.FenLei;
using System.Diagnostics;

namespace AspxOn.Search.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); //  开始监视代码运行时间
            //  you code ....

            //string s = "微软公司提出以446亿美元的价格收购雅虎中国网2月1日报道 美联社消息，微软公司提出以446亿美元现金加股票的价格收购搜索网站雅虎公司。微软提出以每股31美元的价格收购雅虎。微软的收购报价较雅虎1月31日的收盘价19.18美元溢价62%。微软公司称雅虎公司的股东可以选择以现金或股票进行交易。微软和雅虎公司在2006年底和2007年初已在寻求双方合作。而近两年，雅虎一直处于困境：市场份额下滑、运营业绩不佳、股价大幅下跌。对于力图在互联网市场有所作为的微软来说，收购雅虎无疑是一条捷径，因为双方具有非常强的互补性。(小桥)";
            string s = "今天上午，央行上海总部发布两项细则，启动市场期待已久的上海自贸区自由贸易账户（FTA）。两份文件名为《中国（上海）自由贸易实验区分账核算业务实施细则》和《中国（上海）自由贸易实验区分账核算风险审慎管理细则》。《第一财经日报》记者获取了细则核心内容包括：上海地区的金融机构可以通过建立分账核算单元，为开立自由贸易账户的区内主体提供经常项目、直接投资和投融资创新相关业务的金融服务，以及按准入国民待遇原则为境外机构提供的相关金融服务。同时，明确FT账户为规则统一的本外币账户，区内主体和境外机构可以根据需要开立。上述细则还明确，FTA账户与境外账户、境内区外的非居民机构账户，以及FTA账户之间的资金流动按宏观审慎的原则实施管理。";

            //BayesClassifier byc = new BayesClassifier();
            //List<ClassifyResult> crs = byc.Classify(s);
            //string lei = "";
            //double max = 0;
            //for (int i = 0; i < crs.Count;i++ )
            //{
            //    if(crs[i].probability>max)
            //    {
            //        lei = crs[i].classification;
            //        max = crs[i].probability;
            //    }
            //}
            //Console.Write("属于" + lei + "类");
            //    stopwatch.Stop(); //  停止监视
            //TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            //double hours = timespan.TotalHours; // 总小时
            //double minutes = timespan.TotalMinutes;  // 总分钟
            //double seconds = timespan.TotalSeconds;  //  总秒数
            //double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数
            //Console.Write( milliseconds + "ms");
            //Console.ReadKey();
            

        }
        
    }
}
