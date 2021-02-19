using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class Transition : GameObject
{
    Button button;
    HUD_Retry hud_retry;
    ScoreManager scoremanager = new ScoreManager();
    Backgroundtr background = new Backgroundtr();

    public Transition()
    {
        button = new Button();
        scoremanager = new ScoreManager();
        button.x = (game.width - button.width) / 2;
        button.y = (game.height - button.height) / 2;
        scoremanager.x = button.x - 50 ;
        scoremanager.y = button.y + 200;
        AddChild(button);
        AddChild(background);
        AddChild(scoremanager);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (button.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                StartNextLevel();
                button.visible = false;
                LateDestroy();
            }
        }
    }

    void StartNextLevel()
    {
        Level2 level2 = new Level2();
        game.AddChild(level2);
    }
}




public class Backgroundtr : Sprite
{
    public Backgroundtr() : base("menuL.png")
    {

    }
}
