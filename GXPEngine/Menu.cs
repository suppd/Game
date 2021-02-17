using System;
using GXPEngine;
using System.Drawing;

public class Menu : GameObject
{
    Button _button;

    public Menu() : base()
    {
        _button = new Button();
        AddChild(_button);
        _button.x = (game.width - _button.width) / 2;
        _button.y = (game.height - _button.height) / 2;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_button.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                startGame();
                DestroyMenu();
                _button.visible = false;
            }
        }
    }

    void startGame()
    {
        Level level = new Level();
        game.AddChild(level);
    }

    void DestroyMenu()
    {
        LateDestroy();
    }

}