using UnityEngine;
using UnityEngine.UIElements;

namespace BRDK2.Layout
{
    public class DashboardLayout
    {
        public VisualElement Root { get; }

        public VisualElement Hero { get; }

        public VisualElement Build { get; }

        public VisualElement Stats { get; }

        public VisualElement Health { get; }

        public VisualElement Console { get; }

        public VisualElement Tools { get; }

        public DashboardLayout()
        {
            //------------------------------------------------
            // ROOT
            //------------------------------------------------

            Root = new VisualElement();

            Root.style.flexGrow = 1;
            Root.style.paddingLeft = 28;
            Root.style.paddingRight = 28;
            Root.style.paddingTop = 24;
            Root.style.paddingBottom = 24;

            Root.style.flexDirection = FlexDirection.Column;

            //------------------------------------------------
            // TOP
            //------------------------------------------------

            VisualElement top = new VisualElement();

            top.style.flexDirection = FlexDirection.Row;
            top.style.height = 200;
            top.style.marginBottom = 22;

            Root.Add(top);

            Hero = new VisualElement();

            Hero.style.flexGrow = 3;
            Hero.style.marginRight = 20;

            top.Add(Hero);

            Build = new VisualElement();

            Build.style.width = 340;

            top.Add(Build);

            //------------------------------------------------
            // STATS
            //------------------------------------------------

            Stats = new VisualElement();

            Stats.style.height = 150;
            Stats.style.marginBottom = 22;

            Root.Add(Stats);

            //------------------------------------------------
            // BOTTOM
            //------------------------------------------------

            VisualElement bottom = new VisualElement();

            bottom.style.flexGrow = 1;
            bottom.style.flexDirection = FlexDirection.Row;

            Root.Add(bottom);

            //------------------------------------------------
            // LEFT
            //------------------------------------------------

            VisualElement left = new VisualElement();

            left.style.flexGrow = 2;
            left.style.marginRight = 20;

            bottom.Add(left);

            Health = new VisualElement();

            Health.style.flexGrow = 1;
            Health.style.marginBottom = 20;

            left.Add(Health);

            //------------------------------------------------
            // RIGHT
            //------------------------------------------------

            VisualElement right = new VisualElement();

            right.style.flexGrow = 1;

            bottom.Add(right);

            Console = new VisualElement();

            Console.style.flexGrow = 1;
            Console.style.marginBottom = 20;

            right.Add(Console);

            Tools = new VisualElement();

            Tools.style.height = 320;

            right.Add(Tools);
        }
    }
}