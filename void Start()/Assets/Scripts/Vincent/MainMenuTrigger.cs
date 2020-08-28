
using UnityEngine;
using UnityEngine.Events;

public class MainMenuTrigger : MonoBehaviour
{
    public UnityEvent doSomething;
    SP_Player_GridDirectionalMove sp;
    private bool isCorrentAngle;

    private void Start()
    {
        sp = FindObjectOfType<SP_Player_GridDirectionalMove>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Pushable" && !sp.isHolding)
        {
            if (!isCorrentAngle) {
                doSomething?.Invoke();
                isCorrentAngle = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pushable") {
            isCorrentAngle = false;
        }
    }
}
