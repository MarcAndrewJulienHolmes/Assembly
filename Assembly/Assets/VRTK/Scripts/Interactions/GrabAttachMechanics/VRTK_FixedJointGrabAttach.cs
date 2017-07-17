﻿// Fixed Joint Grab Attach|GrabAttachMechanics|50040
namespace VRTK.GrabAttachMechanics
{
    using UnityEngine;

    /// <summary>
    /// The Fixed Joint Grab Attach script is used to create a simple Fixed Joint connection between the object and the grabbing object.
    /// </summary>
    /// <example>
    /// `VRTK/Examples/005_Controller_BasicObjectGrabbing` demonstrates this grab attach mechanic all of the grabbable objects in the scene.
    /// </example>
    [AddComponentMenu("VRTK/Scripts/Interactions/Grab Attach Mechanics/VRTK_FixedJointGrabAttach")]
    public class VRTK_FixedJointGrabAttach : VRTK_BaseJointGrabAttach
    {
        [Tooltip("Maximum force the joint can withstand before breaking. Infinity means unbreakable.")]
        public float breakForce = 1500f;

        protected override void CreateJoint(GameObject obj)
        {
            givenJoint = obj.AddComponent<FixedJoint>();
            if (grabbedObjectScript.validDrop == VRTK_InteractableObject.ValidDropTypes.NoCollisionDrop)
            {
                givenJoint.breakForce = Mathf.Infinity;
            }else if (grabbedObjectScript.validDrop == VRTK_InteractableObject.ValidDropTypes.DropClearAndValidDropSnap)
            {
                givenJoint.breakForce = Mathf.Infinity;
            }
            else
            {
                givenJoint.breakForce = (grabbedObjectScript.IsDroppable() ? breakForce : Mathf.Infinity);
            }
            base.CreateJoint(obj);
        }
    }
}