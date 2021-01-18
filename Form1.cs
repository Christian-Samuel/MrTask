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
        public static ParteTarefa ListaDom = new ParteTarefa();
        public static ParteTarefa ListaSeg = new ParteTarefa();
        public static ParteTarefa ListaTer = new ParteTarefa();
        public static ParteTarefa ListaQua = new ParteTarefa();
        public static ParteTarefa ListaQui = new ParteTarefa();
        public static ParteTarefa ListaSex = new ParteTarefa();
        public static ParteTarefa ListaSab = new ParteTarefa();

        public Form1()
        {
            InitializeComponent();
            Label[] DomLis = { it1, it2, it3, it4, it5, it6, it7, it8, it9, it10, it11 };
            ListaDom.inicializar(domingo, DomLis);

            Label[] SegLis = { it12, it13, it14, it15, it16, it17, it18, it19, it20, it21, it22 };
            ListaSeg.inicializar(segunda, SegLis);

            Label[] TerLis = { it23, it24, it25, it26, it27, it28, it29, it30, it31, it32, it33 };
            ListaTer.inicializar(terca, TerLis);

            Label[] QuaLis = { it34, it35, it36, it37, it38, it39, it40, it41, it42, it43, it44 };
            ListaQua.inicializar(quarta, QuaLis);

            Label[] QuiLis = { it45, it46, it47, it48, it49, it50, it51, it52, it53, it54, it55 };
            ListaQui.inicializar(quinta, QuiLis);

            Label[] SexLis = { it56, it57, it58, it59, it60, it61, it62, it63, it64, it65, it66 };
            ListaSex.inicializar(sexta, SexLis);

            Label[] SabLis = { it67, it68, it69, it70, it71, it72, it73, it74, it75, it76, it77 };
            ListaSab.inicializar(sabado, SabLis);
        }

        public void atualizar()
        {
            ParteTarefa[] listaDias = { ListaDom, ListaSeg, ListaTer, ListaQua, ListaQui, ListaSex, ListaSab };
            DateTimePicker[] timePickers = { dateTimePicker1, dateTimePicker2, dateTimePicker3, dateTimePicker4, dateTimePicker5, dateTimePicker6, dateTimePicker7 };
            ControleTarefas.CarregarTarefa(listaDias, timePickers);
            label1.Text = dateTimePicker1.Value.DayOfWeek.ToString();
            label3.Text = dateTimePicker2.Value.DayOfWeek.ToString();
            label5.Text = dateTimePicker3.Value.DayOfWeek.ToString();
            label4.Text = dateTimePicker4.Value.DayOfWeek.ToString();
            label7.Text = dateTimePicker5.Value.DayOfWeek.ToString();
            label6.Text = dateTimePicker6.Value.DayOfWeek.ToString();
            label10.Text = dateTimePicker7.Value.DayOfWeek.ToString();


        }
        private void Form1_Load(object sender, EventArgs e)
        {   
            
            dateTimePicker2.Value = dateTimePicker1.Value.Date.AddDays(1);
            dateTimePicker3.Value = dateTimePicker1.Value.Date.AddDays(2);
            dateTimePicker4.Value = dateTimePicker1.Value.Date.AddDays(3);
            dateTimePicker5.Value = dateTimePicker1.Value.Date.AddDays(4);
            dateTimePicker6.Value = dateTimePicker1.Value.Date.AddDays(5);
            dateTimePicker7.Value = dateTimePicker1.Value.Date.AddDays(6);
            atualizar();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (nomeTarefatxt.TextLength > 1 && descTarefatxt.TextLength > 1)
            {
                ControleTarefas.gerarTarefaDia(nomeTarefatxt.Text, descTarefatxt.Text);
                abaTarefa.Visible = false;
                nomeTarefatxt.Text = "";
                descTarefatxt.Text = "";
                atualizar();
            }
            else
            {
                MessageBox.Show("Não deixe nenhum campo em branco!");
            }
        }

        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            dateTimePicker2.Value = dateTimePicker1.Value.Date.AddDays(1);
            dateTimePicker3.Value = dateTimePicker1.Value.Date.AddDays(2);
            dateTimePicker4.Value = dateTimePicker1.Value.Date.AddDays(3);
            dateTimePicker5.Value = dateTimePicker1.Value.Date.AddDays(4);
            dateTimePicker6.Value = dateTimePicker1.Value.Date.AddDays(5);
            dateTimePicker7.Value = dateTimePicker1.Value.Date.AddDays(6);
            atualizar();
        }

        private void domingo_DoubleClick_1(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;

            switch (panel.Name.ToString())
            {
                case "domingo":
                    if(ListaDom.posicao<11)
                    ControleTarefas.abrirGerenciadorTarefa(dateTimePicker1, ListaDom);
                    else
                        MessageBox.Show("Desculpe.. Mas todos os espaços estão ocupados");
                    break;

                case "segunda":
                    if (ListaSeg.posicao < 11)
                        ControleTarefas.abrirGerenciadorTarefa(dateTimePicker2, ListaSeg);
                    else
                        MessageBox.Show("Desculpe.. Mas todos os espaços estão ocupados");
                    break;

                case "terca":
                    if (ListaTer.posicao < 11)
                        ControleTarefas.abrirGerenciadorTarefa(dateTimePicker3, ListaTer);
                    else
                        MessageBox.Show("Desculpe.. Mas todos os espaços estão ocupados");
                    break;

                case "quarta":
                    if (ListaQua.posicao < 11)
                        ControleTarefas.abrirGerenciadorTarefa(dateTimePicker4, ListaQua);
                    else
                        MessageBox.Show("Desculpe.. Mas todos os espaços estão ocupados");
                    break;

                case "quinta":
                    if (ListaQui.posicao < 11)
                        ControleTarefas.abrirGerenciadorTarefa(dateTimePicker5, ListaQui);
                    else
                        MessageBox.Show("Desculpe.. Mas todos os espaços estão ocupados");
                    break;

                case "sexta":
                    if (ListaSex.posicao < 11)
                        ControleTarefas.abrirGerenciadorTarefa(dateTimePicker6, ListaSex);
                    else
                        MessageBox.Show("Desculpe.. Mas todos os espaços estão ocupados");
                     break;

                case "sabado":
                    if (ListaSab.posicao < 11)
                        ControleTarefas.abrirGerenciadorTarefa(dateTimePicker7, ListaSab);
                    else
                        MessageBox.Show("Desculpe.. Mas todos os espaços estão ocupados");
                    break;

            }
            abaTarefa.Visible = true;
        }
        private void it1_DoubleClick(object sender, EventArgs e)
        {
            Label[] DomLis = { it1, it2, it3, it4, it5, it6, it7, it8, it9, it10, it11 };
            Label item = sender as Label;
            ListaDom.alterarStatus(item);
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker1, ListaDom);
            ControleTarefas.atualizarTarefa(item,DomLis);
        }

        private void it12_DoubleClick(object sender, EventArgs e)
        {
            Label[] SegLis = { it12, it13, it14, it15, it16, it17, it18, it19, it20, it21, it22 };
            Label item = sender as Label;
            ListaSeg.alterarStatus(item);
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker2, ListaSeg);
            ControleTarefas.atualizarTarefa(item, SegLis);

        }

        private void it23_DoubleClick(object sender, EventArgs e)
        {
            Label[] TerLis = { it23, it24, it25, it26, it27, it28, it29, it30, it31, it32, it33 };
            Label item = sender as Label;
            ListaTer.alterarStatus(item);
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker3, ListaTer);
            ControleTarefas.atualizarTarefa(item, TerLis);

        }

        private void it34_DoubleClick(object sender, EventArgs e)
        {
            Label[] QuaLis = { it34, it35, it36, it37, it38, it39, it40, it41, it42, it43, it44 };
            Label item = sender as Label;
            ListaQua.alterarStatus(item);
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker4, ListaQua);
            ControleTarefas.atualizarTarefa(item, QuaLis);

        }

        private void it45_DoubleClick(object sender, EventArgs e)
        {
            Label[] QuiLis = { it45, it46, it47, it48, it49, it50, it51, it52, it53, it54, it55 };
            Label item = sender as Label;
            ListaQui.alterarStatus(item);
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker5, ListaQui);
            ControleTarefas.atualizarTarefa(item, QuiLis);

        }

        private void it56_DoubleClick(object sender, EventArgs e)
        {
            Label[] SexLis = { it56, it57, it58, it59, it60, it61, it62, it63, it64, it65, it66 };
            Label item = sender as Label;
            ListaSex.alterarStatus(item);
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker6, ListaSex);
            ControleTarefas.atualizarTarefa(item, SexLis);

        }

        private void it67_DoubleClick(object sender, EventArgs e)
        {
            Label[] SabLis = { it67, it68, it69, it70, it71, it72, it73, it74, it75, it76, it77 };
            Label item = sender as Label;
            ListaSab.alterarStatus(item);
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker7, ListaSab);
            ControleTarefas.atualizarTarefa(item, SabLis);

        }

        private void it1_Click(object sender, EventArgs e)
        {
            Label[] DomLis = { it1, it2, it3, it4, it5, it6, it7, it8, it9, it10, it11 };
            Label item = sender as Label;
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker1, ListaDom);
            ControleTarefas.carregarDescricao(descricaoTxt,nomeTxt,item,DomLis);
        }

        private void it22_Click(object sender, EventArgs e)
        {
            Label[] SegLis = { it12, it13, it14, it15, it16, it17, it18, it19, it20, it21, it22 };
            Label item = sender as Label;
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker2, ListaSeg);
            ControleTarefas.carregarDescricao(descricaoTxt, nomeTxt, item, SegLis);
        }

        private void it33_Click(object sender, EventArgs e)
        {
            Label[] TerLis = { it23, it24, it25, it26, it27, it28, it29, it30, it31, it32, it33 };
            Label item = sender as Label;
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker3, ListaTer);
            ControleTarefas.carregarDescricao(descricaoTxt, nomeTxt, item, TerLis);

        }

        private void it44_Click(object sender, EventArgs e)
        {
            Label[] QuaLis = { it34, it35, it36, it37, it38, it39, it40, it41, it42, it43, it44 };
            Label item = sender as Label;
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker4, ListaQua);
            ControleTarefas.carregarDescricao(descricaoTxt, nomeTxt, item, QuaLis);
        }

        private void it55_Click(object sender, EventArgs e)
        {
            Label[] QuiLis = { it45, it46, it47, it48, it49, it50, it51, it52, it53, it54, it55 };
            Label item = sender as Label;
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker5, ListaQui);
            ControleTarefas.carregarDescricao(descricaoTxt, nomeTxt, item, QuiLis);
        }

        private void it66_Click(object sender, EventArgs e)
        {
            Label[] SexLis = { it56, it57, it58, it59, it60, it61, it62, it63, it64, it65, it66 };
            Label item = sender as Label;
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker6, ListaSex);
            ControleTarefas.carregarDescricao(descricaoTxt, nomeTxt, item, SexLis);
        }

        private void it77_Click(object sender, EventArgs e)
        {
            Label[] SabLis = { it67, it68, it69, it70, it71, it72, it73, it74, it75, it76, it77 };
            Label item = sender as Label;
            ControleTarefas.abrirGerenciadorTarefa(dateTimePicker7, ListaSab);
            ControleTarefas.carregarDescricao(descricaoTxt, nomeTxt, item, SabLis);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = !groupBox3.Visible;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Christian Samuel->->->" +
                " Christian.cs.silva@gmail.com");
        }

        private void it1_MouseLeave_1(object sender, EventArgs e)
        {
            Label item = sender as Label;
            item.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
        }

        private void it1_MouseHover_1(object sender, EventArgs e)
        {
            Label item = sender as Label;
            item.BackColor = System.Drawing.Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = dateTimePicker1.Value.DayOfWeek.ToString();
         
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label12_MouseHover(object sender, EventArgs e)
        {
            Label icone = sender as Label;
            icone.BackColor = Color.FromArgb(255, 192, 192);
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            Label icone = sender as Label;
            icone.BackColor = Color.FromArgb(128, 255, 128);
        }
    }
}
