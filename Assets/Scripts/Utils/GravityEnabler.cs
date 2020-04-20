using UnityEngine;

public class GravityEnabler : MonoBehaviour
{
    public Rigidbody rigidbody;
    //public ManipulationHandler man;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        //man = gameObject.GetComponent<ManipulationHandler>();
        //man.OnManipulationEnded.AddListener(FallDown);
    }

    private void FallDown() {
        EnableGravity();
    }
    
    public void EnableGravity()
    {
    }

    public void DisableGravity()
    {
    }
    
}
