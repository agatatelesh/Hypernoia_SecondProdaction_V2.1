using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptiTrackFollower : MonoBehaviour
{
    private static Vector3 optiTrackPosition;
    private static Quaternion optiTrackRotation;
    private static bool optiTrackDataInitialized = false;

    private void Awake()
    {
        // Если данные OptiTrack не инициализированы, инициализируем их
        if (!optiTrackDataInitialized)
        {
            GameObject optiTrackObject = GameObject.FindGameObjectWithTag("OptiTrackCamera");

            if (optiTrackObject != null)
            {
                optiTrackPosition = optiTrackObject.transform.position;
                optiTrackRotation = optiTrackObject.transform.rotation;
                optiTrackDataInitialized = true;
            }
            else
            {
                Debug.LogError("Object with tag 'OptiTrackCamera' not found in the scene.");
            }
        }

        // Применяем позицию и поворот к текущему объекту
        transform.position = optiTrackPosition;
        transform.rotation = optiTrackRotation;
    }

    private void OnEnable()
    {
        // Подписываемся на событие загрузки новой сцены
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // При загрузке новой сцены обновляем данные OptiTrack
        GameObject optiTrackObject = GameObject.FindGameObjectWithTag("OptiTrackCamera");
        if (optiTrackObject != null)
        {
            optiTrackPosition = optiTrackObject.transform.position;
            optiTrackRotation = optiTrackObject.transform.rotation;
        }
    }

    private void OnDisable()
    {
        // Отписываемся от события при выключении скрипта
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

