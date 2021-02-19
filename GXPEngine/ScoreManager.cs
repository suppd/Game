using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class ScoreManager : Canvas
{
    float score = 5000;
    float ScoreTimer = 0;
    public ScoreManager() : base(200, 200, false)
    {
        scale = 2;
        score = score - Utils.Random(3000, 4000);
    }

    public float getScore()
    {
        return score;
    }

    void Update()
    {
        Console.WriteLine(score);

        
        graphics.DrawString("Your Score For the rap battle:" + score, SystemFonts.DefaultFont, Brushes.White, 0, 0);
    }
}