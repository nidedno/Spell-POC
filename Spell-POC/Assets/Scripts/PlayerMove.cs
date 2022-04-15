using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0;
    PlayerBodyMove body;
    public Spell spell;
    public Transform CastPoint;

    //Штуки отвечающие за открытие и закрытие редактора
    bool IsShown = false;
    public GameObject Editor;
   
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        body=transform.parent.GetComponent<PlayerBodyMove>();
    }

    public bool freedom = true;
    // Update is called once per frame
    void Update()
    {
        if (freedom)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Intearact();
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (spell != null)
                {
                    Debug.Log("CastPoint: " + CastPoint.position);
                    spell.Cast(CastPoint.position, transform.forward);
                }
                else
                {
                    Debug.Log("No spell");
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (IsShown)
            {
                Editor.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                body.freedom=freedom = true;
            }
            else
            {
                Editor.SetActive(true);
                Cursor.lockState= CursorLockMode.None;
                body.freedom = freedom = false;
            }
            IsShown = !IsShown;
        }
    }

    void Intearact()
    {
        RaycastHit hit;
       
        if(Physics.Raycast(transform.position+ transform.forward*0.1f, transform.forward,out hit))
        {
            if (hit.transform != null)
            {
                Transform Final=hit.transform;
                while (Final.parent != null)
                {
                    Final = Final.parent;
                }
                    
                //if (Final.gameObject.GetComponent<Interactive>())
                //{
                //    Final.gameObject.GetComponent<Interactive>().BeIntaracted(transform.parent);
                //    Debug.Log("Interactive");
                //}
            }
        }
    }
}
