using System;									
using System.Drawing;                           
using GXPEngine;
using TiledMapParser;

public class MyGame : Game
{
	public MyGame() : base(1920, 1080, false, false)
	{
		Level level = new Level();
		AddChild(level);
	}



	//mandatory for the game to start
	static void Main()
	{
		new MyGame().Start();
	}

}