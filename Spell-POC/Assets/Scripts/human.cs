using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class human :  Damgeable
{
    //класс отвечающий за тело человека, всякие показатели типа здоровья и тд. Но не отвечающий за ИИ, ибо таковых бывает много потенциально
    //Одинаковый human у NPC, союзнике и врага
    public int hp;
    public Animator animator;
    NavMeshAgent agent;
    public Rigidbody[] AllRigidbodies;
    public Mind mind;

    public override void  GetDamage(int damage)
    {
        hp-=damage;
        if (hp < 0)
        {
            Die();
        }

    }
    public IEnumerator Reach(Vector3 point)
    {
        agent.destination=point;
        animator.SetBool("walking",true);
        while (Vector3.Distance(transform.position, point) > 1)
        {
            yield return null;
        }
    }
    private void Awake()
    {
        agent=GetComponent<NavMeshAgent>();
        for(int i = 0;i< AllRigidbodies.Length; i++)
        {
            AllRigidbodies[i].isKinematic = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       mind=GetComponent<Mind>();
    }


    void Die()
    {
        Destroy(mind);
        MakePhysical();
    }
    public void MakePhysical()
    {
        animator.enabled=false;
        for (int i = 0; i < AllRigidbodies.Length; i++)
        {
            AllRigidbodies[i].isKinematic = false;
        }

    }
    
}
