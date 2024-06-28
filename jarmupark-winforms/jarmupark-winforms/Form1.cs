using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace jarmupark_winforms
{
    public partial class Form1 : Form
    {
        int bev = 0;
        int kiad = 0;

        List<int> ferohely = new List<int>() {30, 24, 30, 40, 20};
        List<int> fogyasztas = new List<int>() {13, 9, 14, 14, 8};

        List<int> ferohely2 = new List<int>() { 5, 4, 5};
        List<int> fogyasztas2 = new List<int>() { 18, 15, 16};

        public Form1()
        {
            InitializeComponent();
        }

        private void leftright_Click(object sender, EventArgs e)
        {
            if (left.SelectedIndex != -1)
            {
                right.Items.Add(left.Items[left.SelectedIndex]);
                left.Items.RemoveAt(left.SelectedIndex);
            }
        }

        private void rightleft_Click(object sender, EventArgs e)
        {
            if (right.SelectedIndex != -1)
            {
                left.Items.Add(right.Items[right.SelectedIndex]);
                right.Items.RemoveAt(right.SelectedIndex);
            }
        }

        public int getIndex(ListBox box)
        {
            int index;
            switch (box.Items[box.SelectedIndex].ToString())
            {
                case "busz-01":
                    index = 0;
                    break;
                case "busz-02":
                    index = 1;
                    break;
                case "busz-03":
                    index = 2;
                    break;
                case "busz-04":
                    index = 3;
                    break;
                case "busz-05":
                    index = 4;
                    break;
                default:
                    index = 0;
                    break;
            }
            return index;
        }

        public int getIndex2(ListBox box)
        {
            int index;
            switch (box.Items[box.SelectedIndex].ToString())
            {
                case "teher-01":
                    index = 0;
                    break;
                case "teher-02":
                    index = 1;
                    break;
                case "teher-03":
                    index = 2;
                    break;
                default:
                    index = 0;
                    break;
            }
            return index;
        }

        private void left_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (left.SelectedIndex != -1)
            {
                int index = getIndex(left);
                toolTip1.SetToolTip(left, "férőhelyek száma: " + ferohely[index] +
                    " fő, fogyasztása: " + fogyasztas[index] + " l/100 km");
            }
        }

        int frisKiad;
        int frisBer;

        private void frissites_Click(object sender, EventArgs e)
        {
            if (benzinAr.Text != "" && ut.Text != "" && right.Items.Count != 0)
            {
                int index;
                int kiadas = 0;
                int berlet = 0;
                for (int i = 0; i < right.Items.Count; i++)
                {
                    switch (right.Items[i].ToString())
                    {
                        case "busz-01":
                            index = 0;
                            break;
                        case "busz-02":
                            index = 1;
                            break;
                        case "busz-03":
                            index = 2;
                            break;
                        case "busz-04":
                            index = 3;
                            break;
                        case "busz-05":
                            index = 4;
                            break;
                        default:
                            index = 0;
                            break;
                    }

                    kiadas += Int32.Parse(benzinAr.Text) * Int32.Parse(ut.Text) / 100 * fogyasztas[index];
                    berlet += ferohely[index] * 25;
                }
                berletdij.Text = (kiadas + berlet).ToString();

                frisKiad = kiadas;
                frisBer = berlet;
            }
        }

        private void rendeles_Click(object sender, EventArgs e)
        {
            bev += frisKiad + frisBer;
            kiad += frisKiad;

            osszBev.Text = bev.ToString();
            osszKiad.Text = kiad.ToString();
            osszHaszon.Text = (bev - kiad).ToString();

            if (right.Items.Count != 0)
            {
                for (int i = right.Items.Count - 1; i > -1; i--)
                {
                    left.Items.Add(right.Items[i]);
                    right.Items.RemoveAt(i);
                }
                ut.Text = "0";
                benzinAr.Text = "0";
                frisKiad = 0;
                frisBer = 0;
                berletdij.Text = "0";
            }
        }

        private void leftright2_Click(object sender, EventArgs e)
        {
            if (left2.SelectedIndex != -1)
            {
                right2.Items.Add(left2.Items[left2.SelectedIndex]);
                left2.Items.RemoveAt(left2.SelectedIndex);
            }
        }

        private void rightleft2_Click(object sender, EventArgs e)
        {
            if (right2.SelectedIndex != -1)
            {
                left2.Items.Add(right2.Items[right2.SelectedIndex]);
                right2.Items.RemoveAt(right2.SelectedIndex);
            }
        }

        private void left2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (left2.SelectedIndex != -1)
            {
                int index = getIndex2(left2);
                toolTip1.SetToolTip(left2, "férőhelyek száma: " + ferohely2[index] +
                    " fő, fogyasztása: " + fogyasztas2[index] + " l/100 km");
            }
        }

        private void frissites2_Click(object sender, EventArgs e)
        {
            if (benzinAr2.Text != "" && ut2.Text != "" && right2.Items.Count != 0)
            {
                int index;
                int kiadas = 0;
                int berlet = 0;
                for (int i = 0; i < right2.Items.Count; i++)
                {
                    switch (right2.Items[i].ToString())
                    {
                        case "teher-01":
                            index = 0;
                            break;
                        case "teher-02":
                            index = 1;
                            break;
                        case "teher-03":
                            index = 2;
                            break;
                        default:
                            index = 0;
                            break;
                    }

                    kiadas += Int32.Parse(benzinAr2.Text) * Int32.Parse(ut2.Text) / 100 * fogyasztas2[index];
                    berlet += ferohely2[index] * 25;
                }
                berletdij2.Text = (kiadas + berlet).ToString();

                frisKiad = kiadas;
                frisBer = berlet;
            }
        }

        private void rendeles2_Click(object sender, EventArgs e)
        {
            bev += frisKiad + frisBer;
            kiad += frisKiad;

            osszBev.Text = bev.ToString();
            osszKiad.Text = kiad.ToString();
            osszHaszon.Text = (bev - kiad).ToString();

            if (right2.Items.Count != 0)
            {
                for (int i = right2.Items.Count - 1; i > -1; i--)
                {
                    left2.Items.Add(right2.Items[i]);
                    right2.Items.RemoveAt(i);
                }
                ut2.Text = "0";
                benzinAr2.Text = "0";
                frisKiad = 0;
                frisBer = 0;
                berletdij2.Text = "0";
            }
        }
    }
}
