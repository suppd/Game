using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class Player : AnimationSprite
{
    Retry retry;
    bool idle;
    bool move = false;
    float acceleration = 0.3f;
    float speed = 0;
    float FrameCount;
    float Frames;
    float CooldownTimer = 800;
    float nextFireTime = 0;
    bool shot = false; // if shot or not for cooldown logic
    public int Lifes = 5;
    bool Jumping = false;
    float Timer = 1f;
    int Highscore = 0;
    Sound walk;
    SoundChannel SFX;



    public Player(float SetX = 0, float SetY = 0) : base("protagcycle_good.png", 5, 3, 11, false, true)
    {
        SetOrigin(width / 2, height / 2);
        SetXY(SetX, SetY);
        this.scale = 0.75f;
        SetFrame(6);
        FrameCount = 0;
        Frames = 2.5f;
        walk = new Sound("Sounds/Riley Walk/Walk.mp3", false, false);
        SFX = walk.Play();
        SFX.Volume = 0.1f;
    }


    //store (old) velocity
    float moveX = 0;
    float moveY = 0;

    void Update()
    {

        if (move == true)
        {
            SetCycle(0, 6);
            Animate();
            Walk();
        }

        if (move == false)
        {
            SetCycle(6, 4);
            Animate();
            StopWalk();
        }

        if (Jumping == true)
        {
            SetCycle(10, 1);
            Animate();
            StopWalk();
        }

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

    void StopWalk()
    {
        SFX.Stop();
    }

    void Walk()
    {
        if (SFX.IsPlaying != true)
        {
            SFX = walk.Play();
            SFX.Volume = 0.1f;
        }
    }

    public void Death()
    {

        LateDestroy();
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
                Jumping = true;
                moveY = -25;
            }
            if (moveY != -25)
            {
                Jumping = false;

            }
        
        }
    }
    void Move()
    {
        Console.WriteLine(move);
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
                //FrameCount++;
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
                //FrameCount++;
                Mirror(false, false);
            }
        }

        //if (FrameCount > Frames)
        //{
        //    NextFrame();
        //    FrameCount = 0;
        //}
    }

    public void DeleteLifes(int addition)
    {
        Lifes = Lifes - addition;
    }

    public int GetLifes()
    {
        return Lifes;
    }

    void OnCollision(GameObject other)
    {

        if (other is Platform)
        {
            Platform platform = other as Platform;
            if (y < platform.y - 75)
            {


                Jumping = false;
            }
            if (y < platform.y - 75)
            {

                if (Input.GetKey(Key.W))
                {
                    Jumping = true;
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
}