using UnityEngine;
using System.Collections;

namespace N_Awakening.Halloween
{
    public class FallManager : MonoBehaviour
    {
        #region References

        [SerializeField] GameObject[] _rainbowCandy;
        [SerializeField] GameObject[] _cornCandy;
        [SerializeField] GameObject[] _wrappedCandy;
        [SerializeField] GameObject[] _jellyCandy;
        [SerializeField] GameObject[] _sword;
        [SerializeField] GameObject[] _axe;
        [SerializeField] GameObject[] _sizePowerUp;
        [SerializeField] GameObject[] _multiplierPowerUp;
        [SerializeField] GameObject[] _shieldPowerUp;
        [SerializeField] GameObject[] _extraLife;

        #endregion

        #region Knobs

        [SerializeField] float _minPosition;
        [SerializeField] float _maxPosition;

        #endregion

        #region RuntimeVariables

        int _random;
        GameObject _objetToSpawn;
        float _spawnTime = 2f;

        #endregion

        #region LocalMethods

        private void ChooseItemToDrop()
        {
            _random = Random.Range(1, 101);
            if (_random <= 9)
            {
                for (int i = 0; i < 3 ; i++)
                {
                    if (!_rainbowCandy[i].activeSelf)
                        _objetToSpawn= _rainbowCandy[i];
                }
            }
            else if (_random <= 26)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!_cornCandy[i].activeSelf)
                        _objetToSpawn = _cornCandy[i];
                }
            }
            else if (_random <= 43)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!_wrappedCandy[i].activeSelf)
                        _objetToSpawn = _wrappedCandy[i];
                }
            }
            else if (_random <= 60)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!_cornCandy[i].activeSelf)
                        _objetToSpawn = _cornCandy[i];
                }
            }
            else if (_random <= 75)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!_sword[i].activeSelf)
                        _objetToSpawn = _sword[i];
                }
            }
            else if (_random <= 90)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!_axe[i].activeSelf)
                        _objetToSpawn = _axe[i];
                }
            }
            else if (_random <= 93)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!_sizePowerUp[i].activeSelf)
                        _objetToSpawn = _sizePowerUp[i];
                }
            }
            else if (_random <= 96)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!_multiplierPowerUp[i].activeSelf)
                        _objetToSpawn = _multiplierPowerUp[i];
                }
            }
            else if (_random <= 99)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!_shieldPowerUp[i].activeSelf)
                        _objetToSpawn = _shieldPowerUp[i];
                }
            }
            else if (_random == 100)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (!_extraLife[i].activeSelf)
                        _objetToSpawn = _extraLife[i];
                }
            }
            _objetToSpawn.transform.position = new Vector3 (Random.Range(_minPosition,_maxPosition), transform.position.y, 0);
            _objetToSpawn.transform.eulerAngles = Vector3.zero;
            StartCoroutine(Drop());
        }

        #endregion

        #region UnityMethods
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            ChooseItemToDrop();
        }

        #endregion

        #region PublicMethods

        public void EndGame()
        {
            StopAllCoroutines();
        }

        #endregion

        #region Corroutines

        IEnumerator Drop()
        {
            _objetToSpawn.SetActive(true);
            yield return new WaitForSeconds(_spawnTime);
            if (_spawnTime > 1)
                _spawnTime -= 0.5f;
            ChooseItemToDrop();
        }

        #endregion
    }
}