using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	
	private Animator hammerDown;
	private LineRenderer laserline;
	private GameObject camera;
	private GameObject laserBegin;
	private GameObject laserEnd;
	public bool fire = false;
	public Vector3 shootDirection;
	public Vector3 rayOrigin;
    public AudioClip lasersound;
    private AudioSource source;

    // Use this for initialization
    void Start () {
		GameObject hammerObject = GameObject.FindGameObjectWithTag ("Hammer");
		GameObject laserLineObject = GameObject.FindGameObjectWithTag ("Laser");
		GameObject laserBeginObject = GameObject.FindGameObjectWithTag ("HammerTip");
		GameObject laserEndObject = GameObject.FindGameObjectWithTag ("LaserEnd");
		GameObject cameraObject = GameObject.FindGameObjectWithTag ("MainCamera");
		if (hammerObject != null && laserLineObject != null)
		{
			hammerDown = hammerObject.GetComponent <Animator>();
			camera = cameraObject;
			laserline = laserLineObject.GetComponent <LineRenderer> ();
			laserline.enabled = false;
			laserBegin = laserBeginObject;
			laserEnd = laserEndObject;
			hammerDown.Play ("AxeUp");
		}
		if (hammerDown == null || laserline == null)
		{
			Debug.Log ("GameObject initialize error");
		}
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		hammerDown.speed = 2;
		hammerDown.Play ("AxeDown");
		//Debug.Log ("pointer down!");
		fire = true;
        StartCoroutine ("FireLaser");
        //source.Play();
    }
		
	public void OnPointerUp(PointerEventData eventData)
	{
		fire = false;
		hammerDown.speed = 3;
		hammerDown.Play ("AxeUp");
		//Debug.Log ("pointer Up!");
	}

	IEnumerator FireLaser (){
		laserline.enabled = true;
        source.Play();
        while (fire) {
            rayOrigin = laserBegin.transform.position;
			shootDirection = camera.transform.forward;
			shootDirection = shootDirection * 100 - rayOrigin;
			laserBegin.transform.forward = shootDirection;
			laserEnd.transform.position = shootDirection + rayOrigin;

			yield return null;
		}
        source.Stop();
        laserline.enabled = false;
        
    }
}
