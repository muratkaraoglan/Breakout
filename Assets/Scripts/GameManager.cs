using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject[] bricks;
    public Text scoreText;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }


    float xOffset = 1.54f;
    float yOffset = 0.43f;
    int score = 0;
    int count = 0;
    private void Awake()
    {
        if ( instance == null )
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        ProduceBricks();
        BreakBrick(0);
    }

    void ProduceBricks()
    {
        for ( int j = 0; j < 8; j++ )
        {
            for ( int i = 0; i < 11; i++ )
            {
                int rnd = Random.Range(0, bricks.Length);


                GameObject brick = (GameObject)Instantiate(bricks[rnd], new Vector2(i * xOffset + 1.18f, j * yOffset), Quaternion.identity);

                brick.GetComponent<Brick>().brickValue = Random.Range(1, 5);
                count++;
            }
        }
        Debug.Log(count);
    }


    public void BreakBrick(int value)
    {
        score += value * 10;
        scoreText.text ="Score "+ score.ToString();
    }
}
