using UnityEngine;

public class SkrillTower : Tower
{
    private SpriteRenderer _spr;

    private void Awake()
    {
        _spr = GetComponent<SpriteRenderer>();
    }

    protected override void RotateTower(float angleToRotate)
    {
        transform.rotation = Quaternion.AngleAxis(angleToRotate, Vector3.forward);
        var absAngle = Mathf.Abs(transform.rotation.eulerAngles.z % 360);
        //Debug.Log($"absAngle: {absAngle}");
        _spr.flipY = (absAngle > 90) && (absAngle < 270);
    }
}
