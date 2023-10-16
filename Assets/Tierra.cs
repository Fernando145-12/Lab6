using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tierra : MonoBehaviour
{
    [Header("Rotacion en la Tierra")]
    [SerializeField] private float velocidad;
    private Vector3 angulos;
    private Quaternion qx = Quaternion.identity;
    private Quaternion qy = Quaternion.identity;
    private Quaternion qz = Quaternion.identity;
    private Quaternion r = Quaternion.identity;
    private float anguloSen;
    private float anguloCos;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            angulos.x = angulos.x + Time.deltaTime * velocidad;
            angulos.y = angulos.y - Time.deltaTime * velocidad;
        }     

        if (Input.GetKey(KeyCode.D))
        {
            angulos.x = angulos.x - Time.deltaTime * velocidad;
            angulos.y = angulos.y + Time.deltaTime * velocidad;
        }  

        angulos.z = angulos.z - Time.deltaTime * velocidad;

        StartCoroutine(Enderezar());

        //rotation z-> x -> y
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.z * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.z * 0.5f);
        qz.Set(0, 0, anguloSen, anguloCos);

        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.x * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.x * 0.5f);
        qx.Set(anguloSen, 0, 0, anguloCos);

        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.y * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.y * 0.5f);
        qy.Set(0, anguloSen, 0, anguloCos);

        r = qy * qx * qz;

        transform.rotation = r;
    }

    IEnumerator Enderezar()
    {
        //angulos.x = 0;
        yield return new WaitForSeconds(1);
    }

}
