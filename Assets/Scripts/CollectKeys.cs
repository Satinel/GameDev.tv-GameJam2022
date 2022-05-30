using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKeys : MonoBehaviour
{

    public bool DefeatedKumoko;
    public bool DefeatedFireRat;
    public bool DefeatedConsortSlime;
    public bool DefeatedQueenSlime;
    bool kumoTrophy;
    bool direTrophy;
    bool consortTrophy;
    bool queenTrophy;
    [SerializeField] GameObject consortHead;
    [SerializeField] GameObject slimeQueenHead;
    [SerializeField] GameObject fireRatHead;
    [SerializeField] GameObject kumokoHead;
    [SerializeField] GameObject dungeonExit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dungeonExit.activeInHierarchy)
        {
            return;
        }
        if (DefeatedConsortSlime && !consortTrophy)
        {
            consortHead.SetActive(true);
            consortTrophy = true;
        }
        if (DefeatedQueenSlime && !queenTrophy)
        {
            slimeQueenHead.SetActive(true);
            queenTrophy = true;
        }
        if (DefeatedFireRat && !direTrophy)
        {
            fireRatHead.SetActive(true);
            direTrophy = true;
        }
        if (DefeatedKumoko && !kumoTrophy)
        {
            kumokoHead.SetActive(true);
            kumoTrophy = true;
        }
        if (DefeatedConsortSlime && DefeatedQueenSlime && DefeatedFireRat && DefeatedKumoko)
        {
            dungeonExit.SetActive(true);
        }
    }
}
