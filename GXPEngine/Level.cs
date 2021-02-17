using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class Level : GameObject
{
    public Player player = new Player(100, 900);
    Boss1 boss1;

    public Level()
    {

        SetupLevel();
    }

    void Update()
    {


        if (boss1.GetHP() <= 0)
        {
            ClearLevel();
            LateDestroy();
            Level2 level2 = new Level2();
            game.AddChild(level2);
        }


    }



    void SetupLevel()
    {
        Background background = new Background(0, 0);
        game.AddChild(background);


 

        boss1 = new Boss1(1700, 700, player);
        game.AddChild(boss1);

        boss1.HP = 100;

        HUD_Boss hud = new HUD_Boss(boss1);
        game.AddChild(hud);


        Platform platform1 = new Platform(450 , game.height / 2 + 400);
        game.AddChild(platform1);

        Platform platform2 = new Platform( 850, game.height / 2 + 100);
        game.AddChild(platform2);

        Platform platform3 = new Platform( 1250, game.height / 2 + 400);
        game.AddChild(platform3);

        game.AddChild(player);

        HUD_Player hud_player = new HUD_Player(player);
        game.AddChild(hud_player);


    }

    //\\----------------------------------------------------------------------------------------------------------------------//
    //-----------------------------------------------Clearlevel()----------------------------------------------------------\\
    //-------------------------------------------------------------------------------------------------------------------------\\
    public void ClearLevel()
    {
        foreach (GameObject child in game.GetChildren())
        {
            child.LateDestroy();
        }
    }
    //\\----------------------------------------------------------------------------------------------------------------------//

}


public class Level2 : GameObject
{
    public Player player = new Player(100, 900);
    public Level2()
    {
        SetupLevel();
    }

    void SetupLevel()
    {
        Background background = new Background(0, 0);
        //game.AddChild(background);


        Boss2 boss2 = new Boss2(1700, 700, player);
        game.AddChild(boss2);

        boss2.HP = 100;

        HUD_Boss hud = new HUD_Boss(boss2);
        game.AddChild(hud);


        Platform platform1 = new Platform(450, game.height / 2 + 400);
        game.AddChild(platform1);

        Platform platform2 = new Platform(850, game.height / 2 + 100);
        game.AddChild(platform2);

        Platform platform3 = new Platform(1250, game.height / 2 + 400);
        game.AddChild(platform3);


        game.AddChild(player);


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











