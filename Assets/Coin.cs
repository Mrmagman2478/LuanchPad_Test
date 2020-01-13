using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int score;
    public float rSpeed;

    // Update is called once per frame
    void Update()
    {
        float rot = rSpeed;

        rot *= Time.deltaTime;
        this.transform.Rotate(0, rot, 0);
    }
}
