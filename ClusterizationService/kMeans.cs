using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;
namespace ClusterizationService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
   public class kMeans : IkMeans
    {
     static   Dictionary<Guid,kMeansContext> clients= new Dictionary<Guid, kMeansContext>();

        static bool isFin = false;

        public class MyDataComparer : IEqualityComparer<DataInstance>
        {
            public bool Equals(DataInstance x, DataInstance y)
            {
                for (int i = 0; i < x.attributes.Length; i++)
                {
                    if (x.attributes[i] != y.attributes[i])
                    {
                        return false;
                    }
                }
                return true;
            }

            public int GetHashCode(DataInstance obj)
            {
                return 1;
            }
        }
        //евклидово расстояние
       public double dist(DataInstance pD1, DataInstance pD2)
        {
            double d = 0;
            for (int i = 0; i < pD1.attributes.Length; i++)
            {
                d = d + Math.Pow(pD1.attributes[i] - pD2.attributes[i], 2);
            }
            return Math.Sqrt(d);
        }
        public bool computeCenters(double accuracy, Guid clientNum)
        {
            DataInstance[] lCenters = new DataInstance[clients[clientNum].clusterNum];
            for (int i = 1; i < clients[clientNum].clusterNum; i++)
            {
                double[] centAtr = new double[clients[clientNum].atrNum];
                lCenters[i] = new DataInstance(centAtr, i + 1);

            }
            foreach (var item in clients[clientNum].dataset)
            {
                for (int i = 0; i < item.attributes.Length; i++)
                {
                    lCenters[item.cluster].attributes[i] += item.attributes[i];
                }
            }
            double locSum = 0;
            for (int CurCent = 1; CurCent < clients[clientNum].clusterNum; CurCent++)
            {
                for (int i = 0; i < clients[clientNum].atrNum; i++)
                {
                    if (clients[clientNum].clusterCount[CurCent] != 0)
                    {
                        lCenters[CurCent].attributes[i] = lCenters[CurCent].attributes[i] / clients[clientNum].clusterCount[CurCent];
                    }
                }
                locSum += dist(lCenters[CurCent], clients[clientNum].clusterCenter[CurCent]);
            }
            clients[clientNum].clusterCenter = lCenters;
            if (Math.Abs(locSum - clients[clientNum].sumDist) <= accuracy)
            {


                return true;
            }
            else
            {
                clients[clientNum].sumDist = locSum;
                return false;
            }
        }

        public void DoClusters(Guid client, int pClusterNum, double accuracy= 0.1 )
        {
            Console.WriteLine("зашёл в метод");
            kMeansContext lCurClient = clients[client];
            lCurClient.SetClusterCount(pClusterNum);
            Console.WriteLine("создал контекст");
            MyDataComparer cmp = new MyDataComparer();
            lCurClient.MakeRndCenters(cmp);
            Console.WriteLine("сделал рандомные центры");
            updateMarkers(client);
            while (!computeCenters(accuracy,client))
            {
                updateMarkers(client);
            }
            Console.WriteLine("закончил работать");
            isFin = true;
         
        }

        public void updateMarkers(Guid clientNum)
        {
            foreach (DataInstance item in clients[clientNum].dataset)
            {
                double distToCur = item.cluster == 0 ? double.MaxValue : dist(item, clients[clientNum].clusterCenter[item.cluster]);
                for (int j = 1; j < clients[clientNum].clusterNum; j++)
                {
                    double distToNew = dist(item, clients[clientNum].clusterCenter[j]);
                    if (distToCur > distToNew)
                    {
                        clients[clientNum].clusterCount[item.cluster]--;
                        item.cluster = j;
                        clients[clientNum].clusterCount[j]++;
                        distToCur = distToNew;
                    }
                }
            }
        }

        public bool isFinished()
        {
            return isFin;
        }

        public DataInstance GetInst(Guid clientNum,int index)
        {
            return clients[clientNum].getInst(index);
        }

        public bool SendInst(Guid clientNum, DataInstance d)
        {
            return clients[clientNum].addInstance(d);
        }

        public Guid RegisterClient(int dataCount, int atrCount)
        {
            kMeansContext lCont = new kMeansContext(dataCount, atrCount);
            Guid ClientGuid = Guid.NewGuid();
            clients.Add(ClientGuid, lCont);
            return ClientGuid;
        }

    
    }
}
