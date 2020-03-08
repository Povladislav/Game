using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    private TowerBtn towerBtnPressed;
    private GameObject newTower;
    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);
            PlaceTower(hit);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            renderer.sprite = null;
            
            towerBtnPressed = null;
            newTower = null;
        }
    }
    private void FollowMouse()
    {
        if (renderer != null && towerBtnPressed != null)
        {
            renderer.sprite = towerBtnPressed.SpriteObject;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
    }
    public void SelectedTower(TowerBtn selectedTower)
    {
        towerBtnPressed = selectedTower;

    }
    private void PlaceTower(RaycastHit2D hit)
    {
        if (hit.collider != null)
        {
            if (hit.collider.tag == "TowerPlace" && towerBtnPressed != null)
            {
                newTower = Instantiate(towerBtnPressed.TowerObject, hit.transform.position, hit.transform.rotation);
                hit.collider.tag = "TowerPlaceFull";

            }

        }


    }
}
