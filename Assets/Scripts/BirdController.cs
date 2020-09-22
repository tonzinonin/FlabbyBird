using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float addForce = 200f;

    private Rigidbody2D rb2d;
    private bool isDead = false;
    private Animator anim;
    //Github test

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead && Input.GetMouseButtonDown(0)) //鼠标左键。
        {
            rb2d.velocity = Vector2.zero; //重置速度为0，平衡力
            rb2d.AddForce(new Vector2(0, addForce));
            anim.SetTrigger("Flap");
        }
    }

    void OnCollisionEnter2D() 
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied ();
    }
}
