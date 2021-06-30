import java.awt.*;
public class Wall
{
	private int[]rows;
	private int[]cols;
	private int r;
	private int g;
	private int b;
	private String side;
	private int size;
	private int dis;
	public Wall(int[]rows, int[]cols,int r, int g, int b, String side, int size, int dis)
	{
		this.rows = rows;
		this.cols = cols;
		this.r = r;
		this.g = g;
		this.b = b;
		this.side = side;
		this.size = size;
		this.dis = dis;
	}
	public int[] getRow()
	{
		return rows;
	}
	public int[] getCol()
	{
		return cols;
	}
	public String getSide()
	{
		return side;
	}
	public Polygon getPolygon()
	{
		if(getSide().equals("rf") || getSide().equals("rt") || getSide().equals("lt") || getSide().equals("lf"))
		{
			return new Polygon(getCol(), getRow(), 3);
		}
		return new Polygon(getCol(), getRow(),  4);
	}
	public int getDis()
	{
		return dis;
	}
	public GradientPaint getPaint()
	{
		int r2 = r - getDis();
		int g2 = g - getDis();
		int b2 = b - getDis();
		switch(getSide())
		{
			case "f":
				return new GradientPaint(cols[0],rows[0],new Color(r,g,b),cols[0],rows[1],new Color(r2,g2,b2));
			case "t":
				return new GradientPaint(cols[0],rows[0],new Color(r,g,b),cols[0],rows[1],new Color(r2,g2,b2));
			case "e":
				return new GradientPaint(cols[0],rows[0],new Color(r,g,b),rows[1],cols[0],new Color(r2,g2,b2));
			case "r":
				return new GradientPaint(cols[1],rows[0],new Color(r,g,b),cols[0],rows[0],new Color(r2,g2,b2));
			case "rp":
				return new GradientPaint(cols[1],rows[0],new Color(r,g,b),cols[0],rows[0],new Color(r2,g2,b2));
			case "rt":
				return new GradientPaint(cols[1],rows[0],new Color(r,g,b),cols[0],rows[0],new Color(r2,g2,b2));
			case "rf":
				return new GradientPaint(cols[1],rows[0],new Color(r,g,b),cols[0],rows[0],new Color(r2,g2,b2));
			case "Light":
				return new GradientPaint(cols[0],rows[0],new Color(r,g,b),cols[0],rows[0],new Color(r,g,b));
			default:
				return new GradientPaint(cols[0],rows[0],new Color(r,g,b),cols[1],rows[0],new Color(r2,g2,b2));
		}
	}
}