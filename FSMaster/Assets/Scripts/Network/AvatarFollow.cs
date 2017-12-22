using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarFollow : MonoBehaviour {
    public Transform AHead;
    public Transform ALHand;
    public Transform ARHand;

    public Transform Head;
    public Transform LHand;
    public Transform RHand;

	void FixedUpdate () {
        Head.rotation = AHead.rotation;
        Head.position = AHead.position;
        RHand.rotation = ARHand.rotation;
        RHand.position = ARHand.position;
        LHand.rotation = ALHand.rotation;
        LHand.position = ALHand.position;
    }
}
