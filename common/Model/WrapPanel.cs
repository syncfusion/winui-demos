#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;

namespace Syncfusion.DemosCommon.WinUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;   
    using Windows.Foundation;

    /// <summary>
    /// WrapPanel is a panel that position child control vertically or horizontally based on the orientation.
    /// </summary>
    public partial class WrapPanel : Panel
    {
        /// <summary>
        /// Identifies the <see cref="HorizontalSpacing"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalSpacingProperty =
            DependencyProperty.Register(
                nameof(HorizontalSpacing),
                typeof(double),
                typeof(WrapPanel),
                new PropertyMetadata(0d, LayoutPropertyChanged));

        /// <summary>
        /// Identifies the <see cref="VerticalSpacing"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalSpacingProperty =
            DependencyProperty.Register(
                nameof(VerticalSpacing),
                typeof(double),
                typeof(WrapPanel),
                new PropertyMetadata(0d, LayoutPropertyChanged));

        /// <summary>
        /// Identifies the <see cref="Orientation"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register(
                nameof(Orientation),
                typeof(Orientation),
                typeof(WrapPanel),
                new PropertyMetadata(Orientation.Horizontal, LayoutPropertyChanged));

        /// <summary>
        /// Identifies the Padding dependency property.
        /// </summary>
        /// <returns>The identifier for the <see cref="Padding"/> dependency property.</returns>
        public static readonly DependencyProperty PaddingProperty =
            DependencyProperty.Register(
                nameof(Padding),
                typeof(Thickness),
                typeof(WrapPanel),
                new PropertyMetadata(default(Thickness), LayoutPropertyChanged));

        private readonly List<Row> rows = new List<Row>();

        /// <summary>
        /// Gets or sets a uniform Horizontal distance (in pixels) between items when <see cref="Orientation"/> is set to Horizontal,
        /// or between columns of items when <see cref="Orientation"/> is set to Vertical.
        /// </summary>
        public double HorizontalSpacing
        {
            get { return (double)this.GetValue(HorizontalSpacingProperty); }
            set { this.SetValue(HorizontalSpacingProperty, value); }
        }

        /// <summary>
        /// Gets or sets the orientation of the WrapPanel.
        /// Horizontal means that child controls will be added horizontally until the width of the panel is reached, then a new row is added to add new child controls.
        /// Vertical means that children will be added vertically until the height of the panel is reached, then a new column is added.
        /// </summary>
        public Orientation Orientation
        {
            get { return (Orientation)this.GetValue(OrientationProperty); }
            set { this.SetValue(OrientationProperty, value); }
        }

        /// <summary>
        /// Gets or sets a uniform Vertical distance (in pixels) between items when <see cref="Orientation"/> is set to Vertical,
        /// or between rows of items when <see cref="Orientation"/> is set to Horizontal.
        /// </summary>
        public double VerticalSpacing
        {
            get { return (double)this.GetValue(VerticalSpacingProperty); }
            set { this.SetValue(VerticalSpacingProperty, value); }
        }

        /// <summary>
        /// Gets or sets the distance between the border and its child object.
        /// </summary>
        /// <returns>
        /// The dimensions of the space between the border and its child as a Thickness value.
        /// Thickness is a structure that stores dimension values using pixel measures.
        /// </returns>
        public Thickness Padding
        {
            get { return (Thickness)this.GetValue(PaddingProperty); }
            set { this.SetValue(PaddingProperty, value); }
        }

        /// <inheritdoc />
        protected override Size MeasureOverride(Size availableSize)
        {
            var childAvailableSize = new Size(
                availableSize.Width - this.Padding.Left - this.Padding.Right,
                availableSize.Height - this.Padding.Top - this.Padding.Bottom);
            foreach (var child in this.Children)
            {
                child.Measure(childAvailableSize);
            }

            var requiredSize = this.UpdateRows(availableSize);
            return requiredSize;
        }

        /// <inheritdoc />
        protected override Size ArrangeOverride(Size finalSize)
        {
            if ((this.Orientation == Orientation.Horizontal && finalSize.Width < this.DesiredSize.Width) ||
                (this.Orientation == Orientation.Vertical && finalSize.Height < this.DesiredSize.Height))
            {
                // We haven't received our desired size. We need to refresh the rows.
                this.UpdateRows(finalSize);
            }

            if (this.rows.Count > 0)
            {
                // Now that we have all the data, we do the actual arrange pass
                var childIndex = 0;
                foreach (var row in this.rows)
                {
                    foreach (var rect in row.ChildrenRects)
                    {
                        var child = this.Children[childIndex++];
                        while (child.Visibility == Visibility.Collapsed)
                        {
                            // Collapsed children are not added into the rows,
                            // we skip them.
                            child = this.Children[childIndex++];
                        }

                        var arrangeRect = new UvRect
                        {
                            Position = rect.Position,
                            Size = new UvMeasure { U = rect.Size.U, V = row.Size.V },
                        };

                        var finalRect = arrangeRect.ToRect(this.Orientation);
                        child.Arrange(finalRect);
                    }
                }
            }

            return finalSize;
        }

        private static void LayoutPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is WrapPanel wp)
            {
                wp.InvalidateMeasure();
                wp.InvalidateArrange();
            }
        }

        private Size UpdateRows(Size availableSize)
        {
            this.rows.Clear();

            var paddingStart = new UvMeasure(this.Orientation, this.Padding.Left, this.Padding.Top);
            var paddingEnd = new UvMeasure(this.Orientation, this.Padding.Right, this.Padding.Bottom);

            if (this.Children.Count == 0)
            {
                var emptySize = paddingStart.Add(paddingEnd).ToSize(this.Orientation);
                return emptySize;
            }

            var parentMeasure = new UvMeasure(this.Orientation, availableSize.Width, availableSize.Height);
            var spacingMeasure = new UvMeasure(this.Orientation, this.HorizontalSpacing, this.VerticalSpacing);
            var position = new UvMeasure(this.Orientation, this.Padding.Left, this.Padding.Top);

            var currentRow = new Row(new List<UvRect>(), default);
            var finalMeasure = new UvMeasure(this.Orientation, width: 0.0, height: 0.0);
            void Arrange(UIElement child, bool isLast = false)
            {
                if (child.Visibility == Visibility.Collapsed)
                {
                    return; // if an item is collapsed, avoid adding the spacing
                }

                var desiredMeasure = new UvMeasure(this.Orientation, child.DesiredSize);
                if ((desiredMeasure.U + position.U + paddingEnd.U) > parentMeasure.U)
                {
                    // next row!
                    position.U = paddingStart.U;
                    position.V += currentRow.Size.V + spacingMeasure.V;

                    this.rows.Add(currentRow);
                    currentRow = new Row(new List<UvRect>(), default);
                }

                // Stretch the last item to fill the available space
                if (isLast)
                {
                    desiredMeasure.U = parentMeasure.U - position.U;
                }

                currentRow.Add(position, desiredMeasure);

                // adjust the location for the next items
                position.U += desiredMeasure.U + spacingMeasure.U;
                finalMeasure.U = Math.Max(finalMeasure.U, position.U);
            }

            var lastIndex = this.Children.Count - 1;
            for (var i = 0; i < lastIndex; i++)
            {
                Arrange(this.Children[i]);
            }

            Arrange(this.Children[lastIndex], false);
            if (currentRow.ChildrenRects.Count > 0)
            {
                this.rows.Add(currentRow);
            }

            if (this.rows.Count == 0)
            {
                var emptySize = paddingStart.Add(paddingEnd).ToSize(this.Orientation);
                return emptySize;
            }

            // Get max V here before computing final rect
            var lastRowRect = this.rows.Last().Rect;
            finalMeasure.V = lastRowRect.Position.V + lastRowRect.Size.V;
            var finalRect = finalMeasure.Add(paddingEnd).ToSize(this.Orientation);
            return finalRect;
        }
    }

    /// <summary>
    /// WrapPanel is a panel that position child control vertically or horizontally based on the orientation.
    /// </summary>
    public partial class WrapPanel
    {
        [System.Diagnostics.DebuggerDisplay("U = {U} V = {V}")]
        private struct UvMeasure
        {
            public UvMeasure(Orientation orientation, Size size)
                : this(orientation, size.Width, size.Height)
            {
            }

            public UvMeasure(Orientation orientation, double width, double height)
            {
                if (orientation == Orientation.Horizontal)
                {
                    this.U = width;
                    this.V = height;
                }
                else
                {
                    this.U = height;
                    this.V = width;
                }
            }

            internal static UvMeasure Zero => default;

            internal double U { get; set; }

            internal double V { get; set; }

            public UvMeasure Add(double u, double v)
                => new UvMeasure { U = this.U + u, V = this.V + v };

            public UvMeasure Add(UvMeasure measure)
                => this.Add(measure.U, measure.V);

            public Size ToSize(Orientation orientation)
                => orientation == Orientation.Horizontal ? new Size(this.U, this.V) : new Size(this.V, this.U);
        }

        private struct UvRect
        {
            public UvMeasure Position { get; set; }

            public UvMeasure Size { get; set; }

            public Rect ToRect(Orientation orientation)
            {
                switch (orientation)
                {
                    case Orientation.Horizontal:
                        return new Rect(this.Position.U, this.Position.V, this.Size.U, this.Size.V);
                    case Orientation.Vertical:
                        return new Rect(this.Position.V, this.Position.U, this.Size.V, this.Size.U);
                    default:
                        return Rect.Empty;
                }
            }
        }

        private struct Row
        {
            public Row(List<UvRect> childrenRects, UvMeasure size)
            {
                this.ChildrenRects = childrenRects;
                this.Size = size;
            }

            public List<UvRect> ChildrenRects { get; }

            public UvMeasure Size { get; set; }

            public UvRect Rect => this.ChildrenRects.Count > 0 ?
                new UvRect { Position = this.ChildrenRects[0].Position, Size = this.Size } :
                new UvRect { Position = UvMeasure.Zero, Size = this.Size };

            public void Add(UvMeasure position, UvMeasure size)
            {
                this.ChildrenRects.Add(new UvRect { Position = position, Size = size });
                this.Size = new UvMeasure
                {
                    U = position.U + size.U,
                    V = Math.Max(this.Size.V, size.V),
                };
            }
        }
    }

}
