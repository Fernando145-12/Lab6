using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    [SerializeField] GameObject enemigo1;
    [SerializeField] GameObject enemigo2;
    [SerializeField] GameObject giro;
    void Start()
    {
        StartCoroutine( CrearEnemigos());
    }
  
    IEnumerator CrearEnemigos()
    {
        int rdn = Random.Range(0,3);
        yield return new WaitForSecondsRealtime(2);
        if( rdn == 1)
        {
            Instantiate(enemigo1, transform.position, enemigo1.transform.rotation, giro.transform) ;
        }else if(rdn == 2)
        {
            Instantiate(enemigo2, transform.position, enemigo2.transform.rotation, giro.transform);
        }       
        StartCoroutine(CrearEnemigos());
    }
}
