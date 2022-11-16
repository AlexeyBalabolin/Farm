using UnityEngine;

namespace UI
{
    public class ActorUI : MonoBehaviour
    {
        public GrownBar GrownBar;
        private IBar _bar;


        private void Awake()
        {
            IBar bar = GetComponent<IBar>();
            if (bar != null)
                Construct(bar);
        }

        public void Construct(IBar bar)
        {
            _bar = bar;
            _bar.OnValueChanged += UpdateHpBar;
        }

        private void UpdateHpBar() => GrownBar.SetValue(_bar.CurrentValue, _bar.MaxValue);

        private void OnDestroy() => _bar.OnValueChanged -= UpdateHpBar;
    }
}
