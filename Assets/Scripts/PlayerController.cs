using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    KinectManager kinectManager;
    
    public float speedPlayerShip = 5.0f;
    public float paddingPlayerShip = 1f;

    float leftLimitX;
    float rightLimitX;

	// Use this for initialization
	void Start () {
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
        leftLimitX = leftmost.x + paddingPlayerShip;
        rightLimitX = rightmost.x - paddingPlayerShip;
	}

	// Update is called once per frame
	void Update () {

        long primaryUserID;
        long primaryUserIndex;

        if (kinectManager.IsUserDetected()) {
            primaryUserID = kinectManager.GetPrimaryUserID();
            primaryUserIndex = kinectManager.GetUserIndexById(primaryUserID);

            Debug.Log("primaryuserid:" + primaryUserID + " - primaryuserindex" + primaryUserIndex);
        }

        // bool leaning = gestureListener.GestureInProgress(primaryUserID, primaryUserIndex, KinectGestures.Gestures.LeanLeft, 0.6, KinectInterop.JointType.ShoulderLeft, new Vector3(0, 0, 0));

        // TODO hooks this up to Kinect controls
        // TODO use lean gesture to determine direction of playerShip movement
        // TODO use lean angle to change speedPlayerShip dynamically
        if (Input.GetKey(KeyCode.LeftArrow)) {
            this.transform.position += Vector3.left * speedPlayerShip * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            this.transform.position += Vector3.right * speedPlayerShip * Time.deltaTime;
        }

        float newX = Mathf.Clamp(transform.position.x, leftLimitX, rightLimitX);
        this.transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}
