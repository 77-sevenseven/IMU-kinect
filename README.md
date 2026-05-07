# IMU-kinect
多传感器-姿态数据采集-全身15个IMU传感器+KinectV2相机采集动作-WPE显示+Unity3D展示

本文档介绍本目录中的 WPF 子程序：

该 WPF 程序主要用于通过 Kinect v2 读取人体骨骼数据，并在窗口中实时绘制人体骨架。

## 项目作用

- 连接默认 Kinect 体感设备。
- 读取 Kinect BodyFrame 骨骼帧。
- 支持最多 6 个人体目标的骨架显示。
- 将 Kinect 三维关节坐标映射到彩色图像平面坐标。
- 根据关节连接关系绘制全身骨架线段和关节点。
- 自动选取距离 Kinect 最近的人体作为主要跟踪对象。
- 在窗口关闭时释放 Kinect 读取器和设备资源。

## 项目结构

```text
被嵌入的程序
├─ 被嵌入的程序.sln
└─ 被嵌入的程序
   ├─ App.xaml
   ├─ App.xaml.cs
   ├─ MainWindow.xaml
   ├─ MainWindow.xaml.cs
   ├─ App.config
   ├─ 被嵌入的程序.csproj
   └─ Properties
```

主要代码在：

```text
被嵌入的程序\被嵌入的程序\MainWindow.xaml.cs
```

其中：

- `_KinectDevice`：Kinect 设备对象。
- `_BodyFrameReader`：骨骼帧读取器。
- `_Bodies`：最多 6 个用户的骨骼数据数组。
- `_PrimaryBody`：当前距离 Kinect 最近的主要人体。
- `_JointType`：骨架连线使用的关节连接顺序。
- `DrawBodies()`：绘制人体骨架。
- `GetNearBody()`：选取最近人体。
- `GetJointPointScreen()`：把 Kinect 关节坐标转换到 WPF 窗口坐标。
- `Window_Closing()`：关闭窗口时释放 Kinect 资源。

## 运行环境

建议环境：

- Windows 系统。
- Visual Studio。
- .NET Framework 4.7.2。
- Kinect for Windows SDK 2.0。
- Kinect v2 设备及对应驱动。

如果没有安装 Kinect SDK 或没有连接 Kinect 设备，程序可能无法正常启动或无法读取骨骼数据。

## 运行方式

1. 连接 Kinect v2 设备。
2. 确认 Kinect 驱动和 Kinect for Windows SDK 2.0 已安装。
3. 使用 Visual Studio 打开：


4. 选择 `Debug` 或 `Release` 配置。
5. 编译并运行项目。

运行后，窗口会显示骨架绘制区域；当 Kinect 跟踪到人体时，会在界面中绘制对应的人体骨架。

## 与主程序的关系

本目录下还有一个 WinForms 主程序：


该主程序包含更多采集、保存、IMU、曲线显示和外部程序嵌入逻辑。WPF 子程序更专注于 Kinect 骨架显示，可作为主程序中的可视化模块或独立骨架显示程序使用。

## 注意事项

- 该 WPF 子程序本身主要负责实时显示骨架，不是完整的数据采集保存软件。
- Kinect 相关程序通常依赖本机安装的 Kinect SDK 和设备驱动。
- 如果编译时提示找不到 `Microsoft.Kinect`，需要检查 Kinect SDK 是否安装，或检查项目引用是否正确。
- 关闭窗口时应正常触发资源释放逻辑，避免 Kinect 设备被进程占用。

