using System;
using System.Collections.Generic;
using System.Text;

namespace AspxOn.Search.FenLei
{
    /// <summary>
    /// 先验概率（事先概率）计算
    /// </summary>
    public class PriorProbability
    {
        private static TrainingDataManager tdm = new TrainingDataManager();

        /// <summary>
        /// 计算先验概率
        /// </summary>
        /// <param name="c">给定的分类</param>
        /// <returns>给定条件下的先验概率</returns>
        public static float CaculatePc(string c)
        {
            float ret = 0F;
            float Nc = tdm.GetTrainFileCountOfCertainClassification(c);
            float N = tdm.GetTrainFileCount();
            ret = Nc / N;
            return ret;
        }
    }
}