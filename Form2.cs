using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace 姿态采集
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            EmbeddedExeTool exetool = new EmbeddedExeTool();
            ///test.exe 为要嵌入外部exe的具体路径
            exetool.LoadEXE(canvasPanel, "D:\\vs\\第二代Kinect WPF开发从入门到精通资料集合\\KinectMeasureJointAngle-master\\KinectCoordinateMapping\\bin\\Debug\\KinectCoordinateMapping.exe");

        }

        // 关闭窗体时释放 Kinect 资源
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }






    }
}
