using challenge_1_Csharp;

var path = new Dictionary<Square,Square>();
HashSet<string> visited = new HashSet<string>();
path.Add(new Square(0,0,0),null);
visited.Add("(0,0)");
void calculateMiniMoves()
{

 Console.WriteLine("Enter X");
 int x = int.Parse(Console.ReadLine()?? "0");
 Console.WriteLine("Enter Y");
 int y = int.Parse(Console.ReadLine()?? "0");
 var destination = new Square(x, y,0);

  

 Console.WriteLine(bfs(destination,Shorten_path(destination)));

utilities.constructPath(destination);

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
  
     var current = movesQueue.Dequeue();
     if (current.x == destination.x && current.y == destination.y)
     {
      reconstructPath(current);
      return current.pathlen;
     }

     for (int j = 0; j < 8; j++)
     {
      int nx = current.x + dx[j];
      int ny = current.y + dy[j];
     
      if (nx>=0 && ny>=0 && !visited.Contains($"({nx},{ny})") )
      {
       movesQueue.Enqueue(new Square(nx,ny,current.pathlen+1));

      path.Add(new Square(nx,ny,current.pathlen+1),new Square(current.x,current.y,current.pathlen));
       
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
    path.Add(new Square(start.x +1, start.y +2,start.pathlen+1),new Square(start.x, start.y ,start.pathlen));
    visited.Add($"({ start.x +1},{ start.y +2})");
    start.x +=1;
    start.y += 2;
start.pathlen += 1;

   }
   else
   {
   path.Add(new Square(start.x +2, start.y +1,start.pathlen+1),new Square(start.x, start.y ,start.pathlen));

    visited.Add($"({ start.x + 2},{ start.y + 1})");

    start.x += 2;
    start.y += 1;
    start.pathlen += 1;
   }
  }

 else if (destination.x-7 > start.x && destination.y -7<= start.y)
  {
   path.Add(new Square(start.x +2, start.y -1,start.pathlen+1),new Square(start.x, start.y ,start.pathlen));

   visited.Add($"({start.x + 2},{start.y - 1})");

   start.x += 2;
   start.y -= 1;

   start.pathlen += 1;
   
  }
  else if (destination.x - 7 <= start.x && destination.y - 7 > start.y)
  {
   path.Add(new Square(start.x -1, start.y +2,start.pathlen+1),new Square(start.x, start.y ,start.pathlen));

   visited.Add($"({start.x - 1},{start.y+ 2})");

   start.x -= 1;
   start.y+= 2;
   start.pathlen += 1;
   
   
  }
 }
 return start;
}
void reconstructPath(Square destination)
{

 Square current=destination;
 while (current != null)
 {
  Console.WriteLine($"({current.x},{current.y})");
  utilities.addTOPath(current);
  current=path[current];
 }
}

calculateMiniMoves();