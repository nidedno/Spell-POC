using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Spell : MonoBehaviour
{

    private List<Cast> _castQueue = new List<Cast>();

    public Unit caster{get ; private set;}

    private void Start()
    {
        //_castQueue.Add());
        


        var cast = new Cast(this, new SelfLogic(),new List<SpellAction>());

    }

    public void SpellCast(Vector3 startPoint, Vector3 Direction)
    {
        _castQueue[0].SetDirection(startPoint, Direction);
        _castQueue[0].StartCast();
        
    }

    public void SetCaster(Unit whoCast){
        caster = whoCast;
    }

  

    

}
