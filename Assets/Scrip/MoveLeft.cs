using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float sleep = 30;
    private PlayerContoller playerContollerScrip;

    // Start is called before the first frame update
    void Start()
    {
        playerContollerScrip = GameObject.Find("Player").GetComponent<PlayerContoller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerContollerScrip.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * sleep);
        }
    }
}
