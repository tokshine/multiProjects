//using System;
//using System.Collections.Generic;
//using System.Text;
//using Xamarin.Forms;

//namespace MultiProjects.Behaviour
//{
//    public class NavigationBehavior : Behavior<TemplatedPage>
//    {

//        private INavigation navService;

//        public string TargetPage { get; set; }

//        protected override void OnAttachedTo(View bindable)
//        {
//            base.OnAttachedTo(bindable);
//            bindable. += bindable_Clicked;
//        }

//        protected override void OnDetachingFrom(TemplatedPage bindable)
//        {
//            base.OnDetachingFrom(bindable);

//            bindable.Clicked -= bindable_Clicked;
//        }
//    }
//}
