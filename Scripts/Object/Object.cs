using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public GameObject destoryPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        float x = Random.Range(-12.0f, 12.0f);
        float y = 7.0f;

        transform.position = new Vector3(x, y, 0); // 랜덤한 X좌표에서 생성 (미세조정 필요)

        RandomSpeed(); //랜덤한 속도 구현
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //그라운드 태그가 있는 오브젝트와 충돌했을 때
        {
            Instantiate(destoryPrefab, transform.position, Quaternion.identity);

            SoundManager.Instance.PlaySFX(SFX.Bomb);

            Destroy(gameObject); // 바닥에 충돌하면 오브젝트 파괴
            int best = int.Parse(GameManager.instance.best.text);
            int plusScore = int.Parse(GameManager.instance.score.text);
            plusScore++;
            GameManager.instance.score.text = plusScore.ToString(); // 바닥에 충돌하면 점수 1점씩 상승

            if(plusScore > best) //베스트 스코어 텍스트 갱신
            {
                GameManager.instance.best.text = plusScore.ToString();
            }

        }
        else if (collision.gameObject.CompareTag("Player")) //플레이어 태그가 있는 오브젝트와 충돌하면
        {
            Instantiate(destoryPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            collision.gameObject.SetActive(false);

            if(GameManager.instance.player.activeSelf == false && GameManager.instance.player2.activeSelf == false)
            {
                GameManager.instance.endPanel.SetActive(true); //엔드판넬 (결과창)을 활성화
            }
        }
    }

    private void RandomSpeed()
    {
        int type = Random.Range(1, 4);
        if (int.Parse(GameManager.instance.score.text) > 20) // 점수가 20점이 넘어가면 Rigidbody의 속력 변경
        {
            rb2d.velocity = new Vector2(0, -type); // 잘 동작하는지 체크 확인
        }
    }

    public void AnimPrefab()
    {
        Instantiate(destoryPrefab, transform.position, Quaternion.identity);
    }
}
