using TMPro;
using UnityEngine;
using Player;

namespace UIX
{
    public class StatsPage : MonoBehaviour
    {
        // Array of item prefabs (one prefab per item)
        public GameObject[] itemPrefabs;

        // Parent object where item UI elements will be added (Content of the Scroll View)
        public PlayerStats stats;
        public Transform content;

        // Array to keep track of item quantities
        private int[] itemQuantities = new int[8];

        // Array to store the instantiated item UI elements
        private GameObject[] itemUIElements = new GameObject[8];

        private void Start()
        {
            LoadItems();
        }

        public void Setup()
        {
            gameObject.SetActive(true);
        }

        public void Resume()
        {
            gameObject.SetActive(false);
        }

        /*index to upgrade list:
        0: Diverge
        1: Forcefield
        2: Fortified Plating
        3: Machine Guns
        4: Piercing Rounds
        5: Piloting Enhancements
        6: Rocket Boosters
        7: Roulette
        */
        private void LoadItems()
        {
            for (int i = 0; i < stats.divergeCount; i++)
            {
                AddItem(0);
            }

            for (int i = 0; i < stats.forcefieldCount; i++)
            {
                AddItem(1);
            }

            for (int i = 0; i < stats.shieldCount; i++)
            {
                AddItem(2);
            }

            for (int i = 0; i < stats.MachineGunCount; i++)
            {
                AddItem(3);
            }

            for (int i = 0; i < stats.piercingRoundCount; i++) //piercing not yet implemented
            {
                AddItem(4);
            }

            for (int i = 0; i < stats.pilotingEnhancementsCount; i++)
            {
                AddItem(5);
            }

            for (int i = 0; i < stats.RocketBoosterCount; i++)
            {
                AddItem(6);
            }

            for (int i = 0; i < stats.rouletteCount; i++)
            {
                AddItem(7);
            }
        }

        public void AddItem(int itemIndex)
        {
            // Check if the item UI already exists in the Scroll View
            if (itemUIElements[itemIndex] == null)
            {
                // Instantiate prefab for this item and place it in Scroll View content
                GameObject newItemUI = Instantiate(itemPrefabs[itemIndex], content);

                // Store prefab in array
                itemUIElements[itemIndex] = newItemUI;

                // Initialize num to 1 for the first instance
                itemQuantities[itemIndex] = 1;
            }
            else
            {
                // Increment the quantity of item
                itemQuantities[itemIndex]++;
            }

            // Update num of item in the UI
            TextMeshProUGUI x = itemUIElements[itemIndex].transform.Find("numOf").GetComponent<TextMeshProUGUI>();
            x.text = "x" + itemQuantities[itemIndex].ToString();
        }
    }
}
