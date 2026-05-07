using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;

namespace 被嵌入的程序
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Member Variables
        //体感设备
        private KinectSensor _KinectDevice;

        //骨骼图像
        //骨骼帧读取变量
        private BodyFrameReader _BodyFrameReader;

        //玩家数据
        private Body[] _Bodies;

        //主要的玩家
        private Body _PrimaryBody;

        //画骨架图颜色uint[]
        private Brush[] ColorBody = new Brush[]
        {
            Brushes.Red,Brushes.Green,Brushes.Pink,Brushes.Blue,Brushes.Black,Brushes.Orange
        };

        //关节点两两相连
        private JointType[] _JointType = new JointType[]{
            JointType.SpineBase,JointType.SpineMid,
            JointType.SpineMid,JointType.SpineShoulder,
            JointType.SpineShoulder,JointType.Neck,
            JointType.Neck,JointType.Head,

            JointType.SpineShoulder,JointType.ShoulderLeft,
            JointType.ShoulderLeft,JointType.ElbowLeft,
            JointType.ElbowLeft,JointType.WristLeft,
            JointType.WristLeft,JointType.HandLeft,
            JointType.HandLeft,JointType.HandTipLeft,
            JointType.HandLeft,JointType.ThumbLeft,

            JointType.SpineShoulder,JointType.ShoulderRight,
            JointType.ShoulderRight,JointType.ElbowRight,
            JointType.ElbowRight,JointType.WristRight,
            JointType.WristRight,JointType.HandRight,
            JointType.HandRight,JointType.HandTipRight,
            JointType.HandRight,JointType.ThumbRight,

            JointType.SpineBase,JointType.HipLeft,
            JointType.HipLeft,JointType.KneeLeft,
            JointType.KneeLeft,JointType.AnkleLeft,
            JointType.AnkleLeft,JointType.FootLeft,

            JointType.SpineBase,JointType.HipRight,
            JointType.HipRight,JointType.KneeRight,
            JointType.KneeRight,JointType.AnkleRight,
            JointType.AnkleRight,JointType.FootRight,

        };
        #endregion Member Variables

        #region Constructor
        public MainWindow()
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
        }
        #endregion Construtor

        #region Methods
        //骨骼帧处理事件
        void _BodyFrameReader_FrameArrived(object sender, BodyFrameArrivedEventArgs e)
        {
            //获取一帧骨骼
            using (BodyFrame bodyFrame = e.FrameReference.AcquireFrame())
            {
                if (bodyFrame != null)
                {
                    //骨骼网格清空
                    Layout.Children.Clear();

                    //玩家骨骼保存到数组里面
                    bodyFrame.GetAndRefreshBodyData(this._Bodies);

                    //画骨架
                    DrawBodies();

                    //获取最近的人的骨架
                    _PrimaryBody = GetNearBody(_Bodies);
                }
            }
        }
        //画骨架，六个人
        private void DrawBodies()
        {
            //遍历6个玩家
            for (int i = 0; i < this._Bodies.Length; i++)
            {
                //如果跟踪到玩家
                if (this._Bodies[i].IsTracked == true)
                {
                    //根据编号选择一种骨架的颜色
                    Brush color = ColorBody[i % 6];

                    Body oneBody = this._Bodies[i];
                    //通过循环将关节点两两连接，
                    for (int j = 0; j < this._JointType.Length; j += 2)
                    {
                        Line line = new Line();
                        line.Stroke = color;
                        line.StrokeThickness = 2;

                        //起点的屏幕坐标和终点的屏幕坐标
                        Point StartP = GetJointPointScreen(oneBody.Joints[this._JointType[j]]);
                        Point EndP = GetJointPointScreen(oneBody.Joints[this._JointType[j + 1]]);

                        Ellipse sp = new Ellipse();
                        Ellipse ep = new Ellipse();

                        sp.Width = 10;
                        sp.Height = 10;
                        sp.HorizontalAlignment = HorizontalAlignment.Left;
                        sp.VerticalAlignment = VerticalAlignment.Top;
                        sp.Fill = color;
                        ep.Width = 10;
                        ep.Height = 10;
                        ep.HorizontalAlignment = HorizontalAlignment.Left;
                        ep.VerticalAlignment = VerticalAlignment.Top;
                        ep.Fill = color;

                        sp.Margin = new Thickness(StartP.X - sp.Width / 2, StartP.Y - sp.Height / 2, 0, 0);
                        ep.Margin = new Thickness(EndP.X - ep.Width / 2, EndP.Y - ep.Height / 2, 0, 0);

                        //设置起点、终点的坐标
                        line.X1 = StartP.X;
                        line.Y1 = StartP.Y;
                        line.X2 = EndP.X;
                        line.Y2 = EndP.Y;

                        //把起点、终点及连接添加到网格中。
                        Layout.Children.Add(sp);
                        Layout.Children.Add(ep);
                        Layout.Children.Add(line);
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

        //骨骼坐标转化为彩色图像坐标，再转化为屏幕坐标
        private Point GetJointPointScreen(Joint oneJoint)
        {
            //骨骼坐标转化为彩色图像坐标
            ColorSpacePoint colorPoint = this._KinectDevice.CoordinateMapper.MapCameraPointToColorSpace(oneJoint.Position);

            //彩色图像坐标转化为屏幕坐标

            colorPoint.X = (int)((colorPoint.X * Layout.Width) / 1920);
            colorPoint.Y = (int)((colorPoint.Y * Layout.Height) / 1080);

            //返回Point类型变量
            return new Point(colorPoint.X, colorPoint.Y);
        }
        //窗口关闭处理事件
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
        }
        #endregion Methods
    }
}
