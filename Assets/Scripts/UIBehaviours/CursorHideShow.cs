using UnityEngine;
using System.Collections;

public class CursorHideShow : MonoBehaviour {

    bool isLocked;

	// Use this for initialization
	void Start () {
        isLocked = true;
        Screen.lockCursor = true;
        Cursor.visible = false;
	}

    void SetCursorLock(bool locked)
    {
        this.isLocked = locked;
        Screen.lockCursor = locked;
        Cursor.visible = !locked;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetCursorLock(!isLocked);
        }
	
	}
}
