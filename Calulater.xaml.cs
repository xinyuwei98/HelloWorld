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
using System.Windows.Shapes;

namespace Calculater
{
    /// <summary>
    /// Calulater.xaml 的交互逻辑
    /// </summary>
    public partial class Calulater : Window
    {
        public Calulater()
        {
            InitializeComponent();
        }

        bool isInput = false;//普通数字的输入,false，运算符的输入，true
        int addTime = 0;//计算输入的运算符的次数，一次只能输入一个运算符进行计算
        double temp1 = 0;//正负数切换变量
        int point = 0;//用来判断输入的小数点个数，只能输入一个小数点
        double mediaResult = 0;//存放数据的中间值


        //左侧菜单栏点击事件，显示和隐藏
        private void Bu1_Click(object sender, RoutedEventArgs e)
        {
            if (myPopup.IsOpen == false)
            {
                myPopup.IsOpen = true;
            }
            else if (myPopup.IsOpen == true)
            {
                myPopup.IsOpen = false;
            }
        }

        public void AddNumber(Button btn)
        {
            addTime = 0;
            //如果是输入了运算符号的输入
            if (isInput)
            {
                Content.Text = (string)btn.Content;
                isInput = false;
            }
            //没有输入运算符号的时候随便输入的数字
            else
            {
                if (Content.Text == "0")
                {
                    //如果没有输入，则让当前点击按钮数字到大数字框中
                    Content.Text = (string)btn.Content;
                }
                else if (Content.Text.Length > 8)
                {
                    //如果超出输入长度，则不再进行输入
                    return;
                }
                else
                {
                    //如果没有超出输入长度，则让输入依次加载到输入框中
                    Content.Text += btn.Content;
                }
            }
        }//添加数字

        // 数字 7
        private void Bu4_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(bu4);
        }

        // 数字 8
        private void Bu10_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(bu10);
        }

        // 数字 9
        private void Bu16_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(bu16);
        }

        // 数字 4
        private void Bu5_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(bu5);
        }

        // 数字 5
        private void Bu11_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(bu11);
        }

        // 数字 6
        private void Bu17_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(bu17);
        }

        // 数字 1
        private void Bu6_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(bu6);
        }

        // 数字 2
        private void Bu12_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(bu12);
        }

        // 数字 3
        private void Bu18_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(bu18);
        }

        // 数字 0
        private void Bu13_Click(object sender, RoutedEventArgs e)
        {
            AddNumber(bu13);
        }

        // 退格
        private void Bu15_Click(object sender, RoutedEventArgs e)
        {
            //在数字按钮被点击之后，退格删除末端的一个数字
            if (Content.Text.Length > 1)
            {
                string str = "";
                for (int i = 0; i < Content.Text.Length - 1; i++)
                {
                    str += Content.Text[i];
                }
                Content.Text = str;
            }
            else
            {
                Content.Text = "0";
                point = 0;
            }
        }

        // CE 清除输入的数字
        private void Bu3_Click(object sender, RoutedEventArgs e)
        {
            //点击清除所有输入的数字
            Content.Text = "0";
            point = 0;
            temp1 = 0;

        }

        // C ,全部清除，包括大数字输入栏和小数字
        private void Bu9_Click(object sender, RoutedEventArgs e)
        {
            MediaResult.Content = "";
            Content.Text = "0";
            point = 0;
            temp1 = 0;
            addTime = 0;
            isInput = false;//清除按钮不算运算符
            mediaResult = 0;
            operaTionNumber = 0;
            temp = 0;
            mediaResult1 = 0;
            firstNumber = 0;
            Array.Clear(operationArray1, 0, operationArray1.Length);
            opeNumber = 0;
        }


        // ± 号
        private void Bu7_Click(object sender, RoutedEventArgs e)
        {
            //让double类型的变量被赋值
            temp1 = Convert.ToDouble(Content.Text);

            //点击该按钮，将正数改成负数，将负数改成正数
            if (Content.Text == "0")
            {
                //如果等于0
                MediaResult.Content = "negate(0)";
            }
            else
            {
                //如果大于0，改为负号,如果小于0，改为正号
                temp1 = -temp1;
                Content.Text = Convert.ToString(temp1);
            }
            return;
        }


        //小数点.
        private void Bu19_Click(object sender, RoutedEventArgs e)
        {
            //在输入运算符之后直接输入小数点的话代表是零点几
            if (isInput)
            {
                Content.Text = "0";
                isInput = false;
            }
            //输入的数只能加一个小数点
            if (point == 0)
            {
                Content.Text = Content.Text + ".";
                point++;
            }
            else
            {
                return;
            }
        }


        // + 号
        private void Bu24_Click(object sender, RoutedEventArgs e)
        {
            MathOperation("+");
        }


        // - 号
        private void Bu23_Click(object sender, RoutedEventArgs e)
        {
            MathOperation("-");
        }



        // 乘 号 X
        private void Bu22_Click(object sender, RoutedEventArgs e)
        {
            MathOperation("*");
        }

        // 除 号 /
        private void Bu21_Click(object sender, RoutedEventArgs e)
        {
            MathOperation("÷");
        }

        // 取余 %
        private void Bu2_Click(object sender, RoutedEventArgs e)
        {
            MathOperation("%");
        }

        // 等于 =
        int first = 0;//用于判断是不是第一次输入等号，如果是的话，清空右边文本框
        private void Bu25_Click(object sender, RoutedEventArgs e)
        {
            MathOperation("=");
            if (first == 0)
            {
                ResultLabel.Text = "";
                showbutton.Visibility = Visibility.Visible;
                first++;
            }


            string str = MediaResult.Content + "";
            Label la = new Label();
            Label la1 = new Label();
            la.Content = str;
            la1.Content = Content.Text;
            ResultLabel.Text += str + "\n";
            ResultLabel.Text += la1.Content + "\n";
            ResultLabel.Text += "\n";



            //更新输入
            MediaResult.Content = null;
            operaTionNumber = 0;
            point = 0;
            temp1 = 0;
            addTime = 0;
            mediaResult = 0;
            temp = 0;
            mediaResult1 = 0;
            firstNumber = 0;
            Array.Clear(operationArray1, 0, operationArray1.Length);
            opeNumber = 0;
        }

        // 平方 
        private void Bu14_Click(object sender, RoutedEventArgs e)
        {
            MathOperation("X²");
        }

        // 开根号 
        private void Bu8_Click(object sender, RoutedEventArgs e)
        {
            double number = Convert.ToDouble(Content.Text);
            MediaResult.Content = "√(" + number + ")";
            if (number < 0)
            {
                Content.Text = "无效输入";
                return;
            }
            double b;
            b = Math.Sqrt(number);
            Content.Text = Convert.ToString(b);
        }

        // 除以当前数字
        private void Bu20_Click(object sender, RoutedEventArgs e)
        {
            MathOperation("1/X");
        }


        // 删除右侧文本
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Text = "尚无历史记录";
            showbutton.Visibility = Visibility.Hidden;
        }



        int operaTionNumber = 0;//判断是不是第一个出现的运算符
        int temp = 0;//使用temp来判断当前输入的式子的位数
        string firstOperation = "";//第一次输入的符号
        double firstNumber = 0;//第一次输入的数字  
        double mediaResult1 = 0;//中间数字
        string[] operationArray1 = new string[20];
        int opeNumber = 0;
        public void MathOperation2()
        {
            if (addTime == 0)
            {
                double nowNumber = Convert.ToDouble(Content.Text);//获取当前输入的数字
                //输入完一个数字加一个运算符加一个数字的组合后，输入另一个运算符，先运算前面的表达式，运算结果再跟后面进行计算
                //重复这个操作，进行多元运算
                //如果是第一个输入的运算符，则先不进行运算，等第二个再进行运算
                char[] operaTionArray = Convert.ToString(MediaResult.Content).ToCharArray();//将字符串分割成char类型数组
                for (int i = temp; i < operaTionArray.Length; i++)
                {
                    if (operaTionArray[i] == '+' || operaTionArray[i] == '-' || operaTionArray[i] == '*' || operaTionArray[i] == '÷')
                    {
                        temp = i + 1;//使用temp判断当前式子进展，将之前的值保留就可以
                        operaTionNumber++;
                        if (operaTionNumber == 1)//第一次出现运算符
                        {
                            //MessageBox.Show("第一次出现运算符，符号是" + operaTionArray[i]);
                            firstOperation = operaTionArray[i] + "";
                            firstNumber = Convert.ToDouble(Content.Text);
                            break;
                        }
                        else if (operaTionNumber == 2)
                        {                            
                            operationArray1[opeNumber] = operaTionArray[i] +"";
                            switch (firstOperation)
                            {
                                case "+":
                                    mediaResult1 = firstNumber + Convert.ToDouble(Content.Text);//中间数字等于第一个输入的数加上第二个输入的数字
                                    Content.Text = mediaResult1 + "";
                                    break;
                                case "-":
                                    mediaResult1 = firstNumber - Convert.ToDouble(Content.Text);//中间数字等于第一个输入的数减去第二个输入的数字
                                    Content.Text = mediaResult1 + "";
                                    break;
                                case "*":
                                    mediaResult1 = firstNumber * Convert.ToDouble(Content.Text);//中间数字等于第一个输入的数乘上第二个输入的数字
                                    Content.Text = mediaResult1 + "";
                                    break;
                                case "÷":
                                    mediaResult1 = firstNumber / Convert.ToDouble(Content.Text);//中间数字等于第一个输入的数除以+第二个输入的数字
                                    Content.Text = mediaResult1 + "";
                                    break;
                            }
                        }
                        else if (operaTionNumber > 2)
                        {
                            //MessageBox.Show("第" + operaTionNumber + "个运算符是" + operaTionArray[i]);
                            opeNumber++;
                            operationArray1[opeNumber] = operaTionArray[i] + "";
                            for (; opeNumber < 20;)
                            {
                                switch (operationArray1[opeNumber])
                                {
                                    case "+":
                                        mediaResult1 = mediaResult1 + Convert.ToDouble(Content.Text);//中间数字等于第一个输入的数加上第二个输入的数字
                                        Content.Text = mediaResult1 + "";
                                        break;
                                    case "-":
                                        mediaResult1 = mediaResult1 - Convert.ToDouble(Content.Text);//中间数字等于第一个输入的数减去第二个输入的数字
                                        Content.Text = mediaResult1 + "";
                                        break;
                                    case "*":
                                        mediaResult1 = mediaResult1 * Convert.ToDouble(Content.Text);//中间数字等于第一个输入的数乘上第二个输入的数字
                                        Content.Text = mediaResult1 + "";
                                        break;
                                    case "÷":
                                        mediaResult1 = mediaResult1 / Convert.ToDouble(Content.Text);//中间数字等于第一个输入的数除以+第二个输入的数字
                                        Content.Text = mediaResult1 + "";
                                        break;
                                }
                                break;
                            }

                        }
                    }

                }
            }
            addTime++;
        }
















        bool isAddOperation = true;//是否按模板添加符号，不同的符号有不同的情况
        public void MathOperation(string symbol)
        {

            if (addTime == 0)
            {
                point = 0;
                try
                {
                    double a = Convert.ToDouble(Content.Text);//输入的数字

                    if (isAddOperation)
                    {
                        if (Convert.ToString(MediaResult.Content).Contains("√"))
                        { }
                        else
                        {
                            MediaResult.Content += Content.Text + symbol;//输入的时候按照 数字 + 运算符 的形式输入
                        }
                    }
                    switch (symbol)
                    {
                        case "+":
                            //MathOperation2();
                            mediaResult += a;
                            Content.Text = Convert.ToString(mediaResult);

                            break;
                        case "-":
                            //MathOperation2();
                            if (mediaResult == 0)
                            {
                                mediaResult = a;
                                break;
                            }

                            mediaResult -= a;
                            Content.Text = Convert.ToString(mediaResult);

                            break;
                        case "*":
                            //MathOperation2();
                            if (mediaResult == 0)//当前输入是第一次输入
                            {
                                mediaResult = a;
                                break;
                            }
                            mediaResult *= a;
                            Content.Text = Convert.ToString(mediaResult);

                            break;
                        case "÷":
                            //MathOperation2();
                            if (mediaResult == 0)
                            {
                                mediaResult = a;
                                break;
                            }
                            if (a == 0)
                            {
                                Content.Text = "除数不可以为0";
                                MediaResult.Content = null;
                                break;
                            }
                            mediaResult /= a;
                            Content.Text = Convert.ToString(mediaResult);

                            break;
                        case "%":
                            if (mediaResult == 0)//当前输入是第一次输入
                            {
                                mediaResult = a;
                                break;
                            }
                            mediaResult %= a;
                            Content.Text = Convert.ToString(mediaResult);
                            break;
                        case "=":
                            isAddOperation = false;
                            if (Convert.ToString(MediaResult.Content).Contains("+"))
                            {
                                MathOperation("+");
                            }
                            else if (Convert.ToString(MediaResult.Content).Contains("-"))
                            {
                                MathOperation("-");
                            }
                            else if (Convert.ToString(MediaResult.Content).Contains("*"))
                            {
                                MathOperation("*");
                            }
                            else if (Convert.ToString(MediaResult.Content).Contains("÷"))
                            {
                                MathOperation("÷");
                            }
                            else if (Convert.ToString(MediaResult.Content).Contains("%"))
                            {
                                MathOperation("%");
                            }
                            else if (Convert.ToString(MediaResult.Content).Contains("X²"))
                            {
                                MathOperation("X²");
                            }
                            else if (Convert.ToString(MediaResult.Content).Contains("1/X"))
                            {
                                MathOperation("1/X");
                            }
                            isAddOperation = true;
                            break;
                        case "X²":
                            mediaResult = a;
                            MediaResult.Content = "sqr(" + mediaResult + ")";
                            Content.Text = Convert.ToString(Math.Pow(mediaResult, 2));
                            mediaResult = 0;
                            break;
                        case "1/X":
                            mediaResult = a;
                            MediaResult.Content = 1 + "/" + mediaResult;
                            Content.Text = Convert.ToString(1 / mediaResult);
                            mediaResult = 0;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Content.Text = "0";
                    MediaResult.Content = null;
                }
                addTime++;
                isInput = true;
            }
        }//运算符运算



    }
}
