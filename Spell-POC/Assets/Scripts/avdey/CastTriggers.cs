
using UnityEngine;
using System;

public class CastTriggers 
{
    /*
    * ��� ������ ��������� � ����������, ������� ����� �������� ����� ����������;
    * ���� ���������� �� ����� ����������� �����������, �� �������� ������ �������� �����������
    */

    public event Action OnSpellDie;
    public event Action OnSurfaceContact;
    public event Action OnEnemyContact;
    public event Action OnStep;


    
    public void SpellDie() => OnSpellDie?.Invoke();

    public void SurfaceContact() => OnSurfaceContact?.Invoke();

    public void EnemyContact() => OnEnemyContact?.Invoke();

    public void StepFinish() => OnStep?.Invoke();




}
