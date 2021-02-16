using System;
using GXPEngine;
using GXPEngine.Core;


public class Bullet : GameObject
{
    Vector2 direction;
    float speed = 5;
    Sprite bulletSprite = new BulletSprite();
    Sprite bossBullet = new BulletBoss();
    float timer = 0;
    Player shooter; // initalise the player as shooter
    bool pEnemy; // know who shot the bullet player or enemy? if yes its TRUE

    /// <summary>
    /// For bullets shot by players: assign the player arguemtn (pFromEnemy is false by default)
    /// For bullets shot by enemies: set pShooter=null, and pFromEnemy=true.
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="pShooter"></param>
    /// <param name="pFromEnemy"></param>
    public Bullet(Vector2 direction, Player pShooter=null, bool pFromEnemy=false)
    {
        this.scaleX = 0.06f;
        this.scaleY = 0.15f;
        this.direction = direction;
        shooter = pShooter;         // Now we know who shot us
        pEnemy = pFromEnemy;        // Now we know if enemy shot us

        if(pShooter != null)
        {
            AddChild(bulletSprite);
        }
        
        if(pFromEnemy != false)
        {
            AddChild(bossBullet);
        }

    }

   

    void Update()
    {
        Move(direction.normalized * ((speed * 100) * Time.deltaTime));  //bullet movement
        timer += Time.deltaTime;                                        //timer for destroying bullet after being spawned
        if (timer >= 4)
        {
            Destroy();
        }
    }


}
public class BulletSprite : Sprite
{
    float Timer = 5;
    bool Hit = false;
    public BulletSprite() : base("note.png")
    {
        SetOrigin(width/2, height/2);
        SetColor(1, 0.2f, 0.2f);
        SetColor(200, 50, 50);
    }

    public void OnCollision(GameObject other)
    {
        //if (other is BaseBoss)
        //{
        //    BaseBoss boss1 = other as BaseBoss;
        //    boss1.Hit = true;
        //    Console.WriteLine("hit");
        //    DestroyBullet();
        //}



        if (other is BaseBoss)
        {
            BaseBoss boss1 = other as BaseBoss;
            boss1.LoseLifes(10);
            boss1.GetHit();
            DestroyBullet();
        }

        if (other is TylerSprite)
        {
            TylerSprite tyler = other as TylerSprite;
            Console.WriteLine("HIT");
            tyler.Hit = true;
        }

    }

    void Update()
    {

    }
    public void DestroyBullet()
    {
        LateDestroy();
    }
}

public class BulletBoss : Sprite
{

    public BulletBoss() : base("colors.png")
    {
        SetOrigin(_bounds.width / 2, _bounds.height / 2);
    }
    public void OnCollision(GameObject other)
    {

    }
    public void DestroyBullet()
    {
        LateDestroy();
    }

}