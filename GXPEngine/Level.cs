using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class Level : GameObject
{
    public Player player = new Player(100, 900);
    public Level()
    {
        SetupLevel();
    }

    void SetupLevel()
    {
        
        game.AddChild(player);

        Boss1 Boss1 = new Boss1(game.width / 2, 100, player);
        game.AddChild(Boss1);
    }

}












