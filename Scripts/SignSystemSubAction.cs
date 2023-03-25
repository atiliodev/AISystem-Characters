using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignSystemSubAction : MonoBehaviour
{
  public SignSystem system;
  public CarAISystem carAI;
  bool inHere;

  void Update()
  {
    inHere = system.canPass;
    if (carAI != null)
    {
      if (system.canPass && carAI.obstacle)
      {
        carAI.obstacle = false;
        carAI.RestTime();
        carAI = null;
      }
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    carAI = other.GetComponent<CarAISystem>();
    if (carAI != null && !system.canPass)
    {
      carAI.obstacle = true;
    }
    if (carAI != null && system.canPass)
    {
      carAI.obstacle = false;
      carAI.RestTime();
      carAI = null;
    }
  }

}
