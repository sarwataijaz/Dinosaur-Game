using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicScript : MonoBehaviour
{

    public GameManager game;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("Game").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            game.addScore(1);
        }
    }
}
