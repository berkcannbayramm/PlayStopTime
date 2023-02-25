using BBGameStudios.Managers;
using UnityEngine;

[DefaultExecutionOrder(-9999)]
public class BBSystems : MonoBehaviour
{
    public static BBSystems instance;
    
    [field: SerializeField] public MoneyManager MoneyManager { get; private set; }
    [field: SerializeField] public LevelManager LevelManager { get; private set; }
    [field: SerializeField] public Panel        PanelManager { get; private set; }
    [field: SerializeField] public GameManager  GameManager  { get; private set; }
    private void Awake()
    {
        if(instance != null)
            Destroy(gameObject);
        
        else
            instance = this;
        
        DontDestroyOnLoad(gameObject);
    }
}
