using UnityEngine;

#pragma warning disable 649

[ExecuteInEditMode]
public class RoomResizer: MonoBehaviour
{
    [Header("Floor")]
    [SerializeField] private RectTransform _floorRect;
    [SerializeField] private Transform _floorTransform;
    [SerializeField] private MeshRenderer _floorRenderer;

    [SerializeField] private float _multiplier;

    [Header("Walls")]
    [SerializeField] private Transform _leftWallTransform;
    [SerializeField] private Transform _rightWallTransform;
    [SerializeField] private Transform _topWallTransform;
    [SerializeField] private Transform _botWallTransform;

#if UNITY_EDITOR
    private void Update() {
        UpdateRoomSize();
    }
#endif

    private void UpdateRoomSize() {
        Vector3[] corners = new Vector3[4];
        _floorRect.GetWorldCorners(corners);

        // floor
        float posX = (corners[2].x + corners[0].x) / 2;
        float posY = (corners[2].z + corners[0].z) / 2;
        float scaleX = (corners[2].x - corners[0].x) * 0.1f;
        float scaleY = (corners[2].z - corners[0].z) * 0.1f;
        _floorTransform.localPosition = new Vector3(posX, 0, posY);
        _floorTransform.localScale = new Vector3(scaleX, 1, scaleY);
        _floorRenderer.material.SetVector("tiling", new Vector4(scaleX, scaleY) * _multiplier);

        // walls
        // left / right
        _leftWallTransform.localScale = new Vector3(0.2f, 1, scaleY);
        _rightWallTransform.localScale = new Vector3(0.2f, 1, scaleY);

        _leftWallTransform.localPosition = new Vector3(posX + scaleX * 5, 1, posY);
        _rightWallTransform.localPosition = new Vector3(posX - scaleX * 5, 1, posY);

        _leftWallTransform.localRotation = Quaternion.Euler(0, 0, 90);
        _rightWallTransform.localRotation = Quaternion.Euler(0, 0, -90);

        // top / bottom
        //return;
        _topWallTransform.localScale = new Vector3(scaleX, 1, 0.2f);
        _botWallTransform.localScale = new Vector3(scaleX, 1, 0.2f);

        _topWallTransform.localPosition = new Vector3(posX, 1, posY + scaleY * 5);
        _botWallTransform.localPosition = new Vector3(posX, 1, posY - scaleY * 5);

        _topWallTransform.localRotation = Quaternion.Euler(-90, 0, 0);
        _botWallTransform.localRotation = Quaternion.Euler(90, 0, 0);
    }

    void Start() {
        UpdateRoomSize();
    }
}
