using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    string userState;

    // Update is called once per frame
    private void FixedUpdate() {
        GetState();
        CheckState();
    }

    private void CheckState() {
        // if (userState == "onTheGround") {
        //     RunWhileOnThegRound();
        //     JumpWhileOnTheGround();
        // } else if (userState == "onTheRope") {
        //     RunWhileOnTheRope();
        //     JumpWhileOnTheRope();
        // } else if (userState == "onTheMagnet") {
        //     RunWhileOnTheMagnet();
        //     JumpWhileOnTheMagnet();
        // }
    }

    void Run() {
        if (userState == "runningOnTheGround") {
            // ...
        } else if (userState == "runningWhileClimbing") {
            // ...
        }
    }

    void Climb() {
        if (userState == "runningOnTheGround") {
            // ...
        } else if (userState == "runningWhileClimbing") {
            // ...
        }
    }

    void Jump() {
        if (userState == "runningOnTheGround") {
            // ...
        } else if (userState == "runningWhileClimbing") {
            // ...
        }
    }

    private void GetState() {
        // if (isRunning && isOnTheGround) {
        //     userState = "runningOnTheGround";
        // } else if (isRunning && isClimbing) {
        //     userState = "runningWhileClimbing";
        // } else if () {

        // } else if () {

        // }

        // .... bunch of else if
    }
}
