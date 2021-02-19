using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class HUD_Boss : Canvas
{

    private BaseBoss _boss;
    public HUD_Boss(BaseBoss boss) : base(200, 200, false)
    {
        SetOrigin(width / 2, height / 2);
        _boss = boss;
        scale = 3;
    }

    void Update()
    {
        x = _boss.x;
        y = _boss.y - 200;

        //HP bar
        graphics.Clear(Color.Empty);
        if (_boss != null)
        {
            graphics.DrawString("HP:" + _boss.GetHP(), SystemFonts.DefaultFont, Brushes.White, 0, 0);
        }

    }

}






public class HUD_Player : AnimationSprite
{

    private Player _player;
    public HUD_Player(Player player) : base("HP.png",2,3,5, false, false)
    {
        SetOrigin(width / 2, height / 2);
        _player = player;
        this.scale = 1;
        x = 200;
        y = 100;
    }

    void Update()
    {
        if (_player.GetLifes() >= 5)
        {
            SetFrame(4);
        }
        if (_player.GetLifes() == 4)
        {
            SetFrame(3);
        }
        if (_player.GetLifes() == 3)
        {
            SetFrame(2);
        }
        if (_player.GetLifes() == 2)
        {
            SetFrame(1);
        }
        if (_player.GetLifes() == 1)
        {
            SetFrame(0);
        }




    }

}



public class HUD_Score : Canvas
{

    private MyGame _myGame;
    public HUD_Score(MyGame myGame) : base(400, 400, false)
    {
        SetOrigin(width / 2, height / 2);
        _myGame = myGame;
        x = 1000;
        y = 500;
    }

    void Update()
    {


        //HP bar
        graphics.Clear(Color.Empty);
        if (_myGame != null)
        {

            graphics.DrawString("Score:" + _myGame.GetScore(), SystemFonts.DefaultFont, Brushes.Red, 0, 0);
        }



    }




}



public class HUD_Retry : Canvas
{
    private ScoreManager scoremanager;
    public HUD_Retry(ScoreManager _scoremanager) : base(400, 400, false)
    {
        SetOrigin(width / 2, height / 2);

        x = 1000;
        y = 500;
        scoremanager = _scoremanager;
    }

    void Update()
    {


        graphics.Clear(Color.Empty);


        if (scoremanager != null)
        {
            graphics.DrawString("Your Score is:" + scoremanager.getScore(), SystemFonts.DefaultFont, Brushes.White, 0, 0);
        }



    }




}