using System;

class Player
{
    public string Name;
    public int Level;

    public Player(string name, int level)
    {
        Name = name;
        Level = level;
    }
    public void LevelUp()
    {
        Level++;
    }

    public void ShowLevel()
    {
        Console.WriteLine($"Уровень: {Level}");
    }
    public void ShowName()
    {

        Console.WriteLine($"Игрок: {Name}");

    }
    public void ShowInfo()
    {
        Console.WriteLine($"{Name} — {Level} уровень");
    }
}

class Program
{
    static void ShowPlayers(List<Player> players)
    {
        foreach(var player in players)
        {
            Console.WriteLine($"{player.Name} - {player.Level} уровень");
        }
    }

    static void AddPlayer(List<Player> players)
    {
        Console.WriteLine("Введите имя: ");
        string name = Console.ReadLine();
        if (players.Any(player => player.Name == name))
        {
            Console.WriteLine("Такое имя уже есть");
        }
        else
        {
            int level = 0;
            Console.WriteLine("Введите уровень: ");
            while(!int.TryParse(Console.ReadLine(), out level))
            {
                Console.WriteLine("Введите корректное число");
            }
            players.Add(new Player(name, level));
        }
    }

    static void FindPlayer(List<Player> players)
    
    {
        Console.WriteLine("Введите имя");
        string name = Console.ReadLine();
        var result = players.FirstOrDefault(player => player.Name == name);
        if (result!=null)
        {
            Console.WriteLine("Игрок найден" + 
            $"\nИмя: {result.Name}" + 
            $"\nУровень: {result.Level}");
        }
        else
        {
            Console.WriteLine("Игрок не найден");
        }
    }
    
    static void DeletePlayer(List<Player> players)
    {
        Console.WriteLine("Введите имя игрока");
        string searchName = Console.ReadLine();
        var exist = players.FirstOrDefault(player => player.Name == searchName);
        if (exist!= null)
        {
            players.Remove(exist);
            Console.WriteLine("Игрок удалён");
        }
        else
        {
            Console.WriteLine("Игрок не найден");
        }
    }
    
    
    static void LvlUpNewPlayers(List<Player> players)
    {   
        int lvlUp = 5;
        var newbies = players.Where(player => player.Level < 10);
        foreach(var player in newbies)
        {
            player.Level += lvlUp;
        }
    }
   
    static void ShowStatistics(List<Player> players)
    {
        if (players.Count < 1)
        {
            Console.WriteLine("Игроков нет");
        }
        else
        {
            int playersNumber = players.Count;
            Console.WriteLine($"Количество игроков: {playersNumber}");

            var averageLvl = players.Average(player => player.Level);
            Console.WriteLine($"Средний уровень: {averageLvl}");

            var maxLvl = players.Max(player => player.Level);
            Console.WriteLine($"Максимальный уровень: {maxLvl}");

            var minLvl = players.Min(player => player.Level);
            Console.WriteLine($"Минимальный уровень: {minLvl}");

            var sumLvl = players.Sum(player => player.Level);
            Console.WriteLine($"Суммарный уровень: {sumLvl}");
        }
    }
    
    static void ShowPlayersAboveLevel(List<Player> players)
    {
        int overLevel;
        Console.WriteLine("Введите уровень: ");
        while(!int.TryParse(Console.ReadLine(), out overLevel) || overLevel < 0)
        {
            Console.WriteLine("Введите число");
        }
        var overLevelPlayers = players
        .Where(player => player.Level > overLevel)
        .OrderByDescending(player => player.Level);
        if (overLevelPlayers.Any())
        {
            foreach(var player in overLevelPlayers)
            {
                Console.WriteLine($"{player.Name} - {player.Level} - уровень");
            }
        }
        else
        {
            Console.WriteLine($"Игроков с уровнем выше {overLevel} нет");
        }
    }
   
    static void GroupPlayers(List<Player> players)
    {
        var groups = players
        .GroupBy(player => player.Level)
        .OrderByDescending(group => group.Key);

        foreach (var group in groups)
        {
            Console.WriteLine($"Уровень {group.Key}:");
            foreach(var player in group)
            {
                Console.WriteLine(player.Name);
            }
        }
    }

    static void  Main(string[] args)
    {
        List<Player> players = new List<Player>()
        {
            new Player("Alex", 15),
            new Player("Gogis", 41),
            new Player("Andrew", 1),
            new Player("Kukis", 74),
            new Player("Bob", 41),
            new Player("Pusya", 14) 
        };

        const int exit = 9;
        int choice = 0;

        while(choice != exit)
        {
            Console.WriteLine($"1.Показать всех игроков\n2.Добавить игрока\n3.Найти игрока\n4.Удалить игрока\n5.Игроки выше уровня\n6.Статистика\n7.Повысить уровень новичкам\n8.Сгрупировать по уровню\n{exit}.Выход");
            while(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > exit)
            {
                Console.WriteLine("Введите корректное число");
            }

            switch(choice)
            {
                case 1:
                ShowPlayers(players);
                break;

                case 2:
                AddPlayer(players);
                break;
                
                case 3:
                FindPlayer(players);
                break;

                case 4:
                DeletePlayer(players);
                break;

                case 5:
                ShowPlayersAboveLevel(players);
                break;

                case 6:
                ShowStatistics(players);
                break;

                case 7:
                LvlUpNewPlayers(players);
                break;

                case 8:
                GroupPlayers(players);
                break;
            }
        }
    }

    // Изменение через GitHub
}

