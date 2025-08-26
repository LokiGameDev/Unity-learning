using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private Camera sceneCamera;
    private Vector3 lastPosition;
    [SerializeField]
    private LayerMask placementLayerMask;

    #endregion

    public Vector3 GetSelectedMApPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = sceneCamera.nearClipPlane;
        Ray ray = sceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, placementLayerMask))
        {
            lastPosition = hit.point;
        }
        return lastPosition;
    }
}
