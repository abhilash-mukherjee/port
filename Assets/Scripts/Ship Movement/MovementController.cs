using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (FloatObjectScript))]
public class MovementController : MonoBehaviour
{
    public Vector3 COM_Position;
    [Space (15)]
    public float speed = 1.0f;
    public float steerSpeed = 1.0f;
    public float movementThresold = 10.0f;
    [SerializeField]
    private Transform pivot;
    [SerializeField]
    private InputSystem lateralInputSystem, linearInputSystem;
    [SerializeField] private float backwardMovementMultiplier = 0.3f;
    [SerializeField] private float breakMultiplier = 4;
    [SerializeField] private float oppositeSteerMultiplier = 3;
    Transform m_COM;
    float movementFactor;
    float steerFactor;
    private void Start()
    {
        lateralInputSystem.StartInput();
        linearInputSystem.StartInput();
    }
    void Update()
    {
        Balance ();
	Movement ();
	Steer ();
    }
	
    void Balance () {
		GetComponent<Rigidbody> ().centerOfMass = getCOM().position;
	}

    void Movement () {
		/*movementFactor = Mathf.Lerp (movementFactor, linearInputSystem.GetInput(), Time.deltaTime / movementThresold);
        if(linearInputSystem.GetInput() >=0 )  
        {
            transform.Translate(movementFactor * speed, 0.0f, 0.0f);
        }
        else
        {*/
            var backwardMultiplier = movementFactor > 0 ? breakMultiplier : backwardMovementMultiplier;
            transform.Translate(speed * linearInputSystem.GetInput(), 0.0f, 0.0f);
        /*}*/

		
	}

     void Steer () {

		steerFactor = Mathf.Lerp (steerFactor, lateralInputSystem.GetInput() * movementFactor, Time.deltaTime / movementThresold);
        /*if(steerFactor * lateralInputSystem.GetInput() < 0)
        {
            steerFactor = Mathf.Lerp(steerFactor, lateralInputSystem.GetInput() * movementFactor * oppositeSteerMultiplier, Time.deltaTime / movementThresold);
        }*/
        transform.RotateAround(pivot.position, Vector3.up, Time.deltaTime * steerSpeed * lateralInputSystem.GetInput());

	}
    Transform getCOM()
    {
        if (!m_COM) {
			    m_COM = new GameObject ("COM").transform;
			    m_COM.SetParent (transform);
		    }
        		    m_COM.position = COM_Position;
            return m_COM;
    }
}

