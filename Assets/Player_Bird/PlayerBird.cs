using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBird : MonoBehaviour
{
    public Character character;
    public UI_Scripts uI_Script;
    public int score;
    public Text scoreText;
    public Text timeText;
    public Camera endCamera;
    float time = 0.0f;
    int min = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        character.characterMove(this.gameObject);
        scoreText.text = "Score: " + score;

        time += Time.deltaTime;
        if (time >= 60)
        {
            min++;
            time = 0;
        }

        timeText.text =""+ min +": "+ (int)time ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Coin coin = other.gameObject.GetComponent<Coin>();
            score = score + coin.score;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Dragon")
        {
            uI_Script.GameState = UI_Scripts.StateOfGame.End;
            this.gameObject.SetActive(false);
            uI_Script.getInfo(score, "You Died");
            Destroy(this.gameObject);
            endCamera.enabled = true;
        }

        if (other.gameObject.tag == "Finish")
        {
            uI_Script.GameState = UI_Scripts.StateOfGame.End;
            uI_Script.getInfo(score, "You Won");
        }
    }

}
