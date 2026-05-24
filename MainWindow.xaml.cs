using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace RGB2Index
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		/// <summary>
		/// RGB/Index 色值对应表
		/// </summary>
		private Dictionary<int, int[]> ColorPalette = new Dictionary<int, int[]>()
		{
			{1, new int[]{255, 0, 0}},
			{2, new int[]{255, 255, 0}},
			{3, new int[]{0, 255, 0}},
			{4, new int[]{0, 255, 255}},
			{5, new int[]{0, 0, 255}},
			{6, new int[]{255, 0, 255}},
			{7, new int[]{255, 255, 255}},
			{8, new int[]{128, 128, 128}},
			{9, new int[]{192, 192, 192}},
			{11, new int[]{255, 127, 127}},
			{12, new int[]{165, 0, 0}},
			{13, new int[]{165, 82, 82}},
			{14, new int[]{127, 0, 0}},
			{15, new int[]{127, 63, 63}},
			{16, new int[]{76, 0, 0}},
			{17, new int[]{76, 38, 38}},
			{18, new int[]{38, 0, 0}},
			{19, new int[]{38, 19, 19}},
			{20, new int[]{255, 63, 0}},
			{21, new int[]{255, 159, 127}},
			{22, new int[]{165, 41, 0}},
			{23, new int[]{165, 107, 82}},
			{24, new int[]{127, 31, 0}},
			{25, new int[]{127, 79, 63}},
			{26, new int[]{76, 19, 0}},
			{27, new int[]{76, 47, 38}},
			{28, new int[]{38, 9, 0}},
			{29, new int[]{38, 23, 19}},
			{30, new int[]{255, 127, 0}},
			{31, new int[]{255, 191, 127}},
			{32, new int[]{165, 82, 0}},
			{33, new int[]{165, 124, 82}},
			{34, new int[]{127, 63, 0}},
			{35, new int[]{127, 95, 63}},
			{36, new int[]{76, 38, 0}},
			{37, new int[]{76, 57, 38}},
			{38, new int[]{38, 19, 0}},
			{39, new int[]{38, 28, 19}},
			{40, new int[]{255, 191, 0}},
			{41, new int[]{255, 223, 127}},
			{42, new int[]{165, 124, 0}},
			{43, new int[]{165, 145, 82}},
			{44, new int[]{127, 95, 0}},
			{45, new int[]{127, 111, 63}},
			{46, new int[]{76, 57, 0}},
			{47, new int[]{76, 66, 38}},
			{48, new int[]{38, 28, 0}},
			{49, new int[]{38, 33, 19}},
			{51, new int[]{255, 255, 127}},
			{52, new int[]{165, 165, 0}},
			{53, new int[]{165, 165, 82}},
			{54, new int[]{127, 127, 0}},
			{55, new int[]{127, 127, 63}},
			{56, new int[]{76, 76, 0}},
			{57, new int[]{76, 76, 38}},
			{58, new int[]{38, 38, 0}},
			{59, new int[]{38, 38, 19}},
			{60, new int[]{191, 255, 0}},
			{61, new int[]{223, 255, 127}},
			{62, new int[]{124, 165, 0}},
			{63, new int[]{145, 165, 82}},
			{64, new int[]{95, 127, 0}},
			{65, new int[]{111, 127, 63}},
			{66, new int[]{57, 76, 0}},
			{67, new int[]{66, 76, 38}},
			{68, new int[]{28, 38, 0}},
			{69, new int[]{33, 38, 19}},
			{70, new int[]{127, 255, 0}},
			{71, new int[]{191, 255, 127}},
			{72, new int[]{82, 165, 0}},
			{73, new int[]{124, 165, 82}},
			{74, new int[]{63, 127, 0}},
			{75, new int[]{95, 127, 63}},
			{76, new int[]{38, 76, 0}},
			{77, new int[]{57, 76, 38}},
			{78, new int[]{19, 38, 0}},
			{79, new int[]{28, 38, 19}},
			{80, new int[]{63, 255, 0}},
			{81, new int[]{159, 255, 127}},
			{82, new int[]{41, 165, 0}},
			{83, new int[]{103, 165, 82}},
			{84, new int[]{31, 127, 0}},
			{85, new int[]{79, 127, 63}},
			{86, new int[]{19, 76, 0}},
			{87, new int[]{47, 76, 38}},
			{88, new int[]{9, 38, 0}},
			{89, new int[]{23, 38, 19}},
			{91, new int[]{127, 255, 127}},
			{92, new int[]{0, 165, 0}},
			{93, new int[]{82, 165, 82}},
			{94, new int[]{0, 127, 0}},
			{95, new int[]{63, 127, 63}},
			{96, new int[]{0, 76, 0}},
			{97, new int[]{38, 76, 38}},
			{98, new int[]{0, 38, 0}},
			{99, new int[]{19, 38, 19}},
			{100, new int[]{0, 255, 63}},
			{101, new int[]{127, 255, 159}},
			{102, new int[]{0, 165, 41}},
			{103, new int[]{82, 165, 103}},
			{104, new int[]{0, 127, 31}},
			{105, new int[]{63, 127, 79}},
			{106, new int[]{0, 76, 19}},
			{107, new int[]{38, 76, 47}},
			{108, new int[]{0, 38, 9}},
			{109, new int[]{19, 88, 23}},
			{110, new int[]{0, 255, 127}},
			{111, new int[]{127, 255, 191}},
			{112, new int[]{0, 165, 82}},
			{113, new int[]{82, 165, 124}},
			{114, new int[]{0, 127, 63}},
			{115, new int[]{63, 127, 95}},
			{116, new int[]{0, 76, 38}},
			{117, new int[]{38, 76, 57}},
			{118, new int[]{0, 38, 19}},
			{119, new int[]{19, 88, 28}},
			{120, new int[]{0, 255, 191}},
			{121, new int[]{127, 255, 223}},
			{122, new int[]{0, 165, 124}},
			{123, new int[]{82, 165, 145}},
			{124, new int[]{0, 127, 95}},
			{125, new int[]{63, 127, 111}},
			{126, new int[]{0, 76, 57}},
			{127, new int[]{38, 76, 66}},
			{128, new int[]{0, 38, 28}},
			{129, new int[]{19, 88, 88}},
			{131, new int[]{127, 255, 255}},
			{132, new int[]{0, 165, 165}},
			{133, new int[]{82, 165, 165}},
			{134, new int[]{0, 127, 127}},
			{135, new int[]{63, 127, 127}},
			{136, new int[]{0, 76, 76}},
			{137, new int[]{38, 76, 76}},
			{138, new int[]{0, 38, 38}},
			{139, new int[]{19, 88, 88}},
			{140, new int[]{0, 191, 255}},
			{141, new int[]{127, 223, 255}},
			{142, new int[]{0, 124, 165}},
			{143, new int[]{82, 145, 165}},
			{144, new int[]{0, 95, 127}},
			{145, new int[]{63, 111, 127}},
			{146, new int[]{0, 57, 76}},
			{147, new int[]{38, 66, 126}},
			{148, new int[]{0, 28, 38}},
			{149, new int[]{19, 88, 88}},
			{150, new int[]{0, 127, 255}},
			{151, new int[]{127, 191, 255}},
			{152, new int[]{0, 82, 165}},
			{153, new int[]{82, 124, 165}},
			{154, new int[]{0, 63, 127}},
			{155, new int[]{63, 195, 127}},
			{156, new int[]{0, 38, 76}},
			{157, new int[]{38, 57, 126}},
			{158, new int[]{0, 19, 38}},
			{159, new int[]{19, 28, 88}},
			{160, new int[]{0, 63, 255}},
			{161, new int[]{127, 159, 255}},
			{162, new int[]{0, 41, 165}},
			{163, new int[]{82, 103, 165}},
			{164, new int[]{0, 31, 127}},
			{165, new int[]{63, 79, 127}},
			{166, new int[]{0, 19, 76}},
			{167, new int[]{38, 47, 126}},
			{168, new int[]{0, 9, 38}},
			{169, new int[]{19, 23, 88}},
			{171, new int[]{127, 127, 255}},
			{172, new int[]{0, 0, 165}},
			{173, new int[]{82, 82, 165}},
			{174, new int[]{0, 0, 127}},
			{175, new int[]{63, 63, 127}},
			{176, new int[]{0, 0, 76}},
			{177, new int[]{38, 38, 126}},
			{178, new int[]{0, 0, 38}},
			{179, new int[]{19, 19, 88}},
			{180, new int[]{63, 0, 255}},
			{181, new int[]{159, 127, 255}},
			{182, new int[]{41, 0, 165}},
			{183, new int[]{103, 82, 165}},
			{184, new int[]{31, 0, 127}},
			{185, new int[]{79, 63, 127}},
			{186, new int[]{19, 0, 76}},
			{187, new int[]{47, 38, 126}},
			{188, new int[]{9, 0, 38}},
			{189, new int[]{23, 19, 88}},
			{190, new int[]{127, 0, 255}},
			{191, new int[]{191, 127, 255}},
			{192, new int[]{82, 0, 165}},
			{193, new int[]{124, 82, 165}},
			{194, new int[]{63, 0, 127}},
			{195, new int[]{95, 63, 127}},
			{196, new int[]{38, 0, 76}},
			{197, new int[]{57, 38, 126}},
			{198, new int[]{19, 0, 38}},
			{199, new int[]{28, 19, 88}},
			{200, new int[]{191, 0, 255}},
			{201, new int[]{223, 127, 255}},
			{202, new int[]{124, 0, 165}},
			{203, new int[]{145, 82, 165}},
			{204, new int[]{95, 0, 127}},
			{205, new int[]{111, 63, 127}},
			{206, new int[]{57, 0, 76}},
			{207, new int[]{66, 38, 76}},
			{208, new int[]{28, 0, 38}},
			{209, new int[]{88, 19, 88}},
			{211, new int[]{255, 127, 255}},
			{212, new int[]{165, 0, 165}},
			{213, new int[]{165, 82, 165}},
			{214, new int[]{127, 0, 127}},
			{215, new int[]{127, 63, 127}},
			{216, new int[]{76, 0, 76}},
			{217, new int[]{76, 38, 76}},
			{218, new int[]{38, 0, 38}},
			{219, new int[]{88, 19, 88}},
			{220, new int[]{225, 0, 191}},
			{221, new int[]{255, 127, 223}},
			{222, new int[]{165, 0, 124}},
			{223, new int[]{165, 82, 145}},
			{224, new int[]{127, 0, 95}},
			{225, new int[]{127, 63, 111}},
			{226, new int[]{76, 0, 57}},
			{227, new int[]{76, 38, 66}},
			{228, new int[]{38, 0, 27}},
			{229, new int[]{88, 19, 88}},
			{230, new int[]{255, 0, 127}},
			{231, new int[]{255, 127, 191}},
			{232, new int[]{165, 0, 82}},
			{233, new int[]{165, 82, 124}},
			{234, new int[]{127, 0, 63}},
			{235, new int[]{127, 63, 95}},
			{236, new int[]{76, 0, 38}},
			{237, new int[]{76, 38, 57}},
			{238, new int[]{38, 0, 19}},
			{239, new int[]{88, 19, 28}},
			{240, new int[]{255, 0, 63}},
			{241, new int[]{255, 127, 159}},
			{242, new int[]{165, 0, 41}},
			{243, new int[]{165, 82, 103}},
			{244, new int[]{127, 0, 31}},
			{245, new int[]{127, 63, 79}},
			{246, new int[]{76, 0, 19}},
			{247, new int[]{76, 38, 47}},
			{248, new int[]{38, 0, 9}},
			{249, new int[]{88, 19, 23}},
			{250, new int[]{0, 0, 0}},
			{251, new int[]{101, 101, 101}},
			{252, new int[]{102, 102, 102}},
			{253, new int[]{153, 153, 153}},
			{254, new int[]{204, 204, 204}},
			{255, new int[]{255, 255, 255}},
			{256, new int[]{0, 0, 0}}
		};
		private int[] RGB_Input = new int[] { };
		public MainWindow()
		{
			InitializeComponent();
		}
		//暂无用户输入RGB值的格式正确判断
		private void confirm_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				RGB_Input = new int[] { int.Parse(RGB_R.Text), int.Parse(RGB_G.Text), int.Parse(RGB_B.Text) };
				var result = FindNearestColor(ColorPalette, RGB_Input);
				SameOrSimilar.Text = result[1] == 0 ? "等于" : "相似";
				RecRGB.Visibility = Visibility.Visible;
				RecIndex.Visibility = Visibility.Visible;
				RecRGB_Num.Visibility = Visibility.Visible;
				RecIndex_Num.Visibility = Visibility.Visible;
				RecRGB_Num.Text = RGB_R.Text + "," + RGB_G.Text + "," + RGB_B.Text;
				RecIndex_Num.Text = ColorPalette[(int)result[0]][0] + ","
					+ ColorPalette[(int)result[0]][1] + "," + ColorPalette[(int)result[0]][2];
				RecRGB.Fill = new SolidColorBrush(Color.FromRgb(byte.Parse(RGB_R.Text), byte.Parse(RGB_G.Text), byte.Parse(RGB_B.Text)));
				RecIndex.Fill = new SolidColorBrush(Color.FromRgb((byte)ColorPalette[(int)result[0]][0],
					(byte)ColorPalette[(int)result[0]][1], (byte)ColorPalette[(int)result[0]][2]));
				if (result[1] == 0)
				{
					SameOrSimilar.Text = "等于";
					SameOrSimilar.Foreground = Brushes.Black;
				}
				else
				{
					SameOrSimilar.Text = "相似";
					SameOrSimilar.Foreground = Brushes.DarkGray;
				}
				IndexNum.Text = result[0].ToString();
			}
			catch (Exception)
			{
				MessageBox.Show("请正确填写真彩色的RGB值！");
			}
		}

		/// <summary>
		/// 寻找真彩色最近的索引色，[0]是索引色值，[1]是欧式距离值
		/// </summary>
		/// <param name="colorPalette">真彩色对索引色映射</param>
		/// <param name="rgbColor">待转换颜色-真彩色</param>
		/// <returns></returns>
		public double[] FindNearestColor(Dictionary<int, int[]> colorPalette, int[] rgbColor)
		{
			var result = new double[2]{0,0};
			int nearestColor = 0;
			double nearestDistance = double.MaxValue;

			foreach (var entry in colorPalette)
			{
				double distance = Math.Pow(entry.Value[0] - rgbColor[0], 2) +
								  Math.Pow(entry.Value[1] - rgbColor[1], 2) +
								  Math.Pow(entry.Value[2] - rgbColor[2], 2);

				if (distance < nearestDistance)
				{
					nearestDistance = distance;
					nearestColor = entry.Key;
					result[0] = nearestColor;
					result[1] = distance;
				}
			}
			if (!colorPalette.ContainsKey(nearestColor))
			{
				MessageBox.Show("返回值不在字典中", "错误提示");
			}
			return result;
		}
		private void RGB_GotFocus(object sender, RoutedEventArgs e)
		{
			(sender as TextBox).SelectAll();
		}

	}
}
