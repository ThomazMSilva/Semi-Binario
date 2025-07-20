using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts
{
    public class FadeUtility : MonoBehaviour
    {
        [SerializeField] private float fadeDuration = .5f;
        private Tween fadeTween;
        private bool isProcessingFade;

        public void SetActiveFade(GameObject target)
        {
            FadeObject(target, !target.activeSelf);
        }

        public void FadeObject(GameObject objectToFade, bool active, System.Action onComplete = null)
        {
            if (!objectToFade.TryGetComponent<CanvasGroup>(out var group))
            {
                group = objectToFade.AddComponent<CanvasGroup>();
            }
            Debug.Assert(group != null, "ainda nao conseguiu alocar valor ao group");

            isProcessingFade = true;
            group.alpha = active ? 0 : 1;
            objectToFade.SetActive(true);

            fadeTween?.Complete();

            var targetAlpha = active ? 1 : 0;
            //Debug.Log("indo pra " + targetAlpha);

            fadeTween ??= group
            .DOFade(targetAlpha, fadeDuration)
            .SetUpdate(true)
            .OnComplete(() =>
            {
                onComplete?.Invoke();
                objectToFade.SetActive(active);
                isProcessingFade = false;
                fadeTween = null;
            });
        }

        private void OnDestroy() => fadeTween?.Kill();
    }
}