using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TwistyFunc_Manager : MonoBehaviour
{
    public int index;
    public string[] messages;
    public string speakerName;

    public float textSpeed;
    public bool allow_next;
    public bool allow_closing;

    public bool isBoss, isEnemy, isStory;

    public TextMeshProUGUI displayMessage;
    public TextMeshProUGUI speaker;

    public TwistyData twist;
    private void Start() {
        index = 0;
        displayMessage.text = string.Empty;
        
        messages = twist.dialogueData;
        speakerName = twist.speaker;
        StartCoroutine(OutputMessage(textSpeed));
    }

    private void Update() {
        speaker.text = twist.speaker;
        UdpateSprite();
         if(Input.GetKeyDown(KeyCode.Space)){
            NextMessage();
        }

        if(index > messages.Length - 1){
            displayMessage.text = "X TO CLOSE";
            allow_closing = true;
        }

        if(Input.GetKeyDown(KeyCode.X)&& allow_closing){
            CloseTwistyFunc();
        }

    }

    IEnumerator OutputMessage(float speed){
        foreach(char letters in messages[index].ToCharArray()){
            displayMessage.text += letters;
             yield return new WaitForSeconds(speed);
        }

          if(displayMessage.text == messages[index]){
            allow_next = true;
        }

    }

    void NextMessage(){
        if(allow_next){
            displayMessage.text = string.Empty;
        index++;
        StartCoroutine(OutputMessage(textSpeed));
        }
    }

    void CloseTwistyFunc(){
        Destroy(gameObject);
        displayMessage.text = string.Empty;
        // add particle effect
    }

    void UdpateSprite(){
        if(isBoss){
            GameObject.FindGameObjectWithTag("dialoguesprite").GetComponent<SpriteRenderer>().sprite = twist.bossSprite;
        }

        if(isEnemy){
           GameObject.FindGameObjectWithTag("dialoguesprite").GetComponent<SpriteRenderer>().sprite = twist.enemySprite;
        }

        if(isStory){
            GameObject.FindGameObjectWithTag("dialoguesprite").GetComponent<SpriteRenderer>().sprite = twist.storrySprite;
        }
    }

 
}
