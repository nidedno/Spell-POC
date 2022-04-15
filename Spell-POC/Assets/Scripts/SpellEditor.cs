using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellEditor : MonoBehaviour
{
    public GameObject spellPrefab;
    public PlayerMove caster;


    public InputField field;
    // Start is called before the first frame update
    void Start()
    {
        field = GetComponent<InputField>();
    }


    public void Compile()//Получение текста с ввода и помещение свитка на нужного мага.
    {
        string source = field.text;
        Debug.Log(source);
        GameObject spellObject = NewSpell(source);

        if (caster.spell != null)//Временная затычка с удалением предыдущего заклинания
        {
            Destroy(caster.spell.gameObject);
        }



        spellObject.transform.transform.position=caster.transform.position;
        spellObject.transform.SetParent(caster.transform);
        caster.spell=spellObject.GetComponent<Spell>();

    }
    public GameObject NewSpell(string source)//Создание свитка с заклинанием
    {
        GameObject spellObject = Instantiate(spellPrefab);
        Spell spell = spellObject.GetComponent<Spell>();
        string[] words = source.Split(' ');

        //инициализация всех штук нужных в заклинании
        spell.move = new List<Spell.SpellMove>();

        foreach (string word in words)
        {

            //Обработка методов движения
            
            if (word == "ball") spell.move.Add(Spell.SpellMove.ball);
            if (word == "sky") spell.move.Add(Spell.SpellMove.ToSky);
            if (word == "ray") spell.move.Add(Spell.SpellMove.ray);
            if (word == "self") spell.move.Add(Spell.SpellMove.Self);
        }

        //затычки для дефолтных кейсов
        if (spell.move.Count == 0) spell.move.Add(Spell.SpellMove.ToSky);


        return spellObject;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
