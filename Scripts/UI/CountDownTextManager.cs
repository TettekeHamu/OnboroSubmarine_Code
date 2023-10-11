using System.Collections;
using System.Globalization;
using naichilab.EasySoundPlayer.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// カウントダウンをおこなうテキストを管理するクラス
    /// </summary>
    public class CountDownTextManager : MonoBehaviour
    {
        /// <summary>
        /// カウントダウンをおこなうテキスト
        /// </summary>
        [SerializeField] private Text countDownText;

        private void Awake()
        {
            countDownText.gameObject.SetActive(false);
        }

        /// <summary>
        /// カウントダウンをおこなう処理
        /// </summary>
        public IEnumerator CountDownCoroutine()
        {
            countDownText.gameObject.SetActive(true);
            var timer = 3f;
            while (timer > 0)
            {
                SePlayer.Instance.Play("SE_CountDown");
                countDownText.text = timer.ToString(CultureInfo.InvariantCulture);
                yield return new WaitForSeconds(1f);
                timer--;
            }

            SePlayer.Instance.Play("SE_GameStart");
            countDownText.text = "ゲームスタート！";

            yield return new WaitForSeconds(1f);
            
            countDownText.gameObject.SetActive(false);
        }
    }
}
