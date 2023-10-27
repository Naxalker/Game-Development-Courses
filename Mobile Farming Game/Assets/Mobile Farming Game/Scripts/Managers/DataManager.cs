using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [Header("Data")]
    [SerializeField] private CropData[] cropDatas;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public Sprite GetCropSpriteFromCropType(CropType cropType)
    {
        for (int i = 0; i < cropDatas.Length; i++)
        {
            if (cropDatas[i].cropType == cropType)
                return cropDatas[i].icon;
        }

        Debug.LogError("No cropData found of that type");
        return null;
    }

    public int GetCropPriceFromCropType(CropType cropType)
    {
        for (int i = 0; i < cropDatas.Length; i++)
        {
            if (cropDatas[i].cropType == cropType)
                return cropDatas[i].price;
        }

        Debug.LogError("No cropData found of that type");
        return 0;
    }
}
