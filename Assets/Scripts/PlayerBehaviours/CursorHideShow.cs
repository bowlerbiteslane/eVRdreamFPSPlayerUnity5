using UnityEngine;
using System.Collections;

public class CursorHideShow : MonoBehaviour {

    bool isLocked;

	// Use this for initialization
	void Start () {
        isLocked = true;
        Screen.lockCursor = true;
        Screen.showCursor = false;
	}

    void SetCursorLock(bool locked)
    {
        this.isLocked = locked;
        Screen.lockCursor = locked;
        Screen.showCursor = !locked;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetCursorLock(!isLocked);
        }
	
	}
}
