
using UnityEngine;
using UnityEngine.Events;

public class MainMenuTrigger : MonoBehaviour
{
    public UnityEvent doSomething;
    private bool isCorrentAngle;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Pushable" && other.transform.parent == null)
        {
            //Debug.Log(other.transform.rotation.eulerAngles);
            if ((other.transform.rotation.eulerAngles.y > 315 || other.transform.rotation.eulerAngles.y < 45) && !isCorrentAngle)
            {
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
