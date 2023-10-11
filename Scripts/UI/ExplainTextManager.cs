using System;
using System.Collections;
using naichilab.EasySoundPlayer.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// ゲーム開始時に説明文を表示するText
    /// </summary>
    public class ExplainTextManager : MonoBehaviour
    {
        [SerializeField] private Text text;

        private void Awake()
        {
            text.gameObject.SetActive(false);
        }

        public void SendHighScoreText()
        {
            text.gameObject.SetActive(true);
            text.text = "ハイスコアのデータを送っています…";
        }

        public IEnumerator ShowExplainText()
        {
            text.gameObject.SetActive(true);
            text.text = "";

            yield return new WaitForSeconds(1.5f);
            
            SePlayer.Instance.Play("SE_Message");
            text.text = "おぉ気づいたか！！";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;

            SePlayer.Instance.Play("SE_Message");
            text.text = "無事深海まで潜れた様じゃの";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;

            SePlayer.Instance.Play("SE_Message");
            text.text = "お主にはいまから" +
                        "\nその潜水艦でお宝の採掘をしてもらう";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;

            SePlayer.Instance.Play("SE_Message");
            text.text = "なぁに簡単なことじゃ"
                        + "\n！マークアイコンのところにSマークのボタンをおいて"
                        + "\nSpaceキーを押すと採掘用の弾が発射されるぞ";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;

            SePlayer.Instance.Play("SE_Message");
            text.text = "上手く照準を合わせて弾を打つのじゃ";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;

            SePlayer.Instance.Play("SE_Message");
            text.text = "左側のアイコンの上にボタンを置くことで" +
                        "\n回転と前後に移動が出来るぞい";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;

            SePlayer.Instance.Play("SE_Message");
            text.text = "そして一番右のボタンは周りを" +
                        "\n明るく照らしてくれるぞ";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;
            
            SePlayer.Instance.Play("SE_Message");
            text.text = "マウスのドラッグ＆ドロップで" +
                        "\n上手くボタンをセットするのじゃ";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;

            SePlayer.Instance.Play("SE_Message");
            text.text = "ナニ？機体がボロボロだし" +
                        "\n何でボタンが１つしかないんだって？？";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;

            SePlayer.Instance.Play("SE_Message");
            text.text = "それはの、度重なる増税で" +
                        "\n予算がなくなってしまったからじゃ";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;

            SePlayer.Instance.Play("SE_Message");
            text.text = "だから借金まみれのお主を助けて" +
                        "\nこの潜水艦に乗せたのじゃ";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;
            
            SePlayer.Instance.Play("SE_Message");
            text.text = "人生そんなにあまくないのじゃ";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;
            
            SePlayer.Instance.Play("SE_Message");
            text.text = "じゃあ時間いっぱいまで頑張るのじゃぞい～～～";
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return null;
            
            text.gameObject.SetActive(false);
        }
    }
}
