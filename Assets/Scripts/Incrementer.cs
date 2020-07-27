using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incrementer : MonoBehaviour
{
    public GameObject gameManager;

    void OnTriggerEnter2D(Collider2D collision) {
        gameManager.GetComponent<GameManager>().incrementScore();
    }
}
