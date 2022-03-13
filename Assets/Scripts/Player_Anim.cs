using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        Running();
    }

    #region Movimentação;

    void Movement()
    {
        //Este Metodo checa se o player esta ou não se movimentando;
        if (player.Direction.sqrMagnitude > 0) //se for maior que zero, player se move;
        {
            anim.SetInteger("base", 1);
        }
        else
        {
            anim.SetInteger("base", 0);
        }

        if(player.Direction.x > 0) //se for maior que zero, player se move pra direirta;
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if(player.Direction.x < 0) //se for menor que zero, player se move pra esquerda;
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void Running()
    {
        if (player.IsRunning)
        {
            anim.SetInteger("base", 2);
        }
    }

    #endregion
}
