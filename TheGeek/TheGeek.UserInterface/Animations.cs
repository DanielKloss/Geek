﻿using System;
using Windows.Foundation.Metadata;
using Windows.UI.Composition;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

namespace TheGeek.UserInterface
{
    public static class Animations
    {
        public static void RegisterImplicitAnimations(this Panel panel)
        {
            if (!ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 3))
            {
                return;
            }

            var compositor = ElementCompositionPreview.GetElementVisual(panel).Compositor;

            var elementImplicitAnimation = compositor.CreateImplicitAnimationCollection();

            elementImplicitAnimation["Offset"] = CreateOffsetAnimation(compositor);

            foreach (var item in panel.Children)
            {
                var elementVisual = ElementCompositionPreview.GetElementVisual(item);
                elementVisual.ImplicitAnimations = elementImplicitAnimation;
            }
        }

        private static CompositionAnimationGroup CreateOffsetAnimation(Compositor compositor)
        {
            // Define Offset Animation for the Animation group
            var offsetAnimation = compositor.CreateVector3KeyFrameAnimation();
            offsetAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue");
            offsetAnimation.Duration = TimeSpan.FromSeconds(.4);

            // Define Animation Target for this animation to animate using definition. 
            offsetAnimation.Target = "Offset";

            // Define Rotation Animation for Animation Group. 
            var rotationAnimation = compositor.CreateScalarKeyFrameAnimation();
            rotationAnimation.InsertKeyFrame(.5f, 0.160f);
            rotationAnimation.InsertKeyFrame(1f, 0f);
            rotationAnimation.Duration = TimeSpan.FromSeconds(.4);

            // Define Animation Target for this animation to animate using definition. 
            rotationAnimation.Target = "RotationAngle";

            // Add Animations to Animation group. 
            var animationGroup = compositor.CreateAnimationGroup();
            animationGroup.Add(offsetAnimation);
            animationGroup.Add(rotationAnimation);

            return animationGroup;
        }
    }
}
