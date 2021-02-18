using System;
using GXPEngine;
using GXPEngine.Core;


public class Bullet : GameObject
{

    Vector2 direction;
    float speed = 5;
    BulletSprite bulletSprite = new BulletSprite();
    Sprite bossBullet = new BulletBoss();
    Sprite arm = new ArmBoss();
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
    public Bullet(Vector2 direction, Player pShooter=null, bool pFromEnemy=false, bool pFromKanye=false)
    {
        //this.scaleX = 0.06f;
        //this.scaleY = 0.15f;
        this.direction = direction;
        shooter = pShooter;         // Now we know who shot us
        pEnemy = pFromEnemy;        // Now we know if enemy shot us

        if(pShooter != null)
        {
            AddChild(bulletSprite);
            bulletSprite.CheckFrame();
        }
        
        if(pFromEnemy != false)
        {
            AddChild(bossBullet);
        }

        if(pFromKanye != false)
        {
            AddChild(arm);
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
public class BulletSprite : AnimationSprite
{
    Sound Ayo;
    Sound Burh;
    Sound Ey;
    Sound Uh;
    Sound Yuh;
    SoundChannel _SFX;
    float Timer = 5;
    bool Hit = false;
    public BulletSprite() : base("Mumble.png", 3, 2, 5)
    {
        SetOrigin(width/2, height/2);
        SetFrame(Utils.Random(0, 5));
        this.scale = 0.5f;
        Ayo = new Sound("Sounds/Riley speech/Ayo_Riley.mp3", false, false);
        Burh = new Sound("Sounds/Riley speech/Burh_Riley.mp3", false, false);
        Ey = new Sound("Sounds/Riley speech/Riley_EY.mp3", false, false);
        Uh = new Sound("Sounds/Riley speech/Uh_Riley.mp3", false, false);
        Yuh = new Sound("Sounds/Riley speech/Yuh_Riley.mp3", false, false);
        
    }

    public void OnCollision(GameObject other)
    {

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

        if (other is KanyeSprite)
        {
            KanyeSprite kanye = other as KanyeSprite;
            Console.WriteLine("HIT");
            kanye.Hit = true;
        }

    }

    void Update()
    {

    }
    public void DestroyBullet()
    {
        LateDestroy();
    }

    public void CheckFrame()
    {

        if (currentFrame == 0)
        {
           _SFX = Ayo.Play();
           _SFX.Volume = 0.10f;
        }
        if (currentFrame == 1)
        {
           _SFX = Burh.Play();
           _SFX.Volume = 0.10f;
        }
        if (currentFrame == 2)
        {
           _SFX = Ey.Play();
           _SFX.Volume = 0.10f;
        }
        if (currentFrame == 3)
        {
           _SFX = Uh.Play();
           _SFX.Volume = 0.10f;
        }
        if (currentFrame == 4)
        {
           _SFX = Yuh.Play();
           _SFX.Volume = 0.10f;
        }
    }
}

public class BulletBoss : Sprite
{

    public BulletBoss() : base("Mic.png")
    {
        SetOrigin(_bounds.width / 2, _bounds.height / 2);
        this.scale = 0.33f;
    }
    public void OnCollision(GameObject other)
    {
        //if (other is Platform)
        //{
        //    Platform platform = other as Platform;
        //    DestroyBullet();
        //}

        if(other is Player)
        {

            Player player = other as Player;
            player.DeleteLifes(1);
            DestroyBullet();
        }
    }
    public void DestroyBullet()
    {
        LateDestroy();
    }

}


public class ArmBoss : Sprite
{

    public ArmBoss() : base("yeezy.png")
    {
        SetOrigin(width / 2, height / 2);
        this.scale = 1;
    }
    public void OnCollision(GameObject other)
    {
        //if (other is Platform)
        //{
        //    Platform platform = other as Platform;
        //    DestroyBullet();
        //}

        if (other is Player)
        {
            Player player = other as Player;
            player.DeleteLifes(1);
            DestroyBullet();
        }
    }
    public void DestroyBullet()
    {
        LateDestroy();
    }

}