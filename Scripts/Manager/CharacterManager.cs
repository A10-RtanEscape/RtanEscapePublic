using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    public int selectIndex;
    public int NumberOfPlayer = 1;

    public PlayerInfo[] Characters;

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if ( instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("StartScene");

        // 저장된 최근 선택 캐릭터 값 불러오기


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
