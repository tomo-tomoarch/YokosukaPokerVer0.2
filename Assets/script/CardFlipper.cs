using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlipper : MonoBehaviour
{

    SpriteRenderer spriteRenderer;  //SpriteRenderクラスを参照します。
    CardModel model;　　　//CardModelクラスを参照します。

    public AnimationCurve scaleCurve;　　//AnimationCurveを外部参照します　scaleCurveという名で以下のスクリプトでは記載します。
    public float duration = 0.5f;　　　　// duration というフロートの値（の宣言）は0.5です。

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();　　//SpriteRendererの取得。
        model = GetComponent<CardModel>();　　//CardModel.cs を取得。
    }

    public void FlipCard(Sprite startImage, Sprite endImage, int cardIndex)　　//メソッドの宣言FlipCard()
    {
        StopCoroutine(Flip(startImage, endImage, cardIndex));     //現在動いているコールーチン（この場合前回のアニメーション処理）を止めます。
        StartCoroutine(Flip(startImage, endImage, cardIndex));　　　//新たにコールーチン（この場合今回のアニメーション処理）を始めます。
    }
    IEnumerator Flip(Sprite startImage, Sprite endImage, int cardIndex)　　//コールーチンで動くメソッドFlipの定義。
    {
        spriteRenderer.sprite = startImage;　　　// SpriteRenderでスプライトの最初のイメージ（引数で与えられたもの）をレンダー

        float time = 0f;　　　　　　　// 小数点の値の宣言と０の代入
        while (time <= 1f)　　　　　　// time が１と等しいか小さい場合下記処理を繰り返す
        {
            float scale = scaleCurve.Evaluate(time);　　　　//小数点scale の宣言とtimeに対応するAnimationCurveグラフでのScaleの値の代入。
            time = time + Time.deltaTime / duration;　　　　//time に　time+PCの単位時間をdurationで割ったものを代入

            Vector3 localScale = transform.localScale;　　//localScaleというVector3の宣言と現在のtransformlocalScaleの値の代入。
            localScale.x = scale;　　　　　　　　　　　　　//localScaleのx成分だけ上で定義したscaleを代入する。
            transform.localScale = localScale;　　　　　　//現在のtransformにx成分変更後のlocalscaleを代入する。

            if (time >= 0.5f)                     //もしtimeが0.5以上の場合
            {
                spriteRenderer.sprite = endImage;　　//次の面をレンダー
            }

            yield return new WaitForFixedUpdate();　　// 一定間隔待って次のwhile処理に移ります。
        }
        if (cardIndex == -1)　　//もしcardIndex が-1と等しい場合
        {
            model.ToggleFace(false);　//裏面をレンダーします
        }
        else　　　　//それ以外の場合は
        {
            model.cardIndex = cardIndex;　　//  modelのカードインデックスの値をcardIndex とし、
            model.ToggleFace(true);　　// 表面をレンダーします
        }
    }
}