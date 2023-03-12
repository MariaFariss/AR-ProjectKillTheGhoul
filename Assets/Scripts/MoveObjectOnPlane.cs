using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MoveObjectOnPlane : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager _arTrackedImageManager;
    [SerializeField] private float _moveSpeed = 0.1f;
    private Vector3 _targetPosition;

    private void OnEnable()
    {
        _arTrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage trackedImage in args.updated)
        {
            if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
            {
                _targetPosition = trackedImage.transform.position;
                _targetPosition.y = transform.position.y; // Maintain the current y position
            }
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
    }
}
