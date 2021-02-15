using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class Player : Sprite
{
    bool move = false;
    float acceleration = 0.3f;
    float speed = 0;
    float FrameCount;
    float Frames;
    float CooldownTimer = 400;
    float nextFireTime = 0;
    bool shot = false; // if shot or not for cooldown logic
    int Lifes = 5;
    //float JumpSpeed = 5;
    //float MaxJump = 50;
    //float PlayerStartY = 900;
    //bool Jumping = false;
    int gravity = 10;
    int force;
    bool jump = false;
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
        Jump();


        float oldX = x;
        float oldY = y;

        move = false;
        ////friction
        //moveX *= 0.97f;
        //moveY *= 0.97f;
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
            }
        }

        //if (Input.GetKey(Key.W) && Input.GetKey(Key.D))
        //{
        //    moveX -= acceleration;
        //    moveY += acceleration;

        //    if (Time.time > nextFireTime)
        //    {
        //        if (Input.GetKey(Key.SPACE))
        //        {
        //            nextFireTime = Time.time + CooldownTimer;
        //            Console.WriteLine("shot");
        //            Bullet bullet = new Bullet(new Vector2(15, -15), this);
        //            bullet.SetXY(x , y - 150);
        //            game.AddChild(bullet);

        //        }
        //    }

        //}

        //if (Input.GetKey(Key.W) && Input.GetKey(Key.A))
        //{
        //    moveX += acceleration;
        //    moveY += acceleration;

        //    if (Time.time > nextFireTime)
        //    {
        //        if (Input.GetKey(Key.SPACE))
        //        {
        //            nextFireTime = Time.time + CooldownTimer;
        //            Console.WriteLine("shot");
        //            Bullet bullet = new Bullet(new Vector2(-15, -15), this);
        //            bullet.SetXY(x , y - 150);
        //            game.AddChild(bullet);

        //        }
        //    }

        //}

        if (Time.time > nextFireTime)
        {
            if (Input.GetKey(Key.SPACE))
            {
                nextFireTime = Time.time + CooldownTimer;
                Console.WriteLine("shot");
                Bullet bullet = new Bullet(new Vector2(10, 0), this);
                bullet.SetXY(x + 130, y );
                game.AddChild(bullet);

            }
        }


        //if (PlayerStartY - y >= MaxJump)
        //{
        //    y = y + JumpSpeed;
        //}
        //if (Input.GetKey(Key.W))
        //{
        //    y = y - JumpSpeed;

        //}

        //if (Input.GetKey(Key.S))
        //{
        //    moveY += acceleration;
        //}



        void Jump()
        {
            moveY = moveY + 1;
            y = y + moveY;

            if (y > (game.height - 80) - height / 2)
            {
                y = (game.height - 80) - height / 2;
                moveY = 0;


                if (Input.GetKey(Key.W))
                {
                    moveY = -20;
                }
            }
        }

        //collisions with other objects
        MoveUntilCollision(moveX, moveY);
    }

}
