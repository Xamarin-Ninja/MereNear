using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MereNear.CustomControl
{
    public class SlidePanelView : ContentView
    {
        public static readonly BindableProperty SwipedLeftCommandProperty =
            BindableProperty.Create(
                nameof(SwipedUpCommand),
                typeof(ICommand),
                typeof(SwipeCardView));

        public static readonly BindableProperty SwipedRightCommandProperty =
            BindableProperty.Create(
                nameof(SwipedDownCommand),
                typeof(ICommand),
                typeof(SwipeCardView));

          private const int AnimationLength = 250; // Speed of the animations


        private const string DefaultBackgroundColor = "#F5F8FA";

        private const string DefaultCardBackgroundColor = "#FFFFFF";

        private const string SwipeLeftBackgroundColor = "#efc450";

        private const string SwipeRightBackgroundColor = "#66BB6A";

        private readonly View Panel = new SlidePanelView();

        private float cardDistance = 0;   // Distance the card has been moved

        private bool ignoreTouch = false;

        public SlidePanelView()
        {
            var view = new RelativeLayout();

            this.BackgroundColor = Color.FromHex(DefaultBackgroundColor);
            this.Content = view;

            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += this.OnPanUpdated;
            this.GestureRecognizers.Add(panGesture);
        }

        public int CardMoveDistance { get; set; } // Distance a card must be moved to consider to be swiped off


        public ICommand SwipedUpCommand
        {
            get => (ICommand)this.GetValue(SwipedLeftCommandProperty);
            set => this.SetValue(SwipedLeftCommandProperty, value);
        }

        public ICommand SwipedDownCommand
        {
            get => (ICommand)this.GetValue(SwipedRightCommandProperty);
            set => this.SetValue(SwipedRightCommandProperty, value);
        }

        /// <summary>
        /// Simpulates PanGesture movement on left
        /// </summary>
        /// <param name="numberOfTouches">Number of touch events. It should be positive number (i.e. 50)</param>
        /// <param name="differenceX">Distance betweeen two touches. It should be positive number (i.e. 50)</param>
        public void InvokeSwipeUp(int numberOfTouches, int differenceX, int differenceY)
        {
            if (numberOfTouches <= 0 || differenceX <= 0 || differenceY <= 0)
            {
                return;
            }

            this.HandleTouchStart();

            for (var i = 1; i < numberOfTouches; i++)
            {
                HandleTouch(-differenceY * i);
            }

            this.HandleTouchEnd();
        }

        /// <summary>
        /// Simpulates PanGesture movement on right
        /// </summary>
        /// <param name="numberOfTouches">Number of touch events. It should be positive number (i.e. 50)</param>
        /// <param name="differenceX">Distance betweeen two touches. It should be positive number (i.e. 50)</param>
        public void InvokeSwipeDown(int numberOfTouches, int differenceX, int differenceY)
        {
            if (numberOfTouches <= 0 || differenceX <= 0 || differenceY <= 0)
            {
                return;
            }

            this.HandleTouchStart();

            for (var i = 1; i < numberOfTouches; i++)
            {
                HandleTouch(differenceY * i);
            }

            this.HandleTouchEnd();
        }


        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    this.HandleTouchStart();
                    break;
                case GestureStatus.Running:
                    this.HandleTouch((float)e.TotalY);
                    break;
                case GestureStatus.Completed:
                    this.HandleTouchEnd();
                    break;
            }
        }

        // Hande when a touch event begins
        private void HandleTouchStart()
        {
            this.cardDistance = 0;
        }

        // Handle the ongoing touch event as the card is moved
        private void HandleTouch(float differenceY)
        {
            if (this.ignoreTouch)
            {
                return;
            }
                // Move the card
                Panel.TranslationY = differenceY;


                // Keep a record of how far its moved
                this.cardDistance = differenceY;

                if (Math.Abs((int)this.cardDistance) > this.CardMoveDistance)
                {
                    if (this.cardDistance > 00)
                    {
                        Panel.BackgroundColor = Color.FromHex(SwipeRightBackgroundColor);

                    }
                    else if (this.cardDistance < -100)
                    {
                        Panel.BackgroundColor = Color.FromHex(SwipeLeftBackgroundColor);
                        //MessagingCenter.Send(topCard, "CardSwipe");
                    }
                }
                else
                {
                    Panel.BackgroundColor = Color.FromHex(DefaultCardBackgroundColor);
                    //MessagingCenter.Send(topCard, "CardSwipe");
                }           
           }

        // Handle the end of the touch event
        private async void HandleTouchEnd()
        {
            this.ignoreTouch = true;
            Panel.BackgroundColor = Color.FromHex(DefaultCardBackgroundColor);
            // If the card was move enough to be considered swiped off
            var swapeddistance = Math.Abs((int)this.cardDistance);
            if (this.cardDistance > 10)
            {
                // move off the screen
                await Panel.TranslateTo(0,Panel.Height, AnimationLength/2, Easing.Linear);

            }
            else if (this.cardDistance < -10)
            {
                // move off the screen
                await Panel.TranslateTo(0, -this.Panel.Height, AnimationLength / 2, Easing.Linear);
            }
            else
            {
                // Move the top card back to the center
                await Panel.TranslateTo((-Panel.X), -Panel.Y, AnimationLength, Easing.Linear);
            }
            this.ignoreTouch = false;
        }
    }
}
