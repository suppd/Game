using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Missile : GameObject
{
    float Speed = 1;
    GameObject objectToFollow = null;
    float targetX = 0f;
    float targetY = 0f;
    float Timer = 0;
    BulletTyler tylerbullet = new BulletTyler();
    BulletKanye kanyebullet = new BulletKanye();


    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="objectToFollow">Als deze null is, gaat hij naar targetX, targetY</param>
    /// <param name="targetX"></param>
    /// <param name="targetY"></param>
    public Missile(float x, float y, GameObject objectToFollow, float targetX, float targetY, bool pKanye = false, bool pTyler = false)
    {
        //scale = 0.4f;

        if (objectToFollow != null)
        {
            this.objectToFollow = objectToFollow;
        }
        this.targetX = targetX;
        this.targetY = targetY;
        this.x = x;
        this.y = y;

        if (pKanye != false)
        {
            AddChild(kanyebullet);
        }

        if (pTyler != false)
        {
           AddChild(tylerbullet);
        }
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 1.5f)
        {
            Destroy();
        }
        if (objectToFollow != null)
        {
            targetX = objectToFollow.x;
            targetY = objectToFollow.y;
        }

        float oldX = x;
        float oldY = y;
        //placeholder voor movement naar (targetX, targetY);
        x = x * 0.96f + targetX * 0.04f;
        y = y * 0.96f + targetY * 0.04f;

        if (objectToFollow != null)
        {


            if ((targetX + 200) > x)
            {
                x = oldX;
                y = oldY;
            }
        }
    }




    public void OnCollision(GameObject other)
    {
        if (other is Player)
        {
            Player player = other as Player;
            player.DeleteLifes(1);

            LateDestroy();
        }

    }
}




public class Lazer : Sprite
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
    public Lazer(float x, float y, GameObject objectToFollow, float targetX, float targetY) : base("circle.png")
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
        if (Timer >= 3)
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
            player.DeleteLifes(1);

            LateDestroy();
        }

    }
}



public class BulletTyler : AnimationSprite
{

    public BulletTyler() : base("TylerPr.png",3,1,3)
    {
        SetOrigin(width/2,height/2);
        this.scale = 0.4f;
        SetFrame(Utils.Random(0, 3)); ;
    }
    public void OnCollision(GameObject other)
    {
        if (other is Player)
        {
            Player player = other as Player;
            LateDestroy();
            player.DeleteLifes(1);
        }
    }
}



public class BulletKanye : AnimationSprite
{

    public BulletKanye() : base("KanyePr.png",2,1,2)
    {
        SetOrigin(width / 2, height / 2);
        this.scale = 0.4f;
        SetFrame(Utils.Random(0, 2));
    }
    public void OnCollision(GameObject other)
    {
        if (other is Player)
        {
            Player player = other as Player;
            LateDestroy();
            player.DeleteLifes(1);
        }
    }
}
