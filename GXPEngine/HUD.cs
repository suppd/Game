using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class HUD : Canvas
{

    private BaseBoss _boss;
    public HUD(BaseBoss boss) : base(200, 200, false)
    {
        SetOrigin(width / 2, height / 2);
        _boss = boss;
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