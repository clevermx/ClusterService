using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace ClusterizationService
{
    [ServiceContract]
    public interface IkMeans
    {
        [OperationContract]
        void DoClusters(Guid client, int pClusterNum, double accuracy);

        [OperationContract]
        DataInstance GetInst(Guid clientNum, int index);
        [OperationContract]
        bool SendInst(Guid clientNum, DataInstance d);
        [OperationContract]
        Guid RegisterClient(int dataCount,int atrCount);
        [OperationContract]
        bool isFinished();
        void updateMarkers(Guid clientNum);
        bool computeCenters(double accuracy, Guid clientNum);

        double dist(DataInstance pD1, DataInstance pD2);


    }
   
}
