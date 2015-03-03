using UnityEngine;
using System.Collections;

public class MatchTransform : MonoBehaviour {

    public Transform parentTransform;

	// Use this for initialization
	void Start () {
        if (parentTransform == null)
        {
            Debug.Log("There is no transform object attached to this script. Disabling script.");
            this.enabled = false;
        }
	}
	
	// Update is called once per frame
	void LateUpdate () {
        this.transform.position = parentTransform.position;
        this.transform.rotation = parentTransform.rotation;
	}
}
