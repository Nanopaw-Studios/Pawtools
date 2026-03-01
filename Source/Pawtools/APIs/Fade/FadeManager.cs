using System;
using FlaxEngine;
using FlaxEngine.GUI;

namespace Pawtools;

public class FadeManager : Script
{
    private static FadeManager _instance;

    public Prefab prefab;

    private UICanvas _canvas;
    private Image _fadeImage;

    private float _timer;
    private float _fadeIn;
    private float _hold;
    private float _fadeOut;

    private enum FadeState
    {
        None,
        FadeIn,
        Hold,
        FadeOut
    }

    private FadeState _state = FadeState.None;

    public override void OnStart()
    {
        _instance = this;
        SpawnCanvas();
    }

    private void SpawnCanvas()
    {
        if (_canvas != null)
            return;

        if (prefab == null)
        {
            Debug.LogError("FadeCanvas prefab not set!");
            return;
        }

        var instance = PrefabManager.SpawnPrefab(prefab);

        _canvas = instance.GetChild<UICanvas>();

        var fadeActor = instance.FindActor("Fade") as UIControl;

        if (fadeActor == null)
        {
            Debug.LogError("Fade image not found in prefab!");
            return;
        }

        _fadeImage = fadeActor.Get<Image>();

        if (_fadeImage == null)
        {
            Debug.LogError("Fade Image component missing!");
            return;
        }

        var c = _fadeImage.BackgroundColor;
        c.A = 0;
        _fadeImage.BackgroundColor = c;
    }

    public override void OnUpdate()
    {
        if (_state == FadeState.None || _fadeImage == null)
            return;

        _timer += Time.DeltaTime;

        var color = _fadeImage.BackgroundColor;

        switch (_state)
        {
            case FadeState.FadeIn:

                if (_fadeIn <= 0)
                    color.A = 1;
                else
                    color.A = Mathf.Clamp(_timer / _fadeIn, 0, 1);

                _fadeImage.BackgroundColor = color;

                if (_timer >= _fadeIn)
                {
                    _timer = 0;
                    _state = FadeState.Hold;
                }

                break;

            case FadeState.Hold:

                if (_timer >= _hold)
                {
                    _timer = 0;
                    _state = FadeState.FadeOut;
                }

                break;

            case FadeState.FadeOut:

                if (_fadeOut <= 0)
                    color.A = 0;
                else
                    color.A = 1 - Mathf.Clamp(_timer / _fadeOut, 0, 1);

                _fadeImage.BackgroundColor = color;

                if (_timer >= _fadeOut)
                    _state = FadeState.None;

                break;
        }
    }

    public static void Fade(int mode, float fadeInDuration, float holdDuration, float fadeOutDuration)
    {
        if (_instance == null)
        {
            Debug.LogError("FadeManager instance not found.");
            return;
        }

        _instance._fadeIn = fadeInDuration;
        _instance._hold = holdDuration;
        _instance._fadeOut = fadeOutDuration;

        _instance._timer = 0;
        _instance._state = FadeState.FadeIn;
    }
}