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
    class ControleTarefas
    {
        static int diaTarefa;
        static DateTimePicker Data;
        static CheckedListBox Lista;

        public static void gerarTarefaDia(string nome, string desc)
        {
            string tempLocal =diaTarefa.ToString() + ".cal";

            using (FileStream arquivo = new FileStream(tempLocal, FileMode.Append))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(arquivo))
                {
                    binaryWriter.Write(nome);
                    binaryWriter.Write(desc);
                }
            }
        }

        public static void abrirGerenciadorTarefa(DateTimePicker data, CheckedListBox lista)
        {
            diaTarefa = data.Value.DayOfYear;
            Data = data;
            Lista = lista;
        }


        //Carregar as tarefas do banco de dados
        public static void CarregarTarefa(CheckedListBox[] listBox, DateTimePicker[] timePickers)
        {

            for (int x=1; x<=366; x++)
            {
                string tempLocal = x.ToString() + ".cal";

                for (int z=0; z<=6; z++)
                {
                    if (System.IO.File.Exists(tempLocal))
                    {
                        if ((timePickers[z].Value.DayOfYear.ToString() + ".cal") == (x.ToString() + ".cal"))
                        {
                            using (FileStream arquivo = new FileStream(tempLocal, FileMode.Open))
                            {
                                using (BinaryReader binaryReader = new BinaryReader(arquivo))
                                {
                                    while (binaryReader.PeekChar() != -1)
                                    {
                                        listBox[z].Items.Add(binaryReader.ReadString());
                                        binaryReader.ReadString();
                                    }
                                }
                            }
                        }
                    }
                }      
            }
        }
    }
}
