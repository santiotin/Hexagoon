using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    float moveSpeed = 300f;
    float movement = 0f;
    bool move = false;
    bool menu = true;
    public GameObject gameManager;
    public ParticleSystem ps;

    // Update is called once per frame
    void Update() {
        if(move) {
            //teclado
            movement = Input.GetAxisRaw("Horizontal");
            transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.deltaTime * -moveSpeed);

            //tactil
            if(Input.touchCount > 0) {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                if(touchPosition.x > 0) movement = 1.0f;
                else movement = -1.0f;
                transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.deltaTime * -moveSpeed);
            }
        } else if(menu){
            transform.RotateAround(Vector3.zero, Vector3.forward, 0.8f * Time.deltaTime * -moveSpeed);
        } else {

        }
    }

    public void startMove() {
        menu = false;
        move = true;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(move) {
            move = false;
            gameManager.GetComponent<GameManager>().endGame();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            ps.Emit(20);
        }
    }
}
