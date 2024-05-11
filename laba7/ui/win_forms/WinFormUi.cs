using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace laba7.ui.win_forms
{
    public partial class WinFormUi : Form, ZheckVeiw
    {
        Presenter controller;
        public WinFormUi()
        {
            InitializeComponent();
        }

        ZheckUi ZheckVeiw.adding { get  {
                return new ZheckUi(
                    region: textBox2.Text,
                    number: 0,
                    name: textBox4.Text,
                    numberHabitians: (double)numericUpDown1.Value,
                    numberOfBuildings: (double)numericUpDown2.Value
                );
            }
            set {
                textBox2.Text = value.Region;
                textBox4.Text = value.Name;
                numericUpDown1.Value = (decimal)value.NumberHabitians;
                numericUpDown2.Value = (decimal)value.NumberOfBuildings;
            }
        }
        ZheckUi ZheckVeiw.changing {
            get
            {
                return new ZheckUi(
                    region: textBox8.Text,
                    number: Int32.Parse(listBox1.SelectedItem.ToString().Split()[0]),
                    name: textBox6.Text,
                    numberHabitians: (double)numericUpDown3.Value,
                    numberOfBuildings: (double)numericUpDown4.Value
                );
            }
            set
            {
                textBox8.Text = value.Region;
                textBox6.Text = value.Name;
                numericUpDown3.Value = (decimal)value.NumberHabitians;
                numericUpDown4.Value = (decimal)value.NumberOfBuildings;
            }
        }

        public string error { set { MessageBox.Show(value); } }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.addZheck();
        }

        void ZheckVeiw.SetController(Presenter _controller)
        {
            controller = _controller;
        }

        void ZheckVeiw.ShowZheckList(List<ZheckUi> zheckList)
        {
            listBox1.Items.Clear();
            zheckList.ForEach((z) => {
                listBox1.Items.Add(z.Number+" "+z.Name);
            });
        }
        void ZheckVeiw.Run()
        {
            Application.Run(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.changeZheck();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.removeZheck();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1?.SelectedItem!=null) controller.setChanging(Int32.Parse(listBox1?.SelectedItem?.ToString().Split()[0]));
        }
    }
}
