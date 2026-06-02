using UnityEngine;
using UnityEngine.InputSystem;

public class DragManager : MonoBehaviour
{
    private Camera cam;
    
	[Range (0.0f, 100.0f),SerializeField] private float damping = 1.0f;
	[Range (0.0f, 100.0f),SerializeField] private float frequency = 5.0f;
	private TargetJoint2D targetJoint;
    public LayerMask dragLayerMask;
    
    [Header("AudioFX")]private AudioSource AS;
    [SerializeField] private AudioClip pick, drop;
    void Awake()
    {
        cam = Camera.main;
        AS = GetComponent<AudioSource>();
    }
    void Update ()
	{
		var currentMouse = Mouse.current;
		var worldPos = cam.ScreenToWorldPoint (currentMouse.position.ReadValue()); // I dont want to find camera every frame, so ill get ref in awake

		if (currentMouse.leftButton.wasPressedThisFrame)
		{
			var collider = Physics2D.OverlapPoint (worldPos, dragLayerMask);
			if (!collider)
            {
                return;
            }
			var body = collider.attachedRigidbody;
			if (!body)
            {
                return;
            }

			targetJoint = body.gameObject.AddComponent<TargetJoint2D> ();
			targetJoint.dampingRatio = dragLayerMask;
			targetJoint.frequency = frequency;

			targetJoint.anchor = targetJoint.transform.InverseTransformPoint (worldPos);	
            AS.PlayOneShot(pick,PlayerPrefs.GetFloat("FXVolume"));	
		}
		else if (currentMouse.leftButton.wasReleasedThisFrame)
		{
            if(targetJoint)
            {AS.PlayOneShot(drop,PlayerPrefs.GetFloat("FXVolume"));}
			Destroy (targetJoint);
			targetJoint = null;
			return;
		}

		if (targetJoint)
		{
			targetJoint.target = worldPos;
		}
	}
}
