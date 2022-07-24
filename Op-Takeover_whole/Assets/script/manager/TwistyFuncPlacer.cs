using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwistyFuncPlacer : MonoBehaviour
{
   public Transform[] locations;
   public List<Transform> twistyfunc;

  

   private void Update() {
    int randomIndex = Random.Range(0, twistyfunc.Count);

    twistyfunc[randomIndex].transform.position = locations[randomIndex].transform.position;
   }

   

 
}
