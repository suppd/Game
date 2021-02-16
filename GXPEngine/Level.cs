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
        //game.AddChild(background);

        game.AddChild(player);

        Boss1 Boss1 = new Boss1(1700, 700, player);
        game.AddChild(Boss1);


        Platform platform1 = new Platform(450 , game.height / 2 + 300);
        game.AddChild(platform1);

        Platform platform2 = new Platform( 800, game.height / 2 + 100);
        game.AddChild(platform2);

        Platform platform3 = new Platform( 1250, game.height / 2 + 300);
        game.AddChild(platform3);


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











