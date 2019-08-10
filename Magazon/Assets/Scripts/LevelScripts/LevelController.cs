using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    
    public UIController UIController;
    private SoundController soundController;
    public int objectives = 5;
    public int parcels = 5;
    public float targetTime = 30.0f;
    public LevelCode levelCode;

    private bool movementInputEnabled = true;
    private bool DeliveryEnabled = true;
    private int score = 0;

    private GAMESTATUS gameStatus = GAMESTATUS.PLAYING;
    private bool finalScoreSet = true;
    void Start()
    {
        setupUISoundControllers();
    }
    void Update()
    {
        if(gameStatus == GAMESTATUS.PLAYING)
        {
            updateUI();
            toggleMap();
            CheckGameStatus();
        } else
        {
            stopGame();
        }
    }

    public void CheckGameStatus()
    {
        if(targetTime <= 0.0f || parcels < 1)
        {
            gameStatus = GAMESTATUS.LOSE;
        }
        else if(objectives < 1)
        {
            gameStatus = GAMESTATUS.WIN;
        }
    }
    /*
     Method: updateArrivedParcels
     ParcelController passes the message that a parcel was delivered into the objective.  
         */
    public void updateArrivedParcels(int pointsToAdd)
    {
        if (pointsToAdd > 0)
        {
            objectives--;
            score += pointsToAdd;
        }
    }
    /*
    Method: updateDeliveredParcels
    ShootParcelController passes the message that a parcel was used.
    */
    public void updateDeliveredParcels()
    {
        parcels--;
        if (parcels < 1)
            DeliveryEnabled = false;
    }
    public void toggleKeyboard()
    {
        movementInputEnabled = !movementInputEnabled;
    }
    public bool isKeyboardEnabled()
    {
        return movementInputEnabled;
    }
    public bool isDeliveryEnabled()
    {
        return DeliveryEnabled;
    }
    /*
    Method: playSoundEffect
    Message passed to Sound controller to play a specific sound effect.
        */
    public void playSoundEffect(string name)
    {
        soundController.play(name);
    }
    /*
     Method: setup UI Sound Controllers
     Find the sound controller script and GUI controller script.
         */
    private void setupUISoundControllers()
    {
        soundController = FindObjectOfType<SoundController>();
        UIController = FindObjectOfType<UIController>();
    }
    private void toggleMap()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
            UIController.toggleMap();
    }

    private void updateUI()
    {
        UIController.updatePlayerInfo(score, objectives, targetTime, parcels);
        targetTime -= Time.deltaTime;   
    }
   
    private void stopGame()
    {
        if (gameStatus == GAMESTATUS.WIN)
                playerWin();        
        else if (gameStatus == GAMESTATUS.LOSE)        
            UIController.showLose();
        
        endGameOptions();
    }
    private void playerWin()
    {
        score = finalScore();

        UIController.showWin(score);

        PlayerRepository.Instance.SaveLevel(new Level(levelCode, score));
        if (Input.GetKeyDown(KeyCode.O))
        {
            int nextScene = (int)levelCode + 2;
            SceneManager.LoadScene(nextScene);
        }
    }

    private int  finalScore()
    {
        if (finalScoreSet)
        {            
            finalScoreSet = false;
            return score + (int)targetTime;
        }
        return 0;
    }
    /*
     Method: endGameOptions
     If game status is not playing, then allow player to reload or go to main menu.
         */
    private void endGameOptions()
    {
        movementInputEnabled = false;

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKey(KeyCode.U))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
   
}

public enum GAMESTATUS
{
    PLAYING = 0,
    WIN = 1,
    LOSE = 2
}