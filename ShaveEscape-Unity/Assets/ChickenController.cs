using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("x")) {
            int tickIndex = Random.Range(0, 4);
            animator.SetInteger("tickIndex", tickIndex);
            animator.SetTrigger("tick");
        }
    }
}
