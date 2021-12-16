using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Declaring variables for default values
    public int defaultGold = 0;
    public float defaultEnergy = 100.0f;
    public float defaultExploration = 0.0f;
    public int defaultEnergyPots = 0;
    public bool isDead = false;

    public float maxEnergy = 10000;
    public float currentEnergy;
    public EnergyBar energyBar;

    private SpriteRenderer rend;
    public Sprite deadSprite;


    [SerializeField] TextMeshProUGUI textMeshProEnergy;
    [SerializeField] TextMeshProUGUI textMeshProGold;

    //variables that will be used during combat
    [SerializeField] public int npcGold;
    public int NpcGold
    {
        get { return npcGold; }
        set { npcGold = value; }
    }

    [SerializeField] public float npcEnergy;
    public float NpcEnergy
    {
        get { return npcEnergy; }
        set { npcEnergy = value; }
    }

    [SerializeField] public float npcExploration;
    public float NpcExploration
    {
        get { return npcExploration; }
        set { npcExploration = value; }
    }

  
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        // Initialize the variables that will be used by the monsters
        npcGold = defaultGold;
        npcEnergy = defaultEnergy;
        npcExploration = defaultExploration;
      
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);

        //αντιστοιχηση txt για coin στους npc Μας
        if (name == "NPC_1")
        {
      
            textMeshProGold = GameObject.Find("Txt_NPC_1_Gold_Value")
                                          .GetComponent<TextMeshProUGUI>();
        }
        else if (name == "NPC_2")
        {
         
            textMeshProGold = GameObject.Find("Txt_NPC_2_Gold_Value")
                                         .GetComponent<TextMeshProUGUI>();
        }
        else if (name == "NPC_3")
        {
         
            textMeshProGold = GameObject.Find("Txt_NPC_3_Gold_Value")
                                          .GetComponent<TextMeshProUGUI>();
        }
        else
        {
           
            textMeshProGold = GameObject.Find("Txt_NPC_4_Gold_Value")
                                         .GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProGold.SetText("Gold: {0}", NpcGold);

        if (currentEnergy > 0)
        {
             TakeEnergy((float)0.01);
        }
        
        if (currentEnergy < 0)
        {
            GetComponent <RandomMovement>().enabled = false;
            rend.sprite = deadSprite;
            isDead = true;
        }

    }

    //Μέθοδος για να αφαιρούμετο energy του Npc μας.
    void TakeEnergy(float energy)
    {
        currentEnergy -= energy;
        energyBar.SetEnergy(currentEnergy);
    }

    //Μέθοδος για να αυξάνουμε το energy του Npc μας.
    void GiveEnegry(float energy)
    {
        
        currentEnergy += energy;
        energyBar.SetEnergy(currentEnergy);
    }


    //Μέθοδος της c# όπου μας βοηθά να βρίσκουμε πότε ένα αντικείμενο ήρθε σε
    //επαφή με τον Npc μας.
    private void OnTriggerEnter2D(Collider2D other)
    {
        //έλεγχος αν ηρθε σε επαφή με coin
        if (other.gameObject.CompareTag("Coin"))
        {
            //αν ηρθε τότε το καταστρέφουμε
            Destroy(other.gameObject);
            
            string npc = gameObject.name;
            
            //βρισκουμε ποιος npc ήταν Και του προσθέτουμε ένα coin
            switch (npc)
            {
                case "NPC_1":
                    NpcGold += 1;
                    textMeshProGold.SetText("Gold: {0}", NpcGold);
                    break;
                case "NPC_2":
                    NpcGold += 1;
                    textMeshProGold.SetText("Gold: {0}", NpcGold);
                    break;
                case "NPC_3":
                    NpcGold += 1;
                    textMeshProGold.SetText("Gold: {0}", NpcGold);
                    break;
                case "NPC_4":
                    NpcGold += 1;
                    textMeshProGold.SetText("Gold: {0}", NpcGold);
                    break;
            }
        }

        //έλεγχος αν έχει βρει energy Bots αν έχει βρει 
        // και έχει τουλάχιστον 5 coin του αφαιρούμε αυτά τα 5
        //και του προσθέτουμε energy
        if (other.gameObject.CompareTag("Energy Pot"))
        {
            if (NpcGold >= 5)
            {
                GiveEnegry(5);
                Destroy(other.gameObject);
                NpcGold -= 5;
            }
        }

    }

}
