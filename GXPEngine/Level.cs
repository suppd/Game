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
        Background background = new Background(0, 0);
        game.AddChild(background);

        game.AddChild(player);

        Boss1 Boss1 = new Boss1(1700, 700, player);
        game.AddChild(Boss1);


    }

}

public class Background : Sprite
{
    public Background(float NewX,float NewY) : base("Background.png", false, false)
    {
        this.x = NewX;
        this.y = NewY;
    }

}











