using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class Transition : GameObject
{
    Button button;
    HUD_Retry hud_retry;
    ScoreManager scoremanager = new ScoreManager();
    
    public Transition()
    {
        button = new Button();
        hud_retry = new HUD_Retry(scoremanager);
        button.x = (game.width - button.width) / 2;
        button.y = (game.height - button.height) / 2;

        AddChild(button);
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
