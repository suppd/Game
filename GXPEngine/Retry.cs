using System;
using GXPEngine;
using System.Drawing;

public class Retry : GameObject
{
    ButtonRetry _button;
    Level level;
    private Player _player;
    MyGame mygame;

    public Retry(Player player) : base()
    {
        _player = player;
        _button = new ButtonRetry();
        AddChild(_button);
        _button.x = (game.width/2);
        _button.y = (game.height/2);

    }

    void Update()
    {
        HUD_Retry hud_retry = new HUD_Retry();
        hud_retry.x = _button.x + 125;
        hud_retry.y = _button.y + 300;
        AddChild(hud_retry);
        if (Input.GetMouseButtonDown(0))
        {
            if (_button.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (level != null)
                {
                    level.LateDestroy();
                    level = null;
                }
            }
            startGame();
            LateDestroy();
            _button.visible = false;
        }


    }


    void startGame()
    {
        Level level = new Level();
        game.AddChild(level);
    }
}