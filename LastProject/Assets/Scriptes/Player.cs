using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float Jump_force;
    public float gravity = 1f;
    public float jumpheight = 30f;
    bool isDragging = false;
    Vector2 touchpos, playpos, dragpos;
    public float lefBound, rightBound;
    public GameObject jumpEffect;
    public GameObject DeadEffect;
    public GameObject touchstart;
    bool isDead = false;
    bool isstart = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("stair"))
        {
            if (rb.velocity.y <= 0f)
            {
                Jump_force = gravity * jumpheight;
                rb.velocity = new Vector2(0f, Jump_force);
                ScoreManger.instance.addscore();
                SoundManger.instance.StairSoubd();
                gravity += 0.01f;
                 Camera.main.backgroundColor = target.gameObject.GetComponent<SpriteRenderer>().color;

                destroyAndMakestair(target);
                effact();

            }
        }
    }
    private void effact() {

       Destroy(Instantiate(jumpEffect, transform.position, Quaternion.identity),0.5f);
    }
    void destroyAndMakestair(Collider2D stair)
    {
        stair.gameObject.SetActive(false);
        StairSpawner.instance.Makestair();

    }
  
    private void Update()
    {
        waittotouch();
        if (isDead)
            return;
        if (!isstart)
            return;
        addGravity();
        getinput();
        moveplayer();
        checkPlayer();
    }
    private void waittotouch() {
        if (!isstart) { 
        if(Input.GetMouseButtonDown(0))
            {
                isstart = true;
                touchstart.SetActive(false);

            }
        
        }
    
    
    
    }
    private void moveplayer()
    {
        if (isDragging)
        {
            dragpos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = new Vector2(playpos.x + (dragpos.x - touchpos.x), transform.position.y);
            if (transform.position.x < lefBound)
            {

                transform.position = new Vector2(lefBound, transform.position.y);
            }
            if (transform.position.x > rightBound)
            {

                transform.position = new Vector2(rightBound, transform.position.y);
            }
        }
    }
    private void getinput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            Debug.Log("ok down");

         touchpos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            playpos = transform.position;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            Debug.Log("ok Up");
        }

    }
    void addGravity()
    {
        rb.velocity = new Vector2(0, rb.velocity.y - (gravity * gravity));
    }
    void checkPlayer()
    {
        if (!isDead&& transform.position.y < Camera.main.transform.position.y - 15)
        {
            isDead = true;
            rb.velocity = Vector2.zero;
            Destroy(Instantiate(DeadEffect, transform.position, Quaternion.identity), 1f);
            SoundManger.instance.dethSoubd();
            GameManger.instance.Gameover();

        }

    }
}
