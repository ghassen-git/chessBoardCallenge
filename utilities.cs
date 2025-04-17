using System.Text;

namespace challenge_1_Csharp;

public class utilities
{
    private static string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        , "ChessboardData");
    private static string pathname="chessboard.txt";   
    static string  path = Path.Combine(directory, pathname);
private static List<Square> points = new List<Square>();
    internal static void addTOPath(Square point)
    {
        points.Add(point);
        
    }
 


    internal static void constructPath(Square destination)
    {
        points.Reverse();
        string[,] board = new String [ destination.x + 3, destination.y + 3];
        for (int i = destination.y + 2; 0 <= i; i--)
        {
            for (int j = 0; j <= destination.x + 2; j++)
            {
                board[i, j] = ".";
            }
        }

        foreach (var point in points)
        {
            board[point.x, point.y] = point.pathlen.ToString();
        }
       
        bool exists = File.Exists(path);
        if (exists)
        {
           File.WriteAllText(path,"");
            for (int i = destination.y + 2; 0 <= i; i--)
            {
                for (int j = 0; j <= destination.x + 2; j++)
                {
                    File.AppendAllText(path,board[i,j]);
                }
                File.AppendAllText(path,"\n");
            }
        }
        else
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(directory);
                Console.WriteLine("Created directory!");
            }
            for (int i = destination.y + 2; 0 <= i; i--)
            {
                for (int j = 0; j <= destination.x + 2; j++)
                {
                    File.AppendAllText(path,board[i,j]);
                }
                File.AppendAllText(path,"\n");
            }
            
        }
        
    }
    
}