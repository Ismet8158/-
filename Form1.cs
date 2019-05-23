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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CalcButton_Click(object sender, EventArgs e)
        {
            double L, Kl, Kc, Ko;
            int N;
            try
            {
                L = Double.Parse(LengthTB.Text);
                N = Int32.Parse(ChannelCountsTB.Text);
                Kl = Double.Parse(LayCostTB.Text);
                Kc = Double.Parse(PhysCircCostTB.Text);
                Ko = Double.Parse(EquipCostTB.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка входных данных");
                return;
            }
            double[] totalInvestArr = new double[N];
            for (int i = 0; i < N; i++)
            {
                totalInvestArr[i] = TotalCapitalInvest(L, i + 1, Kl, Kc);
            }
            Form2 graphForm = new Form2(totalInvestArr, ((Kl + Kc) * L + 2 * Ko), N, L);
            graphForm.Show();
        }

        private double TotalCapitalInvest(double L, int N, double Kl, double Kc)
        {
            return (Kl + N * Kc) * L;
        }
    }
}
