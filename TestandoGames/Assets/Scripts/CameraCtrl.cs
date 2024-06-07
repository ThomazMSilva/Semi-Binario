using UnityEngine;


public enum CameraMode 
{ 
    Following,
    Cutscene,
}
public class CameraCtrl : MonoBehaviour
{
    private CameraMode mCameraMode = CameraMode.Following;
    private Vector3 
        offset = new(0, 0, -10f),
        velocity = Vector3.zero;
    [SerializeField] Transform player;
    [SerializeField] float smoothTime = .25f;

    private void FixedUpdate()
    {
        switch (mCameraMode)
        {
            case CameraMode.Following:
                Vector3 targetPosition = player.position + offset;
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

                break;
            case CameraMode.Cutscene:
                break;
            
            default: break;
        }
        
    }

    public void SetCamStateFollowing()
    {
        mCameraMode = CameraMode.Following;
    }
    public void SetCamStateCutscene()
    {
        mCameraMode = CameraMode.Cutscene;
    }
}
