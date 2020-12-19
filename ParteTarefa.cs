using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MrTask
{
   public class ParteTarefa 
    { 
    
        //Dados
        private Panel fundo;
        private Label[] itens=new Label[11];
        public int posicao=0;

        //Construtor

        public ParteTarefa()
        {

        }
        public void inicializar(Panel panel, Label[] labels) 
        {
            this.fundo = panel;

            for(int x=0; x<11; x++)
            {
                this.itens[x] = labels[x];
            }
        }

        //Metodos
        public void add(string nome, bool stts)
        {
            
                this.itens[posicao].Text = nome;
                this.itens[posicao].Visible = true;
                if (stts)
                {
                    this.itens[posicao].ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    this.itens[posicao].ForeColor = System.Drawing.Color.Red;
                }
                this.posicao += 1;
           
        }

        public void alterarStatus(Label item)
        {
            if(item.ForeColor == System.Drawing.Color.Blue)
            {
                item.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                item.ForeColor = System.Drawing.Color.Blue;
            }
        }

        public void clear()
        {
            for (int x = 0; x < 11; x++)
            {
                this.itens[x].Text = "";
                this.itens[x].Visible = false;
            }
            this.posicao = 0;
        }

        public Label getItem(int x) 
        {
            return this.itens[x];
        }
    }
}
