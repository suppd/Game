using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class Player : AnimationSprite
{
    bool idle;
    bool move = false;
    float acceleration = 0.3f;
    float speed = 0;
    float FrameCount;
    float Frames;
    float CooldownTimer = 400;
    float nextFireTime = 0;
    bool shot = false; // if shot or not for cooldown logic
    int Lifes = 5;
    bool Onplatform;



    public Player(float SetX = 0, float SetY = 0) : base("MCani.png", 5, 2, 6, false, true)
    {
        SetOrigin(width / 2, height / 2);
        SetXY(SetX, SetY);
        this.scale = 0.75f;
        SetFrame(0);
        FrameCount = 0;
        Frames = 2.5f;
    }


    //store (old) velocity
    float moveX = 0;
    float moveY = 0;

    void Update()
    {
        Move(moveX, moveY);
        Move();

        Jump();


        if (Time.time > nextFireTime)
        {
            if (Input.GetKey(Key.SPACE))
            {
                nextFireTime = Time.time + CooldownTimer;
                Console.WriteLine("shot");
                Bullet bullet = new Bullet(new Vector2(10, 0), this);
                bullet.SetXY(x + 130, y);
                game.AddChild(bullet);

            }
        }

    }

    void Jump()
    {
        moveY = moveY + 1;
        //y = y + moveY;

        if (y > (game.height - 80) - height / 2)
        {
            y = (game.height - 80) - height / 2;


            if (Input.GetKey(Key.W))
            {
                
                moveY = -25;

            }
        }
    }
    void Move()
    {
        //x = x + moveX;
        move = false;

        if (move == false)
        {
            speed = 0;
            moveX = 0;
        }

        if (Input.GetKey(Key.A))
        {
            speed = 10;
            move = true;
            if (move == true)
            {
                moveX -= speed;
                FrameCount++;
                Mirror(true,false);
            }
        }
        if (Input.GetKey(Key.D))
        {
            speed = 10;
            move = true;
            if (move == true)
            {
                moveX += speed;
                FrameCount++;
                Mirror(false, false);
            }
        }

        if (FrameCount > Frames)
        {
            NextFrame();
            FrameCount = 0;
        }
    }

    void OnCollision(GameObject other)
    {

        if (other is Platform)
        {
            Platform platform = other as Platform;

            if (Input.GetKey(Key.W))
            {
                moveY = -25;
            }
            else
            {
                Move(0, -moveY);
                moveY = 0;
            }
        }
    }
}