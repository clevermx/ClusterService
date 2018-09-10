using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace ClusterService
{
    [ServiceContract]
    public interface IkMeans
    {
        [OperationContract]
        List<DataInstance> DoClusters(List<DataInstance> pDataset, int pClusterNum, double accuracy);
       void updateMarkers( int clientNum);
        bool computeCenters(double accuracy, int clientNum);

        double dist(DataInstance pD1, DataInstance pD2);


    }
}
