using System.Text;

namespace challenge_1_Csharp;

public class utilities
{
    private static StringBuilder sb = new StringBuilder();
    private static string directory = @"../../../../chessBorard_Preview";
    private static string pathname="chessboard.txt";
private static List<Square> points = new List<Square>();
    internal static void addTOPath(Square point)
    {
        points.Add(point);
        
    }
 
    internal static void checkForExistingFile()
    {
        string path = directory +"/"+ pathname;
        bool exists = File.Exists(path);
        if (exists)
        {
  File.Delete(path);  
  File.WriteAllText(path,sb.ToString());
        }
        else
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(directory);
                Console.WriteLine("Created directory!");
            }
            File.WriteAllText(path,sb.ToString());
        }
    }

    internal static void constructPath(Square destination)
    {
        points.Reverse();
        
        for (int i = destination.y+2; 0 <=i ; i--)
        {
            for (int j =0 ; j <=destination.x+2 ; j++)
            {
                    sb.Append(" .");
                foreach (var point in points)
                {
                    if (i==point.y && j==point.x)
                    {
                        sb.Remove(sb.Length - 1, 1);
                        sb.Append(point.pathlen>9 ? point.pathlen.ToString() : "0" + point.pathlen.ToString());
                        break;
                    }
                   
                }
                
                
            }
            sb.AppendLine();
            
        }
       
    }
}