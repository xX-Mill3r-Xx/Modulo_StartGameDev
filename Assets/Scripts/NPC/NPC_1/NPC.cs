using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private int index;
    private float initialSpeed;
    private Animator anim;
    public List<Transform> paths = new List<Transform>();
    public float speed;

    private void Start()
    {
        anim = GetComponent<Animator>();
        initialSpeed = speed;
    }

    void Update()
    {
        if (DialogController.instance.isShowing)
        {
            speed = 0f;
            anim.SetBool("isWalking", false);
        }
        else
        {
            speed = initialSpeed;
            anim.SetBool("isWalking", true);
        }

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, paths[index].position) < 0.01f)
        {
            if (index < paths.Count -1)
            {
                index++;

                #region NPC anda aleatoriamente
                //este codigo só funciona quando tem mais de dois paths e faz o npc andar aleatoriamente.;
                //index = Random.Range(0, paths.Count - 1);
                #endregion
            }
            else
            {
                index = 0;
            }
        }

        Vector2 direction = paths[index].position - transform.position;
        if(direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if(direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
