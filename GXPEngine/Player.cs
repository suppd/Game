using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class Player : Sprite
{
    bool move = false;
    float acceleration = 0.3f;
    float FrameCount;
    float Frames;
    float CooldownTimer = 400;
    float nextFireTime = 0;
    bool shot = false; // if shot or not for cooldown logic

    public Player(float SetX = 0, float SetY = 0) :base("Circle.png",false,true)
    {
        SetOrigin(width / 2, height / 2);
        SetXY(SetX, SetY);
        this.scale = 3;
    }


    //store (old) velocity
    float moveX = 0;
    float moveY = 0;

    void Update()
    {
        Console.WriteLine(x);

        float oldX = x;
        float oldY = y;

        move = false;
        //friction
        moveX *= 0.97f;
        moveY *= 0.97f;

        if (Input.GetKey(Key.A))
        {
            move = true;
            moveX -= acceleration;
            FrameCount++;
        }
        if (Input.GetKey(Key.D))
        {
            move = true;
            moveX += acceleration;
            FrameCount++;
        }

        if (Input.GetKey(Key.W) && Input.GetKey(Key.D))
        {
            moveX -= acceleration;
            moveY += acceleration;

            if (Time.time > nextFireTime)
            {
                if (Input.GetKey(Key.SPACE))
                {
                    nextFireTime = Time.time + CooldownTimer;
                    Console.WriteLine("shot");
                    Bullet bullet = new Bullet(new Vector2(15, -15), this);
                    bullet.SetXY(x , y - 150);
                    game.AddChild(bullet);

                }
            }

        }

        if (Input.GetKey(Key.W) && Input.GetKey(Key.A))
        {
            moveX += acceleration;
            moveY += acceleration;

            if (Time.time > nextFireTime)
            {
                if (Input.GetKey(Key.SPACE))
                {
                    nextFireTime = Time.time + CooldownTimer;
                    Console.WriteLine("shot");
                    Bullet bullet = new Bullet(new Vector2(-15, -15), this);
                    bullet.SetXY(x , y - 150);
                    game.AddChild(bullet);

                }
            }

        }

        if (Time.time > nextFireTime)
        {
            if (Input.GetKey(Key.SPACE))
            {
                nextFireTime = Time.time + CooldownTimer;
                Console.WriteLine("shot");
                Bullet bullet = new Bullet(new Vector2(-1, -70), this);
                bullet.SetXY(x, y - 150);
                game.AddChild(bullet);

            }
        }


        if (Input.GetKey(Key.W))
        {
            moveY -= acceleration;
        }

        if (Input.GetKey(Key.S))
        {
            moveY += acceleration;
        }

        //CooldownTimer++;

        //if(shot = false && CooldownTimer == 2)
        //{
        //    CooldownTimer = 2;
        //}

        //if(shot == true)
        //{
        //    CooldownTimer = 0;

        //}



        //if (Time.time > nextFireTime)
        //{
        //    if (Input.GetKey(Key.SPACE))
        //    {
        //        nextFireTime = Time.time + CooldownTimer;
        //        Console.WriteLine("shot");
        //        Bullet bullet = new Bullet(new Vector2(10, 0), this);
        //        bullet.SetXY(x + 120, y - 40);
        //        game.AddChild(bullet);

        //    }
        //}

        //collisions with other objects
        MoveUntilCollision(moveX, moveY);
    }

}
