using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class Level : GameObject
{
    public Player player = new Player(100, 900);
    Boss1 boss1;
    MyGame mygame;
    Sound Tyler;
    SoundChannel _musicChannel;

    public Level()
    {
        SetupLevel();
    }

    public void muteMusic()
    {
        if (_musicChannel.Volume != 0)
        {
            _musicChannel.Volume = 0f;
        }
        else
        {
            _musicChannel.Volume = 0.1f;
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(Key.T))
        {
            _musicChannel.Volume = _musicChannel.Volume - 0.10f;
        }
        if (Input.GetKeyDown(Key.Y))
        {
            _musicChannel.Volume = _musicChannel.Volume + 0.20f;
        }

        if (Input.GetKeyDown(Key.M))
        {
            _musicChannel.Volume = 0f;
        }

        if (boss1.GetHP() <= 0)
        {
            StopFrankMusic();
            ClearLevel();
            LateDestroy();
            Transition transition = new Transition();
            game.AddChild(transition);
            //Level2 level2 = new Level2();
            //game.AddChild(level2);
        }

        if (player.GetLifes() <= 0)
        {
            StopFrankMusic();
            player.Death();
            LateDestroy();
            ClearLevel();
            Retry retry = new Retry(player);
            game.AddChild(retry);
        }


    }

    void StopFrankMusic()
    {
         _musicChannel.Stop();
    }


    void SetupLevel()
    {
        
        Background background = new Background(0, 0);
        game.AddChild(background);

        Tyler = new Sound("Sounds/Frank/boogaloo.mp3", false, false);
        _musicChannel = Tyler.Play();
        _musicChannel.Volume = 0.10f;

        if (Input.GetKeyDown(Key.M))
        {
            _musicChannel.Volume = 0f;
        }

        boss1 = new Boss1(1700, 700, player);
        game.AddChild(boss1);

        boss1.HP = 300;
        player.Lifes = 5;

        HUD_Boss hud = new HUD_Boss(boss1);
        game.AddChild(hud);


        Platform platform1 = new Platform(450 , game.height / 2 + 300);
        game.AddChild(platform1);

        Platform platform2 = new Platform( 850, game.height / 2 );
        game.AddChild(platform2);

        Platform platform3 = new Platform( 1250, game.height / 2 + 300);
        game.AddChild(platform3);

        game.AddChild(player);

        HUD_Player hud_player = new HUD_Player(player);
        game.AddChild(hud_player);

        HUD_Score hud_score = new HUD_Score(mygame);
        game.AddChild(hud_score);


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
    Sound Kanye;
    SoundChannel _musicChannel;
    Boss2 boss2;
    MyGame mygame;
    public Player player = new Player(100, 900);
    public Level2()
    {
        SetupLevel();
    }

    void SetupLevel()
    {
        Kanye = new Sound("Sounds/Kanye/Vintage.mp3", false, false);
        _musicChannel = Kanye.Play();
        _musicChannel.Volume = 0.10f;

        Background1 background1 = new Background1(0, 0);
        game.AddChild(background1);


        boss2 = new Boss2(1700, 700, player);
        game.AddChild(boss2);

        boss2.HP = 300;
        player.Lifes = 5; 

        HUD_Boss hud = new HUD_Boss(boss2);
        game.AddChild(hud);


        Platform platform1 = new Platform(450, game.height / 2 + 400);
        game.AddChild(platform1);

        Platform platform2 = new Platform(850, game.height / 2 + 100);
        game.AddChild(platform2);

        Platform platform3 = new Platform(1250, game.height / 2 + 400);
        game.AddChild(platform3);


        game.AddChild(player);

        HUD_Player hud_player = new HUD_Player(player);
        game.AddChild(hud_player);

        HUD_Score hud_score = new HUD_Score(mygame);
        game.AddChild(hud_score);



    }

    void Update()
    {
        if (Input.GetKeyDown(Key.T))
        {
            _musicChannel.Volume = _musicChannel.Volume - 0.10f;
        }
        if (Input.GetKeyDown(Key.Y))
        {
            _musicChannel.Volume = _musicChannel.Volume + 0.20f;
        }


        if (boss2.GetHP() <= 0)
        {
            StopKanyeMusic();
            ClearLevel();
            LateDestroy();
            Retry retry = new Retry(player);
            game.AddChild(retry);
        }

        if (player.GetLifes() <= 0)
        {
            StopKanyeMusic();
            player.Death();
            LateDestroy();
            ClearLevel();
            Retry retry = new Retry(player);
            game.AddChild(retry);
        }


    }

    void StopKanyeMusic()
    {
        _musicChannel.Stop();
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






public class Background : Sprite
{
    public Background(float NewX,float NewY) : base("Background.png", false, false)
    {
        this.x = NewX;
        this.y = NewY;
    }

}

public class Background1 : Sprite
{
    public Background1(float NewX, float NewY) : base("Background1.png", false, false)
    {
        this.x = NewX;
        this.y = NewY;
    }

}











