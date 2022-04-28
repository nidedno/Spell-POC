using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Cast 
{

    public Cast follower;
    
    
    public _Spell _owner{get;private set;}

    private SpellLogic _castLogic; // �� ��� ������������ ���� ����

    private List<SpellAction> _spellActions; // ������ �������� �����
    //private List<Element> _spellElements;

    public CastTriggers _castTriggers = new CastTriggers(); // ������ ��������� �����������

    // ����������� �����
    public Vector3 _startPoint = Vector3.zero, _direction = Vector3.up;

    private GameObject _castObject;



    public Cast(_Spell owner,SpellLogic logic, List<SpellAction> actions)
    {
        _owner = owner;
        _castLogic = logic;
        _spellActions = actions;
        _castLogic.SetOwner(this);


    }

    public void SetDirection(Vector3 startPoint, Vector3 direction)
    {
        _startPoint = startPoint;
        _direction = direction;
    }

    // ���������� �������� ���� ����������
    
    public void StartCast()
    {

        //_castLogic.ApplyLogic(_startPoint, _direction);
        _castLogic.ActivateLogic();

        Debug.Log("spell die");

       
    }

    


    private void OnDestroy()
    {
        _castTriggers.SpellDie();
    }




}
