using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public enum CharacterType
    {
        Player,
        AI
    };

    //public Character Variables
    public float speed;
    public float rSpeed;
    public CharacterType type;

    public void characterMove(GameObject character)
    {
        if( type == CharacterType.Player)
        {
            float rotationX = Input.GetAxis("Vertical") * rSpeed;
            float rotationY = Input.GetAxis("Horizontal") * rSpeed;
            float cSpeed = Input.GetAxis("Fire1") * speed;



            rotationX *= Time.deltaTime;
            rotationY *= Time.deltaTime;
            cSpeed*= Time.deltaTime;

            float turnRight = rSpeed;
            float turnLeft = -rSpeed;

            turnRight *= Time.deltaTime;
            turnLeft *= Time.deltaTime;

            // pitch-- roll 
            character.transform.Rotate(rotationX, -rotationY, 0);
            character.transform.Translate(0, cSpeed, 0);

            if (Input.GetButton("Right"))
            {
                character.transform.Rotate(0, 0, turnRight);
            }
            else if(Input.GetButton("Left"))
            {
                character.transform.Rotate(0, 0, turnLeft);
            }
                

        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            //character.GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            //character.transform.LookAt(player.transform);
            float flying = rSpeed * Time.deltaTime;
            //character.transform.LookAt(player.transform);
            Vector3 dir = player.transform.position - character.transform.position;
            dir.y = 0; // keep the direction strictly horizontal
            Quaternion rot = Quaternion.LookRotation(dir);
            // slerp to the desired rotation over time
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, rot, flying);

            character.transform.position = Vector3.MoveTowards(character.transform.position, player.transform.position, flying);
        }
    }
}
