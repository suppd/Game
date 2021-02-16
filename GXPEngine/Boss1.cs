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
        HP = 20;
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
                if (Timer <= 0f)
                {
                    
                    game.AddChild(dialogue);
                    SetState(BossState.Fase1);
                }               
                break;
            case BossState.Fase1:
                Timer -= Time.deltaTime;
                if(Timer <= 0f)
                {
                    dialogue.Destroy();
                    AddMissile();
                    Timer = 2;
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