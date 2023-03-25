using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignSystem : MonoBehaviour
{
  [Header("Tenha atenção luz: Verde-Element0;Laranja-Element1;Vermelha-Elemento2")]
  public GameObject[] lights;
  [Header("Tenha atenção trigger: Car-Element0;Character-Element1;")]
  public BoxCollider[] triggers;
  [Space(15)]
  public float timeOfWait = 5f;
  [Space(15)]
  public bool invert;

  public bool canPass;
  bool wait = true;

  private void Start()
  {
    transform.tag = "RCSystemAI";
  }

  private void Update()
  {
    if (wait && !invert)
    {
      StartCoroutine("SignBaseLoop");
      wait = false;
    }
    else if (wait && invert)
    {
      StartCoroutine("SignBaseLoopIn");
      wait = false;
    }
  }

  IEnumerator SignBaseLoop()
  {
    yield return new WaitForSeconds(0);
    lights[0].SetActive(true);
    lights[1].SetActive(false);
    lights[2].SetActive(false);
    triggers[1].isTrigger = false;
    triggers[0].isTrigger = false;
    canPass = true;
    yield return new WaitForSeconds(timeOfWait);
    lights[1].SetActive(true);
    lights[0].SetActive(false);
    lights[2].SetActive(false);
    yield return new WaitForSeconds(1);
    triggers[1].isTrigger = true;
    triggers[0].isTrigger = true;
    yield return new WaitForSeconds(0.2f);
    triggers[1].isTrigger = false;
    triggers[0].isTrigger = false;
    yield return new WaitForSeconds(0.1f);
    lights[2].SetActive(true);
    lights[1].SetActive(false);
    lights[0].SetActive(false);
    triggers[1].isTrigger = true;
    triggers[0].isTrigger = true;
    canPass = false;
    yield return new WaitForSeconds(timeOfWait);
    wait = true;

  }


  IEnumerator SignBaseLoopIn()
  {
    yield return new WaitForSeconds(0);
    lights[2].SetActive(true);
    lights[0].SetActive(false);
    lights[1].SetActive(false);
    triggers[1].isTrigger = true;
    triggers[0].isTrigger = true;
    canPass = false;
    yield return new WaitForSeconds(timeOfWait);
    lights[1].SetActive(true);
    lights[0].SetActive(false);
    lights[2].SetActive(false);
    yield return new WaitForSeconds(1);
    triggers[1].isTrigger = false;
    triggers[0].isTrigger = false;
    yield return new WaitForSeconds(0.2f);
    triggers[1].isTrigger = true;
    triggers[0].isTrigger = true;
    yield return new WaitForSeconds(0.1f);
    lights[0].SetActive(true);
    lights[1].SetActive(false);
    lights[2].SetActive(false);
    triggers[1].isTrigger = false;
    triggers[0].isTrigger = false;
    canPass = true;
    yield return new WaitForSeconds(timeOfWait);
    wait = true;

  }

}
