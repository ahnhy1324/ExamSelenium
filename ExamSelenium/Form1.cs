﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ExamSelenium
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            crawlling.go();
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            crawlling.start();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
