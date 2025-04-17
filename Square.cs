namespace challenge_1_Csharp;

public class Square
{
    public int x;
    public int y;
    public int pathlen;

    public Square(int x, int y, int pathlen)
    {
        this.x = x;
        this.y = y;
        this.pathlen = pathlen;
    }

    public override bool Equals(object obj)
    {
        if (obj is Square other)
        {
            return this.x == other.x && this.y == other.y && this.pathlen == other.pathlen;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y, pathlen);
    }


}
