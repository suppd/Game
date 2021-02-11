﻿using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public enum BossState
{
    None,
    Idle,
    GoLeft,
    GoRight,
    GoCenter,
    Shoot,
    Hurt,
}

public abstract class BaseBoss : Sprite
{
    public BossState currentState = BossState.None;

    public float HP;
    public float Timer = 0f;
    public Player _player;

    public BaseBoss(float newX, float newY, Player player) : base ("triangle.png")
    {
        SetXY(newX, newY);
        SetOrigin(width / 2, height / 2);
        alpha = 1.0f;
        _player = player;
        SetState(BossState.Idle);
    }

    public void SetState(BossState newState) // switch states
    {
        if (currentState != newState)
        {
            currentState = newState;
            BeginState(newState);
        }
    }

    public void BeginState(BossState state)
    {
        Console.WriteLine("State " + state + " has begun.");
        if (state == BossState.Idle)
        {
            Timer = 1f;
        }
    }
    public virtual void HandleStates()
    {
        //empty code this in indivual boss classes
    }

    public void LoseLifes(int addition)
    {
        HP = HP - addition;
    }

    public void AddMissile()
    {
        //Missile missile = new Missile(x, y + 50, null, _player.x, _player.y);  // missle that moves to position when spawned
        Missile missile = new Missile(x, y + 50, _player, 0f, 0f);                  // missle that KEEPS following
        game.AddChild(missile);
    }



    public void Update()
    {
        HandleStates();

        //if (Hit == true)
        //{
        //    Timer--;
        //    SetColor(1.0f, 0.0f, 0.0f);
        //}
        //else
        //{
        //    SetColor(0.0f, 1.0f, 0.0f);
        //}
        //if (Timer == 0)
        //{
        //    Hit = false;
        //    Timer = 50;
        //}


        //if (Input.GetKey(Key.R))
        //{
        //    if (_player.x < 849)
        //    {
        //        M = M + 2;
        //        if(M > 800)
        //        {
        //            M = 0;
        //        }
        //        Bullet bullet = new Bullet(new Vector2( -100 - M , _player.y), null, true);
        //        bullet.SetXY(x, y + 50);
        //        game.AddChild(bullet);
        //    }



        //    if (_player.x > 1156)
        //    {
        //        N = N + 2;
        //        if (N > 600)
        //        {
        //            N = 0;
        //        }
        //        Bullet bullet = new Bullet(new Vector2((_player.x + N )/3, _player.y), null, true);
        //        bullet.SetXY(x, y + 50);
        //        game.AddChild(bullet);

        //    }

        //    if (_player.x < 1155 && _player.x > 850)
        //    {
        //        L = L + 2;
        //        if(L > 600)
        //        {
        //            L = 0;
        //        }
        //        Bullet bullet = new Bullet(new Vector2((- _player.x / 4) + L, _player.y), null, true);
        //        bullet.SetXY(x, y + 50);
        //        game.AddChild(bullet);
        //    }
        //}


    }


}