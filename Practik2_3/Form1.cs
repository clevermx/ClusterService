using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practik2_3.ServiceReference1;
using System.ServiceModel;

namespace Practik2_3
{
    public partial class Form1 : Form
    {
        
        public static int clusterNum;
        public static int clusterNum2;
        public static List<DataInstance> dataset;
        public static List<DataInstance> dataset2;
        public static int atrNum;
        public static int atrNum2;
        public static string datainfo;
        public static int Rounds =0;
        DateTime dt1, dt2;
        double lAllTime = 0;

        public void ReadData(string path, int rowNumber,out List<DataInstance> data)
        {
            data= new List<DataInstance>();
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                line=sr.ReadLine();
                while (((line = sr.ReadLine()) != null) && rowNumber > 0)
                {
                    var strAtr = line.Split(' ');
                    atrNum = strAtr.Length;
                    double[] atr = new double[strAtr.Length];
                    /* for (int i = 0; i < atr.Length; i++)
                     {
                         double.TryParse(strAtr[i], out atr[i]);
                     }*/

                    double latitude, longtitude;
                    double.TryParse(strAtr[0], out latitude);
                    double.TryParse(strAtr[1], out longtitude);
                    double x, y;
                    //latitude
                    var latRad = latitude * Math.PI / 180;
                    var MercN = Math.Log(Math.Tan((Math.PI / 4) + (latRad / 2)));
                    atr[1] = 180 - (720 * MercN / (2 * Math.PI));

                    //get x from longtitude
                    atr[0] = (longtitude + 180) * 2;

                    DataInstance d = new DataInstance();
                    d.attributes = atr;
                    d.cluster = 0;
                    data.Add(d);
                    rowNumber--;
                }
       
              
                if (rowNumber > 0)
                {
                    MessageBox.Show("Количество строк, указанное вами больше, чем размер файла. Считан весь файл", "Предупреждение", MessageBoxButtons.OK);
                }
            }
        }
     
        public Form1()
        {


            InitializeComponent();
        }

        private void downloadBTN_Click(object sender, EventArgs e)
        {
            ResTB.Clear();
           
      
            int rowNum;
            int.TryParse(countTB.Text, out rowNum);
            ReadData(@"E:\C#\data-mining\input2.txt", rowNum,out dataset);
            panel1.Enabled = true;
          
            backgroundWorker1.WorkerReportsProgress = true;
          
            backgroundWorker1.WorkerSupportsCancellation = true;
            datainfo = "загружено " + dataset.Count() + " сущностей размерности " + dataset[0].attributes.Length;
            drawData(dataset, pictureBox1);
            ResTB.AppendText(datainfo + Environment.NewLine);
            startBTN.Enabled = true;
           
            downloadBTN.Enabled = false;
        }

        private void downloadBTN2_Click(object sender, EventArgs e)
        {
            ResParallelTB.Clear();
            int rowNum;
            int.TryParse(countTB2.Text, out rowNum);
            ReadData(@"E:\C#\data-mining\input2.txt", rowNum, out dataset2);
            panel2.Enabled = true;
            backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;
            string datainfo2= "загружено " + dataset2.Count() + " сущностей размерности " + dataset2[0].attributes.Length;
            drawData(dataset2,pictureBox2);
            ResParallelTB.AppendText(datainfo2);
            startParallelBTN.Enabled = true;
            downloadBTN2.Enabled = false;
        }
        public void drawData(List<DataInstance> data,PictureBox pb)
        {
            double picW = pb.Width-10;
            double picH = pb.Height-10;
   
            Graphics gr = pb.CreateGraphics();
            gr.Clear(Color.White);
            int maxX= 0;
            int maxY = 0;
            int minX = int.MaxValue;
            int minY = int.MaxValue;
            foreach (var item in data)
            {
                if (minX > item.attributes[0])
                {
                    minX = (int)item.attributes[0];
                }
                if (maxX < item.attributes[0])
                {
                    maxX = (int)item.attributes[0];
                }
                if (maxY < item.attributes[1])
                {
                    maxY = (int)item.attributes[1];
                }
                if (minY > item.attributes[1])
                {
                    minY = (int)item.attributes[1];
                }
            }
      

            foreach (var item in data)
            {
                var ClusterCol = Color.FromArgb(item.cluster*40, 255 - item.cluster*40, item.cluster*40);
                 gr.DrawRectangle(new Pen(ClusterCol,3), 5+(int)( (item.attributes[0] -minX)* picW/ (maxX - minX)), 5+(int)( (item.attributes[1]-minY) * picH / (maxY - minY)), 5,5);
            }
        }


      

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;

        }
        private void tb_TextChanged(object sender, EventArgs e)
        {
            if (countTB.Text.Length > 0)
            {
                downloadBTN.Enabled = true;
            }
            else
            {
                downloadBTN.Enabled = false;
            }
        }

        private void SingleWork(object sender, DoWorkEventArgs e)
        {
            lAllTime = 0;
            dt1 = DateTime.Now;
            double accuracy = 0;
            Double.TryParse(accuracyTB.Text,  out accuracy);
           clusterNum=5;


            // Задаём адрес нашей службы
            Uri tcpUri = new Uri("http://localhost:8000/kMeans");
            // Создаём сетевой адрес, с которым клиент будет взаимодействовать
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            // Данный класс используется клиентами для отправки сообщений
            ChannelFactory<IkMeans> factory = new ChannelFactory<IkMeans>(binding, address);
            // Открываем канал для общения клиента с со службой
            IkMeans service = factory.CreateChannel();

            Guid clientGuid = service.RegisterClient(dataset.Count, atrNum);
           for (int i =0; i<dataset.Count;i++)
            {
                service.SendInst(clientGuid, dataset[i]);
            }
            service.DoClusters(clientGuid, clusterNum, accuracy);
            while (!service.isFinished())
            {
            }
            for (int i = 0; i < dataset.Count; i++)
            {
                dataset[i]=service.GetInst(clientGuid, i);
            }
            
            dt2 = DateTime.Now;
            lAllTime = dt2.Millisecond - dt1.Millisecond;
        }

        private void startBTN_Click(object sender, EventArgs e)
        {
            startBTN.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void startParallelBTN_Click(object sender, EventArgs e)
        {
         
            startParallelBTN.Enabled = false;
            backgroundWorker2.RunWorkerAsync();
        }

        private void cancelParallelBTN_Click(object sender, EventArgs e)
        {
            backgroundWorker2.CancelAsync();
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
         
           
            double accuracy = 0;
            Double.TryParse(accuracyTB.Text, out accuracy);
            clusterNum2 = 3;
            atrNum2 = 2;

            // Задаём адрес нашей службы
            Uri tcpUri = new Uri("http://localhost:8000/kMeans");
            // Создаём сетевой адрес, с которым клиент будет взаимодействовать
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            // Данный класс используется клиентами для отправки сообщений
            ChannelFactory<IkMeans> factory = new ChannelFactory<IkMeans>(binding, address);
            // Открываем канал для общения клиента с со службой
            IkMeans service = factory.CreateChannel();

            Guid clientGuid = service.RegisterClient(dataset2.Count, atrNum2);
            for (int i = 0; i < dataset2.Count; i++)
            {
                service.SendInst(clientGuid, dataset2[i]);
            }
            service.DoClusters(clientGuid, clusterNum2, accuracy);
            while (!service.isFinished())
            {
            }
            for (int i = 0; i < dataset2.Count; i++)
            {
                dataset2[i] = service.GetInst(clientGuid, i);
            }
            
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ResParallelTB.AppendText("==================Окончательные результаты===========");
            for (int i = 0; i < clusterNum2; i++)
            {
                ResParallelTB.AppendText(i + "  кластер " + dataset2.Where(x => x.cluster == i).Count() + " элементов");
            }

            
            drawData(dataset2,pictureBox2);
           downloadBTN2.Enabled = true;
        }

        private void SingleComplete(object sender, RunWorkerCompletedEventArgs e)
        {
           
            ResTB.AppendText("==================Окончательные результаты===========");
            for (int i = 0; i < clusterNum; i++)
            {
                ResTB.AppendText(i + "  кластер " + dataset.Where(x=>x.cluster==i).Count() + " элементов");
            }

            lAllTime = (dt2 - dt1).TotalMilliseconds;
            ResTB.AppendText("Затрачено времени:" + lAllTime);
            ResTB.AppendText("Итераций :" + Rounds);
            drawData(dataset,pictureBox1);
            downloadBTN.Enabled = true;
        }

     

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
         
           
       
           /* int[] uState = (int[])e.UserState;
            for (int i = 0; i < clusterNum; i++)
            {
                ResTB.AppendText(i + "  кластер " + uState[i] + " элементов");
            }*/
        }
    }
}
