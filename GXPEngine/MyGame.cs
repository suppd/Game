using System;									
using System.Drawing;                           
using GXPEngine;
using TiledMapParser;

public class MyGame : Game
{
	float Points = 0;
	float Score = 5000;
	float Timer = 0;
	public MyGame() : base(1920, 1080, false, false)
	{
		//Level level = new Level();
		//AddChild(level);

		Menu menu = new Menu();
		AddChild(menu);

	}

	void Update()
    {


    }



	//mandatory for the game to start
	static void Main()
	{
		new MyGame().Start();
	}

	public float GetScore()
    {
		return Points;
    }
}