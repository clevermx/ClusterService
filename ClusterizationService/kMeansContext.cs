using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClusterizationService.kMeans;

namespace ClusterizationService
{
   public class kMeansContext
    {
       public DataInstance[] dataset;
      public int[] clusterCount;
      public DataInstance[] clusterCenter;
      public int clusterNum;
      public int atrNum;
      public double sumDist;
        int CurData;
        int totalData;
        public kMeansContext(int dataCount, int atrCount)
        {  dataset = new DataInstance[dataCount];
            atrNum = atrCount;
            CurData = 0;
            totalData = dataCount;
        }
        public DataInstance getInst(int i)
        {
            if (i <= CurData)
            {
                return dataset[i];
            }
            else
            {
                return null;
            }
        }
        public bool addInstance(DataInstance d)
        {
            if (CurData == totalData)
            {
                return false;
            }
            else
            {
                dataset[CurData] = d;
                CurData++;
                return true;
            }
        }
        public void SetClusterCount(int pClusterNum)
        {
            clusterNum = pClusterNum;
            clusterNum++;
            clusterCenter = new DataInstance[clusterNum];
            clusterCount = new int[clusterNum];
            clusterCount[0] = dataset.Length;
        }
        public void MakeRndCenters(MyDataComparer cmp)
        {
            var DistData = dataset.Distinct(cmp).ToList();
            Random r = new Random();
            for (int i = 1; i < clusterNum; i++)
            {
                int rnd = r.Next(1, DistData.Count - 1);
                clusterCenter[i] = DistData[rnd];
                DistData.RemoveAt(rnd);
            }
            clusterCenter[0] = null;
            sumDist = 10000;
        }
    }
}
