public class Location{
	private int x;
	private int y;
	public Location(int x, int y)
	{
		this.x = x;
		this.y = y;
	}
	public void setX(int z){
		x+=z;
	}
	public void setY(int z){
		y+=z;
	}
	public int getX(){
		return x;
	}
	public int getY(){
		return y;
	}
}
