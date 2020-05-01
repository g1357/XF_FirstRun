using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace XF_FirstRun.Behaviors
{
    /// <summary>
    /// Базовый класс для создания "поведений" (Behavior)
    /// </summary>
    /// <typeparam name="T">Класс к которому добавляется "поведение"</typeparam>
    abstract public class BaseBehavior<T> : Behavior<T> where T : BindableObject
    {
        
        /// <summary>
        /// Объест к которому добавляется "поведение"
        /// </summary>
        public T AssociatedObject { get; private set; }

        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;
            if (bindable.BindingContext != null)
            {
                BindingContext = bindable.BindingContext;
            }
            bindable.BindingContextChanged += OnBindableContextChanged;
        }

        protected override void OnDetachingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindableContextChanged;
            AssociatedObject = null;
        }
        void OnBindableContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}
