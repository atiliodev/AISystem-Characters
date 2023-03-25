using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class CharacterSystem : MonoBehaviour
{
  NavMeshAgent agent;
  Animator animator;
  WaypointProgressTracker waypoint;

  public Transform target;

  public bool set;
  Vector3 pos;
  bool walk = true;
  bool inTrigger;
  SphereCollider collider;
  private void Start()
  {
    waypoint = GetComponent<WaypointProgressTracker>();
    animator = GetComponent<Animator>();
    agent = GetComponent<NavMeshAgent>();
    collider = GetComponent<SphereCollider>();
  }
  bool wait = true;
  void Update()
  {
    pos = transform.position;

    animator.SetBool("walk", walk);
    set = walk;
    if (walk)
    {
      agent.SetDestination(target.transform.position);
    }
    else
    {
      agent.SetDestination(pos);
    }

    if (wait)
    {
      StartCoroutine("ApplySettings");
      wait = false;
    }
  }

  IEnumerator ApplySettings()
  {
    yield return new WaitForSeconds(3);
    collider.radius = Mathf.Lerp(collider.radius, 0, 1);
    yield return new WaitForSeconds(0.2f);
    collider.radius = Mathf.Lerp(collider.radius, 1, 1);
    yield return new WaitForSeconds(0.2f);
    collider.radius = Mathf.Lerp(collider.radius, 0, 1);
    yield return new WaitForSeconds(0.2f);
    collider.radius = Mathf.Lerp(collider.radius, 1, 1);
    wait = true;
  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "RCSystemCharacters" || other.tag == "RCSystem" || other.tag == "RCSystemAI")
    {
      inTrigger = true;
      walk = false;
    }
  }
  private void OnTriggerExit(Collider other)
  {
    if (other.tag == "RCSystemCharacters" || other.tag == "RCSystemAI" || other.tag == "RCSystem")
    {
      inTrigger = false;
      walk = true;
    }
  }

}
