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
        scale = 2;
    }

    void Update()
    {
        x = _boss.x;
        y = _boss.y - 300;

        //HP bar
        graphics.Clear(Color.Empty);
        if (_boss != null)
        {
            graphics.DrawString("HP:" + _boss.GetHP(), SystemFonts.DefaultFont, Brushes.White, 0, 0);
        }

    }

}






public class HUD_Player : Canvas
{

    private Player _player;
    public HUD_Player(Player player) : base(200, 200, false)
    {
        SetOrigin(width / 2, height / 2);
        _player = player;
        this.scale = 3;
        x = 600;
        y = 300;
    }

    void Update()
    {


        //HP bar
        graphics.Clear(Color.Empty);
        if (_player != null)
        {
            
            graphics.DrawString("HP:" + _player.GetLifes(), SystemFonts.DefaultFont, Brushes.White, 0, 0);
        }

    }




}