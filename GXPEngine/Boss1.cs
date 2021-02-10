using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class Boss1 : Sprite
{
    int M = 0;
    int N = 0;
    int L = 0;
    float HP;
    public bool Hit;
    float Timer = 30;
    private Player _player;

    //determine which phase?? or put pPhase in the constructor?
    bool Phase1 = true;
    bool Phase2 = false;

    public Boss1(float newX, float newY, Player player) : base ("triangle.png")
    {
        SetXY(newX, newY);
        SetOrigin(width / 2, height / 2);
        alpha = 1.0f;
        _player = player;
    }

    public void LoseLifes(int addition)
    {
        HP = HP - addition;
    }

    public void Fade()
    {
        if(Hit == true)
        {
            SetColor(1.0f, 0.0f, 0.0f);
        }
        else
        {
            SetColor(0.0f, 1.0f, 0.0f);
        }

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
            SetColor(0.0f, 1.0f, 0.0f);
        }
        if (Timer == 0)
        {
            Hit = false;
            Timer = 50;
        }


        if (Input.GetKey(Key.R))
        {
            if (_player.x < 849)
            {
                M = M + 2;
                if(M > 800)
                {
                    M = 0;
                }
                Bullet bullet = new Bullet(new Vector2( -100 - M , _player.y), null, true);
                bullet.SetXY(x, y + 50);
                game.AddChild(bullet);
            }



            if (_player.x > 1156)
            {
                N = N + 2;
                if (N > 600)
                {
                    N = 0;
                }
                Bullet bullet = new Bullet(new Vector2((_player.x + N )/3, _player.y), null, true);
                bullet.SetXY(x, y + 50);
                game.AddChild(bullet);

            }

            if (_player.x < 1155 && _player.x > 850)
            {
                L = L + 2;
                if(L > 600)
                {
                    L = 0;
                }
                Bullet bullet = new Bullet(new Vector2((- _player.x / 4) + L, _player.y), null, true);
                bullet.SetXY(x, y + 50);
                game.AddChild(bullet);
            }
        }


    }


}