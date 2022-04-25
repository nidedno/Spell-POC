using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Spell : MonoBehaviour
{

    private List<Cast> _castQueue = new List<Cast>();



    private void Start()
    {
        // тестово создаем абстрактные касты с их эффектами и логикой доставки
        
        _castQueue.Add(new Cast( new BallSpellLogic(), new List<SpellAction>() ) );
        _castQueue.Add(new Cast(new BallSpellLogic(), new List<SpellAction>()));
        _castQueue.Add(new Cast(new BallSpellLogic(), new List<SpellAction>()));
        _castQueue.Add(new Cast(new BallSpellLogic(), new List<SpellAction>()));
        _castQueue.Add(new Cast(new BallSpellLogic(), new List<SpellAction>()));

        // искусственно подписываем касты к другим по триггерам
        _castQueue[0]._castTriggers.OnSpellDie += _castQueue[1].StartCast;
        _castQueue[1]._castTriggers.OnSpellDie += _castQueue[2].StartCast;
        _castQueue[2]._castTriggers.OnSpellDie += _castQueue[3].StartCast;
        _castQueue[3]._castTriggers.OnSpellDie += _castQueue[4].StartCast;
        

    }

    public void SpellCast(Vector3 startPoint, Vector3 Direction)
    {
        _castQueue[0].SetDirection(startPoint, Direction);
        _castQueue[0].StartCast();
        
    }

  

    

}
