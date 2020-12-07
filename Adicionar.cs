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

namespace GerenciarSenhas
{

	public class adicionar
	{
		protected static void ocultar()
        {
			FileInfo dado1 = new FileInfo("data.pas");
			FileInfo dado2 = new FileInfo("data.loc");
			FileInfo dado3 = new FileInfo("data.lgn");

			dado1.Attributes = FileAttributes.Hidden;
			dado2.Attributes = FileAttributes.Hidden;
			dado3.Attributes = FileAttributes.Hidden;

			File.Encrypt("data.pas");
			File.Encrypt("data.loc");
			File.Encrypt("data.lgn");
		}
		public static void add(Control local, Control login, Control senha)
		{


			using (FileStream arquivo = new FileStream("data.pas", FileMode.Append))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(arquivo))
				{
					using (FileStream arquivo1 = new FileStream("data.loc", FileMode.Append))
					{
						using (BinaryWriter binaryWriter1 = new BinaryWriter(arquivo1))
						{
							using (FileStream arquivo2 = new FileStream("data.lgn", FileMode.Append))
							{
								using (BinaryWriter binaryWriter2 = new BinaryWriter(arquivo2))
								{
									binaryWriter1.Write(local.Text);
									binaryWriter.Write(login.Text);
									binaryWriter2.Write(senha.Text);
								}
							}
						}
					}
				}
			}
			ocultar();
		}

		public static void procL(ListBox lista)
		{
			using (FileStream arquivo1 = new FileStream("data.loc", FileMode.Open))
			{
				using (BinaryReader binaryWriter1 = new BinaryReader(arquivo1))
				{
					lista.Items.Clear();
					while (binaryWriter1.PeekChar() != -1)
					{
						lista.Items.Add(binaryWriter1.ReadString()) ;
					}
				}
			}
		}

		public static void proc(int i, Control login, Control senha)
		{
			using (FileStream arquivo1 = new FileStream("data.pas", FileMode.Open))
			{
				using (BinaryReader binaryWriter1 = new BinaryReader(arquivo1))
				{
					using (FileStream arquivo = new FileStream("data.lgn", FileMode.Open))
					{
						using (BinaryReader binaryWriter = new BinaryReader(arquivo))
						{
							if (i == 0)
							{
								senha.Text = binaryWriter.ReadString();
								login.Text = binaryWriter1.ReadString();
							}
							else
							{
								int x = 0;
								do
								{
									binaryWriter1.ReadString();
									binaryWriter.ReadString();
									x++;
								} while (x < i);

								if (binaryWriter1.PeekChar() != -1)
								{
									login.Text = binaryWriter1.ReadString();
									senha.Text = binaryWriter.ReadString();
								}
							}
						}
					}
				}

			}
		}

		public static void remover(int i)
		{
			using (FileStream arquivo = new FileStream("data.pas", FileMode.Open))
			{
				using (BinaryReader binaryReader = new BinaryReader(arquivo))
				{
					using (FileStream arquivo1 = new FileStream("data.loc", FileMode.Open))
					{
						using (BinaryReader binaryReader1 = new BinaryReader(arquivo1))
						{
							using (FileStream arquivo2 = new FileStream("data.lgn", FileMode.Open))
							{
								using (BinaryReader binaryReader2 = new BinaryReader(arquivo2))
								{
									using (FileStream arquivo3 = new FileStream("bak.pas", FileMode.Create))
									{
										using (BinaryWriter binaryWriter = new BinaryWriter(arquivo3))
										{
											using (FileStream arquivo4 = new FileStream("bak.loc", FileMode.Create))
											{
												using (BinaryWriter binaryWriter1 = new BinaryWriter(arquivo4))
												{
													using (FileStream arquivo5 = new FileStream("bak.lgn", FileMode.Create))
													{
														using (BinaryWriter binaryWriter2 = new BinaryWriter(arquivo5))
														{
															int x = 0;
															if (i > 0)
															{
																do
																{
																	binaryWriter.Write(binaryReader.ReadString());
																	binaryWriter1.Write(binaryReader1.ReadString());
																	binaryWriter2.Write(binaryReader2.ReadString());
																	x++;
																} while (x < i);
															}

															if (binaryReader.PeekChar() != -1)
															{
																binaryReader.ReadString();
																binaryReader1.ReadString();
																binaryReader2.ReadString();
															}
															
															while (binaryReader.PeekChar() != -1) 
															{	
																	binaryWriter.Write(binaryReader.ReadString());
																	binaryWriter1.Write(binaryReader1.ReadString());
																	binaryWriter2.Write(binaryReader2.ReadString());
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
					}
				}
			}
			
			File.Delete("data.lgn");
			File.Delete("data.loc");
			File.Delete("data.pas");

			File.Move("bak.lgn","data.lgn");
			File.Move("bak.loc", "data.loc");
			File.Move("bak.pas", "data.pas");
			ocultar();
		}
	}	
}
