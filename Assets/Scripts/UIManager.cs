using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance()
    {
        return _instance;
    }

    public Text roundText;
    public Slider playerHpBar;
    public Slider enemyHpBar;
    public GameObject GameOverImage;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this; //instance�Ҵ����ֱ�
            DontDestroyOnLoad(this.gameObject); // Scene �� �ٲ� ����
        }
        else
        {
            if (this != _instance)
            {
                Destroy(this.gameObject); //�������� ��� ����
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
