using System;
using System.Drawing;
using GXPEngine;
using GXPEngine.Core;

public class Platform : Sprite
{

    public Platform(float SetX,float SetY) : base("square.png", false, true)
    {
        this.x = SetX;
        this.y = SetY;
        SetOrigin(width / 2, height / 2);
        this.scale = 3;
    }


    //void OnCollision(GameObject other)
    //{
    //    if (other is Player)
    //    {
    //        Player player = other as Player;
            
    //        if (player.y >= y - 95)
    //        {
    //            player.y = this.y - (96 + player.height/2) ;
    //        }




    //    }

    //}


        

}