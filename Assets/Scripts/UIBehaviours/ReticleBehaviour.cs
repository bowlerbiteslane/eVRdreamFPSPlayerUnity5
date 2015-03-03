using UnityEngine;
using System.Collections;

public class ReticleBehaviour : MonoBehaviour {

    public Texture2D retTexture = null;
    
    RectTransform retTransform;
    float currRetWidth;
    float currRetHeight;
    public float shootingRetModifier = 2f;

    //
    //  SCRIPT IS STILL IN THE WORKS
    //  THE GOAL IS TO RESIZE THE RETICLE WHEN THE PLAYER SHOOTS
    //  THIS IDEALLY WOULD GIVE THE PERCEPTION OF A LOSS OF PRECISION DURING RECOIL
    //  DOES NOT CURRENTLY WORK AS IS:
    //  MAY WANT TO CONSIDER CHANGING RETICLE TO AN IMAGE OBJECT RATHER THAN A RAW IMAGE...
    //  APPEARANTLY THIS HAS THE BENEFIT OF IMPROVING PERFORMANCE
    //
    
    // Use this for initialization
	void Start () {
        retTransform = this.gameObject.GetComponent<RectTransform>();
        currRetWidth = retTransform.rect.width;
        currRetHeight = retTransform.rect.height;
        Debug.Log("RetWidth: " + currRetWidth + " RetHeight: " + currRetHeight);
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CharacterShooting();
        }
    }

    void CharacterShooting()
    {
        retTransform.rect.Set(retTransform.rect.x, retTransform.rect.y, retTransform.rect.width*shootingRetModifier, retTransform.rect.height*shootingRetModifier);
        Debug.Log("Fire1 registered by ReticleBehaviour script");
    }

    void OnGUI()
    {
        if(retTexture!= null)
        GUI.DrawTexture(retTransform.rect, retTexture);
    }
}
