using UnityEngine;

public class RemovingState : IBuildingState
{
    private int gameObjectIndex = -1;
    Grid grid;
    PreviewSystem previewSystem;
    GridData blockData;
    ObjectPlacer objectPlacer;

    public RemovingState(
                    Grid grid,
                    PreviewSystem previewSystem,
                    GridData blockData,
                    ObjectPlacer objectPlacer)
    {
        this.grid = grid;
        this.previewSystem = previewSystem;
        this.blockData = blockData;
        this.objectPlacer = objectPlacer;

        previewSystem.StartShowingRemovingPreview();
    }

    public void EndState()
    {
        previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3Int gridPosition)
    {
        GridData selectedData = null;
        if (blockData.CanPlaceObjectAt(gridPosition, Vector2Int.one) == false)
        {
            selectedData = blockData;
        }

        if (selectedData == null)
            return;
        else
        {
            gameObjectIndex = selectedData.GetRepresentationIndex(gridPosition);
            if (gameObjectIndex == -1)
                return;
            selectedData.RemoveObjectAt(gridPosition);
            objectPlacer.RemoveObject(gameObjectIndex);
        }

        Vector3 cellPosition = grid.CellToWorld(gridPosition);
        previewSystem.UpdatePosition(cellPosition, !selectedData.CanPlaceObjectAt(gridPosition, Vector2Int.one));
    }

    public void UpdateState(Vector3Int gridPosition)
    {
        bool validity = !blockData.CanPlaceObjectAt(gridPosition, Vector2Int.one);
        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), validity);
    }
}
