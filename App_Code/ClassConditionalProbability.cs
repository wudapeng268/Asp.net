using System;
using System.Collections.Generic;
using System.Text;

namespace AspxOn.Search.FenLei
{
    /// <summary>
    /// 条件概率计算
    /// </summary>
    public class ClassConditionalProbability
    {

        private static TrainingDataManager tdm = new TrainingDataManager();
        private static float M = 0F;

        /// <summary>
        /// 类条件概率
        /// </summary>
        /// <param name="x">给定关键字</param>
        /// <param name="c">给定分类</param>
        /// <returns></returns>
        public static float CaculatePxc(string x, string c)
        {
            float ret = 0F;
            float Nxc = tdm.GetCountContainKeyOfClassification(c, x);
            float Nc = tdm.GetTrainFileCountOfCertainClassification(c);
            float V = tdm.GetTrainingClassifications().Length;

            ret = (Nxc + 1) / (Nc + V + M);//为避免出现0这样的极端情况，进行加权处理

            return ret;
        }
    }
}