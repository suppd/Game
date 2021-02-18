using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class ScoreManager : GameObject
{
    float score = 5000;
    float ScoreTimer = 0;
    public ScoreManager()
    {

    }

    public float getScore()
    {
        return score;
    }

    void Update()
    {
        ScoreTimer--;
        score = score - ScoreTimer;
    }
}