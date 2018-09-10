using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace ClusterService
{
    [DataContract]
   public class DataInstance
    {
        [DataMember]
        public double[] attributes;
        [DataMember]
        public int cluster;
        public DataInstance(double[] input, int marker)
        {
            attributes = input;
            cluster = marker;
        }
    }
}
