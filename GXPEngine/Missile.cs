using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Missile : Sprite
{
    float Speed = 1;
    GameObject objectToFollow = null;
    float targetX = 0f;
    float targetY = 0f;
    float Timer = 0;

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
        Timer += Time.deltaTime;
        if (Timer >= 4)
        {
            Destroy();
        }
        if (objectToFollow != null)
        {
            targetX = objectToFollow.x;
            targetY = objectToFollow.y;
        }

        //placeholder voor movement naar (targetX, targetY);
        x = x * 0.96f + targetX * 0.04f;
        y = y * 0.96f + targetY * 0.04f;
    }




    public void OnCollision(GameObject other)
    {
        if (other is Player)
        {
            Player player = other as Player;

            LateDestroy();
        }

    }
}

