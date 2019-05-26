using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class police : MonoBehaviour {
		
		float crouching = 1f;
		float runtimer = 2f;
		float runtime = 2f;
		float bending = 0f;
		public float movespeed = 0.05f;
		public float mouseSensitivity = 1f;
		public GameObject head;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		domovement();
		dorotation();
		if (Input.GetKey("w")){
			run();
		}
		if (Input.GetKeyUp("w")){
			runtimer = runtime;
			stand();
		}
		action();
	}
	void domovement()
    {
        Quaternion rotY = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        Vector3 v = Input.GetAxis("Vertical")*(rotY*Vector3.forward)
                    +Input.GetAxis("Horizontal") * (rotY * Vector3.right);
        /*if (Input.GetButton("Jump")) movement.jump(v);
        else*/ move(v);
    }
	void dorotation()
    {
        rotate(
            -mouseSensitivity * Input.GetAxis("Mouse Y"),
			mouseSensitivity * Input.GetAxis("Mouse X")
            );
    }
	
	public void move(Vector3 v)
    {
        transform.localPosition += movespeed * v;
    }
	
	public void rotate(float deltaX,float deltaY)
    {
        Vector3 angle = head.transform.localRotation.eulerAngles;
        angle.x += deltaX;
        if (angle.x > 90f && angle.x < 270f)
        {
            if(deltaX > 0)
            {
                angle.x = 90f;
            }else{
                angle.x = 270f;
            }
        }
        head.transform.localRotation = Quaternion.Euler(angle);
		angle = transform.localRotation.eulerAngles;
		angle.y += deltaY;
		transform.localRotation = Quaternion.Euler(angle);
    }
	
	void action(){
		if (Input.GetKeyDown("c")){
			movespeed = 0.025f;
			if (crouching == 2f) crouching = 0f;
		}
		if (crouching<1f){
			crouching += Time.deltaTime;
			Vector3 v = transform.GetChild(0).localRotation.eulerAngles;
			v.x += 0.8f;
			transform.GetChild(0).localRotation = Quaternion.Euler(v);
			
			v = transform.GetChild(0).GetChild(2).localRotation.eulerAngles;
			v.x -= 1f;
			transform.GetChild(0).GetChild(2).localRotation = Quaternion.Euler(v);
			transform.GetChild(0).GetChild(3).localRotation = Quaternion.Euler(v);
			
			v = transform.GetChild(1).localRotation.eulerAngles;
			v.x -= 1f;
			transform.GetChild(1).localRotation = Quaternion.Euler(v);
			transform.GetChild(2).localRotation = Quaternion.Euler(v);
			
			v = transform.GetChild(1).GetChild(1).localRotation.eulerAngles;
			bending += 2.5f;
			v.x = bending;
			transform.GetChild(1).GetChild(1).localRotation = Quaternion.Euler(v);
			transform.GetChild(2).GetChild(1).localRotation = Quaternion.Euler(v);
		}else {crouching = 2f;}
		if (Input.GetKeyDown("x")){
			bending = 0f;
			movespeed = 0.05f;
			stand();
		}
		
	}

	void run(){
		runtimer += Time.deltaTime;
		if (runtimer<1){
			Vector3 v = transform.GetChild(0).GetChild(2).localRotation.eulerAngles;
			v.x += 2f;
			transform.GetChild(0).GetChild(2).localRotation = Quaternion.Euler(v);
			v = transform.GetChild(0).GetChild(2).GetChild(1).localRotation.eulerAngles;
			v.x += Time.deltaTime*40f;
			transform.GetChild(0).GetChild(2).GetChild(1).localRotation = Quaternion.Euler(v);
			v = transform.GetChild(0).GetChild(3).localRotation.eulerAngles;
			v.x -= 2f;
			transform.GetChild(0).GetChild(3).localRotation = Quaternion.Euler(v);
			v = transform.GetChild(0).GetChild(3).GetChild(1).localRotation.eulerAngles;
			v.x -= Time.deltaTime*40f;
			transform.GetChild(0).GetChild(3).GetChild(1).localRotation = Quaternion.Euler(v);
			
			v = transform.GetChild(1).localRotation.eulerAngles;
			v.x += Time.deltaTime*80f;
			transform.GetChild(1).localRotation = Quaternion.Euler(v);
			v = transform.GetChild(1).GetChild(1).localRotation.eulerAngles;
			v.x -= Time.deltaTime*70f;
			transform.GetChild(1).GetChild(1).localRotation = Quaternion.Euler(v);
			v = transform.GetChild(2).localRotation.eulerAngles;
			v.x -= Time.deltaTime*80f;
			transform.GetChild(2).localRotation = Quaternion.Euler(v);
			v = transform.GetChild(2).GetChild(1).localRotation.eulerAngles;
			v.x += Time.deltaTime*70f;
			transform.GetChild(2).GetChild(1).localRotation = Quaternion.Euler(v);
		}else if(runtimer<runtime){
			Vector3 v = transform.GetChild(0).GetChild(2).localRotation.eulerAngles;
			v.x -= 2f;
			transform.GetChild(0).GetChild(2).localRotation = Quaternion.Euler(v);
			v = transform.GetChild(0).GetChild(2).GetChild(1).localRotation.eulerAngles;
			v.x -= Time.deltaTime*40f;
			transform.GetChild(0).GetChild(2).GetChild(1).localRotation = Quaternion.Euler(v);
			v = transform.GetChild(0).GetChild(3).localRotation.eulerAngles;
			v.x += 2f;
			transform.GetChild(0).GetChild(3).localRotation = Quaternion.Euler(v);
			v = transform.GetChild(0).GetChild(3).GetChild(1).localRotation.eulerAngles;
			v.x += Time.deltaTime*40f;
			transform.GetChild(0).GetChild(3).GetChild(1).localRotation = Quaternion.Euler(v);
			
			v = transform.GetChild(1).localRotation.eulerAngles;
			v.x -= Time.deltaTime*80f;
			transform.GetChild(1).localRotation = Quaternion.Euler(v);
			v = transform.GetChild(1).GetChild(1).localRotation.eulerAngles;
			v.x += Time.deltaTime*70f;
			transform.GetChild(1).GetChild(1).localRotation = Quaternion.Euler(v);
			v = transform.GetChild(2).localRotation.eulerAngles;
			v.x += Time.deltaTime*80f;
			transform.GetChild(2).localRotation = Quaternion.Euler(v);
			v = transform.GetChild(2).GetChild(1).localRotation.eulerAngles;
			v.x -= Time.deltaTime*70f;
			transform.GetChild(2).GetChild(1).localRotation = Quaternion.Euler(v);
		}else{
			transform.GetChild(0).GetChild(2).localRotation = Quaternion.Euler(-60,0,0);
			transform.GetChild(0).GetChild(2).GetChild(1).localRotation = Quaternion.Euler(-70,0,0);
			transform.GetChild(0).GetChild(3).localRotation = Quaternion.Euler(40,0,0);
			transform.GetChild(0).GetChild(3).GetChild(1).localRotation = Quaternion.Euler(-20,0,0);
			transform.GetChild(1).localRotation = Quaternion.Euler(-50,0,0);
			transform.GetChild(1).GetChild(1).localRotation = Quaternion.Euler(90,0,0);
			transform.GetChild(2).localRotation = Quaternion.Euler(30,0,0);
			transform.GetChild(2).GetChild(1).localRotation = Quaternion.Euler(20,0,0);
			runtimer = 0;
		}
		
	}
	void stand(){
		transform.GetChild(0).localRotation = Quaternion.Euler(0,0,0);
		transform.GetChild(0).GetChild(2).localRotation = Quaternion.Euler(0,0,0);
		transform.GetChild(0).GetChild(2).GetChild(1).localRotation = Quaternion.Euler(-20,0,0);
		transform.GetChild(0).GetChild(3).localRotation = Quaternion.Euler(0,0,0);
		transform.GetChild(0).GetChild(3).GetChild(1).localRotation = Quaternion.Euler(-20,0,0);
		transform.GetChild(1).localRotation = Quaternion.Euler(0,0,0);
		transform.GetChild(1).GetChild(1).localRotation = Quaternion.Euler(0,0,0);
		transform.GetChild(2).localRotation = Quaternion.Euler(0,0,0);
		transform.GetChild(2).GetChild(1).localRotation = Quaternion.Euler(0,0,0);
	}
}