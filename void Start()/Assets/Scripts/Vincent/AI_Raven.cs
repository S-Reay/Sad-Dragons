using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateBehaviour {
    idle,
    Flyaway,
    Patrol,
    FindLandingPoint,
}

public class AI_Raven : MonoBehaviour
{
    public AudioSource SFX;
    public float flyAwaySpeed = 4f;
    public Vector2 idleTimer = new Vector2(2,5);
    public Vector2 patrolTimer = new Vector2(5,10);
    private float randomTimeToFlyAway;
    private float randomTimeToPatrol;
    public StateBehaviour state;
    public List<Transform> patrolPoints;
    int randomPatrolIndex;

    Animator anim;
    public Transform landingPoint { set; get; }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        randomTimeToFlyAway = Random.Range(idleTimer.x,idleTimer.y);
    }
 
    private void Update()
    {
        switch (state) {
            case StateBehaviour.idle:
                if (randomTimeToFlyAway > 0)
                {
                    randomTimeToFlyAway -= Time.deltaTime;
                }
                else {
                    anim.SetTrigger("FlyAway");
                    state = StateBehaviour.Flyaway;
                    
                }
                break;
            case StateBehaviour.Flyaway:
                randomPatrolIndex = Random.Range(0,patrolPoints.Count);
                randomTimeToPatrol = Random.Range(patrolTimer.x,patrolTimer.y);
                state = StateBehaviour.Patrol;
                break;
            case StateBehaviour.Patrol:
                if (randomTimeToPatrol > 0)
                {
                    randomTimeToPatrol -= Time.deltaTime;
                    if (Vector3.Distance(transform.position, patrolPoints[randomPatrolIndex].position) > 0.3f)
                    {
                        SFX = GetComponent<AudioSource>();
                        SFX.Play(0);
                        transform.LookAt(patrolPoints[randomPatrolIndex].position);
                        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[randomPatrolIndex].position, Time.deltaTime * flyAwaySpeed);
                    }
                    else
                    {
                        randomPatrolIndex = Random.Range(0, patrolPoints.Count);
                    }
                }
                else {
                    state = StateBehaviour.FindLandingPoint;
                }
                break;
            case StateBehaviour.FindLandingPoint:
                if (landingPoint != null) {
                    if (Vector3.Distance(transform.position, landingPoint.position) > 0.3f)
                    {
                        transform.LookAt(landingPoint.position);
                        transform.position = Vector3.MoveTowards(transform.position, landingPoint.position, Time.deltaTime * flyAwaySpeed);
                        SFX = GetComponent<AudioSource>();
                        SFX.Play(0);
                    }
                    else {
                        randomTimeToFlyAway = Random.Range(idleTimer.x, idleTimer.y);
                        anim.SetTrigger("Landing");
                        landingPoint = null;
                        state = StateBehaviour.idle;
                    }
                }
                break;
        }
       
    }
}
