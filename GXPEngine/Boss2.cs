using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;





public class Boss2 : BaseBoss
{
    //if you exchange tyler sprite with Sprite then u can't acces tyler specific stuff but can import a lot more sprites here which i think isn't needed cuz every boss has 1 sprite
    KanyeSprite kanye = new KanyeSprite();
    float Timer2 = 6f;
    public Boss2(float newX, float newY, Player player = null) : base(newX, newY, player)
    {
        AddChild(kanye);
        HP = 100;
        SetState(BossState.Idle);
        scale = 0.14f;
    }

    new private void Update()
    {
        HandleStates();

    }



    public override void HandleStates()
    {
        switch (currentState)
        {
            case BossState.Idle:
                Timer -= Time.deltaTime;
                if (Timer <= 0f)
                {
                    SetState(BossState.Fase1);
                }
                break;
            case BossState.Fase1:
                Timer -= Time.deltaTime;
                if (Timer <= 0f)
                {
                    AddSlam();
                    Timer = 5;
                }
                if (HP < 50)
                {
                    SetState(BossState.Fase2);
                }
                break;

            case BossState.Fase2:
                Timer -= Time.deltaTime;
                if (Timer <= 0f)
                {
                    AddLaser();
                    Timer = 1;
                }
                if (HP < 20)
                {
                    SetState(BossState.Fase3);
                }
                break;
            case BossState.Fase3:
                Timer -= Time.deltaTime;
                Timer2 -= Time.deltaTime;
                if (Timer <= 0f)
                {
                    AddLaser();
                    Timer = 1f;
                }
                if (Timer2 <= 0f)
                {
                    AddSlam();
                    Timer2 = 6f;
                }
                if (HP <= 0)
                {
                    SetState(BossState.Defeated);
                }
                break;
            case BossState.Defeated:
                LateDestroy();
                break;

        }

    }

}

public class KanyeSprite : Sprite
    {
        public int Timer = 25;
        public bool Hit = false;
        public KanyeSprite() : base("Kanye.png", false, true)
        {
            SetOrigin(width / 2, height / 2);
            scale = 2;
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


