using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyIndicator : MonoBehaviour
{
    public Transform enemyTransform; 
    public Image indicatorImage;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Vector3 screenPos;
    Vector2 indicatorSize;
    float clampedX;
    float clampedY;
    bool isOutsideScreen;
    private void Start()
    {
        skinnedMeshRenderer = CacheComponent.GetEnemyComponent(enemyTransform).skinRendered;
        indicatorImage.color = skinnedMeshRenderer.material.color;
    }
    private void OnEnable()
    {
        if(skinnedMeshRenderer != null)
        {
            indicatorImage.color = skinnedMeshRenderer.material.color;

        }
    }
    void FixedUpdate()
    {
        MoveIndicator();
    }

    private void MoveIndicator()
    {
        screenPos = Camera.main.WorldToScreenPoint(enemyTransform.position);
        indicatorSize = indicatorImage.rectTransform.sizeDelta / 2;
        clampedX = Mathf.Clamp(screenPos.x, indicatorSize.x, Screen.width - indicatorSize.x);
        clampedY = Mathf.Clamp(screenPos.y, indicatorSize.y, Screen.height - indicatorSize.y);
        indicatorImage.transform.position = new Vector3(clampedX, clampedY, screenPos.z);
        isOutsideScreen = (screenPos.x < 0 || screenPos.x > Screen.width || screenPos.y < 0 || screenPos.y > Screen.height);
        indicatorImage.gameObject.SetActive(isOutsideScreen);
    }
}
