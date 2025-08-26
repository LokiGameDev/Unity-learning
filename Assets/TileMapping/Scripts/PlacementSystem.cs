using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject mouseIndicator, cellIndicator;
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private Grid grid;

    private void Update()
    {
        Vector3 mousePoistion = inputManager.GetSelectedMApPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePoistion);
        mouseIndicator.transform.position = mousePoistion;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }
}
