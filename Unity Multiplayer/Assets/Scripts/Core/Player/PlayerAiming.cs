using Unity.Netcode;
using UnityEngine;

public class PlayerAiming : NetworkBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Transform _turretTransform;

    private void LateUpdate()
    {
        if (!IsOwner)
            return;

        Vector2 aimScreenPosition = _inputReader.AimPosition;
        Vector2 aimWorldPosition = Camera.main.ScreenToWorldPoint(aimScreenPosition);
        _turretTransform.up = aimWorldPosition - (Vector2)_turretTransform.position;
    }
}
