using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    List<int> cards; //リストの宣言。

    public IEnumerable<int> GetCards() //戻り値に列挙可能なリストを持つメソッド
    {
        foreach (int i in cards)　//cardsの中の要素それぞれについて
        {
            yield return i;　//要素を戻り値に返します
        }
    }

    public void Shuffle()　//shuffleメソッド本体。
    {
        if ( cards == null)　//cardsが空であれば。
        {
            cards = new List<int>();　//cardの初期化。

        }
        else　//その他の場合。
        {
            cards.Clear();　//cardsを空にする。
        }

        for (int i = 0; i < 52; i++)
        //初期値i=0から52以下の場合下記を繰り返しiをインクリメント。
        {
            cards.Add(i);　//リストにiを加える。
        }

        int n = cards.Count; //整数ｎの初期値はカードの枚数とする。
        while (n > 1)　//nが１より大きい場合下記を繰り返す。
        {
            n--;　//nをディクリメント
            int k = Random.Range(0, n + 1);//kは０～n+1の間のランダムな数とする
            int temp = cards[k];　//k番目のカードをtempに代入
            cards[k] = cards[n];　//k番目のインデックスにn番目のインデックスを代入
            cards[n] = temp;　//n番目のインデックスにtemp(k番目のインデックス）を代入
        }
    }
  
	void Start ()
    {
          Shuffle();　　//shuffleメソッドを実行
    }
	
}
