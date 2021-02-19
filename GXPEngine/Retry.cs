using System;
using GXPEngine;
using System.Drawing;

public class Retry : GameObject
{
    ScoreManager scoreManager = new ScoreManager();
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
        scoreManager = new ScoreManager();
        scoreManager.x = _button.x - 100;
        scoreManager.y = _button.y + 100;
        AddChild(scoreManager);

    }

    void Update()
    {

        AddChild(scoreManager);
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