using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatSwitchScript : MonoBehaviour {

    [HideInInspector]
    public static CatSwitchScript Instance;
    public Respawn respawn;

	public List<GameObject> Cats;
    public List<Vector3> Positions;
    public int maxLife;

    [HideInInspector]
    public GameObject Cat;
    [HideInInspector]
	public int actCat = 0;
    [HideInInspector]
	public int hp;
    [HideInInspector]
    public bool canBruxoAttack = false;
    [HideInInspector]
    public bool canSwitch = true;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            hp = maxLife;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        int index = scene.buildIndex;
        Destroy(Cat);
        if (index != 0)
        {
            transform.position = Positions[index - 1];
            Cat = Instantiate(Cats[actCat], transform.position, transform.rotation);
            respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Respawn>();
            if (respawn == null)
                print("deu boxta");
            else
                print("aee porra");
        }
    }
    
    void LateUpdate () {
		if (Input.GetKeyDown (KeyCode.LeftAlt) && canSwitch) {
			actCat++;
			if (actCat == Cats.Count)
				actCat = 0;
			SwitchCat (Cats [actCat]);
		}
	}

	public void SwitchCat (GameObject C) {
		Vector3 pos = Cat.transform.position;
		Quaternion rot = Cat.transform.rotation;
		Destroy (Cat);
		Cat = Instantiate (C, pos, rot);
		actCat = Cats.IndexOf (C);
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
    }

	public void ResetLife(){
		hp = maxLife;
	}

    public void Resp()
    {
        Cat.transform.position = transform.position;
        Cat.GetComponent<AllCatsBehaviour>().Rigid.velocity = Vector2.zero;
        ResetLife();
        respawn.RespawnMenu();
    }
}
