using System;

class Program
{
    static void Main()
    {
        int opcao;
        TimeSpan horaEntrada, horaSaida, terceiroValor;

        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Adição de Hora");
            Console.WriteLine("2 - Cálculo");
            Console.WriteLine("0 - Sair");

            Console.Write("Escolha uma opção: ");
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    Console.Write("Digite a hora de entrada (formato HH:mm): ");
                    if (!TimeSpan.TryParse(Console.ReadLine(), out horaEntrada))
                    {
                        Console.WriteLine("Hora de entrada inválida. Tente novamente.");
                        continue;
                    }

                    Console.Write("Digite a hora de saída (formato HH:mm): ");
                    if (!TimeSpan.TryParse(Console.ReadLine(), out horaSaida))
                    {
                        Console.WriteLine("Hora de saída inválida. Tente novamente.");
                        continue;
                    }

                    Console.Write("Digite o terceiro valor (formato HH:mm): ");
                    if (!TimeSpan.TryParse(Console.ReadLine(), out terceiroValor))
                    {
                        Console.WriteLine("Terceiro valor inválido. Tente novamente.");
                        continue;
                    }

                    Console.Write("Deseja adicionar (A) ou subtrair (S) o terceiro valor? ");
                    string opcaoAdicao = Console.ReadLine().ToUpper();

                    bool adicionar = opcaoAdicao == "A";
                    bool subtrair = opcaoAdicao == "S";

                    if (adicionar || subtrair)
                    {
                        TimeSpan resultadoAdicao = AdicionarHoras(horaEntrada, horaSaida, terceiroValor, adicionar);
                        Console.WriteLine($"Resultado da {(adicionar ? "adição" : "subtração")}: {resultadoAdicao}");
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                    }
                    break;

                case 2:
                    Console.Write("Digite o primeiro valor (formato HH:mm): ");
                    if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan primeiroValor))
                    {
                        Console.WriteLine("Primeiro valor inválido. Tente novamente.");
                        continue;
                    }

                    Console.Write("Digite o segundo valor (formato HH:mm): ");
                    if (!TimeSpan.TryParse(Console.ReadLine(), out TimeSpan segundoValor))
                    {
                        Console.WriteLine("Segundo valor inválido. Tente novamente.");
                        continue;
                    }

                    terceiroValor = primeiroValor - segundoValor;
                    Console.WriteLine($"Resultado do cálculo: {terceiroValor}");
                    break;

                case 0:
                    Console.WriteLine("Saindo do programa.");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        } while (opcao != 0);
    }

    static TimeSpan AdicionarHoras(TimeSpan horaEntrada, TimeSpan horaSaida, TimeSpan terceiroValor, bool adicionar)
    {
        TimeSpan totalHoras = horaSaida - horaEntrada;

        if (adicionar)
            return horaEntrada + totalHoras + terceiroValor;
        else
            return horaEntrada + totalHoras - terceiroValor;
    }
}
