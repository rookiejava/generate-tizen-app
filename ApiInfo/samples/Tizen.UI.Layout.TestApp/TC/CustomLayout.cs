using Tizen.UI;
using Tizen.UI.Layouts;

namespace LayoutTest.TC
{
    /// <summary>
    /// CustomLayout is an example of a class that inherits from ViewGroup and implements IStackLayout
    /// to provide layout functionality using a LayoutManager. It uses LayoutHelper to simplify implementation.
    /// </summary>
    public class CustomVStackLayout : ViewGroup, IStackLayout
    {
        private readonly LayoutHelper _layoutHelper;
        private readonly ILayoutManager _layoutManagerInstance;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomLayout"/> class.
        /// </summary>
        public CustomVStackLayout()
        {
            _layoutManagerInstance = new VStackLayoutManager(this);
            _layoutHelper = new LayoutHelper(this, _layoutManagerInstance);
        }

        /// <summary>
        /// Gets or sets the padding of the layout.
        /// </summary>
        public Thickness Padding { get; set; }



        /// <summary>
        /// Gets or sets the spacing between child elements in the stack.
        /// </summary>
        public float Spacing { get; set; }

        /// <summary>
        /// Gets or sets the alignment of the child elements within the stack.
        /// </summary>
        public LayoutAlignment ItemAlignment { get; set; }

        LayoutParam ILayout.LayoutParam => this.LayoutParam();


        /// <summary>
        /// Gets the layout manager for the layout.
        /// </summary>
        protected virtual ILayoutManager LayoutManager => _layoutManagerInstance;


        /// <summary>
        /// Updates the layout.
        /// </summary>
        public void UpdateLayout()
        {
            _layoutHelper.UpdateLayout();
        }

        /// <summary>
        /// Updates the layout with the specified bounds.
        /// </summary>
        /// <param name="bounds">The bounds to update the layout with.</param>
        /// <returns>The size of the layout after updating.</returns>
        public virtual Size UpdateLayout(Rect bounds)
        {
            return _layoutHelper.UpdateLayout(bounds);
        }

        /// <summary>
        /// Measures the layout with the specified available width and height.
        /// </summary>
        /// <param name="availableWidth">The available width to measure the layout with.</param>
        /// <param name="availableHeight">The available height to measure the layout with.</param>
        /// <returns>The size of the layout after measuring.</returns>
        public override Size Measure(float availableWidth, float availableHeight)
        {
            return _layoutHelper.Measure(availableWidth, availableHeight);
        }

        /// <summary>
        /// Called when a child is added to the layout.
        /// </summary>
        /// <param name="view">The view that was added to the layout.</param>
        protected override void OnChildAdded(View view)
        {
            base.OnChildAdded(view);
            _layoutHelper.OnChildAdded(view);
        }

        /// <summary>
        /// Called when a child is removed from the layout.
        /// </summary>
        /// <param name="view">The view that was removed from the layout.</param>
        protected override void OnChildRemoved(View view)
        {
            base.OnChildRemoved(view);
            _layoutHelper.OnChildRemoved(view);
        }

        /// <inheritdoc/>
        protected override void OnMeasureInvalidatedOverride()
        {
            _layoutHelper.OnMeasureInvalidated();
            base.OnMeasureInvalidatedOverride();
        }

        /// <summary>
        /// Disposes of the layout.
        /// </summary>
        /// <param name="disposing"><see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _layoutHelper.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}