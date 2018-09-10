using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClusterService.kMeans;

namespace ClusterService
{
   public class kMeansClient
    {
       public List<DataInstance> dataset;
      public int[] clusterCount;
      public DataInstance[] clusterCenter;
      public int clusterNum;
      public int atrNum;
      public double sumDist;
        public kMeansClient(List<DataInstance> pDataset, int pClusterNum)
        {
             dataset = pDataset;
            clusterNum = pClusterNum;
            atrNum = pDataset[0].attributes.Length;
            clusterNum++;
            clusterCenter = new DataInstance[clusterNum];
            clusterCount = new int[clusterNum];
            clusterCount[0] = dataset.Count;
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
