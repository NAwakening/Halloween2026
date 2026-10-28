using Unity.VisualScripting;
using UnityEngine;

namespace N_Awakening.Halloween
{
    public class DeathZone : MonoBehaviour
    {
        #region References

        [SerializeField] Manager manager;

        #endregion

        #region UnityMethods

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Candy"))
                manager.AddMiss();
            else if (other.CompareTag("Player"))
                return;
            other.gameObject.SetActive(false);
        }

        #endregion
    }

}
