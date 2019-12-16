using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balascript : MonoBehaviour
{
	public float speedbala=1;
  public static int danio=0;
    public Animator animator;
   // int direccion;
    void Start()
    {
      /*  GameObject play_er=GameObject.Find("Player");
        CharacterController2D playerScript=play_er.GetComponent<CharacterController2D>();
*/
        Destroy(this.gameObject, 2);   
        
       // direccion=playerScript.m_FacingRight ? 1 : -1;
    }
    public int GetDanio(){
      return danio;
    }
    public void SetDanio(int other){
      danio=other;
    }

    void Update()
    {
        transform.Translate(Vector3.up* Time.deltaTime*speedbala/**direccion*/,Space.Self);
    }

    void OnCollisionEnter2D(Collision2D other){
      if(other.gameObject.name=="interruptor"){
        danio+=1;
      }
      animator.SetBool("explosion",true);
      Destroy(this.gameObject,0.15f);  

    }
}
