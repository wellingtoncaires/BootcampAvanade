using System;
using DIO.Series;

namespace DIO.Series.Console
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ShowSerie();
                        break;
                    case "C":
                        System.Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                userOption = GetUserOption();
            }

            System.Console.WriteLine("obrigado por utilizar nossos serviços");
            System.Console.ReadLine();
        }

        private static void ListSeries()
        {
            System.Console.WriteLine("Lista séries"); ;

            var list = repository.Lista();

            if (list.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in list)
            {
                var removed = serie.returnRemoved();
                if (!removed)
                {
                    System.Console.WriteLine($"#ID {serie.returnId()}: {serie.returnTitle()}");
                }

            }
        }

        private static void InsertSerie()
        {
            System.Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                System.Console.WriteLine($"{i}-{Enum.GetName(typeof(Gender), i)}");
            }
            System.Console.Write("Digite o gênero entre as opções acima: ");
            int enterGender = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite o Título da Série: ");
            string enterTitle = System.Console.ReadLine();

            System.Console.Write("Digite o Ano de Início da série: ");
            int enterYear = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite a Descrição da Série: ");
            string enterDescription = System.Console.ReadLine();

            Series newSerie = new Series(id: repository.NextId(),
                gender: (Gender)enterGender,
                title: enterTitle,
                year: enterYear,
                description: enterDescription);
            repository.Insert(newSerie);
        }

        private static void UpdateSerie()
        {
            System.Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(System.Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                System.Console.WriteLine($"{i}-{Enum.GetName(typeof(Gender), i)}");
            }
            System.Console.Write("Digite o gênero entre as opções acima: ");
            int enterGender = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite o Título da Série: ");
            string enterTitle = System.Console.ReadLine();

            System.Console.Write("Digite o Ano de Início da série: ");
            int enterYear = int.Parse(System.Console.ReadLine());

            System.Console.Write("Digite a Descrição da Série: ");
            string enterDescription = System.Console.ReadLine();

            Series updateSerie = new Series(id: idSerie,
                gender: (Gender)enterGender,
                title: enterTitle,
                year: enterYear,
                description: enterDescription);
            repository.Update(idSerie, updateSerie);
        }

        private static void DeleteSerie()
        {
            System.Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(System.Console.ReadLine());

            System.Console.Write("Confirmar a exclusão [S/N]: ");
            char answer = char.Parse(System.Console.ReadLine().ToUpper().Trim());
            if (answer == 'S')
            {
                repository.Delete(idSerie);
            }
            else
            {
                System.Console.WriteLine("Deleção cancelada:");
            }
        }

        private static void ShowSerie()
        {
            System.Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(System.Console.ReadLine());

            var serie = repository.ReturnById(idSerie);

            System.Console.WriteLine(serie);
        }

        private static string GetUserOption()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Dio Series!");
            System.Console.WriteLine("Informe a opção desejada:");

            System.Console.WriteLine("1- Listar séries");
            System.Console.WriteLine("2- Inserir nova série");
            System.Console.WriteLine("3- Atualizar série");
            System.Console.WriteLine("4- Excluir série");
            System.Console.WriteLine("5- Visualizar sére");
            System.Console.WriteLine("C- Limpar Telsa");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string userOption = System.Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return userOption;

        }
    }
}
