using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;





public class Boss1 : BaseBoss
{
    //if you exchange tyler sprite with Sprite then u can't acces tyler specific stuff but can import a lot more sprites here which i think isn't needed cuz every boss has 1 sprite
    TylerSprite tyler = new TylerSprite();

    public Boss1(float newX, float newY, Player player = null) : base(newX, newY, player)
    {
        AddChild(tyler);
        HP = 100;
        SetState(BossState.Idle);
    }

    new private void Update()
    {
        HandleStates();

    }

    

    public override void HandleStates()
    {
        Dialogue dialogue = new Dialogue(x - 300, y);
        switch (currentState)
        {
            case BossState.Idle:
                Timer -= Time.deltaTime;
                game.AddChild(dialogue);
                if (Timer <= 0f)
                {
                    SetState(BossState.Fase1);
                }               
                break;
            case BossState.Fase1:
                dialogue.LateDestroy();
                Timer -= Time.deltaTime;
                if(Timer <= 0f)
                {
                    AddMissile();
                    Timer = 1f;
                }
                if(HP <= 50)
                {
                    SetState(BossState.Fase2);
                }
                break;
            case BossState.Fase2:
                Timer -= Time.deltaTime;
                if (Timer <= 0f)
                {
                    AddGroundBul();
                    Timer = 2;
                }
                if(HP <= 20)
                {
                    SetState(BossState.Fase3);
                }
                break;
            case BossState.Fase3:
                Timer -= Time.deltaTime;
                if (Timer <= 0f)
                {
                    AddGroundBul();
                    AddMissile();
                    Timer = 2;
                }
                if(HP <= 0)
                {
                    SetState(BossState.Defeated);
                }
                break;
            case BossState.Defeated:
                if (HP <= 0)
                {
                    LateDestroy();
                }
                break;
        }
    }

}


public class TylerSprite : Sprite
{
    public int Timer = 25;
    public bool Hit = false;
    public TylerSprite() : base("Tyler.png", false, true)
    {
        SetOrigin(width / 2, height / 2);
        
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



public class Dialogue : Sprite
{ 
    public Dialogue(float NewX, float NewY) : base("dia.png", false, true)
    {
        this.x = NewX;
        this.y = NewY; 
        SetOrigin(width / 2, height / 2);
    }

    void Destroy()
    {
        LateDestroy();
    }
}