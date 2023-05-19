using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectCollision : MonoBehaviour
{
    [SerializeField] string detectionTag;

    [SerializeField] UnityEvent OnEnter, OnStay, OnExit;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag(detectionTag))
        {
            OnEnter.Invoke();
            Debug.Log("Enter");
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.transform.CompareTag(detectionTag))
        {
            OnStay.Invoke();
            Debug.Log("Stay");
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.transform.CompareTag(detectionTag))
        {
            OnExit.Invoke();
            Debug.Log("Exit");
        }
    }
}
