using System;
using ProjetoMedicamento;

class Program
{
    static void Main(string[] args)
    {
        Medicamentos medicamentos = new Medicamentos();
        int opcao;

        do
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("0. Finalizar processo");
            Console.WriteLine("1. Cadastrar medicamento");
            Console.WriteLine("2. Consultar medicamento (sintético)");
            Console.WriteLine("3. Consultar medicamento (analítico)");
            Console.WriteLine("4. Comprar medicamento (cadastrar lote)");
            Console.WriteLine("5. Vender medicamento (abater do lote mais antigo)");
            Console.WriteLine("6. Listar medicamentos");
            Console.Write("Opção: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Laboratório: ");
                    string lab = Console.ReadLine();

                    medicamentos.Adicionar(new Medicamento(id, nome, lab));
                    Console.WriteLine("Medicamento cadastrado!");
                    break;

                case 2:
                    Console.Write("ID do medicamento: ");
                    int id2 = int.Parse(Console.ReadLine());
                    var med2 = medicamentos.Pesquisar(new Medicamento(id2, "", ""));
                    Console.WriteLine(med2.Id == 0 ? "Não encontrado" : med2);
                    break;

                case 3:
                    Console.Write("ID do medicamento: ");
                    int id3 = int.Parse(Console.ReadLine());
                    var med3 = medicamentos.Pesquisar(new Medicamento(id3, "", ""));
                    if (med3.Id == 0)
                        Console.WriteLine("Medicamento não encontrado");
                    else
                    {
                        Console.WriteLine(med3);
                        foreach (var lote in med3.Lotes)
                            Console.WriteLine("  " + lote);
                    }
                    break;

                case 4:
                    Console.Write("ID do medicamento: ");
                    int id4 = int.Parse(Console.ReadLine());
                    var med4 = medicamentos.Pesquisar(new Medicamento(id4, "", ""));
                    if (med4.Id == 0)
                        Console.WriteLine("Medicamento não encontrado");
                    else
                    {
                        Console.Write("ID Lote: ");
                        int idL = int.Parse(Console.ReadLine());
                        Console.Write("Quantidade: ");
                        int qtde = int.Parse(Console.ReadLine());
                        Console.Write("Data de vencimento (dd/mm/aaaa): ");
                        DateTime venc = DateTime.Parse(Console.ReadLine());

                        med4.Comprar(new Lote(idL, qtde, venc));
                        Console.WriteLine("Lote cadastrado!");
                    }
                    break;

                case 5:
                    Console.Write("ID do medicamento: ");
                    int id5 = int.Parse(Console.ReadLine());
                    var med5 = medicamentos.Pesquisar(new Medicamento(id5, "", ""));
                    if (med5.Id == 0)
                        Console.WriteLine("Medicamento não encontrado");
                    else
                    {
                        Console.Write("Quantidade a vender: ");
                        int qtd = int.Parse(Console.ReadLine());
                        if (med5.Vender(qtd))
                            Console.WriteLine("Venda realizada!");
                        else
                            Console.WriteLine("Quantidade insuficiente!");
                    }
                    break;

                case 6:
                    foreach (var m in medicamentos.Listar())
                        Console.WriteLine(m);
                    break;
            }

        } while (opcao != 0);
    }
}
