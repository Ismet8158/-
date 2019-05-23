using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаб2_СиТ
{
    public partial class Form2 : Form
    {
        public Form2(double[] K1, double K2, int N, double L)
        {
            InitializeComponent();
            TotalInvestChart.Series[0].Points.Clear();
            SpecInvestChart.Series[0].Points.Clear();
            for (int i = 0; i < N; i++)
            {
                TotalInvestChart.Series[0].Points.AddXY(i + 1, K1[i]);
                TotalInvestChart.Series[1].Points.AddXY(i + 1, K2);
                double dk = K1[i] - K2;
                TotalInvestChart.Series[2].Points.AddXY(i + 1, dk);
                double k1 = K1[i] / ((i + 1) * L);
                double k2 = K2 / ((i + 1) * L);
                SpecInvestChart.Series[0].Points.AddXY(i + 1, k1);
                SpecInvestChart.Series[1].Points.AddXY(i + 1, k2);
                if (i != 0)
                {
                    if (K1[i - 1] - K2 > 0 && dk < 0 || K1[i - 1] - K2 < 0 && dk > 0)
                    {
                        ResultLabel.Text = "С " + (i + 1).ToString() + " каналов целесообразно использовать многоканальную систему";
                    }
                }
                SpecInvestChart.Series[2].Points.AddXY(i + 1, dk / ((i + 1) * L));
            }
        }
    }
}
