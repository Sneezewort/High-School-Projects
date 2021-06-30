import java.awt.*;
public class Explorer
{
    private Location loc;
    private int dir;
    private int size;
    private Color color;
    public Explorer(Location loc, int dir, int size, Color color)
    {
        this.loc = loc;
        this.dir = dir;
        this.size = size;
        this.color = color;
    }
    public Color getColor()
    {
        return color;
    }
    public int getDir()
    {
        return dir;
    }
    public Location getLoc()
    {
        return loc;
    }
    public int getSize()
    {
        return size;
    }
    public void move(int key, char[][] maze)
    {
        int x = getLoc().getX();
        int y = getLoc().getY();
        if (key == 38)
        {
            if (dir == 0)
            {
                if (x > 0 && (maze[x - 1][y] == ' ' || maze[x - 1][y] == 'F'))
                    getLoc().setX(-1);
            }
            if (dir == 1)
            {
                if (y < maze[0].length - 1 && (maze[x][y + 1] == ' ' || maze[x][y + 1] == 'F'))
                    getLoc().setY(1);
            }
            if (dir == 2)
            {
                if (x < maze.length - 1 && (maze[x + 1][y] == ' ' || maze[x + 1][y] == 'F'))
                    getLoc().setX(1);
            }
            if (dir == 3)
            {
                if (y > 0 && (maze[x][y - 1] == ' ' || maze[x][y - 1] == 'F'))
                    getLoc().setY(-1);
            }
        }
        if (key == 37)
        {
            dir--;
            if (dir < 0)
                dir = 3;
        }
        if (key == 39)
        {
            dir++;
            if (dir > 3)
                dir = 0;
        }
    }
    public Rectangle getRect()
    {
        int x = getLoc().getX();
        int y = getLoc().getY();
        return new Rectangle(y * size + size, x * size + size, size, size);
    }
}