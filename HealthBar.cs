using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _fillLine;

    private Slider _slider = null;
    private float _targetSliderValue = 0f;
    private int _sliderMaxValue = 100;
    private int _sliderSpeed = 10;

    private void Start()
    {
        if (TryGetComponent(out Slider slider))
        {
            _slider = slider;
            _slider.value = _sliderMaxValue;
        }
    }

    public void OnChangeValue(int value)
    {
        if (_slider != null)
        {
            _targetSliderValue = _slider.value + value;
            StartCoroutine(FillingBar(ChangeSliderValue));
        }
    }

    public void ChangeHealhBarColorByValue(float value)
    {
        byte greenValue = (byte)(255 * value );
        byte redValue = (byte)(255 * (1 - value));

        _fillLine.color = new Color32(redValue, greenValue, 0, 255); 
    }

    private IEnumerator FillingBar(UnityAction<float> lerpingEnd)
    {
        float elapsed = 0;
        while (!Mathf.Approximately(_slider.value, _targetSliderValue))
        {
            _slider.value = Mathf.Lerp(_slider.value, _targetSliderValue, _sliderSpeed * elapsed );
            ChangeHealhBarColorByValue((float)(_slider.value / 100));
            elapsed += Time.deltaTime;
            yield return null;
        }
        lerpingEnd?.Invoke(_targetSliderValue);
    }

    private void ChangeSliderValue (float value)
    {
        _slider.value = value;
    }
}
