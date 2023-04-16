using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

namespace VipShaderStudy.Intro
{
    public class MessageView : MonoBehaviour
    {
        [SerializeField] Text text;

        string message;

        void Start()
        {
            message = "このプロジェクトはVIPPER向けのシェーダー勉強用プロジェクトです。用意した各シーンで一体何が起こっているのかを順番に理解し、ステップアップしてゆくことで、シェーダーへの理解を深めてもらえればと思います。各シーンの解説については「Unity勉強会サークル」の「シェーダー勉強用」チャンネルにて行いますのでそちらも併せて参照してください。";
            StartCoroutine(ShowMessage());
        }

        IEnumerator ShowMessage()
        {
            var separator = '。';
            var sentences = message.Split(separator).Take(message.Count(e => e == separator)).Select(e => e + separator).ToArray();
            foreach(var sentence in sentences)
            {
                text.text = sentence;
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return null;
            }

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
