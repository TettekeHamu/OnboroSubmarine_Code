using System.Collections;
using TettekeKobo.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Hamu.OnboroSubmarine
{
    /// <summary>
    /// 
    /// </summary>
    public class SceneChangeManager : MonoDontDestroySingletonBase<SceneChangeManager>
    {
        /// <summary>
        /// 画面遷移ポストエフェクトのマテリアル
        /// </summary>
        [SerializeField] private Material postEffectMaterial;
        /// <summary>
        /// 画面遷移の時間
        /// </summary>
        [SerializeField] private float transitionTime = 2f;
        /// <summary>
        /// シェーダープロパティのReference名
        /// </summary>
        private readonly int progressId = Shader.PropertyToID("_Progress");


        public void ChangeScene(string sceneName)
        {
            StartCoroutine(Transition(sceneName));
        }

        /// <summary>
        /// 画面遷移
        /// </summary>
        private IEnumerator Transition(string sceneName)
        {
            var time = transitionTime;
            while (time > 0)
            {
                var progress = time / transitionTime;
            
                // シェーダーの_Progressに値を設定
                postEffectMaterial.SetFloat(progressId, progress);
                yield return null;

                time -= Time.deltaTime;
            }
            
            postEffectMaterial.SetFloat(progressId, 0f);
            SceneManager.LoadScene(sceneName);
            
            while (time < transitionTime)
            {
                var progress = time / transitionTime;
            
                // シェーダーの_Progressに値を設定
                postEffectMaterial.SetFloat(progressId, progress);
                yield return null;

                time += Time.deltaTime;
            }
            
            postEffectMaterial.SetFloat(progressId, 1f);
        }
    }
}
