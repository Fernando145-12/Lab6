using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Nave : MonoBehaviour
{
    [Header("Rotacion en el Avion")]
    [SerializeField] private float velocidad;
    private Vector3 angulos;
    private Quaternion qx = Quaternion.identity;
    private Quaternion qy = Quaternion.identity;
     private Quaternion qz = Quaternion.identity;
     private Quaternion r = Quaternion.identity;
    private float anguloSen;
    private float anguloCos;
    public Text score;
    private float scores;
    public Text life;
    private float lifes = 3;

    public GameObject End;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Izquierda();

        if (Input.GetKey(KeyCode.D))
        {
            angulos.z = Mathf.Clamp(angulos.z - Time.deltaTime * velocidad, -20, 20);
        }
        else if (angulos.z < -6)
        {
            angulos.z = Mathf.Clamp(angulos.z + Time.deltaTime * velocidad, -20, -6);
        }


    }
    public void Izquierda()
    {
        if (Input.GetKey(KeyCode.A))
        {
            angulos.z = Mathf.Clamp(angulos.z + Time.deltaTime * velocidad, -20, 20);
        }
        else if (angulos.z > -6)
        {
            angulos.z = Mathf.Clamp(angulos.z - Time.deltaTime * velocidad, -6, 20);
        }

    }

    private void FixedUpdate()
    {
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

        scores += 1*Time.deltaTime;
        score.text = "Scores : " + (int)scores;
        life.text = "Life : " + (int)lifes;

        if (lifes <= 0)
        {
            Debug.Log("asd");
            End.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemigo"))
        {
            lifes--;
            Destroy(other.gameObject);
        }
    }
}
