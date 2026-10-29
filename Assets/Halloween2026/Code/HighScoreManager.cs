using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace N_Awakening.Halloween
{
    public class HighScoreManager : MonoBehaviour
    {
        #region References

        [SerializeField] TextMeshProUGUI[] _names;
        [SerializeField] TextMeshProUGUI[] _scores;
        [SerializeField] Score _highScore;

        #endregion

        #region UnityMethods
        
        void Start()
        {
            for(int i = 0; i < _names.Length; i++)
            {
                _names[i].text = _highScore.topTen[i].name;
                _scores[i].text = _highScore.topTen[i].score.ToString();
            }
        }

        #endregion

        #region PublicMethods

        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        #endregion
    }
}

