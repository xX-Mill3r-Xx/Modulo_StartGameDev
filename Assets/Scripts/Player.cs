using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    private Vector2 _direction;

    private float initialSpeed;
    private bool _isRunning;

    public float speed;
    public float run_Speed;

    #region Get and Set;

    /*Usamos os acessadores para encapsular um metodo e acessarmos
        e acessarmos o mesmo em outras classes;
        obs: ateção ao padrao de nomeclatura das variaveis;*/
    public Vector2 Direction
    {
        
        get { return _direction; }
        set { _direction = value; }
    }

    public bool IsRunning
    {

        get { return _isRunning; }
        set { _isRunning = value; }
    }

    #endregion

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    void Update()
    {
        Move();
        Run();
    }

    private void FixedUpdate()
    {
        OnInput();
    }

    #region Movimentação;

    void Move()
    {
        //Este Metodo serve para movimentar o RigdyBody2D do player;
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void Run()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            speed = run_Speed;
            _isRunning = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            speed = initialSpeed;
            IsRunning = false;
        }
    }

    void OnInput()
    {
        //Este Metodo serve para add força de movimento (*speed) ao player;
        rig.MovePosition(rig.position+ _direction * speed * Time.fixedDeltaTime);
    }

    #endregion
}
