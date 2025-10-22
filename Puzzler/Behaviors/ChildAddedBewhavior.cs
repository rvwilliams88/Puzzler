using System.Windows.Input;

namespace Puzzler.Behaviors
{
    public class ChildAddedBehavior : Behavior<CollectionView>
    {
        public static readonly BindableProperty ChildAddedCommandProperty =
            BindableProperty.Create(nameof(ChildAddedCommand), typeof(ICommand), typeof(ChildAddedBehavior));

        public ICommand ChildAddedCommand
        {
            get => (ICommand)GetValue(ChildAddedCommandProperty);
            set => SetValue(ChildAddedCommandProperty, value);
        }

        protected override void OnAttachedTo(CollectionView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ChildAdded += OnChildAdded;
        }

        protected override void OnDetachingFrom(CollectionView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.ChildAdded -= OnChildAdded;
        }

        private void OnChildAdded(object sender, ElementEventArgs e)
        {
            if (ChildAddedCommand?.CanExecute(e.Element) == true)
                ChildAddedCommand.Execute(e.Element);
        }
    }
}
