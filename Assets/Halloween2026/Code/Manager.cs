using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace N_Awakening.Halloween
{
    public class Manager : MonoBehaviour
    {
        #region References

        [SerializeField] TextMeshProUGUI _score;
        [SerializeField] Image[] _misses;
        [SerializeField] Image[] _health;
        [SerializeField] Player _player;
        [SerializeField] FallManager _fall;
        [SerializeField] GameObject _multiplier;

        #endregion

        #region RuntimeVariables

        int _scoreAmount;
        int _missAmount;
        int _healthAmount = 3;

        #endregion

        #region LocalMethods

        protected void EndGame()
        {
            _player.EndGame();
            _fall.EndGame();
            Cursor.lockState = CursorLockMode.None;
        }

        #endregion

        #region UnityMethods

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        #endregion

        #region PublicMethods

        public void AddScore(int p_amount)
        {
            _scoreAmount += p_amount;
            _score.text = "Score: " + _scoreAmount.ToString();
        }

        public void AddMiss()
        {
            if (_missAmount < 2)
            {
                _misses[_missAmount].color = Color.red;
                ++_missAmount;
            }
            else
            {
                for (int i = 0; i< _misses.Length; i++)
                    _misses[i].color = Color.black;
                _missAmount = 0;   
                ReduceHealth();
            }
        }

        public void AddHealth()
        {
            if (_healthAmount < 3)
            {
                _health[_healthAmount].color = Color.black;
                ++_healthAmount;
            }
        } 

        public void ReduceHealth()
        {
            --_healthAmount;
            _health[_healthAmount].color = Color.black;
            if (_healthAmount == 0)
                EndGame();
        }

        public void ChangeMultiplier(bool p_value)
        {
            _multiplier.SetActive(p_value);
        }

        #endregion
    }

}