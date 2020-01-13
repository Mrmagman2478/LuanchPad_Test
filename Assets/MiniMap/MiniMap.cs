using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    void LateUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector3 newPosition = player.transform.position;
        newPosition.y = this.transform.position.y;
        this.transform.position = newPosition;
    }
}
