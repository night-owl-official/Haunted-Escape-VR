using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Assertions;

[RequireComponent(typeof(Animator))]
public class HandsAnimationManager : MonoBehaviour {
    #region Methods
    // Start is called before the first frame update
    private void Start() {
        handAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update() {
        AnimatePinchAction();
        AnimateGripAction();
    }

    /// <summary>
    /// It sets the animation parameter used for the pinch action,
    /// using the input action tied to it.
    /// </summary>
    private void AnimatePinchAction() {
        Assert.IsNotNull(handAnimator, "Warning: Animator component is missing!");

        float triggerBtnVal = pinchAction.action.ReadValue<float>();
        handAnimator.SetFloat(pinchParamName, triggerBtnVal);
    }

    /// <summary>
    /// It sets the animation parameter used for the grib action,
    /// using the input action tied to it.
    /// </summary>
    private void AnimateGripAction() {
        Assert.IsNotNull(handAnimator, "Warning: Animator component is missing!");

        float gripBtnVal = gripAction.action.ReadValue<float>();
        handAnimator.SetFloat(gripParamName, gripBtnVal);
    }
    #endregion

    #region Member variables
    [Header("Pinch Animation")]

    [SerializeField]
    private string pinchParamName = "Trigger";
    [SerializeField]
    private InputActionProperty pinchAction;

    [Header("Grip Animation")]

    [SerializeField]
    private string gripParamName = "Grip";
    [SerializeField]
    private InputActionProperty gripAction;

    private Animator handAnimator = null;
    #endregion
}
