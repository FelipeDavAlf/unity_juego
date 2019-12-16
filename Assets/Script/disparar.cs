using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class disparar : MonoBehaviour
{
    public GameObject bala;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire")){
        Instantiate(bala,this.transform.position, this.transform.rotation).transform.parent=this.transform;;
        }
    } 
}
