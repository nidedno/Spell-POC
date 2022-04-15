using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//��� ����� ����������� ���������� ����� ����������. ������ �� �� Monobehaviour?


public class Spell : MonoBehaviour
{
    public GameObject FireBallPrefab;
    public GameObject MagicRayPrefab;
    public GameObject FireStreamPrefab;
    public GameObject Indicator;
    //������������ ���� ������: ����, �����, �����, ����� 
    public enum SpellEffect
    {
        Water, Fire, earth, wind
    }
    public int area = 0;
    public int HowMuch = 1;
    public enum SpellMove
    {
        Self, //��������� � ����
        ToSky, //� ���� (� ������ ������)
        ball, //��������� ��� ���-�� ����� ������� �� ������
        ray //������ �������� �����
      
    }
    //������, ���� ����� ������� � int ���������� ������� � ���������� �������. � ������ � ������� ������� ������� 1 � ���������� �������
    //� 0 � �������, ���� �� ����� ���� �� �������

    //��� �������� ��������� ������������� � ���������� SpellMove, � ��������� SpellMove ��� ����� ������������� ��.

    public List<SpellMove> move= new List<SpellMove>();

    void SpawnIndicator(Vector3 point)
    {
        GameObject ind = Instantiate(Indicator);
        ind.transform.position = point;
    }
    public void Cast(Vector3 startPoint, Vector3 Direction)
    {
        StartCoroutine(SpellProcess(startPoint, Direction));
    }

    IEnumerator SpellProcess(Vector3 startPoint, Vector3 Direction)
    {
        //Debug.Log(startPoint+" "+ Direction);
        if (move[0] == SpellMove.ball)
        {
            GameObject ball = Instantiate(FireBallPrefab);
            ball.transform.position = startPoint;
            Rigidbody ballBody = ball.GetComponent<Rigidbody>();
            ballBody.AddForce(Direction * 100);
            MagicBall magicBall=ball.GetComponent<MagicBall>();
            while(!magicBall.Collided)
            {
                yield return null;
            }
            SpawnIndicator(magicBall.point);
            yield return null;
            Damgeable damgeable = magicBall.collider.GetComponentInParent<Damgeable>();
            if (damgeable != null)
            {
                damgeable.GetDamage(1);
            }
            Destroy(ball);
        }
        if (move[0] == SpellMove.ray)
        {
            GameObject ray = Instantiate(MagicRayPrefab);
            //ray.transform.position = startPoint;
            LineRenderer line = ray.GetComponent<LineRenderer>();
            line.SetPosition(0, startPoint-new Vector3(0,0.3f));
            //SpawnIndicator(startPoint);

            Vector3 SecondPoint = startPoint + 50 * Direction;

            RaycastHit hit;
            if (Physics.Raycast(startPoint, Direction, out hit))
            {
                SecondPoint=hit.point;
                //Debug.Log(hit.transform.name);
                Damgeable damgeable = hit.transform.GetComponentInParent<Damgeable>();
                if (damgeable != null)
                {
                    damgeable.GetDamage(1);
                }
            }
            line.SetPosition(1, SecondPoint);
            //SpawnIndicator(SecondPoint);

            yield return new WaitForSeconds(0.3f);
            Destroy(ray);
        }
        if (move[0] == SpellMove.ToSky)
        {
            GameObject stream = Instantiate(FireStreamPrefab);
            stream.transform.position = startPoint;


            yield return new WaitForSeconds(5f);
            Destroy(stream);
        }
        yield return null;
    }
    
}
