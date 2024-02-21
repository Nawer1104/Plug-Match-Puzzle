using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plug : MonoBehaviour
{
    public GameObject vfxTouch;

    public Enum type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.GetComponent<Plug>() == null)
        {
            if (collision.GetComponent<OutLet>().type == this.type)
            {
                GameObject vfx = Instantiate(vfxTouch, transform.position, Quaternion.identity) as GameObject;

                Destroy(vfx, 1f);

                gameObject.SetActive(false);
                collision.gameObject.SetActive(false);

                GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);

                GameManager.Instance.CheckLevelUp();
            }
        }
    } 
}
