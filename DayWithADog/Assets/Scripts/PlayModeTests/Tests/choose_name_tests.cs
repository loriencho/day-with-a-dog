using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class choose_name_tests
{
    // A Test behaves as an ordinary method
    [Test]
    public void choose_name_testsSimplePasses()
    {
        SceneManager.LoadScene("DogDay");
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator choose_name_dogName_matches_input_when_nothing_entered()
    {
        NameChoose nameChoose = GameObject.Find("NameChoose").GetComponent<NameChoose>();
        nameChoose.inputField.text = "";
        nameChoose.setDogNameToInput();
        yield return null;
        Assert.AreEqual("", NameChoose.DogName);
    }

    [UnityTest]
    public IEnumerator choose_name_dogName_matches_input()
    {
        NameChoose nameChoose = GameObject.Find("NameChoose").GetComponent<NameChoose>();
        nameChoose.inputField.text = "Maki";
        nameChoose.setDogNameToInput();
        yield return null;
        Assert.AreEqual("Maki", NameChoose.DogName);
    }

    [UnityTest]
    public IEnumerator choose_name_dogName_matches_longInput()
    {
        NameChoose nameChoose = GameObject.Find("NameChoose").GetComponent<NameChoose>();
        nameChoose.inputField.text = "LorienYuna Cho124728714098231LorienYunaCho{}";
        nameChoose.setDogNameToInput();
        yield return null;
        Assert.AreEqual("LorienYuna Cho124728714098231LorienYunaCho{}", NameChoose.DogName);
    }
}
