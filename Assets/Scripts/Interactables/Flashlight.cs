using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Flashlight : MonoBehaviour {
    #region Methods
    // Start is called before the first frame update
    void Start() {
        SetupGrabInteractable();

        if (!lightBeam)
            lightBeam = GetComponentInChildren<Light>();
    }

    private void SetupGrabInteractable() {
        if (!grabInteractable)
            grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.activated.AddListener(ToggleLight);
    }

    private void ToggleLight(ActivateEventArgs args) {
        isLightOn = !isLightOn;
        lightBeam.gameObject.SetActive(isLightOn);
    }
    #endregion

    #region Member variables
    [SerializeField]
    [Tooltip("Grab Interactable component used by this interactable." +
        "If none is assigned, it will use the one attached to this gameobject.")]
    private XRGrabInteractable grabInteractable = null;

    [SerializeField]
    [Tooltip("The light component associated with this flashlight." +
        "If none is assigned, it will use the one attached as a child object.")]
    private Light lightBeam = null;

    private bool isLightOn = false;
    #endregion
}
