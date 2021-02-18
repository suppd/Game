using System;
using GXPEngine;
using System.Drawing;

public class Menu : GameObject
{
    Sound Ping;
    Button button1;
    ButtonHow button2;
    ButtonQuit button3;
    MenuSpr menu;
    ButtonVolume buttonvolume;
    ButtonVolumeNot buttonvolumenot;
    private Level _level;
    public Menu() : base()
    {

        button1 = new Button(); //start
        button2 = new ButtonHow(); //how to play
        button3 = new ButtonQuit(); //quit
        buttonvolume = new ButtonVolume();
        buttonvolumenot = new ButtonVolumeNot();

        AddChild(button1);
        AddChild(button2);
        AddChild(button3);


        button1.x = (game.width - button1.width) / 2;
        button1.y = (game.height - button1.height + 200) / 2 ;

        button2.x = (game.width - button2.width) / 2 + 110;
        button2.y = ((game.height - button2.height) / 2 + 300);

        button3.x = (game.width - button3.width) / 2 + 110;
        button3.y = ((game.height - button3.height) / 2 + 500);

        buttonvolume.x =  60;
        buttonvolume.y =  900;

        buttonvolumenot.x = 60;
        buttonvolumenot.y = 900;

        menu = new MenuSpr(0,0);
        AddChild(menu);
        AddChild(buttonvolume);
        AddChild(buttonvolumenot);


        buttonvolumenot.visible = false;

    }
    void Update()
    {
        Ping = new Sound("Sounds/menu/menu.mp3", false, false);
        if (Input.GetMouseButtonDown(0))
        {
            if (button1.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                startGame();
                DestroyMenu();
                button1.visible = false;;
                
            }

            if (button2.HitTestPoint(Input.mouseX, Input.mouseY))
            {

                button2.visible = false;
                GoHowtoPlay();
                DestroyMenu();

            }

            if (button3.HitTestPoint(Input.mouseX, Input.mouseY))
            {

                button3.visible = false;
                game.Destroy();
            }

            if (buttonvolumenot.visible == false)
            {
                if (buttonvolume.HitTestPoint(Input.mouseX, Input.mouseY))
                {
                    StopMusic(_level);
                    buttonvolumenot.visible = true;
                    buttonvolume.visible = false;
                }
            }
            else
            {
                buttonvolumenot.visible = false;
                buttonvolume.visible = true;
            }

        }
    }

    void startGame()
    {
        _level = new Level();
        game.AddChild(_level);
    }

    void DestroyMenu()
    {
        LateDestroy();
    }


    void GoHowtoPlay()
    {
        Howtoplay howtoplay = new Howtoplay();
        game.AddChild(howtoplay);
    }
    void StopMusic(Level level)
    {
        level = _level;
        if (level != null)
        {
            level.muteMusic();
        }
    }
}


public class MenuSpr : Sprite
{

    public MenuSpr(float NewX= 0, float NewY= 0) : base("MenuS.png")
    {
        this.x = NewX;
        this.y = NewY;

    }

}