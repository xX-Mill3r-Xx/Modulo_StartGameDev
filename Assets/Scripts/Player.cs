using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    //private Animator anim;
    private Vector2 direction;

    public float speed;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Direction();
    }

    void Move()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void Direction()
    {
        rig.MovePosition(rig.position+ direction*speed * Time.fixedDeltaTime);
    }
}
