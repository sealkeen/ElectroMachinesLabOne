using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectroMachinesLabOne
{
    public partial class Grid : Form
    {
        public Grid()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<double> U1 = new List<double>(); for (int i = 0; i < 12; i++) { U1.Add(15); }
            List<double> I   = new List<double> { 150,  120,  100, 80,  52, 40,  31, 27,   23,   17,   10,   4 }   ;
            List<double> Ul = new List<double> { 14.2, 11.3, 9.4, 7,   5,  3.7, 3,  2.45, 2.1,  1.6,  0.7,  0.35} ;
            List<double> U2  = new List<double> { 0.17, 3.3,  5,   7.7, 10, 11,  12, 12.3, 12.8, 13.2, 14.4, 14.5 };
            ConvertMAToA(ref I);

            lstOutput.Items.Add($"{Concat(I, "I")}");
            lstOutput.Items.Add($"{Concat(Ul, "Ul1")}");
            lstOutput.Items.Add($"{Concat(U2, "U2")}");
            lstOutput.Items.Add($"{Concat(U1, I, "P1")}");
            lstOutput.Items.Add($"{Concat(Ul, I, "Pl")}");
            lstOutput.Items.Add($"{Concat(U2, I, "P2")}");
            lstOutput.Items.Add($"{Concat(U2, I, "Ppr")}");
            lstOutput.Items.Add($"{ConcatDivide(U2, I, U1, I, "shnyaga")}");
        }
        private double p(double i, double u1)
        { return (i * u1); }
        private double hurma(double Ppr, double P1)
        { return Ppr/P1; }
        private string Concat(List<double> Massive, List<double> multiplier, string columnName)
        {
            string sb = columnName;
            for (int i = 0; i < Massive.Count; i++) { sb+=$"\t{Math.Round( (Massive[i]*multiplier[i]), 2 ).ToString()}"; }
            return sb.ToString();
        }

        private string Concat(List<double> Massive, string columnName)
        {
            string sb = columnName;
            for (int i = 0; i < Massive.Count; i++) { sb += $"\t{Math.Round((Massive[i]), 3).ToString()}"; }
            return sb.ToString();
        }

        private string ConcatDivide(List<double> Massive1, List<double> Massive2, List<double> Massive3, List<double> Massive4, string columnName)
        {
            string sb = columnName;
            for (int i = 0; i < Massive1.Count; i++) { sb += $"\t{Math.Round((Massive1[i]* Massive2[i] / Massive3[i]* Massive4[i]), 2).ToString()}"; }
            return sb.ToString();
        }

        private void ConvertMAToA(ref List<double> Arr)
        {
            if (Arr.Count != 0)
                for (int i = 0; i < Arr.Count; i++)
                {
                    Arr[i] *= 0.001;
                }
                ;
        }
    }
}
