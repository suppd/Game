using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Missile : Sprite
{
    GameObject objectToFollow = null;
    float targetX = 0f;
    float targetY = 0f;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="objectToFollow">Als deze null is, gaat hij naar targetX, targetY</param>
    /// <param name="targetX"></param>
    /// <param name="targetY"></param>
    public Missile(float x, float y, GameObject objectToFollow, float targetX, float targetY) : base("circle.png")
    {
        if (objectToFollow != null)
        {
            this.objectToFollow = objectToFollow;
        }
        this.targetX = targetX;
        this.targetY = targetY;
        this.x = x;
        this.y = y;
    }

    void Update()
    {
        if (objectToFollow != null)
        {
            targetX = objectToFollow.x;
            targetY = objectToFollow.y;
        }

        //placeholder voor movement naar (targetX, targetY);
        x = x * 0.99f + targetX * 0.01f;
        y = y * 0.99f + targetY * 0.01f;
    }

}

