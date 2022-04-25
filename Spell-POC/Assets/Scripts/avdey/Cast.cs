using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class Cast 
{

    private ISpellLogic _castLogic; // то как доставл€етс€ этот каст

    private List<SpellAction> _spellActions; // список эффектов каста

    public CastTriggers _castTriggers = new CastTriggers(); // список тригерров подписчеков

    // направление каста
    public Vector3 _startPoint = Vector3.zero, _direction = Vector3.up;

    private GameObject _castObject;



    public Cast(ISpellLogic logic, List<SpellAction> actions)
    {
        _castLogic = logic;
        _spellActions = actions;
        _castLogic.SetOwner(this);
        // возможно будет больше конструкторов
    }

    public void SetDirection(Vector3 startPoint, Vector3 direction)
    {
        _startPoint = startPoint;
        _direction = direction;
    }

    // собственно начинаем каст заклинани€
    
    public void StartCast()
    {

       // _castObject = new GameObject("spell name + iteration [n]");



        _castLogic.ApplyLogic(_startPoint, _direction);


        Debug.Log("spell die");

       
    }


    private void OnDestroy()
    {
        _castTriggers.SpellDie();
    }




}
