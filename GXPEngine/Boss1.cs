using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Boss1 : BaseBoss
{
    public Boss1(float newX, float newY, Player player) : base(newX, newY, player)
    {
        AddChild(new Sprite("circle.png", false, false));//slecht!! >:(
    }

    public override void HandleStates()
    {
        switch (currentState)
        {
            case BossState.Idle:
                Timer -= Time.deltaTime;
                if (Timer < 0f)
                {
                    AddMissile();
                    SetState(BossState.GoLeft);
                }
                break;
            case BossState.GoLeft:
                if (x > 100)
                {
                    x = x - 4;
                }
                else
                {
                    SetState(BossState.GoRight);
                }
                break;
            case BossState.GoRight:
                if (x < 1800)
                {
                    x = x + 4;
                }
                else
                {
                    SetState(BossState.Idle);
                }
                break;
        }
    }
}