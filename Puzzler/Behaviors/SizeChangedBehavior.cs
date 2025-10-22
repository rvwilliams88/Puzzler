using System.Windows.Input;

namespace Puzzler.Behaviors
{
    public partial class SizeChangedBehavior : Behavior<VisualElement>
    {
        public static readonly BindableProperty SizeChangedCommandProperty =
            BindableProperty.Create(nameof(SizeChangedCommand), typeof(ICommand), typeof(SizeChangedBehavior));

        public ICommand SizeChangedCommand
        {
            get => (ICommand)GetValue(SizeChangedCommandProperty);
            set => SetValue(SizeChangedCommandProperty, value);
        }

        protected override void OnAttachedTo(VisualElement bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.SizeChanged += OnSizeChanged;
        }

        protected override void OnDetachingFrom(VisualElement bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.SizeChanged -= OnSizeChanged;
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            if (sender is VisualElement ve && SizeChangedCommand?.CanExecute(ve) == true)
                SizeChangedCommand.Execute(ve);
        }
    }
}
