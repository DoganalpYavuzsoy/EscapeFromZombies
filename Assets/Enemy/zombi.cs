using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class zombi : MonoBehaviour
{
    Animator Zombianim;
    CharacterController Karakter;

    public Transform Hedef;
    NavMeshAgent Agent;
    public float mesafe;

    // Start is called before the first frame update
    void Start()
    {
        Karakter=GetComponent<CharacterController>();
        Zombianim=GetComponent<Animator>();
        Agent=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Zombianim.SetFloat("hız",Karakter.velocity.magnitude);
        mesafe=Vector3.Distance(transform.position, Hedef.position);
        Agent.destination=Hedef.position;
        
        if(mesafe<=10){
            Agent.enabled=true;


        }
        else{

            Agent.enabled=false;
        }



    }
}
