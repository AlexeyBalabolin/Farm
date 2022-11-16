using System.Collections;
using UnityEngine;

public class CurtainLoader : MonoBehaviour
{
    public float HideSpeed = 0.03f;

    private CanvasGroup _curtain;

    private void Awake()
    {
        _curtain = GetComponent<CanvasGroup>();
        DontDestroyOnLoad(this);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _curtain.alpha = 1;
    }

    public void Hide() => StartCoroutine(HideCoroutine());

    private IEnumerator HideCoroutine()
    {
        while(_curtain.alpha>0)
        {
            _curtain.alpha -= 0.01f;
            yield return new WaitForSeconds(HideSpeed);
        }
        gameObject.SetActive(false);
    }
}
