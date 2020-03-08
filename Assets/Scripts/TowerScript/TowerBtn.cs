
using UnityEngine;

public class TowerBtn : MonoBehaviour
{
    [SerializeField]
    GameObject towerObject;
    [SerializeField]
    Sprite sprite;

    public GameObject TowerObject
    {
        get
        {
            return towerObject;
        }
    }
    public Sprite SpriteObject
    {
        get
        {
            return sprite;
        }
    }

}
