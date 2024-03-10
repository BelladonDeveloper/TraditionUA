using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControllerKrampus : MonoBehaviour
{
    [SerializeField] private Transform PlayerTF;
    [SerializeField] private Rigidbody PlayerRB;
    [SerializeField] private Animator _animator;
    public bool LeftHold = false;
    public bool RightHold = false;
    private float Dir;
    void FixedUpdate()
    {
        Dir = 0f;
        if(Input.GetKey("a"))
        {
            Dir += -1f;
        }
        if(Input.GetKey("d"))
        {
            Dir += 1;
        }  

        Dir += LeftHold ? -1f : 0;
        Dir += RightHold ? 1f : 0;

        Vector3 Direction = new Vector3(-Dir, 0, 0);
        PlayerRB.MovePosition(transform.position + Direction * Time.deltaTime * 5);
        Swap();
        Anim();
    }
    private void Swap()
    {   
        if(Dir != 0)
        {
            Vector3 SwapVector = new Vector3((Dir < 0) ? 1 : -1, 1, 1);
            PlayerTF.localScale = SwapVector;
        }
    }
    private void Anim()
    {
        _animator.SetBool("Walk", (Dir != 0) ? true : false); 
    }
}
