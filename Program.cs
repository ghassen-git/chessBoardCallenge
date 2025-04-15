using challenge_1_Csharp;
var path = new Dictionary<string,string>();
HashSet<string> visited = new HashSet<string>();
path.Add("(0,0)","");

void calculateMiniMoves()
{

 Console.WriteLine("Enter X");
 int x = int.Parse(Console.ReadLine()?? "0");
 Console.WriteLine("Enter Y");
 int y = int.Parse(Console.ReadLine()?? "0");
 var destination = new Square(x, y,0);

  

 Console.WriteLine(bfs(destination,Shorten_path(destination)));
}

int bfs( Square destination ,Square start)
{

   int[] dx= [1,1,-1,-1,2,2,-2,-2];
   int[] dy= [2,-2,2,-2,1,-1,1,-1];
  


   Queue<Square> movesQueue = new Queue<Square>();
   movesQueue.Enqueue(start);
   
   while (movesQueue.Count > 0)
   {
    
    int size = movesQueue.Count;
  
     Square current = movesQueue.Dequeue();
     if (current.x == destination.x && current.y == destination.y)
     {
      reconstructPath($"({current.x},{current.y})");
      return current.pathlen;
     }

     for (int j = 0; j < 8; j++)
     {
      int nx = current.x + dx[j];
      int ny = current.y + dy[j];
     
      if (nx>=0 && ny>=0 && !visited.Contains($"({nx},{ny})") )
      {
       movesQueue.Enqueue(new Square(nx,ny,current.pathlen+1));

      path.Add($"({nx},{ny})",$"({current.x},{current.y})");
       
       visited.Add($"({nx},{ny})");
      }
     
      
    }
    
    
   }

   return 0;
 }

Square Shorten_path( Square destination )
{
 Square start = new Square(0,0,0);
 while (destination.x -7 > start.x || destination.y -7> start.y)
 {
  if (destination.x -7 > start.x && destination.y-7 > start.y)
  {
   if (destination.x-7-start.x<destination.y-7-start.y)
   {
    path.Add($"({ start.x +1},{ start.y +2})",$"({start.x},{start.y})");
    visited.Add($"({ start.x +1},{ start.y +2})");
    start.x +=1;
    start.y += 2;
start.pathlen += 1;

   }
   else
   {
    path.Add($"({ start.x + 2},{ start.y + 1})",$"({start.x},{start.y})");
    visited.Add($"({ start.x + 2},{ start.y + 1})");

    start.x += 2;
    start.y += 1;
    start.pathlen += 1;
   }
  }

 else if (destination.x-7 > start.x && destination.y -7<= start.y)
  {
   path.Add($"({start.x + 2},{start.y - 1})",$"({start.x},{start.y})");
   visited.Add($"({start.x + 2},{start.y - 1})");

   start.x += 2;
   start.y -= 1;

   start.pathlen += 1;
   
  }
  else if (destination.x - 7 <= start.x && destination.y - 7 > start.y)
  {
   path.Add($"({start.x - 1},{start.y+ 2})",$"({start.x},{start.y})");
   visited.Add($"({start.x - 1},{start.y+ 2})");

   start.x -= 1;
   start.y+= 2;
   start.pathlen += 1;
   
   
  }
 }
 return start;
}
void reconstructPath(string destination)
{
 string current=destination;
 while (current != "")
 {
  Console.WriteLine(current);
  current=path[current];
 }
}

calculateMiniMoves();