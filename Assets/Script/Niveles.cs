using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveles : MonoBehaviour
{
    public GameObject puntos;
    public GameObject jugador;
    public Animator anim;
    public GameObject interruptor;
    public AudioSource sonido;
    public AudioClip explosion;
    public AudioClip win;
    //posiciones del interruptor a disparar
    Vector3[] posicion={new Vector3(1.46f,1.524f,-1.414f),new Vector3(1.695f,1.442f,-1.414f),new Vector3(1.697f,1.514f,-1.414f),new Vector3(1.701f,1.518f,-1.414f)};
    int indice=0;
    void Start()
    {
        sonido=GetComponent<AudioSource>();
    }

    void Update()
    {
        if (puntos.gameObject.GetComponent<balascript>().GetDanio()>=3  && indice<=4)//si se dispara al interruptor varias veces y todavia no se llega al final de niveles
        {
            sonido.PlayOneShot(explosion);
            if(indice<=3){
                interruptor.transform.position=posicion[indice];//modifica la posicion del interruptor
            }
            anim.SetTrigger("cambio");//cambia el escenario
            puntos.gameObject.GetComponent<balascript>().SetDanio(0);//regresa el daño de puntos a 0 
            indice++; 
            
        }else if(puntos.gameObject.GetComponent<balascript>().GetDanio()>=3 && indice==5)//en el ultimo escenario gana
        {
            jugador.gameObject.GetComponent<PlayerMovement>().enabled=false;
            jugador.gameObject.GetComponent<CharacterController2D>().enabled=false;
            jugador.gameObject.GetComponentInChildren<disparar>().enabled=false;
            sonido.PlayOneShot(explosion);
            Application.Quit();
            
            //StartCoroutine(GameOver());
        }
        
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(6);
        sonido.Stop();
        Application.Quit();
    }
}
