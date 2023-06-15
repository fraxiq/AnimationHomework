using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    public UI gameUI;
    public AudioSource planeEngine;
    private bool dead = false;
    private float targetPitch = 0.1f;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Gate"))
        {
            gameUI.UpdateTimer();
            gameUI.UpdateGateCounter();

            UpdateFlames(other);
            UpdateAnimations(other);
            
        }
    }

    private void UpdateFlames(Collider other)
    {
        other.GetComponent<FlameController>().ToggleFlames(false);

        int index = other.transform.GetSiblingIndex();

        if (other.transform.parent.childCount > index + 1)
        {
            Transform nextNode = other.transform.parent.GetChild(index + 1);
            if (nextNode)
            {
                nextNode.transform.GetComponent<FlameController>().ToggleFlames(true);
            }
        }
    }
    private void UpdateAnimations(Collider other)
    {
        other.GetComponent<AnimationPlayer>().StopAnimation(true);

        int index = other.transform.GetSiblingIndex();

        if (other.transform.parent.childCount > index + 1)
        {
            Transform nextNode = other.transform.parent.GetChild(index + 1);
            if (nextNode)
            {
                nextNode.transform.GetComponent<AnimationPlayer>().PlayAnimation(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameUI.ShowGameOverScreenDeath();
        dead = true;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
        }
    }
    private void Update()
    {
        if (dead)
        {
            planeEngine.pitch = Mathf.MoveTowards(planeEngine.pitch, targetPitch, planeEngine.pitch * Time.deltaTime);
        }
        
    }
}
