using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameController : MonoBehaviour
{
    [SerializeField] private Animator anim1,anim2;
    private void Start() 
    {
        anim1.Play("1");
        anim2.Play("1_1");    
    }

}
