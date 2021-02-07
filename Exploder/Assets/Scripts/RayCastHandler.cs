using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
public class RayCastHandler : MonoBehaviour
{
    [Header("Resource Input")]
    [SerializeField] float raycastRadius;
    [SerializeField] DataHolder[] dataHolders;

    [Header("Tweening")]
    [SerializeField] float critHitShakeStrenght;
    [SerializeField] float critHitShakeDuration;

    CharacterBehaviour playerScript;
    RaycastHit2D[] info;
    Tween critEffectTween;

    private void Start()
    {
        playerScript = transform.GetComponent<CharacterBehaviour>();


    }


    private void Update()
    {
        for (int i = 0; i < dataHolders.Length; i++)
        {
            CheckPlayerInput(i);
        }
    }

    void CheckPlayerInput(int i)
    {

        if (Input.GetKeyDown(dataHolders[i].killKey))
        {
            info = CheckIfHitSomething(dataHolders[i]);
            if (info.Length > 0)
            {
                EnemyHitted(info);
            }
            else
            {
                CharacterBehaviour.instance.healthSystem.AddValue(3);
            }
        }
    }
    RaycastHit2D[] CheckIfHitSomething(DataHolder data)
    {
        RaycastHit2D[] info;
        info = Physics2D.CircleCastAll(data.raycastTransf.position, raycastRadius, Vector2.zero);
        return info;
    }

    void EnemyHitted(RaycastHit2D[] raycastHit2Ds)
    {
        Vector2 centroidpos = raycastHit2Ds.First().centroid;
        float points = 0;
        float distance = 0;
        float temppoints = 0;
        float tempopointscap = 2f;
        foreach (RaycastHit2D raycast in raycastHit2Ds)
        {
            //Por enquanto a relação entre pontos e distância é de 1 para 1 (não é o ideal) 
            distance = Vector2.Distance(raycast.collider.transform.position, centroidpos);
            temppoints = 1 / distance;
            if (temppoints > tempopointscap)
            {
                temppoints = tempopointscap;

            }
            points += temppoints;
            Destroy(raycast.collider.gameObject);
            Debug.Log("Enemy destroyed! Your precision was " + distance.ToString("F2") + " units away from the center!");
            MunizCodeKit.Factory.PrefabFactory.instance.CreateItem(MunizCodeKit.Factory.PrefabFactory.FactoryProduct.EnemyDeathParticle, raycast.collider.transform.position);
            MunizCodeKit.Systems.SoundSystem.instance.PlaySound(MunizCodeKit.Systems.SoundSystem.Sound.EnergyAbsorbed);
        }

        if (temppoints == tempopointscap)//Show that it was a perfect hit
        {
            critEffectTween?.Complete();
            critEffectTween = transform.DOShakeScale(critHitShakeDuration, critHitShakeStrenght);

        }
        MunizCodeKit.MonoBehaviours.CameraController.ShakeCamera(.07f, .8f);
        points *= 2.5f;
        if (points < 1) points = 1;
        playerScript.levelSystem.AddExperience((int)points);
    }

    DataHolder GetCorrectData(KeyCode killkey)
    {
        return dataHolders.Where((data) => data.killKey == killkey).FirstOrDefault();
    }

    [System.Serializable]
    public struct DataHolder
    {
        public Transform raycastTransf;
        public KeyCode killKey;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(dataHolders[0].raycastTransf.position, raycastRadius);
        Gizmos.DrawWireSphere(dataHolders[1].raycastTransf.position, raycastRadius);
        Gizmos.DrawWireSphere(dataHolders[2].raycastTransf.position, raycastRadius);
        Gizmos.DrawWireSphere(dataHolders[3].raycastTransf.position, raycastRadius);
    }

}
