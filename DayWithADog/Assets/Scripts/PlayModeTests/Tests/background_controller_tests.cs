using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class background_controller_tests
{
    // A Test behaves as an ordinary method
    [Test]
    public void background_controller_testsSimplePasses()
    {
        SceneManager.LoadScene("DogDay");
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator background_index_goes_negative_and_loops()
    {
        BackgroundController backgroundController = GameObject.Find("Background").GetComponent<BackgroundController>();
        backgroundController.index = 0;
        backgroundController.decreaseBackground();
        yield return null;
        Assert.AreEqual(2, backgroundController.index);
    }

    [UnityTest]
    public IEnumerator background_index_goes_above_background_count_and_loops()
    {
        BackgroundController backgroundController = GameObject.Find("Background").GetComponent<BackgroundController>();
        backgroundController.index = 2;
        backgroundController.increaseBackground();
        yield return null;
        Assert.AreEqual(0, backgroundController.index);
    }


    [UnityTest]
    public IEnumerator background_index_increases_normally()
    {
        BackgroundController backgroundController = GameObject.Find("Background").GetComponent<BackgroundController>();
        backgroundController.index = 0;
        backgroundController.increaseBackground();
        yield return null;
        Assert.AreEqual(1, backgroundController.index);
    }

    [UnityTest]
    public IEnumerator background_index_decreases_normally()
    {
        BackgroundController backgroundController = GameObject.Find("Background").GetComponent<BackgroundController>();
        backgroundController.index = 1;
        backgroundController.decreaseBackground();
        yield return null;
        Assert.AreEqual(0, backgroundController.index);
    }
}
