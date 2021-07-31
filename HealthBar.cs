using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _fillLine;

    private Slider _slider;
    private bool _isSmoothAnimateStarted = false;
    private float _targetSliderValue = 0f;
    private int _sliderMaxValue = 100;
    private int _sliderSpeed = 50;

    private void Start()
    {
        if (TryGetComponent(out Slider slider))
        {
            _slider = slider;
            _slider.value = _sliderMaxValue;
        }
    }

    private void FixedUpdate()
    {
        if (_isSmoothAnimateStarted)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetSliderValue, _sliderSpeed * Time.deltaTime);
            ChangeHealhBarColorByValue((float)(_slider.value / 100));

            if (_slider.value == _targetSliderValue)
            {
                _isSmoothAnimateStarted = false;
            }
        }
    }

    public void OnChangeValue(int value)
    {
        if (_slider != null)
        {
            _isSmoothAnimateStarted = true;
            _targetSliderValue = _slider.value + value;
        }
    }

    public void ChangeHealhBarColorByValue(float value)
    {
        byte greenValue = (byte)(255 * value );
        byte redValue = (byte)(255 * (1 - value));

        _fillLine.color = new Color32(redValue, greenValue, 0, 255); 
    }
}
