import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.io.*;
import java.util.ArrayList;

public class MazeActivity extends JPanel implements KeyListener
{
    JFrame frame;
    char[][] maze = new char[16][44];
    Explorer explorer;
    int x=1;
    int y=0;
    int xl = 0;
    int yl = 0;
    int depth = 3;
    int dir=1;
    int x1 = (int)(Math.random()*120);
    int x2 = (int)(Math.random()*120);
    int moves=0;
    int counter=0;
    int dis = 50;
    int mainDis = 50;
    int temp = 0;
    int paint = 40;
    int size = 20;
    boolean firstPerson = false;
    boolean finish = false;
    boolean l1 = false;
    boolean flash;
    Location end;
    Font font;
    ArrayList<Wall> walls;
    ArrayList<Location>locationList;
    ArrayList<Location>trail;
    public MazeActivity()
    {

        explorer = new Explorer(new Location(x,y),dir,size,Color.GREEN);
        trail = new ArrayList<Location>();
        locationList = new ArrayList<Location>();
		setBoard();
        frame = new JFrame("Maze Project");
        frame.add(this);
        frame.setSize(950,900);
        frame.addKeyListener(this);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setVisible(true);
    }
    public void setBoard()
    {
        try
        {
            BufferedReader input = new BufferedReader(new FileReader("maze.txt"));
            String text;
            int x = 0;
            firstPerson = false;
            while((text=input.readLine())!=null)
            {
                for(int y=0;y<text.length();y++)
                    maze[x][y] = text.charAt(y);
                x++;
            }
            if(firstPerson)
				drawWalls();
        }
        catch (Exception e)
        {
            System.out.println("An Exor Has Oyuxed");
        }
    }
    public void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        Graphics2D g2 = (Graphics2D)g;
        g2.setColor(Color.BLACK);
        g2.fillRect(0,0,1200,900);
		dir = explorer.getDir();
        g2.setColor(Color.CYAN);
        g2.drawString("Moves Made: "+moves, 800, 400);
        if(!firstPerson)
        {
            g2.setColor(Color.CYAN);
            for (int y = 0; y < maze[0].length; y++)
            {
                for (int x = 0; x < maze.length; x++)
                {
                    if (maze[x][y] == ' ' || maze[x][y]=='F')
                    {
                        g2.fillRect(y * size + size, x * size + size, size, size);
                        locationList.add(new Location(x,y));
					}
                    else
                    	g2.drawRect(y * size + size, x * size + size, size, size);
                    if(maze[x][y]=='F')
                    {
                    	end = new Location(x,y);
                    	g2.setColor(Color.WHITE);
                    	g2.fillRect(y * size + size, x * size + size, size, size);
                    	g2.setColor(Color.CYAN);
					}
                }
            }
			xl = locationList.get(x1).getX();
			yl = locationList.get(x1).getY();
            if(!(l1))
            {
				g2.setColor(Color.YELLOW); //Red
				g2.fillRect(yl * size + size, xl * size + size, size, size);
			}
			else
			{
				g2.setColor(new Color(255,182,18));
				g2.fillRect(yl * size + size, xl* size + size, size, size);
			}
            g2.setColor(explorer.getColor());
            g2.fill(explorer.getRect());
            trail.add(new Location(explorer.getLoc().getX(), explorer.getLoc().getY()));
			for(int i = 0; i<trail.size()-1; i++)
			{
				int tx = trail.get(i).getX();
				int ty = trail.get(i).getY();
				g2.setColor(Color.BLUE);
				g2.fillRect(ty * size + size+5, tx * size+size+5, 10, 10);
			}
       }
       else
       {
            g2.setColor(Color.BLACK);
            g2.fillRect(0,0,1200,900);
            g2.setColor(Color.GREEN);
       		g2.drawString("Moves Made: "+moves, 800, 400);
            for(int fov=0;fov<walls.size();fov++)
            {
				g2.setPaint(walls.get(fov).getPaint());
				g2.fillPolygon(walls.get(fov).getPolygon());
				g2.setColor(Color.BLACK);
                g2.drawPolygon(walls.get(fov).getPolygon());
            }
        }
        if(explorer.getLoc().getX() == end.getX() && explorer.getLoc().getY() == end.getY())
        {
			if(firstPerson)
				g2.setColor(Color.GREEN);
			else
				g2.setColor(Color.CYAN);
			font = new Font("Arial", Font.BOLD, 20);
			g2.setFont(font);
			g2.drawString("Good Job!", 680, 400);
			font = new Font("Arial", Font.BOLD, 15);
			g2.drawString("Press Space to Play Again", 680, 500);
			finish = true;
		}
		if((explorer.getLoc().getX() == xl && explorer.getLoc().getY() == yl) && !(l1))
		{
			l1 = true;
			mainDis = 50;
			temp = 50;
			if(flash)
				mainDis = 0;
		}
    }
	public void drawWalls()
	{
		walls = new ArrayList<Wall>();
		int x = explorer.getLoc().getX();
		int y = explorer.getLoc().getY();
		trail.add(new Location(x,y));
		int dir = explorer.getDir();
		if((explorer.getLoc().getX() == xl && explorer.getLoc().getY() == yl) && !(l1))
		{
			l1 = true;
			mainDis = 50;
			temp = 50;
			if(!flash)
				depth++;
		}
		switch(dir)
		{
			case 0:
				for(int i = 0; i<depth; i++)
				{
					try
					{
						if(maze[x-i][y]=='#')
						{
							walls.add(getEnd(i));
							break;
						}
						if(maze[x-i][y-1]=='#')
							walls.add(getLeft(i));
						else
						{
							walls.add(getLeftSide(i+1));
							walls.add(getLeftTop(i+1));
							walls.add(getLeftFloor(i+1));
						}
						if(maze[x-i][y+1]=='#')
							walls.add(getRight(i));
						else
						{
							walls.add(getRightSide(i+1));
							walls.add(getRightTop(i+1));
							walls.add(getRightFloor(i+1));
						}
						walls.add(getTop(i));
						walls.add(getFloor(i));
						if((x-i==xl && y==yl) && !(l1))
						{
							walls.add(getLight(i));
						}
						else if((x-i==xl && y==yl) && (l1))
						{
							walls.add(getLighted(i));
						}
					}catch(Exception e)
					{
					}
				}
				break;
			case 1:
				for(int i = 0; i<depth; i++)
				{
					try
					{
						if(maze[x][y+i]=='#')
						{
							walls.add(getEnd(i));
							break;
						}
						if(maze[x-1][y+i]=='#')
							walls.add(getLeft(i));
						else{
							walls.add(getLeftSide(i+1));
							walls.add(getLeftTop(i+1));
							walls.add(getLeftFloor(i+1));
						}
						if(maze[x+1][y+i]=='#')
							walls.add(getRight(i));
						else{
							walls.add(getRightSide(i+1));
							walls.add(getRightTop(i+1));
							walls.add(getRightFloor(i+1));
						}
						walls.add(getTop(i));
						walls.add(getFloor(i));
						if((x==xl && y+i==yl) && !(l1))
						{
							walls.add(getLight(i));
						}
						else if((x==xl && y+i==yl) && (l1))
						{
							walls.add(getLighted(i));
						}
					}catch(Exception e)
					{
					}
				}
				break;
			case 2:
				for(int i = 0; i<depth; i++)
				{
					try
					{
						if(maze[x+i][y]=='#')
						{
							walls.add(getEnd(i));
							break;
						}
						if(maze[x+i][y+1]=='#')
							walls.add(getLeft(i));
						else
						{
							walls.add(getLeftSide(i+1));
							walls.add(getLeftTop(i+1));
							walls.add(getLeftFloor(i+1));
						}
						if(maze[x+i][y-1]=='#')
							walls.add(getRight(i));
						else
						{
							walls.add(getRightSide(i+1));
							walls.add(getRightTop(i+1));
							walls.add(getRightFloor(i+1));
						}
						walls.add(getTop(i));
						walls.add(getFloor(i));
						if((x+i==xl && y==yl) && !(l1))
						{
							walls.add(getLight(i));
						}
						else if((x+i==xl && y==yl) && (l1))
						{
							walls.add(getLighted(i));
						}
					}catch(Exception e)
					{
					}
				}
				break;
			case 3:
				for(int i = 0; i<depth; i++)
				{
					try
					{
						if(maze[x][y-i]=='#')
						{
							walls.add(getEnd(i));
							break;
						}
						if(maze[x+1][y-i]=='#')
							walls.add(getLeft(i));
						else
						{
							walls.add(getLeftSide(i+1));
							walls.add(getLeftTop(i+1));
							walls.add(getLeftFloor(i+1));
						}
						if(maze[x-1][y-i]=='#')
							walls.add(getRight(i));
						else
						{
							walls.add(getRightSide(i+1));
							walls.add(getRightTop(i+1));
							walls.add(getRightFloor(i+1));
						}
						walls.add(getTop(i));
						walls.add(getFloor(i));
						if((x==xl && y-i==yl) && !(l1))
						{
							walls.add(getLight(i));
						}
						else if((x==xl && y-i==yl) && (l1))
						{
							walls.add(getLighted(i));
						}
					}catch(Exception e)
					{
					}
				}
				break;
		}
	}
    public void keyPressed(KeyEvent e)
    {
		if(!finish)
		{
			if(e.getKeyCode() == 37 || e.getKeyCode() == 38 || e.getKeyCode() == 39)
				explorer.move(e.getKeyCode(),maze);
			 if(e.getKeyCode()==38)
	        {
				moves++;
				counter++;
				if(counter > 19 && depth == 3)
				{
					depth = 2;
					counter = 0;
				}
			}
			if(e.getKeyCode() == 70)
			{
				flash = !flash;
				if(flash)
				{
					temp = depth;
					depth = 5;
				}
				else
				{
					depth = temp;
				}
			}
		}
		else{
			if(e.getKeyCode()==32)
			{
				explorer = new Explorer(new Location(1,0),dir,size,Color.GREEN);
				setBoard();
				trail.clear();
				locationList.clear();
				l1 = false;
				depth = 3;
				moves = 0;
				mainDis = 50;
				finish = false;
			}
		}
        if(e.getKeyCode() == 32)
        	firstPerson = !firstPerson;
        if(firstPerson)
        	drawWalls();
        repaint();
    }
    public void keyReleased(KeyEvent e)
    {
	}
    public void keyTyped(KeyEvent e)
    {
	}
    public Wall getLeftSide(int n)
    {
		int[]locX = new int[]{100+dis*n,100+dis*n,700-dis*n,700-dis*n};
		int[]locY = new int[]{dis*n, 50+dis*n, 50+dis*n, dis*n};
		return new Wall(locX, locY, 255-paint*n, 255-paint*n, 255-paint*n,"lp",size,mainDis);
	}
	public Wall getLeft(int n)
	{
		int[]locX = new int[]{100+dis*n,150+dis*n,650-dis*n,700-dis*n};
		int[]locY = new int[]{50+dis*n, 100+dis*n, 100+dis*n, 50+dis*n};
		return new Wall(locX, locY, 255-mainDis*n, 255-mainDis*n, 255-mainDis*n,"l",size,mainDis);
	}
	public Wall getRight(int n)
	{
		int[]locX = new int[]{150+dis*n,100+dis*n,700-dis*n,650-dis*n};
		int[]locY = new int[]{600-dis*n, 650-dis*n, 650-dis*n, 600-dis*n};
		return new Wall(locX, locY, 255-mainDis*n, 255-mainDis*n, 255-mainDis*n,"r",size,mainDis);
	}
	public Wall getRightSide(int n)
	{
		int[]locX = new int[]{100+dis*n,100+dis*n,700-dis*n,700-dis*n};
		int[]locY = new int[]{650-dis*n, 700-dis*n, 700-dis*n, 650-dis*n};
		return new Wall(locX, locY, 255-paint*n, 255-paint*n, 255-paint*n,"rp",size,mainDis);
	}
	public Wall getTop(int n)
	{
		int[]locX = new int[]{100+dis*n, 150+dis*n, 150+dis*n, 100+dis*n};
		int[]locY = new int[]{50+dis*n,100+dis*n,600-dis*n,650-dis*n};
		return new Wall(locX, locY, 255-mainDis*n, 255-mainDis*n, 255-mainDis*n,"t",size,mainDis);
	}
	public Wall getFloor(int n)
	{
		int[]locX = new int[]{700-dis*n, 650-dis*n, 650-dis*n, 700-dis*n};
		int[]locY = new int[]{50+dis*n, 100+dis*n,  600-dis*n, 650-dis*n};
		return new Wall(locX, locY, 255-mainDis*n, 255-mainDis*n, 255-mainDis*n,"f",size,mainDis);
	}
	public Wall getRightTop(int n)
	{
		int[]locX = new int[]{100+dis*n,50+dis*n,100+dis*n};
		int[]locY = new int[]{650-dis*n, 700-dis*n, 700-dis*n};
		return new Wall(locX, locY, 255-paint*n, 255-paint*n, 255-paint*n,"rt",size,mainDis);
	}
	public Wall getRightFloor(int n)
	{
		int[]locX = new int[]{700-dis*n, 750-dis*n, 700-dis*n};
		int[]locY = new int[]{650-dis*n, 700-dis*n, 700-dis*n};
		return new Wall(locX, locY, 255-paint*n, 255-paint*n, 255-paint*n,"rf",size,mainDis);
	}
	public Wall getLeftTop(int n)
	{
		int[]locX = new int[]{50+dis*n, 100+dis*n, 100+dis*n};
		int[]locY = new int[]{dis*n, 50+dis*n, dis*n};
		return new Wall(locX, locY, 255-paint*n, 255-paint*n, 255-paint*n,"lt",size,mainDis);
	}
	public Wall getLeftFloor(int n)
	{
		int[]locX = new int[]{700-dis*n, 700-dis*n, 750-dis*n};
		int[]locY = new int[]{dis*n, 50+dis*n, dis*n};
		return new Wall(locX, locY, 255-paint*n, 255-paint*n, 255-paint*n,"lf",size,mainDis);
	}
	public Wall getEnd(int n)
	{
		int[]locX = new int[]{100+dis*n, 100+dis*n, 700-dis*n, 700-dis*n};
		int[]locY = new int[]{50+dis*n, 650-dis*n,650-dis*n,50+dis*n};
		return new Wall(locX, locY, 255-mainDis*n, 255-mainDis*n, 255-mainDis*n,"e",size,mainDis);
	}
	public Wall getLight(int n)
	{
		int[]locX = new int[]{700-dis*n, 650-dis*n, 650-dis*n, 700-dis*n};
		int[]locY = new int[]{50+dis*n, 100+dis*n,  600-dis*n, 650-dis*n};
		return new Wall(locX, locY, 255,255,0,"Light", size,mainDis);
	}
	public Wall getLighted(int n)
	{
		int[]locX = new int[]{700-dis*n, 650-dis*n, 650-dis*n, 700-dis*n};
		int[]locY = new int[]{50+dis*n, 100+dis*n,  600-dis*n, 650-dis*n};
		return new Wall(locX, locY, 144,238,144,"Light", size,mainDis);
	}
    public static void main(String [] args)
    {
        MazeActivity app = new MazeActivity();
    }
}