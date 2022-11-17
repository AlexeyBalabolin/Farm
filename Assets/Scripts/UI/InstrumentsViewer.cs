using Gameplay;
using Infrastructure.Factory;
using Infrastructure.Services;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstrumentsViewer : MonoBehaviour
{
    [SerializeField]
    private List<InstrumentData> _instruments;

    [SerializeField]
    private Image _instrumentImage;

    [SerializeField]
    private Transform _instrumentsPanel;

    private IGameFactory _gameFactory;

    private void Start()
    {
        _gameFactory = ServiceLocator.Container.GetService<IGameFactory>();
        FillInstrumentsWindow();
    }

    private void FillInstrumentsWindow()
    {
        foreach(InstrumentData data in _instruments)
        {
            Instrument instrument = _gameFactory.CreateGameobjectAtPoint(_instrumentImage.gameObject, _instrumentsPanel).GetComponent<Instrument>();
            instrument.GetComponent<Image>().sprite = data.InstrumentSprite;
            instrument.GetComponent<RectTransform>().localScale = Vector3.one;
            instrument.Construct(data.InstrumentType);
        }
    }
}
