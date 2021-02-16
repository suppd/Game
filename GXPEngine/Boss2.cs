using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;





public class Boss2 : BaseBoss
{
    //if you exchange tyler sprite with Sprite then u can't acces tyler specific stuff but can import a lot more sprites here which i think isn't needed cuz every boss has 1 sprite
    KanyeSprite kanye = new KanyeSprite();

    public Boss2(float newX, float newY, Player player = null) : base(newX, newY, player)
    {

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

                break;

        }

    }



    public class KanyeSprite : Sprite
    {
        public int Timer = 25;
        public bool Hit = false;
        public KanyeSprite() : base("circle.png", false, true)
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
}
