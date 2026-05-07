using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using Microsoft.Kinect;
using ZedGraph;

namespace 姿态采集
{
    public partial class Form1 : Form
    {
		//private Body _body3;
		#region 保存
		public string uwbdata = ""; //保存数据
        #endregion 保存

        #region kinect
        #region Member Variables
        //体感器设备
        private KinectSensor _KinectDevice;

		//骨骼图像
		//骨骼帧读取变量
		private BodyFrameReader _BodyFrameReader;

		//玩家数据
		private Body[] _Bodies;

		//主要的玩家
		private Body _PrimaryBody;

		//数据保存
		private StreamWriter _SW;
		private StreamWriter _SW2;
		//private StreamWriter _SW3;

		//保存路径
		private string _CoordinatePath;

		//是否保存开关
		private bool _IsSave;
		private bool _close;
		private bool _close1;
		#endregion Member Variables

		#endregion kinect

		#region design

		private delegate void AddItemDelegate(System.Windows.Forms.ListBox listbox, string text);

		private delegate void ClearTextBoxDelegate();

		private UdpClient receiveUdpClient;

		private UdpClient receiveUdpClient1;

		private UdpClient receiveUdpClient2;

		private UdpClient receiveUdpClient3;

		private UdpClient receiveUdpClient4;

		private UdpClient receiveUdpClient5;

		private UdpClient receiveUdpClient6;

		private UdpClient receiveUdpClient7;

		private UdpClient receiveUdpClient8;

		private UdpClient receiveUdpClient9;

		private UdpClient receiveUdpClient10;

		private UdpClient receiveUdpClient11;

		private UdpClient receiveUdpClient12;

		private UdpClient receiveUdpClient13;

		private UdpClient receiveUdpClient14;

		private UdpClient sendUdpClient;

		private UdpClient sendUdpClient1;

		private UdpClient sendUdpClient2;

		private UdpClient sendUdpClient3;

		private UdpClient sendUdpClient4;

		private UdpClient sendUdpClient5;

		private UdpClient sendUdpClient6;

		private UdpClient sendUdpClient7;

		private UdpClient sendUdpClient8;

		private UdpClient sendUdpClient9;

		private UdpClient sendUdpClient10;

		private UdpClient sendUdpClient11;

		private UdpClient sendUdpClient12;

		private UdpClient sendUdpClient13;

		private UdpClient sendUdpClient14;

		
		private const int port = 1;

		private IPAddress ip;

		private IPAddress remoteIp;

		private string Auto_IP;

		private string readset;

		private int readsetnum;

		private string[] setfile1 = new string[100000];

		private string[] setfile2 = new string[100000];

		private byte[] result = new byte[7];

		private double[] Data = new double[4];

		private byte[] arrServerRecMsg = new byte[1048576];

		private double[] Data1 = new double[4];

		private byte[] arrServerRecMsg1 = new byte[1048576];

		private double[] Data2 = new double[4];

		private byte[] arrServerRecMsg2 = new byte[1048576];

		private double[] Data3 = new double[4];

		private byte[] arrServerRecMsg3 = new byte[1048576];

		private double[] Data4 = new double[4];

		private byte[] arrServerRecMsg4 = new byte[1048576];

		private double[] Data5 = new double[4];

		private byte[] arrServerRecMsg5 = new byte[1048576];

		private double[] Data6 = new double[4];

		private byte[] arrServerRecMsg6 = new byte[1048576];

		private double[] Data7 = new double[4];

		private byte[] arrServerRecMsg7 = new byte[1048576];

		private double[] Data8 = new double[4];

		private double[] Data8A = new double[4];

		private double[] Data8W = new double[4];

		private byte[] arrServerRecMsg8 = new byte[1048576];

		private double[] Data9 = new double[4];

		private double[] Data9A = new double[4];

		private double[] Data9W = new double[4];

		private byte[] arrServerRecMsg9 = new byte[1048576];

		private double[] Data10 = new double[4];

		private double[] Data10A = new double[4];

		private double[] Data10W = new double[4];

		private byte[] arrServerRecMsg10 = new byte[1048576];

		private double[] Data11 = new double[4];

		private double[] Data11A = new double[4];

		private double[] Data11W = new double[4];

		private byte[] arrServerRecMsg11 = new byte[1048576];

		private double[] Data12 = new double[4];

		private double[] Data12A = new double[4];

		private double[] Data12W = new double[4];

		private byte[] arrServerRecMsg12 = new byte[1048576];

		private double[] Data13 = new double[4];

		private double[] Data13A = new double[4];

		private double[] Data13W = new double[4];

		private byte[] arrServerRecMsg13 = new byte[1048576];

		private double[] Data14 = new double[4];

		private double[] Data14A = new double[4];

		private double[] Data14W = new double[4];

		private byte[] arrServerRecMsg14 = new byte[1048576];

		private IPEndPoint remote1;

		private IPEndPoint remote2;

		private IPEndPoint remote3;

		private IPEndPoint remote4;

		private IPEndPoint remote5;

		private IPEndPoint remote6;

		private IPEndPoint remote7;

		private IPEndPoint remote8;

		private IPEndPoint remote9;

		private IPEndPoint remote10;

		private IPEndPoint remote11;

		private IPEndPoint remote12;

		private IPEndPoint remote13;

		private IPEndPoint remote14;

		private IPEndPoint remote15;

		//private IPEndPoint UDP_conn0;

		private bool exit1 = false;

		private bool exit2 = false;

		private bool exit3 = false;

		private bool exit4 = false;

		private bool exit5 = false;

		private bool exit6 = false;

		private bool exit7 = false;

		private bool exit8 = false;

		private bool exit9 = false;

		private bool exit10 = false;

		private bool exit11 = false;

		private bool exit12 = false;

		private bool exit13 = false;

		private bool exit14 = false;

		private bool exit15 = false;

        #region design

        private double offset_x_0;

        private double offset_y_0;

        private double offset_z_0;

        private double offset_x_1;

        private double offset_y_1;

        private double offset_z_1;

        private double offset_x_2;

        private double offset_y_2;

        private double offset_z_2;

        private double offset_x_3;

        private double offset_y_3;

        private double offset_z_3;

        private double offset_x_4;

        private double offset_y_4;

        private double offset_z_4;

        private double offset_x_5;

        private double offset_y_5;

        private double offset_z_5;

        private double offset_x_6;

        private double offset_y_6;

        private double offset_z_6;

        private double offset_x_7;

        private double offset_y_7;

        private double offset_z_7;

        private double offset_x_8;

        private double offset_y_8;

        private double offset_z_8;

        private double offset_x_9;

        private double offset_y_9;

        private double offset_z_9;

        private double offset_x_10;

        private double offset_y_10;

        private double offset_z_10;

        private double offset_x_11;

        private double offset_y_11;

        private double offset_z_11;

        private double offset_x_12;

        private double offset_y_12;

        private double offset_z_12;

        private double offset_x_13;

        private double offset_y_13;

        private double offset_z_13;

        private double offset_x_14;

        private double offset_y_14;

        private double offset_z_14;

        #endregion design

        private string Ax1;

		private string Ay1;

		private string Az1;

		private string Wx1;

		private string Wy1;

		private string Wz1;

		private string Angle_x1;

		private string Angle_y1;

		private string Angle_z1;

		private string Mx1;

		private string My1;

		private string Mz1;

		private string Mx2;

		private string My2;

		private string Mz2;

		private string Mx3;

		private string My3;

		private string Mz3;

		private string Mx4;

		private string My4;

		private string Mz4;

		private string Mx5;

		private string My5;

		private string Mz5;

		private string Mx6;

		private string My6;

		private string Mz6;

		private string Mx7;

		private string My7;

		private string Mz7;

		private string Mx8;

		private string My8;

		private string Mz8;

		private string Mx9;

		private string My9;

		private string Mz9;

		private string Mx10;

		private string My10;

		private string Mz10;

		private string Mx11;

		private string My11;

		private string Mz11;

		private string Mx12;

		private string My12;

		private string Mz12;

		private string Mx13;

		private string My13;

		private string Mz13;

		private string Mx14;

		private string My14;

		private string Mz14;

		private string Mx15;

		private string My15;

		private string Mz15;

		private double[] AData1 = new double[3];

		private double[] WData1 = new double[3];

		private double[] MData1 = new double[3];

		private double[] AData2 = new double[3];

		private double[] WData2 = new double[3];

		private double[] MData2 = new double[3];

		private double[] AData3 = new double[3];

		private double[] WData3 = new double[3];

		private double[] MData3 = new double[3];

		private double[] AData4 = new double[3];

		private double[] WData4 = new double[3];

		private double[] MData4 = new double[3];

		private double[] AData5 = new double[3];

		private double[] WData5 = new double[3];

		private double[] MData5 = new double[3];

		private double[] AData6 = new double[3];

		private double[] WData6 = new double[3];

		private double[] MData6 = new double[3];

		private double[] AData7 = new double[3];

		private double[] WData7 = new double[3];

		private double[] MData7 = new double[3];

		private double[] AData8 = new double[3];

		private double[] WData8 = new double[3];

		private double[] MData8 = new double[3];

		private double[] AData9 = new double[3];

		private double[] WData9 = new double[3];

		private double[] MData9 = new double[3];

		private double[] AData10 = new double[3];

		private double[] WData10 = new double[3];

		private double[] MData10 = new double[3];

		private double[] AData11 = new double[3];

		private double[] WData11 = new double[3];

		private double[] MData11 = new double[3];

		private double[] AData12 = new double[3];

		private double[] WData12 = new double[3];

		private double[] MData12 = new double[3];

		private double[] AData13 = new double[3];

		private double[] WData13 = new double[3];

		private double[] MData13 = new double[3];

		private double[] AData14 = new double[3];

		private double[] WData14 = new double[3];

		private double[] MData14 = new double[3];

		private double[] AData15 = new double[3];

		private double[] WData15 = new double[3];

		private double[] MData15 = new double[3];

		private int test = 0;

		private bool first_tst = false;

		private string Ax2;

		private string Ay2;

		private string Az2;

		private string Wx2;

		private string Wy2;

		private string Wz2;

		private string Angle_x2;

		private string Angle_y2;

		private string Angle_z2;

		private bool first_tst_2 = false;

		private string Ax3;

		private string Ay3;

		private string Az3;

		private string Wx3;

		private string Wy3;

		private string Wz3;

		private string Angle_x3;

		private string Angle_y3;

		private string Angle_z3;

		private bool first_tst_3 = false;

		private string Ax4;

		private string Ay4;

		private string Az4;

		private string Wx4;

		private string Wy4;

		private string Wz4;

		private string Angle_x4;

		private string Angle_y4;

		private string Angle_z4;

		private bool first_tst_4 = false;

		private string Ax5;

		private string Ay5;

		private string Az5;

		private string Wx5;

		private string Wy5;

		private string Wz5;

		private string Angle_x5;

		private string Angle_y5;

		private string Angle_z5;

		private byte[] gloveRxBuffer = new byte[1000];

		//private ushort gloveusRxLength = 0;

		private byte[] glovebyteTemp = new byte[1000];

		private byte[] gloveresult = new byte[7];

		private double[] gloveData = new double[4];

		private byte[] LgloveRxBuffer = new byte[1000];

		//private ushort LgloveusRxLength = 0;

		private byte[] LglovebyteTemp = new byte[1000];

		private byte[] Lgloveresult = new byte[7];

		private double[] LgloveData = new double[4];

		private byte[] active = new byte[5];

		private double[] scroll_offset_Xall = new double[15];

		private double[] scroll_offset_Yall = new double[15];

		private double[] scroll_offset_Zall = new double[15];		

		private UdpClient sendUdpClient_public;

		private IPEndPoint iep_public;

		private byte[] read_RE = new byte[47];

		public Worksheet xSheel;

		private bool Excel_start = false;

		private int excel_cnt = 0;

		private bool first_tst_5 = false;

		private string Ax6;

		private string Ay6;

		private string Az6;

		private string Wx6;

		private string Wy6;

		private string Wz6;

		private string Angle_x6;

		private string Angle_y6;

		private string Angle_z6;

		private bool first_tst_6 = false;

		private string Ax7;

		private string Ay7;

		private string Az7;

		private string Wx7;

		private string Wy7;

		private string Wz7;

		private string Angle_x7;

		private string Angle_y7;

		private string Angle_z7;

		private bool first_tst_7 = false;

		private string Ax8;

		private string Ay8;

		private string Az8;

		private string Wx8;

		private string Wy8;

		private string Wz8;

		private string Angle_x8;

		private string Angle_y8;

		private string Angle_z8;

		private bool first_tst_8 = false;

		private string Ax9;

		private string Ay9;

		private string Az9;

		private string Wx9;

		private string Wy9;

		private string Wz9;

		private string Angle_x9;

		private string Angle_y9;

		private string Angle_z9;

		private bool first_tst_9 = false;

		private string Ax10;

		private string Ay10;

		private string Az10;

		private string Wx10;

		private string Wy10;

		private string Wz10;

		private string Angle_x10;

		private string Angle_y10;

		private string Angle_z10;

		private bool first_tst_10 = false;

		private string Ax11;

		private string Ay11;

		private string Az11;

		private string Wx11;

		private string Wy11;

		private string Wz11;

		private string Angle_x11;

		private string Angle_y11;

		private string Angle_z11;

		private bool first_tst_11 = false;

		private string Ax12;

		private string Ay12;

		private string Az12;

		private string Wx12;

		private string Wy12;

		private string Wz12;

		private string Angle_x12;

		private string Angle_y12;

		private string Angle_z12;

		private bool first_tst_12 = false;

		private string Ax13;

		private string Ay13;

		private string Az13;

		private string Wx13;

		private string Wy13;

		private string Wz13;

		private string Angle_x13;

		private string Angle_y13;

		private string Angle_z13;

		private bool first_tst_13 = false;

		private string Ax14;

		private string Ay14;

		private string Az14;

		private string Wx14;

		private string Wy14;

		private string Wz14;

		private string Angle_x14;

		private string Angle_y14;

		private string Angle_z14;

		private bool first_tst_14 = false;

		private string Ax15;

		private string Ay15;

		private string Az15;

		private string Wx15;

		private string Wy15;

		private string Wz15;

		private string Angle_x15;

		private string Angle_y15;

		private string Angle_z15;

		private bool first_tst_15 = false;



        //private bool sflag = false;

        private double scroll_ofset_x_0;

        private double scroll_ofset_x_1;

        private double scroll_ofset_x_2;

        private double scroll_ofset_x_3;

        private double scroll_ofset_x_4;

        private double scroll_ofset_x_5;

        private double scroll_ofset_x_6;

        private double scroll_ofset_x_7;

        private double scroll_ofset_x_8;

        private double scroll_ofset_x_9;

        private double scroll_ofset_x_10;

        private double scroll_ofset_x_11;

        private double scroll_ofset_x_12;

        private double scroll_ofset_x_13;

        private double scroll_ofset_x_14;

        private double scroll_ofset_y_0;

        private double scroll_ofset_y_1;

        private double scroll_ofset_y_2;

        private double scroll_ofset_y_3;

        private double scroll_ofset_y_4;

        private double scroll_ofset_y_5;

        private double scroll_ofset_y_6;

        private double scroll_ofset_y_7;

        private double scroll_ofset_y_8;

        private double scroll_ofset_y_9;

        private double scroll_ofset_y_10;

        private double scroll_ofset_y_11;

        private double scroll_ofset_y_12;

        private double scroll_ofset_y_13;

        private double scroll_ofset_y_14;

        private double scroll_ofset_z_0;

        private double scroll_ofset_z_1;

        private double scroll_ofset_z_2;

        private double scroll_ofset_z_3;

        private double scroll_ofset_z_4;

        private double scroll_ofset_z_5;

        private double scroll_ofset_z_6;

        private double scroll_ofset_z_7;

        private double scroll_ofset_z_8;

        private double scroll_ofset_z_9;

        private double scroll_ofset_z_10;

        private double scroll_ofset_z_11;

        private double scroll_ofset_z_12;

        private double scroll_ofset_z_13;

        private double scroll_ofset_z_14;

        private double record_JS = 0;

		private byte[] RxBuffer = new byte[1000];

        #endregion design

        //定时器刷新曲线
        System.Windows.Forms.Timer ChartTimer;
		System.Windows.Forms.Timer ChartTimer1;
		//时间
		int time = 30;
		int time1 = 30;
		//记录曲线值
		PointPairList vlist = new PointPairList();
		PointPairList vlist2 = new PointPairList();
		PointPairList vlist3 = new PointPairList();

		PointPairList vlist4 = new PointPairList();
		PointPairList vlist5 = new PointPairList();
		PointPairList vlist6 = new PointPairList();
		public Form1()
        {
            InitializeComponent();
			//获取默认的连接的体感器
			this._KinectDevice = KinectSensor.GetDefault();

			//骨骼变量初始化
			this._BodyFrameReader = this._KinectDevice.BodyFrameSource.OpenReader();

			//触发骨骼帧处理事件
			this._BodyFrameReader.FrameArrived += _BodyFrameReader_FrameArrived;

			//玩家骨骼数组长度为6
			this._Bodies = new Body[6];
			//启动体感器
			this._KinectDevice.Open();

			//默认不保存坐标
			_IsSave = false;
			_close = false;
			_close1 = false;
			//初始化ZedGraph
			InitZedGraph();
			InitZedGraph1();
			ChartTimer = new System.Windows.Forms.Timer()
			{
				Interval = 300,
			};
			ChartTimer.Tick += ChartTimer_Tick;
			ChartTimer.Start();

			ChartTimer1 = new System.Windows.Forms.Timer()
			{
				Interval = 300,
			};
			 ChartTimer1.Tick += ChartTimer1_Tick;
			ChartTimer1.Start();
		}
		#region 初始化图表控件
		private void InitZedGraph1()
        {
			GraphPane myPane1 = myZedgraph1.GraphPane;
			myPane1.IsAlignGrids = true;
			myPane1.Title.Text = "Kinect";
			myPane1.XAxis.Title.Text = "时间";
			myPane1.YAxis.Title.Text = "相对相机位置";

			for (int i = 0; i < 30; i++)
			{
				double time = (double)i;
				//double acceleration = 2.0;
				double velocity = 0;
				vlist4.Add(time, velocity);
				vlist5.Add(time, velocity);
				vlist6.Add(time, velocity);
			}

			//生成一条红色的菱形样式曲线，将曲线和值vlist绑定
			//生成速度图例

			LineItem myCurve4 = myPane1.AddCurve("", vlist4, Color.Red, SymbolType.Diamond);
			LineItem myCurve5 = myPane1.AddCurve("", vlist5, Color.Blue, SymbolType.Diamond);
			LineItem myCurve6 = myPane1.AddCurve("", vlist6, Color.Green, SymbolType.Diamond);

			//填充白色
			myCurve4.Symbol.Fill = new Fill(Color.White);
			myCurve5.Symbol.Fill = new Fill(Color.White);
			myCurve6.Symbol.Fill = new Fill(Color.White);

			//显示X的网格线
			myPane1.XAxis.MajorGrid.IsVisible = true;

			//设置Y轴刻度为红色
			myPane1.YAxis.Scale.FontSpec.FontColor = Color.Red;
			myPane1.YAxis.Title.FontSpec.FontColor = Color.Black;

			// 不显示Y轴的0刻度线
			myPane1.YAxis.MajorGrid.IsZeroLine = false;
			myPane1.YAxis.MajorGrid.IsVisible = true;
			myPane1.YAxis.MajorGrid.Color = Color.Black;

			//设置刻度范围
			myPane1.YAxis.Scale.Align = AlignP.Inside;
			myPane1.YAxis.Scale.Max = 3;
			myPane1.YAxis.Scale.MaxAuto = true;

			//设置chart的背景颜色
			myPane1.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);

			//刷新轴
			myZedgraph1.AxisChange();
		}
		#endregion

		#region 初始化图表控件
		private void InitZedGraph()
		{
			GraphPane myPane = myZedgraph.GraphPane;
			myPane.IsAlignGrids = true;
			myPane.Title.Text = "IMU";
			myPane.XAxis.Title.Text = "时间";
			myPane.YAxis.Title.Text = "姿态角";


			for (int i = 0; i < 30; i++)
			{
				double time = (double)i;
				//double acceleration = 2.0;
				double velocity = 0;
				vlist.Add(time, velocity);
				vlist2.Add(time, velocity);
				vlist3.Add(time, velocity);
			}

			//生成一条红色的菱形样式曲线，将曲线和值vlist绑定
			//生成速度图例
			
			LineItem myCurve = myPane.AddCurve("", vlist, Color.Red, SymbolType.Diamond);
			LineItem myCurve2 = myPane.AddCurve("", vlist2, Color.Blue, SymbolType.Diamond);
			LineItem myCurve3 = myPane.AddCurve("", vlist3, Color.Green, SymbolType.Diamond);


			//填充白色
			myCurve.Symbol.Fill = new Fill(Color.White);


			//显示X的网格线
			myPane.XAxis.MajorGrid.IsVisible = true;

			//设置Y轴刻度为红色
			myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
			myPane.YAxis.Title.FontSpec.FontColor = Color.Red;

			//隐藏Y轴对面的刻度显示
			myPane.YAxis.MajorTic.IsOpposite = false;
			myPane.YAxis.MinorTic.IsOpposite = false;

			// 不显示Y轴的0刻度线
			myPane.YAxis.MajorGrid.IsZeroLine = false;
			myPane.YAxis.MajorGrid.IsVisible = true;
			myPane.YAxis.MajorGrid.Color = Color.Red;

			//设置刻度范围
			myPane.YAxis.Scale.Align = AlignP.Inside;
			myPane.YAxis.Scale.Max = 100;
			myPane.YAxis.Scale.MaxAuto = true;


			//设置chart的背景颜色
			myPane.Chart.Fill = new Fill(Color.White, Color.White, 45.0f);

			//刷新轴
			myZedgraph.AxisChange();
		}
		#endregion



		private void ChartTimer1_Tick(object sender, EventArgs e)
		{
			if (comboBox2.Text == "头部")
			{
				if (_PrimaryBody != null)
				{
					Joint head = _PrimaryBody.Joints[JointType.Head];
					textBoxk1.Text = Math.Round(head.Position.X, 1).ToString();
					textBoxk2.Text = Math.Round(head.Position.Y, 1).ToString();
					textBoxk3.Text = Math.Round(head.Position.Z, 1).ToString();

					double v4 = Double.Parse(textBoxk1.Text);
					double v5 = Double.Parse(textBoxk2.Text);
					double v6 = Double.Parse(textBoxk3.Text);
					//添加新的数据
					vlist4.Add(time1, v4);
					vlist5.Add(time1, v5);
					vlist6.Add(time1, v6);
					//每个点的时间间隔
					time1 += 2;

					#region 方法
					if (vlist4.Count >= 30)
					{
						//更新X轴的显示范围
						myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
						//每个点的时间间隔
						myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
					}
					if (vlist5.Count >= 30)
					{//更新X轴的显示范围

						myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
						//每个点的时间间隔
						myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
					}
					if (vlist6.Count >= 30)
					{//更新X轴的显示范围

						myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
						//每个点的时间间隔
						myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
					}
					#endregion
					//曲线刷新
					myZedgraph1.AxisChange();
					myZedgraph1.Refresh();
				}
			}
				//右肩
				if (comboBox2.Text == "右肩")
				{
					if (_PrimaryBody != null)
					{
						Joint ShoulderR = _PrimaryBody.Joints[JointType.ShoulderRight];
						textBoxk4.Text = Math.Round(ShoulderR.Position.X, 1).ToString();
						textBoxk5.Text = Math.Round(ShoulderR.Position.Y, 1).ToString();
						textBoxk6.Text = Math.Round(ShoulderR.Position.Z, 1).ToString();

						double v4 = Double.Parse(textBoxk4.Text);
						double v5 = Double.Parse(textBoxk5.Text);
						double v6 = Double.Parse(textBoxk6.Text);
						//添加新的数据
						vlist4.Add(time1, v4);
						vlist5.Add(time1, v5);
						vlist6.Add(time1, v6);
						//每个点的时间间隔
						time1 += 2;

						#region 方法
						if (vlist4.Count >= 30)
						{
							//更新X轴的显示范围
							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist5.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist6.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						#endregion
						//曲线刷新
						myZedgraph1.AxisChange();
						myZedgraph1.Refresh();
					}
				}
				//左肩
				if (comboBox2.Text == "左肩")
				{
					if (_PrimaryBody != null)
					{
						Joint ShoulderL = _PrimaryBody.Joints[JointType.ShoulderLeft];
						textBoxk7.Text = Math.Round(ShoulderL.Position.X, 1).ToString();
						textBoxk8.Text = Math.Round(ShoulderL.Position.Y, 1).ToString();
						textBoxk9.Text = Math.Round(ShoulderL.Position.Z, 1).ToString();

						double v4 = Double.Parse(textBoxk7.Text);
						double v5 = Double.Parse(textBoxk8.Text);
						double v6 = Double.Parse(textBoxk9.Text);
						//添加新的数据
						vlist4.Add(time1, v4);
						vlist5.Add(time1, v5);
						vlist6.Add(time1, v6);
						//每个点的时间间隔
						time1 += 2;

						#region 方法
						if (vlist4.Count >= 30)
						{
							//更新X轴的显示范围
							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist5.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist6.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						#endregion
						//曲线刷新
						myZedgraph1.AxisChange();
						myZedgraph1.Refresh();
					}
				}
				//右肘
				if (comboBox2.Text == "右肘")
				{
					if (_PrimaryBody != null)
					{
						Joint ElbowR = _PrimaryBody.Joints[JointType.ElbowRight];
						textBoxk10.Text = Math.Round(ElbowR.Position.X, 1).ToString();
						textBoxk11.Text = Math.Round(ElbowR.Position.Y, 1).ToString();
						textBoxk12.Text = Math.Round(ElbowR.Position.Z, 1).ToString();

						double v4 = Double.Parse(textBoxk10.Text);
						double v5 = Double.Parse(textBoxk11.Text);
						double v6 = Double.Parse(textBoxk12.Text);
						//添加新的数据
						vlist4.Add(time1, v4);
						vlist5.Add(time1, v5);
						vlist6.Add(time1, v6);
						//每个点的时间间隔
						time1 += 2;

						#region 方法
						if (vlist4.Count >= 30)
						{
							//更新X轴的显示范围
							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist5.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist6.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						#endregion
						//曲线刷新
						myZedgraph1.AxisChange();
						myZedgraph1.Refresh();
					}
				}
				//左肘
				if (comboBox2.Text == "左肘")
				{
					if (_PrimaryBody != null)
					{
						Joint ElbowL = _PrimaryBody.Joints[JointType.ElbowLeft];
						textBoxk13.Text = Math.Round(ElbowL.Position.X, 1).ToString();
						textBoxk14.Text = Math.Round(ElbowL.Position.Y, 1).ToString();
						textBoxk15.Text = Math.Round(ElbowL.Position.Z, 1).ToString();

						double v4 = Double.Parse(textBoxk13.Text);
						double v5 = Double.Parse(textBoxk14.Text);
						double v6 = Double.Parse(textBoxk15.Text);
						//添加新的数据
						vlist4.Add(time1, v4);
						vlist5.Add(time1, v5);
						vlist6.Add(time1, v6);
						//每个点的时间间隔
						time1 += 2;

						#region 方法
						if (vlist4.Count >= 30)
						{
							//更新X轴的显示范围
							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist5.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist6.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						#endregion
						//曲线刷新
						myZedgraph1.AxisChange();
						myZedgraph1.Refresh();
					}
				}
				//右手腕
				if (comboBox2.Text == "右手腕")
				{
					if (_PrimaryBody != null)
					{
						Joint WristR = _PrimaryBody.Joints[JointType.WristRight];
						textBoxk16.Text = Math.Round(WristR.Position.X, 1).ToString();
						textBoxk17.Text = Math.Round(WristR.Position.Y, 1).ToString();
						textBoxk18.Text = Math.Round(WristR.Position.Z, 1).ToString();

						double v4 = Double.Parse(textBoxk16.Text);
						double v5 = Double.Parse(textBoxk17.Text);
						double v6 = Double.Parse(textBoxk18.Text);
						//添加新的数据
						vlist4.Add(time1, v4);
						vlist5.Add(time1, v5);
						vlist6.Add(time1, v6);
						//每个点的时间间隔
						time1 += 2;

						#region 方法
						if (vlist4.Count >= 30)
						{
							//更新X轴的显示范围
							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist5.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist6.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						#endregion
						//曲线刷新
						myZedgraph1.AxisChange();
						myZedgraph1.Refresh();
					}
				}
				//左手腕
				if (comboBox2.Text == "左手腕")
				{
					if (_PrimaryBody != null)
					{
						Joint _WristL = _PrimaryBody.Joints[JointType.WristLeft];
						textBoxk19.Text = Math.Round(_WristL.Position.X, 1).ToString();
						textBoxk20.Text = Math.Round(_WristL.Position.Y, 1).ToString();
						textBoxk21.Text = Math.Round(_WristL.Position.Z, 1).ToString();

						double v4 = Double.Parse(textBoxk19.Text);
						double v5 = Double.Parse(textBoxk20.Text);
						double v6 = Double.Parse(textBoxk21.Text);
						//添加新的数据
						vlist4.Add(time1, v4);
						vlist5.Add(time1, v5);
						vlist6.Add(time1, v6);
						//每个点的时间间隔
						time1 += 2;

						#region 方法
						if (vlist4.Count >= 30)
						{
							//更新X轴的显示范围
							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist5.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist6.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						#endregion
						//曲线刷新
						myZedgraph1.AxisChange();
						myZedgraph1.Refresh();
					}
				}
				//右膝盖
				if (comboBox2.Text == "右膝盖")
				{
					if (_PrimaryBody != null)
					{
						Joint KneeR = _PrimaryBody.Joints[JointType.KneeRight];
						textBoxk22.Text = Math.Round(KneeR.Position.X, 1).ToString();
						textBoxk23.Text = Math.Round(KneeR.Position.Y, 1).ToString();
						textBoxk24.Text = Math.Round(KneeR.Position.Z, 1).ToString();

						double v4 = Double.Parse(textBoxk22.Text);
						double v5 = Double.Parse(textBoxk23.Text);
						double v6 = Double.Parse(textBoxk24.Text);
						//添加新的数据
						vlist4.Add(time1, v4);
						vlist5.Add(time1, v5);
						vlist6.Add(time1, v6);
						//每个点的时间间隔
						time1 += 2;

						#region 方法
						if (vlist4.Count >= 30)
						{
							//更新X轴的显示范围
							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist5.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist6.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						#endregion
						//曲线刷新
						myZedgraph1.AxisChange();
						myZedgraph1.Refresh();
					}
				}
				//左膝盖
				if (comboBox2.Text == "左膝盖")
				{
					if (_PrimaryBody != null)
					{
						Joint KneeL = _PrimaryBody.Joints[JointType.KneeLeft];
						textBoxk25.Text = Math.Round(KneeL.Position.X, 1).ToString();
						textBoxk26.Text = Math.Round(KneeL.Position.Y, 1).ToString();
						textBoxk27.Text = Math.Round(KneeL.Position.Z, 1).ToString();

						double v4 = Double.Parse(textBoxk25.Text);
						double v5 = Double.Parse(textBoxk26.Text);
						double v6 = Double.Parse(textBoxk27.Text);
						//添加新的数据
						vlist4.Add(time1, v4);
						vlist5.Add(time1, v5);
						vlist6.Add(time1, v6);
						//每个点的时间间隔
						time1 += 2;

						#region 方法
						if (vlist4.Count >= 30)
						{
							//更新X轴的显示范围
							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist5.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist6.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						#endregion
						//曲线刷新
						myZedgraph1.AxisChange();
						myZedgraph1.Refresh();
					}
				}
				//右脚踝
				if (comboBox2.Text == "右脚踝")
				{
					if (_PrimaryBody != null)
					{
						Joint AnkleR = _PrimaryBody.Joints[JointType.AnkleRight];
						textBoxk28.Text = Math.Round(AnkleR.Position.X, 1).ToString();
						textBoxk29.Text = Math.Round(AnkleR.Position.Y, 1).ToString();
						textBoxk30.Text = Math.Round(AnkleR.Position.Z, 1).ToString();

						double v4 = Double.Parse(textBoxk28.Text);
						double v5 = Double.Parse(textBoxk29.Text);
						double v6 = Double.Parse(textBoxk30.Text);
						//添加新的数据
						vlist4.Add(time1, v4);
						vlist5.Add(time1, v5);
						vlist6.Add(time1, v6);
						//每个点的时间间隔
						time1 += 2;

						#region 方法
						if (vlist4.Count >= 30)
						{
							//更新X轴的显示范围
							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist5.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist6.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						#endregion
						//曲线刷新
						myZedgraph1.AxisChange();
						myZedgraph1.Refresh();
					}
				}
				//左脚踝
				if (comboBox2.Text == "左脚踝")
				{
					if (_PrimaryBody != null)
					{
						Joint AnkleL = _PrimaryBody.Joints[JointType.AnkleLeft];
						textBoxk31.Text = Math.Round(AnkleL.Position.X, 1).ToString();
						textBoxk32.Text = Math.Round(AnkleL.Position.Y, 1).ToString();
						textBoxk33.Text = Math.Round(AnkleL.Position.Z, 1).ToString();

						double v4 = Double.Parse(textBoxk31.Text);
						double v5 = Double.Parse(textBoxk32.Text);
						double v6 = Double.Parse(textBoxk33.Text);
						//添加新的数据
						vlist4.Add(time1, v4);
						vlist5.Add(time1, v5);
						vlist6.Add(time1, v6);
						//每个点的时间间隔
						time1 += 2;

						#region 方法
						if (vlist4.Count >= 30)
						{
							//更新X轴的显示范围
							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist5.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						if (vlist6.Count >= 30)
						{//更新X轴的显示范围

							myZedgraph1.GraphPane.XAxis.Scale.Max = time1;
							//每个点的时间间隔
							myZedgraph1.GraphPane.XAxis.Scale.Min = time1 - (30 * 2);
						}
						#endregion
						//曲线刷新
						myZedgraph1.AxisChange();
						myZedgraph1.Refresh();
					}
				}			
		}
		private void ChartTimer_Tick(object sender, EventArgs e)
		{
			//右大臂
			textBox9.Text = Data[0].ToString();
			textBox2.Text = Data[1].ToString();
			textBox3.Text = Data[2].ToString();
			if(comboBox1.Text == "右大臂")
			{ 
			double v = Double.Parse(textBox9.Text);
			double v2 = Double.Parse(textBox2.Text);
			double v3 = Double.Parse(textBox3.Text);
			
			//添加新的数据
			vlist.Add(time, v);
			vlist2.Add(time, v2);
			vlist3.Add(time, v3);
			//每个点的时间间隔
			time += 2;

			#region 方法
			if (vlist.Count >= 30)
			{//更新X轴的显示范围

				myZedgraph.GraphPane.XAxis.Scale.Max = time;
				//每个点的时间间隔
				myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
			}
			if (vlist2.Count >= 30)
			{//更新X轴的显示范围

				myZedgraph.GraphPane.XAxis.Scale.Max = time;
				//每个点的时间间隔
				myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
			}
			if (vlist3.Count >= 30)
			{//更新X轴的显示范围

				myZedgraph.GraphPane.XAxis.Scale.Max = time;
				//每个点的时间间隔
				myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
			}
			#endregion


			//曲线刷新
			myZedgraph.AxisChange();
			myZedgraph.Refresh();
			}
			//左大臂
			textBox4.Text = Data1[0].ToString();
			textBox5.Text = Data1[1].ToString();
			textBox6.Text = Data1[2].ToString();
			if (comboBox1.Text == "左大臂")
			{
				double v = Double.Parse(textBox4.Text);
				double v2 = Double.Parse(textBox5.Text);
				double v3 = Double.Parse(textBox6.Text);
				//添加新的数据
				vlist.Add(time, v);
				vlist2.Add(time, v2);
				vlist3.Add(time, v3);
				//每个点的时间间隔
				time += 2;
				#region 方法
				if (vlist.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist2.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist3.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				#endregion
				//曲线刷新
				myZedgraph.AxisChange();
				myZedgraph.Refresh();
			}
			//右小臂
			textBox12.Text = Data2[0].ToString();
			textBox11.Text = Data2[1].ToString();
			textBox8.Text = Data2[2].ToString();
			if (comboBox1.Text == "右小臂")
			{
				double v = Double.Parse(textBox12.Text);
				double v2 = Double.Parse(textBox11.Text);
				double v3 = Double.Parse(textBox8.Text);
				//添加新的数据
				vlist.Add(time, v);
				vlist2.Add(time, v2);
				vlist3.Add(time, v3);
				//每个点的时间间隔
				time += 2;
				#region 方法
				if (vlist.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist2.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist3.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				#endregion
				//曲线刷新
				myZedgraph.AxisChange();
				myZedgraph.Refresh();
			}
			//左小臂
			textBox19.Text = Data3[0].ToString();
			textBox20.Text = Data3[1].ToString();
			textBox21.Text = Data3[2].ToString();
			if (comboBox1.Text == "左小臂")
			{
				double v = Double.Parse(textBox19.Text);
				double v2 = Double.Parse(textBox20.Text);
				double v3 = Double.Parse(textBox21.Text);
				//添加新的数据
				vlist.Add(time, v);
				vlist2.Add(time, v2);
				vlist3.Add(time, v3);
				//每个点的时间间隔
				time += 2;
				#region 方法
				if (vlist.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist2.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist3.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				#endregion
				//曲线刷新
				myZedgraph.AxisChange();
				myZedgraph.Refresh();
			}
			//右大腿
			textBox22.Text = Data4[0].ToString();
			textBox23.Text = Data4[1].ToString();
			textBox24.Text = Data4[2].ToString();
			if (comboBox1.Text == "右大腿")
			{
				double v = Double.Parse(textBox22.Text);
				double v2 = Double.Parse(textBox23.Text);
				double v3 = Double.Parse(textBox24.Text);
				//添加新的数据
				vlist.Add(time, v);
				vlist2.Add(time, v2);
				vlist3.Add(time, v3);
				//每个点的时间间隔
				time += 2;
				#region 方法
				if (vlist.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist2.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist3.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				#endregion
				//曲线刷新
				myZedgraph.AxisChange();
				myZedgraph.Refresh();
			}
			//左大腿
			textBox25.Text = Data5[0].ToString();
			textBox26.Text = Data5[1].ToString();
			textBox27.Text = Data5[2].ToString();
			if (comboBox1.Text == "左大腿")
			{
				double v = Double.Parse(textBox25.Text);
				double v2 = Double.Parse(textBox26.Text);
				double v3 = Double.Parse(textBox27.Text);
				//添加新的数据
				vlist.Add(time, v);
				vlist2.Add(time, v2);
				vlist3.Add(time, v3);
				//每个点的时间间隔
				time += 2;
				#region 方法
				if (vlist.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist2.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist3.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				#endregion
				//曲线刷新
				myZedgraph.AxisChange();
				myZedgraph.Refresh();
			}

			//右小腿
			textBox28.Text = Data6[0].ToString();
			textBox29.Text = Data6[1].ToString();
			textBox30.Text = Data6[2].ToString();
			if (comboBox1.Text == "右小腿")
			{
				double v = Double.Parse(textBox28.Text);
				double v2 = Double.Parse(textBox29.Text);
				double v3 = Double.Parse(textBox30.Text);
				
				//添加新的数据
				vlist.Add(time, v);
				vlist2.Add(time, v2);
				vlist3.Add(time, v3);
				//每个点的时间间隔
				time += 2;
				#region 方法
				if (vlist.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist2.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist3.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				#endregion
				//曲线刷新
				myZedgraph.AxisChange();
				myZedgraph.Refresh();
			}
			//左小腿
			textBox31.Text = Data7[0].ToString();
			textBox32.Text = Data7[1].ToString();
			textBox33.Text = Data7[2].ToString();
			if (comboBox1.Text == "左小腿")
			{
				double v = Double.Parse(textBox31.Text);
				double v2 = Double.Parse(textBox32.Text);
				double v3 = Double.Parse(textBox33.Text);
				//添加新的数据
				vlist.Add(time, v);
				vlist2.Add(time, v2);
				vlist3.Add(time, v3);
				//每个点的时间间隔
				time += 2;
				#region 方法
				if (vlist.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist2.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist3.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				#endregion
				//曲线刷新
				myZedgraph.AxisChange();
				myZedgraph.Refresh();
			}
			//胸部
			textBox34.Text = Data8[0].ToString();
			textBox35.Text = Data8[1].ToString();
			textBox36.Text = Data8[2].ToString();
			if (comboBox1.Text == "胸部")
			{
				double v = Double.Parse(textBox34.Text);
				double v2 = Double.Parse(textBox35.Text);
				double v3 = Double.Parse(textBox36.Text);
				//添加新的数据
				vlist.Add(time, v);
				vlist2.Add(time, v2);
				vlist3.Add(time, v3);
				//每个点的时间间隔
				time += 2;
				#region 方法
				if (vlist.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist2.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist3.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				#endregion
				//曲线刷新
				myZedgraph.AxisChange();
				myZedgraph.Refresh();
			}

			//腰部
			textBox37.Text = Data9[0].ToString();
			textBox38.Text = Data9[1].ToString();
			textBox39.Text = Data9[2].ToString();
			if (comboBox1.Text == "腰部")
			{
				double v = Double.Parse(textBox37.Text);
				double v2 = Double.Parse(textBox38.Text);
				double v3 = Double.Parse(textBox39.Text);
				//添加新的数据
				vlist.Add(time, v);
				vlist2.Add(time, v2);
				vlist3.Add(time, v3);
				//每个点的时间间隔
				time += 2;
				#region 方法
				if (vlist.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist2.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist3.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				#endregion
				//曲线刷新
				myZedgraph.AxisChange();
				myZedgraph.Refresh();
			}

			//头部
			textBox50.Text = Data10[0].ToString();
			textBox51.Text = Data10[1].ToString();
			textBox52.Text = Data10[2].ToString();
			if (comboBox1.Text == "头部")
			{
				double v = Double.Parse(textBox50.Text);
				double v2 = Double.Parse(textBox51.Text);
				double v3 = Double.Parse(textBox52.Text);
				//添加新的数据
				vlist.Add(time, v);
				vlist2.Add(time, v2);
				vlist3.Add(time, v3);
				//每个点的时间间隔
				time += 2;
				#region 方法
				if (vlist.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist2.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist3.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				#endregion
				//曲线刷新
				myZedgraph.AxisChange();
				myZedgraph.Refresh();
			}
			//右肩
			textBox42.Text = Data11[0].ToString();
			textBox43.Text = Data11[1].ToString();
			textBox44.Text = Data11[2].ToString();
			if (comboBox1.Text == "右肩")
			{
				double v = Double.Parse(textBox42.Text);
				double v2 = Double.Parse(textBox43.Text);
				double v3 = Double.Parse(textBox44.Text);
				//添加新的数据
				vlist.Add(time, v);
				vlist2.Add(time, v2);
				vlist3.Add(time, v3);
				//每个点的时间间隔
				time += 2;
				#region 方法
				if (vlist.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist2.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist3.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				#endregion
				//曲线刷新
				myZedgraph.AxisChange();
				myZedgraph.Refresh();
			}

			//左肩
			textBox46.Text = Data12[0].ToString();
			textBox47.Text = Data12[1].ToString();
			textBox48.Text = Data12[2].ToString();
			if (comboBox1.Text == "左肩")
			{
				double v = Double.Parse(textBox46.Text);
				double v2 = Double.Parse(textBox47.Text);
				double v3 = Double.Parse(textBox48.Text);
				//添加新的数据
				vlist.Add(time, v);
				vlist2.Add(time, v2);
				vlist3.Add(time, v3);
				//每个点的时间间隔
				time += 2;
				#region 方法
				if (vlist.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist2.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				if (vlist3.Count >= 30)
				{//更新X轴的显示范围
					myZedgraph.GraphPane.XAxis.Scale.Max = time;
					//每个点的时间间隔
					myZedgraph.GraphPane.XAxis.Scale.Min = time - (30 * 2);
				}
				#endregion
				//曲线刷新
				myZedgraph.AxisChange();
				myZedgraph.Refresh();
			}
		}


		//骨骼帧处理事件
		void _BodyFrameReader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
		{
			//获取一帧骨骼
			using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
			{
				if (bodyFrame != null)
				{
					//玩家骨骼保存到数组里面
					bodyFrame.GetAndRefreshBodyData(this._Bodies);

					//获取最近的人的骨架
					_PrimaryBody = GetNearBody(_Bodies);

					if (_PrimaryBody != null)
					{

						#region 显示头的X,Y，Z坐标
						Joint head = _PrimaryBody.Joints[JointType.Head];						
						textBoxk1.Text = Math.Round(head.Position.X, 1).ToString();
						textBoxk2.Text = Math.Round(head.Position.Y, 1).ToString();
						textBoxk3.Text = Math.Round(head.Position.Z, 1).ToString();

						Joint ShoulderR = _PrimaryBody.Joints[JointType.ShoulderRight];
						textBoxk4.Text = Math.Round(ShoulderR.Position.X, 1).ToString();
						textBoxk5.Text = Math.Round(ShoulderR.Position.Y, 1).ToString();
						textBoxk6.Text = Math.Round(ShoulderR.Position.Z, 1).ToString();

						Joint ShoulderL = _PrimaryBody.Joints[JointType.ShoulderLeft];
						textBoxk7.Text = Math.Round(ShoulderL.Position.X, 1).ToString();
						textBoxk8.Text = Math.Round(ShoulderL.Position.Y, 1).ToString();
						textBoxk9.Text = Math.Round(ShoulderL.Position.Z, 1).ToString();

						Joint ElbowR = _PrimaryBody.Joints[JointType.ElbowRight];
						textBoxk10.Text = Math.Round(ElbowR.Position.X, 1).ToString();
						textBoxk11.Text = Math.Round(ElbowR.Position.Y, 1).ToString();
						textBoxk12.Text = Math.Round(ElbowR.Position.Z, 1).ToString();

						Joint ElbowL = _PrimaryBody.Joints[JointType.ElbowLeft];
						textBoxk13.Text = Math.Round(ElbowL.Position.X, 1).ToString();
						textBoxk14.Text = Math.Round(ElbowL.Position.Y, 1).ToString();
						textBoxk15.Text = Math.Round(ElbowL.Position.Z, 1).ToString();

						Joint WristR = _PrimaryBody.Joints[JointType.WristRight];
						textBoxk16.Text = Math.Round(WristR.Position.X, 1).ToString();
						textBoxk17.Text = Math.Round(WristR.Position.Y, 1).ToString();
						textBoxk18.Text = Math.Round(WristR.Position.Z, 1).ToString();

						Joint _WristL = _PrimaryBody.Joints[JointType.WristLeft];
						textBoxk19.Text = Math.Round(_WristL.Position.X, 1).ToString();
						textBoxk20.Text = Math.Round(_WristL.Position.Y, 1).ToString();
						textBoxk21.Text = Math.Round(_WristL.Position.Z, 1).ToString();

						Joint KneeR = _PrimaryBody.Joints[JointType.KneeRight];
						textBoxk22.Text = Math.Round(KneeR.Position.X, 1).ToString();
						textBoxk23.Text = Math.Round(KneeR.Position.Y, 1).ToString();
						textBoxk24.Text = Math.Round(KneeR.Position.Z, 1).ToString();

						Joint KneeL = _PrimaryBody.Joints[JointType.KneeLeft];
						textBoxk25.Text = Math.Round(KneeL.Position.X, 1).ToString();
						textBoxk26.Text = Math.Round(KneeL.Position.Y, 1).ToString();
						textBoxk27.Text = Math.Round(KneeL.Position.Z, 1).ToString();

						Joint AnkleR = _PrimaryBody.Joints[JointType.AnkleRight];
						textBoxk28.Text = Math.Round(AnkleR.Position.X, 1).ToString();
						textBoxk29.Text = Math.Round(AnkleR.Position.Y, 1).ToString();
						textBoxk30.Text = Math.Round(AnkleR.Position.Z, 1).ToString();

						Joint AnkleL = _PrimaryBody.Joints[JointType.AnkleLeft];
						textBoxk31.Text = Math.Round(AnkleL.Position.X, 1).ToString();
						textBoxk32.Text = Math.Round(AnkleL.Position.Y, 1).ToString();
						textBoxk33.Text = Math.Round(AnkleL.Position.Z, 1).ToString();

						#endregion 显示头的X,Y，Z坐标
						#region 保存坐标
						if (_IsSave == true)
						{
							SaveJointPosition(_PrimaryBody);
							
						}

						#endregion 保存坐标

						#region 判断手势

						if (_PrimaryBody.HandLeftState == HandState.Closed)
						{
							textBox7.Text = "左手握拳";
						}
						else if (_PrimaryBody.HandLeftState == HandState.Open)
						{
							textBox7.Text = "左手张开";
						}
						else
						{
							textBox7.Text = "";
						}

						if (_PrimaryBody.HandRightState == HandState.Closed)
						{
							textBox1.Text = "右手握拳";
						}
						else if (_PrimaryBody.HandRightState == HandState.Open)
						{
							textBox1.Text = "右手张开";
						}
						else
						{
							textBox1.Text = "";
						}
						#endregion 判断手势
					}
				}
			}
		}
		//距离最近的人的骨架
		private Body GetNearBody(Body[] bodies)
		{
			Body body = null;

			if (bodies != null)
			{
				for (int i = 0; i < bodies.Length; i++)
				{
					if (bodies[i].IsTracked == true)
					{
						if (body == null)
						{
							body = bodies[i];
						}
						else
						{
							if (Math.Abs(body.Joints[JointType.SpineBase].Position.Z) > Math.Abs(bodies[i].Joints[JointType.SpineBase].Position.Z))
							{
								body = bodies[i];
							}
						}
					}
				}
			}

			return body;
		}
		//保存数据
		private void SaveJointPosition(Body body)
		{
			//保存头
			Joint joint0 = body.Joints[JointType.SpineBase];
			Joint joint1 = body.Joints[JointType.SpineMid];
			Joint joint2 = body.Joints[JointType.Neck];
			Joint joint3 = body.Joints[JointType.Head];
			Joint joint4 = body.Joints[JointType.ShoulderLeft];
			Joint joint5 = body.Joints[JointType.ElbowLeft];
        	Joint joint6 = body.Joints[JointType.WristLeft];
			Joint joint7 = body.Joints[JointType.HandLeft];
			Joint joint8 = body.Joints[JointType.ShoulderRight];
			Joint joint9 = body.Joints[JointType.ElbowRight];
			Joint joint10 = body.Joints[JointType.WristRight];
			Joint joint11 = body.Joints[JointType.HandRight];
			Joint joint12 = body.Joints[JointType.HipLeft];
			Joint joint13 = body.Joints[JointType.KneeLeft];
			Joint joint14 = body.Joints[JointType.AnkleLeft];
			Joint joint15 = body.Joints[JointType.FootLeft];
			Joint joint16 = body.Joints[JointType.HipRight];
			Joint joint17 = body.Joints[JointType.KneeRight];
			Joint joint18 = body.Joints[JointType.AnkleRight];
			Joint joint19 = body.Joints[JointType.FootRight];
			Joint joint20 = body.Joints[JointType.SpineShoulder];
			Joint joint21 = body.Joints[JointType.HandTipLeft];
			Joint joint22 = body.Joints[JointType.ThumbLeft];
			Joint joint23 = body.Joints[JointType.HandTipRight];
			Joint joint24 = body.Joints[JointType.ThumbRight];
			JointOrientation joint30 = body.JointOrientations[JointType.SpineBase];
			JointOrientation joint31 = body.JointOrientations[JointType.SpineMid];
			JointOrientation joint32 = body.JointOrientations[JointType.Neck];
			JointOrientation joint33 = body.JointOrientations[JointType.Head];
			JointOrientation joint34 = body.JointOrientations[JointType.ShoulderLeft];
			JointOrientation joint35 = body.JointOrientations[JointType.ElbowLeft];
			JointOrientation joint36 = body.JointOrientations[JointType.WristLeft];
			JointOrientation joint37 = body.JointOrientations[JointType.HandLeft];
			JointOrientation joint38 = body.JointOrientations[JointType.ShoulderRight];
			JointOrientation joint39 = body.JointOrientations[JointType.ElbowRight];
			JointOrientation joint40 = body.JointOrientations[JointType.WristRight];
			JointOrientation joint41 = body.JointOrientations[JointType.HandRight];
			JointOrientation joint42 = body.JointOrientations[JointType.HipLeft];
			JointOrientation joint43 = body.JointOrientations[JointType.KneeLeft];
			JointOrientation joint44 = body.JointOrientations[JointType.AnkleLeft];
			JointOrientation joint45 = body.JointOrientations[JointType.FootLeft];
			JointOrientation joint46 = body.JointOrientations[JointType.HipRight];
			JointOrientation joint47 = body.JointOrientations[JointType.KneeRight];
			JointOrientation joint48 = body.JointOrientations[JointType.AnkleRight];
			JointOrientation joint49 = body.JointOrientations[JointType.FootRight];
			JointOrientation joint50 = body.JointOrientations[JointType.SpineShoulder];
			JointOrientation joint51 = body.JointOrientations[JointType.HandTipLeft];
			JointOrientation joint52 = body.JointOrientations[JointType.ThumbLeft];
			JointOrientation joint53 = body.JointOrientations[JointType.HandTipRight];
			JointOrientation joint54 = body.JointOrientations[JointType.ThumbRight];

			_SW.Write(Math.Round(joint0.Position.X, 4).ToString() + "\t" + Math.Round(joint0.Position.Y, 4).ToString() + "\t" + Math.Round(joint0.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint1.Position.X, 4).ToString() + "\t" + Math.Round(joint1.Position.Y, 4).ToString() + "\t" + Math.Round(joint1.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint2.Position.X, 4).ToString() + "\t" + Math.Round(joint2.Position.Y, 4).ToString() + "\t" + Math.Round(joint2.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint3.Position.X, 4).ToString() + "\t" + Math.Round(joint3.Position.Y, 4).ToString() + "\t" + Math.Round(joint3.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint4.Position.X, 4).ToString() + "\t" + Math.Round(joint4.Position.Y, 4).ToString() + "\t" + Math.Round(joint4.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint5.Position.X, 4).ToString() + "\t" + Math.Round(joint5.Position.Y, 4).ToString() + "\t" + Math.Round(joint5.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint6.Position.X, 4).ToString() + "\t" + Math.Round(joint6.Position.Y, 4).ToString() + "\t" + Math.Round(joint6.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint7.Position.X, 4).ToString() + "\t" + Math.Round(joint7.Position.Y, 4).ToString() + "\t" + Math.Round(joint7.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint8.Position.X, 4).ToString() + "\t" + Math.Round(joint8.Position.Y, 4).ToString() + "\t" + Math.Round(joint8.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint9.Position.X, 4).ToString() + "\t" + Math.Round(joint9.Position.Y, 4).ToString() + "\t" + Math.Round(joint9.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint10.Position.X, 4).ToString() + "\t" + Math.Round(joint10.Position.Y, 4).ToString() + "\t" + Math.Round(joint10.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint11.Position.X, 4).ToString() + "\t" + Math.Round(joint11.Position.Y, 4).ToString() + "\t" + Math.Round(joint11.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint12.Position.X, 4).ToString() + "\t" + Math.Round(joint12.Position.Y, 4).ToString() + "\t" + Math.Round(joint12.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint13.Position.X, 4).ToString() + "\t" + Math.Round(joint13.Position.Y, 4).ToString() + "\t" + Math.Round(joint13.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint14.Position.X, 4).ToString() + "\t" + Math.Round(joint14.Position.Y, 4).ToString() + "\t" + Math.Round(joint14.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint15.Position.X, 4).ToString() + "\t" + Math.Round(joint15.Position.Y, 4).ToString() + "\t" + Math.Round(joint15.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint16.Position.X, 4).ToString() + "\t" + Math.Round(joint16.Position.Y, 4).ToString() + "\t" + Math.Round(joint16.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint17.Position.X, 4).ToString() + "\t" + Math.Round(joint17.Position.Y, 4).ToString() + "\t" + Math.Round(joint17.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint18.Position.X, 4).ToString() + "\t" + Math.Round(joint18.Position.Y, 4).ToString() + "\t" + Math.Round(joint18.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint19.Position.X, 4).ToString() + "\t" + Math.Round(joint19.Position.Y, 4).ToString() + "\t" + Math.Round(joint19.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint20.Position.X, 4).ToString() + "\t" + Math.Round(joint20.Position.Y, 4).ToString() + "\t" + Math.Round(joint20.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint21.Position.X, 4).ToString() + "\t" + Math.Round(joint21.Position.Y, 4).ToString() + "\t" + Math.Round(joint21.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint22.Position.X, 4).ToString() + "\t" + Math.Round(joint22.Position.Y, 4).ToString() + "\t" + Math.Round(joint22.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint23.Position.X, 4).ToString() + "\t" + Math.Round(joint23.Position.Y, 4).ToString() + "\t" + Math.Round(joint23.Position.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint24.Position.X, 4).ToString() + "\t" + Math.Round(joint24.Position.Y, 4).ToString() + "\t" + Math.Round(joint24.Position.Z, 4).ToString());
			_SW.WriteLine();

			//保存四元数数据

			_SW2.Write(Math.Round(joint30.Orientation.W, 4).ToString() + "\t" + Math.Round(joint30.Orientation.X, 4).ToString() + "\t" + Math.Round(joint30.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint30.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint31.Orientation.W, 4).ToString() + "\t" + Math.Round(joint31.Orientation.X, 4).ToString() + "\t" + Math.Round(joint31.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint31.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint32.Orientation.W, 4).ToString() + "\t" + Math.Round(joint32.Orientation.X, 4).ToString() + "\t" + Math.Round(joint32.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint32.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint33.Orientation.W, 4).ToString() + "\t" + Math.Round(joint33.Orientation.X, 4).ToString() + "\t" + Math.Round(joint33.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint33.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint34.Orientation.W, 4).ToString() + "\t" + Math.Round(joint34.Orientation.X, 4).ToString() + "\t" + Math.Round(joint34.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint34.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint35.Orientation.W, 4).ToString() + "\t" + Math.Round(joint35.Orientation.X, 4).ToString() + "\t" + Math.Round(joint35.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint35.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint36.Orientation.W, 4).ToString() + "\t" + Math.Round(joint36.Orientation.X, 4).ToString() + "\t" + Math.Round(joint36.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint36.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint37.Orientation.W, 4).ToString() + "\t" + Math.Round(joint37.Orientation.X, 4).ToString() + "\t" + Math.Round(joint37.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint37.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint38.Orientation.W, 4).ToString() + "\t" + Math.Round(joint38.Orientation.X, 4).ToString() + "\t" + Math.Round(joint38.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint38.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint39.Orientation.W, 4).ToString() + "\t" + Math.Round(joint39.Orientation.X, 4).ToString() + "\t" + Math.Round(joint39.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint39.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint40.Orientation.W, 4).ToString() + "\t" + Math.Round(joint40.Orientation.X, 4).ToString() + "\t" + Math.Round(joint40.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint40.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint41.Orientation.W, 4).ToString() + "\t" + Math.Round(joint41.Orientation.X, 4).ToString() + "\t" + Math.Round(joint41.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint41.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint42.Orientation.W, 4).ToString() + "\t" + Math.Round(joint42.Orientation.X, 4).ToString() + "\t" + Math.Round(joint42.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint42.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint43.Orientation.W, 4).ToString() + "\t" + Math.Round(joint43.Orientation.X, 4).ToString() + "\t" + Math.Round(joint43.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint43.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint44.Orientation.W, 4).ToString() + "\t" + Math.Round(joint44.Orientation.X, 4).ToString() + "\t" + Math.Round(joint44.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint44.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint45.Orientation.W, 4).ToString() + "\t" + Math.Round(joint45.Orientation.X, 4).ToString() + "\t" + Math.Round(joint45.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint45.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint46.Orientation.W, 4).ToString() + "\t" + Math.Round(joint46.Orientation.X, 4).ToString() + "\t" + Math.Round(joint46.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint46.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint47.Orientation.W, 4).ToString() + "\t" + Math.Round(joint47.Orientation.X, 4).ToString() + "\t" + Math.Round(joint47.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint47.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint48.Orientation.W, 4).ToString() + "\t" + Math.Round(joint48.Orientation.X, 4).ToString() + "\t" + Math.Round(joint48.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint48.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint49.Orientation.W, 4).ToString() + "\t" + Math.Round(joint49.Orientation.X, 4).ToString() + "\t" + Math.Round(joint49.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint49.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint50.Orientation.W, 4).ToString() + "\t" + Math.Round(joint50.Orientation.X, 4).ToString() + "\t" + Math.Round(joint50.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint50.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint51.Orientation.W, 4).ToString() + "\t" + Math.Round(joint51.Orientation.X, 4).ToString() + "\t" + Math.Round(joint51.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint51.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint52.Orientation.W, 4).ToString() + "\t" + Math.Round(joint52.Orientation.X, 4).ToString() + "\t" + Math.Round(joint52.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint52.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint53.Orientation.W, 4).ToString() + "\t" + Math.Round(joint53.Orientation.X, 4).ToString() + "\t" + Math.Round(joint53.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint53.Orientation.Z, 4).ToString() + "\t"
			   + "\t" + Math.Round(joint54.Orientation.W, 4).ToString() + "\t" + Math.Round(joint54.Orientation.X, 4).ToString() + "\t" + Math.Round(joint54.Orientation.Y, 4).ToString() + "\t" + Math.Round(joint54.Orientation.Z, 4).ToString() + "\t"
			);
			_SW2.WriteLine();
			//_SW3.Write(Head_euler[0] + "\t" + Head_euler[1] + "\t" + Head_euler[2] + "\t" + "\t" +
			//           L_shoulder_euler[0] + "\t" + L_shoulder_euler[1] + "\t" + L_shoulder_euler[2] + "\t" + "\t" +
			//           R_shoulder_euler[0] + "\t" + R_shoulder_euler[1] + "\t" + R_shoulder_euler[2] + "\t" + "\t" +
			//           hip_euler[0] + "\t" + hip_euler[1] + "\t" + hip_euler[2] + "\t" + "\t" +
			//           waist_euler[0] + "\t" + waist_euler[1] + "\t" + waist_euler[2] + "\t" + "\t" +
			//           R_upperarm[0] + "\t" + R_upperarm[1] + "\t" + R_upperarm[2] + "\t" + "\t" +
			//           R_lowerarm[0] + "\t" + R_lowerarm[1] + "\t" + R_lowerarm[2] + "\t" );
			//_SW3.WriteLine();
		}

		private void Form1_Load(object sender, EventArgs e)
        {
			IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
			IPAddress[] array = hostAddresses;
			foreach (IPAddress iPAddress in array)
			{
				if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					ip = iPAddress;
					break;
				}
			}
			remoteIp = ip;
			Auto_IP = remoteIp.ToString();
			string path = "后台配置.txt";
			StreamReader streamReader = new StreamReader(path, detectEncodingFromByteOrderMarks: false);
			string text = streamReader.ReadToEnd().ToString();
			streamReader.Close();
			readset = text;
			int num = 0;
			int num2 = 0;
			for (int j = 0; j < readset.Length; j++)
			{
				if (readset[j] == '#')
				{
					for (j++; readset[j] != '%'; j++)
					{
						setfile1[num] += readset[j];
					}
					num++;
				}
			}
			for (int j = 0; j < readset.Length; j++)
			{
				if (readset[j] == '%')
				{
					for (j++; readset[j] != '\r'; j++)
					{
						setfile2[num2] += readset[j];
					}
					num2++;
				}
			}
			if (num2 == num)
			{
				readsetnum = num2;
				int[] array2 = new int[1000];
				int[] array3 = new int[1000];
				for (int k = 0; k < readsetnum; k++)
				{
					switch (k)
					{
						case 0:
							//comboBox2.Text = setfile2[k];
							break;
						case 1:
							//comboBox1.Text = setfile2[k];
							break;
						case 2:
							//comboBox3.Text = setfile2[k];
							break;
						case 3:
							//comboBox4.Text = setfile2[k];
							break;
						case 4:
							//comboBox5.Text = setfile2[k];
							break;
						case 5:
							//comboBox6.Text = setfile2[k];
							break;
						case 6:
							//comboBox7.Text = setfile2[k];
							break;
						case 7:
							//comboBox9.Text = setfile2[k];
							break;
						case 8:
							if (setfile2[k] != "")
							{
								txt_IPAddress.Text = setfile2[k];
							}
							else
							{
								txt_IPAddress.Text = Auto_IP;
							}
							break;
					}
				}
				try
				{
					remoteIp = IPAddress.Parse(txt_IPAddress.Text.Trim());
					ip = IPAddress.Parse(txt_IPAddress.Text.Trim());
					remoteIp = ip;
					Thread thread = new Thread(ReceiveData);
					Thread thread2 = new Thread(ReceiveData1);
					Thread thread3 = new Thread(ReceiveData2);
					Thread thread4 = new Thread(ReceiveData3);
					Thread thread5 = new Thread(ReceiveData4);
					Thread thread6 = new Thread(ReceiveData5);
					Thread thread7 = new Thread(ReceiveData6);
					Thread thread8 = new Thread(ReceiveData7);
					Thread thread9 = new Thread(ReceiveData8);
					Thread thread10 = new Thread(ReceiveData9);
					Thread thread11 = new Thread(ReceiveData10);
					Thread thread12 = new Thread(ReceiveData11);
					Thread thread13 = new Thread(ReceiveData12);
					Thread thread14 = new Thread(ReceiveData13);
					Thread thread15 = new Thread(ReceiveData14);
					thread.IsBackground = true;
					thread.Start();
					thread2.IsBackground = true;
					thread2.Start();
					thread3.IsBackground = true;
					thread3.Start();
					thread4.IsBackground = true;
					thread4.Start();
					thread5.IsBackground = true;
					thread5.Start();
					thread6.IsBackground = true;
					thread6.Start();
					thread7.IsBackground = true;
					thread7.Start();
					thread8.IsBackground = true;
					thread8.Start();
					thread9.IsBackground = true;
					thread9.Start();
					thread10.IsBackground = true;
					thread10.Start();
					thread11.IsBackground = true;
					thread11.Start();
					thread12.IsBackground = true;
					thread12.Start();
					thread13.IsBackground = true;
					thread13.Start();
					thread14.IsBackground = true;
					thread14.Start();
					thread15.IsBackground = true;
					thread15.Start();
					Control.CheckForIllegalCrossThreadCalls = false;
					sendUdpClient = new UdpClient(1);
					sendUdpClient1 = new UdpClient(2);
					sendUdpClient2 = new UdpClient(3);
					sendUdpClient3 = new UdpClient(4);
					sendUdpClient4 = new UdpClient(5);
					sendUdpClient5 = new UdpClient(6);
					sendUdpClient6 = new UdpClient(7);
					sendUdpClient7 = new UdpClient(8);
					sendUdpClient8 = new UdpClient(9);
					sendUdpClient9 = new UdpClient(10);
					sendUdpClient10 = new UdpClient(11);
					sendUdpClient11 = new UdpClient(12);
					sendUdpClient12 = new UdpClient(13);
					sendUdpClient13 = new UdpClient(14);
					sendUdpClient14 = new UdpClient(15);
					timer1.Enabled = true;
				}
				catch
				{

				}
				try
				{

				}
				catch
				{

				}
			}
			for (int l = 0; l < 15; l++)
			{
				scroll_offset_Xall[l] = 0.0;
				scroll_offset_Yall[l] = 0.0;
				scroll_offset_Zall[l] = 0.0;
			}
			Control.CheckForIllegalCrossThreadCalls = false;


        }
        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
			//骨骼帧关闭处理
			if (this._BodyFrameReader != null)
			{
				this._BodyFrameReader.Dispose();
				this._BodyFrameReader = null;
			}
			//体感器关闭处理
			if (this._KinectDevice != null)
			{
				this._KinectDevice.Close();
				this._KinectDevice = null;
			}
			try
			{
				//serialPort1.Close();
				//serialPort2.Close();
				//serialPort3.Close();
				this.Dispose();
			}
			catch
			{
				//MessageBox.Show("端口关闭错误");
			}
		}


		private void ReceiveData()
        {
			if (!first_tst)
			{
				IPEndPoint localEP = new IPEndPoint(ip, 1);
				receiveUdpClient = new UdpClient(localEP);
				first_tst = true;
			}
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 9250);
			while (!exit1)
			{
				try
				{
					arrServerRecMsg = receiveUdpClient.Receive(ref remoteEP);
					string @string = Encoding.Default.GetString(arrServerRecMsg, 0, arrServerRecMsg.Length);
					//if (@string[2] == 'O' && @string[3] == 'K')
					//{
					//	textBox1.Text = "DNOK";
					//}
					string[] array = @string.Split(',');
					Ax1 = array[0].Substring(14, array[0].Length - 14);
					Ay1 = array[1];
					Az1 = array[2];
					Wx1 = array[3];
					Wy1 = array[4];
					Wz1 = array[5];
					Angle_x1 = array[6];
					Angle_y1 = array[7];
					Angle_z1 = array[8];
					textBox54.Text = array[9] + "\r\n" + array[10] + "\r\n" + array[11] + "\r\n";
					Data[0] = Convert.ToDouble(Angle_x1);
					Data[1] = Convert.ToDouble(Angle_y1);
					Data[2] = Convert.ToDouble(Angle_z1);
					Data[0] += offset_x_0;
					Data[1] += offset_y_0;
					Data[2] += offset_z_0;
					Data[0] += scroll_ofset_x_0;
					Data[1] += scroll_ofset_y_0;
					Data[2] += scroll_ofset_z_0;
					Mx1 = array[9];
					My1 = array[10];
					Mz1 = array[11];
					AData1[0] = Convert.ToDouble(Ax1);
					AData1[1] = Convert.ToDouble(Ay1);
					AData1[2] = Convert.ToDouble(Az1);
					WData1[0] = Convert.ToDouble(Wx1);
					WData1[1] = Convert.ToDouble(Wy1);
					WData1[2] = Convert.ToDouble(Wz1);
					MData1[0] = Convert.ToDouble(Mx1);
					MData1[1] = Convert.ToDouble(My1);
					MData1[2] = Convert.ToDouble(Mz1);
                    #region send
                    //sendgroup1[2] = (byte)((int)(Data[0] * 1000.0) >> 24);
                    //sendgroup1[3] = (byte)((int)(Data[0] * 1000.0) >> 16);
                    //sendgroup1[4] = (byte)((int)(Data[0] * 1000.0) >> 8);
                    //sendgroup1[5] = (byte)(int)(Data[0] * 1000.0);
                    //sendgroup1[6] = (byte)((int)(Data[1] * 1000.0) >> 24);
                    //sendgroup1[7] = (byte)((int)(Data[1] * 1000.0) >> 16);
                    //sendgroup1[8] = (byte)((int)(Data[1] * 1000.0) >> 8);
                    //sendgroup1[9] = (byte)(int)(Data[1] * 1000.0);
                    //sendgroup1[10] = (byte)((int)(Data[2] * 1000.0) >> 24);
                    //sendgroup1[11] = (byte)((int)(Data[2] * 1000.0) >> 16);
                    //sendgroup1[12] = (byte)((int)(Data[2] * 1000.0) >> 8);
                    //sendgroup1[13] = (byte)(int)(Data[2] * 1000.0);

                    //sendgroup4[2] = (byte)((int)(AData1[0] * 1000.0) >> 24);
                    //sendgroup4[3] = (byte)((int)(AData1[0] * 1000.0) >> 16);
                    //sendgroup4[4] = (byte)((int)(AData1[0] * 1000.0) >> 8);
                    //sendgroup4[5] = (byte)(int)(AData1[0] * 1000.0);
                    //sendgroup4[6] = (byte)((int)(AData1[1] * 1000.0) >> 24);
                    //sendgroup4[7] = (byte)((int)(AData1[1] * 1000.0) >> 16);
                    //sendgroup4[8] = (byte)((int)(AData1[1] * 1000.0) >> 8);
                    //sendgroup4[9] = (byte)(int)(AData1[1] * 1000.0);
                    //sendgroup4[10] = (byte)((int)(AData1[2] * 1000.0) >> 24);
                    //sendgroup4[11] = (byte)((int)(AData1[2] * 1000.0) >> 16);
                    //sendgroup4[12] = (byte)((int)(AData1[2] * 1000.0) >> 8);
                    //sendgroup4[13] = (byte)(int)(AData1[2] * 1000.0);
                    //sendgroup4[14] = (byte)((int)(WData1[0] * 1000.0) >> 24);
                    //sendgroup4[15] = (byte)((int)(WData1[0] * 1000.0) >> 16);
                    //sendgroup4[16] = (byte)((int)(WData1[0] * 1000.0) >> 8);
                    //sendgroup4[17] = (byte)(int)(WData1[0] * 1000.0);
                    //sendgroup4[18] = (byte)((int)(WData1[1] * 1000.0) >> 24);
                    //sendgroup4[19] = (byte)((int)(WData1[1] * 1000.0) >> 16);
                    //sendgroup4[20] = (byte)((int)(WData1[1] * 1000.0) >> 8);
                    //sendgroup4[21] = (byte)(int)(WData1[1] * 1000.0);
                    //sendgroup4[22] = (byte)((int)(WData1[2] * 1000.0) >> 24);
                    //sendgroup4[23] = (byte)((int)(WData1[2] * 1000.0) >> 16);
                    //sendgroup4[24] = (byte)((int)(WData1[2] * 1000.0) >> 8);
                    //sendgroup4[25] = (byte)(int)(WData1[2] * 1000.0);
                    //sendgroup4[26] = (byte)((int)(MData1[0] * 1000.0) >> 24);
                    //sendgroup4[27] = (byte)((int)(MData1[0] * 1000.0) >> 16);
                    //sendgroup4[28] = (byte)((int)(MData1[0] * 1000.0) >> 8);
                    //sendgroup4[29] = (byte)(int)(MData1[0] * 1000.0);
                    //sendgroup4[30] = (byte)((int)(MData1[1] * 1000.0) >> 24);
                    //sendgroup4[31] = (byte)((int)(MData1[1] * 1000.0) >> 16);
                    //sendgroup4[32] = (byte)((int)(MData1[1] * 1000.0) >> 8);
                    //sendgroup4[33] = (byte)(int)(MData1[1] * 1000.0);
                    //sendgroup4[34] = (byte)((int)(MData1[2] * 1000.0) >> 24);
                    //sendgroup4[35] = (byte)((int)(MData1[2] * 1000.0) >> 16);
                    //sendgroup4[36] = (byte)((int)(MData1[2] * 1000.0) >> 8);
                    //sendgroup4[37] = (byte)(int)(MData1[2] * 1000.0);
                    #endregion send
                    test++;
					remote1 = remoteEP;
					
				}
				catch
				{
					break;
				}
			}
		}
		private void ReceiveData1()
        {
			if (!first_tst_2)
			{
				IPEndPoint localEP = new IPEndPoint(ip, 2);
				receiveUdpClient1 = new UdpClient(localEP);
				first_tst_2 = true;
			}
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 9250);
			while (!exit2)
			{
				try
				{
					arrServerRecMsg1 = receiveUdpClient1.Receive(ref remoteEP);
					string @string = Encoding.Default.GetString(arrServerRecMsg1, 0, arrServerRecMsg1.Length);
					//if (@string[2] == 'O' && @string[3] == 'K')
					//{
					//	textBox10.Text = "DNOK";
					//}
					string[] array = @string.Split(',');
					Ax2 = array[0].Substring(14, array[0].Length - 14);
					Ay2 = array[1];
					Az2 = array[2];
					Wx2 = array[3];
					Wy2 = array[4];
					Wz2 = array[5];
					Angle_x2 = array[6];
					Angle_y2 = array[7];
					Angle_z2 = array[8];
					textBox55.Text = array[9] + "\r\n" + array[10] + "\r\n" + array[11] + "\r\n";
					Data1[0] = Convert.ToDouble(Angle_x2);
					Data1[1] = Convert.ToDouble(Angle_y2);
					Data1[2] = Convert.ToDouble(Angle_z2);
					Data1[0] += offset_x_1;
					Data1[1] += offset_y_1;
					Data1[2] += offset_z_1;
					Data1[0] += scroll_ofset_x_1;
					Data1[1] += scroll_ofset_y_1;
					Data1[2] += scroll_ofset_z_1;
					Mx2 = array[9];
					My2 = array[10];
					Mz2 = array[11];
					AData2[0] = Convert.ToDouble(Ax2);
					AData2[1] = Convert.ToDouble(Ay2);
					AData2[2] = Convert.ToDouble(Az2);
					WData2[0] = Convert.ToDouble(Wx2);
					WData2[1] = Convert.ToDouble(Wy2);
					WData2[2] = Convert.ToDouble(Wz2);
					MData2[0] = Convert.ToDouble(Mx2);
					MData2[1] = Convert.ToDouble(My2);
					MData2[2] = Convert.ToDouble(Mz2);
                    #region send
                    //sendgroup1[14] = (byte)((int)(Data1[0] * 1000.0) >> 24);
                    //sendgroup1[15] = (byte)((int)(Data1[0] * 1000.0) >> 16);
                    //sendgroup1[16] = (byte)((int)(Data1[0] * 1000.0) >> 8);
                    //sendgroup1[17] = (byte)(int)(Data1[0] * 1000.0);
                    //sendgroup1[18] = (byte)((int)(Data1[1] * 1000.0) >> 24);
                    //sendgroup1[19] = (byte)((int)(Data1[1] * 1000.0) >> 16);
                    //sendgroup1[20] = (byte)((int)(Data1[1] * 1000.0) >> 8);
                    //sendgroup1[21] = (byte)(int)(Data1[1] * 1000.0);
                    //sendgroup1[22] = (byte)((int)(Data1[2] * 1000.0) >> 24);
                    //sendgroup1[23] = (byte)((int)(Data1[2] * 1000.0) >> 16);
                    //sendgroup1[24] = (byte)((int)(Data1[2] * 1000.0) >> 8);
                    //sendgroup1[25] = (byte)(int)(Data1[2] * 1000.0);
                    //sendgroup4[38] = (byte)((int)(AData2[0] * 1000.0) >> 24);
                    //sendgroup4[39] = (byte)((int)(AData2[0] * 1000.0) >> 16);
                    //sendgroup4[40] = (byte)((int)(AData2[0] * 1000.0) >> 8);
                    //sendgroup4[41] = (byte)(int)(AData2[0] * 1000.0);
                    //sendgroup4[42] = (byte)((int)(AData2[1] * 1000.0) >> 24);
                    //sendgroup4[43] = (byte)((int)(AData2[1] * 1000.0) >> 16);
                    //sendgroup4[44] = (byte)((int)(AData2[1] * 1000.0) >> 8);
                    //sendgroup4[45] = (byte)(int)(AData2[1] * 1000.0);
                    //sendgroup4[46] = (byte)((int)(AData2[2] * 1000.0) >> 24);
                    //sendgroup4[47] = (byte)((int)(AData2[2] * 1000.0) >> 16);
                    //sendgroup4[48] = (byte)((int)(AData2[2] * 1000.0) >> 8);
                    //sendgroup4[49] = (byte)(int)(AData2[2] * 1000.0);
                    //sendgroup4[50] = (byte)((int)(WData2[0] * 1000.0) >> 24);
                    //sendgroup4[51] = (byte)((int)(WData2[0] * 1000.0) >> 16);
                    //sendgroup4[52] = (byte)((int)(WData2[0] * 1000.0) >> 8);
                    //sendgroup4[53] = (byte)(int)(WData2[0] * 1000.0);
                    //sendgroup4[54] = (byte)((int)(WData2[1] * 1000.0) >> 24);
                    //sendgroup4[55] = (byte)((int)(WData2[1] * 1000.0) >> 16);
                    //sendgroup4[56] = (byte)((int)(WData2[1] * 1000.0) >> 8);
                    //sendgroup4[57] = (byte)(int)(WData2[1] * 1000.0);
                    //sendgroup4[58] = (byte)((int)(WData2[2] * 1000.0) >> 24);
                    //sendgroup4[59] = (byte)((int)(WData2[2] * 1000.0) >> 16);
                    //sendgroup4[60] = (byte)((int)(WData2[2] * 1000.0) >> 8);
                    //sendgroup4[61] = (byte)(int)(WData2[2] * 1000.0);
                    //sendgroup4[62] = (byte)((int)(MData2[0] * 1000.0) >> 24);
                    //sendgroup4[63] = (byte)((int)(MData2[0] * 1000.0) >> 16);
                    //sendgroup4[64] = (byte)((int)(MData2[0] * 1000.0) >> 8);
                    //sendgroup4[65] = (byte)(int)(MData2[0] * 1000.0);
                    //sendgroup4[66] = (byte)((int)(MData2[1] * 1000.0) >> 24);
                    //sendgroup4[67] = (byte)((int)(MData2[1] * 1000.0) >> 16);
                    //sendgroup4[68] = (byte)((int)(MData2[1] * 1000.0) >> 8);
                    //sendgroup4[69] = (byte)(int)(MData2[1] * 1000.0);
                    //sendgroup4[70] = (byte)((int)(MData2[2] * 1000.0) >> 24);
                    //sendgroup4[71] = (byte)((int)(MData2[2] * 1000.0) >> 16);
                    //sendgroup4[72] = (byte)((int)(MData2[2] * 1000.0) >> 8);
                    //sendgroup4[73] = (byte)(int)(MData2[2] * 1000.0);
                    #endregion send
                    remote2 = remoteEP;
				}
				catch
				{
					break;
				}
			}
		}
		private void ReceiveData2()
		{
			if (!first_tst_3)
			{
				IPEndPoint localEP = new IPEndPoint(ip, 3);
				receiveUdpClient2 = new UdpClient(localEP);
				first_tst_3 = true;
			}
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 9250);
			while (!exit3)
			{
				try
				{
					arrServerRecMsg2 = receiveUdpClient2.Receive(ref remoteEP);
					string @string = Encoding.Default.GetString(arrServerRecMsg2, 0, arrServerRecMsg2.Length);
					//if (@string[2] == 'O' && @string[3] == 'K')
					//{
					//	textBox7.Text = "DNOK";
					//}
					string[] array = @string.Split(',');
					Ax3 = array[0].Substring(14, array[0].Length - 14);
					Ay3 = array[1];
					Az3 = array[2];
					Wx3 = array[3];
					Wy3 = array[4];
					Wz3 = array[5];
					Angle_x3 = array[6];
					Angle_y3 = array[7];
					Angle_z3 = array[8];
					textBox56.Text = array[9] + "\r\n" + array[10] + "\r\n" + array[11] + "\r\n";
					Data2[0] = Convert.ToDouble(Angle_x3);
					Data2[1] = Convert.ToDouble(Angle_y3);
					Data2[2] = Convert.ToDouble(Angle_z3);
					Data2[0] += offset_x_2;
					Data2[1] += offset_y_2;
					Data2[2] += offset_z_2;
					Data2[0] += scroll_ofset_x_2;
					Data2[1] += scroll_ofset_y_2;
					Data2[2] += scroll_ofset_z_2;
					Mx3 = array[9];
					My3 = array[10];
					Mz3 = array[11];
					AData3[0] = Convert.ToDouble(Ax3);
					AData3[1] = Convert.ToDouble(Ay3);
					AData3[2] = Convert.ToDouble(Az3);
					WData3[0] = Convert.ToDouble(Wx3);
					WData3[1] = Convert.ToDouble(Wy3);
					WData3[2] = Convert.ToDouble(Wz3);
					MData3[0] = Convert.ToDouble(Mx3);
					MData3[1] = Convert.ToDouble(My3);
					MData3[2] = Convert.ToDouble(Mz3);
                    #region send
                    //sendgroup1[26] = (byte)((int)(Data2[0] * 1000.0) >> 24);
                    //sendgroup1[27] = (byte)((int)(Data2[0] * 1000.0) >> 16);
                    //sendgroup1[28] = (byte)((int)(Data2[0] * 1000.0) >> 8);
                    //sendgroup1[29] = (byte)(int)(Data2[0] * 1000.0);
                    //sendgroup1[30] = (byte)((int)(Data2[1] * 1000.0) >> 24);
                    //sendgroup1[31] = (byte)((int)(Data2[1] * 1000.0) >> 16);
                    //sendgroup1[32] = (byte)((int)(Data2[1] * 1000.0) >> 8);
                    //sendgroup1[33] = (byte)(int)(Data2[1] * 1000.0);
                    //sendgroup1[34] = (byte)((int)(Data2[2] * 1000.0) >> 24);
                    //sendgroup1[35] = (byte)((int)(Data2[2] * 1000.0) >> 16);
                    //sendgroup1[36] = (byte)((int)(Data2[2] * 1000.0) >> 8);
                    //sendgroup1[37] = (byte)(int)(Data2[2] * 1000.0);

                    //sendgroup4[74] = (byte)((int)(AData3[0] * 1000.0) >> 24);
                    //sendgroup4[75] = (byte)((int)(AData3[0] * 1000.0) >> 16);
                    //sendgroup4[76] = (byte)((int)(AData3[0] * 1000.0) >> 8);
                    //sendgroup4[77] = (byte)(int)(AData3[0] * 1000.0);
                    //sendgroup4[78] = (byte)((int)(AData3[1] * 1000.0) >> 24);
                    //sendgroup4[79] = (byte)((int)(AData3[1] * 1000.0) >> 16);
                    //sendgroup4[80] = (byte)((int)(AData3[1] * 1000.0) >> 8);
                    //sendgroup4[81] = (byte)(int)(AData3[1] * 1000.0);
                    //sendgroup4[82] = (byte)((int)(AData3[2] * 1000.0) >> 24);
                    //sendgroup4[83] = (byte)((int)(AData3[2] * 1000.0) >> 16);
                    //sendgroup4[84] = (byte)((int)(AData3[2] * 1000.0) >> 8);
                    //sendgroup4[85] = (byte)(int)(AData3[2] * 1000.0);
                    //sendgroup4[86] = (byte)((int)(WData3[0] * 1000.0) >> 24);
                    //sendgroup4[87] = (byte)((int)(WData3[0] * 1000.0) >> 16);
                    //sendgroup4[88] = (byte)((int)(WData3[0] * 1000.0) >> 8);
                    //sendgroup4[89] = (byte)(int)(WData3[0] * 1000.0);
                    //sendgroup4[90] = (byte)((int)(WData3[1] * 1000.0) >> 24);
                    //sendgroup4[91] = (byte)((int)(WData3[1] * 1000.0) >> 16);
                    //sendgroup4[92] = (byte)((int)(WData3[1] * 1000.0) >> 8);
                    //sendgroup4[93] = (byte)(int)(WData3[1] * 1000.0);
                    //sendgroup4[94] = (byte)((int)(WData3[2] * 1000.0) >> 24);
                    //sendgroup4[95] = (byte)((int)(WData3[2] * 1000.0) >> 16);
                    //sendgroup4[96] = (byte)((int)(WData3[2] * 1000.0) >> 8);
                    //sendgroup4[97] = (byte)(int)(WData3[2] * 1000.0);
                    //sendgroup4[98] = (byte)((int)(MData3[0] * 1000.0) >> 24);
                    //sendgroup4[99] = (byte)((int)(MData3[0] * 1000.0) >> 16);
                    //sendgroup4[100] = (byte)((int)(MData3[0] * 1000.0) >> 8);
                    //sendgroup4[101] = (byte)(int)(MData3[0] * 1000.0);
                    //sendgroup4[102] = (byte)((int)(MData3[1] * 1000.0) >> 24);
                    //sendgroup4[103] = (byte)((int)(MData3[1] * 1000.0) >> 16);
                    //sendgroup4[104] = (byte)((int)(MData3[1] * 1000.0) >> 8);
                    //sendgroup4[105] = (byte)(int)(MData3[1] * 1000.0);
                    //sendgroup4[106] = (byte)((int)(MData3[2] * 1000.0) >> 24);
                    //sendgroup4[107] = (byte)((int)(MData3[2] * 1000.0) >> 16);
                    //sendgroup4[108] = (byte)((int)(MData3[2] * 1000.0) >> 8);
                    //sendgroup4[109] = (byte)(int)(MData3[2] * 1000.0);
                    #endregion send
                    remote3 = remoteEP;
				}
				catch
				{
					break;
				}
			}
		}
		private void ReceiveData3()
		{
			if (!first_tst_4)
			{
				IPEndPoint localEP = new IPEndPoint(ip, 4);
				receiveUdpClient3 = new UdpClient(localEP);
				first_tst_4 = true;
			}
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 9250);
			while (!exit4)
			{
				try
				{
					arrServerRecMsg3 = receiveUdpClient3.Receive(ref remoteEP);
					string @string = Encoding.Default.GetString(arrServerRecMsg3, 0, arrServerRecMsg3.Length);
					//if (@string[2] == 'O' && @string[3] == 'K')
					//{
					//	textBox13.Text = "DNOK";
					//}
					string[] array = @string.Split(',');
					Ax4 = array[0].Substring(14, array[0].Length - 14);
					Ay4 = array[1];
					Az4 = array[2];
					Wx4 = array[3];
					Wy4 = array[4];
					Wz4 = array[5];
					Angle_x4 = array[6];
					Angle_y4 = array[7];
					Angle_z4 = array[8];
					textBox57.Text = array[9] + "\r\n" + array[10] + "\r\n" + array[11] + "\r\n";
					Data3[0] = Convert.ToDouble(Angle_x4);
					Data3[1] = Convert.ToDouble(Angle_y4);
					Data3[2] = Convert.ToDouble(Angle_z4);
					Data3[0] += offset_x_3;
					Data3[1] += offset_y_3;
					Data3[2] += offset_z_3;
					Data3[0] += scroll_ofset_x_3;
					Data3[1] += scroll_ofset_y_3;
					Data3[2] += scroll_ofset_z_3;
					Mx4 = array[9];
					My4 = array[10];
					Mz4 = array[11];
					AData4[0] = Convert.ToDouble(Ax4);
					AData4[1] = Convert.ToDouble(Ay4);
					AData4[2] = Convert.ToDouble(Az4);
					WData4[0] = Convert.ToDouble(Wx4);
					WData4[1] = Convert.ToDouble(Wy4);
					WData4[2] = Convert.ToDouble(Wz4);
					MData4[0] = Convert.ToDouble(Mx4);
					MData4[1] = Convert.ToDouble(My4);
					MData4[2] = Convert.ToDouble(Mz4);
                    #region send
                    //sendgroup1[38] = (byte)((int)(Data3[0] * 1000.0) >> 24);
					//sendgroup1[39] = (byte)((int)(Data3[0] * 1000.0) >> 16);
					//sendgroup1[40] = (byte)((int)(Data3[0] * 1000.0) >> 8);
					//sendgroup1[41] = (byte)(int)(Data3[0] * 1000.0);
					//sendgroup1[42] = (byte)((int)(Data3[1] * 1000.0) >> 24);
					//sendgroup1[43] = (byte)((int)(Data3[1] * 1000.0) >> 16);
					//sendgroup1[44] = (byte)((int)(Data3[1] * 1000.0) >> 8);
					//sendgroup1[45] = (byte)(int)(Data3[1] * 1000.0);
					//sendgroup1[46] = (byte)((int)(Data3[2] * 1000.0) >> 24);
					//sendgroup1[47] = (byte)((int)(Data3[2] * 1000.0) >> 16);
					//sendgroup1[48] = (byte)((int)(Data3[2] * 1000.0) >> 8);
					//sendgroup1[49] = (byte)(int)(Data3[2] * 1000.0);

					//sendgroup4[110] = (byte)((int)(AData4[0] * 1000.0) >> 24);
					//sendgroup4[111] = (byte)((int)(AData4[0] * 1000.0) >> 16);
					//sendgroup4[112] = (byte)((int)(AData4[0] * 1000.0) >> 8);
					//sendgroup4[113] = (byte)(int)(AData4[0] * 1000.0);
					//sendgroup4[114] = (byte)((int)(AData4[1] * 1000.0) >> 24);
					//sendgroup4[115] = (byte)((int)(AData4[1] * 1000.0) >> 16);
					//sendgroup4[116] = (byte)((int)(AData4[1] * 1000.0) >> 8);
					//sendgroup4[117] = (byte)(int)(AData4[1] * 1000.0);
					//sendgroup4[118] = (byte)((int)(AData4[2] * 1000.0) >> 24);
					//sendgroup4[119] = (byte)((int)(AData4[2] * 1000.0) >> 16);
					//sendgroup4[120] = (byte)((int)(AData4[2] * 1000.0) >> 8);
					//sendgroup4[121] = (byte)(int)(AData4[2] * 1000.0);
					//sendgroup4[122] = (byte)((int)(WData4[0] * 1000.0) >> 24);
					//sendgroup4[123] = (byte)((int)(WData4[0] * 1000.0) >> 16);
					//sendgroup4[124] = (byte)((int)(WData4[0] * 1000.0) >> 8);
					//sendgroup4[125] = (byte)(int)(WData4[0] * 1000.0);
					//sendgroup4[126] = (byte)((int)(WData4[1] * 1000.0) >> 24);
					//sendgroup4[127] = (byte)((int)(WData4[1] * 1000.0) >> 16);
					//sendgroup4[128] = (byte)((int)(WData4[1] * 1000.0) >> 8);
					//sendgroup4[129] = (byte)(int)(WData4[1] * 1000.0);
					//sendgroup4[130] = (byte)((int)(WData4[2] * 1000.0) >> 24);
					//sendgroup4[131] = (byte)((int)(WData4[2] * 1000.0) >> 16);
					//sendgroup4[132] = (byte)((int)(WData4[2] * 1000.0) >> 8);
					//sendgroup4[133] = (byte)(int)(WData4[2] * 1000.0);
					//sendgroup4[134] = (byte)((int)(MData4[0] * 1000.0) >> 24);
					//sendgroup4[135] = (byte)((int)(MData4[0] * 1000.0) >> 16);
					//sendgroup4[136] = (byte)((int)(MData4[0] * 1000.0) >> 8);
					//sendgroup4[137] = (byte)(int)(MData4[0] * 1000.0);
					//sendgroup4[138] = (byte)((int)(MData4[1] * 1000.0) >> 24);
					//sendgroup4[139] = (byte)((int)(MData4[1] * 1000.0) >> 16);
					//sendgroup4[140] = (byte)((int)(MData4[1] * 1000.0) >> 8);
					//sendgroup4[141] = (byte)(int)(MData4[1] * 1000.0);
					//sendgroup4[142] = (byte)((int)(MData4[2] * 1000.0) >> 24);
					//sendgroup4[143] = (byte)((int)(MData4[2] * 1000.0) >> 16);
					//sendgroup4[144] = (byte)((int)(MData4[2] * 1000.0) >> 8);
					//sendgroup4[145] = (byte)(int)(MData4[2] * 1000.0);
                    #endregion send
                    remote4 = remoteEP;
				}
				catch
				{
					break;
				}
			}
		}
		private void ReceiveData4()
		{
			if (!first_tst_5)
			{
				IPEndPoint localEP = new IPEndPoint(ip, 5);
				receiveUdpClient4 = new UdpClient(localEP);
				first_tst_5 = true;
			}
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 9250);
			while (!exit5)
			{
				try
				{
					arrServerRecMsg4 = receiveUdpClient4.Receive(ref remoteEP);
					string @string = Encoding.Default.GetString(arrServerRecMsg4, 0, arrServerRecMsg4.Length);
					//if (@string[2] == 'O' && @string[3] == 'K')
					//{
					//	textBox14.Text = "DNOK";
					//}
					string[] array = @string.Split(',');
					Ax5 = array[0].Substring(14, array[0].Length - 14);
					Ay5 = array[1];
					Az5 = array[2];
					Wx5 = array[3];
					Wy5 = array[4];
					Wz5 = array[5];
					Angle_x5 = array[6];
					Angle_y5 = array[7];
					Angle_z5 = array[8];
					textBox62.Text = array[9] + "\r\n" + array[10] + "\r\n" + array[11] + "\r\n";
					Data4[0] = Convert.ToDouble(Angle_x5);
					Data4[1] = Convert.ToDouble(Angle_y5);
					Data4[2] = Convert.ToDouble(Angle_z5);
					Data4[0] += offset_x_4;
					Data4[1] += offset_y_4;
					Data4[2] += offset_z_4;
					Data4[0] += scroll_ofset_x_4;
					Data4[1] += scroll_ofset_y_4;
					Data4[2] += scroll_ofset_z_4;
					Mx5 = array[9];
					My5 = array[10];
					Mz5 = array[11];
					AData5[0] = Convert.ToDouble(Ax5);
					AData5[1] = Convert.ToDouble(Ay5);
					AData5[2] = Convert.ToDouble(Az5);
					WData5[0] = Convert.ToDouble(Wx5);
					WData5[1] = Convert.ToDouble(Wy5);
					WData5[2] = Convert.ToDouble(Wz5);
					MData5[0] = Convert.ToDouble(Mx5);
					MData5[1] = Convert.ToDouble(My5);
					MData5[2] = Convert.ToDouble(Mz5);
                    #region send
     //               sendgroup2[2] = (byte)((int)(Data4[0] * 1000.0) >> 24);
					//sendgroup2[3] = (byte)((int)(Data4[0] * 1000.0) >> 16);
					//sendgroup2[4] = (byte)((int)(Data4[0] * 1000.0) >> 8);
					//sendgroup2[5] = (byte)(int)(Data4[0] * 1000.0);
					//sendgroup2[6] = (byte)((int)(Data4[1] * 1000.0) >> 24);
					//sendgroup2[7] = (byte)((int)(Data4[1] * 1000.0) >> 16);
					//sendgroup2[8] = (byte)((int)(Data4[1] * 1000.0) >> 8);
					//sendgroup2[9] = (byte)(int)(Data4[1] * 1000.0);
					//sendgroup2[10] = (byte)((int)(Data4[2] * 1000.0) >> 24);
					//sendgroup2[11] = (byte)((int)(Data4[2] * 1000.0) >> 16);
					//sendgroup2[12] = (byte)((int)(Data4[2] * 1000.0) >> 8);
					//sendgroup2[13] = (byte)(int)(Data4[2] * 1000.0);

					//sendgroup4[146] = (byte)((int)(AData5[0] * 1000.0) >> 24);
					//sendgroup4[147] = (byte)((int)(AData5[0] * 1000.0) >> 16);
					//sendgroup4[148] = (byte)((int)(AData5[0] * 1000.0) >> 8);
					//sendgroup4[149] = (byte)(int)(AData5[0] * 1000.0);
					//sendgroup4[150] = (byte)((int)(AData5[1] * 1000.0) >> 24);
					//sendgroup4[151] = (byte)((int)(AData5[1] * 1000.0) >> 16);
					//sendgroup4[152] = (byte)((int)(AData5[1] * 1000.0) >> 8);
					//sendgroup4[153] = (byte)(int)(AData5[1] * 1000.0);
					//sendgroup4[154] = (byte)((int)(AData5[2] * 1000.0) >> 24);
					//sendgroup4[155] = (byte)((int)(AData5[2] * 1000.0) >> 16);
					//sendgroup4[156] = (byte)((int)(AData5[2] * 1000.0) >> 8);
					//sendgroup4[157] = (byte)(int)(AData5[2] * 1000.0);
					//sendgroup4[158] = (byte)((int)(WData5[0] * 1000.0) >> 24);
					//sendgroup4[159] = (byte)((int)(WData5[0] * 1000.0) >> 16);
					//sendgroup4[160] = (byte)((int)(WData5[0] * 1000.0) >> 8);
					//sendgroup4[161] = (byte)(int)(WData5[0] * 1000.0);
					//sendgroup4[162] = (byte)((int)(WData5[1] * 1000.0) >> 24);
					//sendgroup4[163] = (byte)((int)(WData5[1] * 1000.0) >> 16);
					//sendgroup4[164] = (byte)((int)(WData5[1] * 1000.0) >> 8);
					//sendgroup4[165] = (byte)(int)(WData5[1] * 1000.0);
					//sendgroup4[166] = (byte)((int)(WData5[2] * 1000.0) >> 24);
					//sendgroup4[167] = (byte)((int)(WData5[2] * 1000.0) >> 16);
					//sendgroup4[168] = (byte)((int)(WData5[2] * 1000.0) >> 8);
					//sendgroup4[169] = (byte)(int)(WData5[2] * 1000.0);
					//sendgroup4[170] = (byte)((int)(MData5[0] * 1000.0) >> 24);
					//sendgroup4[171] = (byte)((int)(MData5[0] * 1000.0) >> 16);
					//sendgroup4[172] = (byte)((int)(MData5[0] * 1000.0) >> 8);
					//sendgroup4[173] = (byte)(int)(MData5[0] * 1000.0);
					//sendgroup4[174] = (byte)((int)(MData5[1] * 1000.0) >> 24);
					//sendgroup4[175] = (byte)((int)(MData5[1] * 1000.0) >> 16);
					//sendgroup4[176] = (byte)((int)(MData5[1] * 1000.0) >> 8);
					//sendgroup4[177] = (byte)(int)(MData5[1] * 1000.0);
					//sendgroup4[178] = (byte)((int)(MData5[2] * 1000.0) >> 24);
					//sendgroup4[179] = (byte)((int)(MData5[2] * 1000.0) >> 16);
					//sendgroup4[180] = (byte)((int)(MData5[2] * 1000.0) >> 8);
					//sendgroup4[181] = (byte)(int)(MData5[2] * 1000.0);
#endregion send
                    remote5 = remoteEP;
				}
				catch
				{
					break;
				}
			}
		}
		private void ReceiveData5()
		{
			if (!first_tst_6)
			{
				IPEndPoint localEP = new IPEndPoint(ip, 6);
				receiveUdpClient5 = new UdpClient(localEP);
				first_tst_6 = true;
			}
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 9250);
			while (!exit6)
			{
				try
				{
					arrServerRecMsg5 = receiveUdpClient5.Receive(ref remoteEP);
					string @string = Encoding.Default.GetString(arrServerRecMsg5, 0, arrServerRecMsg5.Length);
					//if (@string[2] == 'O' && @string[3] == 'K')
					//{
					//	textBox15.Text = "DNOK";
					//}
					string[] array = @string.Split(',');
					Ax6 = array[0].Substring(14, array[0].Length - 14);
					Ay6 = array[1];
					Az6 = array[2];
					Wx6 = array[3];
					Wy6 = array[4];
					Wz6 = array[5];
					Angle_x6 = array[6];
					Angle_y6 = array[7];
					Angle_z6 = array[8];
					textBox63.Text = array[9] + "\r\n" + array[10] + "\r\n" + array[11] + "\r\n";
					Data5[0] = Convert.ToDouble(Angle_x6);
					Data5[1] = Convert.ToDouble(Angle_y6);
					Data5[2] = Convert.ToDouble(Angle_z6);
					Data5[0] += offset_x_5;
					Data5[1] += offset_y_5;
					Data5[2] += offset_z_5;
					Data5[0] += scroll_ofset_x_5;
					Data5[1] += scroll_ofset_y_5;
					Data5[2] += scroll_ofset_z_5;
					Mx6 = array[9];
					My6 = array[10];
					Mz6 = array[11];
					AData6[0] = Convert.ToDouble(Ax6);
					AData6[1] = Convert.ToDouble(Ay6);
					AData6[2] = Convert.ToDouble(Az6);
					WData6[0] = Convert.ToDouble(Wx6);
					WData6[1] = Convert.ToDouble(Wy6);
					WData6[2] = Convert.ToDouble(Wz6);
					MData6[0] = Convert.ToDouble(Mx6);
					MData6[1] = Convert.ToDouble(My6);
					MData6[2] = Convert.ToDouble(Mz6);
                    #region send
     //               sendgroup2[14] = (byte)((int)(Data5[0] * 1000.0) >> 24);
					//sendgroup2[15] = (byte)((int)(Data5[0] * 1000.0) >> 16);
					//sendgroup2[16] = (byte)((int)(Data5[0] * 1000.0) >> 8);
					//sendgroup2[17] = (byte)(int)(Data5[0] * 1000.0);
					//sendgroup2[18] = (byte)((int)(Data5[1] * 1000.0) >> 24);
					//sendgroup2[19] = (byte)((int)(Data5[1] * 1000.0) >> 16);
					//sendgroup2[20] = (byte)((int)(Data5[1] * 1000.0) >> 8);
					//sendgroup2[21] = (byte)(int)(Data5[1] * 1000.0);
					//sendgroup2[22] = (byte)((int)(Data5[2] * 1000.0) >> 24);
					//sendgroup2[23] = (byte)((int)(Data5[2] * 1000.0) >> 16);
					//sendgroup2[24] = (byte)((int)(Data5[2] * 1000.0) >> 8);
					//sendgroup2[25] = (byte)(int)(Data5[2] * 1000.0);

					//sendgroup4[182] = (byte)((int)(AData6[0] * 1000.0) >> 24);
					//sendgroup4[183] = (byte)((int)(AData6[0] * 1000.0) >> 16);
					//sendgroup4[184] = (byte)((int)(AData6[0] * 1000.0) >> 8);
					//sendgroup4[185] = (byte)(int)(AData6[0] * 1000.0);
					//sendgroup4[186] = (byte)((int)(AData6[1] * 1000.0) >> 24);
					//sendgroup4[187] = (byte)((int)(AData6[1] * 1000.0) >> 16);
					//sendgroup4[188] = (byte)((int)(AData6[1] * 1000.0) >> 8);
					//sendgroup4[189] = (byte)(int)(AData6[1] * 1000.0);
					//sendgroup4[190] = (byte)((int)(AData6[2] * 1000.0) >> 24);
					//sendgroup4[191] = (byte)((int)(AData6[2] * 1000.0) >> 16);
					//sendgroup4[192] = (byte)((int)(AData6[2] * 1000.0) >> 8);
					//sendgroup4[193] = (byte)(int)(AData6[2] * 1000.0);
					//sendgroup4[194] = (byte)((int)(WData6[0] * 1000.0) >> 24);
					//sendgroup4[195] = (byte)((int)(WData6[0] * 1000.0) >> 16);
					//sendgroup4[196] = (byte)((int)(WData6[0] * 1000.0) >> 8);
					//sendgroup4[197] = (byte)(int)(WData6[0] * 1000.0);
					//sendgroup4[198] = (byte)((int)(WData6[1] * 1000.0) >> 24);
					//sendgroup4[199] = (byte)((int)(WData6[1] * 1000.0) >> 16);
					//sendgroup4[200] = (byte)((int)(WData6[1] * 1000.0) >> 8);
					//sendgroup4[201] = (byte)(int)(WData6[1] * 1000.0);
					//sendgroup4[202] = (byte)((int)(WData6[2] * 1000.0) >> 24);
					//sendgroup4[203] = (byte)((int)(WData6[2] * 1000.0) >> 16);
					//sendgroup4[204] = (byte)((int)(WData6[2] * 1000.0) >> 8);
					//sendgroup4[205] = (byte)(int)(WData6[2] * 1000.0);
					//sendgroup4[206] = (byte)((int)(MData6[0] * 1000.0) >> 24);
					//sendgroup4[207] = (byte)((int)(MData6[0] * 1000.0) >> 16);
					//sendgroup4[208] = (byte)((int)(MData6[0] * 1000.0) >> 8);
					//sendgroup4[209] = (byte)(int)(MData6[0] * 1000.0);
					//sendgroup4[210] = (byte)((int)(MData6[1] * 1000.0) >> 24);
					//sendgroup4[211] = (byte)((int)(MData6[1] * 1000.0) >> 16);
					//sendgroup4[212] = (byte)((int)(MData6[1] * 1000.0) >> 8);
					//sendgroup4[213] = (byte)(int)(MData6[1] * 1000.0);
					//sendgroup4[214] = (byte)((int)(MData6[2] * 1000.0) >> 24);
					//sendgroup4[215] = (byte)((int)(MData6[2] * 1000.0) >> 16);
					//sendgroup4[216] = (byte)((int)(MData6[2] * 1000.0) >> 8);
					//sendgroup4[217] = (byte)(int)(MData6[2] * 1000.0);
#endregion send
                    remote6 = remoteEP;
				}
				catch
				{
					break;
				}
			}
		}
		private void ReceiveData6()
		{
			if (!first_tst_7)
			{
				IPEndPoint localEP = new IPEndPoint(ip, 7);
				receiveUdpClient6 = new UdpClient(localEP);
				first_tst_7 = true;
			}
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 9250);
			while (!exit7)
			{
				try
				{
					arrServerRecMsg6 = receiveUdpClient6.Receive(ref remoteEP);
					string @string = Encoding.Default.GetString(arrServerRecMsg6, 0, arrServerRecMsg6.Length);
					//if (@string[2] == 'O' && @string[3] == 'K')
					//{
					//	textBox16.Text = "DNOK";
					//}
					string[] array = @string.Split(',');
					Ax7 = array[0].Substring(14, array[0].Length - 14);
					Ay7 = array[1];
					Az7 = array[2];
					Wx7 = array[3];
					Wy7 = array[4];
					Wz7 = array[5];
					Angle_x7 = array[6];
					Angle_y7 = array[7];
					Angle_z7 = array[8];
					textBox64.Text = array[9] + "\r\n" + array[10] + "\r\n" + array[11] + "\r\n";
					Data6[0] = Convert.ToDouble(Angle_x7);
					Data6[1] = Convert.ToDouble(Angle_y7);
					Data6[2] = Convert.ToDouble(Angle_z7);
					Data6[0] += offset_x_6;
					Data6[1] += offset_y_6;
					Data6[2] += offset_z_6;
					Data6[0] += scroll_ofset_x_6;
					Data6[1] += scroll_ofset_y_6;
					Data6[2] += scroll_ofset_z_6;
					Mx7 = array[9];
					My7 = array[10];
					Mz7 = array[11];
					AData7[0] = Convert.ToDouble(Ax7);
					AData7[1] = Convert.ToDouble(Ay7);
					AData7[2] = Convert.ToDouble(Az7);
					WData7[0] = Convert.ToDouble(Wx7);
					WData7[1] = Convert.ToDouble(Wy7);
					WData7[2] = Convert.ToDouble(Wz7);
					MData7[0] = Convert.ToDouble(Mx7);
					MData7[1] = Convert.ToDouble(My7);
					MData7[2] = Convert.ToDouble(Mz7);
                    #region send
     //               sendgroup2[26] = (byte)((int)(Data6[0] * 1000.0) >> 24);
					//sendgroup2[27] = (byte)((int)(Data6[0] * 1000.0) >> 16);
					//sendgroup2[28] = (byte)((int)(Data6[0] * 1000.0) >> 8);
					//sendgroup2[29] = (byte)(int)(Data6[0] * 1000.0);
					//sendgroup2[30] = (byte)((int)(Data6[1] * 1000.0) >> 24);
					//sendgroup2[31] = (byte)((int)(Data6[1] * 1000.0) >> 16);
					//sendgroup2[32] = (byte)((int)(Data6[1] * 1000.0) >> 8);
					//sendgroup2[33] = (byte)(int)(Data6[1] * 1000.0);
					//sendgroup2[34] = (byte)((int)(Data6[2] * 1000.0) >> 24);
					//sendgroup2[35] = (byte)((int)(Data6[2] * 1000.0) >> 16);
					//sendgroup2[36] = (byte)((int)(Data6[2] * 1000.0) >> 8);
					//sendgroup2[37] = (byte)(int)(Data6[2] * 1000.0);

					//sendgroup4[218] = (byte)((int)(AData7[0] * 1000.0) >> 24);
					//sendgroup4[219] = (byte)((int)(AData7[0] * 1000.0) >> 16);
					//sendgroup4[220] = (byte)((int)(AData7[0] * 1000.0) >> 8);
					//sendgroup4[221] = (byte)(int)(AData7[0] * 1000.0);
					//sendgroup4[222] = (byte)((int)(AData7[1] * 1000.0) >> 24);
					//sendgroup4[223] = (byte)((int)(AData7[1] * 1000.0) >> 16);
					//sendgroup4[224] = (byte)((int)(AData7[1] * 1000.0) >> 8);
					//sendgroup4[225] = (byte)(int)(AData7[1] * 1000.0);
					//sendgroup4[226] = (byte)((int)(AData7[2] * 1000.0) >> 24);
					//sendgroup4[227] = (byte)((int)(AData7[2] * 1000.0) >> 16);
					//sendgroup4[228] = (byte)((int)(AData7[2] * 1000.0) >> 8);
					//sendgroup4[229] = (byte)(int)(AData7[2] * 1000.0);
					//sendgroup4[230] = (byte)((int)(WData7[0] * 1000.0) >> 24);
					//sendgroup4[231] = (byte)((int)(WData7[0] * 1000.0) >> 16);
					//sendgroup4[232] = (byte)((int)(WData7[0] * 1000.0) >> 8);
					//sendgroup4[233] = (byte)(int)(WData7[0] * 1000.0);
					//sendgroup4[234] = (byte)((int)(WData7[1] * 1000.0) >> 24);
					//sendgroup4[235] = (byte)((int)(WData7[1] * 1000.0) >> 16);
					//sendgroup4[236] = (byte)((int)(WData7[1] * 1000.0) >> 8);
					//sendgroup4[237] = (byte)(int)(WData7[1] * 1000.0);
					//sendgroup4[238] = (byte)((int)(WData7[2] * 1000.0) >> 24);
					//sendgroup4[239] = (byte)((int)(WData7[2] * 1000.0) >> 16);
					//sendgroup4[240] = (byte)((int)(WData7[2] * 1000.0) >> 8);
					//sendgroup4[241] = (byte)(int)(WData7[2] * 1000.0);
					//sendgroup4[242] = (byte)((int)(MData7[0] * 1000.0) >> 24);
					//sendgroup4[243] = (byte)((int)(MData7[0] * 1000.0) >> 16);
					//sendgroup4[244] = (byte)((int)(MData7[0] * 1000.0) >> 8);
					//sendgroup4[245] = (byte)(int)(MData7[0] * 1000.0);
					//sendgroup4[246] = (byte)((int)(MData7[1] * 1000.0) >> 24);
					//sendgroup4[247] = (byte)((int)(MData7[1] * 1000.0) >> 16);
					//sendgroup4[248] = (byte)((int)(MData7[1] * 1000.0) >> 8);
					//sendgroup4[249] = (byte)(int)(MData7[1] * 1000.0);
					//sendgroup4[250] = (byte)((int)(MData7[2] * 1000.0) >> 24);
					//sendgroup4[251] = (byte)((int)(MData7[2] * 1000.0) >> 16);
					//sendgroup4[252] = (byte)((int)(MData7[2] * 1000.0) >> 8);
					//sendgroup4[253] = (byte)(int)(MData7[2] * 1000.0);
#endregion send
                    remote7 = remoteEP;
				}
				catch
				{
					break;
				}
			}
		}
		private void ReceiveData7()
		{
			if (!first_tst_8)
			{
				IPEndPoint localEP = new IPEndPoint(ip, 8);
				receiveUdpClient7 = new UdpClient(localEP);
				first_tst_8 = true;
			}
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 9250);
			while (!exit8)
			{
				try
				{
					arrServerRecMsg7 = receiveUdpClient7.Receive(ref remoteEP);
					string @string = Encoding.Default.GetString(arrServerRecMsg7, 0, arrServerRecMsg7.Length);
					//if (@string[2] == 'O' && @string[3] == 'K')
					//{
					//	textBox17.Text = "DNOK";
					//}
					string[] array = @string.Split(',');
					Ax8 = array[0].Substring(14, array[0].Length - 14);
					Ay8 = array[1];
					Az8 = array[2];
					Wx8 = array[3];
					Wy8 = array[4];
					Wz8 = array[5];
					Angle_x8 = array[6];
					Angle_y8 = array[7];
					Angle_z8 = array[8];
					textBox65.Text = array[9] + "\r\n" + array[10] + "\r\n" + array[11] + "\r\n";
					Data7[0] = Convert.ToDouble(Angle_x8);
					Data7[1] = Convert.ToDouble(Angle_y8);
					Data7[2] = Convert.ToDouble(Angle_z8);
					Data7[0] += offset_x_7;
					Data7[1] += offset_y_7;
					Data7[2] += offset_z_7;
					Data7[0] += scroll_ofset_x_7;
					Data7[1] += scroll_ofset_y_7;
					Data7[2] += scroll_ofset_z_7;
					Mx8 = array[9];
					My8 = array[10];
					Mz8 = array[11];
					AData8[0] = Convert.ToDouble(Ax8);
					AData8[1] = Convert.ToDouble(Ay8);
					AData8[2] = Convert.ToDouble(Az8);
					WData8[0] = Convert.ToDouble(Wx8);
					WData8[1] = Convert.ToDouble(Wy8);
					WData8[2] = Convert.ToDouble(Wz8);
					MData8[0] = Convert.ToDouble(Mx8);
					MData8[1] = Convert.ToDouble(My8);
					MData8[2] = Convert.ToDouble(Mz8);
                    #region send
     //               sendgroup2[38] = (byte)((int)(Data7[0] * 1000.0) >> 24);
					//sendgroup2[39] = (byte)((int)(Data7[0] * 1000.0) >> 16);
					//sendgroup2[40] = (byte)((int)(Data7[0] * 1000.0) >> 8);
					//sendgroup2[41] = (byte)(int)(Data7[0] * 1000.0);
					//sendgroup2[42] = (byte)((int)(Data7[1] * 1000.0) >> 24);
					//sendgroup2[43] = (byte)((int)(Data7[1] * 1000.0) >> 16);
					//sendgroup2[44] = (byte)((int)(Data7[1] * 1000.0) >> 8);
					//sendgroup2[45] = (byte)(int)(Data7[1] * 1000.0);
					//sendgroup2[46] = (byte)((int)(Data7[2] * 1000.0) >> 24);
					//sendgroup2[47] = (byte)((int)(Data7[2] * 1000.0) >> 16);
					//sendgroup2[48] = (byte)((int)(Data7[2] * 1000.0) >> 8);
					//sendgroup2[49] = (byte)(int)(Data7[2] * 1000.0);

					//sendgroup4[254] = (byte)((int)(AData8[0] * 1000.0) >> 24);
					//sendgroup4[255] = (byte)((int)(AData8[0] * 1000.0) >> 16);
					//sendgroup4[256] = (byte)((int)(AData8[0] * 1000.0) >> 8);
					//sendgroup4[257] = (byte)(int)(AData8[0] * 1000.0);
					//sendgroup4[258] = (byte)((int)(AData8[1] * 1000.0) >> 24);
					//sendgroup4[259] = (byte)((int)(AData8[1] * 1000.0) >> 16);
					//sendgroup4[260] = (byte)((int)(AData8[1] * 1000.0) >> 8);
					//sendgroup4[261] = (byte)(int)(AData8[1] * 1000.0);
					//sendgroup4[262] = (byte)((int)(AData8[2] * 1000.0) >> 24);
					//sendgroup4[263] = (byte)((int)(AData8[2] * 1000.0) >> 16);
					//sendgroup4[264] = (byte)((int)(AData8[2] * 1000.0) >> 8);
					//sendgroup4[265] = (byte)(int)(AData8[2] * 1000.0);
					//sendgroup4[266] = (byte)((int)(WData8[0] * 1000.0) >> 24);
					//sendgroup4[267] = (byte)((int)(WData8[0] * 1000.0) >> 16);
					//sendgroup4[268] = (byte)((int)(WData8[0] * 1000.0) >> 8);
					//sendgroup4[269] = (byte)(int)(WData8[0] * 1000.0);
					//sendgroup4[270] = (byte)((int)(WData8[1] * 1000.0) >> 24);
					//sendgroup4[271] = (byte)((int)(WData8[1] * 1000.0) >> 16);
					//sendgroup4[272] = (byte)((int)(WData8[1] * 1000.0) >> 8);
					//sendgroup4[273] = (byte)(int)(WData8[1] * 1000.0);
					//sendgroup4[274] = (byte)((int)(WData8[2] * 1000.0) >> 24);
					//sendgroup4[275] = (byte)((int)(WData8[2] * 1000.0) >> 16);
					//sendgroup4[276] = (byte)((int)(WData8[2] * 1000.0) >> 8);
					//sendgroup4[277] = (byte)(int)(WData8[2] * 1000.0);
					//sendgroup4[278] = (byte)((int)(MData8[0] * 1000.0) >> 24);
					//sendgroup4[279] = (byte)((int)(MData8[0] * 1000.0) >> 16);
					//sendgroup4[280] = (byte)((int)(MData8[0] * 1000.0) >> 8);
					//sendgroup4[281] = (byte)(int)(MData8[0] * 1000.0);
					//sendgroup4[282] = (byte)((int)(MData8[1] * 1000.0) >> 24);
					//sendgroup4[283] = (byte)((int)(MData8[1] * 1000.0) >> 16);
					//sendgroup4[284] = (byte)((int)(MData8[1] * 1000.0) >> 8);
					//sendgroup4[285] = (byte)(int)(MData8[1] * 1000.0);
					//sendgroup4[286] = (byte)((int)(MData8[2] * 1000.0) >> 24);
					//sendgroup4[287] = (byte)((int)(MData8[2] * 1000.0) >> 16);
					//sendgroup4[288] = (byte)((int)(MData8[2] * 1000.0) >> 8);
					//sendgroup4[289] = (byte)(int)(MData8[2] * 1000.0);
#endregion send
                    remote8 = remoteEP;
				}
				catch
				{
					break;
				}
			}
		}
		private void ReceiveData8()
		{
			if (!first_tst_9)
			{
				IPEndPoint localEP = new IPEndPoint(ip, 9);
				receiveUdpClient8 = new UdpClient(localEP);
				first_tst_9 = true;
			}
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 9250);
			while (!exit9)
			{
				try
				{
					arrServerRecMsg8 = receiveUdpClient8.Receive(ref remoteEP);
					string @string = Encoding.Default.GetString(arrServerRecMsg8, 0, arrServerRecMsg8.Length);
					//if (@string[2] == 'O' && @string[3] == 'K')
					//{
					//	textBox18.Text = "DNOK";
					//}
					string[] array = @string.Split(',');
					Ax9 = array[0].Substring(14, array[0].Length - 14);
					Ay9 = array[1];
					Az9 = array[2];
					Wx9 = array[3];
					Wy9 = array[4];
					Wz9 = array[5];
					Angle_x9 = array[6];
					Angle_y9 = array[7];
					Angle_z9 = array[8];
					textBox53.Text = array[9] + "\r\n" + array[10] + "\r\n" + array[11] + "\r\n";
					Data8[0] = Convert.ToDouble(Angle_x9);
					Data8[1] = Convert.ToDouble(Angle_y9);
					Data8[2] = Convert.ToDouble(Angle_z9);
					Data8[0] += offset_x_8;
					Data8[1] += offset_y_8;
					Data8[2] += offset_z_8;
					Data8[0] += scroll_ofset_x_8;
					Data8[1] += scroll_ofset_y_8;
					Data8[2] += scroll_ofset_z_8;
					Mx9 = array[9];
					My9 = array[10];
					Mz9 = array[11];
					AData9[0] = Convert.ToDouble(Ax9);
					AData9[1] = Convert.ToDouble(Ay9);
					AData9[2] = Convert.ToDouble(Az9);
					WData9[0] = Convert.ToDouble(Wx9);
					WData9[1] = Convert.ToDouble(Wy9);
					WData9[2] = Convert.ToDouble(Wz9);
					MData9[0] = Convert.ToDouble(Mx9);
					MData9[1] = Convert.ToDouble(My9);
					MData9[2] = Convert.ToDouble(Mz9);
                    #region send
     //               sendgroup3[2] = (byte)((int)(Data8[0] * 1000.0) >> 24);
					//sendgroup3[3] = (byte)((int)(Data8[0] * 1000.0) >> 16);
					//sendgroup3[4] = (byte)((int)(Data8[0] * 1000.0) >> 8);
					//sendgroup3[5] = (byte)(int)(Data8[0] * 1000.0);
					//sendgroup3[6] = (byte)((int)(Data8[1] * 1000.0) >> 24);
					//sendgroup3[7] = (byte)((int)(Data8[1] * 1000.0) >> 16);
					//sendgroup3[8] = (byte)((int)(Data8[1] * 1000.0) >> 8);
					//sendgroup3[9] = (byte)(int)(Data8[1] * 1000.0);
					//sendgroup3[10] = (byte)((int)(Data8[2] * 1000.0) >> 24);
					//sendgroup3[11] = (byte)((int)(Data8[2] * 1000.0) >> 16);
					//sendgroup3[12] = (byte)((int)(Data8[2] * 1000.0) >> 8);
					//sendgroup3[13] = (byte)(int)(Data8[2] * 1000.0);

					//sendgroup4[290] = (byte)((int)(AData9[0] * 1000.0) >> 24);
					//sendgroup4[291] = (byte)((int)(AData9[0] * 1000.0) >> 16);
					//sendgroup4[292] = (byte)((int)(AData9[0] * 1000.0) >> 8);
					//sendgroup4[293] = (byte)(int)(AData9[0] * 1000.0);
					//sendgroup4[294] = (byte)((int)(AData9[1] * 1000.0) >> 24);
					//sendgroup4[295] = (byte)((int)(AData9[1] * 1000.0) >> 16);
					//sendgroup4[296] = (byte)((int)(AData9[1] * 1000.0) >> 8);
					//sendgroup4[297] = (byte)(int)(AData9[1] * 1000.0);
					//sendgroup4[298] = (byte)((int)(AData9[2] * 1000.0) >> 24);
					//sendgroup4[299] = (byte)((int)(AData9[2] * 1000.0) >> 16);
					//sendgroup4[300] = (byte)((int)(AData9[2] * 1000.0) >> 8);
					//sendgroup4[301] = (byte)(int)(AData9[2] * 1000.0);
					//sendgroup4[302] = (byte)((int)(WData9[0] * 1000.0) >> 24);
					//sendgroup4[303] = (byte)((int)(WData9[0] * 1000.0) >> 16);
					//sendgroup4[304] = (byte)((int)(WData9[0] * 1000.0) >> 8);
					//sendgroup4[305] = (byte)(int)(WData9[0] * 1000.0);
					//sendgroup4[306] = (byte)((int)(WData9[1] * 1000.0) >> 24);
					//sendgroup4[307] = (byte)((int)(WData9[1] * 1000.0) >> 16);
					//sendgroup4[308] = (byte)((int)(WData9[1] * 1000.0) >> 8);
					//sendgroup4[309] = (byte)(int)(WData9[1] * 1000.0);
					//sendgroup4[310] = (byte)((int)(WData9[2] * 1000.0) >> 24);
					//sendgroup4[311] = (byte)((int)(WData9[2] * 1000.0) >> 16);
					//sendgroup4[312] = (byte)((int)(WData9[2] * 1000.0) >> 8);
					//sendgroup4[313] = (byte)(int)(WData9[2] * 1000.0);
					//sendgroup4[314] = (byte)((int)(MData9[0] * 1000.0) >> 24);
					//sendgroup4[315] = (byte)((int)(MData9[0] * 1000.0) >> 16);
					//sendgroup4[316] = (byte)((int)(MData9[0] * 1000.0) >> 8);
					//sendgroup4[317] = (byte)(int)(MData9[0] * 1000.0);
					//sendgroup4[318] = (byte)((int)(MData9[1] * 1000.0) >> 24);
					//sendgroup4[319] = (byte)((int)(MData9[1] * 1000.0) >> 16);
					//sendgroup4[320] = (byte)((int)(MData9[1] * 1000.0) >> 8);
					//sendgroup4[321] = (byte)(int)(MData9[1] * 1000.0);
					//sendgroup4[322] = (byte)((int)(MData9[2] * 1000.0) >> 24);
					//sendgroup4[323] = (byte)((int)(MData9[2] * 1000.0) >> 16);
					//sendgroup4[324] = (byte)((int)(MData9[2] * 1000.0) >> 8);
					//sendgroup4[325] = (byte)(int)(MData9[2] * 1000.0);
#endregion send
                    remote9 = remoteEP;
				}
				catch
				{
					break;
				}
			}
		}
		private void ReceiveData9()
		{
			if (!first_tst_10)
			{
				IPEndPoint localEP = new IPEndPoint(ip, 10);
				receiveUdpClient9 = new UdpClient(localEP);
				first_tst_10 = true;
			}
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 9250);
			while (!exit10)
			{
				try
				{
					arrServerRecMsg9 = receiveUdpClient9.Receive(ref remoteEP);
					string @string = Encoding.Default.GetString(arrServerRecMsg9, 0, arrServerRecMsg9.Length);
					//if (@string[2] == 'O' && @string[3] == 'K')
					//{
					//	textBox40.Text = "DNOK";
					//}
					string[] array = @string.Split(',');
					Ax10 = array[0].Substring(14, array[0].Length - 14);
					Ay10 = array[1];
					Az10 = array[2];
					Wx10 = array[3];
					Wy10 = array[4];
					Wz10 = array[5];
					Angle_x10 = array[6];
					Angle_y10 = array[7];
					Angle_z10 = array[8];
					textBox58.Text = array[9] + "\r\n" + array[10] + "\r\n" + array[11] + "\r\n";
					Data9[0] = Convert.ToDouble(Angle_x10);
					Data9[1] = Convert.ToDouble(Angle_y10);
					Data9[2] = Convert.ToDouble(Angle_z10);
					Data9[0] += offset_x_9;
					Data9[1] += offset_y_9;
					Data9[2] += offset_z_9;
					Data9[0] += scroll_ofset_x_9;
					Data9[1] += scroll_ofset_y_9;
					Data9[2] += scroll_ofset_z_9;
					Mx10 = array[9];
					My10 = array[10];
					Mz10 = array[11];
					AData10[0] = Convert.ToDouble(Ax10);
					AData10[1] = Convert.ToDouble(Ay10);
					AData10[2] = Convert.ToDouble(Az10);
					WData10[0] = Convert.ToDouble(Wx10);
					WData10[1] = Convert.ToDouble(Wy10);
					WData10[2] = Convert.ToDouble(Wz10);
					MData10[0] = Convert.ToDouble(Mx10);
					MData10[1] = Convert.ToDouble(My10);
					MData10[2] = Convert.ToDouble(Mz10);
                    #region send
                    //sendgroup3[14] = (byte)((int)(Data9[0] * 1000.0) >> 24);
                    //sendgroup3[15] = (byte)((int)(Data9[0] * 1000.0) >> 16);
                    //sendgroup3[16] = (byte)((int)(Data9[0] * 1000.0) >> 8);
                    //sendgroup3[17] = (byte)(int)(Data9[0] * 1000.0);
                    //sendgroup3[18] = (byte)((int)(Data9[1] * 1000.0) >> 24);
                    //sendgroup3[19] = (byte)((int)(Data9[1] * 1000.0) >> 16);
                    //sendgroup3[20] = (byte)((int)(Data9[1] * 1000.0) >> 8);
                    //sendgroup3[21] = (byte)(int)(Data9[1] * 1000.0);
                    //sendgroup3[22] = (byte)((int)(Data9[2] * 1000.0) >> 24);
                    //sendgroup3[23] = (byte)((int)(Data9[2] * 1000.0) >> 16);
                    //sendgroup3[24] = (byte)((int)(Data9[2] * 1000.0) >> 8);
                    //sendgroup3[25] = (byte)(int)(Data9[2] * 1000.0);

                    //sendgroup4[326] = (byte)((int)(AData10[0] * 1000.0) >> 24);
                    //sendgroup4[327] = (byte)((int)(AData10[0] * 1000.0) >> 16);
                    //sendgroup4[328] = (byte)((int)(AData10[0] * 1000.0) >> 8);
                    //sendgroup4[329] = (byte)(int)(AData10[0] * 1000.0);
                    //sendgroup4[330] = (byte)((int)(AData10[1] * 1000.0) >> 24);
                    //sendgroup4[331] = (byte)((int)(AData10[1] * 1000.0) >> 16);
                    //sendgroup4[332] = (byte)((int)(AData10[1] * 1000.0) >> 8);
                    //sendgroup4[333] = (byte)(int)(AData10[1] * 1000.0);
                    //sendgroup4[334] = (byte)((int)(AData10[2] * 1000.0) >> 24);
                    //sendgroup4[335] = (byte)((int)(AData10[2] * 1000.0) >> 16);
                    //sendgroup4[336] = (byte)((int)(AData10[2] * 1000.0) >> 8);
                    //sendgroup4[337] = (byte)(int)(AData10[2] * 1000.0);
                    //sendgroup4[338] = (byte)((int)(WData10[0] * 1000.0) >> 24);
                    //sendgroup4[339] = (byte)((int)(WData10[0] * 1000.0) >> 16);
                    //sendgroup4[340] = (byte)((int)(WData10[0] * 1000.0) >> 8);
                    //sendgroup4[341] = (byte)(int)(WData10[0] * 1000.0);
                    //sendgroup4[342] = (byte)((int)(WData10[1] * 1000.0) >> 24);
                    //sendgroup4[343] = (byte)((int)(WData10[1] * 1000.0) >> 16);
                    //sendgroup4[344] = (byte)((int)(WData10[1] * 1000.0) >> 8);
                    //sendgroup4[345] = (byte)(int)(WData10[1] * 1000.0);
                    //sendgroup4[346] = (byte)((int)(WData10[2] * 1000.0) >> 24);
                    //sendgroup4[347] = (byte)((int)(WData10[2] * 1000.0) >> 16);
                    //sendgroup4[348] = (byte)((int)(WData10[2] * 1000.0) >> 8);
                    //sendgroup4[349] = (byte)(int)(WData10[2] * 1000.0);
                    //sendgroup4[350] = (byte)((int)(MData10[0] * 1000.0) >> 24);
                    //sendgroup4[351] = (byte)((int)(MData10[0] * 1000.0) >> 16);
                    //sendgroup4[352] = (byte)((int)(MData10[0] * 1000.0) >> 8);
                    //sendgroup4[353] = (byte)(int)(MData10[0] * 1000.0);
                    //sendgroup4[354] = (byte)((int)(MData10[1] * 1000.0) >> 24);
                    //sendgroup4[355] = (byte)((int)(MData10[1] * 1000.0) >> 16);
                    //sendgroup4[356] = (byte)((int)(MData10[1] * 1000.0) >> 8);
                    //sendgroup4[357] = (byte)(int)(MData10[1] * 1000.0);
                    //sendgroup4[358] = (byte)((int)(MData10[2] * 1000.0) >> 24);
                    //sendgroup4[359] = (byte)((int)(MData10[2] * 1000.0) >> 16);
                    //sendgroup4[360] = (byte)((int)(MData10[2] * 1000.0) >> 8);
                    //sendgroup4[361] = (byte)(int)(MData10[2] * 1000.0);
                    #endregion send
                    remote10 = remoteEP;
				}
				catch
				{
					break;
				}
			}
		}
		private void ReceiveData10()
		{
			if (!first_tst_11)
			{
				IPEndPoint localEP = new IPEndPoint(ip, 11);
				receiveUdpClient10 = new UdpClient(localEP);
				first_tst_11 = true;
			}
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 9250);
			while (!exit11)
			{
				try
				{
					arrServerRecMsg10 = receiveUdpClient10.Receive(ref remoteEP);
					string @string = Encoding.Default.GetString(arrServerRecMsg10, 0, arrServerRecMsg10.Length);
					//if (@string[2] == 'O' && @string[3] == 'K')
					//{
					//	textBox49.Text = "DNOK";
					//}
					string[] array = @string.Split(',');
					Ax11 = array[0].Substring(14, array[0].Length - 14);
					Ay11 = array[1];
					Az11 = array[2];
					Wx11 = array[3];
					Wy11 = array[4];
					Wz11 = array[5];
					Angle_x11 = array[6];
					Angle_y11 = array[7];
					Angle_z11 = array[8];
					textBox59.Text = array[9] + "\r\n" + array[10] + "\r\n" + array[11] + "\r\n";
					Data10[0] = Convert.ToDouble(Angle_x11);
					Data10[1] = Convert.ToDouble(Angle_y11);
					Data10[2] = Convert.ToDouble(Angle_z11);
					Data10[0] += offset_x_10;
					Data10[1] += offset_y_10;
					Data10[2] += offset_z_10;
					Data10[0] += scroll_ofset_x_10;
					Data10[1] += scroll_ofset_y_10;
					Data10[2] += scroll_ofset_z_10;
					Mx11 = array[9];
					My11 = array[10];
					Mz11 = array[11];
					AData11[0] = Convert.ToDouble(Ax11);
					AData11[1] = Convert.ToDouble(Ay11);
					AData11[2] = Convert.ToDouble(Az11);
					WData11[0] = Convert.ToDouble(Wx11);
					WData11[1] = Convert.ToDouble(Wy11);
					WData11[2] = Convert.ToDouble(Wz11);
					MData11[0] = Convert.ToDouble(Mx11);
					MData11[1] = Convert.ToDouble(My11);
					MData11[2] = Convert.ToDouble(Mz11);
                    #region send
     //               sendgroup3[26] = (byte)((int)(Data10[0] * 1000.0) >> 24);
					//sendgroup3[27] = (byte)((int)(Data10[0] * 1000.0) >> 16);
					//sendgroup3[28] = (byte)((int)(Data10[0] * 1000.0) >> 8);
					//sendgroup3[29] = (byte)(int)(Data10[0] * 1000.0);
					//sendgroup3[30] = (byte)((int)(Data10[1] * 1000.0) >> 24);
					//sendgroup3[31] = (byte)((int)(Data10[1] * 1000.0) >> 16);
					//sendgroup3[32] = (byte)((int)(Data10[1] * 1000.0) >> 8);
					//sendgroup3[33] = (byte)(int)(Data10[1] * 1000.0);
					//sendgroup3[34] = (byte)((int)(Data10[2] * 1000.0) >> 24);
					//sendgroup3[35] = (byte)((int)(Data10[2] * 1000.0) >> 16);
					//sendgroup3[36] = (byte)((int)(Data10[2] * 1000.0) >> 8);
					//sendgroup3[37] = (byte)(int)(Data10[2] * 1000.0);

					//sendgroup4[362] = (byte)((int)(AData11[0] * 1000.0) >> 24);
					//sendgroup4[363] = (byte)((int)(AData11[0] * 1000.0) >> 16);
					//sendgroup4[364] = (byte)((int)(AData11[0] * 1000.0) >> 8);
					//sendgroup4[365] = (byte)(int)(AData11[0] * 1000.0);
					//sendgroup4[366] = (byte)((int)(AData11[1] * 1000.0) >> 24);
					//sendgroup4[367] = (byte)((int)(AData11[1] * 1000.0) >> 16);
					//sendgroup4[368] = (byte)((int)(AData11[1] * 1000.0) >> 8);
					//sendgroup4[369] = (byte)(int)(AData11[1] * 1000.0);
					//sendgroup4[370] = (byte)((int)(AData11[2] * 1000.0) >> 24);
					//sendgroup4[371] = (byte)((int)(AData11[2] * 1000.0) >> 16);
					//sendgroup4[372] = (byte)((int)(AData11[2] * 1000.0) >> 8);
					//sendgroup4[373] = (byte)(int)(AData11[2] * 1000.0);
					//sendgroup4[374] = (byte)((int)(WData11[0] * 1000.0) >> 24);
					//sendgroup4[375] = (byte)((int)(WData11[0] * 1000.0) >> 16);
					//sendgroup4[376] = (byte)((int)(WData11[0] * 1000.0) >> 8);
					//sendgroup4[377] = (byte)(int)(WData11[0] * 1000.0);
					//sendgroup4[378] = (byte)((int)(WData11[1] * 1000.0) >> 24);
					//sendgroup4[379] = (byte)((int)(WData11[1] * 1000.0) >> 16);
					//sendgroup4[380] = (byte)((int)(WData11[1] * 1000.0) >> 8);
					//sendgroup4[381] = (byte)(int)(WData11[1] * 1000.0);
					//sendgroup4[382] = (byte)((int)(WData11[2] * 1000.0) >> 24);
					//sendgroup4[383] = (byte)((int)(WData11[2] * 1000.0) >> 16);
					//sendgroup4[384] = (byte)((int)(WData11[2] * 1000.0) >> 8);
					//sendgroup4[385] = (byte)(int)(WData11[2] * 1000.0);
					//sendgroup4[386] = (byte)((int)(MData11[0] * 1000.0) >> 24);
					//sendgroup4[387] = (byte)((int)(MData11[0] * 1000.0) >> 16);
					//sendgroup4[388] = (byte)((int)(MData11[0] * 1000.0) >> 8);
					//sendgroup4[389] = (byte)(int)(MData11[0] * 1000.0);
					//sendgroup4[390] = (byte)((int)(MData11[1] * 1000.0) >> 24);
					//sendgroup4[391] = (byte)((int)(MData11[1] * 1000.0) >> 16);
					//sendgroup4[392] = (byte)((int)(MData11[1] * 1000.0) >> 8);
					//sendgroup4[393] = (byte)(int)(MData11[1] * 1000.0);
					//sendgroup4[394] = (byte)((int)(MData11[2] * 1000.0) >> 24);
					//sendgroup4[395] = (byte)((int)(MData11[2] * 1000.0) >> 16);
					//sendgroup4[396] = (byte)((int)(MData11[2] * 1000.0) >> 8);
					//sendgroup4[397] = (byte)(int)(MData11[2] * 1000.0);
#endregion send
                    remote11 = remoteEP;
				}
				catch
				{
					break;
				}
			}
		}
		private void ReceiveData11()
		{
			if (!first_tst_12)
			{
				IPEndPoint localEP = new IPEndPoint(ip, 12);
				receiveUdpClient11 = new UdpClient(localEP);
				first_tst_12 = true;
			}
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 9250);
			while (!exit12)
			{
				try
				{
					arrServerRecMsg11 = receiveUdpClient11.Receive(ref remoteEP);
					string @string = Encoding.Default.GetString(arrServerRecMsg11, 0, arrServerRecMsg11.Length);
					//if (@string[2] == 'O' && @string[3] == 'K')
					//{
					//	textBox41.Text = "DNOK";
					//}
					string[] array = @string.Split(',');
					Ax12 = array[0].Substring(14, array[0].Length - 14);
					Ay12 = array[1];
					Az12 = array[2];
					Wx12 = array[3];
					Wy12 = array[4];
					Wz12 = array[5];
					Angle_x12 = array[6];
					Angle_y12 = array[7];
					Angle_z12 = array[8];
					textBox60.Text = array[9] + "\r\n" + array[10] + "\r\n" + array[11] + "\r\n";
					Data11[0] = Convert.ToDouble(Angle_x12);
					Data11[1] = Convert.ToDouble(Angle_y12);
					Data11[2] = Convert.ToDouble(Angle_z12);
					Data11[0] += offset_x_11;
					Data11[1] += offset_y_11;
					Data11[2] += offset_z_11;
					Data11[0] += scroll_ofset_x_11;
					Data11[1] += scroll_ofset_y_11;
					Data11[2] += scroll_ofset_z_11;
					Mx12 = array[9];
					My12 = array[10];
					Mz12 = array[11];
					AData12[0] = Convert.ToDouble(Ax12);
					AData12[1] = Convert.ToDouble(Ay12);
					AData12[2] = Convert.ToDouble(Az12);
					WData12[0] = Convert.ToDouble(Wx12);
					WData12[1] = Convert.ToDouble(Wy12);
					WData12[2] = Convert.ToDouble(Wz12);
					MData12[0] = Convert.ToDouble(Mx12);
					MData12[1] = Convert.ToDouble(My12);
					MData12[2] = Convert.ToDouble(Mz12);
                    #region send
     //               sendgroup3[38] = (byte)((int)(Data11[0] * 1000.0) >> 24);
					//sendgroup3[39] = (byte)((int)(Data11[0] * 1000.0) >> 16);
					//sendgroup3[40] = (byte)((int)(Data11[0] * 1000.0) >> 8);
					//sendgroup3[41] = (byte)(int)(Data11[0] * 1000.0);
					//sendgroup3[42] = (byte)((int)(Data11[1] * 1000.0) >> 24);
					//sendgroup3[43] = (byte)((int)(Data11[1] * 1000.0) >> 16);
					//sendgroup3[44] = (byte)((int)(Data11[1] * 1000.0) >> 8);
					//sendgroup3[45] = (byte)(int)(Data11[1] * 1000.0);
					//sendgroup3[46] = (byte)((int)(Data11[2] * 1000.0) >> 24);
					//sendgroup3[47] = (byte)((int)(Data11[2] * 1000.0) >> 16);
					//sendgroup3[48] = (byte)((int)(Data11[2] * 1000.0) >> 8);
					//sendgroup3[49] = (byte)(int)(Data11[2] * 1000.0);

					//sendgroup4[398] = (byte)((int)(AData12[0] * 1000.0) >> 24);
					//sendgroup4[399] = (byte)((int)(AData12[0] * 1000.0) >> 16);
					//sendgroup4[400] = (byte)((int)(AData12[0] * 1000.0) >> 8);
					//sendgroup4[401] = (byte)(int)(AData12[0] * 1000.0);
					//sendgroup4[402] = (byte)((int)(AData12[1] * 1000.0) >> 24);
					//sendgroup4[403] = (byte)((int)(AData12[1] * 1000.0) >> 16);
					//sendgroup4[404] = (byte)((int)(AData12[1] * 1000.0) >> 8);
					//sendgroup4[405] = (byte)(int)(AData12[1] * 1000.0);
					//sendgroup4[406] = (byte)((int)(AData12[2] * 1000.0) >> 24);
					//sendgroup4[407] = (byte)((int)(AData12[2] * 1000.0) >> 16);
					//sendgroup4[408] = (byte)((int)(AData12[2] * 1000.0) >> 8);
					//sendgroup4[409] = (byte)(int)(AData12[2] * 1000.0);
					//sendgroup4[410] = (byte)((int)(WData12[0] * 1000.0) >> 24);
					//sendgroup4[411] = (byte)((int)(WData12[0] * 1000.0) >> 16);
					//sendgroup4[412] = (byte)((int)(WData12[0] * 1000.0) >> 8);
					//sendgroup4[413] = (byte)(int)(WData12[0] * 1000.0);
					//sendgroup4[414] = (byte)((int)(WData12[1] * 1000.0) >> 24);
					//sendgroup4[415] = (byte)((int)(WData12[1] * 1000.0) >> 16);
					//sendgroup4[416] = (byte)((int)(WData12[1] * 1000.0) >> 8);
					//sendgroup4[417] = (byte)(int)(WData12[1] * 1000.0);
					//sendgroup4[418] = (byte)((int)(WData12[2] * 1000.0) >> 24);
					//sendgroup4[419] = (byte)((int)(WData12[2] * 1000.0) >> 16);
					//sendgroup4[420] = (byte)((int)(WData12[2] * 1000.0) >> 8);
					//sendgroup4[421] = (byte)(int)(WData12[2] * 1000.0);
					//sendgroup4[422] = (byte)((int)(MData12[0] * 1000.0) >> 24);
					//sendgroup4[423] = (byte)((int)(MData12[0] * 1000.0) >> 16);
					//sendgroup4[424] = (byte)((int)(MData12[0] * 1000.0) >> 8);
					//sendgroup4[425] = (byte)(int)(MData12[0] * 1000.0);
					//sendgroup4[426] = (byte)((int)(MData12[1] * 1000.0) >> 24);
					//sendgroup4[427] = (byte)((int)(MData12[1] * 1000.0) >> 16);
					//sendgroup4[428] = (byte)((int)(MData12[1] * 1000.0) >> 8);
					//sendgroup4[429] = (byte)(int)(MData12[1] * 1000.0);
					//sendgroup4[430] = (byte)((int)(MData12[2] * 1000.0) >> 24);
					//sendgroup4[431] = (byte)((int)(MData12[2] * 1000.0) >> 16);
					//sendgroup4[432] = (byte)((int)(MData12[2] * 1000.0) >> 8);
					//sendgroup4[433] = (byte)(int)(MData12[2] * 1000.0);
#endregion send
                    remote12 = remoteEP;
				}
				catch
				{
					break;
				}
			}
		}
		private void ReceiveData12()
		{
			if (!first_tst_13)
			{
				IPEndPoint localEP = new IPEndPoint(ip, 13);
				receiveUdpClient12 = new UdpClient(localEP);
				first_tst_13 = true;
			}
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 9250);
			while (!exit13)
			{
				try
				{
					arrServerRecMsg12 = receiveUdpClient12.Receive(ref remoteEP);
					string @string = Encoding.Default.GetString(arrServerRecMsg12, 0, arrServerRecMsg12.Length);
					//if (@string[2] == 'O' && @string[3] == 'K')
					//{
					//	textBox45.Text = "DNOK";
					//}
					string[] array = @string.Split(',');
					Ax13 = array[0].Substring(14, array[0].Length - 14);
					Ay13 = array[1];
					Az13 = array[2];
					Wx13 = array[3];
					Wy13 = array[4];
					Wz13 = array[5];
					Angle_x13 = array[6];
					Angle_y13 = array[7];
					Angle_z13 = array[8];
					textBox61.Text = array[9] + "\r\n" + array[10] + "\r\n" + array[11] + "\r\n";
					Data12[0] = Convert.ToDouble(Angle_x13);
					Data12[1] = Convert.ToDouble(Angle_y13);
					Data12[2] = Convert.ToDouble(Angle_z13);
					Data12[0] += offset_x_12;
					Data12[1] += offset_y_12;
					Data12[2] += offset_z_12;
					Data12[0] += scroll_ofset_x_12;
					Data12[1] += scroll_ofset_y_12;
					Data12[2] += scroll_ofset_z_12;
					Mx13 = array[9];
					My13 = array[10];
					Mz13 = array[11];
					AData13[0] = Convert.ToDouble(Ax13);
					AData13[1] = Convert.ToDouble(Ay13);
					AData13[2] = Convert.ToDouble(Az13);
					WData13[0] = Convert.ToDouble(Wx13);
					WData13[1] = Convert.ToDouble(Wy13);
					WData13[2] = Convert.ToDouble(Wz13);
					MData13[0] = Convert.ToDouble(Mx13);
					MData13[1] = Convert.ToDouble(My13);
					MData13[2] = Convert.ToDouble(Mz13);
                    #region send
     //               sendgroup3[50] = (byte)((int)(Data12[0] * 1000.0) >> 24);
					//sendgroup3[51] = (byte)((int)(Data12[0] * 1000.0) >> 16);
					//sendgroup3[52] = (byte)((int)(Data12[0] * 1000.0) >> 8);
					//sendgroup3[53] = (byte)(int)(Data12[0] * 1000.0);
					//sendgroup3[54] = (byte)((int)(Data12[1] * 1000.0) >> 24);
					//sendgroup3[55] = (byte)((int)(Data12[1] * 1000.0) >> 16);
					//sendgroup3[56] = (byte)((int)(Data12[1] * 1000.0) >> 8);
					//sendgroup3[57] = (byte)(int)(Data12[1] * 1000.0);
					//sendgroup3[58] = (byte)((int)(Data12[2] * 1000.0) >> 24);
					//sendgroup3[59] = (byte)((int)(Data12[2] * 1000.0) >> 16);
					//sendgroup3[60] = (byte)((int)(Data12[2] * 1000.0) >> 8);
					//sendgroup3[61] = (byte)(int)(Data12[2] * 1000.0);

					//sendgroup4[434] = (byte)((int)(AData13[0] * 1000.0) >> 24);
					//sendgroup4[435] = (byte)((int)(AData13[0] * 1000.0) >> 16);
					//sendgroup4[436] = (byte)((int)(AData13[0] * 1000.0) >> 8);
					//sendgroup4[437] = (byte)(int)(AData13[0] * 1000.0);
					//sendgroup4[438] = (byte)((int)(AData13[1] * 1000.0) >> 24);
					//sendgroup4[439] = (byte)((int)(AData13[1] * 1000.0) >> 16);
					//sendgroup4[440] = (byte)((int)(AData13[1] * 1000.0) >> 8);
					//sendgroup4[441] = (byte)(int)(AData13[1] * 1000.0);
					//sendgroup4[442] = (byte)((int)(AData13[2] * 1000.0) >> 24);
					//sendgroup4[443] = (byte)((int)(AData13[2] * 1000.0) >> 16);
					//sendgroup4[444] = (byte)((int)(AData13[2] * 1000.0) >> 8);
					//sendgroup4[445] = (byte)(int)(AData13[2] * 1000.0);
					//sendgroup4[446] = (byte)((int)(WData13[0] * 1000.0) >> 24);
					//sendgroup4[447] = (byte)((int)(WData13[0] * 1000.0) >> 16);
					//sendgroup4[448] = (byte)((int)(WData13[0] * 1000.0) >> 8);
					//sendgroup4[449] = (byte)(int)(WData13[0] * 1000.0);
					//sendgroup4[450] = (byte)((int)(WData13[1] * 1000.0) >> 24);
					//sendgroup4[451] = (byte)((int)(WData13[1] * 1000.0) >> 16);
					//sendgroup4[452] = (byte)((int)(WData13[1] * 1000.0) >> 8);
					//sendgroup4[453] = (byte)(int)(WData13[1] * 1000.0);
					//sendgroup4[454] = (byte)((int)(WData13[2] * 1000.0) >> 24);
					//sendgroup4[455] = (byte)((int)(WData13[2] * 1000.0) >> 16);
					//sendgroup4[456] = (byte)((int)(WData13[2] * 1000.0) >> 8);
					//sendgroup4[457] = (byte)(int)(WData13[2] * 1000.0);
					//sendgroup4[458] = (byte)((int)(MData13[0] * 1000.0) >> 24);
					//sendgroup4[459] = (byte)((int)(MData13[0] * 1000.0) >> 16);
					//sendgroup4[460] = (byte)((int)(MData13[0] * 1000.0) >> 8);
					//sendgroup4[461] = (byte)(int)(MData13[0] * 1000.0);
					//sendgroup4[462] = (byte)((int)(MData13[1] * 1000.0) >> 24);
					//sendgroup4[463] = (byte)((int)(MData13[1] * 1000.0) >> 16);
					//sendgroup4[464] = (byte)((int)(MData13[1] * 1000.0) >> 8);
					//sendgroup4[465] = (byte)(int)(MData13[1] * 1000.0);
					//sendgroup4[466] = (byte)((int)(MData13[2] * 1000.0) >> 24);
					//sendgroup4[467] = (byte)((int)(MData13[2] * 1000.0) >> 16);
					//sendgroup4[468] = (byte)((int)(MData13[2] * 1000.0) >> 8);
					//sendgroup4[469] = (byte)(int)(MData13[2] * 1000.0);
#endregion send
                    remote13 = remoteEP;
				}
				catch
				{
					break;
				}
			}
		}
		private void ReceiveData13()
		{
			if (!first_tst_14)
			{
				IPEndPoint localEP = new IPEndPoint(ip, 14);
				receiveUdpClient13 = new UdpClient(localEP);
				first_tst_14 = true;
			}
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 9250);
			while (!exit14)
			{
				try
				{
					arrServerRecMsg13 = receiveUdpClient13.Receive(ref remoteEP);
					string @string = Encoding.Default.GetString(arrServerRecMsg13, 0, arrServerRecMsg13.Length);
					//if (@string[2] == 'O' && @string[3] == 'K')
					//{
					//	textBox67.Text = "DNOK";
					//}
					string[] array = @string.Split(',');
					Ax14 = array[0].Substring(14, array[0].Length - 14);
					Ay14 = array[1];
					Az14 = array[2];
					Wx14 = array[3];
					Wy14 = array[4];
					Wz14 = array[5];
					Angle_x14 = array[6];
					Angle_y14 = array[7];
					Angle_z14 = array[8];
					textBox66.Text = array[9] + "\r\n" + array[10] + "\r\n" + array[11] + "\r\n";
					Data13[0] = Convert.ToDouble(Angle_x14);
					Data13[1] = Convert.ToDouble(Angle_y14);
					Data13[2] = Convert.ToDouble(Angle_z14);
					Data13[0] += offset_x_13;
					Data13[1] += offset_y_13;
					Data13[2] += offset_z_13;
					Data13[0] += scroll_ofset_x_13;
					Data13[1] += scroll_ofset_y_13;
					Data13[2] += scroll_ofset_z_13;
					Mx14 = array[9];
					My14 = array[10];
					Mz14 = array[11];
					AData14[0] = Convert.ToDouble(Ax14);
					AData14[1] = Convert.ToDouble(Ay14);
					AData14[2] = Convert.ToDouble(Az14);
					WData14[0] = Convert.ToDouble(Wx14);
					WData14[1] = Convert.ToDouble(Wy14);
					WData14[2] = Convert.ToDouble(Wz14);
					MData14[0] = Convert.ToDouble(Mx14);
					MData14[1] = Convert.ToDouble(My14);
					MData14[2] = Convert.ToDouble(Mz14);
                    #region send
     //               sendgroup2[50] = (byte)((int)(Data13[0] * 1000.0) >> 24);
					//sendgroup2[51] = (byte)((int)(Data13[0] * 1000.0) >> 16);
					//sendgroup2[52] = (byte)((int)(Data13[0] * 1000.0) >> 8);
					//sendgroup2[53] = (byte)(int)(Data13[0] * 1000.0);
					//sendgroup2[54] = (byte)((int)(Data13[1] * 1000.0) >> 24);
					//sendgroup2[55] = (byte)((int)(Data13[1] * 1000.0) >> 16);
					//sendgroup2[56] = (byte)((int)(Data13[1] * 1000.0) >> 8);
					//sendgroup2[57] = (byte)(int)(Data13[1] * 1000.0);
					//sendgroup2[58] = (byte)((int)(Data13[2] * 1000.0) >> 24);
					//sendgroup2[59] = (byte)((int)(Data13[2] * 1000.0) >> 16);
					//sendgroup2[60] = (byte)((int)(Data13[2] * 1000.0) >> 8);
					//sendgroup2[61] = (byte)(int)(Data13[2] * 1000.0);

					//sendgroup4[470] = (byte)((int)(AData14[0] * 1000.0) >> 24);
					//sendgroup4[471] = (byte)((int)(AData14[0] * 1000.0) >> 16);
					//sendgroup4[472] = (byte)((int)(AData14[0] * 1000.0) >> 8);
					//sendgroup4[473] = (byte)(int)(AData14[0] * 1000.0);
					//sendgroup4[474] = (byte)((int)(AData14[1] * 1000.0) >> 24);
					//sendgroup4[475] = (byte)((int)(AData14[1] * 1000.0) >> 16);
					//sendgroup4[476] = (byte)((int)(AData14[1] * 1000.0) >> 8);
					//sendgroup4[477] = (byte)(int)(AData14[1] * 1000.0);
					//sendgroup4[478] = (byte)((int)(AData14[2] * 1000.0) >> 24);
					//sendgroup4[479] = (byte)((int)(AData14[2] * 1000.0) >> 16);
					//sendgroup4[480] = (byte)((int)(AData14[2] * 1000.0) >> 8);
					//sendgroup4[481] = (byte)(int)(AData14[2] * 1000.0);
					//sendgroup4[482] = (byte)((int)(WData14[0] * 1000.0) >> 24);
					//sendgroup4[483] = (byte)((int)(WData14[0] * 1000.0) >> 16);
					//sendgroup4[484] = (byte)((int)(WData14[0] * 1000.0) >> 8);
					//sendgroup4[485] = (byte)(int)(WData14[0] * 1000.0);
					//sendgroup4[486] = (byte)((int)(WData14[1] * 1000.0) >> 24);
					//sendgroup4[487] = (byte)((int)(WData14[1] * 1000.0) >> 16);
					//sendgroup4[488] = (byte)((int)(WData14[1] * 1000.0) >> 8);
					//sendgroup4[489] = (byte)(int)(WData14[1] * 1000.0);
					//sendgroup4[490] = (byte)((int)(WData14[2] * 1000.0) >> 24);
					//sendgroup4[491] = (byte)((int)(WData14[2] * 1000.0) >> 16);
					//sendgroup4[492] = (byte)((int)(WData14[2] * 1000.0) >> 8);
					//sendgroup4[493] = (byte)(int)(WData14[2] * 1000.0);
					//sendgroup4[494] = (byte)((int)(MData14[0] * 1000.0) >> 24);
					//sendgroup4[495] = (byte)((int)(MData14[0] * 1000.0) >> 16);
					//sendgroup4[496] = (byte)((int)(MData14[0] * 1000.0) >> 8);
					//sendgroup4[497] = (byte)(int)(MData14[0] * 1000.0);
					//sendgroup4[498] = (byte)((int)(MData14[1] * 1000.0) >> 24);
					//sendgroup4[499] = (byte)((int)(MData14[1] * 1000.0) >> 16);
					//sendgroup4[500] = (byte)((int)(MData14[1] * 1000.0) >> 8);
					//sendgroup4[501] = (byte)(int)(MData14[1] * 1000.0);
					//sendgroup4[502] = (byte)((int)(MData14[2] * 1000.0) >> 24);
					//sendgroup4[503] = (byte)((int)(MData14[2] * 1000.0) >> 16);
					//sendgroup4[504] = (byte)((int)(MData14[2] * 1000.0) >> 8);
					//sendgroup4[505] = (byte)(int)(MData14[2] * 1000.0);
#endregion send
                    remote14 = remoteEP;
				}
				catch
				{
					break;
				}
			}
		}
		private void ReceiveData14()
		{
			if (!first_tst_15)
			{
				IPEndPoint localEP = new IPEndPoint(ip, 15);
				receiveUdpClient14 = new UdpClient(localEP);
				first_tst_15 = true;
			}
			IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 9250);
			while (!exit15)
			{
				try
				{
					arrServerRecMsg14 = receiveUdpClient14.Receive(ref remoteEP);
					string @string = Encoding.Default.GetString(arrServerRecMsg14, 0, arrServerRecMsg14.Length);
					//if (@string[2] == 'O' && @string[3] == 'K')
					//{
					//	textBox72.Text = "DNOK";
					//}
					string[] array = @string.Split(',');
					Ax15 = array[0].Substring(14, array[0].Length - 14);
					Ay15 = array[1];
					Az15 = array[2];
					Wx15 = array[3];
					Wy15 = array[4];
					Wz15 = array[5];
					Angle_x15 = array[6];
					Angle_y15 = array[7];
					Angle_z15 = array[8];
					textBox71.Text = array[9] + "\r\n" + array[10] + "\r\n" + array[11] + "\r\n";
					Data14[0] = Convert.ToDouble(Angle_x15);
					Data14[1] = Convert.ToDouble(Angle_y15);
					Data14[2] = Convert.ToDouble(Angle_z15);
					Data14[0] += offset_x_14;
					Data14[1] += offset_y_14;
					Data14[2] += offset_z_14;
					Data14[0] += scroll_ofset_x_14;
					Data14[1] += scroll_ofset_y_14;
					Data14[2] += scroll_ofset_z_14;
					Mx15 = array[9];
					My15 = array[10];
					Mz15 = array[11];
					AData15[0] = Convert.ToDouble(Ax15);
					AData15[1] = Convert.ToDouble(Ay15);
					AData15[2] = Convert.ToDouble(Az15);
					WData15[0] = Convert.ToDouble(Wx15);
					WData15[1] = Convert.ToDouble(Wy15);
					WData15[2] = Convert.ToDouble(Wz15);
					MData15[0] = Convert.ToDouble(Mx15);
					MData15[1] = Convert.ToDouble(My15);
					MData15[2] = Convert.ToDouble(Mz15);
                    #region send
     //               sendgroup2[62] = (byte)((int)(Data14[0] * 1000.0) >> 24);
					//sendgroup2[63] = (byte)((int)(Data14[0] * 1000.0) >> 16);
					//sendgroup2[64] = (byte)((int)(Data14[0] * 1000.0) >> 8);
					//sendgroup2[65] = (byte)(int)(Data14[0] * 1000.0);
					//sendgroup2[66] = (byte)((int)(Data14[1] * 1000.0) >> 24);
					//sendgroup2[67] = (byte)((int)(Data14[1] * 1000.0) >> 16);
					//sendgroup2[68] = (byte)((int)(Data14[1] * 1000.0) >> 8);
					//sendgroup2[69] = (byte)(int)(Data14[1] * 1000.0);
					//sendgroup2[70] = (byte)((int)(Data14[2] * 1000.0) >> 24);
					//sendgroup2[71] = (byte)((int)(Data14[2] * 1000.0) >> 16);
					//sendgroup2[72] = (byte)((int)(Data14[2] * 1000.0) >> 8);
					//sendgroup2[73] = (byte)(int)(Data14[2] * 1000.0);

					//sendgroup4[506] = (byte)((int)(AData15[0] * 1000.0) >> 24);
					//sendgroup4[507] = (byte)((int)(AData15[0] * 1000.0) >> 16);
					//sendgroup4[508] = (byte)((int)(AData15[0] * 1000.0) >> 8);
					//sendgroup4[509] = (byte)(int)(AData15[0] * 1000.0);
					//sendgroup4[510] = (byte)((int)(AData15[1] * 1000.0) >> 24);
					//sendgroup4[511] = (byte)((int)(AData15[1] * 1000.0) >> 16);
					//sendgroup4[512] = (byte)((int)(AData15[1] * 1000.0) >> 8);
					//sendgroup4[513] = (byte)(int)(AData15[1] * 1000.0);
					//sendgroup4[514] = (byte)((int)(AData15[2] * 1000.0) >> 24);
					//sendgroup4[515] = (byte)((int)(AData15[2] * 1000.0) >> 16);
					//sendgroup4[516] = (byte)((int)(AData15[2] * 1000.0) >> 8);
					//sendgroup4[517] = (byte)(int)(AData15[2] * 1000.0);
					//sendgroup4[518] = (byte)((int)(WData15[0] * 1000.0) >> 24);
					//sendgroup4[519] = (byte)((int)(WData15[0] * 1000.0) >> 16);
					//sendgroup4[520] = (byte)((int)(WData15[0] * 1000.0) >> 8);
					//sendgroup4[521] = (byte)(int)(WData15[0] * 1000.0);
					//sendgroup4[522] = (byte)((int)(WData15[1] * 1000.0) >> 24);
					//sendgroup4[523] = (byte)((int)(WData15[1] * 1000.0) >> 16);
					//sendgroup4[524] = (byte)((int)(WData15[1] * 1000.0) >> 8);
					//sendgroup4[525] = (byte)(int)(WData15[1] * 1000.0);
					//sendgroup4[526] = (byte)((int)(WData15[2] * 1000.0) >> 24);
					//sendgroup4[527] = (byte)((int)(WData15[2] * 1000.0) >> 16);
					//sendgroup4[528] = (byte)((int)(WData15[2] * 1000.0) >> 8);
					//sendgroup4[529] = (byte)(int)(WData15[2] * 1000.0);
					//sendgroup4[530] = (byte)((int)(MData15[0] * 1000.0) >> 24);
					//sendgroup4[531] = (byte)((int)(MData15[0] * 1000.0) >> 16);
					//sendgroup4[532] = (byte)((int)(MData15[0] * 1000.0) >> 8);
					//sendgroup4[533] = (byte)(int)(MData15[0] * 1000.0);
					//sendgroup4[534] = (byte)((int)(MData15[1] * 1000.0) >> 24);
					//sendgroup4[535] = (byte)((int)(MData15[1] * 1000.0) >> 16);
					//sendgroup4[536] = (byte)((int)(MData15[1] * 1000.0) >> 8);
					//sendgroup4[537] = (byte)(int)(MData15[1] * 1000.0);
					//sendgroup4[538] = (byte)((int)(MData15[2] * 1000.0) >> 24);
					//sendgroup4[539] = (byte)((int)(MData15[2] * 1000.0) >> 16);
					//sendgroup4[540] = (byte)((int)(MData15[2] * 1000.0) >> 8);
					//sendgroup4[541] = (byte)(int)(MData15[2] * 1000.0);
#endregion send
                    remote15 = remoteEP;
				}
				catch
				{
					break;
				}
			}
		}
		private void data_save_excell()
		{
			if (Excel_start)
			{
				xSheel.Cells[excel_cnt + 2, 1] = DateTime.Now.ToString("hh:mm:ss");
				xSheel.Cells[excel_cnt + 3, 1] = "X";
				xSheel.Cells[excel_cnt + 4, 1] = "Y";
				xSheel.Cells[excel_cnt + 5, 1] = "Z";
				xSheel.Cells[excel_cnt + 3, 2] = Data[0] + "°";
				xSheel.Cells[excel_cnt + 4, 2] = Data[1] + "°";
				xSheel.Cells[excel_cnt + 5, 2] = Data[2] + "°";
				xSheel.Cells[excel_cnt + 3, 3] = Data1[0] + "°";
				xSheel.Cells[excel_cnt + 4, 3] = Data1[1] + "°";
				xSheel.Cells[excel_cnt + 5, 3] = Data1[2] + "°";
				xSheel.Cells[excel_cnt + 3, 4] = Data2[0] + "°";
				xSheel.Cells[excel_cnt + 4, 4] = Data2[1] + "°";
				xSheel.Cells[excel_cnt + 5, 4] = Data2[2] + "°";
				xSheel.Cells[excel_cnt + 3, 5] = Data3[0] + "°";
				xSheel.Cells[excel_cnt + 4, 5] = Data3[1] + "°";
				xSheel.Cells[excel_cnt + 5, 5] = Data3[2] + "°";
				xSheel.Cells[excel_cnt + 3, 6] = Data4[0] + "°";
				xSheel.Cells[excel_cnt + 4, 6] = Data4[1] + "°";
				xSheel.Cells[excel_cnt + 5, 6] = Data4[2] + "°";
				xSheel.Cells[excel_cnt + 3, 7] = Data5[0] + "°";
				xSheel.Cells[excel_cnt + 4, 7] = Data5[1] + "°";
				xSheel.Cells[excel_cnt + 5, 7] = Data5[2] + "°";
				xSheel.Cells[excel_cnt + 3, 8] = Data6[0] + "°";
				xSheel.Cells[excel_cnt + 4, 8] = Data6[1] + "°";
				xSheel.Cells[excel_cnt + 5, 8] = Data6[2] + "°";
				xSheel.Cells[excel_cnt + 3, 9] = Data7[0] + "°";
				xSheel.Cells[excel_cnt + 4, 9] = Data7[1] + "°";
				xSheel.Cells[excel_cnt + 5, 9] = Data7[2] + "°";
				xSheel.Cells[excel_cnt + 3, 10] = Data8[0] + "°";
				xSheel.Cells[excel_cnt + 4, 10] = Data8[1] + "°";
				xSheel.Cells[excel_cnt + 5, 10] = Data8[2] + "°";
				xSheel.Cells[excel_cnt + 3, 11] = Data9[0] + "°";
				xSheel.Cells[excel_cnt + 4, 11] = Data9[1] + "°";
				xSheel.Cells[excel_cnt + 5, 11] = Data9[2] + "°";
				xSheel.Cells[excel_cnt + 3, 12] = Data10[0] + "°";
				xSheel.Cells[excel_cnt + 4, 12] = Data10[1] + "°";
				xSheel.Cells[excel_cnt + 5, 12] = Data10[2] + "°";
				xSheel.Cells[excel_cnt + 3, 13] = Data11[0] + "°";
				xSheel.Cells[excel_cnt + 4, 13] = Data11[1] + "°";
				xSheel.Cells[excel_cnt + 5, 13] = Data11[2] + "°";
				xSheel.Cells[excel_cnt + 3, 14] = Data12[0] + "°";
				xSheel.Cells[excel_cnt + 4, 14] = Data12[1] + "°";
				xSheel.Cells[excel_cnt + 5, 14] = Data12[2] + "°";
				xSheel.Cells[excel_cnt + 3, 15] = Data13[0] + "°";
				xSheel.Cells[excel_cnt + 4, 15] = Data13[1] + "°";
				xSheel.Cells[excel_cnt + 5, 15] = Data13[2] + "°";
				xSheel.Cells[excel_cnt + 3, 16] = Data14[0] + "°";
				xSheel.Cells[excel_cnt + 4, 16] = Data14[1] + "°";
				xSheel.Cells[excel_cnt + 5, 16] = Data14[2] + "°";
				xSheel.Cells[excel_cnt + 6, 1] = "Ax";
				xSheel.Cells[excel_cnt + 7, 1] = "Ay";
				xSheel.Cells[excel_cnt + 8, 1] = "Az";
				xSheel.Cells[excel_cnt + 6, 2] = Ax1 + "g";
				xSheel.Cells[excel_cnt + 7, 2] = Ay1 + "g";
				xSheel.Cells[excel_cnt + 8, 2] = Az1 + "g";
				xSheel.Cells[excel_cnt + 6, 3] = Ax2 + "g";
				xSheel.Cells[excel_cnt + 7, 3] = Ay2 + "g";
				xSheel.Cells[excel_cnt + 8, 3] = Az2 + "g";
				xSheel.Cells[excel_cnt + 6, 4] = Ax3 + "g";
				xSheel.Cells[excel_cnt + 7, 4] = Ay3 + "g";
				xSheel.Cells[excel_cnt + 8, 4] = Az3 + "g";
				xSheel.Cells[excel_cnt + 6, 5] = Ax4 + "g";
				xSheel.Cells[excel_cnt + 7, 5] = Ay4 + "g";
				xSheel.Cells[excel_cnt + 8, 5] = Az4 + "g";
				xSheel.Cells[excel_cnt + 6, 6] = Ax5 + "g";
				xSheel.Cells[excel_cnt + 7, 6] = Ay5 + "g";
				xSheel.Cells[excel_cnt + 8, 6] = Az5 + "g";
				xSheel.Cells[excel_cnt + 6, 7] = Ax6 + "g";
				xSheel.Cells[excel_cnt + 7, 7] = Ay6 + "g";
				xSheel.Cells[excel_cnt + 8, 7] = Az6 + "g";
				xSheel.Cells[excel_cnt + 6, 8] = Ax7 + "g";
				xSheel.Cells[excel_cnt + 7, 8] = Ay7 + "g";
				xSheel.Cells[excel_cnt + 8, 8] = Az7 + "g";
				xSheel.Cells[excel_cnt + 6, 9] = Ax8 + "g";
				xSheel.Cells[excel_cnt + 7, 9] = Ay8 + "g";
				xSheel.Cells[excel_cnt + 8, 9] = Az8 + "g";
				xSheel.Cells[excel_cnt + 6, 10] = Ax9 + "g";
				xSheel.Cells[excel_cnt + 7, 10] = Ay9 + "g";
				xSheel.Cells[excel_cnt + 8, 10] = Az9 + "g";
				xSheel.Cells[excel_cnt + 6, 11] = Ax10 + "g";
				xSheel.Cells[excel_cnt + 7, 11] = Ay10 + "g";
				xSheel.Cells[excel_cnt + 8, 11] = Az10 + "g";
				xSheel.Cells[excel_cnt + 6, 12] = Ax11 + "g";
				xSheel.Cells[excel_cnt + 7, 12] = Ay11 + "g";
				xSheel.Cells[excel_cnt + 8, 12] = Az11 + "g";
				xSheel.Cells[excel_cnt + 6, 13] = Ax12 + "g";
				xSheel.Cells[excel_cnt + 7, 13] = Ay12 + "g";
				xSheel.Cells[excel_cnt + 8, 13] = Az12 + "g";
				xSheel.Cells[excel_cnt + 6, 14] = Ax13 + "g";
				xSheel.Cells[excel_cnt + 7, 14] = Ay13 + "g";
				xSheel.Cells[excel_cnt + 8, 14] = Az13 + "g";
				xSheel.Cells[excel_cnt + 6, 15] = Ax14 + "g";
				xSheel.Cells[excel_cnt + 7, 15] = Ay14 + "g";
				xSheel.Cells[excel_cnt + 8, 15] = Az14 + "g";
				xSheel.Cells[excel_cnt + 6, 16] = Ax15 + "g";
				xSheel.Cells[excel_cnt + 7, 16] = Ay15 + "g";
				xSheel.Cells[excel_cnt + 8, 16] = Az15 + "g";
				xSheel.Cells[excel_cnt + 9, 1] = "Wx";
				xSheel.Cells[excel_cnt + 10, 1] = "Wy";
				xSheel.Cells[excel_cnt + 11, 1] = "Wz";
				xSheel.Cells[excel_cnt + 9, 2] = Wx1 + "°/s";
				xSheel.Cells[excel_cnt + 10, 2] = Wy1 + "°/s";
				xSheel.Cells[excel_cnt + 11, 2] = Wz1 + "°/s";
				xSheel.Cells[excel_cnt + 9, 3] = Wx2 + "°/s";
				xSheel.Cells[excel_cnt + 10, 3] = Wy2 + "°/s";
				xSheel.Cells[excel_cnt + 11, 3] = Wz2 + "°/s";
				xSheel.Cells[excel_cnt + 9, 4] = Wx3 + "°/s";
				xSheel.Cells[excel_cnt + 10, 4] = Wy3 + "°/s";
				xSheel.Cells[excel_cnt + 11, 4] = Wz3 + "°/s";
				xSheel.Cells[excel_cnt + 9, 5] = Wx4 + "°/s";
				xSheel.Cells[excel_cnt + 10, 5] = Wy4 + "°/s";
				xSheel.Cells[excel_cnt + 11, 5] = Wz4 + "°/s";
				xSheel.Cells[excel_cnt + 9, 6] = Wx5 + "°/s";
				xSheel.Cells[excel_cnt + 10, 6] = Wy5 + "°/s";
				xSheel.Cells[excel_cnt + 11, 6] = Wz5 + "°/s";
				xSheel.Cells[excel_cnt + 9, 7] = Wx6 + "°/s";
				xSheel.Cells[excel_cnt + 10, 7] = Wy6 + "°/s";
				xSheel.Cells[excel_cnt + 11, 7] = Wz6 + "°/s";
				xSheel.Cells[excel_cnt + 9, 8] = Wx7 + "°/s";
				xSheel.Cells[excel_cnt + 10, 8] = Wy7 + "°/s";
				xSheel.Cells[excel_cnt + 11, 8] = Wz7 + "°/s";
				xSheel.Cells[excel_cnt + 9, 9] = Wx8 + "°/s";
				xSheel.Cells[excel_cnt + 10, 9] = Wy8 + "°/s";
				xSheel.Cells[excel_cnt + 11, 9] = Wz8 + "°/s";
				xSheel.Cells[excel_cnt + 9, 10] = Wx9 + "°/s";
				xSheel.Cells[excel_cnt + 10, 10] = Wy9 + "°/s";
				xSheel.Cells[excel_cnt + 11, 10] = Wz9 + "°/s";
				xSheel.Cells[excel_cnt + 9, 11] = Wx10 + "°/s";
				xSheel.Cells[excel_cnt + 10, 11] = Wy10 + "°/s";
				xSheel.Cells[excel_cnt + 11, 11] = Wz10 + "°/s";
				xSheel.Cells[excel_cnt + 9, 12] = Wx11 + "°/s";
				xSheel.Cells[excel_cnt + 10, 12] = Wy11 + "°/s";
				xSheel.Cells[excel_cnt + 11, 12] = Wz11 + "°/s";
				xSheel.Cells[excel_cnt + 9, 13] = Wx12 + "°/s";
				xSheel.Cells[excel_cnt + 10, 13] = Wy12 + "°/s";
				xSheel.Cells[excel_cnt + 11, 13] = Wz12 + "°/s";
				xSheel.Cells[excel_cnt + 9, 14] = Wx13 + "°/s";
				xSheel.Cells[excel_cnt + 10, 14] = Wy13 + "°/s";
				xSheel.Cells[excel_cnt + 11, 14] = Wz13 + "°/s";
				xSheel.Cells[excel_cnt + 9, 15] = Wx14 + "°/s";
				xSheel.Cells[excel_cnt + 10, 15] = Wy14 + "°/s";
				xSheel.Cells[excel_cnt + 11, 15] = Wz14 + "°/s";
				xSheel.Cells[excel_cnt + 9, 16] = Wx15 + "°/s";
				xSheel.Cells[excel_cnt + 10, 16] = Wy15 + "°/s";
				xSheel.Cells[excel_cnt + 11, 16] = Wz15 + "°/s";
				xSheel.Cells[excel_cnt + 12, 1] = "Mx";
				xSheel.Cells[excel_cnt + 13, 1] = "My";
				xSheel.Cells[excel_cnt + 14, 1] = "Mz";
				xSheel.Cells[excel_cnt + 12, 2] = Mx1 + "ut";
				xSheel.Cells[excel_cnt + 13, 2] = My1 + "ut";
				xSheel.Cells[excel_cnt + 14, 2] = Mz1 + "ut";
				xSheel.Cells[excel_cnt + 12, 3] = Mx2 + "ut";
				xSheel.Cells[excel_cnt + 13, 3] = My2 + "ut";
				xSheel.Cells[excel_cnt + 14, 3] = Mz2 + "ut";
				xSheel.Cells[excel_cnt + 12, 4] = Mx3 + "ut";
				xSheel.Cells[excel_cnt + 13, 4] = My3 + "ut";
				xSheel.Cells[excel_cnt + 14, 4] = Mz3 + "ut";
				xSheel.Cells[excel_cnt + 12, 5] = Mx4 + "ut";
				xSheel.Cells[excel_cnt + 13, 5] = My4 + "ut";
				xSheel.Cells[excel_cnt + 14, 5] = Mz4 + "ut";
				xSheel.Cells[excel_cnt + 12, 6] = Mx5 + "ut";
				xSheel.Cells[excel_cnt + 13, 6] = My5 + "ut";
				xSheel.Cells[excel_cnt + 14, 6] = Mz5 + "ut";
				xSheel.Cells[excel_cnt + 12, 7] = Mx6 + "ut";
				xSheel.Cells[excel_cnt + 13, 7] = My6 + "ut";
				xSheel.Cells[excel_cnt + 14, 7] = Mz6 + "ut";
				xSheel.Cells[excel_cnt + 12, 8] = Mx7 + "ut";
				xSheel.Cells[excel_cnt + 13, 8] = My7 + "ut";
				xSheel.Cells[excel_cnt + 14, 8] = Mz7 + "ut";
				xSheel.Cells[excel_cnt + 12, 9] = Mx8 + "ut";
				xSheel.Cells[excel_cnt + 13, 9] = My8 + "ut";
				xSheel.Cells[excel_cnt + 14, 9] = Mz8 + "ut";
				xSheel.Cells[excel_cnt + 12, 10] = Mx9 + "ut";
				xSheel.Cells[excel_cnt + 13, 10] = My9 + "ut";
				xSheel.Cells[excel_cnt + 14, 10] = Mz9 + "ut";
				xSheel.Cells[excel_cnt + 12, 11] = Mx10 + "ut";
				xSheel.Cells[excel_cnt + 13, 11] = My10 + "ut";
				xSheel.Cells[excel_cnt + 14, 11] = Mz10 + "ut";
				xSheel.Cells[excel_cnt + 12, 12] = Mx11 + "ut";
				xSheel.Cells[excel_cnt + 13, 12] = My11 + "ut";
				xSheel.Cells[excel_cnt + 14, 12] = Mz11 + "ut";
				xSheel.Cells[excel_cnt + 12, 13] = Mx12 + "ut";
				xSheel.Cells[excel_cnt + 13, 13] = My12 + "ut";
				xSheel.Cells[excel_cnt + 14, 13] = Mz12 + "ut";
				xSheel.Cells[excel_cnt + 12, 14] = Mx13 + "ut";
				xSheel.Cells[excel_cnt + 13, 14] = My13 + "ut";
				xSheel.Cells[excel_cnt + 14, 14] = Mz13 + "ut";
				xSheel.Cells[excel_cnt + 12, 15] = Mx14 + "ut";
				xSheel.Cells[excel_cnt + 13, 15] = My14 + "ut";
				xSheel.Cells[excel_cnt + 14, 15] = Mz14 + "ut";
				xSheel.Cells[excel_cnt + 12, 16] = Mx15 + "ut";
				xSheel.Cells[excel_cnt + 13, 16] = My15 + "ut";
				xSheel.Cells[excel_cnt + 14, 16] = Mz15 + "ut";
				xSheel.Cells[excel_cnt + 3, 17] = gloveData[0] + "°";
				xSheel.Cells[excel_cnt + 4, 17] = gloveData[1] + "°";
				xSheel.Cells[excel_cnt + 5, 17] = gloveData[2] + "°";
				xSheel.Cells[excel_cnt + 3, 18] = LgloveData[0] + "°";
				xSheel.Cells[excel_cnt + 4, 18] = LgloveData[1] + "°";
				xSheel.Cells[excel_cnt + 5, 18] = LgloveData[2] + "°";
				excel_cnt += 13;
			}
		}
        private void button6_Click(object sender, EventArgs e)
        {
			Thread thread = new Thread(ReceiveData);
			Thread thread2 = new Thread(ReceiveData1);
			Thread thread3 = new Thread(ReceiveData2);
			Thread thread4 = new Thread(ReceiveData3);
			Thread thread5 = new Thread(ReceiveData4);
			Thread thread6 = new Thread(ReceiveData5);
			Thread thread7 = new Thread(ReceiveData6);
			Thread thread8 = new Thread(ReceiveData7);
			Thread thread9 = new Thread(ReceiveData8);
			Thread thread10 = new Thread(ReceiveData9);
			Thread thread11 = new Thread(ReceiveData10);
			Thread thread12 = new Thread(ReceiveData11);
			Thread thread13 = new Thread(ReceiveData12);
			Thread thread14 = new Thread(ReceiveData13);
			Thread thread15 = new Thread(ReceiveData14);
			thread.IsBackground = true;
			thread.Start();
			thread2.IsBackground = true;
			thread2.Start();
			thread3.IsBackground = true;
			thread3.Start();
			thread4.IsBackground = true;
			thread4.Start();
			thread5.IsBackground = true;
			thread5.Start();
			thread6.IsBackground = true;
			thread6.Start();
			thread7.IsBackground = true;
			thread7.Start();
			thread8.IsBackground = true;
			thread8.Start();
			thread9.IsBackground = true;
			thread9.Start();
			thread10.IsBackground = true;
			thread10.Start();
			thread11.IsBackground = true;
			thread11.Start();
			thread12.IsBackground = true;
			thread12.Start();
			thread13.IsBackground = true;
			thread13.Start();
			thread14.IsBackground = true;
			thread14.Start();
			thread15.IsBackground = true;
			thread15.Start();
			Control.CheckForIllegalCrossThreadCalls = false;
            #region send
            //sendUdpClient = new UdpClient(1);
            //sendUdpClient1 = new UdpClient(2);
            //sendUdpClient2 = new UdpClient(3);
            //sendUdpClient3 = new UdpClient(4);
            //sendUdpClient4 = new UdpClient(5);
            //sendUdpClient5 = new UdpClient(6);
            //sendUdpClient6 = new UdpClient(7);
            //sendUdpClient7 = new UdpClient(8);
            //sendUdpClient8 = new UdpClient(9);
            //sendUdpClient9 = new UdpClient(10);
            //sendUdpClient10 = new UdpClient(11);
            //sendUdpClient11 = new UdpClient(12);
            //sendUdpClient12 = new UdpClient(13);
            //sendUdpClient13 = new UdpClient(14);
            //sendUdpClient14 = new UdpClient(15);
            #endregion send
            timer1.Enabled = true;
		}
        //50HZ
		private void button9_Click(object sender, EventArgs e)
        {
			int num = 0;
			byte[] array = new byte[21];
			IPEndPoint iPEndPoint = remote1;
			IPEndPoint iPEndPoint2 = remote2;
			IPEndPoint iPEndPoint3 = remote3;
			IPEndPoint iPEndPoint4 = remote4;
			IPEndPoint iPEndPoint5 = remote5;
			IPEndPoint iPEndPoint6 = remote6;
			IPEndPoint iPEndPoint7 = remote7;
			IPEndPoint iPEndPoint8 = remote8;
			IPEndPoint iPEndPoint9 = remote9;
			IPEndPoint iPEndPoint10 = remote10;
			IPEndPoint iPEndPoint11 = remote11;
			IPEndPoint iPEndPoint12 = remote12;
			IPEndPoint iPEndPoint13 = remote13;
			IPEndPoint iPEndPoint14 = remote14;
			IPEndPoint iPEndPoint15 = remote15;
			UdpClient udpClient = null;
			IPEndPoint iPEndPoint16 = null;
			for (num = 0; num < 15; num++)
			{
				switch (num)
				{
					case 0:
						iPEndPoint16 = iPEndPoint;
						udpClient = sendUdpClient;
						break;
					case 1:
						iPEndPoint16 = iPEndPoint2;
						udpClient = sendUdpClient1;
						break;
					case 2:
						iPEndPoint16 = iPEndPoint3;
						udpClient = sendUdpClient2;
						break;
					case 3:
						iPEndPoint16 = iPEndPoint4;
						udpClient = sendUdpClient3;
						break;
					case 4:
						iPEndPoint16 = iPEndPoint5;
						udpClient = sendUdpClient4;
						break;
					case 5:
						iPEndPoint16 = iPEndPoint6;
						udpClient = sendUdpClient5;
						break;
					case 6:
						iPEndPoint16 = iPEndPoint7;
						udpClient = sendUdpClient6;
						break;
					case 7:
						iPEndPoint16 = iPEndPoint8;
						udpClient = sendUdpClient7;
						break;
					case 8:
						iPEndPoint16 = iPEndPoint9;
						udpClient = sendUdpClient8;
						break;
					case 9:
						iPEndPoint16 = iPEndPoint10;
						udpClient = sendUdpClient9;
						break;
					case 10:
						iPEndPoint16 = iPEndPoint11;
						udpClient = sendUdpClient10;
						break;
					case 11:
						iPEndPoint16 = iPEndPoint12;
						udpClient = sendUdpClient11;
						break;
					case 12:
						iPEndPoint16 = iPEndPoint13;
						udpClient = sendUdpClient12;
						break;
					case 13:
						iPEndPoint16 = iPEndPoint14;
						udpClient = sendUdpClient13;
						break;
					case 14:
						iPEndPoint16 = iPEndPoint15;
						udpClient = sendUdpClient14;
						break;
				}
				if (iPEndPoint16 != null && udpClient != null)
				{
					sendUdpClient_public = udpClient;
					iep_public = iPEndPoint16;
				}
				array[0] = 87;
				array[1] = 84;
				array[2] = 52;
				array[3] = 55;
				array[4] = 48;
				array[5] = 48;
				array[6] = 48;
				array[7] = 48;
				array[8] = 48;
				array[9] = 51;
				array[10] = 57;
				array[11] = 54;
				array[12] = 48;
				array[13] = 50;
				array[14] = byte.MaxValue;
				array[15] = 170;
				array[16] = 104;
				array[17] = 20;
				array[18] = 0;
				array[19] = 13;
				array[20] = 10;
                if (iep_public != null)
                {
                    //sendUdpClient_public.Send(array, array.Length, iep_public);
                    textBox99.Text = "";
                    textBox99.AppendText("50HZ");
                }
                else
                {
                    textBox99.Text = "";
                    textBox99.AppendText("未连接");
                }
                array[0] = 87;
				array[1] = 84;
				array[2] = 52;
				array[3] = 55;
				array[4] = 48;
				array[5] = 48;
				array[6] = 48;
				array[7] = 48;
				array[8] = 48;
				array[9] = 51;
				array[10] = 57;
				array[11] = 54;
				array[12] = 48;
				array[13] = 50;
				array[14] = byte.MaxValue;
				array[15] = 170;
				array[16] = 0;
				array[17] = 0;
				array[18] = 0;
				array[19] = 13;
				array[20] = 10;
                if (iep_public != null)
                {
                    sendUdpClient_public.Send(array, array.Length, iep_public);
                    textBox99.Text = "";
                    textBox99.AppendText("参数保存");
                }
                else
                {
                    textBox99.Text = "";
                    textBox99.AppendText("未连接");
                }
            }
			num = 0;
			exit1 = true;
			exit2 = true;
			exit3 = true;
			exit4 = true;
			exit5 = true;
			exit6 = true;
			exit7 = true;
			exit8 = true;
			exit9 = true;
			exit10 = true;
			exit11 = true;
			exit12 = true;
			exit13 = true;
			exit14 = true;
			exit15 = true;
			Thread.Sleep(200);
			exit1 = false;
			exit2 = false;
			exit3 = false;
			exit4 = false;
			exit5 = false;
			exit6 = false;
			exit7 = false;
			exit8 = false;
			exit9 = false;
			exit10 = false;
			exit11 = false;
			exit12 = false;
			exit13 = false;
			exit14 = false;
			exit15 = false;
			Thread thread = new Thread(ReceiveData);
			thread.IsBackground = true;
			thread.Start();
			Thread thread2 = new Thread(ReceiveData1);
			thread2.IsBackground = true;
			thread2.Start();
			Thread thread3 = new Thread(ReceiveData2);
			thread3.IsBackground = true;
			thread3.Start();
			Thread thread4 = new Thread(ReceiveData3);
			thread4.IsBackground = true;
			thread4.Start();
			Thread thread5 = new Thread(ReceiveData4);
			thread5.IsBackground = true;
			thread5.Start();
			Thread thread6 = new Thread(ReceiveData5);
			thread6.IsBackground = true;
			thread6.Start();
			Thread thread7 = new Thread(ReceiveData6);
			thread7.IsBackground = true;
			thread7.Start();
			Thread thread8 = new Thread(ReceiveData7);
			thread8.IsBackground = true;
			thread8.Start();
			Thread thread9 = new Thread(ReceiveData8);
			thread9.IsBackground = true;
			thread9.Start();
			Thread thread10 = new Thread(ReceiveData9);
			thread10.IsBackground = true;
			thread10.Start();
			Thread thread11 = new Thread(ReceiveData10);
			thread11.IsBackground = true;
			thread11.Start();
			Thread thread12 = new Thread(ReceiveData11);
			thread12.IsBackground = true;
			thread12.Start();
			Thread thread13 = new Thread(ReceiveData12);
			thread13.IsBackground = true;
			thread13.Start();
			Thread thread14 = new Thread(ReceiveData13);
			thread14.IsBackground = true;
			thread14.Start();
			Thread thread15 = new Thread(ReceiveData14);
			thread15.IsBackground = true;
			thread15.Start();
		}
		//和下方的timer1_Tick_1功能相同
		private void timer1_Tick(object sender, EventArgs e)
		{
			record_JS++;
			textBox9.Text = Data[0].ToString();
			textBox2.Text = Data[1].ToString();
			textBox3.Text = Data[2].ToString();
			textBox4.Text = Data1[0].ToString();
			textBox5.Text = Data1[1].ToString();
			textBox6.Text = Data1[2].ToString();
			textBox12.Text = Data2[0].ToString();
			textBox11.Text = Data2[1].ToString();
			textBox8.Text = Data2[2].ToString();
			textBox19.Text = Data3[0].ToString();
			textBox20.Text = Data3[1].ToString();
			textBox21.Text = Data3[2].ToString();
			textBox22.Text = Data4[0].ToString();
			textBox23.Text = Data4[1].ToString();
			textBox24.Text = Data4[2].ToString();
			textBox25.Text = Data5[0].ToString();
			textBox26.Text = Data5[1].ToString();
			textBox27.Text = Data5[2].ToString();
			textBox28.Text = Data6[0].ToString();
			textBox29.Text = Data6[1].ToString();
			textBox30.Text = Data6[2].ToString();
			textBox31.Text = Data7[0].ToString();
			textBox32.Text = Data7[1].ToString();
			textBox33.Text = Data7[2].ToString();
			textBox34.Text = Data8[0].ToString();
			textBox35.Text = Data8[1].ToString();
			textBox36.Text = Data8[2].ToString();
			textBox37.Text = Data9[0].ToString();
			textBox38.Text = Data9[1].ToString();
			textBox39.Text = Data9[2].ToString();
			textBox50.Text = Data10[0].ToString();
			textBox51.Text = Data10[1].ToString();
			textBox52.Text = Data10[2].ToString();
			textBox42.Text = Data11[0].ToString();
			textBox43.Text = Data11[1].ToString();
			textBox44.Text = Data11[2].ToString();
			textBox46.Text = Data12[0].ToString();
			textBox47.Text = Data12[1].ToString();
			textBox48.Text = Data12[2].ToString();
			textBox70.Text = Data13[0].ToString();
			textBox69.Text = Data13[1].ToString();
			textBox68.Text = Data13[2].ToString();
			textBox75.Text = Data14[0].ToString();
			textBox74.Text = Data14[1].ToString();
			textBox73.Text = Data14[2].ToString();
            
        }
		//开始
        private void button5_Click(object sender, EventArgs e)
        {
			remoteIp = IPAddress.Parse(txt_IPAddress.Text.Trim());
			ip = IPAddress.Parse(txt_IPAddress.Text.Trim());
			remoteIp = ip;
		}

        private void timer1_Tick_1(object sender, EventArgs e)
        {
			record_JS++;
			//欧拉角
			textBox9.Text = Data[0].ToString();
			textBox2.Text = Data[1].ToString();
			textBox3.Text = Data[2].ToString();

			textBox4.Text = Data1[0].ToString();
			textBox5.Text = Data1[1].ToString();
			textBox6.Text = Data1[2].ToString();

			textBox12.Text = Data2[0].ToString();
			textBox11.Text = Data2[1].ToString();
			textBox8.Text = Data2[2].ToString();

			textBox19.Text = Data3[0].ToString();
			textBox20.Text = Data3[1].ToString();
			textBox21.Text = Data3[2].ToString();

			textBox22.Text = Data4[0].ToString();
			textBox23.Text = Data4[1].ToString();
			textBox24.Text = Data4[2].ToString();

			textBox25.Text = Data5[0].ToString();
			textBox26.Text = Data5[1].ToString();
			textBox27.Text = Data5[2].ToString();

			textBox28.Text = Data6[0].ToString();
			textBox29.Text = Data6[1].ToString();
			textBox30.Text = Data6[2].ToString();

			textBox31.Text = Data7[0].ToString();
			textBox32.Text = Data7[1].ToString();
			textBox33.Text = Data7[2].ToString();

			textBox34.Text = Data8[0].ToString();
			textBox35.Text = Data8[1].ToString();
			textBox36.Text = Data8[2].ToString();

			textBox37.Text = Data9[0].ToString();
			textBox38.Text = Data9[1].ToString();
			textBox39.Text = Data9[2].ToString();

			textBox50.Text = Data10[0].ToString();
			textBox51.Text = Data10[1].ToString();
			textBox52.Text = Data10[2].ToString();

			textBox42.Text = Data11[0].ToString();
			textBox43.Text = Data11[1].ToString();
			textBox44.Text = Data11[2].ToString();
			textBox46.Text = Data12[0].ToString();
			textBox47.Text = Data12[1].ToString();
			textBox48.Text = Data12[2].ToString();
			textBox70.Text = Data13[0].ToString();
			textBox69.Text = Data13[1].ToString();
			textBox68.Text = Data13[2].ToString();
			textBox75.Text = Data14[0].ToString();
			textBox74.Text = Data14[1].ToString();
			textBox73.Text = Data14[2].ToString();
			//加速度
			textBox100.Text = AData1[0].ToString();
			textBox101.Text = AData1[1].ToString();
			textBox102.Text = AData1[2].ToString();
			textBox200.Text = AData2[0].ToString();
			textBox201.Text = AData2[1].ToString();
			textBox202.Text = AData2[2].ToString();
			textBox300.Text = AData3[0].ToString();
			textBox301.Text = AData3[1].ToString();
			textBox302.Text = AData3[2].ToString();
			textBox400.Text = AData4[0].ToString();
			textBox401.Text = AData4[1].ToString();
			textBox402.Text = AData4[2].ToString();
			textBox500.Text = AData5[0].ToString();
			textBox501.Text = AData5[1].ToString();
			textBox502.Text = AData5[2].ToString();
			textBox600.Text = AData6[0].ToString();
			textBox601.Text = AData6[1].ToString();
			textBox602.Text = AData6[2].ToString();
			textBox700.Text = AData7[0].ToString();
			textBox701.Text = AData7[1].ToString();
			textBox702.Text = AData7[2].ToString();
			textBox800.Text = AData8[0].ToString();
			textBox801.Text = AData8[1].ToString();
			textBox802.Text = AData8[2].ToString();
			textBox900.Text = AData9[0].ToString();
			textBox901.Text = AData9[1].ToString();
			textBox902.Text = AData9[2].ToString();
			textBox1000.Text = AData10[0].ToString();
			textBox1001.Text = AData10[1].ToString();
			textBox1002.Text = AData10[2].ToString();
			textBox1100.Text = AData11[0].ToString();
			textBox1101.Text = AData11[1].ToString();
			textBox1102.Text = AData11[2].ToString();
			textBox1200.Text = AData12[0].ToString();
			textBox1201.Text = AData12[1].ToString();
			textBox1202.Text = AData12[2].ToString();
			textBox1300.Text = AData13[0].ToString();
			textBox1301.Text = AData13[1].ToString();
			textBox1302.Text = AData13[2].ToString();
			textBox1400.Text = AData14[0].ToString();
			textBox1401.Text = AData14[1].ToString();
			textBox1402.Text = AData14[2].ToString();
			textBox1500.Text = AData15[0].ToString();
			textBox1501.Text = AData15[1].ToString();
			textBox1502.Text = AData15[2].ToString();
			//角速度
			textBox103.Text = WData1[0].ToString();
			textBox104.Text = WData1[1].ToString();
			textBox105.Text = WData1[2].ToString();
			textBox203.Text = WData2[0].ToString();
			textBox204.Text = WData2[1].ToString();
			textBox205.Text = WData2[2].ToString();
			textBox303.Text = WData3[0].ToString();
			textBox304.Text = WData3[1].ToString();
			textBox305.Text = WData3[2].ToString();
			textBox403.Text = WData4[0].ToString();
			textBox404.Text = WData4[1].ToString();
			textBox405.Text = WData4[2].ToString();
			textBox503.Text = WData5[0].ToString();
			textBox504.Text = WData5[1].ToString();
			textBox505.Text = WData5[2].ToString();
			textBox603.Text = WData6[0].ToString();
			textBox604.Text = WData6[1].ToString();
			textBox605.Text = WData6[2].ToString();
			textBox703.Text = WData7[0].ToString();
			textBox704.Text = WData7[1].ToString();
			textBox705.Text = WData7[2].ToString();
			textBox803.Text = WData8[0].ToString();
			textBox804.Text = WData8[1].ToString();
			textBox805.Text = WData8[2].ToString();
			textBox903.Text = WData9[0].ToString();
			textBox904.Text = WData9[1].ToString();
			textBox905.Text = WData9[2].ToString();
			textBox1003.Text = WData10[0].ToString();
			textBox1004.Text = WData10[1].ToString();
			textBox1005.Text = WData10[2].ToString();
			textBox1103.Text = WData11[0].ToString();
			textBox1104.Text = WData11[1].ToString();
			textBox1105.Text = WData11[2].ToString();
			textBox1203.Text = WData12[0].ToString();
			textBox1204.Text = WData12[1].ToString();
			textBox1205.Text = WData12[2].ToString();
			textBox1303.Text = WData13[0].ToString();
			textBox1304.Text = WData13[1].ToString();
			textBox1305.Text = WData13[2].ToString();
			textBox1403.Text = WData14[0].ToString();
			textBox1404.Text = WData14[1].ToString();
			textBox1405.Text = WData14[2].ToString();
			textBox1503.Text = WData15[0].ToString();
			textBox1504.Text = WData15[1].ToString();
			textBox1505.Text = WData15[2].ToString();
			if (_IsSave == true)
			{
				uwbdata += textBox9.Text + "\t" + textBox2.Text + "\t" + textBox3.Text + "\t" + "\t" +
						   textBox4.Text + "\t" + textBox5.Text + "\t" + textBox6.Text + "\t" + "\t" +
						   textBox12.Text + "\t" + textBox11.Text + "\t" + textBox8.Text + "\t" + "\t" +
						   textBox19.Text + "\t" + textBox20.Text + "\t" + textBox21.Text + "\t" + "\t" +
						   textBox22.Text + "\t" + textBox23.Text + "\t" + textBox24.Text + "\t" + "\t" +
						   textBox25.Text + "\t" + textBox26.Text + "\t" + textBox27.Text + "\t" + "\t" +
						   textBox28.Text + "\t" + textBox29.Text + "\t" + textBox30.Text + "\t" + "\t" +
						   textBox31.Text + "\t" + textBox32.Text + "\t" + textBox33.Text + "\t" + "\t" +
						   textBox34.Text + "\t" + textBox35.Text + "\t" + textBox36.Text + "\t" + "\t" +
						   textBox37.Text + "\t" + textBox38.Text + "\t" + textBox39.Text + "\t" + "\t" +
						   textBox50.Text + "\t" + textBox51.Text + "\t" + textBox52.Text + "\t" + "\t" +
						   textBox42.Text + "\t" + textBox43.Text + "\t" + textBox44.Text + "\t" + "\t" +
						   textBox46.Text + "\t" + textBox47.Text + "\t" + textBox48.Text + "\t" + "\t" +
						   textBox70.Text + "\t" + textBox69.Text + "\t" + textBox68.Text + "\t" + "\t" +
						   textBox75.Text + "\t" + textBox74.Text + "\t" + textBox73.Text + "\t" + "\t" +
										   "\r\n";
			}
		
		}
		//刷新
        private void button12_Click(object sender, EventArgs e)
        {
			exit1 = false;
			exit2 = false;
			exit3 = false;
			exit4 = false;
			exit5 = false;
			exit6 = false;
			exit7 = false;
			exit8 = false;
			exit9 = false;
			exit10 = false;
			exit11 = false;
			exit12 = false;
			exit13 = false;
			exit14 = false;
			exit15 = false;
			Thread thread = new Thread(ReceiveData);
			thread.IsBackground = true;
			thread.Start();
			Thread thread2 = new Thread(ReceiveData1);
			thread2.IsBackground = true;
			thread2.Start();
			Thread thread3 = new Thread(ReceiveData2);
			thread3.IsBackground = true;
			thread3.Start();
			Thread thread4 = new Thread(ReceiveData3);
			thread4.IsBackground = true;
			thread4.Start();
			Thread thread5 = new Thread(ReceiveData4);
			thread5.IsBackground = true;
			thread5.Start();
			Thread thread6 = new Thread(ReceiveData5);
			thread6.IsBackground = true;
			thread6.Start();
			Thread thread7 = new Thread(ReceiveData6);
			thread7.IsBackground = true;
			thread7.Start();
			Thread thread8 = new Thread(ReceiveData7);
			thread8.IsBackground = true;
			thread8.Start();
			Thread thread9 = new Thread(ReceiveData8);
			thread9.IsBackground = true;
			thread9.Start();
			Thread thread10 = new Thread(ReceiveData9);
			thread10.IsBackground = true;
			thread10.Start();
			Thread thread11 = new Thread(ReceiveData10);
			thread11.IsBackground = true;
			thread11.Start();
			Thread thread12 = new Thread(ReceiveData11);
			thread12.IsBackground = true;
			thread12.Start();
			Thread thread13 = new Thread(ReceiveData12);
			thread13.IsBackground = true;
			thread13.Start();
			Thread thread14 = new Thread(ReceiveData13);
			thread14.IsBackground = true;
			thread14.Start();
			Thread thread15 = new Thread(ReceiveData14);
			thread15.IsBackground = true;
			thread15.Start();
		}
		//20HZ
        private void button21_Click(object sender, EventArgs e)
        {
			int num = 0;
			byte[] array = new byte[21];
			IPEndPoint iPEndPoint = remote1;
			IPEndPoint iPEndPoint2 = remote2;
			IPEndPoint iPEndPoint3 = remote3;
			IPEndPoint iPEndPoint4 = remote4;
			IPEndPoint iPEndPoint5 = remote5;
			IPEndPoint iPEndPoint6 = remote6;
			IPEndPoint iPEndPoint7 = remote7;
			IPEndPoint iPEndPoint8 = remote8;
			IPEndPoint iPEndPoint9 = remote9;
			IPEndPoint iPEndPoint10 = remote10;
			IPEndPoint iPEndPoint11 = remote11;
			IPEndPoint iPEndPoint12 = remote12;
			IPEndPoint iPEndPoint13 = remote13;
			IPEndPoint iPEndPoint14 = remote14;
			IPEndPoint iPEndPoint15 = remote15;
			UdpClient udpClient = null;
			IPEndPoint iPEndPoint16 = null;
			for (num = 0; num < 15; num++)
			{
				switch (num)
				{
					case 0:
						iPEndPoint16 = iPEndPoint;
						udpClient = sendUdpClient;
						break;
					case 1:
						iPEndPoint16 = iPEndPoint2;
						udpClient = sendUdpClient1;
						break;
					case 2:
						iPEndPoint16 = iPEndPoint3;
						udpClient = sendUdpClient2;
						break;
					case 3:
						iPEndPoint16 = iPEndPoint4;
						udpClient = sendUdpClient3;
						break;
					case 4:
						iPEndPoint16 = iPEndPoint5;
						udpClient = sendUdpClient4;
						break;
					case 5:
						iPEndPoint16 = iPEndPoint6;
						udpClient = sendUdpClient5;
						break;
					case 6:
						iPEndPoint16 = iPEndPoint7;
						udpClient = sendUdpClient6;
						break;
					case 7:
						iPEndPoint16 = iPEndPoint8;
						udpClient = sendUdpClient7;
						break;
					case 8:
						iPEndPoint16 = iPEndPoint9;
						udpClient = sendUdpClient8;
						break;
					case 9:
						iPEndPoint16 = iPEndPoint10;
						udpClient = sendUdpClient9;
						break;
					case 10:
						iPEndPoint16 = iPEndPoint11;
						udpClient = sendUdpClient10;
						break;
					case 11:
						iPEndPoint16 = iPEndPoint12;
						udpClient = sendUdpClient11;
						break;
					case 12:
						iPEndPoint16 = iPEndPoint13;
						udpClient = sendUdpClient12;
						break;
					case 13:
						iPEndPoint16 = iPEndPoint14;
						udpClient = sendUdpClient13;
						break;
					case 14:
						iPEndPoint16 = iPEndPoint15;
						udpClient = sendUdpClient14;
						break;
				}
				if (iPEndPoint16 != null && udpClient != null)
				{
					sendUdpClient_public = udpClient;
					iep_public = iPEndPoint16;
				}
				array[0] = 87;
				array[1] = 84;
				array[2] = 52;
				array[3] = 55;
				array[4] = 48;
				array[5] = 48;
				array[6] = 48;
				array[7] = 48;
				array[8] = 48;
				array[9] = 51;
				array[10] = 57;
				array[11] = 54;
				array[12] = 48;
				array[13] = 50;
				array[14] = byte.MaxValue;
				array[15] = 170;
				array[16] = 104;
				array[17] = 50;
				array[18] = 0;
				array[19] = 13;
				array[20] = 10;
				if (iep_public != null)
				{
					sendUdpClient_public.Send(array, array.Length, iep_public);
					textBox99.Text = "";
					textBox99.AppendText("20HZ");
				}
				else
				{
					textBox99.Text = "";
					textBox99.AppendText("未连接");
				}
				array[0] = 87;
				array[1] = 84;
				array[2] = 52;
				array[3] = 55;
				array[4] = 48;
				array[5] = 48;
				array[6] = 48;
				array[7] = 48;
				array[8] = 48;
				array[9] = 51;
				array[10] = 57;
				array[11] = 54;
				array[12] = 48;
				array[13] = 50;
				array[14] = byte.MaxValue;
				array[15] = 170;
				array[16] = 0;
				array[17] = 0;
				array[18] = 0;
				array[19] = 13;
				array[20] = 10;
				if (iep_public != null)
				{
					//sendUdpClient_public.Send(array, array.Length, iep_public);
					textBox99.Text = "";
					textBox99.AppendText("参数保存");
				}
				else
				{
					textBox99.Text = "";
					textBox99.AppendText("未连接");
				}
			}
			num = 0;
			exit1 = true;
			exit2 = true;
			exit3 = true;
			exit4 = true;
			exit5 = true;
			exit6 = true;
			exit7 = true;
			exit8 = true;
			exit9 = true;
			exit10 = true;
			exit11 = true;
			exit12 = true;
			exit13 = true;
			exit14 = true;
			exit15 = true;
			Thread.Sleep(200);
			exit1 = false;
			exit2 = false;
			exit3 = false;
			exit4 = false;
			exit5 = false;
			exit6 = false;
			exit7 = false;
			exit8 = false;
			exit9 = false;
			exit10 = false;
			exit11 = false;
			exit12 = false;
			exit13 = false;
			exit14 = false;
			exit15 = false;
			Thread thread = new Thread(ReceiveData);
			thread.IsBackground = true;
			thread.Start();
			Thread thread2 = new Thread(ReceiveData1);
			thread2.IsBackground = true;
			thread2.Start();
			Thread thread3 = new Thread(ReceiveData2);
			thread3.IsBackground = true;
			thread3.Start();
			Thread thread4 = new Thread(ReceiveData3);
			thread4.IsBackground = true;
			thread4.Start();
			Thread thread5 = new Thread(ReceiveData4);
			thread5.IsBackground = true;
			thread5.Start();
			Thread thread6 = new Thread(ReceiveData5);
			thread6.IsBackground = true;
			thread6.Start();
			Thread thread7 = new Thread(ReceiveData6);
			thread7.IsBackground = true;
			thread7.Start();
			Thread thread8 = new Thread(ReceiveData7);
			thread8.IsBackground = true;
			thread8.Start();
			Thread thread9 = new Thread(ReceiveData8);
			thread9.IsBackground = true;
			thread9.Start();
			Thread thread10 = new Thread(ReceiveData9);
			thread10.IsBackground = true;
			thread10.Start();
			Thread thread11 = new Thread(ReceiveData10);
			thread11.IsBackground = true;
			thread11.Start();
			Thread thread12 = new Thread(ReceiveData11);
			thread12.IsBackground = true;
			thread12.Start();
			Thread thread13 = new Thread(ReceiveData12);
			thread13.IsBackground = true;
			thread13.Start();
			Thread thread14 = new Thread(ReceiveData13);
			thread14.IsBackground = true;
			thread14.Start();
			Thread thread15 = new Thread(ReceiveData14);
			thread15.IsBackground = true;
			thread15.Start();
		}
		//复位
		private void button13_Click(object sender, EventArgs e)
		{
			exit1 = true;
			exit2 = true;
			exit3 = true;
			exit4 = true;
			exit5 = true;
			exit6 = true;
			exit7 = true;
			exit8 = true;
			exit9 = true;
			exit10 = true;
			exit11 = true;
			exit12 = true;
			exit13 = true;
			exit14 = true;
			exit15 = true;
		}
		//打开Kinect
		private void button1_Click(object sender, EventArgs e)
        {
			//string s = RunExe.RunExeRes(Resources.被嵌入的程序);
			// MessageBox.Show(s);

			EmbeddedExeTool exetool = new EmbeddedExeTool();
			///test.exe 为要嵌入外部exe的具体路径
			exetool.LoadEXE(panel1, "F:\\用于测试全身姿态的采集\\被嵌入的程序\\被嵌入的程序\\bin\\Debug\\被嵌入的程序.exe");
		}
		//打开UNITY
        private void button2_Click(object sender, EventArgs e)
        {
			//string s = RunExe.RunExeRes(Resources.被嵌入的程序);
			// MessageBox.Show(s);

			EmbeddedExeTool exetool1 = new EmbeddedExeTool();
			///test.exe 为要嵌入外部exe的具体路径
			exetool1.LoadEXE(panel2, "F:\\用于测试全身姿态的采集\\姿态采集\\姿态采集\\bin\\Debug\\UnityApp1\\Animation01.exe");
		}

        private void button4_Click(object sender, EventArgs e)
        {
			if (_IsSave == true)
			{
				_IsSave = false;
				button3.Text = "保存";
				button4.Text = "已停止";
				_SW.Close();
				_SW2.Close();
				//_SW3.Close();
				string tiem1 = DateTime.Now.ToString("yyyy_MM_dd_"); ;
				string tiem2 = DateTime.Now.ToString("hh_mm_ss_");        // 08:05:57
				string result1 = tiem1 + tiem2 + "imu.txt";
				//保存数据
				createFile(result1, uwbdata);
			}
			else
			{
				button3.Text = "启动保存";
			}
		}

        private void button3_Click(object sender, EventArgs e)
        {
			if (_IsSave == false)
			{
				_IsSave = true;
				button3.Text = "运行中";
				button4.Text = "停止保存";

				//string folderName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
				//_CoordinatePath = Path.Combine(System.Environment.CurrentDirectory, folderName);
				//Directory.CreateDirectory(_CoordinatePath);
				// 创建_SW.txt文件
				//string swFilePath = Path.Combine(_CoordinatePath, "_SW.txt");
				//_SW = new StreamWriter(swFilePath);
				// 创建_SW2.txt文件
				//string sw2FilePath = Path.Combine(_CoordinatePath, "_SW2.txt");
				//_SW2 = new StreamWriter(sw2FilePath);

				_CoordinatePath = System.Environment.CurrentDirectory;
				string timepath = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
				_SW = new StreamWriter(_CoordinatePath + @"\" + timepath + @"Kinect.TXT");
				_SW2 = new StreamWriter(_CoordinatePath + @"\" + timepath + @"四元数.TXT");

				//_SW3 = new StreamWriter(_CoordinatePath + @"\" + timepath + @"全身姿态.TXT");

			}
			else
			{
				button3.Text = "保存";
			}
		}
		// 创建txt文件
		public void createFile(string fullPath, string content)   //参数：文件路径，文本内容
		{
			FileStream file = File.OpenWrite(fullPath);    //打开一个现有文件或创建一个文件来写入 
			StreamWriter writer = new StreamWriter(file);   //创建写入流

			writer.WriteLine(content);   //写入数据
			writer.Flush();      //清理写入器的缓冲区
			writer.Close();       //关闭写入器
			MessageBox.Show("文件保存成功！");
		}
		//创建IMU数据曲线
		private void zedGraphControl2_Load(object sender, EventArgs e)
        {
			
		}

        private void button7_Click(object sender, EventArgs e)
        {
			if (_close == false)
			{
				_close = true;
				vlist.Clear();
				vlist2.Clear();
				vlist3.Clear();
				button7.Text = "已重置";
				
			}
			else
			{
				_close = false;
				button7.Text = "重置";
				//this.myZedgraph.Load += new System.EventHandler(this.zedGraphControl2_Load);
				ChartTimer.Start();
				//time = 30;
			}
		}

        private void button8_Click(object sender, EventArgs e)
        {
			if (_close1 == false)
			{
				_close1 = true;
				vlist4.Clear();
				vlist5.Clear();
				vlist6.Clear();
				button8.Text = "已重置";
				// 清除图表内容

			}
			else
			{
				_close1 = false;
				button8.Text = "重置";
				//this.myZedgraph.Load += new System.EventHandler(this.zedGraphControl2_Load);
				ChartTimer1.Start();
				//time = 30;
			}
		}

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
