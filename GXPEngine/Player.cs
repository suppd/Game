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

    public Player(float SetX = 0, float SetY = 0) :base("Circle.png",false,true)
    {
        SetOrigin(width / 2, height / 2);
        SetXY(SetX, SetY);
        this.scale = 4;

    }


    //store (old) velocity
    float moveX = 0;
    float moveY = 0;

    void Update()
    {

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

        if (Input.GetKey(Key.W))
        {

        }

        if (Input.GetKey(Key.S))
        {

        }

        MoveUntilCollision(moveX, moveY);
    }

}
