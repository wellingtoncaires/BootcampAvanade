using System;

namespace DIO.Series
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
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                userOption = GetUserOption();
            }

            Console.WriteLine("obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void ListSeries()
        {
            Console.WriteLine("Lista séries"); ;

            var list = repository.Lista();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in list)
            {
                var removed = serie.returnRemoved();
                if (!removed)
                {
                    Console.WriteLine($"#ID {serie.returnId()}: {serie.returnTitle()}");
                }
                
            }
        }

        private static void InsertSerie()
        {
            Console.WriteLine("Inserir nova série"); 

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Gender),i)}");
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int enterGender = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string enterTitle = Console.ReadLine();

            Console.Write("Digite o Ano de Início da série: ");
            int enterYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string enterDescription = Console.ReadLine();

            Series newSerie = new Series(id: repository.NextId(),
                gender: (Gender)enterGender,
                title: enterTitle,
                year: enterYear,
                description: enterDescription);
            repository.Insert(newSerie);
        }

        private static void UpdateSerie()
        {
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Gender), i)}");
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int enterGender = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string enterTitle = Console.ReadLine();

            Console.Write("Digite o Ano de Início da série: ");
            int enterYear = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string enterDescription = Console.ReadLine();

            Series updateSerie = new Series(id: idSerie,
                gender: (Gender)enterGender,
                title: enterTitle,
                year: enterYear,
                description: enterDescription);
            repository.Update(idSerie, updateSerie);
        }

        private static void DeleteSerie()
        {
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());
                      
            Console.Write("Confirmar a exclusão [S/N]: ");
            char answer = char.Parse(Console.ReadLine().ToUpper().Trim());
            if(answer == 'S')
            {
                repository.Delete(idSerie);
            }
            else
            {
                Console.WriteLine("Deleção cancelada:");
            }
        }

        private static void ShowSerie()
        {
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repository.ReturnById(idSerie);

            Console.WriteLine(serie);
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Series!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar sére");
            Console.WriteLine("C- Limpar Telsa");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;

        }
    }
}
