//*********************❤*********************
// 
// 文件名（File Name）：  UDP_Receive.cs
// 
// 作者（Author）：          LoveNeon
// 
// 创建时间（CreateTime）：    Don't Care
// 
// 说明（Description）： 只负责接受消息，不进行处理
// 
//*********************❤*********************
using UnityEngine;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
public class UDP_Receive : MonoBehaviour
{

	//[Tooltip("消息处理类")] public UDP_Solve m_messageManage;
	[Tooltip("接受端口号")] public int m_ReceivePort = 8080;

	private Socket m_newsock;//定义一个socket变量
	private IPEndPoint m_ip;//定义一个IP地址和端口号
	private int m_recv;//定义一个接受值的变量
	private byte[] m_data = new byte[1024];//定义一个二进制的数组用来获取客户端发过来的数据包
	private string m_mydata;
	private List<string> m_array_data = new List<string>();

	public static bool VoiceUp = false;
	public static bool Card = false;

	/// <summary>
	/// 设置网络
	/// </summary>
	void Start()
	{
		Debug.Log ("start");
		//得到本机IP，设置UDP端口号        
		m_ip = new IPEndPoint(IPAddress.Any, m_ReceivePort);//设置自身的IP和端口号，在这里IPAddress.Any是自动获取本机IP
		m_newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//实例化socket对象设置寻址方案为internetwork（IP版本的4存放）,设置Soket的类型，为Dgram（支持数据报形式的数据），设置协议的类型，为UDP
		//绑定网络地址
		m_newsock.Bind(m_ip);//绑定IP

		Thread test = new Thread(BeginListening);//定义一个子线程
		test.Start();//子线程开始
	}
	/// <summary>
	/// 更新
	/// </summary>
	void Update()
	{
		//byte[] msg_open_buzzer = { 0x21,0x01,0x09,0x01,0x57,0x40,0x2F,0x62,0x12,0x31,0x7C};
		//byte[] msg_close_buzzer = { 0x21,0x01,0x09,0x01,0x57,0x40,0x2F,0x62,0x12,0x30,0x7B};
		//byte[] msg_open_fan = { 0x21,0x01,0x09,0x01,0x57,0x40,0x2C,0x66,0x51,0x31,0x89};
		//byte[] msg_close_fan = { 0x21,0x01,0x09,0x01,0x57,0x40,0x2C,0x66,0x51,0x30,0x8E};
		//byte[] msg_open_light = { 0x21,0x01,0x09,0x01,0x57,0x40,0x2E,0x72,0x51,0x31,0xAC};
		//byte[] msg_close_light = { 0x21,0x01,0x09,0x01,0x57,0x40,0x2E,0x72,0x51,0x30,0xAB};
		//byte[] msg_open_ceilingfan = { 0x21,0x01,0x09,0x01,0x57,0x40,0x2C,0x66,0x51,0x31,0x89};???
		//byte[] msg_close_ceilingfan = { 0x21,0x01,0x09,0x01,0x57,0x40,0x2C,0x66,0x51,0x30,0x8E};???


		//string _ipStr = "192.168.1.100";
		//int _port = 20000;
		//Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//创建UDP服务
		//IPEndPoint ip = new IPEndPoint(IPAddress.Parse(_ipStr), _port);//定义一个IP地址和端口号
		//server.SendTo(/*Encoding.UTF8.GetBytes(_message)*/msg, ip);//发送消息
		//server.Close();//关闭服务


		//判断是否有数据
		//print("ListCount:" + m_array_data.Count);
		if (m_array_data.Count <= 0)
		{
			return;
		}
		//如果有数据 则循环遍历传入处理类
		for (int i = m_array_data.Count - 1; i >= 0; --i)
		{
			//m_messageManage.MessageManage(m_array_data[i]);
			//print("i=" + i);
			int type = str2num(m_array_data[i][14]) * 16 + str2num(m_array_data[i][15]);
			print("CommandType:" + type);
			switch (type) {
			//接受温湿度传感器，控制吊扇
			case 84:/*0x54*/
				AIR_TEMPERATURE.temperature = str2num (m_array_data [i] [18]) * 16 + str2num (m_array_data [i] [19]);
				AIR_HUMIDITY.humidity = str2num (m_array_data [i] [20]) * 16 + str2num (m_array_data [i] [21]);
				if (AIR_TEMPERATURE.temperature >= 25 )
				{
						byte[] msg_open_fan = { 0x21, 0x01, 0x09, 0x01, 0x57, 0x00, 0x34, 0x34, 0x51, 0x31, 0x64 };
						string _ipStr = "192.168.31.140";
						int _port = 20000;
						Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//创建UDP服务
						IPEndPoint ip = new IPEndPoint(IPAddress.Parse(_ipStr), _port);//定义一个IP地址和端口号
						server.SendTo(/*Encoding.UTF8.GetBytes(_message)*/msg_open_fan, ip);//发送消息
						server.Close();//关闭服务
				}
				else if (AIR_TEMPERATURE.temperature < 25 /*&& temperature != 0*/ )
				{
					
						byte[] msg_close_fan = { 0x21, 0x01, 0x09, 0x01, 0x57, 0x00, 0x34, 0x34, 0x51, 0x30, 0x63 };
						string _ipStr = "192.168.31.140";
						int _port = 20000;
						Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//创建UDP服务
						IPEndPoint ip = new IPEndPoint(IPAddress.Parse(_ipStr), _port);//定义一个IP地址和端口号
						server.SendTo(/*Encoding.UTF8.GetBytes(_message)*/msg_close_fan, ip);//发送消息
						server.Close();//关闭服务

				}
				break;

			//接受光敏传感器，控制窗帘
			case 76:/*0x4C*/
				LIGHT.m_light = (str2num (m_array_data [i] [18]) * 16 + str2num (m_array_data [i] [19])) * 256 + str2num (m_array_data [i] [20]) * 16 + str2num (m_array_data [i] [21]);
				print ("light:" + LIGHT.m_light);
				break;
			//火焰传感器
			case 38://0x26
				PM2_5.pm = (str2num (m_array_data [i] [18]) * 16 + str2num (m_array_data [i] [19])) * 256 + str2num (m_array_data [i] [20]) * 16 + str2num (m_array_data [i] [21]);
				break;
			//红外传感器
			case 102://0x66
				GAS.gas = str2num(m_array_data [i] [19]);
				break;
			default:
				break;
			}
				m_array_data.RemoveAt(i);//传入后移除
				//print("ListCount:" + m_array_data.Count);
		}
			//Debug.Log(m_array_data.Count + "+" + m_array_data.Capacity);
			m_array_data.Clear();//此步为了让集合的容量跟着清空
	}
	/// <summary>
	/// 线程接受
	/// </summary>
	void BeginListening()
	{
		IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);//实例化一个网络端点，设置为IPAddress.Any为自动获取跟我通讯的IP，0代表所有的地址都可以
		EndPoint Remote = (EndPoint)(sender);//实例化一个地址结束点来标识网络路径
		//  Debug.Log(Encoding.ASCII.GetString(data, 0, recv));//输出二进制转换为string类型用来测试
		while (true)
		{
			m_data = new byte[1024];//实例化data
			m_recv = m_newsock.ReceiveFrom(m_data, ref Remote);//将数据包接收到的数据放入缓存点，并存储终节点
			Debug.Log("message from: " + Remote.ToString()); //打印客户端信息
			//m_mydata = Encoding.ASCII.GetString(m_data, 0, m_recv);
			//Debug.Log(m_mydata);
			//Debug.Log(m_mydata.Length);
			//Debug.Log(m_recv);//打印收到的信息

			int i = 0;
			string s = "";
			for (i = 0; i < m_recv; i++)
				s += m_data[i].ToString("X2");//转成16进制字符串显示
			Debug.Log(s);
			if(s.Length > 15)
				m_array_data.Add(/*m_mydata*/s);//加入数组
		}
	}
	/// <summary>
	/// 退出后关闭网络
	/// </summary>
	void OnApplicationQuit()
	{
		m_newsock.Close();
	}
	int str2num(char c)
	{
		if (c >= '0' && c <= '9')
		{
			return c - '0';
		}
		else if (c >= 'a' && c <= 'f')
		{
			return c - 'a' + 10;
		}
		else if (c >= 'A' && c <= 'F')
		{
			return c - 'A' + 10;
		}
		else return -1;
	}
}

