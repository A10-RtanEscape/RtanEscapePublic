using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        float x = Random.Range(-12.0f, 12.0f);
        float y = 7.0f;

        transform.position = new Vector3(x, y, 0);

        Destroy(gameObject, 3); // 3초 뒤에 아이템 파괴
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //플레이어에 닿을 경우 파괴
        {
            SoundManager.Instance.PlaySFX(SFX.Item);

            Destroy(gameObject);

            GameObject[] temp = GameObject.FindGameObjectsWithTag("Object"); // 오브젝트 태그 전부 찾아서 파괴

            for (int i = 0; i < temp.Length; i++)
            {
                Object obj = temp[i].GetComponent<Object>();

                obj.AnimPrefab();

                Destroy(temp[i]);
            }
        }
    }
}