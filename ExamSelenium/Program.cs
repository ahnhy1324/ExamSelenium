using System;
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
    static class crawlling
    {

        static ChromeDriverService _driverService = null;
        static ChromeOptions _options = null;
        static ChromeDriver _driver = null;
        public static void go() {
            try
            {
                _driverService = ChromeDriverService.CreateDefaultService();
                _driverService.HideCommandPromptWindow = true;

                _options = new ChromeOptions();
                _options.AddArgument("disable-gpu");
            }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.Message);
            } 
        }
        public static IReadOnlyCollection<IWebElement> Find(string name) 
        {
            var course_box = _driver.FindElement(By.ClassName("total-sections"));
            var HW = course_box.FindElements(By.XPath(".//img[@alt='"+name+"']"));
            return HW;
        }
        public static void start()
        {
            try
            {

                // string id = textBox1.Text;

                // string pw = textBox2.Text;

                List<string> inf = new List<string>();

                _driver = new ChromeDriver(_driverService, _options);

                //id = "2017253020";

                // pw = "980408";

                _driver.Navigate().GoToUrl("https://open.yonsei.ac.kr/passni/sso/coursemosLogin.php?username=" + login.ID + "&password=" + login.PW + "&ssoGubun=Login");

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                var notice = _driver.FindElements(By.ClassName("close"));

                notice[0].Click();

                notice[1].Click();

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                var box = _driver.FindElement(By.ClassName("front-box"));

                //                Trace.WriteLine(box.Text);

                var list = box.FindElements(By.ClassName("course-box"));

                //                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                int k = 1;

                int l = 1;

                foreach (var d in list) // list -> 과목들
                {

                    k = l;

                    foreach (var c in list)
                    {

                        int i = 0;

                        int j = 0;

                        k--;

                        if (k == 0)

                        {
                            Trace.WriteLine(c.Text);

                            inf.Add("과목 " + c.Text);

                            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                            c.Click();

                            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                            var HW = Find("동영상").ToArray();
                            IWebElement c1;
                            foreach (var b in HW)

                            {

                                i = j; // 들어있는 리스트 중에 j번째로 있는 과제 페이지 접근
                                       //  Trace.WriteLine(a.Text);
                                
                                foreach (var a in HW)
                                {
                                    c1 = HW[j];
                                    inf.Add("과제 " + c1.Text);

                                    c1.Click();
                                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

                                    var HWtable = _driver.FindElement(By.ClassName("generaltable"));
                                    var tbody = HWtable.FindElement(By.TagName("tbody"));
                                    var HWresult = tbody.FindElements(By.TagName("tr"));
                                    Trace.WriteLine(HWresult[0].Text);
                                    Trace.WriteLine(HWresult[1].Text);
                                    Trace.WriteLine(HWresult[2].Text);
                                    Trace.WriteLine(HWresult[3].Text);

                                    inf.Add("내용 " + HWresult[0].Text);
                                    inf.Add("내용 " + HWresult[1].Text);
                                    inf.Add("내용 " + HWresult[2].Text);
                                    inf.Add("내용 " + HWresult[3].Text);

                                    j++;
                                    _driver.Navigate().Back(); // 페이지 뒤로가기
                                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
                                    HW = Find("동영상").ToArray();
                                    break;
                                }
                            }
                            _driver.Navigate().GoToUrl("https://open.yonsei.ac.kr/");

                            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

                            notice = _driver.FindElements(By.ClassName("close"));

                            notice[0].Click();

                            notice[1].Click();

                            list = _driver.FindElements(By.ClassName("course-box"));

                            l++;

                            break;
                        }
                    }
                }
                Trace.WriteLine("여기부터 시작");
                foreach (var a in inf)
                {
                    Trace.WriteLine(a);
                }
            }
            catch (Exception exc)
            {
                Trace.WriteLine(exc.Message);
            }
        }

    }
    public class login 
    {
        public static string ID;
        public static string PW;
    }
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}
