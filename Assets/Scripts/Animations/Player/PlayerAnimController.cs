using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{

    public CharacterController controller;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<CharacterController>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.velocity != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
        }
        else {
            animator.SetBool("IsMoving", false);
        }
    }
}
