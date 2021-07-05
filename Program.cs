using System;

namespace DIO.Series
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
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
                        CreateSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSeries();
                        break;
                    case "5":
                        ViewSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
        }

        public static void ListSeries()
        {
            Console.WriteLine("Listar séries");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var series in list)
            {
                var deleted = series.getDeleted();

                Console.WriteLine("#ID {0}: - {1} - {2}", series.getId(), series.getTitle(), (deleted ? "Excluído" : ""));
            }
        }

        public static void CreateSeries()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Gender), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int inputGender = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string inputTitle = Console.ReadLine();

            Console.WriteLine("Digite o ano  de início da série: ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string inputDescription = Console.ReadLine();

            Series newSeries = new Series(id: repository.NextId(),
                                        gender: (Gender)inputGender, title: inputTitle, year: inputYear, description: inputDescription);
            repository.Create(newSeries);
        }

        public static void UpdateSeries()
        {
            Console.WriteLine("Digite o ID da série. ");
            int inputId = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Gender), i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int inputGender = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string inputTitle = Console.ReadLine();

            Console.WriteLine("Digite o ano  de início da série: ");
            int inputYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string inputDescription = Console.ReadLine();

            Series newSeries = new Series(id: inputId, gender: (Gender)inputGender, title: inputTitle, year: inputYear, description: inputDescription);
            repository.Update(inputId, newSeries);
        }

        public static void DeleteSeries()
        {
            Console.WriteLine("Digite o ID da série");
            int inputId = int.Parse(Console.ReadLine());

            repository.Delete(inputId);
        }

        public static void ViewSeries(){
            Console.WriteLine("Digite o ID da série");
            int inputId = int.Parse(Console.ReadLine());

            var series = repository.GetById(inputId);

            Console.WriteLine(series);
        }

        public static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries ao seu dispor!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
