using System;									
using System.Drawing;                           
using GXPEngine;
using TiledMapParser;

public class MyGame : Game
{
	public MyGame() : base(1920, 1080, true, false)
	{
		Player player = new Player(100, 900);
		AddChild(player);



	}



	//mandatory for the game to start
	static void Main()
	{
		new MyGame().Start();
	}

}