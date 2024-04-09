using UnityEngine;

[CreateAssetMenu()]
public class BurningRecipeSO : ScriptableObject
{
    [field: SerializeField] public KitchenObjectSO Input { get; private set; }
    [field: SerializeField] public KitchenObjectSO Output { get; private set; }
    [field: SerializeField] public float BurningTimerMax { get; private set; }
}
