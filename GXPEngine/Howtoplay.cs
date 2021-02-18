using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class Howtoplay : Sprite
{
    Button button;
    public Howtoplay() : base("howtoplay.png")
    {
        SetOrigin(width / 2, height / 2);

        scale = 1.25f;
        button = new Button();
        button.x = 1775;
        button.y = 50;
        x = game.width / 2;
        y = game.height / 2;
        game.AddChild(button);
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (button.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                LateDestroy();
                Menu menu = new Menu();
                game.AddChild(menu);
            }
        }
    }


}
