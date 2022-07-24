using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TwistyData", menuName = "ScriptableObjects/twistyData")]
public class TwistyData : ScriptableObject
{
    public string speaker;
    [TextArea(3, 10)]
    public string[] dialogueData;

    public Sprite bossSprite, enemySprite, storrySprite;




    
}
