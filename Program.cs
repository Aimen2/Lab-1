class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\Aimen\OneDrive\Documents\Desktop\CSCI 2910\videogames.csv";
        List<VideoGame> videoGames = ReadVideoGamesFromFile(filePath);
        videoGames = SortByTitle(videoGames);

        // Perform filtering, sorting, and statistics for publishers and genres
        PublisherData(videoGames);
        GenreData(videoGames);

        // Other program logic
    }

    static List<VideoGame> ReadVideoGamesFromFile(string filePath)
    {
        List<VideoGame> videoGames = new List<VideoGame>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Skip the header line
                reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');

                    if (columns.Length >= 9) // Adjust the column count as needed
                    {
                        VideoGame videoGame = new VideoGame
                        {
                            Title = columns[0],
                            Genre = columns[3],
                            Publisher = columns[4],
                            Year = int.Parse(columns[2]),
                            Rating = double.Parse(columns[7]) // Assuming this column contains the Rating
                        };

                        videoGames.Add(videoGame);
                    }
                    else
                    {
                        Console.WriteLine("Skipping invalid row: " + line);
                    }
                }
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error reading the file: " + ex.Message);
        }

        return videoGames;
    }

    static List<VideoGame> SortByTitle(List<VideoGame> videoGames)
    {
        return videoGames.OrderBy(game => game.Title).ToList();
    }

    static void PublisherData(List<VideoGame> videoGames)
    {
        Console.Write("Enter the publisher: ");
        string publisherToCalculate = Console.ReadLine();

        var publisherGames = videoGames
            .Where(game => game.Publisher == publisherToCalculate)
            .OrderBy(game => game.Title)
            .ToList();

        int totalGames = videoGames.Count;
        int publisherGameCount = publisherGames.Count;

        double percentage = (totalGames != 0) ? (double)publisherGameCount / totalGames * 100 : 0;

        Console.WriteLine($"Out of {totalGames} games, {publisherGameCount} are developed by {publisherToCalculate}, which is {percentage:F2}%.");
    }

    static void GenreData(List<VideoGame> videoGames)
    {
        Console.Write("Enter the genre: ");
        string genreToCalculate = Console.ReadLine();

        var genreGames = videoGames
            .Where(game => game.Genre == genreToCalculate)
            .OrderBy(game => game.Title)
            .ToList();

        int totalGames = videoGames.Count;
        int genreGameCount = genreGames.Count;

        double percentage = (totalGames != 0) ? (double)genreGameCount / totalGames * 100 : 0;

        Console.WriteLine($"Out of {totalGames} games, {genreGameCount} are {genreToCalculate} games, which is {percentage:F2}%.");
    }
}