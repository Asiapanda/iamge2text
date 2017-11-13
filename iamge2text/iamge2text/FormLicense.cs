using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace iamge2text
{
    public partial class FormLicense : Form
    {

        /*
         * 开发思路：图片灰度处理，二进制，然后和图片中的字二进制库精确对比
         * 
         * 获取字库：通过下面代码中generateLicense(Bitmap singlepic)方法获得，具体操作：
         *      从图片中截图出（抠出）一个字符，然后处理得到二维的二进制矩阵，比如下面的字符1对应的二维矩阵
         *      00000
         *      00100
         *      11100
         *      00100
         *      00100
         *      00100
         *      00100
         *      00100
         *      00100
         *      11111
         *      00000
         *      00000
         *      
         * 注意：【相同字符，比如1，不同字体，字号，不同缩放大小的图片，获得到的二位矩阵中0、1排列和数量都是不同的！
         *          故按照此方法来写出匹配所有字的话，那字库就大了。。。】
         * 
         * 
        */
        public FormLicense()
        {
            InitializeComponent();
            buttonGenerate.Enabled = false;         //在pictureBox控件中无图片时buttonGenerate按钮不可用
            richTextBoxLicense.ReadOnly = true;     //并且不可以在文本框中改动输出后的字符
            this.AcceptButton = this.buttonOpen;    //回车键作用在打开按钮上
        }

        #region 在用的字符对应黑白颜色二进制码的字库,我的工具中只需要下面的几个字符,所有不是所有文字都能识别出来
        static string stringByte0 = "000000001100010010100001100001100001100001100001010010001100000000000000";
        static char[] char0 = stringByte0.ToCharArray();
        static int BinaryWidth0 = 5, BinaryHeight0 = 11;    //0的平面像素长宽(从0开始数起)

        static string stringByte1 = "000000010011100001000010000100001000010000100111110000000000";
        static char[] char1 = stringByte1.ToCharArray();
        static int BinaryWidth1 = 4, BinaryHeight1 = 11;    //1的平面像素长宽(从0开始数起)

        static string stringByte2 = "000000111010001100010000100010001000100010001111110000000000";
        static char[] char2 = stringByte2.ToCharArray();
        static int BinaryWidth2 = 4, BinaryHeight2 = 11;    //2的平面像素长宽(从0开始数起)

        static string stringByte3 = "000000111010001100010011000001000011000110001011100000000000";
        static char[] char3 = stringByte3.ToCharArray();
        static int BinaryWidth3 = 4, BinaryHeight3 = 11;    //3的平面像素长宽(从0开始数起)

        static string stringByte4 = "000010000010000110001010010010010010100010011111000010000111000000000000";
        static char[] char4 = stringByte4.ToCharArray();
        static int BinaryWidth4 = 5, BinaryHeight4 = 11;    //4的平面像素长宽(从0开始数起)

        static string stringByte5 = "000001111110000100001111010001000011000110001011100000000000";
        static char[] char5 = stringByte5.ToCharArray();
        static int BinaryWidth5 = 4, BinaryHeight5 = 11;    //5的平面像素长宽(从0开始数起)

        static string stringByte6 = "000000001111010001100000101110110001100001100001100001011110000000000000";
        static char[] char6 = stringByte6.ToCharArray();
        static int BinaryWidth6 = 5, BinaryHeight6 = 11;    //6的平面像素长宽(从0开始数起)

        static string stringByte7 = "000001111110001100100001000100001000010000100001000000000000";
        static char[] char7 = stringByte7.ToCharArray();
        static int BinaryWidth7 = 4, BinaryHeight7 = 11;    //7的平面像素长宽(从0开始数起)

        static string stringByte8 = "000000011110100001100001010010011110100001100001100001011110000000000000";
        static char[] char8 = stringByte8.ToCharArray();
        static int BinaryWidth8 = 5, BinaryHeight8 = 11;    //8的平面像素长宽(从0开始数起)

        static string stringByte9 = "000000011110100001100001100001100011011101000001100010111100000000000000";
        static char[] char9 = stringByte9.ToCharArray();
        static int BinaryWidth9 = 5, BinaryHeight9 = 11;    //9的平面像素长宽(从0开始数起)

        static string stringByteA = "000000000000000000000000011100100010001110010010100010011111000000000000";
        static char[] charA = stringByteA.ToCharArray();
        static int BinaryWidthA = 5, BinaryHeightA = 11;    //a的平面像素长宽(从0开始数起)

        static string stringByteB = "000000110000010000010000011110010001010001010001010001011110000000000000";
        static char[] charB = stringByteB.ToCharArray();
        static int BinaryWidthB = 5, BinaryHeightB = 11;    //b的平面像素长宽(从0开始数起)

        static string stringByteC = "000000000000000000000111110001100001000010001011100000000000";
        static char[] charC = stringByteC.ToCharArray();
        static int BinaryWidthC = 4, BinaryHeightC = 11;    //c的平面像素长宽(从0开始数起)

        static string stringByteD = "000000000110000010000010011110100010100010100010100010011111000000000000";
        static char[] charD = stringByteD.ToCharArray();
        static int BinaryWidthD = 5, BinaryHeightD = 11;    //d的平面像素长宽(从0开始数起)

        static string stringByteE = "000000000000000000000111010001111111000010001011100000000000";
        static char[] charE = stringByteE.ToCharArray();
        static int BinaryWidthE = 4, BinaryHeightE = 11;    //e的平面像素长宽(从0开始数起)

        static string stringByteF = "000000000111001001001000111110001000001000001000001000011110000000000000";
        static char[] charF = stringByteF.ToCharArray();
        static int BinaryWidthF = 5, BinaryHeightF = 11;    //f的平面像素长宽(从0开始数起)

        static string stringByteP = "000000000000000000000000111110010001010001010001010001011110010000111000";
        static char[] charP = stringByteP.ToCharArray();
        static int BinaryWidthP = 5, BinaryHeightP = 11;    //p的平面像素长宽(从0开始数起)

        static string stringByteY = "000000000000000000000000000011101110100010001010000101000001000000100000100001110000";
        static char[] charY = stringByteY.ToCharArray();
        static int BinaryWidthY = 6, BinaryHeightY = 11;    //y的平面像素长宽(从0开始数起)
        #endregion

        static int[,] intStartXY = new int[128, 3];    //记录匹配上时的“X坐标”和“Y坐标”对应的“值”以及该“字符像素的宽度”
        static int numIdentfied = 0;    //负责记录总共有多少匹配的字符

        //打开图片按钮
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap m_Bitmap;    //定义个Bitmap型变量存储图片
                OpenFileDialog openFileDialog = new OpenFileDialog();    //打开图片
                openFileDialog.Filter = "Bitmap文件(*.bmp)|*.bmp|Jpeg文件(*.jpg)|*.jpg|所有合适文件(*.bmp/*.jpg)|*.bmp/*.jpg";    //设置图片类型
                openFileDialog.FilterIndex = 1;    //打开对话框中默认第一个类型（即上面的Bitmap文件(*.bmp)|*.bmp）
                openFileDialog.RestoreDirectory = true;    //记录最后一次打开的文件路径
                if (DialogResult.OK == openFileDialog.ShowDialog())//确定打开文件
                {
                    m_Bitmap = (Bitmap)Bitmap.FromFile(openFileDialog.FileName, false);    //通过(Bitmap)将打开的图片类型转换
                    pictureBoxLicense.Image = m_Bitmap;    //为pictureBox控件加载所打开的图片
                    AutoScroll = true;
                    AutoScrollMinSize = new Size((int)(m_Bitmap.Width), (int)m_Bitmap.Height);
                    buttonGenerate.Enabled = true;    //在pictureBox控件中有图片时buttonGenerate按钮可用
                    this.buttonGenerate.Select();
                }
            }
            catch { }
        }

        //提取注册码按钮
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                buttonGenerate.Enabled = false;    //该图片只可进行一次提取，之后就不可用除非再加载该图片
                this.buttonOpen.Select();
                numIdentfied = 0;    //将计数器清零
                Bitmap Sourcebm = (Bitmap)pictureBoxLicense.Image;    //为了保险起见将pictureBox的图片类型进行格式转换(Bitmap)
                int iw = Sourcebm.Width;    //图片宽度  
                int ih = Sourcebm.Height;    //图片高度  
                //下面双循环是图片灰度处理  
                for (int i = 0; i < iw; i++)
                {//从左到右
                    for (int j = 0; j < ih; j++)
                    {//从上到下
                        Color c = Sourcebm.GetPixel(i, j);    //获取该点的颜色
                        int luma = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);    //将颜色转换为数值体现  
                        Sourcebm.SetPixel(i, j, Color.FromArgb(luma, luma, luma));    //将这一点进行灰度处理,非白色的部分变黑
                    }
                }
                generateLicense(Sourcebm);    //通过该方法进行提取字符
            }
            catch { }
        }

        /// <summary>
        /// 提取出该图片内的字符（将进过灰度处理的图片转化为0、1的二位数组）
        /// </summary>
        /// <param name="singlepic">图片来源</param>
        public void generateLicense(Bitmap singlepic)
        {
            try
            {
                char[,] charArray = new char[singlepic.Height, singlepic.Width];    //定义个chai型的二维数组记录每个像素上0/1的值,形成一个矩形
                int imageWidth = 0;    //记录图片的像素宽度
                int imageHeight = 0;    //记录图片的像素高度
                int dgGrayValue = 128;    //灰度值
                Color piexl;
                //string code = "";    //存储每个像素的0/1
                for (int posy = 0; posy < singlepic.Height; posy++)
                {//从上到下
                    string codeCache = "";    //存储每行的像素的0/1
                    for (int posx = 0; posx < singlepic.Width; posx++)
                    {//从左到右
                        piexl = singlepic.GetPixel(posx, posy);
                        if (piexl.R < dgGrayValue)    
                        {// 如果该像素的颜色为黑色,值就为“1”
                            codeCache = codeCache + "1";
                        }
                        else
                        {// 否则该像素的颜色为白色,值就为“0”
                            codeCache = codeCache + "0";                            
                        }
                    }
                    char[] array = codeCache.ToCharArray();    //每行的0/1的值用数字保存,以便于进行循环处理
                    //code += codeCache + "\n";
                    for (imageWidth = 0; imageWidth < array.Length; imageWidth++)
                        charArray[imageHeight, imageWidth] = array[imageWidth];    //通过循环将每行值转存到二维数组中
                    imageHeight++;
                }       //*********************以上代码可用来获取一个字的图片二进制数组，即字库*****************************

                //开始和字库进行匹配(我的工具中只需要下面的几个字符)
                findWord(charArray, char0, imageHeight, imageWidth, BinaryWidth0, BinaryHeight0, '0');
                findWord(charArray, char1, imageHeight, imageWidth, BinaryWidth1, BinaryHeight1, '1');
                findWord(charArray, char2, imageHeight, imageWidth, BinaryWidth2, BinaryHeight2, '2');
                findWord(charArray, char3, imageHeight, imageWidth, BinaryWidth3, BinaryHeight3, '3');
                findWord(charArray, char4, imageHeight, imageWidth, BinaryWidth4, BinaryHeight4, '4');
                findWord(charArray, char5, imageHeight, imageWidth, BinaryWidth5, BinaryHeight5, '5');
                findWord(charArray, char6, imageHeight, imageWidth, BinaryWidth6, BinaryHeight6, '6');
                findWord(charArray, char7, imageHeight, imageWidth, BinaryWidth7, BinaryHeight7, '7');
                findWord(charArray, char8, imageHeight, imageWidth, BinaryWidth8, BinaryHeight8, '8');
                findWord(charArray, char9, imageHeight, imageWidth, BinaryWidth9, BinaryHeight9, '9');
                findWord(charArray, charA, imageHeight, imageWidth, BinaryWidthA, BinaryHeightA, 'a');
                findWord(charArray, charB, imageHeight, imageWidth, BinaryWidthB, BinaryHeightB, 'b');
                findWord(charArray, charC, imageHeight, imageWidth, BinaryWidthC, BinaryHeightC, 'c');
                findWord(charArray, charD, imageHeight, imageWidth, BinaryWidthD, BinaryHeightD, 'd');
                findWord(charArray, charE, imageHeight, imageWidth, BinaryWidthE, BinaryHeightE, 'e');
                findWord(charArray, charF, imageHeight, imageWidth, BinaryWidthF, BinaryHeightF, 'f');
                findWord(charArray, charP, imageHeight, imageWidth, BinaryWidthP, BinaryHeightP, 'p');
                findWord(charArray, charY, imageHeight, imageWidth, BinaryWidthY, BinaryHeightY, 'y');
                //------------------------------------END---------------------------------------------
                richTextBoxLicense.Text += identifySort();    //执行identifySort方法，将我需要的格式在richTextBoxLicense文本框中显示
                richTextBoxLicense.SelectionStart = richTextBoxLicense.TextLength;    //将光标移到最后面
            }
            catch { }
        }

        /// <summary>
        /// 和字库进行匹配
        /// </summary>
        /// <param name="charArray">记录图片中每个像素的二维数组</param>
        /// <param name="charNum">字库中0/1值一维数组形式的字符</param>
        /// <param name="imageHeight">图片的像素高度</param>
        /// <param name="imageWidth">图片的像素宽度</param>
        /// <param name="binaryWidth">字库中该字符的像素宽度</param>
        /// <param name="binaryHeight">字库中该字符的像素高度</param>
        /// <param name="stringChar">字库中该字符</param>
        public void findWord(char[,] charArray, char[] charNum, int imageHeight, int imageWidth, int binaryWidth, int binaryHeight, char stringChar)
        {
            try
            {
                int upLeftX, upLeftY, x, y;
                for (y = 0; y < imageHeight - binaryHeight; y++)//从图片的每行开始
                {
                    for (x = 0; x < imageWidth - binaryWidth; x++)//从当前行的第一格开始
                    {
                        bool isIdentified = false;    //负责辨别是否匹配
                        int count = 0;    //负责计数
                        for (upLeftY = 0; upLeftY <= binaryHeight; upLeftY++)//从图片中取出一块进行对比，从的每行开始
                        {
                            for (upLeftX = 0; upLeftX <= binaryWidth; upLeftX++)//从这一块当前行的第一格开始
                            {
                                //下面进行每格的对比，大数字去除的“块”是二维数组，小数组是一维数组
                                if (charArray[y + upLeftY, x + upLeftX] == charNum[upLeftY * (binaryWidth + 1) + upLeftX])
                                {
                                    isIdentified = true;    //记录像素点是否比对成功
                                    count++;
                                    if (count == (binaryWidth + 1) * (binaryHeight + 1))//判断是否对比到了最后一个像素点
                                    {
                                        intStartXY[numIdentfied, 0] = y;    //记录字库中该字符在图片中出现的Y值
                                        intStartXY[numIdentfied, 1] = x;    //记录字库中该字符在图片中出现的X值
                                        intStartXY[numIdentfied, 2] = Convert.ToInt32(stringChar);    //将该字符转换为数字型
                                        numIdentfied++;    //记录图片中总共多少个字库中的数字
                                        break;    //一旦匹配即将结束比对
                                    }
                                }
                                else
                                {
                                    isIdentified = false;    //此像素点比对不成功
                                    break;    //如果该像素点值比对不成功即将结束比对
                                }
                            }
                            if (!isIdentified)//如果一个不符就向后退一格，同时小数组的比对又需要从第一格开始
                                break;    //并且结束这次的比对
                        }
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 对比对后的结果通过坐标进行排序
        /// </summary>
        /// <returns>提取出的图片中的字符串</returns>
        public string identifySort()
        {
            string stringLicense = "";    //存储该结果
            try
            {
                int intTemp = 0;
                for (int a = 0; a < numIdentfied; a++)
                {//从第一列开始
                    for (int b = 0; b < numIdentfied; b++)
                    {//然后从该列中第一行开始对比
                        if (intStartXY[a, 0] < intStartXY[b, 0])
                        {//通过Y坐标（离顶端距离）判断那个字符在上面,并进行对调
                            for (int c = 0; c < 3; c++)
                            {
                                intTemp = intStartXY[a, c];
                                intStartXY[a, c] = intStartXY[b, c];
                                intStartXY[b, c] = intTemp;
                            }
                        }
                        if (intStartXY[a, 0] == intStartXY[b, 0] && intStartXY[a, 1] < intStartXY[b, 1])
                        {//当Y坐标（离顶端距离）相同时,通过X坐标（离左端距离）判断那个字符在左面,并进行对调
                            for (int c = 0; c < 3; c++)
                            {
                                intTemp = intStartXY[a, c];
                                intStartXY[a, c] = intStartXY[b, c];
                                intStartXY[b, c] = intTemp;
                            }
                        }
                    }
                }

                //------------------------下面是我需要的格式-------------------------------------------------------------
                /*
                    yp_12_125
                    yp_12_125
                    e4ebf340-563b5e1c-b04957df-baacc576
                 */
                for (int h = 0; h < numIdentfied; h++)
                {
                    stringLicense += Convert.ToChar(intStartXY[h, 2]);
                    if ((intStartXY[h + 1, 0] == intStartXY[h, 0] && intStartXY[h + 1, 1] - intStartXY[h, 1] >= 12 && h < numIdentfied - 32))
                        stringLicense += "_";    //当同一行时，相差一个下划线距离就显示下划线_
                    if (intStartXY[h + 1, 0] - intStartXY[h, 0] >= 11 && h < numIdentfied - 17)
                        stringLicense += "\n";    //当不上一行时就输出\n
                    if (h == numIdentfied - 25 || h == numIdentfied - 17 || h == numIdentfied - 9)
                        stringLicense += "-";    //每8个显示一个中划线-
                }
                //---------------------------------------END---------------------------------------------------------------------------------
            }
            catch { }
            return stringLicense + "\n";    //对返回的结果进行换行,保证在richTextBox文本框显示的时候光标始终在下行
        }

        private void pictureBoxLicense_DoubleClick(object sender, EventArgs e)
        {//通过双击控件粘贴图片
            try
            {
                IDataObject iData = Clipboard.GetDataObject();    //GetDataObject检索当前剪贴板上的数据            
                if (iData.GetDataPresent(DataFormats.Bitmap))//将数据与指定的格式进行匹配
                {
                    // GetData检索数据并指定一个格式
                    Bitmap bitmapLicense = (Bitmap)iData.GetData(DataFormats.Bitmap);
                    pictureBoxLicense.Image = bitmapLicense;    //加载截屏后的图片
                    buttonGenerate.Enabled = true;    //pictureBox中新图片时提取按钮便可使用
                    this.buttonGenerate.Select();
                }
                else
                {
                    MessageBox.Show("目前剪贴板中数据不是图片\n   请先截图再双击此处!", "Error");
                }
            }
            catch { }
        }
    }
}