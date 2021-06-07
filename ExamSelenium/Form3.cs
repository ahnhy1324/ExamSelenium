using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamSelenium
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://open.yonsei.ac.kr/");
        }   // 런-어스 하이퍼 링크 : 런어스 열기

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://portal.yonsei.ac.kr/main/");
        }   // 연세포탈 하이퍼 링크 : 연세포탈 열기

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("종료하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }   // 끝내기 버튼 : 프로그램 종료

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("로그아웃하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Visible = false;
                Form1 showForm1 = new Form1();
                showForm1.ShowDialog();
            }
        }   // 로그아웃 버튼 : 폼 1로 돌아가기

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form4 showForm4 = new Form4();
            showForm4.ShowDialog();
        }   // 열기 버튼 1 : 폼 4 열기

        private void button11_Click(object sender, EventArgs e)
        {
            Form4 showForm4 = new Form4();
            showForm4.ShowDialog();
        }   // 열기 버튼 1 : 폼 4 열기

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        }   // 현재 시간 텍스트박스 : 현재 시간 출력

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }   // 서버 상태 텍스트 박스 : 크롤링 성공 시 정상 출력, 실패 시 비정상 출력

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }   // 런-어스 재 크롤링 남은 시간 출력 : 남는 시간 만큼 출력
    }
}