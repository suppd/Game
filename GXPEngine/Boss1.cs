using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;





public class Boss1 : BaseBoss
{
    Sprite tyler = new TylerSprite();

    public Boss1(float newX, float newY, Player player = null) : base(newX, newY, player)
    {
        AddChild(tyler);
        HP = 20;
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
                    SetState(BossState.Shoot);
                }
                break;
            case BossState.Shoot:
                Timer -= Time.deltaTime;
                if (Timer < 0f)
                {
                    AddMissile();
                    SetState(BossState.Shoot);
                    Timer = 4;
                }
                break;
            case BossState.Fase1:
                if (HP < 30)
                {
                    
                }
                break;

            //case BossState.GoLeft:
            //    if (x > 100)
            //    {
            //        x = x - 4;
            //    }
            //    else
            //    {
            //        SetState(BossState.GoRight);
            //    }
            //    break;
            //case BossState.GoRight:
            //    if (x < 1800)
            //    {
            //        x = x + 4;
            //    }
            //    else
            //    {
            //        SetState(BossState.Idle);
            //    }
            //    break;

            //case BossState.Hurt:
            //    tyler.SetColor(1.0f, 0, 0);
            //    break;
            // doesnt work ^^
        }
    }

    void Update()
    {
        if (HP < 0)
        {
            LateDestroy();
        }
    }

}


public class TylerSprite : Sprite
{
    public int Timer = 25;
    public bool Hit = false;
    public TylerSprite() : base("Tyler.png")
    {
        SetOrigin(width / 2, height / 2);
        scale = 0.1f;
    }



    void Update()
    {
        if (Hit == true)
        {
            Timer--;
            SetColor(1.0f, 0.0f, 0.0f);


        }
        else
        {
            SetColor(1, 1, 1);
        }
        if (Timer == 0)
        {
            Hit = false;
            Timer = 25;
        }
    }
}

