using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 麻将服务器hosts改写
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear(); //远程服务器IP
            string ipStr = textBox1.Text.ToString().Trim(); //构造Ping实例
            Ping pingSender = new Ping(); //Ping 选项设置
            PingOptions options = new PingOptions();
            options.DontFragment = true; //测试数据
            string data = "";
            byte[] buffer = Encoding.ASCII.GetBytes(data); //设置超时时间
            int timeout = 1024; //调用同步 send 方法发送数据,将返回结果保存至PingReply实例
            PingReply reply = pingSender.Send(ipStr, timeout, buffer, options);
            if (reply.Status == IPStatus.Success) //显示信息
            {
                listBox1.Items.Add("答复的主机地址:" + reply.Address.ToString());
                listBox1.Items.Add("往返时间:" + reply.RoundtripTime);
                listBox1.Items.Add("生存时间(TTL):" + reply.Options.Ttl);
                listBox1.Items.Add("是否控制数据包的分段:" + reply.Options.DontFragment);
                listBox1.Items.Add("缓冲区大小:" + reply.Buffer.Length);
            }
            else
                listBox1.Items.Add(reply.Status.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("欢迎使用本程序","这是欢迎界面!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            MessageBox.Show("请注意:现阶段只可以改善Mojang的会话服务器和认证服务器!");
            form2.Show();
        }
    }
}
