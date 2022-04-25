
using UnityEngine;
using System.Threading.Tasks;

public class BallSpellLogic : MonoBehaviour, ISpellLogic 
{
    private Cast logicOwner;
    public void SetOwner(Cast owner)
    {
        logicOwner = owner;
    }


    public async void ApplyLogic(Vector3 startPoint, Vector3 Direction)
    {
        GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        ball.transform.position = startPoint;
        Rigidbody ballBody = ball.AddComponent<Rigidbody>() as Rigidbody;

        ballBody.AddForce(Direction * 500);

        MagicBall magicBall = ball.AddComponent<MagicBall>() as MagicBall;


        while (!magicBall.Collided)
        {
            await Task.Yield();

        }


        GameObject ind = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ind.GetComponent<Collider>().isTrigger = true;
        ind.transform.position = magicBall.point;
      

        Damgeable damgeable = magicBall.collider.GetComponentInParent<Damgeable>();

        if (damgeable != null)
        {
            damgeable.GetDamage(1);
        }

        Destroy(ball);

        //в конце доставки мы должны передать позицию и че ваще делать касту (?);

        logicOwner._castTriggers.SpellDie();
        

    }

}
