using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Assertions;

public class XRTwoAttachGrabInteractable : XRGrabInteractable {
    #region Methods
    protected override void OnSelectEntered(SelectEnterEventArgs args) {
        Assert.IsNotNull(rightHandAttachPoint, "Warning: No right hand attach point!");
        Assert.IsNotNull(leftHandAttachPoint, "Warning: No left hand attach point!");

        if (args.interactorObject.transform.CompareTag(rightHandTag))
            attachTransform = rightHandAttachPoint;
        else if (args.interactorObject.transform.CompareTag(leftHandTag))
            attachTransform = leftHandAttachPoint;

        base.OnSelectEntered(args);
    }
    #endregion

    #region Member variables
    [Header("Custom Attach Points")]

    [SerializeField]
    private string rightHandTag = "Right Hand Controller";
    [SerializeField]
    private Transform rightHandAttachPoint = null;

    [SerializeField]
    private string leftHandTag = "Left Hand Controller";
    [SerializeField]
    private Transform leftHandAttachPoint = null;
    #endregion
}
