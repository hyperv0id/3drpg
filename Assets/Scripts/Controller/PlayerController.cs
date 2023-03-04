using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        MouseManager.Instance.OnMouseClicked += MoveToTarget;
    }
    private void Update()
    {
        ChangeAnimation();
    }
    public void MoveToTarget(Vector3 target)
    {
        agent.destination = target;
    }
    private void ChangeAnimation()
    {
        anim.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }
}