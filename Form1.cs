using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MrTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
 
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            dateTimePicker2.Value = DateTime.Now.AddDays(dateTimePicker1.Value.Day-6);
            dateTimePicker3.Value = DateTime.Now.AddDays(dateTimePicker1.Value.Day - 5);
            dateTimePicker4.Value = DateTime.Now.AddDays(dateTimePicker1.Value.Day - 4);
            dateTimePicker5.Value = DateTime.Now.AddDays(dateTimePicker1.Value.Day - 3);
            dateTimePicker6.Value = DateTime.Now.AddDays(dateTimePicker1.Value.Day - 2);
            dateTimePicker7.Value = DateTime.Now.AddDays(dateTimePicker1.Value.Day - 1);

            CheckedListBox[] listBox = { dom, seg, ter, qua, qui, sex, sab };
            DateTimePicker[] timePickers = { dateTimePicker1, dateTimePicker2, dateTimePicker3, dateTimePicker4, dateTimePicker5, dateTimePicker6, dateTimePicker7 };

            ControleTarefas.CarregarTarefa(listBox,timePickers);
        }

        private void dom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dom_DoubleClick(object sender, EventArgs e)
        {
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker1,dom);
            abaTarefa.Visible = true;
        }

        private void seg_DoubleClick(object sender, EventArgs e)
        {
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker2,seg);
            abaTarefa.Visible = true;
        }

        private void ter_DoubleClick(object sender, EventArgs e)
        {
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker3,ter);
            abaTarefa.Visible = true;
        }

        private void qua_DoubleClick(object sender, EventArgs e)
        {
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker4,qua);
            abaTarefa.Visible = true;
        }

        private void qui_DoubleClick(object sender, EventArgs e)
        {
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker5,qui);
            abaTarefa.Visible = true;
        }

        private void sex_DoubleClick(object sender, EventArgs e)
        {
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker6,sex);
            abaTarefa.Visible = true;
        }

        private void sab_DoubleClick(object sender, EventArgs e)
        {
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker7,sab);
            abaTarefa.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ControleTarefas.gerarTarefaDia(nomeTarefatxt.Text, descTarefatxt.Text);
            abaTarefa.Visible = false;
            nomeTarefatxt.Text = "";
            descTarefatxt.Text = "";
        }
    }
}
