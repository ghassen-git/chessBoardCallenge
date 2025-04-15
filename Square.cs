namespace challenge_1_Csharp;

public class Square
{
    Dictionary<int, string> path = new Dictionary<int, string>();
    public int x;
    public int y;
public int pathlen;
    public Square(int x, int y,int pathlen)
    {
        this.x = x;
        this.y = y;
        this.pathlen = pathlen;
    }
    
   
}