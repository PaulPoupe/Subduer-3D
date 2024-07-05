using System;
using System.Collections;
using UnityEngine;

public class ArrowGauge : MonoBehaviour, IGauge
{
    [SerializeField] private Transform arrow;
    [Space]
    [SerializeField] private float zeroEngle;
    [SerializeField] private float lastEngle;
    [Space]
    [SerializeField] private float speed;

    private Quaternion zeroQuaternion;
    private Quaternion lastQuaternion;

    private float curentValue = 0.0f;

    private void Awake()
    {
        initialize();
    }

    private void initialize()
    {
        zeroQuaternion = Quaternion.Euler(0, 0, zeroEngle);
        lastQuaternion = Quaternion.Euler(0, 0, lastEngle);

        arrow.rotation = zeroQuaternion;
    }

    public IEnumerator Rotate(float requiredValue)
    {
        while (Math.Round(curentValue, 2) != requiredValue)
        {
            if (Overstepping())
            {
                curentValue = requiredValue;
                Rotating();
                yield break;
            }

            else if (curentValue > requiredValue)
            {
                curentValue -= Time.fixedDeltaTime * speed;
                Rotating();
            }
            else if (curentValue < requiredValue)
            {
                curentValue += Time.fixedDeltaTime * speed;
                Rotating();
            }

            yield return null;
        }

        bool Overstepping()
        {
            return Math.Abs(requiredValue - curentValue) <= Time.fixedDeltaTime * speed;
        }

        void Rotating()
        {
            arrow.rotation = Quaternion.LerpUnclamped(zeroQuaternion, lastQuaternion, curentValue);
        }
    }

    public void SetValue(float value)
    {
        StartCoroutine(Rotate(value));
    }


}
