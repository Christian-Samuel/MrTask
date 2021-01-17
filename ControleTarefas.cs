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
        static ParteTarefa Lista;

        public static void gerarTarefaDia(string nome, string desc)
        {
            string patch = "C:\\chrYstYan\\MrTask\\";
            string tempLocal =diaTarefa.ToString() + ".cal";

            if (!Directory.Exists(patch))
                Directory.CreateDirectory(patch);

            using (FileStream arquivo = new FileStream(patch+tempLocal, FileMode.Append))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(arquivo))
                {
                    binaryWriter.Write(nome+"F");
                    binaryWriter.Write(desc);
                }
            }
        }

        public static void abrirGerenciadorTarefa(DateTimePicker data, ParteTarefa lista)
        {
            diaTarefa = data.Value.DayOfYear;
            Data = data;
            Lista = lista;
        }


        //Carregar as tarefas do banco de dados
        public static void CarregarTarefa(ParteTarefa[] listBox, DateTimePicker[] timePickers)
        {
            for(int w=0;w<7;w++)
            {
                listBox[w].clear();
            }

            for (int x=1; x<=366; x++)
            {
                string patch = "C:\\chrYstYan\\MrTask\\";
                string tempLocal = x.ToString() + ".cal";
                string palavra;
                

                if (System.IO.File.Exists(patch+tempLocal))
                {
                    for (int z=0; z<=6; z++)
                    {   
                        if ((timePickers[z].Value.DayOfYear.ToString() + ".cal") == (x.ToString() + ".cal"))
                        {
                            using (FileStream arquivo = new FileStream(patch+tempLocal, FileMode.Open))
                            {
                                using (BinaryReader binaryReader = new BinaryReader(arquivo))
                                {
                                    while (binaryReader.PeekChar() != -1)
                                    {
                                        palavra = binaryReader.ReadString();
                                        string palavraDB = "";
                                        if (palavra[palavra.Length-1]=='F')
                                        {
                                           
                                            for (int y=0;y<palavra.Length-1;y++)
                                            {
                                                palavraDB += palavra[y];
                                            }
                                            listBox[z].add(palavraDB,false);
                                           
                                        }
                                        else
                                        {
                                            for (int y = 0; y < palavra.Length - 1; y++)
                                            {
                                                palavraDB += palavra[y];
                                            }
                                            listBox[z].add(palavraDB, true);
                                        }
                                        binaryReader.ReadString();
                                    }
                                }
                            }
                        }
                    }
                }      
            }
        }


        public static void carregarDescricao(Label descricao, Label nome, Label item, Label[] listBox)
        {
            string patch = "C:\\chrYstYan\\MrTask\\";
            string tempLocal = diaTarefa.ToString() + ".cal";
            string palavra;
            nome.Text = "";
            int x = 0;
            int index = 0;

            for (x = 0; x < 11; x++)
            {
                if (listBox[x].Name.ToString() == item.Name.ToString())
                {
                    index = x;
                }
            }
            x = 0;
            if (System.IO.File.Exists(patch + tempLocal))
            {
                using (FileStream arquivo = new FileStream(patch + tempLocal, FileMode.Open))
                {
                    using (BinaryReader binaryReader = new BinaryReader(arquivo))
                    {
                        if (index > 0)
                        {
                            do
                            {
                                binaryReader.ReadString();
                                binaryReader.ReadString();
                                x++;
                            } while (x < index);
                        }

                        palavra = binaryReader.ReadString();
                        for (int z = 0; z < palavra.Length - 1; z++)
                        {
                            nome.Text += palavra[z];
                        }
                        descricao.Text = binaryReader.ReadString();

                        while (binaryReader.PeekChar() != -1)
                        {
                           binaryReader.ReadString();
                           binaryReader.ReadString();
                        }
                    }
                }
            }
        }

        public static void atualizarTarefa(Label item, Label[] listBox)
         {
             string patch = "C:\\chrYstYan\\MrTask\\";
             string tempLocal = diaTarefa.ToString() + ".cal";
             string tempLocal2 = "bak.cal";

            int index = 0;
            for(int x=0; x<11; x++)
            {
                if(listBox[x].Name.ToString()==item.Name.ToString())
                {
                    index = x;
                }
            }



             if (System.IO.File.Exists(patch+tempLocal) && index>=0)
             {
                 using (FileStream arquivo = new FileStream(patch+tempLocal, FileMode.Open))
                 {
                     using (BinaryReader binaryReader = new BinaryReader(arquivo))
                     {
                         using (FileStream arquivo2 = new FileStream(patch+tempLocal2, FileMode.Create))
                         {
                             using (BinaryWriter binaryWriter = new BinaryWriter(arquivo2))
                             {
                                 string palavra = "";
                                 string palavraDB = "";
                                 int x = 0;

                                 if (index > 0)
                                 {
                                     do
                                     {
                                         binaryWriter.Write(binaryReader.ReadString());
                                         binaryWriter.Write(binaryReader.ReadString());
                                         x++;
                                     } while (x < index);
                                 }

                                 palavraDB = binaryReader.ReadString();

                                 for (int z = 0; z < palavraDB.Length - 1; z++)
                                 {
                                     palavra += palavraDB[z];
                                 }

                                 if (binaryReader.PeekChar() != -1)
                                 {
                                     if (Lista.getItem(index).ForeColor == System.Drawing.Color.Blue)
                                     {
                                         binaryWriter.Write(palavra + "T");
                                     }
                                     else
                                     {
                                         binaryWriter.Write(palavra + "F");
                                     }

                                     binaryWriter.Write(binaryReader.ReadString());
                                 }


                                 while (binaryReader.PeekChar() != -1)
                                 {
                                     binaryWriter.Write(binaryReader.ReadString());
                                     binaryWriter.Write(binaryReader.ReadString());
                                 }
                             }
                         }
                     }

                 }
                 File.Delete(patch+tempLocal);

                 File.Move(patch+tempLocal2, patch+tempLocal);
             }

         }


    }
}
