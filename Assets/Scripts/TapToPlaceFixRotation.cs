using HoloToolkit.Unity;
using HoloToolkit.Unity.SpatialMapping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlaceFixRotation : TapToPlace {

    // Update is called once per frame
    protected override void Update () {
        if (!IsBeingPlaced) { return; }
        Transform cameraTransform = CameraCache.Main.transform;

        Vector3 placementPosition = GetPlacementPosition(cameraTransform.position, cameraTransform.forward, DefaultGazeDistance);

        if (UseColliderCenter)
        {
            placementPosition += PlacementPosOffset;
        }

        // Here is where you might consider adding intelligence
        // to how the object is placed.  For example, consider
        // placing based on the bottom of the object's
        // collider so it sits properly on surfaces.

        if (PlaceParentOnTap)
        {
            placementPosition = ParentGameObjectToPlace.transform.position + (placementPosition - gameObject.transform.position);
        }

        // update the placement to match the user's gaze.
        interpolator.SetTargetPosition(placementPosition);

        // Rotate this object to face the user.
        //interpolator.SetTargetRotation(Quaternion.Euler(0, cameraTransform.localEulerAngles.y, 0));
        interpolator.gameObject.transform.LookAt(GameObject.Find("MixedRealityCamera").transform);
        interpolator.gameObject.transform.Rotate(90, 0, 0);
    }
}
