using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 巴那那的抽籤程式
{
    public partial class Form1 : Form
    {
        //private IPHostEntry IPHost = Dns.GetHostEntry(Environment.MachineName);
        int x = 0;
        private List<int> alist;
        private Random r = new Random(Guid.NewGuid().GetHashCode());
        private string[] ax;

        public Form1()
        {

            InitializeComponent();
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] processesByName = Process.GetProcessesByName(processName);
            if (processesByName.Length > 1)
            {
                MessageBox.Show("程式重複執行", "錯誤");
                Environment.Exit(2);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = Convert.ToString(DateTime.Now) + " 巴那那  ©  2016 - " + DateTime.Now.ToString("yyyy");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ax = null;
            textBox1.Enabled = true;
            textBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            richTextBox1.Enabled = false;
            richTextBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#808080");
            textBox1.Clear();                     
            output.Text = "";
            label4.Text = "";
            richTextBox1.Text = "按Enter為下一行";
            label5.Text = "";
            textBox1.Focus();






        }

        private void button2_Click(object sender, EventArgs e)
        {
            alist = null;
            richTextBox1.Enabled = true;
            richTextBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            textBox1.Enabled = false;
            textBox1.BackColor = System.Drawing.ColorTranslator.FromHtml("#808080");
            textBox1.Clear();
            label5.Text = "";
            output.Text = "";
            label4.Text = "";
            textBox1.Text = "請輸入人數";
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Int32 lineLength = richTextBox1.Lines.Length;
            if (lineLength > 0)
            {
                label5.Text = "共有" + Convert.ToString(lineLength-1) + "筆資料";
            }             
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled ==false & richTextBox1.Enabled==false)
            {
                MessageBox.Show("請先選擇抽籤方式");
                return;
            }
            //一般抽籤
            if (alist != null && alist.Count != 0)
            {
                try
                {

                    int index = r.Next(alist.Count);
                    label5.Text = "我抽我抽我抽抽抽";
                    output.Text = Convert.ToString(alist[index]);
                    alist.RemoveAt(index);
                    label4.Text = string.Concat(new object[]
                    {
                    label4.Text=output.Text,"已被移除，目前剩",alist.Count,"位"
                    });
                    if (this.alist.Count == 0)
                    {
                        MessageBox.Show("已無數字","提示");
                        alist.Clear();
                        alist = null;
                        textBox1.Clear();
                        label5.Text = "";
                        output.Text = "";                        
                        label4.Text = "";
                        MessageBox.Show("欄位已全清空", "提示");
                        this.textBox1.Focus();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("請輸入數字後按確認", "Error");
                }
            }
            else
            {
                //自訂抽籤
               
                try
                 {
                                        
					label5.Text = "我抽我抽我抽抽抽";
					int index = r.Next(0, ax.Length);
					output.Text = Convert.ToString(ax[index]);
					ax = ax.Where(val => val != ax[index]).ToArray();
					label4.Text = string.Concat(new object[]
                                            {
                    label4.Text=output.Text,"已被移除，目前剩",ax.Length,"位"
                                            });
                    if (ax.Length == 0)
                     {
						MessageBox.Show("已無資料","提示");
				     }


                 }
                 catch (Exception)
                 {
                   MessageBox.Show("請輸入資料後按確認", "Error");
                 }
                
            }        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Enabled == false & richTextBox1.Enabled == false)
            {
                MessageBox.Show("請先選擇抽籤方式","Error");
                return;
            }
            try
            {
                x = Convert.ToInt32(textBox1.Text);
                if (x <= 0)
                {
                    MessageBox.Show("數字不能為0","Error");
                    textBox1.Clear();
                    return;
                }
                else
                {
                    this.alist = new List<int>();
                    for (int i = 1; i <= this.x; i++)
                    {
                        this.alist.Add(i);
                    }
                    MessageBox.Show("快去開始抽籤吧", "提示");
                    start.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
                if (alist==null)
                {
                   MessageBox.Show("請重新輸入數字");
                   textBox1.Clear();                    
                   textBox1.Focus();
                }
            }         
        }

        private void Enter2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Enabled == false & richTextBox1.Enabled == false)
            {
                MessageBox.Show("請先選擇抽籤方式");
                return;
            }            
            //一行取一個按Enter一行
            string str = richTextBox1.Text.Trim().Replace(System.Environment.NewLine, "\n");
            ax = str.Split('\n');
            MessageBox.Show("快去開始抽籤吧","提示");
            start.Focus();
        }

        private void output_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

		private void Label6_Click(object sender, EventArgs e)
		{
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Int32 lineLength = richTextBox1.Lines.Length;
            if (lineLength-1 > 0) { 
                ax = null;
                label5.Text = "";
                label4.Text = "";
                output.Text = "";
                richTextBox1.Clear();
                MessageBox.Show("欄位已全清空", "提示");
                richTextBox1.Focus();
            }
            else
            {
                MessageBox.Show("自訂欄位無資料", "提示");
            }
        }
    }
}
